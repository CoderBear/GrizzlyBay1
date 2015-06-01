using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;
using ORKFramework;
using ORKFramework.Behaviours;

namespace PixelCrushers.LoveHate.ORKFrameworkSupport
{
	
	/// <summary>
	/// This subclass of EventInteraction runs when an aura is triggered.
	/// Set the Start Type to None.
	/// </summary>
	[AddComponentMenu("Love\u2215Hate/Third Party/ORK Framework/Aura Event Interaction")]
	public class AuraEventInteraction : EventInteraction, IAuraEventHandler
	{

		[HideInInspector]
		public FactionMember lastFactionMember = null;

		public void OnAura(FactionMember other)
		{
			lastFactionMember = other;
			StartEvent(gameObject);
		}

	}

}

