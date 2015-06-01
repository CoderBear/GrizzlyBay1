using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ORKFramework;
using PixelCrushers.LoveHate;
using PixelCrushers.LoveHate.ORKFrameworkSupport;

namespace ORKFramework.Events.Steps
{

	[ORKEditorHelp("Change PAD", "Changes a faction member's PAD values.", "")]
	[ORKEventStep(typeof(BaseEvent))]
	[ORKNodeInfo("Love\u2215Hate Steps")]
	public class ChangePADSteps : BaseEventStep
	{

		// Actor
		[ORKEditorHelp("Actor", "Select the actor committing the deed.", "")]
		[ORKEditorInfo(labelText="Actor")]
		public EventObjectSetting actorObject = new EventObjectSetting();


		// Happiness
		[ORKEditorInfo(labelText="Change Happiness By", separator=true)]
		public EventFloat valueHappiness = new EventFloat();
		
		[ORKEditorHelp("Operator", "Select how the happiness value will be changed:\n" +
		               "- Add: The value will be added to the current happiness value.\n" +
		               "- Sub: The value will be subtracted from the current happiness value.\n" +
		               "- Set: The happiness value will be set to the value." + 
		               "Happiness is in the range [-100,+100].", "")]
		[ORKEditorInfo(isEnumToolbar=true, toolbarWidth=50)]
		public SimpleOperator opHappiness = SimpleOperator.Add;
		
		
		
		// Happiness
		[ORKEditorInfo(labelText="Change Pleasure By", separator=true)]
		public EventFloat valuePleasure = new EventFloat();
		
		[ORKEditorHelp("Operator", "Select how the pleasure value will be changed:\n" +
		               "- Add: The value will be added to the current pleasure value.\n" +
		               "- Sub: The value will be subtracted from the current pleasure value.\n" +
		               "- Set: The pleasure value will be set to the value." + 
		               "Pleasure is in the range [-100,+100].", "")]
		[ORKEditorInfo(isEnumToolbar=true, toolbarWidth=50)]
		public SimpleOperator opPleasure = SimpleOperator.Add;
		
		
		
		// Happiness
		[ORKEditorInfo(labelText="Change Arousal By", separator=true)]
		public EventFloat valueArousal = new EventFloat();
		
		[ORKEditorHelp("Operator", "Select how the arousal value will be changed:\n" +
		               "- Add: The value will be added to the current arousal value.\n" +
		               "- Sub: The value will be subtracted from the current arousal value.\n" +
		               "- Set: The arousal value will be set to the value." + 
		               "Arousal is in the range [-100,+100].", "")]
		[ORKEditorInfo(isEnumToolbar=true, toolbarWidth=50)]
		public SimpleOperator opArousal = SimpleOperator.Add;
		
		
		
		// Happiness
		[ORKEditorInfo(labelText="Change Dominance By", separator=true)]
		public EventFloat valueDominance = new EventFloat();
		
		[ORKEditorHelp("Operator", "Select how the dominance value will be changed:\n" +
		               "- Add: The value will be added to the current dominance value.\n" +
		               "- Sub: The value will be subtracted from the current dominance value.\n" +
		               "- Set: The dominance value will be set to the value." + 
		               "Dominance is in the range [-100,+100].", "")]
		[ORKEditorInfo(isEnumToolbar=true, toolbarWidth=50)]
		public SimpleOperator opDominance = SimpleOperator.Add;
		
		public ChangePADSteps()
		{
		}
		
		public override void Execute(BaseEvent baseEvent)
		{
			var factionMember = OrkEventTools.GetEventObjectComponentInChildren<FactionMember>(actorObject, baseEvent);
			if (factionMember == null)
			{
				Debug.LogWarning("Love/Hate: ChangePADSteps - Can't find faction member");
			}
			else
			{
				factionMember.pad.happiness = GetNewValue(factionMember.pad.happiness, opHappiness, valueHappiness, baseEvent);
				factionMember.pad.pleasure = GetNewValue(factionMember.pad.pleasure, opPleasure, valuePleasure, baseEvent);
				factionMember.pad.arousal = GetNewValue(factionMember.pad.arousal, opArousal, valueArousal, baseEvent);
				factionMember.pad.dominance = GetNewValue(factionMember.pad.dominance, opDominance, valueDominance, baseEvent);
			}
			baseEvent.StepFinished(next);
		}		

		private float GetNewValue(float originalValue, SimpleOperator op, EventFloat value, BaseEvent baseEvent)
		{
			var newValue = originalValue;
			switch (op)
			{
			case SimpleOperator.Set:
				newValue = value.GetValue(baseEvent);
				break;
			case SimpleOperator.Add:
				newValue += value.GetValue(baseEvent);
				break;
			case SimpleOperator.Sub:
				newValue -= value.GetValue(baseEvent);
				break;
			}
			return Mathf.Clamp(newValue, -100, 100);
		}
		
		public override string GetNodeDetails()
		{
			return actorObject.GetInfoText();
		}

	}

}
