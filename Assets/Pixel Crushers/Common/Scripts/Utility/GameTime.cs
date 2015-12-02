using UnityEngine;

namespace PixelCrushers
{

	/// <summary>
	/// This is a wrapper around Unity's Time class. You can change this class
	/// instead of having to modify direct references to Time in the code.
	/// </summary>
	public static class GameTime 
	{
		
		public static float time 
		{
			get { return Time.time; }
		}

		public static float deltaTime 
		{
			get { return Time.deltaTime; }
		}

		public static bool isPaused 
		{
			get { return time == 0; }
		}
		
	}

}