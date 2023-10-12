using System.Collections.Generic;
using Helpers;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Buildings;
using TaleWorlds.CampaignSystem.Settlements.Workshops;
using TaleWorlds.CampaignSystem.ViewModelCollection.Input;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.GameMenu.TownManagement;

public class TownManagementVM : ViewModel
{
	private ITeleportationCampaignBehavior _teleportationBehavior;

	private InputKeyItemVM _doneInputKey;

	private bool _isThereCurrentProject;

	private bool _isSelectingGovernor;

	private SettlementProjectSelectionVM _projectSelection;

	private SettlementGovernorSelectionVM _governorSelection;

	private TownManagementReserveControlVM _reserveControl;

	private MBBindingList<TownManagementDescriptionItemVM> _middleLeftTextList;

	private MBBindingList<TownManagementDescriptionItemVM> _middleRightTextList;

	private MBBindingList<TownManagementShopItemVM> _shops;

	private MBBindingList<TownManagementVillageItemVM> _villages;

	private HintViewModel _governorSelectionDisabledHint;

	private bool _show;

	private bool _isTown;

	private bool _hasGovernor;

	private bool _isGovernorSelectionEnabled;

	private string _titleText;

	private bool _isCurrentProjectDaily;

	private int _currentProjectProgress;

	private string _currentProjectText;

	private HeroVM _currentGovernor;

	private string _manageText;

	private string _doneText;

	private string _wallsText;

	private string _completionText;

	private string _villagesText;

	private string _shopsInSettlementText;

	private BasicTooltipViewModel _consumptionTooltip;

	private string _governorText;

	[DataSourceProperty]
	public InputKeyItemVM DoneInputKey
	{
		get
		{
			return _doneInputKey;
		}
		set
		{
			if (value != _doneInputKey)
			{
				_doneInputKey = value;
				OnPropertyChangedWithValue(value, "DoneInputKey");
			}
		}
	}

	[DataSourceProperty]
	public string CompletionText
	{
		get
		{
			return _completionText;
		}
		set
		{
			if (value != _completionText)
			{
				_completionText = value;
				OnPropertyChangedWithValue(value, "CompletionText");
			}
		}
	}

	[DataSourceProperty]
	public string GovernorText
	{
		get
		{
			return _governorText;
		}
		set
		{
			if (value != _governorText)
			{
				_governorText = value;
				OnPropertyChangedWithValue(value, "GovernorText");
			}
		}
	}

	[DataSourceProperty]
	public string ManageText
	{
		get
		{
			return _manageText;
		}
		set
		{
			if (value != _manageText)
			{
				_manageText = value;
				OnPropertyChangedWithValue(value, "ManageText");
			}
		}
	}

	[DataSourceProperty]
	public string DoneText
	{
		get
		{
			return _doneText;
		}
		set
		{
			if (value != _doneText)
			{
				_doneText = value;
				OnPropertyChangedWithValue(value, "DoneText");
			}
		}
	}

	[DataSourceProperty]
	public string WallsText
	{
		get
		{
			return _wallsText;
		}
		set
		{
			if (value != _wallsText)
			{
				_wallsText = value;
				OnPropertyChangedWithValue(value, "WallsText");
			}
		}
	}

	[DataSourceProperty]
	public string CurrentProjectText
	{
		get
		{
			return _currentProjectText;
		}
		set
		{
			if (value != _currentProjectText)
			{
				_currentProjectText = value;
				OnPropertyChangedWithValue(value, "CurrentProjectText");
			}
		}
	}

	[DataSourceProperty]
	public string TitleText
	{
		get
		{
			return _titleText;
		}
		set
		{
			if (value != _titleText)
			{
				_titleText = value;
				OnPropertyChangedWithValue(value, "TitleText");
			}
		}
	}

	[DataSourceProperty]
	public bool HasGovernor
	{
		get
		{
			return _hasGovernor;
		}
		set
		{
			if (value != _hasGovernor)
			{
				_hasGovernor = value;
				OnPropertyChangedWithValue(value, "HasGovernor");
			}
		}
	}

	[DataSourceProperty]
	public bool IsGovernorSelectionEnabled
	{
		get
		{
			return _isGovernorSelectionEnabled;
		}
		set
		{
			if (value != _isGovernorSelectionEnabled)
			{
				_isGovernorSelectionEnabled = value;
				OnPropertyChangedWithValue(value, "IsGovernorSelectionEnabled");
			}
		}
	}

	[DataSourceProperty]
	public bool IsTown
	{
		get
		{
			return _isTown;
		}
		set
		{
			if (value != _isTown)
			{
				_isTown = value;
				OnPropertyChangedWithValue(value, "IsTown");
			}
		}
	}

