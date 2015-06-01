using UnityEngine;
using System.Text;
using System.Collections.Generic;
using ORKFramework;

namespace PixelCrushers.LoveHate.ORKFrameworkSupport
{
	
	/// <summary>
	/// This subclass of FactionManager integrates with ORK's save system.
	/// In an ORK project, use it instead of FactionManager.
	/// </summary>
	[AddComponentMenu("Love\u2215Hate/Third Party/ORK Framework/Ork Faction Manager")]
	public class OrkFactionManager : FactionManager, ISaveData
	{

		private const string DataTag = "OrkFactionManager";
		private const string FactionManagerDataKey = "FactionManagerData";
		private const string FactionMemberDataKey = "FactionMemberData";

		private bool m_started = false;
		private bool m_registeredSaveData = false;
		
		private void Start()
		{
			m_started = true;
			RegisterSaveData();
			DontDestroyOnLoad(gameObject);
		}
		
		private void OnEnable()
		{
			if (m_started) RegisterSaveData();
		}
		
		private void OnDisable()
		{
			UnregisterSaveData();
		}
		
		#region SaveData
		
		private void RegisterSaveData()
		{
			if (m_registeredSaveData) return;
			m_registeredSaveData = true;
			ORKFramework.ORK.SaveGame.RegisterCustomData(DataTag, this, false);
		}
		
		private void UnregisterSaveData() {
			if (!m_registeredSaveData) return;
			m_registeredSaveData = false;
			ORKFramework.ORK.SaveGame.UnregisterCustomData(DataTag, false);
		}
		
		public DataObject SaveGame() {
			if (debug)
			{
				Debug.Log("Love/Hate: Saving data to ORK Framework save system", this);
			}

			var data = new DataObject();

			// Save faction manager data:
			data.Set(FactionManagerDataKey, SerializeToString());

			// Save faction member data:
			var enumerator = members.GetEnumerator(); // Enumerates manually to avoid garbage.
			while (enumerator.MoveNext())
			{
				var factionMembers = enumerator.Current.Value;
				for (int i = 0; i < factionMembers.Count; i++)
				{
					var factionMember = factionMembers[i];
					data.Set(FactionMemberDataKey + factionMember.name, factionMember.SerializeToString());
				}
			}

			return data;
		}
		
		public void LoadGame(DataObject data) {
			if (data == null)
			{
				Debug.LogError("Love/Hate: Can't load data from ORK Framework save system; data is null");
				return;
			}
			else if (debug)
			{
				Debug.Log("Love/Hate: Loading data from ORK Framework save system", this);
			}
			string s = string.Empty;

			// Load faction manager data:
			data.Get(FactionManagerDataKey, ref s);
			DeserializeFromString(s);

			// Load faction member data:
			var enumerator = members.GetEnumerator(); // Enumerates manually to avoid garbage.
			while (enumerator.MoveNext())
			{
				var factionMembers = enumerator.Current.Value;
				for (int i = 0; i < factionMembers.Count; i++)
				{
					var factionMember = factionMembers[i];
					data.Get(FactionMemberDataKey + factionMember.name, ref s);
					factionMember.DeserializeFromString(s);
				}
			}
		}
		
		#endregion
		
	}

}

