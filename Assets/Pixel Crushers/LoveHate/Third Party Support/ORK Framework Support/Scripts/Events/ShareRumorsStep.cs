using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ORKFramework;
using PixelCrushers.LoveHate;
using PixelCrushers.LoveHate.ORKFrameworkSupport;

namespace ORKFramework.Events.Steps
{

	[ORKEditorHelp("Share Rumors", "Shares rumors between two faction members.", "")]
	[ORKEventStep(typeof(BaseEvent))]
	[ORKNodeInfo("Love\u2215Hate Steps")]
	public class ShareRumorsStep : BaseEventStep
	{

		// First Actor
		[ORKEditorHelp("First Actor", "Select the first actor.", "")]
		[ORKEditorInfo(labelText="First Actor", isTabPopup=true, tabPopupID=0)]
		public EventObjectSetting firstObject = new EventObjectSetting();

		// Second Actor
		[ORKEditorHelp("Second Actor", "Select the second actor.", "")]
		[ORKEditorInfo(labelText="Second Actor", isTabPopup=true, tabPopupID=0)]
		public EventObjectSetting secondObject = new EventObjectSetting();
		

		public ShareRumorsStep()
		{
		}
		
		public override void Execute(BaseEvent baseEvent)
		{
			var firstMember = OrkEventTools.GetEventObjectComponentInChildren<FactionMember>(firstObject, baseEvent);
			var secondMember = OrkEventTools.GetEventObjectComponentInChildren<FactionMember>(secondObject, baseEvent);
			if (firstMember == null)
			{
				Debug.LogWarning("Love/Hate: ShareRumorsStep - Can't find first faction member");
			}
			if (secondMember == null)
			{
				Debug.LogWarning("Love/Hate: ShareRumorsStep - Can't find second faction member");
			}
			else
			{
				firstMember.ShareRumors(secondMember);
			}
			baseEvent.StepFinished(next);
		}		
		
		public override string GetNodeDetails()
		{
			return firstObject.GetInfoText() + " <-> " + secondObject.GetInfoText();
		}

	}

}