	[DataSourceProperty]
	public bool Show
	{
		get
		{
			return _show;
		}
		set
		{
			if (value != _show)
			{
				_show = value;
				OnPropertyChangedWithValue(value, "Show");
			}
		}
	}

	[DataSourceProperty]
	public bool IsThereCurrentProject
	{
		get
		{
			return _isThereCurrentProject;
		}
		set
		{
			if (value != _isThereCurrentProject)
			{
				_isThereCurrentProject = value;
				OnPropertyChangedWithValue(value, "IsThereCurrentProject");
			}
		}
	}

	[DataSourceProperty]
	public bool IsSelectingGovernor
	{
		get
		{
			return _isSelectingGovernor;
		}
		set
		{
			if (value != _isSelectingGovernor)
			{
				_isSelectingGovernor = value;
				OnPropertyChangedWithValue(value, "IsSelectingGovernor");
			}
		}
	}

	[DataSourceProperty]
	public MBBindingList<TownManagementDescriptionItemVM> MiddleFirstTextList
	{
		get
		{
			return _middleLeftTextList;
		}
		set
		{
			if (value != _middleLeftTextList)
			{
				_middleLeftTextList = value;
				OnPropertyChanged("MiddleLeftTextList");
			}
		}
	}

	[DataSourceProperty]
	public MBBindingList<TownManagementDescriptionItemVM> MiddleSecondTextList
	{
		get
		{
			return _middleRightTextList;
		}
		set
		{
			if (value != _middleRightTextList)
			{
				_middleRightTextList = value;
				OnPropertyChanged("MiddleRightTextList");
			}
		}
	}

	[DataSourceProperty]
	public MBBindingList<TownManagementShopItemVM> Shops
	{
		get
		{
			return _shops;
		}
		set
		{
			if (value != _shops)
			{
				_shops = value;
				OnPropertyChangedWithValue(value, "Shops");
			}
		}
	}

	[DataSourceProperty]
	public MBBindingList<TownManagementVillageItemVM> Villages
	{
		get
		{
			return _villages;
		}
		set
		{
			if (value != _villages)
			{
				_villages = value;
				OnPropertyChangedWithValue(value, "Villages");
			}
		}
	}

	[DataSourceProperty]
	public HintViewModel GovernorSelectionDisabledHint
	{
		get
		{
			return _governorSelectionDisabledHint;
		}
		set
		{
			if (value != _governorSelectionDisabledHint)
			{
				_governorSelectionDisabledHint = value;
				OnPropertyChangedWithValue(value, "GovernorSelectionDisabledHint");
			}
		}
	}

	[DataSourceProperty]
	public string VillagesText
	{
		get
		{
			return _villagesText;
		}
		set
		{
			if (value != _villagesText)
			{
				_villagesText = value;
				OnPropertyChangedWithValue(value, "VillagesText");
			}
		}
	}

	[DataSourceProperty]
	public string ShopsInSettlementText
	{
		get
		{
			return _shopsInSettlementText;
		}
		set
		{
			if (value != _shopsInSettlementText)
			{
				_shopsInSettlementText = value;
				OnPropertyChangedWithValue(value, "ShopsInSettlementText");
			}
		}
	}

	[DataSourceProperty]
	public bool IsCurrentProjectDaily
	{
		get
		{
			return _isCurrentProjectDaily;
		}
		set
		{
			if (value != _isCurrentProjectDaily)
			{
				_isCurrentProjectDaily = value;
				OnPropertyChangedWithValue(value, "IsCurrentProjectDaily");
			}
		}
	}

	[DataSourceProperty]
	public int CurrentProjectProgress
	{
		get
		{
			return _currentProjectProgress;
		}
		set
		{
			if (value != _currentProjectProgress)
			{
				_currentProjectProgress = value;
				OnPropertyChangedWithValue(value, "CurrentProjectProgress");
			}
		}
	}

	[DataSourceProperty]
	public SettlementProjectSelectionVM ProjectSelection
	{
		get
		{
			return _projectSelection;
		}
		set
		{
			if (value != _projectSelection)
			{
				_projectSelection = value;
				OnPropertyChangedWithValue(value, "ProjectSelection");
			}
		}
	}

	[DataSourceProperty]
	public SettlementGovernorSelectionVM GovernorSelection
	{
		get
		{
			return _governorSelection;
		}
		set
		{
			if (value != _governorSelection)
			{
				_governorSelection = value;
				OnPropertyChangedWithValue(value, "GovernorSelection");
			}
		}
	}

