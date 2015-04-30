using UnityEngine;

namespace PixelCrushers.LoveHate 
{

	/// <summary>
	/// Gossips with another character when entering its trigger area.
	/// </summary>
	[AddComponentMenu("Love\u2215Hate/Interaction/Gossip Trigger 2D")]
	public class GossipTrigger2D : AbstractGossipTrigger 
	{

		private void OnTriggerEnter2D(Collider2D other) 
		{
			HandleOnTriggerEnter(other.gameObject);
		}
		
	}

}
