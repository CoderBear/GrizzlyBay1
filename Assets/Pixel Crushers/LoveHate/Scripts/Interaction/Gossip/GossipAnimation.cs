using UnityEngine;

namespace PixelCrushers.LoveHate 
{

	/// <summary>
	/// Triggers an animation when the character gossips.
	/// </summary>
	[AddComponentMenu("Love\u2215Hate/Interaction/Gossip Animation")]
	public class GossipAnimation : MonoBehaviour, IGossipEventHandler
	{

		/// <summary>
		/// The trigger parameter to set when gossiping.
		/// </summary>
		[Tooltip("Animator trigger to set when gossiping")]
		public string triggerParameter = string.Empty;

		private Animator m_animator = null;

		private void Awake()
		{
			m_animator = GetComponentInChildren<Animator>() ?? GetComponentInParent<Animator>();
		}

		public void OnGossip(FactionMember other)
		{
			if (other == null || m_animator == null || string.IsNullOrEmpty(triggerParameter)) return;
			m_animator.SetTrigger(triggerParameter);
		}

	}

}
