using System.Collections.Generic;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.Siege;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.BarterSystem.Barterables;

public class JoinKingdomAsClanBarterable : Barterable
{
	public readonly Kingdom TargetKingdom;

	public readonly bool IsDefecting;

	public override string StringID => "join_faction_barterable";

	public override TextObject Name
	{
		get
		{
			TextObject textObject = new TextObject("{=8Az4q2wp}Join {FACTION}");
			textObject.SetTextVariable("FACTION", TargetKingdom.Name);
			return textObject;
		}
	}

	public JoinKingdomAsClanBarterable(Hero owner, Kingdom targetKingdom, bool isDefecting = false)
		: base(owner, null)
	{
		TargetKingdom = targetKingdom;
		IsDefecting = isDefecting;
	}

	public override int GetUnitValueForFaction(IFaction factionForEvaluation)
	{
		float num = -1000000f;
		if (factionForEvaluation == base.OriginalOwner.Clan)
		{
			num = Campaign.Current.Models.DiplomacyModel.GetScoreOfClanToJoinKingdom(base.OriginalOwner.Clan, TargetKingdom);
			if (base.OriginalOwner.Clan.Kingdom != null)
			{
				int valueForFaction = new LeaveKingdomAsClanBarterable(base.OriginalOwner, base.OriginalParty).GetValueForFaction(factionForEvaluation);
				float num2 = 0f;
				if (!TargetKingdom.IsAtWarWith(base.OriginalOwner.Clan.Kingdom))
				{
					num2 = base.OriginalOwner.Clan.CalculateTotalSettlementValueForFaction(base.OriginalOwner.Clan.Kingdom);
					num -= num2 * ((TargetKingdom.Leader == Hero.MainHero) ? 0.5f : 1f);
				}
				num += (float)valueForFaction;
			}
		}
		else if (factionForEvaluation.MapFaction == TargetKingdom)
		{
			num = Campaign.Current.Models.DiplomacyModel.GetScoreOfKingdomToGetClan(TargetKingdom, base.OriginalOwner.Clan);
		}
		if (TargetKingdom == Clan.PlayerClan.Kingdom && Hero.MainHero.GetPerkValue(DefaultPerks.Trade.SilverTongue))
		{
			num += num * DefaultPerks.Trade.SilverTongue.PrimaryBonus;
		}
		return (int)num;
	}

	public override void CheckBarterLink(Barterable linkedBarterable)
	{
	}

	public override bool IsCompatible(Barterable barterable)
	{
		if (barterable is LeaveKingdomAsClanBarterable leaveKingdomAsClanBarterable)
		{
			return leaveKingdomAsClanBarterable.OriginalOwner.MapFaction != TargetKingdom;
		}
		return true;
	}

	public override ImageIdentifier GetVisualIdentifier()
	{
		return new ImageIdentifier(BannerCode.CreateFrom(TargetKingdom.Banner));
	}

	public override string GetEncyclopediaLink()
	{
		return TargetKingdom.EncyclopediaLink;
	}

	public override void Apply()
	{
		if (TargetKingdom != null && TargetKingdom != null && TargetKingdom.Leader == Hero.MainHero)
		{
			int valueForFaction = GetValueForFaction(base.OriginalOwner.Clan);
			int relation = ((valueForFaction < 0) ? (20 - valueForFaction / 20000) : 20);
			ChangeRelationAction.ApplyPlayerRelation(base.OriginalOwner.Clan.Leader, relation);
			if (base.OriginalOwner.Clan.MapFaction != null)
			{
				ChangeRelationAction.ApplyRelationChangeBetweenHeroes(base.OriginalOwner.Clan.Leader, base.OriginalOwner.Clan.MapFaction.Leader, -100);
			}
		}
		if (PlayerEncounter.Current != null && PlayerEncounter.Current.PlayerSide == BattleSideEnum.Defender && PlayerSiege.PlayerSiegeEvent != null && PlayerSiege.PlayerSide == BattleSideEnum.Attacker)
		{
			PlayerEncounter.Current.SetPlayerSiegeInterruptedByEnemyDefection();
		}
		if (base.OriginalOwner.Clan.Kingdom != null)
		{
			if (base.OriginalOwner.Clan.Kingdom != null && TargetKingdom != null && base.OriginalOwner.Clan.Kingdom.IsAtWarWith(TargetKingdom))
			{
				ChangeKingdomAction.ApplyByLeaveWithRebellionAgainstKingdom(base.OriginalOwner.Clan);
			}
			else
			{
				ChangeKingdomAction.ApplyByLeaveKingdom(base.OriginalOwner.Clan);
			}
		}
		if (IsDefecting)
		{
			ChangeKingdomAction.ApplyByJoinToKingdomByDefection(base.OriginalOwner.Clan, TargetKingdom);
		}
		else
		{
			ChangeKingdomAction.ApplyByJoinToKingdom(base.OriginalOwner.Clan, TargetKingdom);
		}
	}

	internal static void AutoGeneratedStaticCollectObjectsJoinKingdomAsClanBarterable(object o, List<object> collectedObjects)
	{
		((JoinKingdomAsClanBarterable)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		base.AutoGeneratedInstanceCollectObjects(collectedObjects);
	}
}
