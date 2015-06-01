using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.LoveHate;
using ORKFramework;
using PixelCrushers.LoveHate.ORKFrameworkSupport;

namespace ORKFramework.Events.Steps
{

	[ORKEditorHelp("Report Deed", "Reports a deed to Love/Hate.", "")]
	[ORKEventStep(typeof(BaseEvent))]
	[ORKNodeInfo("Love\u2215Hate Steps")]
	public class ReportDeedStep : BaseEventStep
	{

		[ORKEditorHelp("Actor", "Select the actor committing the deed.", "")]
		[ORKEditorInfo(labelText="Actor")]
		public EventObjectSetting actorObject = new EventObjectSetting();
		
		[ORKEditorHelp("Target", "Select the actor that the deed is being done to.", "")]
		[ORKEditorInfo(labelText="Target")]
		public EventObjectSetting targetObject = new EventObjectSetting();

		[ORKEditorHelp("Deed Tag", "Specify the tag of the deed template as specified on the actor's deed reporter.", "")]
		[ORKEditorInfo(labelText="Deed Tag", expandWidth=true)]
		public string deedTag = string.Empty;
		

		public ReportDeedStep()
		{
		}

		public override void Execute(BaseEvent baseEvent)
		{
			var deedReporter = OrkEventTools.GetEventObjectComponentInChildren<DeedReporter>(actorObject, baseEvent);
			var target = OrkEventTools.GetEventObjectComponentInChildren<FactionMember>(targetObject, baseEvent);
			if (deedReporter == null)
			{
				Debug.LogWarning("Love/Hate: ReportDeedStep - Can't find deed reporter");
			}
			else if (target == null)
			{
				Debug.LogWarning("Love/Hate: ReportDeedStep - Can't find target faction member");
			}
			else
			{
				deedReporter.ReportDeed(deedTag, target);
			}
			baseEvent.StepFinished(next);
		}		
		
		public override string GetNodeDetails()
		{
			return deedTag;
		}

	}

}
