using UnityEngine;

namespace PixelCrushers.LoveHate 
{

	/// <summary>
	/// Plays a greeting animation when near another character based on
	/// affinity to that character.
	/// </summary>
	[AddComponentMenu("Love\u2215Hate/Interaction/Greeting Trigger")]
	public class GreetingTrigger : AbstractGreetingTrigger 
	{

		private void OnTriggerEnter(Collider other) 
		{
			if (other == null) return;
			HandleOnTriggerEnter(other.gameObject);
		}

	}

}
