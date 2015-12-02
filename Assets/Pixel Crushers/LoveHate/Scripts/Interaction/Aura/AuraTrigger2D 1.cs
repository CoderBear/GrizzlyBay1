using UnityEngine;

namespace PixelCrushers.LoveHate 
{

	/// <summary>
	/// Applies an aura effect when a faction member enters the trigger.
	/// </summary>
	[AddComponentMenu("Love\u2215Hate/Interaction/Aura Trigger 2D")]
	public class AuraTrigger2D : AbstractAuraTrigger
	{

		private void OnTriggerEnter2D(Collider2D other) 
		{
			if (other == null) return;
			HandleOnTriggerEnter(other.gameObject);
		}
		
	}

}
