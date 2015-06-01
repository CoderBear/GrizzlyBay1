using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.LoveHate;
using ORKFramework;
using PixelCrushers.LoveHate.ORKFrameworkSupport;

namespace ORKFramework.Events.Steps
{

	[ORKEditorHelp("Check Arousal", "Which steps will be executed next is decided by a faction member's arousal value.", "")]
	[ORKEventStep(typeof(BaseEvent))]
	[ORKNodeInfo("Love\u2215Hate Steps")]
	public class CheckArousalStep : BaseEventCheckStep
	{

		// Actor
		[ORKEditorHelp("Actor", "Select the actor to check.", "")]
		[ORKEditorInfo(isTabPopup=true, tabPopupID=0)]
		public EventObjectSetting actorObject = new EventObjectSetting();
		

		// Value
		[ORKEditorHelp("Check Type", "Checks if the value is equal, not equal, less or greater than a defined value.\n" +
		               "Arousal is in the range [-100,+100].\n" +
		               "Range inclusive checks if the value is between two defind values, including the values.\n" +
		               "Range exclusive checks if the value is between two defined values, excluding the values.\n" +
		               "Approximately checks if the value is similar to the defined value.", "")]
		[ORKEditorInfo(separator=true)]
		public VariableValueCheck check = VariableValueCheck.IsEqual;
		
		[ORKEditorInfo(separator=true, labelText="Check Value")]
		public EventFloat checkValue = new EventFloat();
		
		[ORKEditorInfo(separator=true, labelText="Check Value 2")]
		[ORKEditorLayout(new string[] {"check", "check"}, 
		new System.Object[] {VariableValueCheck.RangeInclusive, VariableValueCheck.RangeExclusive}, 
		needed=Needed.One, endCheckGroup=true, autoInit=true)]
		public EventFloat checkValue2;
		

		public CheckArousalStep()
		{
		}

		public override void Execute(BaseEvent baseEvent)
		{
			var factionMember = OrkEventTools.GetEventObjectComponentInChildren<FactionMember>(actorObject, baseEvent);
			if (factionMember == null)
			{
				Debug.LogWarning("Love/Hate: CheckArousal - Can't find faction member");
			}
			else
			{
				var arousal = factionMember.pad.arousal;
				if (ValueHelper.CheckVariableValue(
					arousal,
					checkValue.GetValue(baseEvent), 
					checkValue2 != null ? this.checkValue2.GetValue(baseEvent) : 0, 
					check))
				{
					baseEvent.StepFinished(next);
				}
				else
				{
					baseEvent.StepFinished(nextFail);
				}
			}
			baseEvent.StepFinished(next);
		}		
		
		public override string GetNodeDetails()
		{
			return actorObject.GetInfoText() + " " +
				check + " " + checkValue.GetInfoText() + 
				((VariableValueCheck.RangeInclusive.Equals(this.check) || 
				  VariableValueCheck.RangeExclusive.Equals(this.check)) ? 
				  " - " + this.checkValue2.GetInfoText() : "");
		}

	}

}
