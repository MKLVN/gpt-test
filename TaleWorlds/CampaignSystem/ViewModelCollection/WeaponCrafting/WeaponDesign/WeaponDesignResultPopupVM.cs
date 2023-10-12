using System;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.CraftingSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.Input;
using TaleWorlds.CampaignSystem.ViewModelCollection.Inventory;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting.WeaponDesign;

public class WeaponDesignResultPopupVM : ViewModel
{
	private Action _onFinalize;

	private Crafting _crafting;

	private CraftingOrder _completedOrder;

	private ItemObject _craftedItem;

	private readonly ICraftingCampaignBehavior _craftingBehavior;

	private MBBindingList<ItemFlagVM> _weaponFlagIconsList;

	private bool _isInOrderMode;

	private string _orderResultText;

	private string _orderOwnerRemarkText;

	private bool _isOrderSuccessful;

	private bool _canConfirm;

	private string _craftedWeaponWorthText;

	private int _craftedWeaponInitialWorth;

	private int _craftedWeaponPriceDifference;

	private int _craftedWeaponFinalWorth;

	private string _weaponCraftedText;

	private string _doneLbl;

	private MBBindingList<WeaponDesignResultPropertyItemVM> _designResultPropertyList;

	private string _itemName;

	private ItemCollectionElementViewModel _itemVisualModel;

	private HintViewModel _confirmDisabledReasonHint;

	private InputKeyItemVM _doneInputKey;

	[DataSourceProperty]
	public MBBindingList<ItemFlagVM> WeaponFlagIconsList
	{
		get
		{
			return _weaponFlagIconsList;
		}
		set
		{
			if (value != _weaponFlagIconsList)
			{
				_weaponFlagIconsList = value;
				OnPropertyChangedWithValue(value, "WeaponFlagIconsList");
			}
		}
	}

	[DataSourceProperty]
	public bool IsInOrderMode
	{
		get
		{
			return _isInOrderMode;
		}
		set
		{
			if (value != _isInOrderMode)
			{
				_isInOrderMode = value;
				OnPropertyChangedWithValue(value, "IsInOrderMode");
			}
		}
	}

	[DataSourceProperty]
	public int CraftedWeaponFinalWorth
	{
		get
		{
			return _craftedWeaponFinalWorth;
		}
		set
		{
			if (value != _craftedWeaponFinalWorth)
			{
				_craftedWeaponFinalWorth = value;
				OnPropertyChangedWithValue(value, "CraftedWeaponFinalWorth");
			}
		}
	}

	[DataSourceProperty]
	public int CraftedWeaponPriceDifference
	{
		get
		{
			return _craftedWeaponPriceDifference;
		}
		set
		{
			if (value != _craftedWeaponPriceDifference)
			{
				_craftedWeaponPriceDifference = value;
				OnPropertyChangedWithValue(value, "CraftedWeaponPriceDifference");
			}
		}
	}

	[DataSourceProperty]
	public int CraftedWeaponInitialWorth
	{
		get
		{
			return _craftedWeaponInitialWorth;
		}
		set
		{
			if (value != _craftedWeaponInitialWorth)
			{
				_craftedWeaponInitialWorth = value;
				OnPropertyChangedWithValue(value, "CraftedWeaponInitialWorth");
			}
		}
	}

	[DataSourceProperty]
	public string CraftedWeaponWorthText
	{
		get
		{
			return _craftedWeaponWorthText;
		}
		set
		{
			if (value != _craftedWeaponWorthText)
			{
				_craftedWeaponWorthText = value;
				OnPropertyChangedWithValue(value, "CraftedWeaponWorthText");
			}
		}
	}

	[DataSourceProperty]
	public bool IsOrderSuccessful
	{
		get
		{
			return _isOrderSuccessful;
		}
		set
		{
			if (value != _isOrderSuccessful)
			{
				_isOrderSuccessful = value;
				OnPropertyChangedWithValue(value, "IsOrderSuccessful");
			}
		}
	}

	[DataSourceProperty]
	public bool CanConfirm
	{
		get
		{
			return _canConfirm;
		}
		set
		{
			if (value != _canConfirm)
			{
				_canConfirm = value;
				OnPropertyChangedWithValue(value, "CanConfirm");
			}
		}
	}

	[DataSourceProperty]
	public string OrderResultText
	{
		get
		{
			return _orderResultText;
		}
		set
		{
			if (value != _orderResultText)
			{
				_orderResultText = value;
				OnPropertyChangedWithValue(value, "OrderResultText");
			}
		}
	}

	[DataSourceProperty]
	public string OrderOwnerRemarkText
	{
		get
		{
			return _orderOwnerRemarkText;
		}
		set
		{
			if (value != _orderOwnerRemarkText)
			{
				_orderOwnerRemarkText = value;
				OnPropertyChangedWithValue(value, "OrderOwnerRemarkText");
			}
		}
	}

	[DataSourceProperty]
	public string WeaponCraftedText
	{
		get
		{
			return _weaponCraftedText;
		}
		set
		{
			if (value != _weaponCraftedText)
			{
				_weaponCraftedText = value;
				OnPropertyChangedWithValue(value, "WeaponCraftedText");
			}
		}
	}

