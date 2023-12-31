using System.Collections.Generic;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.MapNotificationTypes;

public class SettlementOwnerChangedMapNotification : InformationData
{
	public override TextObject TitleText => new TextObject("{=b6BunI6y}Settlement Owner Changed");

	public override string SoundEventPath => "event:/ui/notification/settlement_owner_change";

	[SaveableProperty(10)]
	public Hero PreviousOwner { get; private set; }

	[SaveableProperty(20)]
	public Hero NewOwner { get; private set; }

	[SaveableProperty(30)]
	public Settlement Settlement { get; private set; }

	internal static void AutoGeneratedStaticCollectObjectsSettlementOwnerChangedMapNotification(object o, List<object> collectedObjects)
	{
		((SettlementOwnerChangedMapNotification)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		base.AutoGeneratedInstanceCollectObjects(collectedObjects);
		collectedObjects.Add(PreviousOwner);
		collectedObjects.Add(NewOwner);
		collectedObjects.Add(Settlement);
	}

	internal static object AutoGeneratedGetMemberValuePreviousOwner(object o)
	{
		return ((SettlementOwnerChangedMapNotification)o).PreviousOwner;
	}

	internal static object AutoGeneratedGetMemberValueNewOwner(object o)
	{
		return ((SettlementOwnerChangedMapNotification)o).NewOwner;
	}

	internal static object AutoGeneratedGetMemberValueSettlement(object o)
	{
		return ((SettlementOwnerChangedMapNotification)o).Settlement;
	}

	public SettlementOwnerChangedMapNotification(Settlement settlement, Hero newOwner, Hero previousOwner, TextObject descriptionText)
		: base(descriptionText)
	{
		PreviousOwner = previousOwner;
		NewOwner = newOwner;
		Settlement = settlement;
	}
}
