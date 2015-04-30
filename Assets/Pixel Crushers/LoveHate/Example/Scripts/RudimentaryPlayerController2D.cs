using UnityEngine;
using System.Collections;

namespace PixelCrushers.LoveHate.Example
{

	/// <summary>
	/// This is a rudimentary 2D player controller for the example scene.
	/// </summary>
	public class RudimentaryPlayerController2D : Mover2D
	{

		public float speedFactor = 0.5f;

		private void Update()
		{
			var x = transform.position.x + Input.GetAxis("Horizontal") * speedFactor;
			var y = transform.position.y + Input.GetAxis("Vertical") * speedFactor;
			moveToPosition = new Vector3(x, y, transform.position.z);
		}

	}

}
