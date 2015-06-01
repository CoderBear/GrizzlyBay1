using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ORKFramework;
using ORKFramework.Behaviours;
using ORKFramework.Events;
using ORKFramework.Events.Steps;
using PixelCrushers.LoveHate;

namespace PixelCrushers.LoveHate.ORKFrameworkSupport
{

	public static class OrkEventTools
	{

		public static Transform GetEventObjectTransform(EventObjectSetting eventObject, BaseEvent baseEvent)
		{
			var list = eventObject.GetObject(baseEvent);
			var hasItem = (list != null) && (list.Count > 0);
			return hasItem ? list[0].transform : null;
		}

		public static T GetEventObjectComponentInChildren<T>(EventObjectSetting eventObject, BaseEvent baseEvent) where T : Component
		{
			var transform = GetEventObjectTransform(eventObject, baseEvent);
			return (transform == null) ? null : transform.GetComponentInChildren<T>();
		}

		public static FactionManager GetFactionManager(bool useActor, EventObjectSetting eventObject, BaseEvent baseEvent)
		{
			if (useActor)
			{
				var factionMember = GetEventObjectComponentInChildren<FactionMember>(eventObject, baseEvent);
				return (factionMember == null) ? null : factionMember.factionManager;
			}
			else
			{
				return null;
			}
		}

		public static FactionManager GetFactionManager(bool useActor1, EventObjectSetting eventObject1, bool useActor2, EventObjectSetting eventObject2, BaseEvent baseEvent)
		{
			return GetFactionManager(useActor1, eventObject1, baseEvent) ??
					GetFactionManager (useActor2, eventObject2, baseEvent) ??
					GameObject.FindObjectOfType<FactionManager>();
		}

		public static int GetFactionID(bool useActor, EventObjectSetting eventObject, string factionName, FactionManager factionManager, BaseEvent baseEvent)
		{
			if (useActor)
			{
				var factionMember = GetEventObjectComponentInChildren<FactionMember>(eventObject, baseEvent);
				if (factionMember != null)
				{
					return factionMember.factionID;
				}
			}
			else if (factionManager != null)
			{
				return factionManager.GetFactionID(factionName);
			}
			return -1;
		}

		public static void SetVariableValue(BaseEvent baseEvent, System.Object value, 
		                                    VariableOrigin origin, bool useObject, 
		                                    EventObjectSetting variableObject, string objectID,
		                                    StringValue key)
		{
			if (value is string || value is bool || value is int || value is float || value is Vector3)
			{
				if (VariableOrigin.Local.Equals(origin))
				{
					SetVariableValue(baseEvent.Variables, value, key);
				}
				else if (VariableOrigin.Global.Equals(origin))
				{
					SetVariableValue(ORK.Game.Variables, value, key);
				}
				else if(VariableOrigin.Object.Equals(origin))
				{
					if (useObject)
					{
						List<GameObject> list2 = variableObject.GetObject(baseEvent);
						for (int j=0; j < list2.Count; j++)
						{
							if (list2[j] != null)
							{
								ObjectVariablesComponent[] comps = list2[j].
									GetComponentsInChildren<ObjectVariablesComponent>();
								for (int k=0; k < comps.Length; k++)
								{
									SetVariableValue(comps[k].GetHandler(), value, key);
								}
							}
						}
					}
					else
					{
						SetVariableValue(ORK.Game.Scene.GetObjectVariables(objectID), value, key);
					}
				}
			}
		}
		
		public static void SetVariableValue(VariableHandler handler, System.Object value, StringValue key)
		{
			if (value is string)
			{
				handler.Set(key.GetValue(), (string) value);
			}
			else if (value is bool)
			{
				handler.Set(key.GetValue(), (bool) value);
			}
			else if (value is int)
			{
				handler.Set(key.GetValue(), (int) value);
			}
			else if (value is float)
			{
				handler.Set(key.GetValue(), (float) value);
			}
			else if (value is Vector3)
			{
				handler.Set(key.GetValue(), (Vector3) value);
			}
		}

	}
}
