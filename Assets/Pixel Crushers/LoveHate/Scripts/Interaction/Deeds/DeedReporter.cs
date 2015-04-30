using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace PixelCrushers.LoveHate
{

	/// <summary>
	/// Provides a higher-level way to report deeds to the FactionManager
	/// using a deed template library.
	/// 
	/// Add this to the faction member that performs the actions (usually the player).
	/// </summary>
	[RequireComponent(typeof(FactionMember))]
	[AddComponentMenu("Love\u2215Hate/Deed Reporter")]
	public class DeedReporter : MonoBehaviour
	{

		/// <summary>
		/// The dimension in which to report deeds to FactionManager.
		/// </summary>
		public Dimension dimension = Dimension.Is3D;

		/// <summary>
		/// The predefined deed templates.
		/// </summary>
		public DeedTemplateLibrary deedTemplateLibrary;

		private FactionMember m_member = null;

		private void Awake()
		{
			m_member = GetComponent<FactionMember>();
		}

		/// <summary>
		/// Reports that the faction member committed a deed.
		/// </summary>
		/// <param name="tag">Tag of the deed in the deed template library.</param>
		/// <param name="target">Target of the deed.</param>
		public void ReportDeed(string tag, FactionMember target)
		{
			if (target == null)
			{
				Debug.LogError("Love/Hate: ReportDeed(" + tag + ") target is null", this);
				return;
			}
			DeedTemplate deedTemplate;
			if (FindDeedTemplate(tag, out deedTemplate))
			{
				var actorPowerLevel = (m_member == null) ? 0 : m_member.GetPowerLevel();
				var deed = Deed.GetNew(deedTemplate.tag, m_member.factionID, target.factionID, deedTemplate.impact, 
				                       deedTemplate.aggression, actorPowerLevel, deedTemplate.traits);
				m_member.factionManager.CommitDeed(m_member, deed, deedTemplate.requiresSight, dimension, deedTemplate.radius);
				Deed.Release(deed);
			}
		}

		private bool FindDeedTemplate(string tag, out DeedTemplate deedTemplate)
		{
			var index = deedTemplateLibrary.deedTemplates.FindIndex(t => string.Equals(t.tag, tag));
			if (index >= 0)
			{
				deedTemplate = deedTemplateLibrary.deedTemplates[index];
				return true;
			}
			else 
			{
				Debug.LogWarning("Love/Hate: DeedReporter can't find deed template for: '" + tag + "'", this);
				deedTemplate = null;
				return false;
			}
		}
		
	}

}
