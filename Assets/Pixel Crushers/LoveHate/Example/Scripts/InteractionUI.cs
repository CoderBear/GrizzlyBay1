using UnityEngine;
using System.Collections;

namespace PixelCrushers.LoveHate.Example
{

	/// <summary>
	/// This script maintains the faction info window in the lower
	/// right of the example scene.
	/// </summary>
	public class InteractionUI : MonoBehaviour 
	{

		public FactionManager factionManager;

		public CanvasGroup introCanvasGroup;

		public RectTransform panel;

		public UnityEngine.UI.Text text;

		private void Awake()
		{
			if (factionManager == null)
			{
				factionManager = FindObjectOfType<FactionManager>();
			}
		}

		private IEnumerator Start()
		{
			panel.gameObject.SetActive(false);
			float elapsed = 0;
			while (elapsed < 5)
			{
				if (IsInterruptKeyDown()) break;
				yield return null;
				elapsed += Time.deltaTime;
			}
			while (introCanvasGroup.alpha > 0.05f)
			{
				if (IsInterruptKeyDown()) break;
				yield return null;
				introCanvasGroup.alpha -= Time.deltaTime;
			}
			introCanvasGroup.gameObject.SetActive(false);
		}

		private bool IsInterruptKeyDown()
		{
			return Input.GetKeyDown(KeyCode.Escape) ||
					Input.GetKeyDown(KeyCode.Return) ||
					Input.GetKeyDown(KeyCode.Space) ||
					Input.GetMouseButtonDown(0) ||
					Mathf.Abs(Input.GetAxis("Vertical")) > 0.1 ||
					Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1;
		}

		public void Watch(FactionMember member)
		{
			panel.gameObject.SetActive(member != null);
			if (member == null) 
			{
				text.text = string.Empty;
				return;
			}
			text.text = "NPC: " + member.name + "\n";
			text.text += "Faction: " + member.faction.name + "\n";
			text.text += "Description: " + member.faction.description + "\n";

			text.text += "\nParents:\n";
			for (int p = 0; p < member.faction.parents.Length; p++)
			{
				var parentID = member.faction.parents[p];
				text.text += "\t" + factionManager.GetFaction(parentID).name + "\n";
			}

			text.text += "\nPAD:\n" +
				"\tPleasure: " + member.pad.pleasure + "\n" +
				"\tArousal: " + member.pad.arousal + "\n" +
				"\tDominance: " + member.pad.dominance + "\n" +
				"\tHappiness: " + member.pad.happiness + "\n" +
				"\tTemperament: " + member.pad.GetTemperament() + "\n";

			text.text += "\nTraits:\n";
			for (int i = 0; i < factionManager.factionDatabase.personalityTraitDefinitions.Length; i++)
			{
				text.text += "\t" + factionManager.factionDatabase.personalityTraitDefinitions[i].name + ": " + member.faction.traits[i] + "\n";
			}

			text.text += "\nRelationships:\n";
			for (int r = 0; r < member.faction.relationships.Count; r++)
			{
				var relationship = member.faction.relationships[r];
				text.text += "\t" + factionManager.GetFaction(relationship.factionID).name + ": " + relationship.affinity + "\n";
			}

			text.text += "\nMemories:\n";
			for (int m = 0; m < member.longTermMemory.Count; m++)
			{
				var rumor = member.longTermMemory[m];
				text.text += "\t" + factionManager.GetFaction(rumor.actorFactionID).name + " " + rumor.tag + " " +
					factionManager.GetFaction(rumor.targetFactionID).name + ": impact " + rumor.impact;
				if (rumor.count > 1)
				{
					text.text += " (x" + rumor.count + ")";
				}
				text.text += "\n";
			}
		}

	}

}
