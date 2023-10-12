using System.Collections.Generic;
using Helpers;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.LogEntries;

public class ChangeSettlementOwnerLogEntry : LogEntry, IEncyclopediaLog, IWarLog
{
	[SaveableField(80)]
	public readonly Settlement Settlement;

	[SaveableField(81)]
	public readonly Clan PreviousClan;

	[SaveableField(82)]
	public readonly Clan NewClan;

	[SaveableField(83)]
	private readonly bool _bySiege;

	internal static void AutoGeneratedStaticCollectObjectsChangeSettlementOwnerLogEntry(object o, List<object> collectedObjects)
	{
		((ChangeSettlementOwnerLogEntry)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		base.AutoGeneratedInstanceCollectObjects(collectedObjects);
		collectedObjects.Add(Settlement);
		collectedObjects.Add(PreviousClan);
		collectedObjects.Add(NewClan);
	}

	internal static object AutoGeneratedGetMemberValueSettlement(object o)
	{
		return ((ChangeSettlementOwnerLogEntry)o).Settlement;
	}

	internal static object AutoGeneratedGetMemberValuePreviousClan(object o)
	{
		return ((ChangeSettlementOwnerLogEntry)o).PreviousClan;
	}

	internal static object AutoGeneratedGetMemberValueNewClan(object o)
	{
		return ((ChangeSettlementOwnerLogEntry)o).NewClan;
	}

	internal static object AutoGeneratedGetMemberValue_bySiege(object o)
	{
		return ((ChangeSettlementOwnerLogEntry)o)._bySiege;
	}

	public ChangeSettlementOwnerLogEntry(Settlement settlement, Hero newOwner, Hero previousOwner, bool bySiege)
	{
		Settlement = settlement;
		PreviousClan = previousOwner.Clan;
		NewClan = newOwner.Clan;
		_bySiege = bySiege;
	}

	public override ImportanceEnum GetImportanceForClan(Clan clan)
	{
		if (PreviousClan != NewClan)
		{
			if (NewClan != clan)
			{
				return ImportanceEnum.Important;
			}
			return ImportanceEnum.VeryImportant;
		}
		return ImportanceEnum.Zero;
	}

	public bool IsRelatedToWar(StanceLink stance, out IFaction effector, out IFaction effected)
	{
		IFaction faction = stance.Faction1;
		IFaction faction2 = stance.Faction2;
		effector = NewClan.MapFaction;
		effected = PreviousClan.MapFaction;
		if (NewClan.MapFaction != faction || PreviousClan.MapFaction != faction2)
		{
			if (NewClan.MapFaction == faction2)
			{
				return PreviousClan.MapFaction == faction;
			}
			return false;
		}
		return true;
	}

	public override void GetConversationScoreAndComment(Hero talkTroop, bool findString, out string comment, out ImportanceEnum score)
	{
		score = ImportanceEnum.Zero;
		comment = "";
		if (_bySiege && (NewClan == Clan.PlayerClan || PreviousClan == Clan.PlayerClan))
		{
			score = ImportanceEnum.Important;
			if (findString)
			{
				comment = "str_comment_changeownerofsettlement_you_captured_castle";
			}
		}
	}

	public override int GetAsRumor(Settlement talkSettlement, ref TextObject comment)
	{
		int result = 0;
		Settlement settlement = Settlement;
		if (NewClan.IsBanditFaction && settlement.IsHideout && Campaign.Current.Models.MapDistanceModel.GetDistance(talkSettlement, settlement, 60f, out var _))
		{
			comment = new TextObject("{=MXGtQ6YV}I hear {.%}{BANDIT_NAME}{.%} have moved into the old {HIDEOUT_NAME} near here. Travellers better watch themselves.");
			comment.SetTextVariable("BANDIT_NAME", NewClan.Name);
			comment.SetTextVariable("HIDEOUT_NAME", settlement.Name);
			return 4;
		}
		if (_bySiege && PreviousClan == talkSettlement.MapFaction)
		{
			comment = new TextObject("{=UMn2QMIk}Did you hear {ENEMY_NAME} took {FORTRESS_NAME} by storm? Do you think they'll come here next?");
			comment.SetTextVariable("ENEMY_NAME", FactionHelper.GetTermUsedByOtherFaction(NewClan, talkSettlement.MapFaction, pejorative: false));
			comment.SetTextVariable("FORTRESS_NAME", settlement.Name);
			return 10;
		}
		return result;
	}

	public override string ToString()
	{
		return GetEncyclopediaText().ToString();
	}

	public bool IsVisibleInEncyclopediaPageOf<T>(T obj) where T : MBObjectBase
	{
		if (obj == Settlement || obj == NewClan || obj == NewClan.Leader)
		{
			return !_bySiege;
		}
		return false;
	}

	public TextObject GetEncyclopediaText()
	{
		TextObject textObject = GameTexts.FindText("str_settlement_owner_changed_news");
		textObject.SetTextVariable("SETTLEMENT", Settlement.IsHideout ? Settlement.Name : Settlement.EncyclopediaLinkWithName);
		if (NewClan == null && Settlement.IsHideout)
		{
			return GameTexts.FindText("str_hideout_owner_changed_news");
		}
		StringHelpers.SetCharacterProperties("LORD", NewClan.Leader.CharacterObject, textObject);
		return textObject;
	}
}
