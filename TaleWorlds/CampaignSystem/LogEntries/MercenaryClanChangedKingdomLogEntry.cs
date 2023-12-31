using System.Collections.Generic;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.LogEntries;

public class MercenaryClanChangedKingdomLogEntry : LogEntry, IChatNotification, IWarLog
{
	[SaveableField(250)]
	public readonly Clan Clan;

	[SaveableField(251)]
	public readonly Kingdom OldKingdom;

	[SaveableField(252)]
	public readonly Kingdom NewKingdom;

	public bool IsVisibleNotification => true;

	public override ChatNotificationType NotificationType => MilitaryNotification(NewKingdom, OldKingdom);

	internal static void AutoGeneratedStaticCollectObjectsMercenaryClanChangedKingdomLogEntry(object o, List<object> collectedObjects)
	{
		((MercenaryClanChangedKingdomLogEntry)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		base.AutoGeneratedInstanceCollectObjects(collectedObjects);
		collectedObjects.Add(Clan);
		collectedObjects.Add(OldKingdom);
		collectedObjects.Add(NewKingdom);
	}

	internal static object AutoGeneratedGetMemberValueClan(object o)
	{
		return ((MercenaryClanChangedKingdomLogEntry)o).Clan;
	}

	internal static object AutoGeneratedGetMemberValueOldKingdom(object o)
	{
		return ((MercenaryClanChangedKingdomLogEntry)o).OldKingdom;
	}

	internal static object AutoGeneratedGetMemberValueNewKingdom(object o)
	{
		return ((MercenaryClanChangedKingdomLogEntry)o).NewKingdom;
	}

	public MercenaryClanChangedKingdomLogEntry(Clan clan, Kingdom oldKingdom, Kingdom newKingdom)
	{
		Clan = clan;
		OldKingdom = oldKingdom;
		NewKingdom = newKingdom;
	}

	public bool IsRelatedToWar(StanceLink stance, out IFaction effector, out IFaction effected)
	{
		IFaction faction = stance.Faction1;
		IFaction faction2 = stance.Faction2;
		effector = NewKingdom?.MapFaction;
		effected = OldKingdom?.MapFaction;
		if (NewKingdom != faction2)
		{
			return NewKingdom == faction;
		}
		return true;
	}

	public override string ToString()
	{
		return GetNotificationText().ToString();
	}

	public TextObject GetNotificationText()
	{
		if (OldKingdom == null && NewKingdom != null)
		{
			TextObject textObject = GameTexts.FindText("str_notification_mercenary_contract");
			textObject.SetTextVariable("CLAN", Clan.Name);
			textObject.SetTextVariable("KINGDOM", NewKingdom.InformalName);
			return textObject;
		}
		if (OldKingdom != null && NewKingdom == null)
		{
			TextObject textObject2 = GameTexts.FindText("str_notification_mercenary_contract_end");
			textObject2.SetTextVariable("CLAN", Clan.Name);
			textObject2.SetTextVariable("KINGDOM", OldKingdom.InformalName);
			return textObject2;
		}
		if (OldKingdom != null && NewKingdom != null)
		{
			TextObject textObject3 = GameTexts.FindText("str_notification_mercenary_contract");
			textObject3.SetTextVariable("CLAN", Clan.Name);
			textObject3.SetTextVariable("KINGDOM", NewKingdom.InformalName);
			return textObject3;
		}
		return TextObject.Empty;
	}
}
