using System.Collections.Generic;
using Helpers;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.LogEntries;

public class PlayerMeetLordLogEntry : LogEntry, IEncyclopediaLog
{
	[SaveableField(290)]
	public readonly Hero Hero;

	public override CampaignTime KeepInHistoryTime => CampaignTime.Weeks(1f);

	internal static void AutoGeneratedStaticCollectObjectsPlayerMeetLordLogEntry(object o, List<object> collectedObjects)
	{
		((PlayerMeetLordLogEntry)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		base.AutoGeneratedInstanceCollectObjects(collectedObjects);
		collectedObjects.Add(Hero);
	}

	internal static object AutoGeneratedGetMemberValueHero(object o)
	{
		return ((PlayerMeetLordLogEntry)o).Hero;
	}

	public PlayerMeetLordLogEntry(Hero hero)
	{
		Hero = hero;
	}

	public override ImportanceEnum GetImportanceForClan(Clan clan)
	{
		return ImportanceEnum.SlightlyImportant;
	}

	public override void GetConversationScoreAndComment(Hero talkTroop, bool findString, out string comment, out ImportanceEnum score)
	{
		score = ImportanceEnum.Zero;
		comment = "";
		if (Campaign.Current.ConversationManager.CurrentConversationIsFirst && Hero == talkTroop)
		{
			score = ImportanceEnum.SlightlyImportant;
			if (HeroHelper.UnderPlayerCommand(talkTroop))
			{
				score = ImportanceEnum.ExtremelyImportant;
			}
		}
		if (!findString)
		{
			return;
		}
		comment = "str_comment_intro";
		string text = "";
		if (talkTroop.Clan != null && talkTroop.Clan.MapFaction != Hero.MainHero.MapFaction)
		{
			text = "str_comment_special_clan_intro_" + talkTroop.Clan.StringId;
			TextObject textObject = new TextObject();
			if (GameTexts.TryGetText(text, out textObject))
			{
				comment = text;
			}
		}
	}

	public override string ToString()
	{
		return GetEncyclopediaText().ToString();
	}

	public bool IsVisibleInEncyclopediaPageOf<T>(T obj) where T : MBObjectBase
	{
		return obj == Hero;
	}

	public TextObject GetEncyclopediaText()
	{
		TextObject textObject = GameTexts.FindText("str_action_meet_lord");
		StringHelpers.SetCharacterProperties("HERO_1", Hero.CharacterObject, textObject);
		StringHelpers.SetCharacterProperties("HERO_2", CharacterObject.PlayerCharacter, textObject);
		return textObject;
	}
}
