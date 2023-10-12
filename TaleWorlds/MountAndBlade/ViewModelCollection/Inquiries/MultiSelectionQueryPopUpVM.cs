using System;
using System.Collections.Generic;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.Inquiries;

public class MultiSelectionQueryPopUpVM : PopUpBaseVM
{
	private MultiSelectionInquiryData _data;

	private int _selectedOptionCount;

	private MBBindingList<InquiryElementVM> _inquiryElements;

	private int _maxSelectableOptionCount;

	private int _minSelectableOptionCount;

	[DataSourceProperty]
	public MBBindingList<InquiryElementVM> InquiryElements
	{
		get
		{
			return _inquiryElements;
		}
		set
		{
			if (value != _inquiryElements)
			{
				_inquiryElements = value;
				OnPropertyChangedWithValue(value, "InquiryElements");
			}
		}
	}

	[DataSourceProperty]
	public int MaxSelectableOptionCount
	{
		get
		{
			return _maxSelectableOptionCount;
		}
		set
		{
			if (value != _maxSelectableOptionCount)
			{
				_maxSelectableOptionCount = value;
				OnPropertyChangedWithValue(value, "MaxSelectableOptionCount");
			}
		}
	}

	[DataSourceProperty]
	public int MinSelectableOptionCount
	{
		get
		{
			return _minSelectableOptionCount;
		}
		set
		{
			if (value != _minSelectableOptionCount)
			{
				_minSelectableOptionCount = value;
				OnPropertyChangedWithValue(value, "MinSelectableOptionCount");
			}
		}
	}

	public MultiSelectionQueryPopUpVM(Action closeQuery)
		: base(closeQuery)
	{
		InquiryElements = new MBBindingList<InquiryElementVM>();
		MaxSelectableOptionCount = 0;
		MinSelectableOptionCount = 0;
		_selectedOptionCount = 0;
	}

	public void SetData(MultiSelectionInquiryData data)
	{
		_data = data;
		InquiryElements.Clear();
		foreach (InquiryElement inquiryElement in _data.InquiryElements)
		{
			TextObject hint = (string.IsNullOrEmpty(inquiryElement.Hint) ? TextObject.Empty : new TextObject("{=!}" + inquiryElement.Hint));
			InquiryElements.Add(new InquiryElementVM(inquiryElement, hint, OnInquiryElementSelected));
		}
		base.TitleText = _data.TitleText;
		base.PopUpLabel = _data.DescriptionText;
		MaxSelectableOptionCount = _data.MaxSelectableOptionCount;
		MinSelectableOptionCount = _data.MinSelectableOptionCount;
		base.ButtonOkLabel = _data.AffirmativeText;
		base.ButtonCancelLabel = _data.NegativeText;
		base.IsButtonOkShown = true;
		base.IsButtonCancelShown = _data.IsExitShown;
		RefreshIsButtonOkEnabled();
	}

	private void OnInquiryElementSelected(InquiryElementVM elementVM, bool isSelected)
	{
		if (isSelected)
		{
			_selectedOptionCount++;
			if (MaxSelectableOptionCount == 1)
			{
				foreach (InquiryElementVM inquiryElement in InquiryElements)
				{
					if (inquiryElement != elementVM)
					{
						inquiryElement.IsSelected = false;
					}
				}
			}
		}
		else
		{
			_selectedOptionCount--;
		}
		RefreshIsButtonOkEnabled();
	}

	public override void ExecuteAffirmativeAction()
	{
		if (_data.AffirmativeAction != null)
		{
			List<InquiryElement> list = new List<InquiryElement>();
			foreach (InquiryElementVM inquiryElement in InquiryElements)
			{
				if (inquiryElement.IsSelected)
				{
					list.Add(inquiryElement.InquiryElement);
				}
			}
			_data.AffirmativeAction(list);
		}
		CloseQuery();
	}

	public override void ExecuteNegativeAction()
	{
		_data.NegativeAction?.Invoke(new List<InquiryElement>());
		CloseQuery();
	}

	public override void OnClearData()
	{
		base.OnClearData();
		_data = null;
		MaxSelectableOptionCount = 0;
		MinSelectableOptionCount = 0;
		_selectedOptionCount = 0;
	}

	private void RefreshIsButtonOkEnabled()
	{
		base.IsButtonOkEnabled = (MaxSelectableOptionCount <= 0 || _selectedOptionCount <= MaxSelectableOptionCount) && _selectedOptionCount >= MinSelectableOptionCount;
	}
}
