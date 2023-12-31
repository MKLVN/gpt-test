using Helpers;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Issues;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Buildings;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultSettlementTaxModel : SettlementTaxModel
{
	private static readonly TextObject ProsperityText = GameTexts.FindText("str_prosperity");

	private static readonly TextObject VeryLowSecurity = new TextObject("{=IaJ4lhzx}Very Low Security");

	private static readonly TextObject VeryLowLoyalty = new TextObject("{=CcQzFnpN}Very Low Loyalty");

	public override float SettlementCommissionRateTown => 0.06f;

	public override float SettlementCommissionRateVillage => 0.7f;

	public override int SettlementCommissionDecreaseSecurityThreshold => 75;

	public override int MaximumDecreaseBasedOnSecuritySecurity => 10;

	public override float GetTownTaxRatio(Town town)
	{
		float num = 1f;
		if (town.Settlement.OwnerClan.Kingdom != null && town.Settlement.OwnerClan.Kingdom.ActivePolicies.Contains(DefaultPolicies.CrownDuty))
		{
			num += 0.05f;
		}
		return SettlementCommissionRateTown * num;
	}

	public override float GetVillageTaxRatio()
	{
		return SettlementCommissionRateVillage;
	}

	public override float GetTownCommissionChangeBasedOnSecurity(Town town, float commission)
	{
		if (town.Security < (float)SettlementCommissionDecreaseSecurityThreshold)
		{
			float num = MBMath.Map((float)SettlementCommissionDecreaseSecurityThreshold - town.Security, 0f, SettlementCommissionDecreaseSecurityThreshold, MaximumDecreaseBasedOnSecuritySecurity, 0f);
			commission -= commission * (num * 0.01f);
			return commission;
		}
		return commission;
	}

	public override ExplainedNumber CalculateTownTax(Town town, bool includeDescriptions = false)
	{
		ExplainedNumber result = new ExplainedNumber(0f, includeDescriptions);
		CalculateDailyTaxInternal(town, ref result);
		return result;
	}

	private float CalculateDailyTax(Town town, ref ExplainedNumber explainedNumber)
	{
		float prosperity = town.Prosperity;
		float num = 1f;
		if (town.Settlement.OwnerClan.Kingdom != null && town.Settlement.OwnerClan.Kingdom.ActivePolicies.Contains(DefaultPolicies.CouncilOfTheCommons))
		{
			num -= 0.05f;
		}
		float num2 = 0.35f;
		float value = prosperity * num2 * num;
		explainedNumber.Add(value, ProsperityText);
		return explainedNumber.ResultNumber;
	}

	private void CalculateDailyTaxInternal(Town town, ref ExplainedNumber result)
	{
		float rawTax = CalculateDailyTax(town, ref result);
		CalculatePolicyGoldCut(town, rawTax, ref result);
		if (town.IsTown || town.IsCastle)
		{
			if (PerkHelper.GetPerkValueForTown(DefaultPerks.Bow.QuickDraw, town))
			{
				PerkHelper.AddPerkBonusForTown(DefaultPerks.Bow.QuickDraw, town, ref result);
			}
			Hero governor = town.Governor;
			if (governor != null && governor.GetPerkValue(DefaultPerks.Steward.Logistician))
			{
				PerkHelper.AddPerkBonusForTown(DefaultPerks.Steward.Logistician, town, ref result);
			}
		}
		if (town.IsTown)
		{
			if (PerkHelper.GetPerkValueForTown(DefaultPerks.Scouting.DesertBorn, town))
			{
				PerkHelper.AddPerkBonusForTown(DefaultPerks.Scouting.DesertBorn, town, ref result);
			}
			if (town.Governor != null && town.Governor.GetPerkValue(DefaultPerks.Steward.PriceOfLoyalty))
			{
				int num = town.Governor.GetSkillValue(DefaultSkills.Steward) - Campaign.Current.Models.CharacterDevelopmentModel.MinSkillRequiredForEpicPerkBonus;
				result.AddFactor(DefaultPerks.Steward.PriceOfLoyalty.SecondaryBonus * (float)num, DefaultPerks.Steward.PriceOfLoyalty.Name);
			}
			if (town.OwnerClan.Culture.HasFeat(DefaultCulturalFeats.KhuzaitDecreasedTaxFeat))
			{
				result.AddFactor(DefaultCulturalFeats.KhuzaitDecreasedTaxFeat.EffectBonus, GameTexts.FindText("str_culture"));
			}
		}
		GetSettlementTaxChangeDueToIssues(town, ref result);
		CalculateSettlementTaxDueToSecurity(town, ref result);
		CalculateSettlementTaxDueToLoyalty(town, ref result);
		CalculateSettlementTaxDueToBuildings(town, ref result);
		result.Clamp(0f, float.MaxValue);
	}

	private void CalculateSettlementTaxDueToSecurity(Town town, ref ExplainedNumber explainedNumber)
	{
		SettlementSecurityModel settlementSecurityModel = Campaign.Current.Models.SettlementSecurityModel;
		if (town.Security >= (float)settlementSecurityModel.ThresholdForTaxBoost)
		{
			settlementSecurityModel.CalculateGoldGainDueToHighSecurity(town, ref explainedNumber);
		}
		else if (town.Security >= (float)settlementSecurityModel.ThresholdForHigherTaxCorruption && town.Security < (float)settlementSecurityModel.ThresholdForTaxCorruption)
		{
			settlementSecurityModel.CalculateGoldCutDueToLowSecurity(town, ref explainedNumber);
		}
	}

	private void CalculateSettlementTaxDueToLoyalty(Town town, ref ExplainedNumber explainedNumber)
	{
		SettlementLoyaltyModel settlementLoyaltyModel = Campaign.Current.Models.SettlementLoyaltyModel;
		if (town.Loyalty >= (float)settlementLoyaltyModel.ThresholdForTaxBoost)
		{
			settlementLoyaltyModel.CalculateGoldGainDueToHighLoyalty(town, ref explainedNumber);
		}
		else if (town.Loyalty >= (float)settlementLoyaltyModel.ThresholdForHigherTaxCorruption && town.Loyalty <= (float)settlementLoyaltyModel.ThresholdForTaxCorruption)
		{
			settlementLoyaltyModel.CalculateGoldCutDueToLowLoyalty(town, ref explainedNumber);
		}
		else if (town.Loyalty < (float)settlementLoyaltyModel.ThresholdForHigherTaxCorruption)
		{
			explainedNumber.AddFactor(-1f, VeryLowLoyalty);
		}
	}

	private void CalculateSettlementTaxDueToBuildings(Town town, ref ExplainedNumber result)
	{
		if (!town.IsTown && !town.IsCastle)
		{
			return;
		}
		foreach (Building building in town.Buildings)
		{
			float buildingEffectAmount = building.GetBuildingEffectAmount(BuildingEffectEnum.Tax);
			result.AddFactor(buildingEffectAmount * 0.01f, building.Name);
		}
	}

	private void CalculatePolicyGoldCut(Town town, float rawTax, ref ExplainedNumber explainedNumber)
	{
		if (town.MapFaction.IsKingdomFaction)
		{
			Kingdom obj = (Kingdom)town.MapFaction;
			if (obj.ActivePolicies.Contains(DefaultPolicies.Magistrates))
			{
				explainedNumber.Add(-0.05f * rawTax, DefaultPolicies.Magistrates.Name);
			}
			if (obj.ActivePolicies.Contains(DefaultPolicies.Cantons))
			{
				explainedNumber.Add(-0.1f * rawTax, DefaultPolicies.Cantons.Name);
			}
			if (obj.ActivePolicies.Contains(DefaultPolicies.Bailiffs))
			{
				explainedNumber.Add(-0.05f * rawTax, DefaultPolicies.Bailiffs.Name);
			}
			if (obj.ActivePolicies.Contains(DefaultPolicies.TribunesOfThePeople))
			{
				explainedNumber.Add(-0.05f * rawTax, DefaultPolicies.TribunesOfThePeople.Name);
			}
		}
	}

	private void GetSettlementTaxChangeDueToIssues(Town center, ref ExplainedNumber result)
	{
		Campaign.Current.Models.IssueModel.GetIssueEffectsOfSettlement(DefaultIssueEffects.SettlementTax, center.Owner.Settlement, ref result);
	}

	public override int CalculateVillageTaxFromIncome(Village village, int marketIncome)
	{
		return (int)((float)marketIncome * GetVillageTaxRatio());
	}
}
