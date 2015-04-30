using UnityEngine;

namespace PixelCrushers
{

	/// <summary>
	/// Always keeps the GameObject facing the main camera.
	/// </summary>
	public class AlwaysFaceCamera : MonoBehaviour
	{

		/// <summary>
		/// Set `true` to leave Y rotation untouched.
		/// </summary>
		public bool yAxisOnly = false;
		
		private void Update()
		{
			if (Camera.main == null) return;
			if (yAxisOnly)
			{
				transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.x);
			}
			else 
			{
				transform.rotation = Camera.main.transform.rotation;
			}
		}
		
	}

}
