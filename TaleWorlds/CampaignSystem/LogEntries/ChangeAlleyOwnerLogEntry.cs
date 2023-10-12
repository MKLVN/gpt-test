using System.Collections.Generic;
using Helpers;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.LogEntries;

public class ChangeAlleyOwnerLogEntry : LogEntry, IEncyclopediaLog, IChatNotification
{
	[SaveableField(60)]
	public readonly Alley Alley;

	[SaveableField(61)]
	public readonly Hero NewOwner;

	public bool IsVisibleNotification
	{
		get
		{
			if (NewOwner != null)
			{
				return NewOwner == Hero.MainHero;
			}
			return false;
		}
	}

	internal static void AutoGeneratedStaticCollectObjectsChangeAlleyOwnerLogEntry(object o, List<object> collectedObjects)
	{
		((ChangeAlleyOwnerLogEntry)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		base.AutoGeneratedInstanceCollectObjects(collectedObjects);
		collectedObjects.Add(Alley);
		collectedObjects.Add(NewOwner);
	}

	internal static object AutoGeneratedGetMemberValueAlley(object o)
	{
		return ((ChangeAlleyOwnerLogEntry)o).Alley;
	}

	internal static object AutoGeneratedGetMemberValueNewOwner(object o)
	{
		return ((ChangeAlleyOwnerLogEntry)o).NewOwner;
	}

	public ChangeAlleyOwnerLogEntry(Alley alley, Hero newOwner, Hero oldOwner)
	{
		Alley = alley;
		NewOwner = newOwner;
	}

	public TextObject GetNotificationText()
	{
		return GetEncyclopediaText();
	}

	public override void GetConversationScoreAndComment(Hero talkTroop, bool findString, out string comment, out ImportanceEnum score)
	{
		score = ImportanceEnum.Zero;
		comment = "";
	}

	public bool IsVisibleInEncyclopediaPageOf<T>(T obj) where T : MBObjectBase
	{
		if (obj != Alley.Settlement)
		{
			return obj == NewOwner;
		}
		return true;
	}

	public TextObject GetEncyclopediaText()
	{
		TextObject textObject;
		if (NewOwner != null)
		{
			textObject = GameTexts.FindText("str_alley_owner_changed_news");
			StringHelpers.SetCharacterProperties("HERO", NewOwner.CharacterObject, textObject);
		}
		else
		{
			textObject = GameTexts.FindText("str_alley_cleared_news");
		}
		textObject.SetTextVariable("SETTLEMENT", Alley.Settlement.EncyclopediaLinkWithName);
		textObject.SetTextVariable("COMMON_AREA", Alley.Name);
		return textObject;
	}

	public override string ToString()
	{
		return GetEncyclopediaText().ToString();
	}
}
