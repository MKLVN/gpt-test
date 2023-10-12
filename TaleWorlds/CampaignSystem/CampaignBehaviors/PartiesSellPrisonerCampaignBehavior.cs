using System.Linq;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class PartiesSellPrisonerCampaignBehavior : CampaignBehaviorBase
{
	public override void RegisterEvents()
	{
		CampaignEvents.SettlementEntered.AddNonSerializedListener(this, OnSettlementEntered);
		CampaignEvents.DailyTickSettlementEvent.AddNonSerializedListener(this, DailyTickSettlement);
	}

	public override void SyncData(IDataStore dataStore)
	{
	}

	private void OnSettlementEntered(MobileParty mobileParty, Settlement settlement, Hero hero)
	{
		if (!Campaign.Current.GameStarted || !settlement.IsFortification || mobileParty == null || mobileParty.MapFaction == null || mobileParty.IsMainParty || mobileParty.IsDisbanding || (!mobileParty.IsLordParty && !mobileParty.IsCaravan) || mobileParty.MapFaction.IsAtWarWith(settlement.MapFaction) || mobileParty.PrisonRoster.Count <= 0)
		{
			return;
		}
		if (mobileParty.MapFaction.IsKingdomFaction && mobileParty.ActualClan != null)
		{
			FlattenedTroopRoster flattenedTroopRoster = new FlattenedTroopRoster();
			TroopRoster troopRoster = TroopRoster.CreateDummyTroopRoster();
			foreach (TroopRosterElement item in mobileParty.PrisonRoster.GetTroopRoster())
			{
				if (item.Number == 0)
				{
					Debug.FailedAssert($"{item.Character.Name} number is 0 in prison roster!", "C:\\Develop\\MB3\\Source\\Bannerlord\\TaleWorlds.CampaignSystem\\CampaignBehaviors\\PartiesSellPrisonerCampaignBehavior.cs", "OnSettlementEntered", 45);
				}
				else if (!item.Character.IsHero)
				{
					flattenedTroopRoster.Add(item);
					settlement.Party.PrisonRoster.Add(item);
					mobileParty.PrisonRoster.RemoveTroop(item.Character, item.Number);
				}
				else
				{
					flattenedTroopRoster.Add(item);
					troopRoster.Add(item);
				}
			}
			SellPrisonersAction.ApplyForSelectedPrisoners(mobileParty, troopRoster, settlement);
			CampaignEventDispatcher.Instance.OnPrisonerDonatedToSettlement(mobileParty, flattenedTroopRoster, settlement);
		}
		else
		{
			SellPrisonersAction.ApplyForAllPrisoners(mobileParty, mobileParty.PrisonRoster, settlement);
		}
	}

	private void DailyTickSettlement(Settlement settlement)
	{
		if (!settlement.IsFortification)
		{
			return;
		}
		TroopRoster prisonRoster = settlement.Party.PrisonRoster;
		TroopRoster troopRoster = TroopRoster.CreateDummyTroopRoster();
		if (settlement.Owner != Hero.MainHero)
		{
			if (prisonRoster.TotalRegulars > 0)
			{
				int num = (int)((float)prisonRoster.TotalRegulars * 0.1f);
				if (num > 0)
				{
					foreach (TroopRosterElement item in prisonRoster.GetTroopRoster())
					{
						if (!item.Character.IsHero)
						{
							int num2 = ((num > item.Number) ? item.Number : num);
							num -= num2;
							troopRoster.AddToCounts(item.Character, num2);
							if (num <= 0)
							{
								break;
							}
						}
					}
				}
			}
		}
		else if (prisonRoster.TotalManCount > settlement.Party.PrisonerSizeLimit)
		{
			int num3 = prisonRoster.TotalManCount - settlement.Party.PrisonerSizeLimit;
			foreach (TroopRosterElement item2 in from t in prisonRoster.GetTroopRoster()
				orderby t.Character.Tier
				select t)
			{
				if (!item2.Character.IsHero)
				{
					if (num3 >= item2.Number)
					{
						num3 -= item2.Number;
						troopRoster.AddToCounts(item2.Character, item2.Number);
					}
					else
					{
						troopRoster.AddToCounts(item2.Character, num3);
						num3 = 0;
					}
					if (num3 <= 0)
					{
						break;
					}
				}
			}
		}
		if (troopRoster.TotalManCount > 0)
		{
			SellPrisonersAction.ApplyForSettlementPrisoners(settlement, troopRoster);
		}
	}
}
