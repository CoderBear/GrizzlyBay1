using UnityEngine;  
using UnityEditor;  
using UnityEditorInternal;
using System.IO;
using System.Collections.Generic;
using ORKFramework.Behaviours;

namespace PixelCrushers.LoveHate.ORKFrameworkSupport
{

	/// <summary>
	/// Custom editor for OrkFactionMember.
	/// </summary>
	[CustomEditor(typeof(OrkFactionMember))]
	[CanEditMultipleObjects]
	public class OrkFactionMemberEditor : FactionMemberEditor
	{

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			// Event interactions:
			if (!(target is OrkFactionMember)) return;
			var events = (target as OrkFactionMember).eventInteractions;
			events.witnessDeed = EditorGUILayout.ObjectField(new GUIContent("Witness Deed", "Play this event when the character witnesses a deed"), events.witnessDeed, typeof(EventInteraction), true) as EventInteraction;
			events.shareRumors = EditorGUILayout.ObjectField(new GUIContent("Share Rumors", "Play this event when the character shares rumors with another"), events.shareRumors, typeof(EventInteraction), true) as EventInteraction;
			events.enterAura = EditorGUILayout.ObjectField(new GUIContent("Enter Aura", "Play this event when the character enters an aura trigger"), events.enterAura, typeof(EventInteraction), true) as EventInteraction;
			events.greet = EditorGUILayout.ObjectField(new GUIContent("Greet", "Play this event when the character greets another"), events.greet, typeof(EventInteraction), true) as EventInteraction;
			events.gossip = EditorGUILayout.ObjectField(new GUIContent("Gossip", "Play this event when the character gossips with another"), events.gossip, typeof(EventInteraction), true) as EventInteraction;
		}
	}

}
