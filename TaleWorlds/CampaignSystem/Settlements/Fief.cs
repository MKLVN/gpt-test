using System.Collections.Generic;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Party.PartyComponents;
using TaleWorlds.Library;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.Settlements;

public abstract class Fief : SettlementComponent
{
	[CachedData]
	public GarrisonPartyComponent GarrisonPartyComponent;

	[SaveableProperty(100)]
	public float FoodStocks { get; set; }

	public float Militia => base.Owner.Settlement.Militia;

	public MobileParty GarrisonParty => GarrisonPartyComponent?.MobileParty;

	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		base.AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	internal static object AutoGeneratedGetMemberValueFoodStocks(object o)
	{
		return ((Fief)o).FoodStocks;
	}
}
