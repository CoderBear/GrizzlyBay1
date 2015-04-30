using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace PixelCrushers.LoveHate 
{

	/// <summary>
	/// This abstract aura trigger is the workhorse for AuraTrigger (3D) and
	/// AuraTrigger2D.
	/// </summary>
	[RequireComponent(typeof(Traits))]
	public abstract class AbstractAuraTrigger : AbstractTriggerInteractor 
	{

		/// <summary>
		/// At least this many seconds must pass before affecting the same character.
		/// </summary>
		[Tooltip("This many seconds must pass before affecting the same character again")]
		public float timeBetweenEffects = 300f;

		[Range(-100,100)]
		[Tooltip("How powerfully the aura affects characters")]
		public float impact;

		[Range(-100,100)]
		[Tooltip("How submissive (-100) or aggressive (+100) the aura is")]
		public float aggression;

		public bool debug = false;
		
		private Dictionary<FactionMember, float> lastTime = new Dictionary<FactionMember, float>();

		private Traits m_self = null;

		private void Awake() 
		{
			m_self = GetComponentInChildren<Traits>() ?? GetComponentInParent<Traits>();
		}

		protected void HandleOnTriggerEnter(GameObject other)
		{
			TryAffect(GetFactionMember(other));
		}

		public void TryAffect(FactionMember other) 
		{
			if (ShouldAffect(other))
			{
				Affect(other);
			}
		}

		private bool ShouldAffect(FactionMember other) 
		{
			if (m_self == null || other == null || other.gameObject == gameObject) return false;
			var tooRecent = lastTime.ContainsKey(other) && (Time.time < (lastTime[other] + timeBetweenEffects));
			return !tooRecent;
		}

		private void Affect(FactionMember other) 
		{
			if (m_self == null || other == null || other.faction == null || other.gameObject == gameObject) return;
			lastTime[other] = Time.time;
			if (debug) Debug.Log("Love/Hate: Applying aura effect " + name + " to " + other.name, this);
			var alignment = Traits.Alignment(m_self.traits, other.faction.traits);
			var pleasureChange = alignment * impact;
			var arousalChange = Mathf.Max(-alignment * impact, -other.pad.arousal);
			var dominanceChange = alignment * (aggression / 100) * impact;
			other.pad.Modify(pleasureChange, pleasureChange, arousalChange, dominanceChange);
			ExecuteEvents.Execute<IAuraEventHandler>(gameObject, null, (x,y)=>x.OnAura(other));
			ExecuteEvents.Execute<IEnterAuraEventHandler>(other.gameObject, null, (x,y)=>x.OnEnterAura(this));
		}

	}

}
