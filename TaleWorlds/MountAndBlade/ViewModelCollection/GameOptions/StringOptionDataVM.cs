using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.Core.ViewModelCollection.Selector;
using TaleWorlds.Engine.Options;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.GameOptions;

public class StringOptionDataVM : GenericOptionDataVM
{
	private int _initialValue;

	private ISelectionOptionData _selectionOptionData;

	public SelectorVM<SelectorItemVM> _selector;

	[DataSourceProperty]
	public SelectorVM<SelectorItemVM> Selector
	{
		get
		{
			_ = _selector;
			return _selector;
		}
		set
		{
			if (value != _selector)
			{
				_selector = value;
				OnPropertyChangedWithValue(value, "Selector");
			}
		}
	}

	public StringOptionDataVM(OptionsVM optionsVM, ISelectionOptionData option, TextObject name, TextObject description)
		: base(optionsVM, option, name, description, OptionsVM.OptionsDataType.MultipleSelectionOption)
	{
		Selector = new SelectorVM<SelectorItemVM>(0, null);
		_selectionOptionData = option;
		UpdateData(initialUpdate: true);
		_initialValue = (int)Option.GetValue(forceRefresh: false);
		Selector.SelectedIndex = _initialValue;
	}

	public override void UpdateData(bool initialUpdate)
	{
		base.UpdateData(initialUpdate);
		IEnumerable<SelectionData> selectableOptionNames = _selectionOptionData.GetSelectableOptionNames();
		Selector.SetOnChangeAction(null);
		bool flag = (int)Option.GetValue(forceRefresh: true) != Selector.SelectedIndex;
		Action<SelectorVM<SelectorItemVM>> onChange = null;
		if (flag)
		{
			onChange = UpdateValue;
		}
		if (selectableOptionNames.Any() && selectableOptionNames.All((SelectionData n) => n.IsLocalizationId))
		{
			List<TextObject> list = new List<TextObject>();
			foreach (SelectionData item2 in selectableOptionNames)
			{
				TextObject item = Module.CurrentModule.GlobalTextManager.FindText(item2.Data);
				list.Add(item);
			}
			int num = (int)Option.GetValue(!initialUpdate);
			if (list.Count > 0 && num == -1)
			{
				num = 0;
			}
			Selector.Refresh(list, num, onChange);
		}
		else
		{
			List<string> list2 = new List<string>();
			foreach (SelectionData item3 in selectableOptionNames)
			{
				if (item3.IsLocalizationId)
				{
					TextObject textObject = Module.CurrentModule.GlobalTextManager.FindText(item3.Data);
					list2.Add(textObject.ToString());
				}
				else
				{
					list2.Add(item3.Data);
				}
			}
			int num2 = (int)Option.GetValue(!initialUpdate);
			if (list2.Count > 0 && num2 == -1)
			{
				num2 = 0;
			}
			Selector.Refresh(list2, num2, onChange);
		}
		if (!flag)
		{
			Selector.SetOnChangeAction(UpdateValue);
		}
	}

	public override void RefreshValues()
	{
		base.RefreshValues();
		Selector?.RefreshValues();
	}

	public void UpdateValue(SelectorVM<SelectorItemVM> selector)
	{
		if (selector.SelectedIndex >= 0)
		{
			Option.SetValue(selector.SelectedIndex);
			Option.Commit();
			_optionsVM.SetConfig(Option, selector.SelectedIndex);
		}
	}

	public override void UpdateValue()
	{
		if (Selector.SelectedIndex >= 0 && (float)Selector.SelectedIndex != Option.GetValue(forceRefresh: false))
		{
			Option.Commit();
			_optionsVM.SetConfig(Option, Selector.SelectedIndex);
		}
	}

	public override void Cancel()
	{
		Selector.SelectedIndex = _initialValue;
		UpdateValue();
	}

	public override void SetValue(float value)
	{
		Selector.SelectedIndex = (int)value;
	}

	public override void ResetData()
	{
		Selector.SelectedIndex = (int)Option.GetDefaultValue();
	}

	public override bool IsChanged()
	{
		return _initialValue != Selector.SelectedIndex;
	}

	public override void ApplyValue()
	{
		if (_initialValue != Selector.SelectedIndex)
		{
			_initialValue = Selector.SelectedIndex;
		}
	}
}