	[DataSourceProperty]
	public TownManagementReserveControlVM ReserveControl
	{
		get
		{
			return _reserveControl;
		}
		set
		{
			if (value != _reserveControl)
			{
				_reserveControl = value;
				OnPropertyChangedWithValue(value, "ReserveControl");
			}
		}
	}

	[DataSourceProperty]
	public HeroVM CurrentGovernor
	{
		get
		{
			return _currentGovernor;
		}
		set
		{
			if (value != _currentGovernor)
			{
				_currentGovernor = value;
				OnPropertyChangedWithValue(value, "CurrentGovernor");
			}
		}
	}

	[DataSourceProperty]
	public BasicTooltipViewModel ConsumptionTooltip
	{
		get
		{
			return _consumptionTooltip;
		}
		set
		{
			if (value != _consumptionTooltip)
			{
				_consumptionTooltip = value;
				OnPropertyChangedWithValue(value, "ConsumptionTooltip");
			}
		}
	}

	public TownManagementVM()
	{
		_teleportationBehavior = Campaign.Current.GetCampaignBehavior<ITeleportationCampaignBehavior>();
		ProjectSelection = new SettlementProjectSelectionVM(Settlement.CurrentSettlement, OnChangeInBuildingQueue);
		GovernorSelection = new SettlementGovernorSelectionVM(Settlement.CurrentSettlement, OnGovernorSelectionDone);
		ReserveControl = new TownManagementReserveControlVM(Settlement.CurrentSettlement, OnReserveUpdated);
		MiddleFirstTextList = new MBBindingList<TownManagementDescriptionItemVM>();
		MiddleSecondTextList = new MBBindingList<TownManagementDescriptionItemVM>();
		Shops = new MBBindingList<TownManagementShopItemVM>();
		Villages = new MBBindingList<TownManagementVillageItemVM>();
		Show = false;
		IsTown = Settlement.CurrentSettlement?.IsTown ?? false;
		Settlement currentSettlement = Settlement.CurrentSettlement;
		if (currentSettlement == null || !currentSettlement.IsFortification)
		{
			return;
		}
		IsThereCurrentProject = Settlement.CurrentSettlement.Town.CurrentBuilding != null;
		CurrentGovernor = new HeroVM(Settlement.CurrentSettlement.Town.Governor ?? CampaignUIHelper.GetTeleportingGovernor(Settlement.CurrentSettlement, _teleportationBehavior), useCivilian: true);
		UpdateGovernorSelectionProperties();
		RefreshCurrentDevelopment();
		RefreshTownManagementStats();
		if (Settlement.CurrentSettlement.Town != null)
		{
			Workshop[] workshops = Settlement.CurrentSettlement.Town.Workshops;
			foreach (Workshop workshop in workshops)
			{
				WorkshopType workshopType = workshop.WorkshopType;
				if (workshopType != null && !workshopType.IsHidden)
				{
					Shops.Add(new TownManagementShopItemVM(workshop));
				}
			}
		}
		foreach (Village boundVillage in Settlement.CurrentSettlement.BoundVillages)
		{
			Villages.Add(new TownManagementVillageItemVM(boundVillage));
		}
		ConsumptionTooltip = new BasicTooltipViewModel(() => CampaignUIHelper.GetSettlementConsumptionTooltip(Settlement.CurrentSettlement));
		RefreshValues();
	}

	public override void RefreshValues()
	{
		base.RefreshValues();
		CurrentProjectText = new TextObject("{=qBq70qDq}Current Project").ToString();
		CompletionText = new TextObject("{=Rkh2k1OA}Completion:").ToString();
		ManageText = new TextObject("{=XseYJYka}Manage").ToString();
		DoneText = new TextObject("{=WiNRdfsm}Done").ToString();
		WallsText = new TextObject("{=LsZEdD2z}Walls").ToString();
		VillagesText = GameTexts.FindText("str_bound_village").ToString();
		ShopsInSettlementText = GameTexts.FindText("str_shops_in_settlement").ToString();
		GovernorText = GameTexts.FindText("str_sort_by_governor_label").ToString();
		MiddleFirstTextList.ApplyActionOnAllItems(delegate(TownManagementDescriptionItemVM x)
		{
			x.RefreshValues();
		});
		MiddleSecondTextList.ApplyActionOnAllItems(delegate(TownManagementDescriptionItemVM x)
		{
			x.RefreshValues();
		});
		ProjectSelection.RefreshValues();
		GovernorSelection.RefreshValues();
		ReserveControl.RefreshValues();
		Shops.ApplyActionOnAllItems(delegate(TownManagementShopItemVM x)
		{
			x.RefreshValues();
		});
		Villages.ApplyActionOnAllItems(delegate(TownManagementVillageItemVM x)
		{
			x.RefreshValues();
		});
		CurrentGovernor.RefreshValues();
	}

