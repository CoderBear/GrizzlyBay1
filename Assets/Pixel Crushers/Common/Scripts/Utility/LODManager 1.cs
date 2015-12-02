using UnityEngine;
using System;
using System.Collections;

namespace PixelCrushers
{

	/// <summary>
	/// Implements a Level of Detail (LOD) system according to distance from the player.
	/// Add this component to any GameObject with script(s) that implement a method 
	/// named `OnLOD(int)`. It's the script's responsibility to handle the message
	/// accordingly. For example, an AI script could reduce the frequency of perception
	/// checks as the LOD number increases.
	/// </summary>
	public class LODManager : MonoBehaviour
	{

		[Serializable]
		public class LOD
		{

			/// <summary>
			/// The minimum distance for this LOD.
			/// </summary>
			public float minDistance = 0;

			/// <summary>
			/// The max distance for this LOD.
			/// </summary>
			public float maxDistance = Mathf.Infinity;

			public bool Contains(float distance) 
			{
				return (minDistance <= distance && distance <= maxDistance);
			}

		}

		/// <summary>
		/// The LODs.
		/// </summary>
		public LOD[] levels;

		/// <summary>
		/// The frequency at which to check distance from the player and update
		/// the current LOD if necessary.
		/// </summary>
		public float monitorFrequency = 5f;

		/// <summary>
		/// Gets or sets the player's transform. The Start method assigns the
		/// GameObject tagged "Player" to this property.
		/// </summary>
		/// <value>The player.</value>
		public Transform player { get; set; }

		private int currentLevel = 0;

		private void Start()
		{
			FindPlayer();
			StartCoroutine(MonitorLOD());
		}

		/// <summary>
		/// Assigns the GameObject tagged "Player" to the player property.
		/// </summary>
		public void FindPlayer()
		{
			var go = GameObject.FindWithTag("Player");
			player = (go != null) ? go.transform : null;
		}

		private IEnumerator MonitorLOD()
		{
			yield return new WaitForSeconds(UnityEngine.Random.value);
			while (true)
			{
				CheckLOD();
				yield return new WaitForSeconds(monitorFrequency);
			}
		}

		private void CheckLOD() {
			if (player == null || levels == null || levels.Length == 0) return;
			float distance = Vector3.Distance(transform.position, player.position);
			if (levels[currentLevel].Contains(distance)) return;
			for (int level = 0; level < levels.Length; level++)
			{
				if (levels[level].Contains(distance))
				{
					currentLevel = level;
					BroadcastMessage("OnLOD", level, SendMessageOptions.DontRequireReceiver);
					return;
				}
			}
		}

	}

}
