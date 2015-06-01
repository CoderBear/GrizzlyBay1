using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.LoveHate;
using ORKFramework;
using PixelCrushers.LoveHate.ORKFrameworkSupport;

namespace ORKFramework.Events.Steps
{

	[ORKEditorHelp("Check Has Direct Parent", "Which steps will be executed next is decided by whether a faction has a direct parent.", "")]
	[ORKEventStep(typeof(BaseEvent))]
	[ORKNodeInfo("Love\u2215Hate Steps")]
	public class CheckHasDirectParentStep : BaseEventCheckStep
	{

		// Faction
		[ORKEditorHelp("Use Actor", "Check this actor's (combatant) faction.", "")]
		[ORKEditorInfo(labelText="Faction")]
		public bool useFactionActor = false;
		
		[ORKEditorHelp("Actor", "Select the actor whose faction to check.", "")]
		[ORKEditorInfo(isTabPopup=true, tabPopupID=0)]
		[ORKEditorLayout("useFactionActor", true)]
		public EventObjectSetting actorObject = new EventObjectSetting();
		
		[ORKEditorHelp("Faction", "Enter the name of the faction to check.", "")]
		[ORKEditorLayout(elseCheckGroup=true, endCheckGroup=true)]
		public string factionName = string.Empty;
		
		
		// Parent
		[ORKEditorHelp("Use Actor", "Check if this actor's (combatant) faction as a direct parent.", "")]
		[ORKEditorInfo(labelText="Parent Faction")]
		public bool useParentFactionActor = false;
		
		[ORKEditorHelp("Actor", "Select the actor whose faction may be a direct parent.", "")]
		[ORKEditorInfo(isTabPopup=true, tabPopupID=0)]
		[ORKEditorLayout("useParentFactionActor", true)]
		public EventObjectSetting parentActorObject = new EventObjectSetting();
		
		[ORKEditorHelp("Faction", "Enter the name of the direct parent faction.", "")]
		[ORKEditorLayout(elseCheckGroup=true, endCheckGroup=true)]
		public string parentFactionName = string.Empty;


		public CheckHasDirectParentStep()
		{
		}

		public override void Execute(BaseEvent baseEvent)
		{
			var factionManager = OrkEventTools.GetFactionManager(useFactionActor, actorObject, useParentFactionActor, parentActorObject, baseEvent);
			var factionID = OrkEventTools.GetFactionID(useFactionActor, actorObject, factionName, factionManager, baseEvent);
			var parentID = OrkEventTools.GetFactionID(useParentFactionActor, parentActorObject, parentFactionName, factionManager, baseEvent);
			if (factionManager == null || factionManager.factionDatabase == null)
			{
				Debug.LogWarning("Love/Hate: CheckHasDirectParentStep - Can't find faction manager");
			}
			if (factionID == -1)
			{
				Debug.LogWarning("Love/Hate: CheckHasDirectParentStep - Can't find faction ID");
			}
			else if (parentID == -1)
			{
				Debug.LogWarning("Love/Hate: CheckHasDirectParentStep - Can't find parent faction ID");
			}
			else
			{
				if (factionManager.factionDatabase.FactionHasDirectParent(factionID, parentID))
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
			return useParentFactionActor ? parentActorObject.GetInfoText() : parentFactionName;
		}

	}

}
