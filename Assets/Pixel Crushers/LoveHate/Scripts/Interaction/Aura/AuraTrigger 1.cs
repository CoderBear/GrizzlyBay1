using UnityEngine;

namespace PixelCrushers.LoveHate 
{

	/// <summary>
	/// Applies an aura effect when a faction member enters the trigger.
	/// </summary>
	[AddComponentMenu("Love\u2215Hate/Interaction/Aura Trigger")]
	public class AuraTrigger : AbstractAuraTrigger
	{

		private void OnTriggerEnter(Collider other) 
		{
			if (other == null) return;
			HandleOnTriggerEnter(other.gameObject);
		}
		
	}

}
