using System.Collections.Generic;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.LogEntries;

public class PlayerAttackAlleyLogEntry : LogEntry
{
	[SaveableField(270)]
	public readonly Hero CommonAreaOwner;

	[SaveableField(271)]
	public readonly Settlement Location;

	public override CampaignTime KeepInHistoryTime => CampaignTime.Weeks(1f);

	internal static void AutoGeneratedStaticCollectObjectsPlayerAttackAlleyLogEntry(object o, List<object> collectedObjects)
	{
		((PlayerAttackAlleyLogEntry)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		base.AutoGeneratedInstanceCollectObjects(collectedObjects);
		collectedObjects.Add(CommonAreaOwner);
		collectedObjects.Add(Location);
	}

	internal static object AutoGeneratedGetMemberValueCommonAreaOwner(object o)
	{
		return ((PlayerAttackAlleyLogEntry)o).CommonAreaOwner;
	}

	internal static object AutoGeneratedGetMemberValueLocation(object o)
	{
		return ((PlayerAttackAlleyLogEntry)o).Location;
	}

	public PlayerAttackAlleyLogEntry(Hero allyOwner, Settlement location)
	{
		CommonAreaOwner = allyOwner;
		Location = location;
	}

	public override ImportanceEnum GetImportanceForClan(Clan clan)
	{
		return ImportanceEnum.SlightlyImportant;
	}

	public override void GetConversationScoreAndComment(Hero talkTroop, bool findString, out string comment, out ImportanceEnum score)
	{
		score = ImportanceEnum.Zero;
		comment = "";
		if (CommonAreaOwner == talkTroop)
		{
			score = ImportanceEnum.QuiteImportant;
			if (findString)
			{
				comment = "str_comment_common_area_fight_owner";
			}
		}
		else if (talkTroop.HomeSettlement == Location)
		{
			score = ImportanceEnum.ReasonablyImportant;
			if (findString)
			{
				MBTextManager.SetTextVariable("COMMON_AREA_OWNER", CommonAreaOwner.Name);
				comment = "str_comment_common_area_fight_other";
			}
		}
	}

	public override string ToString()
	{
		TextObject textObject = new TextObject("{=!}Player attacked to common area of {OWNER_HERO} in {SETTLEMENT}.");
		textObject.SetTextVariable("OWNER_HERO", CommonAreaOwner.Name);
		textObject.SetTextVariable("SETTLEMENT", Location.Name);
		return textObject.ToString();
	}
}
