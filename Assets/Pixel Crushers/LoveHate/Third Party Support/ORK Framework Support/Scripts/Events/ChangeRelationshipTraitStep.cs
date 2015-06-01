using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ORKFramework;
using PixelCrushers.LoveHate.ORKFrameworkSupport;

namespace ORKFramework.Events.Steps
{

	[ORKEditorHelp("Change Relationship Trait", "Changes the value of a relationship trait of a faction for another faction.", "")]
	[ORKEventStep(typeof(BaseEvent))]
	[ORKNodeInfo("Love\u2215Hate Steps")]
	public class ChangeRelationshipTraitStep : BaseEventStep
	{

		// Judge
		[ORKEditorHelp("Use Actor", "The judging actor's (combatant) faction.", "")]
		[ORKEditorInfo(labelText="Judge Faction")]
		public bool useJudgeActor = false;
		
		[ORKEditorHelp("Actor", "Select the actor whose faction will judge affinity to the subject.", "")]
		[ORKEditorInfo(isTabPopup=true, tabPopupID=0)]
		[ORKEditorLayout("useJudgeActor", true)]
		public EventObjectSetting judgeObject = new EventObjectSetting();
		
		[ORKEditorHelp("Judge Faction", "Enter the name of the faction that will judge affinity to the subject.", "")]
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

		
		// Change by
		[ORKEditorInfo(labelText="Change By", separator=true)]
		public EventFloat value = new EventFloat();
		
		[ORKEditorHelp("Operator", "Select how the trait will be changed:\n" +
		               "- Add: The value will be added to the current trait value.\n" +
		               "- Sub: The value will be subtracted from the current trait value.\n" +
		               "- Set: The trait will be set to the value." + 
		               "Traits are in the range [-100,+100].", "")]
		[ORKEditorInfo(isEnumToolbar=true, toolbarWidth=50)]
		public SimpleOperator op = SimpleOperator.Add;
		
		public ChangeRelationshipTraitStep()
		{
		}
		
		public override void Execute(BaseEvent baseEvent)
		{
			var factionManager = OrkEventTools.GetFactionManager(useJudgeActor, judgeObject, useSubjectActor, subjectObject, baseEvent);
			var judgeID = OrkEventTools.GetFactionID(useJudgeActor, judgeObject, judgeFactionName, factionManager, baseEvent);
			var subjectID = OrkEventTools.GetFactionID(useSubjectActor, subjectObject, subjectFactionName, factionManager, baseEvent);
			if (factionManager == null || factionManager.factionDatabase == null)
			{
				Debug.LogWarning("Love/Hate: ChangeRelationshipTraitStep - Can't find faction manager");
			}
			if (judgeID == -1)
			{
				Debug.LogWarning("Love/Hate: ChangeRelationshipTraitStep - Can't find judge faction ID");
			}
			else if (subjectID == -1)
			{
				Debug.LogWarning("Love/Hate: ChangeRelationshipTraitStep - Can't find subject faction ID");
			}
			else
			{
				var traitID = factionManager.factionDatabase.GetRelationshipTraitID(relationshipTraitName);
				if (traitID == -1)
				{
					Debug.LogWarning("Love/Hate: ChangeRelationshipTraitStep - Can't find relationship trait: " + relationshipTraitName);
				}
				else
				{
					switch (op)
					{
					case SimpleOperator.Set:
						factionManager.factionDatabase.SetPersonalRelationshipTrait(judgeID, subjectID, traitID, value.GetValue(baseEvent));
						break;
					case SimpleOperator.Add:
						factionManager.factionDatabase.ModifyPersonalRelationshipTrait(judgeID, subjectID, traitID, value.GetValue(baseEvent));
						break;
					case SimpleOperator.Sub:
						factionManager.factionDatabase.ModifyPersonalRelationshipTrait(judgeID, subjectID, traitID, -value.GetValue(baseEvent));
						break;
					}
				}
			}
			baseEvent.StepFinished(next);
		}		
		
		public override string GetNodeDetails()
		{
			return (useSubjectActor ? subjectObject.GetInfoText() : subjectFactionName) + " " +
				relationshipTraitName + " " + 
				op.ToString() + " " + value.GetInfoText();
		}

	}

}
