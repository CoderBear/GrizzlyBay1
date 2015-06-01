using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;
using ORKFramework;
using ORKFramework.Behaviours;

namespace PixelCrushers.LoveHate.ORKFrameworkSupport
{
	
	/// <summary>
	/// This subclass of FactionMember integrates with ORK's faction system.
	/// In an ORK project, use it instead of FactionMember. It uses the faction
	/// member's combatant level for its power level, and starts ORK events when
	/// Love/Hate events occur.
	/// </summary>
	[AddComponentMenu("Love\u2215Hate/Third Party/ORK Framework/Ork Faction Member")]
	public class OrkFactionMember : FactionMember, 
		IWitnessDeedEventHandler, IShareRumorsEventHandler, IEnterAuraEventHandler,
		IGreetEventHandler, IGossipEventHandler
	{

		[Serializable]
		public class EventInteractions
		{
			public EventInteraction witnessDeed = null;
			public EventInteraction shareRumors = null;
			public EventInteraction enterAura = null;
			public EventInteraction greet = null;
			public EventInteraction gossip = null;
		}

		/// <summary>
		/// The event interactions to start when Love/Hate events occur.
		/// </summary>
		public EventInteractions eventInteractions = new EventInteractions();

		/// <summary>
		/// Gets the last rumor witnessed.
		/// </summary>
		/// <value>The last rumor.</value>
		public Rumor lastRumor { get; private set; }

		/// <summary>
		/// Gets the last other faction member involved in a greeting, gossip, or rumors.
		/// </summary>
		/// <value>The last other faction member.</value>
		public FactionMember lastOtherFactionMember { get; private set; }

		/// <summary>
		/// Gets the last aura entered.
		/// </summary>
		/// <value>The last aura.</value>
		public AbstractAuraTrigger lastAura { get; private set; }

		private CombatantComponent m_combatant = null;

		protected override void Awake()
		{
			base.Awake();
			m_combatant = GetComponentInChildren<CombatantComponent>() ?? GetComponentInParent<CombatantComponent>();
			GetPowerLevel = GetCombatantLevel;
			lastRumor = null;
			lastOtherFactionMember = null;
			lastAura = null;
		}

		public void OnWitnessDeed(Rumor rumor)
		{
			lastRumor = rumor;
			StartEvent(eventInteractions.witnessDeed);
		}

		public void OnShareRumors(FactionMember other)
		{
			lastOtherFactionMember = other;
			StartEvent(eventInteractions.shareRumors);
		}

		public void OnEnterAura(AbstractAuraTrigger aura)
		{
			lastAura = aura;
			StartEvent(eventInteractions.enterAura);
		}

		public void OnGreet(FactionMember other)
		{
			lastOtherFactionMember = other;
			StartEvent(eventInteractions.greet);
		}

		public void OnGossip(FactionMember other)
		{
			lastOtherFactionMember = other;
			StartEvent(eventInteractions.gossip);
		}

		private void StartEvent(EventInteraction eventInteraction)
		{
			if (eventInteraction == null) return;
			eventInteraction.StartEvent(gameObject);
		}

		private float GetCombatantLevel()
		{
			return (m_combatant == null) ? DefaultGetPowerLevel() : m_combatant.combatant.Level;
		}

	}

}

