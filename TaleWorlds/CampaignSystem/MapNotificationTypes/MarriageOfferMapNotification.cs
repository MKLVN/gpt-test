using System.Collections.Generic;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.MapNotificationTypes;

public class MarriageOfferMapNotification : InformationData
{
	public override TextObject TitleText => new TextObject("{=1OQubYTT}Marriage Offer");

	public override string SoundEventPath => "event:/ui/notification/marriage";

	[SaveableProperty(1)]
	public Hero Suitor { get; private set; }

	[SaveableProperty(2)]
	public Hero Maiden { get; private set; }

	internal static void AutoGeneratedStaticCollectObjectsMarriageOfferMapNotification(object o, List<object> collectedObjects)
	{
		((MarriageOfferMapNotification)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		base.AutoGeneratedInstanceCollectObjects(collectedObjects);
		collectedObjects.Add(Suitor);
		collectedObjects.Add(Maiden);
	}

	internal static object AutoGeneratedGetMemberValueSuitor(object o)
	{
		return ((MarriageOfferMapNotification)o).Suitor;
	}

	internal static object AutoGeneratedGetMemberValueMaiden(object o)
	{
		return ((MarriageOfferMapNotification)o).Maiden;
	}

	public MarriageOfferMapNotification(Hero firstHero, Hero secondHero, TextObject descriptionText)
		: base(descriptionText)
	{
		Suitor = (firstHero.IsFemale ? secondHero : firstHero);
		Maiden = (firstHero.IsFemale ? firstHero : secondHero);
	}

	public override bool IsValid()
	{
		bool flag = Campaign.Current.Models.MarriageModel.IsCoupleSuitableForMarriage(Suitor, Maiden);
		if (flag && MBSaveLoad.IsUpdatingGameVersion && MBSaveLoad.LastLoadedGameVersion < ApplicationVersion.FromString("v1.2.0"))
		{
			flag = Campaign.Current.CampaignBehaviorManager.GetBehavior<MarriageOfferCampaignBehavior>()?.IsThereActiveMarriageOffer ?? false;
		}
		if (!flag)
		{
			CampaignEventDispatcher.Instance.OnMarriageOfferCanceled(Suitor, Maiden);
		}
		return flag;
	}
}
