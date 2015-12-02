using UnityEngine;

namespace PixelCrushers.LoveHate 
{

	/// <summary>
	/// Gossips with another character when entering its trigger area.
	/// </summary>
	[AddComponentMenu("Love\u2215Hate/Interaction/Gossip Trigger")]
	public class GossipTrigger : AbstractGossipTrigger 
	{

		private void OnTriggerEnter(Collider other) 
		{
			if (other == null) return;
			HandleOnTriggerEnter(other.gameObject);
		}

	}

}
