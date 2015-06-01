using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.LoveHate;
using ORKFramework;
using PixelCrushers.LoveHate.ORKFrameworkSupport;

namespace ORKFramework.Events.Steps
{

	[ORKEditorHelp("Check Relationship Trait", "Which steps will be executed next is decided by a judge faction's relationship trait value to a subject faction.", "")]
	[ORKEventStep(typeof(BaseEvent))]
	[ORKNodeInfo("Love\u2215Hate Steps")]
	public class CheckRelationshipTraitStep : BaseEventCheckStep
	{

		// Judge
		[ORKEditorHelp("Use Actor", "The judging actor's (combatant) faction.", "")]
		[ORKEditorInfo(labelText="Judge Faction")]
		public bool useJudgeActor = false;

		[ORKEditorHelp("Actor", "Select the actor whose faction will judge the relationship to the subject.", "")]
		[ORKEditorInfo(isTabPopup=true, tabPopupID=0)]
		[ORKEditorLayout("useJudgeActor", true)]
		public EventObjectSetting judgeObject = new EventObjectSetting();
		
		[ORKEditorHelp("Judge Faction", "Enter the name of the faction that will judge the relationship to the subject.", "")]
		[ORKEditorLayout(elseCheckGroup=true, endCheckGroup=true)]
		public string judgeFactionName = string.Empty;


		// Subject
		[ORKEditorHelp("Use Actor", "The subject actor's (combatant) faction.", "")]
		[ORKEditorInfo(labelText="Subject Faction")]
		public bool useSubjectActor = false;
		
		[ORKEditorHelp("Actor", "Select the subject actor whose faction will be judged.", "")]
		[ORKEditorInfo(isTabPopup=true, tabPopupID=0)]
		[ORKEditorLayout("useSubjectActor", true)]
		public EventObjectSetting subjectObject = new EventObjectSetting();
		
		[ORKEditorHelp("Subject Faction", "Enter the name of the subject faction.", "")]
		[ORKEditorLayout(elseCheckGroup=true, endCheckGroup=true)]
		public string subjectFactionName = string.Empty;


		// Trait
		[ORKEditorHelp("Relationship Trait", "Enter the name of the relationship trait.", "")]
		[ORKEditorInfo(labelText="Relationship Trait")]
		public string relationshipTraitName = string.Empty;
		
		
		// Value
		[ORKEditorHelp("Check Type", "Checks if the value is equal, not equal, less or greater than a defined value.\n" +
		               "Relationship traits are in the range [-100,+100].\n" +
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
		

		public CheckRelationshipTraitStep()
		{
		}

		public override void Execute(BaseEvent baseEvent)
		{
			var factionManager = OrkEventTools.GetFactionManager(useJudgeActor, judgeObject, useSubjectActor, subjectObject, baseEvent);
			var judgeID = OrkEventTools.GetFactionID(useJudgeActor, judgeObject, judgeFactionName, factionManager, baseEvent);
			var subjectID = OrkEventTools.GetFactionID(useSubjectActor, subjectObject, subjectFactionName, factionManager, baseEvent);
			if (factionManager == null || factionManager.factionDatabase == null)
			{
				Debug.LogWarning("Love/Hate: CheckRelationshipTraitStep - Can't find faction manager");
			}
			if (judgeID == -1)
			{
				Debug.LogWarning("Love/Hate: CheckRelationshipTraitStep - Can't find judge faction ID");
			}
			else if (subjectID == -1)
			{
				Debug.LogWarning("Love/Hate: CheckRelationshipTraitStep - Can't find subject faction ID");
			}
			else
			{
				var traitID = factionManager.factionDatabase.GetRelationshipTraitID(relationshipTraitName);
				if (traitID == -1)
				{
					Debug.LogWarning("Love/Hate: CheckRelationshipTraitStep - Can't find relationship trait: " + relationshipTraitName);
				}
				else
				{
					var value = factionManager.factionDatabase.GetRelationshipTrait(judgeID, subjectID, traitID);
					if (ValueHelper.CheckVariableValue(
						value,
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
			}
			baseEvent.StepFinished(next);
		}		
		
		public override string GetNodeDetails()
		{
			return (useSubjectActor ? subjectObject.GetInfoText() : subjectFactionName) + " " +
				relationshipTraitName + " " + 
				check + " " + checkValue.GetInfoText() + 
				((VariableValueCheck.RangeInclusive.Equals(this.check) || 
				  VariableValueCheck.RangeExclusive.Equals(this.check)) ? 
				  " - " + this.checkValue2.GetInfoText() : "");
		}

	}

}
