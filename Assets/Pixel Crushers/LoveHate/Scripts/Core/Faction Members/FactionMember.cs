using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace PixelCrushers.LoveHate
{

	public delegate bool CanSeeDelegate(FactionMember other, Dimension dimension);

	public delegate Rumor EvaluateRumorDelegate(Rumor rumor, FactionMember source);

	public delegate float GetPowerLevelDelegate();

	/// <summary>
	/// A faction member is a GameObject that's a member of a faction. This script
	/// handles functionality tied to the member such as PAD emotional state, 
	/// witnessing deeds, and sharing rumors.
	/// </summary>
	[AddComponentMenu("Love\u2215Hate/Faction Member")]
	public class FactionMember : MonoBehaviour
	{

		/// <summary>
		/// A reference to the FactionManager that will manage the FactionDatabase
		/// containing the Faction that this member belongs to.
		/// </summary>
		public FactionManager factionManager;

		/// <summary>
		/// An editor-time-only reference to the FactionDatabase, to be used only 
		/// by the editor to provide a popup list for the user to set factionID.
		/// To access the FactionDatabase at runtime, go through factionManager.
		/// </summary>
		public FactionDatabase factionDatabase;

		/// <summary>
		/// The faction this member belongs to.
		/// </summary>
		public int factionID = 0;
		
		/// <summary>
		/// The current Pleasure-Arousal-Dominance model emotional state.
		/// </summary>
		public Pad pad = new Pad();
		
		/// <summary>
		/// Only acknowledge deeds whose impact is above this threshold.
		/// </summary>
		[Range(0,100)]
		public float deedImpactThreshold = 5;

		/// <summary>
		/// Specifies how quickly the impact of repeated deeds drops off.
		/// </summary>
		public AnimationCurve acclimatizationCurve = new AnimationCurve(
			new Keyframe[2] { new Keyframe(0, 1), new Keyframe(20, 0) } );
		
		/// <summary>
		/// The max memories to store. Older memories are dropped if over the limit.
		/// </summary>
		public int maxMemories = 50;
		
		/// <summary>
		/// The short term memory duration. Short term memory affects the faction's PAD.
		/// </summary>
		public float shortTermMemoryDuration = 300;
		
		/// <summary>
		/// The long term memory duration. Rumors are shared from long term memory.
		/// </summary>
		public float longTermMemoryDuration = 3600;
		
		/// <summary>
		/// The frequency in seconds at which to remove old memories. This frequency applies
		/// to level of detail (LOD) 0. Higher LOD values will decrease the frequency.
		/// </summary>
		public float memoryCleanupFrequency = 2;
		
		/// <summary>
		/// If `true` memories are sorted in ascending order of their subjective magnitude.
		/// </summary>
		public bool sortMemories = false;
		
		public List<Rumor> shortTermMemory = new List<Rumor>();
		
		public List<Rumor> longTermMemory = new List<Rumor>();
		
		/// <summary>
		/// The transform to raycast from for perception checks. If `null` this GameObject is used.
		/// </summary>
		public Transform eyes = null;

		/// <summary>
		/// The sight layer mask used for perception checks.
		/// </summary>
		public LayerMask sightLayerMask = 1;

		/// <summary>
		/// Set `true` to log details about rumor evaluation.
		/// </summary>
		public bool debugEvalFunc = false;

		/// <summary>
		/// Gets the faction.
		/// </summary>
		/// <value>The faction.</value>
		public Faction faction { get { return GetMyFaction(); } }

		/// <summary>
		/// Assign this delegate to override the default perception check method, which 
		/// does a simple raycast.
		/// </summary>
		public CanSeeDelegate CanSee = null;

		/// <summary>
		/// Assign this delegate to override the default rumor evaluation function.
		/// </summary>
		public EvaluateRumorDelegate EvaluateRumor = null;
		
		/// <summary>
		/// Assign this delegate to override the default power level check, which simply 
		/// returns `1`.
		/// </summary>
		public GetPowerLevelDelegate GetPowerLevel = null;
		
		/// <summary>
		/// Assign this delegate to override the default self-perceived power level check,
		/// which simply returns `1`. This is a separate method from GetPowerLevel to
		/// allow factions to think they're stronger or weaker than they really are.
		/// </summary>
		public GetPowerLevelDelegate GetSelfPerceivedPowerLevel = null;
		
		private bool m_started = false;

		private bool m_registered = false;

		/// <summary>
		/// The current memory cleanup frequency based on level of detail (LOD).
		/// </summary>
		private float m_currentMemoryCleanupFrequency = 2;

		private Faction m_faction = null;

		#region Initialization

		public bool FindResources()
		{
			if (factionManager == null)
			{
				factionManager = FindObjectOfType<FactionManager>();
			}
			if (factionDatabase == null)
			{
				if (factionManager != null)
				{
					factionDatabase = factionManager.factionDatabase;
				}
				if (factionDatabase == null)
				{
					var databases = Resources.FindObjectsOfTypeAll<FactionDatabase>();
					if (databases.Length > 0)
					{
						factionDatabase = databases[0];
					}
				}
			}
			return (factionManager != null && factionDatabase != null);
		}

		protected virtual void Awake()
		{
			CanSee = DefaultCanSee;
			EvaluateRumor = DefaultEvaluateRumor;
			GetPowerLevel = DefaultGetPowerLevel;
			GetSelfPerceivedPowerLevel = DefaultGetPowerLevel;
			m_currentMemoryCleanupFrequency = memoryCleanupFrequency;
		}

		protected virtual void Start()
		{
			m_started = true;
			if (FindResources())
			{
				Register();
				acclimatizationCurve.postWrapMode = WrapMode.Clamp;
				StartMemoryCleanup();
			}
			else
			{
				if (factionManager == null)
				{
					Debug.LogError("Love/Hate: Faction member can't find FactionManager", this);
				}
				else if (factionDatabase == null)
				{
					Debug.LogError("Love/Hate: Faction member can't find faction database", this);
				}
				enabled = false;
			}
		}

		private Faction GetMyFaction()
		{
			if (m_faction == null && FindResources())
			{
				m_faction = factionManager.GetFaction(factionID);
				Register();
			}
			return m_faction;
		}
		
		protected virtual void OnEnable()
		{
			Register();
			StartMemoryCleanup();
		}

		protected virtual void OnDisable()
		{
			Unregister();
			StopMemoryCleanup();
		}

		private void Register()
		{
			if (m_started && !m_registered && FindResources())
			{
				m_registered = true;
				factionManager.RegisterFactionMember(this);
			}
		}

		private void Unregister()
		{
			if (m_registered && FindResources())
			{
				factionManager.UnregisterFactionMember(this);
				m_registered = false;
			}
		}

		#endregion

		#region Memory

		public void StartMemoryCleanup()
		{
			StopMemoryCleanup();
			StartCoroutine(MemoryCleanupCoroutine());
		}

		public void StopMemoryCleanup()
		{
			StopAllCoroutines();
		}

		private IEnumerator MemoryCleanupCoroutine()
		{
			yield return new WaitForSeconds(UnityEngine.Random.value);
			while (true)
			{
				yield return new WaitForSeconds(m_currentMemoryCleanupFrequency);
				if (Time.timeScale > 0)
				{
					CleanMemory();
				}
			}
		}

		public void CleanMemory()
		{
			CleanShortTermMemory();
			CleanLongTermMemory();
		}
		
		private void CleanShortTermMemory()
		{
			for (int i = shortTermMemory.Count - 1; i >= 0; i--)
			{
				var rumor = shortTermMemory[i];
				if (rumor.isExpiredFromShortTerm)
				{
					pad.Modify(0, -rumor.pleasure, -rumor.arousal, -rumor.dominance);
					shortTermMemory.RemoveAt(i);
				}
			}
		}
		
		private void CleanLongTermMemory()
		{
			for (int i = longTermMemory.Count - 1; i >= 0; i--)
			{
				var rumor = longTermMemory[i];
				if (rumor.isExpiredFromLongTerm)
				{
					longTermMemory.RemoveAt(i);
					Rumor.Release(rumor);
				}
			}
		}
		
		public void OnLOD(int level)
		{
			m_currentMemoryCleanupFrequency = (level + 1) * memoryCleanupFrequency;
		}

		/// <summary>
		/// Checks if this faction contains a memory of a deed identified by its deed GUID.
		/// </summary>
		/// <returns>`true`, if the faction member contains a memory of the deed, `false` otherwise.</returns>
		/// <param name="deedGuid">Deed GUID.</param>
		public bool KnowsAboutDeed(Guid deedGuid)
		{
			return longTermMemory.Exists(rumor => rumor.deedGuid.Equals(deedGuid));
		}

		/// <summary>
		/// Checks if this faction contains a memory of a deed done by an actor to a target
		/// identified by a deed tag.
		/// </summary>
		/// <returns><c>true</c>, if the faction member contains a memory of the deed, <c>false</c> otherwise.</returns>
		/// <param name="actorFactionID">Actor faction ID.</param>
		/// <param name="targetFactionID">Target faction ID.</param>
		/// <param name="deedTag">Deed tag.</param>
		public bool KnowsAboutDeed(int actorFactionID, int targetFactionID, string deedTag)
		{
			for (int i = 0; i < longTermMemory.Count; i++)
			{
				var rumor = longTermMemory[i];
				if (rumor.actorFactionID == actorFactionID &&
				    rumor.targetFactionID == actorFactionID &&
				    string.Equals(rumor.tag, deedTag))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Looks for an existing similar rumor in memory.
		/// </summary>
		/// <returns><c>true</c>, if old rumor was found, <c>false</c> otherwise.</returns>
		/// <param name="newRumor">New rumor.</param>
		/// <param name="oldRumor">Old rumor.</param>
		public bool FindOldRumor(Rumor newRumor, out Rumor oldRumor)
		{
			for (int i = 0; i < longTermMemory.Count; i++)
			{
				var rumor = longTermMemory[i];
				if (string.Equals(rumor.tag, newRumor.tag) &&
					(rumor.actorFactionID == newRumor.actorFactionID) &&
					(rumor.targetFactionID == newRumor.targetFactionID))
				{
					oldRumor = rumor;
					return true;
				}
			}
			oldRumor = null;
			return false;
		}
		
		private void AddRumorToMemory(Rumor rumor) 
		{
			AddRumorToMemory(rumor, shortTermMemory);
			AddRumorToMemory(rumor, longTermMemory);
		}
		
		private void AddRumorToMemory(Rumor rumor, List<Rumor> memory)
		{
			if (maxMemories <= 0) return;
			if (memory.Count >= maxMemories)
			{
				Rumor.Release(memory[0]);
				memory.RemoveAt(0);
			}
			if (sortMemories)
			{
				memory.AddSorted(rumor);
			}
			else
			{
				memory.Add(rumor);
			}
		}

		#endregion

		#region Relationships

		/// <summary>
		/// Sets the personal affinity to a subject.
		/// </summary>
		/// <param name="subjectFactionID">Subject faction ID.</param>
		/// <param name="affinity">Affinity.</param>
		public void SetPersonalAffinity(int subjectFactionID, float affinity)
		{
			if (!FindResources()) return;
			factionManager.SetPersonalAffinity(factionID, subjectFactionID, affinity);
		}

		/// <summary>
		/// Sets the personal affinity to a subject.
		/// </summary>
		/// <param name="subjectFactionName">Subject faction name.</param>
		/// <param name="affinity">Affinity.</param>
		public void SetPersonalAffinity(string subjectFactionName, float affinity)
		{
			if (!FindResources()) return;
			factionManager.SetPersonalAffinity(faction.name, subjectFactionName, affinity);
		}

		/// <summary>
		/// Modifies (increments or decrements) the personal affinity to a subject.
		/// </summary>
		/// <param name="subjectFactionID">Subject faction ID.</param>
		/// <param name="affinityChange">Affinity change.</param>
		public void ModifyPersonalAffinity(int subjectFactionID, float affinityChange)
		{
			if (!FindResources()) return;
			factionManager.ModifyPersonalAffinity(faction.id, subjectFactionID, affinityChange);
		}
		
		/// <summary>
		/// Modifies (increments or decrements) the personal affinity to a subject.
		/// </summary>
		/// <param name="subjectFactionName">Subject faction name.</param>
		/// <param name="affinityChange">Affinity change.</param>
		public void ModifyPersonalAffinity(string subjectFactionName, float affinityChange)
		{
			if (!FindResources()) return;
			factionManager.ModifyPersonalAffinity(faction.name, subjectFactionName, affinityChange);
		}
		
		/// <summary>
		/// Finds the personal affinity to a subject.
		/// </summary>
		/// <returns><c>true</c>, if personal affinity was found, <c>false</c> otherwise.</returns>
		/// <param name="subjectFactionID">Subject faction ID.</param>
		/// <param name="affinity">Affinity.</param>
		public bool FindPersonalAffinity(int subjectFactionID, out float affinity)
		{
			return FindResources() ? factionManager.FindPersonalAffinity(factionID, subjectFactionID, out affinity)
				: AffinityNotFound(out affinity);
		}

		/// <summary>
		/// Finds the affinity to a subject, either personal affinity or using
		/// parent faction affinities.
		/// </summary>
		/// <returns><c>true</c>, if affinity was found, <c>false</c> otherwise.</returns>
		/// <param name="subjectFactionID">Subject faction ID.</param>
		/// <param name="affinity">Affinity.</param>
		public bool FindAffinity(int subjectFactionID, out float affinity)
		{
			return FindResources() ? factionManager.FindAffinity(factionID, subjectFactionID, out affinity)
					: AffinityNotFound(out affinity);
		}

		private bool AffinityNotFound(out float affinity)
		{
			affinity = 0;
			return false;
		}

		/// <summary>
		/// Gets the affinity to a subject, either personal affinity or using
		/// parent faction affinities.
		/// </summary>
		/// <returns>The affinity.</returns>
		/// <param name="subjectFactionID">Subject faction ID.</param>
		public float GetAffinity(int subjectFactionID)
		{
			return FindResources() ? factionManager.GetAffinity(factionID, subjectFactionID) : 0;
		}

		/// <summary>
		/// Gets the affinity to a subject, either personal affinity or using
		/// parent faction affinities.
		/// </summary>
		/// <returns>The affinity.</returns>
		/// <param name="subject">Subject.</param>
		public float GetAffinity(FactionMember subject)
		{
			return GetAffinity(subject.factionID);
		}

		/// <summary>
		/// Gets the affinity to a subject, either personal affinity or using
		/// parent faction affinities.
		/// </summary>
		/// <returns>The affinity.</returns>
		/// <param name="subjectFactionName">Subject faction name.</param>
		public float GetAffinity(string subjectFactionName)
		{
			return FindResources() ? factionManager.GetAffinity(faction.name, subjectFactionName) : 0;
		}

		#endregion

		#region Witness Deed

		/// <summary>
		/// Witnesses a deed.
		/// </summary>
		/// <param name="deed">Deed.</param>
		public void WitnessDeed(Deed deed, FactionMember actor, bool requiresSight, Dimension dimension = Dimension.Is3D)
		{
			if (!FindResources()) return;
			if (!requiresSight || CanSee(actor, dimension))
			{
				if (factionManager.debug)
				{
					Debug.Log(string.Format("Love/Hate: " +
					                        faction.name + ".WitnessDeed actor:" + factionManager.GetFaction(deed.actorFactionID).name + 
					                        " target:" + factionManager.GetFaction(deed.targetFactionID).name +
					                        " impact:" + deed.impact), this);
				}
				var tempRumor = Rumor.GetNew(deed);
				tempRumor.confidence = 100;
				var newRumor = EvaluateRumor(tempRumor, this);
				Rumor.Release(tempRumor);
				if (newRumor != null)
				{
					ExecuteEvents.Execute<IWitnessDeedEventHandler>(gameObject, null, (x,y)=>x.OnWitnessDeed(newRumor));
					if (!newRumor.memorable)
					{
						Rumor.Release(newRumor);
					}
				}
			}
		}
		
		private bool DefaultCanSee(FactionMember other, Dimension dimension)
		{
			if (other == null) return false;
			var me = (eyes == null) ? transform : eyes;
			var hit = Raycast(me.position, other.transform.position, sightLayerMask, dimension);
			var hitFactionMember = (hit == null) ? null : hit.GetComponentInChildren<FactionMember>() ?? hit.GetComponentInParent<FactionMember>();
			return (hitFactionMember == other);
		}

		private GameObject Raycast(Vector3 start, Vector3 end, LayerMask layerMask, Dimension dimension)
		{
			switch (dimension)
			{
			case Dimension.Is2D:
				var start2D = new Vector2(start.x, start.y);
				var end2D = new Vector2(end.x, end.y);
				var originalRaycastsStartInColliders = Physics2D.raycastsStartInColliders;
				RaycastHit2D hitInfo2D = Physics2D.Linecast(start2D, end2D, layerMask);
				Physics2D.raycastsStartInColliders = originalRaycastsStartInColliders;
				return (hitInfo2D.collider == null) ? null : hitInfo2D.collider.gameObject;
			default:
			case Dimension.Is3D:
				RaycastHit hitInfo;
				var hit = Physics.Linecast(start, end, out hitInfo, layerMask);
				return hit ? hitInfo.collider.gameObject : null;
			}
		}

		#endregion

		#region Rumors
		
		/// <summary>
		/// Shares rumors with a member of some faction. Also shares affinity to the player.
		/// </summary>
		/// <param name="other">A member of a faction.</param>
		public void ShareRumors(FactionMember other) 
		{
			if (!FindResources()) return;
			if (factionManager.debug) 
			{
				Debug.Log("Love/Hate: " + name + ".ShareRumors with:" + other.name, this);
			}
			factionManager.ShareAffinity(factionID, other.factionID, FactionDatabase.PlayerFactionID);
			for (int i = 0; i < longTermMemory.Count; i++)
			{
				var rumor = longTermMemory[i];
				other.EvaluateRumor(rumor, this);
			}
			ExecuteEvents.Execute<IShareRumorsEventHandler>(gameObject, null, (x,y)=>x.OnShareRumors(other));
		}
		
		/// <summary>
		/// Evaluates a rumor and updates the faction's state.
		/// </summary>
		/// <returns>If this is a new type of deed, returns a new rumor if the impact is
		/// big enough to remember (otherwise `null`). If it's a repeat deed, returns 
		/// the existing rumor..</returns>
		/// <param name="rumor">Rumor.</param>
		/// <param name="source">Source.</param>
		private Rumor DefaultEvaluateRumor(Rumor rumor, FactionMember source)
		{
			if ((rumor == null) || (source == null) || KnowsAboutDeed(rumor.deedGuid) || !FindResources()) return null;

			// This is the big equation!

			// confidenceNorm[0,1]: The degree we trust this rumor is based on our affinity for its source:
			var trustInSource = GetAffinity(source.factionID);				//[-100,+100]
			var trustInSourceNorm = Mathf.Clamp(trustInSource / 100, 0, 1);	//[0,1]
			var confidence = rumor.confidence * trustInSourceNorm;			//[0,+100]
			var confidenceNorm = confidence / 100;							//[0,1]

			// affinityToTargetNorm[-1,+1]: How much we like the target of the rumor's deed:
			var affinityToTarget = GetAffinity(rumor.targetFactionID);		//[-100,+100]
			var affinityToTargetNorm = affinityToTarget / 100;				//[-1,+1]

			// changeInAffinityToActorNorm[-1,+1]: How much the deed changes our opinion of the actor who did it:
			// The base value is determined by the deed's impact, our confidence in the source, and our
			// affinity to the target:
			var impactNorm = rumor.impact / 100;							//[-1,+1]
			var changeInAffinityToActorNorm = confidenceNorm * impactNorm * affinityToTargetNorm; //[-1,+1]

			// Modify the opinion by how well the deed's values align with our own:
			var rumorValuesAlignment = Traits.Alignment(faction.traits, rumor.traits);	//[-1,+1]
			var valueImpactNorm = (changeInAffinityToActorNorm * rumorValuesAlignment) / 2; //[-0.5,+0.5]
			changeInAffinityToActorNorm = Mathf.Clamp(changeInAffinityToActorNorm + valueImpactNorm, -1, 1);//[-1,+1]

			// Modify the opinion by our temperament (happy, aroused, etc.):
			var pleasureImpactNorm = changeInAffinityToActorNorm * (pad.pleasure / 200); //[-0.5,+0.5]
			var arousalImpactNorm = changeInAffinityToActorNorm * (pad.arousal / 200);   //[-0.5,+0.5]
			var padImpactNorm = pleasureImpactNorm + arousalImpactNorm;
			changeInAffinityToActorNorm = Mathf.Clamp(changeInAffinityToActorNorm + padImpactNorm, -1, 1);//[-1,+1]

			var changeInAffinityToActor = changeInAffinityToActorNorm * 100; //[-100,+100]

			if (debugEvalFunc)
			{
				Debug.Log("Love/Hate: EvaluateRumor actor:" + factionManager.GetFaction(rumor.actorFactionID).name +
				          " tag:" + rumor.tag + " target:" + factionManager.GetFaction(rumor.targetFactionID).name +
				          " source:" + source.name);
				Debug.Log("Love/Hate:    confidence in source: " + confidence);
				Debug.Log("Love/Hate:    affinity to target: " + affinityToTarget);
				Debug.Log("Love/Hate:    deed impact: " + rumor.impact);
				Debug.Log("Love/Hate:    value alignment: " + rumorValuesAlignment * 100);
				Debug.Log("Love/Hate:    value alignment impact: " + valueImpactNorm * 100);
				Debug.Log("Love/Hate:    pad state impact: " + padImpactNorm * 100);
				Debug.Log("Love/Hate:    change in affinity to actor (final): " + changeInAffinityToActor);
			}

			return ApplyRumorImpact(rumor, source, confidence, changeInAffinityToActor);
		}

		/// <summary>
		/// Applies an evaluated rumor to the faction member. This is separate from the DefaultEvaluateRumor
		/// method so you can call it in your own custom evaluation methods. It updates the faction member's
		/// state and adds a new rumor to its memory or updates an existing memory.
		/// </summary>
		/// <returns>The rumor in this member's memory.</returns>
		/// <param name="rumor">The original rumor that the member heard.</param>
		/// <param name="source">Source of the original rumor.</param>
		/// <param name="confidence">This member's confidence in the original rumor.</param>
		/// <param name="changeInAffinityToActor">Change in this member's affinity to actor.</param>
		public Rumor ApplyRumorImpact(Rumor rumor, FactionMember source, float confidence, float changeInAffinityToActor)
		{
			if (!FindResources()) return null;

			// If it's a repeat, reduce the impact and update the old rumor:
			Rumor oldRumor;
			var isRepeat = FindOldRumor(rumor, out oldRumor);
			if (isRepeat)
			{
				oldRumor.count++;
				changeInAffinityToActor *= acclimatizationCurve.Evaluate(oldRumor.count);
			}

			// Clamp the opinion to [-100,+100]:
			changeInAffinityToActor = Mathf.Clamp(changeInAffinityToActor, -100, 100);
			var changeMagnitude = Mathf.Abs(changeInAffinityToActor);

			// Update PAD:
			var pleasure = changeInAffinityToActor;
			var arousal = changeMagnitude;
			var dominance = ComputeDominanceChange(rumor, changeMagnitude);
			var happiness = pleasure;
			pad.Modify(happiness, pleasure, arousal, dominance);

			// Update affinity:
			var oldAffinityToActor = GetAffinity(rumor.actorFactionID);
			var newAffinityToActor = Mathf.Clamp(oldAffinityToActor + pleasure, -100, 100);
			SetPersonalAffinity(rumor.actorFactionID, newAffinityToActor);
			
			if (debugEvalFunc)
			{
				Debug.Log("Love/Hate: ApplyRumorImpact actor:" + factionManager.GetFaction(rumor.actorFactionID).name +
				          " tag:" + rumor.tag + " target:" + factionManager.GetFaction(rumor.targetFactionID).name +
				          " source:" + source.name);
				Debug.Log("Love/Hate:    P,A,D change: " + pleasure + ", " + arousal + ", " + dominance);
				Debug.Log("Love/Hate:    old affinity to actor: " + oldAffinityToActor);
				Debug.Log("Love/Hate:    new affinity to actor: " + newAffinityToActor);
			}

			// If the opinion is over the threshold we care about, remember the rumor:
			Rumor result = null;
			if (isRepeat)
			{
				if (factionManager.debug || debugEvalFunc)
				{
					Debug.Log(string.Format("{0}.UpdateExistingRumor actor:{1} target:{2} affinityChange:{3:N2}", new object[] { name, factionManager.GetFaction(rumor.actorFactionID).name, factionManager.GetFaction(rumor.targetFactionID).name, pleasure }), this);
				}
				oldRumor.confidence = Mathf.Max(oldRumor.confidence, confidence);
				result = oldRumor;
			}
			else
			{
				var newRumor = Rumor.GetNew(rumor);
				newRumor.confidence = confidence;
				newRumor.pleasure = pleasure;
				newRumor.arousal = arousal;
				newRumor.dominance = dominance;
				newRumor.memorable = (changeMagnitude > deedImpactThreshold);
				if (!newRumor.memorable)
				{
					pad.Modify(0, -pleasure, -arousal, -dominance);
				}
				result = newRumor;
				if (newRumor.memorable)
				{
					if (factionManager.debug || debugEvalFunc)
					{
						Debug.Log(string.Format("{0}.RememberRumor actor:{1} target:{2} affinityChange:{3:N2}", new object[] { name, factionManager.GetFaction(rumor.actorFactionID).name, factionManager.GetFaction(rumor.targetFactionID).name, pleasure }), this);
					}
					AddRumorToMemory(newRumor);
				}
				else
				{
					if (factionManager.debug || debugEvalFunc)
					{
						Debug.Log(string.Format("{0}.Rumor isn't memorable actor:{1} target:{2} affinityChange:{3:N2}", new object[] { name, factionManager.GetFaction(rumor.actorFactionID).name, factionManager.GetFaction(rumor.targetFactionID).name, pleasure }), this);
					}
				}
			}
			if (result != null)
			{
				result.shortTermExpiration = Time.time + (changeMagnitude * shortTermMemoryDuration);
				result.longTermExpiration = Time.time + (changeMagnitude * longTermMemoryDuration);
			}
			return result;
		}

		/// <summary>
		/// Computes the dominance change based on the rumor and the magnitude of the
		/// change in affinity to the actor. The value is primarily based on the deed's
		/// aggression value, but it's influenced by the power differential between
		/// the actor and the member's self-perceived power level.
		/// </summary>
		/// <returns>The dominance change [-100,+100] where negative means the rumor makes
		/// the member feel more submissive and positive means the member feels more dominant.</returns>
		/// <param name="rumor">Rumor.</param>
		/// <param name="changeMagnitude">Magnitude of change in affinity to actor.</param>
		public float ComputeDominanceChange(Rumor rumor, float changeMagnitude)
		{
			if (rumor == null) return 0;
			var powerDifference = Mathf.Clamp((GetSelfPerceivedPowerLevel() - rumor.actorPowerLevel) / 10, -1, 1); //[-1,+1]
			var dominance = -rumor.aggression * (changeMagnitude / 100); //[-100,+100]
			dominance += powerDifference * Mathf.Abs(dominance);
			return dominance;
		}

		public float DefaultGetPowerLevel()
		{
			return 1;
		}

		#endregion

		#region Serialization

		public string SerializeToString()
		{
			var sb = new StringBuilder();
			
			// Record PAD:
			sb.AppendFormat("{0},{1},{2},{3},", pad.happiness, pad.pleasure, pad.arousal, pad.dominance);
			
			// Record short term memories:
			sb.AppendFormat("{0},", shortTermMemory.Count);
			for (int m = 0; m < longTermMemory.Count; m++)
			{
				var mem = longTermMemory[m];
				var longTermLeft = mem.longTermExpiration - Time.time;
				var shortTermLeft = shortTermMemory.Contains(mem) ? (mem.shortTermExpiration - Time.time) : 0;
				var tag = mem.tag.Contains(",") ? mem.tag.Replace(',', ';') : mem.tag;
				sb.AppendFormat("{0},{1},{2},{3},{4},", mem.deedGuid.ToString(), tag, mem.actorFactionID, mem.targetFactionID, mem.impact);
				for (int t = 0; t < mem.traits.Length; t++)
				{
					sb.AppendFormat("{0},", mem.traits[t]);
				}
				sb.AppendFormat("{0},{1},{2},{3},{4},{5},{6},", mem.count, mem.confidence, mem.pleasure, mem.arousal, mem.dominance, shortTermLeft, longTermLeft);
			}
			return sb.ToString();
		}

		public void DeserializeFromString(string s)
		{
			if (factionManager == null || factionManager.factionDatabase == null) return;
			var traitCount = factionManager.factionDatabase.personalityTraitDefinitions.Length;

			var data = new Queue<string>(s.Split(','));
			if (data.Count < 4) return;
			
			// Get PAD:
			pad.happiness = SafeConvert.ToFloat(data.Dequeue());
			pad.pleasure = SafeConvert.ToFloat(data.Dequeue());
			pad.arousal = SafeConvert.ToFloat(data.Dequeue());
			pad.dominance = SafeConvert.ToFloat(data.Dequeue());
			
			try
			{
				StopMemoryCleanup();
				
				// Release old memories:
				shortTermMemory.Clear();
				for (int m = 0; m < longTermMemory.Count; m++)
				{
					var mem = longTermMemory[m];
					Rumor.Release(mem);
				}
				longTermMemory.Clear();
				shortTermMemory.Clear();
				
				// Get memories:
				var memCount = SafeConvert.ToInt(data.Dequeue());
				for (int m = 0; m < memCount; m++)
				{
					var mem = Rumor.GetNew();
					mem.deedGuid = new System.Guid(data.Dequeue());
					mem.tag = data.Dequeue();
					mem.actorFactionID = SafeConvert.ToInt(data.Dequeue());
					mem.targetFactionID = SafeConvert.ToInt(data.Dequeue());
					mem.impact = SafeConvert.ToFloat(data.Dequeue());
					mem.traits = new float[traitCount];
					for (int t = 0; t < traitCount; t++)
					{
						mem.traits[t] = SafeConvert.ToFloat(data.Dequeue());
					}
					mem.count = SafeConvert.ToInt(data.Dequeue());
					mem.confidence = SafeConvert.ToFloat(data.Dequeue());
					mem.pleasure = SafeConvert.ToFloat(data.Dequeue());
					mem.arousal = SafeConvert.ToFloat(data.Dequeue());
					mem.dominance = SafeConvert.ToFloat(data.Dequeue());
					mem.memorable = true;
					var shortTermLeft = SafeConvert.ToFloat(data.Dequeue());
					var longTermLeft = SafeConvert.ToFloat(data.Dequeue());
					mem.shortTermExpiration = (shortTermLeft <= 0) ? 0 : Time.time + shortTermLeft;
					mem.longTermExpiration = Time.time + longTermLeft;
					longTermMemory.Add(mem);
					if (shortTermLeft > 0)
					{
						shortTermMemory.Add(mem);
					}
				}
			}
			finally
			{
				StartMemoryCleanup();
			}
		}

		#endregion

		#region Gizmos

		#if UNITY_EDITOR

		public void OnDrawGizmos()
		{
			if (factionDatabase == null) return;
			var faction = factionDatabase.GetFaction(factionID);
			if (faction == null || faction.color >= Faction.GizmoIconNames.Length) return;
			Gizmos.DrawIcon(transform.position, Faction.GizmoIconNames[faction.color], true);
		}

		#endif

		#endregion

	}
	
}