	[DataSourceProperty]
	public string DoneLbl
	{
		get
		{
			return _doneLbl;
		}
		set
		{
			if (value != _doneLbl)
			{
				_doneLbl = value;
				OnPropertyChangedWithValue(value, "DoneLbl");
			}
		}
	}

	[DataSourceProperty]
	public MBBindingList<WeaponDesignResultPropertyItemVM> DesignResultPropertyList
	{
		get
		{
			return _designResultPropertyList;
		}
		set
		{
			if (value != _designResultPropertyList)
			{
				_designResultPropertyList = value;
				OnPropertyChangedWithValue(value, "DesignResultPropertyList");
			}
		}
	}

	[DataSourceProperty]
	public string ItemName
	{
		get
		{
			return _itemName;
		}
		set
		{
			if (value != _itemName)
			{
				_itemName = value;
				UpdateConfirmAvailability();
				OnPropertyChangedWithValue(value, "ItemName");
			}
		}
	}

	[DataSourceProperty]
	public ItemCollectionElementViewModel ItemVisualModel
	{
		get
		{
			return _itemVisualModel;
		}
		set
		{
			if (value != _itemVisualModel)
			{
				_itemVisualModel = value;
				OnPropertyChangedWithValue(value, "ItemVisualModel");
			}
		}
	}

	[DataSourceProperty]
	public HintViewModel ConfirmDisabledReasonHint
	{
		get
		{
			return _confirmDisabledReasonHint;
		}
		set
		{
			if (value != _confirmDisabledReasonHint)
			{
				_confirmDisabledReasonHint = value;
				OnPropertyChangedWithValue(value, "ConfirmDisabledReasonHint");
			}
		}
	}

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

	public WeaponDesignResultPopupVM(Action onFinalize, Crafting crafting, CraftingOrder completedOrder, MBBindingList<ItemFlagVM> weaponFlagIconsList, ItemObject craftedItem, MBBindingList<WeaponDesignResultPropertyItemVM> designResultPropertyList, string itemName, ItemCollectionElementViewModel itemVisualModel)
	{
		_craftedItem = craftedItem;
		_onFinalize = onFinalize;
		_crafting = crafting;
		_completedOrder = completedOrder;
		_craftingBehavior = Campaign.Current.GetCampaignBehavior<ICraftingCampaignBehavior>();
		WeaponFlagIconsList = weaponFlagIconsList;
		DesignResultPropertyList = designResultPropertyList;
		ItemModifier currentItemModifier = _craftingBehavior.GetCurrentItemModifier();
		if (currentItemModifier != null)
		{
			TextObject textObject = currentItemModifier.Name.CopyTextObject();
			textObject.SetTextVariable("ITEMNAME", itemName);
			ItemName = textObject.ToString();
		}
		else
		{
			ItemName = itemName;
		}
		ItemVisualModel = itemVisualModel;
		Game.Current?.EventManager.TriggerEvent(new CraftingWeaponResultPopupToggledEvent(isOpen: true));
		RefreshValues();
	}

	public override void RefreshValues()
	{
		base.RefreshValues();
		IsInOrderMode = _completedOrder != null;
		WeaponCraftedText = new TextObject("{=0mqdFC2x}Weapon Crafted!").ToString();
		DoneLbl = GameTexts.FindText("str_done").ToString();
		if (_isInOrderMode)
		{
			_craftingBehavior.GetOrderResult(_completedOrder, _craftedItem, out var isSucceed, out var orderRemark, out var orderResult, out var finalPrice);
			CraftedWeaponInitialWorth = _completedOrder.BaseGoldReward;
			CraftedWeaponFinalWorth = finalPrice;
			IsOrderSuccessful = isSucceed;
			CraftedWeaponWorthText = new TextObject("{=ZIn8W5ZG}Worth").ToString();
			DesignResultPropertyList.Add(new WeaponDesignResultPropertyItemVM(new TextObject("{=QmfZjCo1}Worth: "), CraftedWeaponInitialWorth, CraftedWeaponInitialWorth, CraftedWeaponFinalWorth - CraftedWeaponInitialWorth, showFloatingPoint: false, isExceedingBeneficial: true, showTooltip: false));
			OrderOwnerRemarkText = orderRemark.ToString();
			OrderResultText = orderResult.ToString();
		}
	}

	private void UpdateConfirmAvailability()
	{
		Tuple<bool, TextObject> tuple = CampaignUIHelper.IsStringApplicableForItemName(ItemName);
		CanConfirm = tuple.Item1;
		ConfirmDisabledReasonHint = new HintViewModel(tuple.Item2);
	}

	public override void OnFinalize()
	{
		base.OnFinalize();
		DoneInputKey.OnFinalize();
	}

	public void ExecuteFinalizeCrafting()
	{
		_crafting.SetCraftedWeaponName(ItemName);
		_onFinalize?.Invoke();
		Game.Current?.EventManager.TriggerEvent(new CraftingWeaponResultPopupToggledEvent(isOpen: false));
	}

	public void ExecuteRandomCraftName()
	{
		ItemName = _crafting.GetRandomCraftName().ToString();
	}

	public void SetDoneInputKey(HotKey hotkey)
	{
		DoneInputKey = InputKeyItemVM.CreateFromHotKey(hotkey, isConsoleOnly: true);
	}
}
