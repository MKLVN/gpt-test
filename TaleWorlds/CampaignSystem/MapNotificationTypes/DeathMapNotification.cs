using System.Collections.Generic;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.MapNotificationTypes;

public class DeathMapNotification : InformationData
{
	public override TextObject TitleText => new TextObject("{=W73My5KO}Death");

	public override string SoundEventPath => "event:/ui/notification/death";

	[SaveableProperty(1)]
	public Hero VictimHero { get; private set; }

	[SaveableProperty(2)]
	public Hero KillerHero { get; private set; }

	[SaveableProperty(3)]
	public KillCharacterAction.KillCharacterActionDetail KillDetail { get; private set; }

	[SaveableProperty(4)]
	public CampaignTime CreationTime { get; private set; }

	internal static void AutoGeneratedStaticCollectObjectsDeathMapNotification(object o, List<object> collectedObjects)
	{
		((DeathMapNotification)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		base.AutoGeneratedInstanceCollectObjects(collectedObjects);
		collectedObjects.Add(VictimHero);
		collectedObjects.Add(KillerHero);
		CampaignTime.AutoGeneratedStaticCollectObjectsCampaignTime(CreationTime, collectedObjects);
	}

	internal static object AutoGeneratedGetMemberValueVictimHero(object o)
	{
		return ((DeathMapNotification)o).VictimHero;
	}

	internal static object AutoGeneratedGetMemberValueKillerHero(object o)
	{
		return ((DeathMapNotification)o).KillerHero;
	}

	internal static object AutoGeneratedGetMemberValueKillDetail(object o)
	{
		return ((DeathMapNotification)o).KillDetail;
	}

	internal static object AutoGeneratedGetMemberValueCreationTime(object o)
	{
		return ((DeathMapNotification)o).CreationTime;
	}

	public DeathMapNotification(Hero victimHero, Hero killerHero, TextObject descriptionText, KillCharacterAction.KillCharacterActionDetail detail, CampaignTime creationTime)
		: base(descriptionText)
	{
		VictimHero = victimHero;
		KillerHero = killerHero;
		KillDetail = detail;
		CreationTime = creationTime;
	}
}
