using System.Collections.Generic;
using System.Linq;
using StoryMode.ViewModelCollection.Tutorial;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace StoryMode.GauntletUI.Tutorial;

public class OrderTutorialStep2 : TutorialItemBase
{
	private bool _hasPlayerOrderedCharge;

	private bool _registeredToOrderEvent;

	public OrderTutorialStep2()
	{
		base.Type = "OrderTutorial1TutorialStep2";
		base.Placement = TutorialItemVM.ItemPlacements.TopRight;
		base.HighlightedVisualElementID = "";
		base.MouseRequired = false;
	}

	public override bool IsConditionsMetForCompletion()
	{
		if (!_registeredToOrderEvent && Mission.Current?.PlayerTeam?.PlayerOrderController != null)
		{
			Mission current = Mission.Current;
			if (current != null && current.Mode == MissionMode.Battle)
			{
				Mission.Current.PlayerTeam.PlayerOrderController.OnOrderIssued += OnPlayerOrdered;
				_registeredToOrderEvent = true;
			}
		}
		return _hasPlayerOrderedCharge;
	}

	public override void OnDeactivate()
	{
		base.OnDeactivate();
		if (_registeredToOrderEvent && Mission.Current?.PlayerTeam?.PlayerOrderController != null)
		{
			Mission.Current.PlayerTeam.PlayerOrderController.OnOrderIssued -= OnPlayerOrdered;
		}
		_registeredToOrderEvent = false;
	}

	private void OnPlayerOrdered(OrderType orderType, IEnumerable<Formation> appliedFormations, params object[] delegateParams)
	{
		_hasPlayerOrderedCharge = _hasPlayerOrderedCharge || (orderType == OrderType.Charge && appliedFormations.Any());
	}

	public override TutorialContexts GetTutorialsRelevantContext()
	{
		return TutorialContexts.Mission;
	}

	public override bool IsConditionsMetForActivation()
	{
		if (TutorialHelper.CurrentContext == TutorialContexts.Mission && TutorialHelper.IsPlayerInABattleMission && Mission.Current.Mode != MissionMode.Deployment)
		{
			return TutorialHelper.IsOrderingAvailable;
		}
		return false;
	}
}