	private void RefreshTownManagementStats()
	{
		MiddleFirstTextList.Clear();
		MiddleSecondTextList.Clear();
		ExplainedNumber taxExplanation = Campaign.Current.Models.SettlementTaxModel.CalculateTownTax(Settlement.CurrentSettlement.Town, includeDescriptions: true);
		int taxValue = (int)taxExplanation.ResultNumber;
		BasicTooltipViewModel hint = new BasicTooltipViewModel(() => CampaignUIHelper.GetTooltipForAccumulatingPropertyWithResult(GameTexts.FindText("str_town_management_population_tax").ToString(), taxValue, ref taxExplanation));
		GameTexts.SetVariable("LEFT", GameTexts.FindText("str_town_management_population_tax"));
		MiddleFirstTextList.Add(new TownManagementDescriptionItemVM(GameTexts.FindText("str_LEFT_colon"), taxValue, 0, TownManagementDescriptionItemVM.DescriptionType.Gold, hint));
		BasicTooltipViewModel hint2 = new BasicTooltipViewModel(() => CampaignUIHelper.GetTownProsperityTooltip(Settlement.CurrentSettlement.Town));
		MiddleFirstTextList.Add(new TownManagementDescriptionItemVM(GameTexts.FindText("str_town_management_prosperity"), (int)Settlement.CurrentSettlement.Town.Prosperity, (int)Campaign.Current.Models.SettlementProsperityModel.CalculateProsperityChange(Settlement.CurrentSettlement.Town).ResultNumber, TownManagementDescriptionItemVM.DescriptionType.Prosperity, hint2));
		BasicTooltipViewModel hint3 = new BasicTooltipViewModel(() => CampaignUIHelper.GetTownDailyProductionTooltip(Settlement.CurrentSettlement.Town));
		MiddleFirstTextList.Add(new TownManagementDescriptionItemVM(GameTexts.FindText("str_town_management_daily_production"), (int)Campaign.Current.Models.BuildingConstructionModel.CalculateDailyConstructionPower(Settlement.CurrentSettlement.Town).ResultNumber, 0, TownManagementDescriptionItemVM.DescriptionType.Production, hint3));
		BasicTooltipViewModel hint4 = new BasicTooltipViewModel(() => CampaignUIHelper.GetTownSecurityTooltip(Settlement.CurrentSettlement.Town));
		MiddleFirstTextList.Add(new TownManagementDescriptionItemVM(GameTexts.FindText("str_town_management_security"), (int)Settlement.CurrentSettlement.Town.Security, (int)Campaign.Current.Models.SettlementSecurityModel.CalculateSecurityChange(Settlement.CurrentSettlement.Town).ResultNumber, TownManagementDescriptionItemVM.DescriptionType.Security, hint4));
		BasicTooltipViewModel hint5 = new BasicTooltipViewModel(() => CampaignUIHelper.GetTownLoyaltyTooltip(Settlement.CurrentSettlement.Town));
		MiddleSecondTextList.Add(new TownManagementDescriptionItemVM(GameTexts.FindText("str_town_management_loyalty"), (int)Settlement.CurrentSettlement.Town.Loyalty, (int)Campaign.Current.Models.SettlementLoyaltyModel.CalculateLoyaltyChange(Settlement.CurrentSettlement.Town).ResultNumber, TownManagementDescriptionItemVM.DescriptionType.Loyalty, hint5));
		BasicTooltipViewModel hint6 = new BasicTooltipViewModel(() => CampaignUIHelper.GetTownFoodTooltip(Settlement.CurrentSettlement.Town));
		MiddleSecondTextList.Add(new TownManagementDescriptionItemVM(GameTexts.FindText("str_town_management_food"), (int)Settlement.CurrentSettlement.Town.FoodStocks, (int)Campaign.Current.Models.SettlementFoodModel.CalculateTownFoodStocksChange(Settlement.CurrentSettlement.Town).ResultNumber, TownManagementDescriptionItemVM.DescriptionType.Food, hint6));
		BasicTooltipViewModel hint7 = new BasicTooltipViewModel(() => CampaignUIHelper.GetTownMilitiaTooltip(Settlement.CurrentSettlement.Town));
		MiddleSecondTextList.Add(new TownManagementDescriptionItemVM(GameTexts.FindText("str_town_management_militia"), (int)Settlement.CurrentSettlement.Militia, (int)Campaign.Current.Models.SettlementMilitiaModel.CalculateMilitiaChange(Settlement.CurrentSettlement).ResultNumber, TownManagementDescriptionItemVM.DescriptionType.Militia, hint7));
		BasicTooltipViewModel hint8 = new BasicTooltipViewModel(() => CampaignUIHelper.GetTownGarrisonTooltip(Settlement.CurrentSettlement.Town));
		MiddleSecondTextList.Add(new TownManagementDescriptionItemVM(GameTexts.FindText("str_town_management_garrison"), Settlement.CurrentSettlement.Town.GarrisonParty?.Party.NumberOfAllMembers ?? 0, (int)Campaign.Current.Models.SettlementGarrisonModel.CalculateGarrisonChange(Settlement.CurrentSettlement).ResultNumber, TownManagementDescriptionItemVM.DescriptionType.Garrison, hint8));
	}

