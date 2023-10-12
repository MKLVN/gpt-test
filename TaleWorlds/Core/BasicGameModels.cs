using System.Collections.Generic;

namespace TaleWorlds.Core;

public class BasicGameModels : GameModelsManager
{
	public RidingModel RidingModel { get; private set; }

	public StrikeMagnitudeCalculationModel StrikeMagnitudeModel { get; private set; }

	public BattleSurvivalModel BattleSurvivalModel { get; private set; }

	public ItemCategorySelector ItemCategorySelector { get; private set; }

	public ItemValueModel ItemValueModel { get; private set; }

	public BasicGameModels(IEnumerable<GameModel> inputComponents)
		: base(inputComponents)
	{
		StrikeMagnitudeModel = GetGameModel<StrikeMagnitudeCalculationModel>();
		RidingModel = GetGameModel<RidingModel>();
		ItemCategorySelector = GetGameModel<ItemCategorySelector>();
		ItemValueModel = GetGameModel<ItemValueModel>();
	}
}
