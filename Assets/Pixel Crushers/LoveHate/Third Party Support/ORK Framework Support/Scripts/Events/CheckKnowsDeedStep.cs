using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.LoveHate;
using ORKFramework;
using PixelCrushers.LoveHate.ORKFrameworkSupport;

namespace ORKFramework.Events.Steps
{

	[ORKEditorHelp("Check Knows Deed", "Which steps will be executed next is decided by whether a faction knows of a deed committed by another faction.", "")]
	[ORKEventStep(typeof(BaseEvent))]
	[ORKNodeInfo("Love\u2215Hate Steps")]
	public class CheckKnowsDeedStep : BaseEventCheckStep
	{

		// Judge
		[ORKEditorHelp("Judge", "Select the actor (combatant) whose knowledge to check.", "")]
		[ORKEditorInfo(labelText="Judge", isTabPopup=true, tabPopupID=0)]
		public EventObjectSetting judgeObject = new EventObjectSetting();


		// Actor
		[ORKEditorHelp("Use Actor", "Check whether this actor's (combatant) faction committed the deed.", "")]
		[ORKEditorInfo(labelText="Actor")]
		public bool useActor = false;
		
		[ORKEditorHelp("Actor", "Select the actor who may have committed the deed.", "")]
		[ORKEditorInfo(isTabPopup=true, tabPopupID=0)]
		[ORKEditorLayout("useActor", true)]
		public EventObjectSetting actorObject = new EventObjectSetting();
		
		[ORKEditorHelp("Actor Faction", "Enter the name of the faction of the actor who may have committed the deed.", "")]
		[ORKEditorLayout(elseCheckGroup=true, endCheckGroup=true)]
		public string actorFactionName = string.Empty;
		
		
		// Target
		[ORKEditorHelp("Use Actor", "Check if the deed was done to this actor's (combatant) faction.", "")]
		[ORKEditorInfo(labelText="Target Faction")]
		public bool useTargetFactionActor = false;
		
		[ORKEditorHelp("Target", "Select the target actor.", "")]
		[ORKEditorInfo(isTabPopup=true, tabPopupID=0)]
		[ORKEditorLayout("useTargetFactionActor", true)]
		public EventObjectSetting targetObject = new EventObjectSetting();
		
		[ORKEditorHelp("Target Faction", "Enter the name of the target faction.", "")]
		[ORKEditorLayout(elseCheckGroup=true, endCheckGroup=true)]
		public string targetFactionName = string.Empty;


		// Trait
		[ORKEditorHelp("Deed Tag", "Enter the deed tag to check.", "")]
		[ORKEditorInfo(labelText="Deed Tag", expandWidth=true)]
		public string deedTag = string.Empty;
		
		
		public CheckKnowsDeedStep()
		{
		}

		public override void Execute(BaseEvent baseEvent)
		{
			var judge = OrkEventTools.GetEventObjectComponentInChildren<FactionMember>(judgeObject, baseEvent);
			var factionManager = (judge == null) ? null : judge.factionManager;
			var actorID = OrkEventTools.GetFactionID(useActor, actorObject, actorFactionName, factionManager, baseEvent);
			var targetID = OrkEventTools.GetFactionID(useTargetFactionActor, targetObject, targetFactionName, factionManager, baseEvent);
			if (factionManager == null || factionManager.factionDatabase == null)
			{
				Debug.LogWarning("Love/Hate: CheckKnowsDeedStep - Can't find faction manager");
			}
			else if (judge == null)
			{
				Debug.LogWarning("Love/Hate: CheckKnowsDeedStep - Can't find judge faction member");
			}
			if (actorID == -1)
			{
				Debug.LogWarning("Love/Hate: CheckKnowsDeedStep - Can't find actor faction ID");
			}
			else if (targetID == -1)
			{
				Debug.LogWarning("Love/Hate: CheckKnowsDeedStep - Can't find target faction ID");
			}
			else
			{
				if (judge.KnowsAboutDeed(actorID, targetID, deedTag))
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
			return (useActor ? actorObject.GetInfoText() : actorFactionName) + " " +
				deedTag + " " + 
				(useTargetFactionActor ? targetObject.GetInfoText() : targetFactionName);
		}

	}

}
