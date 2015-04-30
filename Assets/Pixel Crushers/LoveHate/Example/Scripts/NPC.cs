using UnityEngine;
using System.Collections;

namespace PixelCrushers.LoveHate.Example
{

	/// <summary>
	/// Basic NPC script for the example scene. Note that it uses the event system
	/// to handle IWitnessDeedEventHandler's OnWitnessDeed() method.
	/// </summary>
	public class NPC : Mover2D, IWitnessDeedEventHandler
	{

		// The NPC's power level, which is used in the rumor evaluation function
		// to determine power level relative to the actor of the deed. If the 
		// actor is more powerful than this NPC, the NPC might feel cowed or
		// submissive. If the actor is less powerful, the NPC might feel angry
		// or disdainful if the actor does something the NPC doesn't like.
		public float powerLevel = 1;
		public float selfPerceivedPowerLevel = 1;

		private Animator animator;

		private FactionMember member;

		private InteractionUI m_interactionUI;

		private const float UpdateFrequency = 0.5f;

		private Vector3 m_startPosition;

		// Start() does basic setup and also registers custom power level
		// delegates and starts the wander coroutine.
		protected override void Start()
		{
			base.Start();
			m_startPosition = transform.position;
			animator = GetComponent<Animator>();
			m_interactionUI = FindObjectOfType<InteractionUI>();
			member = GetComponent<FactionMember>();
			member.GetPowerLevel = GetPowerLevel;
			member.GetSelfPerceivedPowerLevel = GetSelfPerceivedPowerLevel;
			StartCoroutine(Wander());
		}

		private float GetPowerLevel()
		{
			return powerLevel;
		}

		private float GetSelfPerceivedPowerLevel()
		{
			return selfPerceivedPowerLevel;
		}
		
		private void OnCollisionEnter2D(Collision2D coll)
		{
			StopAllCoroutines();
			StartCoroutine(UpdateFaction());
		}

		private void OnCollisionExit2D(Collision2D coll)
		{
			StopAllCoroutines();
			m_interactionUI.Watch(null);
			StartCoroutine(Wander());
		}

		private IEnumerator UpdateFaction()
		{
			while (true)
			{
				m_interactionUI.Watch(GetComponent<FactionMember>());
				yield return new WaitForSeconds(UpdateFrequency);
			}
		}

		private IEnumerator Wander()
		{
			const float MaxIdle = 5;
			const float MaxRange = 3;
			const float Speed = 0.2f;
			while (true)
			{
				yield return new WaitForSeconds(Random.Range(1, MaxIdle));
				var x = Mathf.Clamp(m_startPosition.x + Random.Range(-MaxRange, MaxRange), cameraRect.xMin, cameraRect.xMax);
				var y = Mathf.Clamp(m_startPosition.y + Random.Range(-MaxRange, MaxRange), cameraRect.yMin, cameraRect.yMax);
				var destination = new Vector3(x, y, m_startPosition.z);
				while (Vector3.Distance(transform.position, destination) > 1)
				{
					yield return null;
					moveToPosition = new Vector2(Mathf.Lerp(transform.position.x, destination.x, Speed * Time.deltaTime),
					                             Mathf.Lerp(transform.position.y, destination.y, Speed * Time.deltaTime));
				}
			}
		}

		// When the NPC witnesses a deed, it generates a rumor that records
		// how it feels about the deed. The rumor has, among other values,
		// a pleasure value. The method below checks whether the NPC found
		// the deed pleasing or displeasing, and then plays an appropriate
		// animation.
		public void OnWitnessDeed(Rumor rumor)
		{
			if (member == null || rumor == null) return;
			if (rumor.pleasure < -0.25)
			{
				animator.SetTrigger("Sad");
			} 
			else if (rumor.pleasure > 0.25)
			{
				animator.SetTrigger("Happy");
			}
		}
		
	}

}
