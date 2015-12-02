using UnityEngine;

namespace PixelCrushers.LoveHate 
{

	/// <summary>
	/// Plays a greeting animation when near another character based on
	/// affinity to that character.
	/// </summary>
	[AddComponentMenu("Love\u2215Hate/Interaction/Greeting Trigger 2D")]
	public class GreetingTrigger2D : AbstractGreetingTrigger
	{

		private void OnTriggerEnter2D(Collider2D other) 
		{
			if (other == null) return;
			HandleOnTriggerEnter(other.gameObject);
		}
		
	}

}
