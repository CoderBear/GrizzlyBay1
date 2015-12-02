using UnityEngine;
using System.Collections.Generic;

namespace PixelCrushers.LoveHate 
{

	/// <summary>
	/// Stabilizes PAD values toward target values. Add this to a faction member to
	/// gradually "cool down" arousal to 0, for example.
	/// </summary>
	[RequireComponent(typeof(FactionMember))]
	[AddComponentMenu("Love\u2215Hate/Stabilize PAD")]
	public class StabilizePAD : MonoBehaviour 
	{

		[System.Serializable]
		public class StabilizeSettings
		{
			public bool stabilize = false;
			public float target = 0;
			public float changeRate = 0.1f;

			public float Apply(float current)
			{
				return (!stabilize || Mathf.Approximately(current, target)) ? target
					: (current > target) 
						? Mathf.Clamp(current - changeRate * Time.deltaTime, target, current)
						: Mathf.Clamp(current + changeRate * Time.deltaTime, current, target);
			}
		}

		public StabilizeSettings happinessSettings;
		public StabilizeSettings pleasureSettings;
		public StabilizeSettings arousalSettings;
		public StabilizeSettings dominanceSettings;

		private FactionMember m_member = null;

		private void Awake()
		{
			m_member = GetComponent<FactionMember>();
			if (m_member == null) enabled = false;
		}

		private void Update()
		{
			if (happinessSettings.stabilize)
			{
				m_member.pad.happiness = happinessSettings.Apply(m_member.pad.happiness);
			}
			if (pleasureSettings.stabilize)
			{
				m_member.pad.pleasure = pleasureSettings.Apply(m_member.pad.pleasure);
			}
			if (arousalSettings.stabilize)
			{
				m_member.pad.arousal = arousalSettings.Apply(m_member.pad.arousal);
			}
			if (dominanceSettings.stabilize)
			{
				m_member.pad.dominance = dominanceSettings.Apply(m_member.pad.dominance);
			}
		}

	}

}
