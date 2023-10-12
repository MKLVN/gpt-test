using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.Actions;

public static class SellPrisonersAction
{
	private enum SellPrisonersDetail
	{
		None,
		SellAllPrisoners,
		SellSelectedPrisoners,
		SellSettlementPrisoners
	}

	private static void ApplyInternal(MobileParty sellerParty, TroopRoster prisoners, Settlement currentSettlement, bool applyGoldChange, SellPrisonersDetail sellPrisonersDetail)
	{
		TroopRoster troopRoster = ((sellPrisonersDetail == SellPrisonersDetail.SellSettlementPrisoners) ? currentSettlement.Party.PrisonRoster : sellerParty.PrisonRoster);
		TroopRoster prisonerRoster = TroopRoster.CreateDummyTroopRoster();
		int num = 0;
		List<string> list = Campaign.Current.GetCampaignBehavior<IViewDataTracker>().GetPartyPrisonerLocks().ToList();
		for (int num2 = prisoners.Count - 1; num2 >= 0; num2--)
		{
			TroopRosterElement elementCopyAtIndex = prisoners.GetElementCopyAtIndex(num2);
			if (elementCopyAtIndex.Character != CharacterObject.PlayerCharacter)
			{
				int woundedNumber = elementCopyAtIndex.WoundedNumber;
				int num3 = elementCopyAtIndex.Number - woundedNumber;
				if ((sellPrisonersDetail == SellPrisonersDetail.SellAllPrisoners || sellPrisonersDetail == SellPrisonersDetail.SellSettlementPrisoners) && !elementCopyAtIndex.Character.IsHero && !list.Contains(elementCopyAtIndex.Character.StringId))
				{
					troopRoster.AddToCounts(elementCopyAtIndex.Character, -num3 - woundedNumber, insertAtFront: false, -woundedNumber);
					if (applyGoldChange)
					{
						int num4 = Campaign.Current.Models.RansomValueCalculationModel.PrisonerRansomValue(elementCopyAtIndex.Character, sellerParty?.LeaderHero);
						num += (num3 + woundedNumber) * num4;
					}
				}
				if (elementCopyAtIndex.Character.IsHero)
				{
					if (sellerParty?.LeaderHero == Hero.MainHero)
					{
						EndCaptivityAction.ApplyByRansom(elementCopyAtIndex.Character.HeroObject, null);
						num += Campaign.Current.Models.RansomValueCalculationModel.PrisonerRansomValue(elementCopyAtIndex.Character, sellerParty.LeaderHero);
					}
					else
					{
						troopRoster.RemoveTroop(elementCopyAtIndex.Character);
						if (currentSettlement.MapFaction.IsAtWarWith(elementCopyAtIndex.Character.HeroObject.MapFaction))
						{
							troopRoster.AddToCounts(elementCopyAtIndex.Character, num3 + woundedNumber, insertAtFront: false, woundedNumber);
							CampaignEventDispatcher.Instance.OnPrisonersChangeInSettlement(currentSettlement, null, elementCopyAtIndex.Character.HeroObject, takenFromDungeon: false);
						}
						else
						{
							EndCaptivityAction.ApplyByPeace(elementCopyAtIndex.Character.HeroObject);
							num += Campaign.Current.Models.RansomValueCalculationModel.PrisonerRansomValue(elementCopyAtIndex.Character, sellerParty.LeaderHero);
						}
					}
				}
				prisonerRoster.AddToCounts(elementCopyAtIndex.Character, num3 + woundedNumber);
			}
		}
		if (applyGoldChange)
		{
			switch (sellPrisonersDetail)
			{
			case SellPrisonersDetail.SellAllPrisoners:
				if (sellerParty.LeaderHero != null)
				{
					GiveGoldAction.ApplyBetweenCharacters(null, sellerParty.LeaderHero, num);
				}
				else if (sellerParty.Party.Owner != null)
				{
					GiveGoldAction.ApplyBetweenCharacters(null, sellerParty.Party.Owner, num);
				}
				break;
			case SellPrisonersDetail.SellSettlementPrisoners:
				GiveGoldAction.ApplyForPartyToSettlement(null, currentSettlement, num, currentSettlement.OwnerClan != Clan.PlayerClan);
				break;
			}
		}
		if (sellPrisonersDetail != SellPrisonersDetail.SellSettlementPrisoners)
		{
			SkillLevelingManager.OnPrisonerSell(sellerParty, in prisonerRoster);
			CampaignEventDispatcher.Instance.OnPrisonerSold(sellerParty, prisonerRoster, currentSettlement);
		}
	}

	public static void ApplyForAllPrisoners(MobileParty sellerParty, TroopRoster prisoners, Settlement currentSettlement, bool applyGoldChange = true)
	{
		ApplyInternal(sellerParty, prisoners, currentSettlement, applyGoldChange, SellPrisonersDetail.SellAllPrisoners);
	}

	public static void ApplyForSelectedPrisoners(MobileParty sellerParty, TroopRoster prisoners, Settlement currentSettlement)
	{
		ApplyInternal(sellerParty, prisoners, currentSettlement, applyGoldChange: false, SellPrisonersDetail.SellSelectedPrisoners);
	}

	public static void ApplyForSettlementPrisoners(Settlement sellerSettlement, TroopRoster soldPrisoners, bool applyGoldChange = true)
	{
		ApplyInternal(null, soldPrisoners, sellerSettlement, applyGoldChange, SellPrisonersDetail.SellSettlementPrisoners);
	}
}
