using System.Collections.Generic;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.MapNotificationTypes;

public class WarMapNotification : InformationData
{
	public override TextObject TitleText => new TextObject("{=qR6HqHgo}Declaration of War");

	public override string SoundEventPath => "event:/ui/notification/war_declared";

	[SaveableProperty(1)]
	public IFaction FirstFaction { get; private set; }

	[SaveableProperty(2)]
	public IFaction SecondFaction { get; private set; }

	internal static void AutoGeneratedStaticCollectObjectsWarMapNotification(object o, List<object> collectedObjects)
	{
		((WarMapNotification)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		base.AutoGeneratedInstanceCollectObjects(collectedObjects);
		collectedObjects.Add(FirstFaction);
		collectedObjects.Add(SecondFaction);
	}

	internal static object AutoGeneratedGetMemberValueFirstFaction(object o)
	{
		return ((WarMapNotification)o).FirstFaction;
	}

	internal static object AutoGeneratedGetMemberValueSecondFaction(object o)
	{
		return ((WarMapNotification)o).SecondFaction;
	}

	public WarMapNotification(IFaction firstFaction, IFaction secondFaction, TextObject descriptionText)
		: base(descriptionText)
	{
		FirstFaction = firstFaction;
		SecondFaction = secondFaction;
	}
}