	private void OnChangeInBuildingQueue()
	{
		OnProjectSelectionDone();
		RefreshTownManagementStats();
	}

	private void RefreshCurrentDevelopment()
	{
		if (Settlement.CurrentSettlement.Town.CurrentBuilding != null)
		{
			IsCurrentProjectDaily = Settlement.CurrentSettlement.Town.CurrentBuilding.BuildingType.IsDefaultProject;
			if (!IsCurrentProjectDaily)
			{
				CurrentProjectProgress = (int)(BuildingHelper.GetProgressOfBuilding(ProjectSelection.CurrentSelectedProject.Building, Settlement.CurrentSettlement.Town) * 100f);
				ProjectSelection.CurrentSelectedProject.RefreshProductionText();
			}
		}
	}

	private void OnProjectSelectionDone()
	{
		List<Building> localDevelopmentList = ProjectSelection.LocalDevelopmentList;
		Building building = ProjectSelection.CurrentDailyDefault.Building;
		if (localDevelopmentList != null)
		{
			BuildingHelper.ChangeCurrentBuildingQueue(localDevelopmentList, Settlement.CurrentSettlement.Town);
		}
		if (building != Settlement.CurrentSettlement.Town.CurrentDefaultBuilding)
		{
			BuildingHelper.ChangeDefaultBuilding(building, Settlement.CurrentSettlement.Town);
		}
		RefreshCurrentDevelopment();
	}

	private void OnGovernorSelectionDone(Hero selectedGovernor)
	{
		if (selectedGovernor != CurrentGovernor.Hero && Settlement.CurrentSettlement?.Town != null)
		{
			CurrentGovernor = new HeroVM(selectedGovernor, useCivilian: true);
			if (CurrentGovernor.Hero != null)
			{
				ChangeGovernorAction.Apply(Settlement.CurrentSettlement.Town, CurrentGovernor.Hero);
			}
			else
			{
				ChangeGovernorAction.RemoveGovernorOfIfExists(Settlement.CurrentSettlement.Town);
			}
		}
		UpdateGovernorSelectionProperties();
		RefreshTownManagementStats();
	}

	private void UpdateGovernorSelectionProperties()
	{
		HasGovernor = CurrentGovernor.Hero != null;
		IsGovernorSelectionEnabled = GetCanChangeGovernor(out var disabledReason);
		GovernorSelectionDisabledHint = new HintViewModel(disabledReason);
	}

	private bool GetCanChangeGovernor(out TextObject disabledReason)
	{
		HeroVM currentGovernor = CurrentGovernor;
		if (currentGovernor != null && currentGovernor.Hero?.IsTraveling == true)
		{
			disabledReason = new TextObject("{=qbqimqMb}{GOVERNOR.NAME} is on the way to be the new governor of {SETTLEMENT_NAME}");
			if (CurrentGovernor.Hero.CharacterObject != null)
			{
				StringHelpers.SetCharacterProperties("GOVERNOR", CurrentGovernor.Hero.CharacterObject, disabledReason);
			}
			disabledReason.SetTextVariable("SETTLEMENT_NAME", Settlement.CurrentSettlement.Name?.ToString() ?? string.Empty);
			return false;
		}
		disabledReason = TextObject.Empty;
		return true;
	}

	private void OnReserveUpdated()
	{
		RefreshCurrentDevelopment();
		RefreshTownManagementStats();
	}

	public void ExecuteDone()
	{
		OnProjectSelectionDone();
		Show = false;
	}

	public override void OnFinalize()
	{
		base.OnFinalize();
		DoneInputKey.OnFinalize();
	}

	public void SetDoneInputKey(HotKey hotKey)
	{
		DoneInputKey = InputKeyItemVM.CreateFromHotKey(hotKey, isConsoleOnly: true);
	}
}
