using System.Collections.Generic;
using Helpers;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.LogEntries;

public class TakePrisonerLogEntry : LogEntry, IEncyclopediaLog, IChatNotification, IWarLog
{
	[SaveableField(330)]
	public readonly IFaction CapturerPartyMapFaction;

	[SaveableField(331)]
	public readonly Hero Prisoner;

	[SaveableField(332)]
	public readonly Settlement CapturerSettlement;

	[SaveableField(333)]
	public readonly Hero CapturerMobilePartyLeader;

	[SaveableField(334)]
	public readonly Hero CapturerHero;

	public override CampaignTime KeepInHistoryTime => CampaignTime.Weeks(12f);

	public bool IsVisibleNotification => true;

	public override ChatNotificationType NotificationType
	{
		get
		{
			IFaction faction = CapturerHero?.Clan;
			return MilitaryNotification(faction ?? CapturerPartyMapFaction, Prisoner.Clan);
		}
	}

	internal static void AutoGeneratedStaticCollectObjectsTakePrisonerLogEntry(object o, List<object> collectedObjects)
	{
		((TakePrisonerLogEntry)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		base.AutoGeneratedInstanceCollectObjects(collectedObjects);
		collectedObjects.Add(CapturerPartyMapFaction);
		collectedObjects.Add(Prisoner);
		collectedObjects.Add(CapturerSettlement);
		collectedObjects.Add(CapturerMobilePartyLeader);
		collectedObjects.Add(CapturerHero);
	}

	internal static object AutoGeneratedGetMemberValueCapturerPartyMapFaction(object o)
	{
		return ((TakePrisonerLogEntry)o).CapturerPartyMapFaction;
	}

	internal static object AutoGeneratedGetMemberValuePrisoner(object o)
	{
		return ((TakePrisonerLogEntry)o).Prisoner;
	}

	internal static object AutoGeneratedGetMemberValueCapturerSettlement(object o)
	{
		return ((TakePrisonerLogEntry)o).CapturerSettlement;
	}

	internal static object AutoGeneratedGetMemberValueCapturerMobilePartyLeader(object o)
	{
		return ((TakePrisonerLogEntry)o).CapturerMobilePartyLeader;
	}

	internal static object AutoGeneratedGetMemberValueCapturerHero(object o)
	{
		return ((TakePrisonerLogEntry)o).CapturerHero;
	}

	public TakePrisonerLogEntry(PartyBase capturerParty, Hero prisoner)
	{
		CapturerPartyMapFaction = capturerParty.MapFaction;
		CapturerHero = capturerParty.LeaderHero;
		CapturerMobilePartyLeader = capturerParty.MobileParty?.LeaderHero;
		CapturerSettlement = capturerParty.Settlement;
		Prisoner = prisoner;
	}

	public bool IsRelatedToWar(StanceLink stance, out IFaction effector, out IFaction effected)
	{
		IFaction faction = stance.Faction1;
		IFaction faction2 = stance.Faction2;
		effector = CapturerPartyMapFaction.MapFaction;
		effected = Prisoner.MapFaction;
		if (CapturerPartyMapFaction != faction || Prisoner.MapFaction != faction2)
		{
			if (CapturerPartyMapFaction == faction2)
			{
				return Prisoner.MapFaction == faction;
			}
			return false;
		}
		return true;
	}

	public override string ToString()
	{
		return GetNotificationText().ToString();
	}

	public TextObject GetNotificationText()
	{
		TextObject textObject = new TextObject("{=QRJQ9Wgv}{PRISONER_LORD.LINK}{?PRISONER_LORD_HAS_FACTION_LINK} of the {PRISONER_LORD_FACTION_LINK}{?}{\\?} has been taken prisoner by the {CAPTOR_FACTION}.");
		if (CapturerHero != null)
		{
			textObject = new TextObject("{=Ebb7aH3T}{PRISONER_LORD.LINK}{?PRISONER_LORD_HAS_FACTION_LINK} of the {PRISONER_LORD_FACTION_LINK}{?}{\\?} has been taken prisoner by {CAPTURER_LORD.LINK}{?CAPTURER_LORD_HAS_FACTION_LINK} of the {CAPTURER_LORD_FACTION_LINK}{?}{\\?}.");
			StringHelpers.SetCharacterProperties("CAPTURER_LORD", CapturerHero.CharacterObject, textObject);
			Clan clan = CapturerHero.Clan;
			if (clan != null && !clan.IsMinorFaction)
			{
				textObject.SetTextVariable("CAPTURER_LORD_FACTION_LINK", CapturerHero.MapFaction.EncyclopediaLinkWithName);
				textObject.SetTextVariable("CAPTURER_LORD_HAS_FACTION_LINK", 1);
			}
		}
		textObject.SetTextVariable("CAPTOR_FACTION", CapturerPartyMapFaction.InformalName);
		StringHelpers.SetCharacterProperties("PRISONER_LORD", Prisoner.CharacterObject, textObject);
		Clan clan2 = Prisoner.Clan;
		if (clan2 != null && !clan2.IsMinorFaction)
		{
			textObject.SetTextVariable("PRISONER_LORD_FACTION_LINK", Prisoner.MapFaction.EncyclopediaLinkWithName);
			textObject.SetTextVariable("PRISONER_LORD_HAS_FACTION_LINK", 1);
		}
		return textObject;
	}

	public bool IsVisibleInEncyclopediaPageOf<T>(T obj) where T : MBObjectBase
	{
		if (obj != Prisoner && (CapturerSettlement == null || obj != CapturerSettlement))
		{
			if (CapturerMobilePartyLeader != null)
			{
				return obj == CapturerMobilePartyLeader;
			}
			return false;
		}
		return true;
	}

	public TextObject GetEncyclopediaText()
	{
		return GetNotificationText();
	}
}
