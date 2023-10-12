using System.Collections.Generic;
using Helpers;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class PlayerTrackCompanionBehavior : CampaignBehaviorBase
{
	public Dictionary<Hero, CampaignTime> ScatteredCompanions = new Dictionary<Hero, CampaignTime>();

	public override void RegisterEvents()
	{
		CampaignEvents.CharacterBecameFugitive.AddNonSerializedListener(this, HeroBecameFugitive);
		CampaignEvents.CompanionRemoved.AddNonSerializedListener(this, CompanionRemoved);
		CampaignEvents.SettlementEntered.AddNonSerializedListener(this, SettlementEntered);
		CampaignEvents.NewCompanionAdded.AddNonSerializedListener(this, CompanionAdded);
		CampaignEvents.HeroPrisonerReleased.AddNonSerializedListener(this, PrisonerReleased);
		CampaignEvents.CanBeGovernorOrHavePartyRoleEvent.AddNonSerializedListener(this, CanBeGovernorOrHavePartyRole);
	}

	public override void SyncData(IDataStore dataStore)
	{
		dataStore.SyncData("ScatteredCompanions", ref ScatteredCompanions);
	}

	private void CanBeGovernorOrHavePartyRole(Hero hero, ref bool canBeGovernorOrHavePartyRole)
	{
		if (ScatteredCompanions.ContainsKey(hero))
		{
			canBeGovernorOrHavePartyRole = false;
		}
	}

	private void AddHeroToScatteredCompanions(Hero hero)
	{
		if (hero.IsPlayerCompanion)
		{
			if (!ScatteredCompanions.ContainsKey(hero))
			{
				ScatteredCompanions.Add(hero, CampaignTime.Now);
			}
			else
			{
				ScatteredCompanions[hero] = CampaignTime.Now;
			}
		}
	}

	private void HeroBecameFugitive(Hero hero)
	{
		AddHeroToScatteredCompanions(hero);
	}

	private void PrisonerReleased(Hero releasedHero, PartyBase party, IFaction capturerFaction, EndCaptivityDetail detail)
	{
		AddHeroToScatteredCompanions(releasedHero);
	}

	private void SettlementEntered(MobileParty party, Settlement settlement, Hero hero)
	{
		if (party != MobileParty.MainParty)
		{
			return;
		}
		foreach (Hero item in settlement.HeroesWithoutParty)
		{
			if (ScatteredCompanions.ContainsKey(item))
			{
				TextObject textObject = new TextObject("{=ahpSGaow}You hear that your companion {NOTABLE.LINK}, who was separated from you after a battle, is currently in this settlement.");
				StringHelpers.SetCharacterProperties("NOTABLE", item.CharacterObject, textObject);
				InformationManager.ShowInquiry(new InquiryData(new TextObject("{=dx0hmeH6}Tracking").ToString(), textObject.ToString(), isAffirmativeOptionShown: true, isNegativeOptionShown: false, new TextObject("{=yS7PvrTD}OK").ToString(), "", null, null));
				ScatteredCompanions.Remove(item);
			}
		}
	}

	private void CompanionAdded(Hero companion)
	{
		if (ScatteredCompanions.ContainsKey(companion))
		{
			ScatteredCompanions.Remove(companion);
		}
	}

	private void CompanionRemoved(Hero companion, RemoveCompanionAction.RemoveCompanionDetail detail)
	{
		if (ScatteredCompanions.ContainsKey(companion))
		{
			ScatteredCompanions.Remove(companion);
		}
	}
}
