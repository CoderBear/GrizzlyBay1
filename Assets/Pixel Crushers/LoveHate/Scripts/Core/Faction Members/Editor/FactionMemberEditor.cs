using UnityEngine;  
using UnityEditor;  
using UnityEditorInternal;
using System.IO;
using System.Collections.Generic;

namespace PixelCrushers.LoveHate
{

	/// <summary>
	/// Custom editor for FactionMember.
	/// </summary>
	[CustomEditor(typeof(FactionMember))]
	[CanEditMultipleObjects]
	public class FactionMemberEditor : Editor
	{

		private FactionMember m_member;
		private int[] m_factionIDList;
		private string[] m_factionNameList;

		private void OnEnable()
		{
			m_member = target as FactionMember;
			m_member.FindResources();
			UpdateFactionList();
		}

		private void UpdateFactionList()
		{
			var idList = new List<int>();
			var nameList = new List<string>();
			if (m_member.factionDatabase != null)
			{
				for (int i = 0; i < m_member.factionDatabase.factions.Length; i++)
				{
					var faction = m_member.factionDatabase.factions[i];
					idList.Add(faction.id);
					nameList.Add(faction.name);
				}
			}
			m_factionIDList = idList.ToArray();
			m_factionNameList = nameList.ToArray();
		}

		private int GetFactionListIndex()
		{
			if (m_member.factionDatabase != null)
			{
				for (int i = 0; i < m_factionIDList.Length; i++)
				{
					if (m_member.factionID == m_factionIDList[i])
					{
						return i;
					}
				}
			}
			return -1;
		}

		#region Inspector GUI

		public override void OnInspectorGUI()
		{
			//base.OnInspectorGUI();
			//EditorGUILayout.Separator();
			//EditorGUILayout.LabelField("CUSTOM EDITOR:");

			Undo.RecordObject(target, "FactionMember");
			DrawCustomGUI();
		}

		private void DrawCustomGUI()
		{
			var newManager = EditorGUILayout.ObjectField(new GUIContent("Faction Manager"), m_member.factionManager, typeof(FactionManager), true) as FactionManager;
			if (newManager != m_member.factionManager)
			{
				m_member.factionManager = newManager;
				m_member.factionDatabase = newManager.factionDatabase;
			}
			var newDatabase = EditorGUILayout.ObjectField(new GUIContent("Faction Database"), m_member.factionDatabase, typeof(FactionDatabase), true) as FactionDatabase;
			if (newDatabase != m_member.factionDatabase)
			{
				m_member.factionDatabase = newDatabase;
				UpdateFactionList();
			}
			var factionListIndex = GetFactionListIndex();
			var newFactionListIndex = EditorGUILayout.Popup("Faction", factionListIndex, m_factionNameList);
			if (newFactionListIndex != factionListIndex)
			{
				m_member.factionID = m_factionIDList[newFactionListIndex];
			}

			serializedObject.Update();
			EditorGUI.indentLevel++;
			EditorGUILayout.PropertyField(serializedObject.FindProperty("pad"), true);
			EditorGUI.indentLevel--;
			serializedObject.ApplyModifiedProperties();

			m_member.eyes = EditorGUILayout.ObjectField(new GUIContent("Eyes"), m_member.eyes, typeof(Transform), true) as Transform;
			serializedObject.Update();
			EditorGUILayout.PropertyField(serializedObject.FindProperty("sightLayerMask"));

			EditorGUILayout.PropertyField(serializedObject.FindProperty("deedImpactThreshold"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("acclimatizationCurve"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("maxMemories"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("shortTermMemoryDuration"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("longTermMemoryDuration"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("memoryCleanupFrequency"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("sortMemories"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("debugEvalFunc"));
			serializedObject.ApplyModifiedProperties();

			if (Application.isPlaying)
			{
				DrawMemories();
			}
		}

		private void DrawMemories()
		{
			GUILayout.Space(10);
			EditorGUILayout.LabelField("Short-Term Memory", EditorStyles.boldLabel);
			GUILayout.Space(10);
			EditorGUILayout.LabelField("Long-Term Memory", EditorStyles.boldLabel);
		}

		#endregion

	}

}
