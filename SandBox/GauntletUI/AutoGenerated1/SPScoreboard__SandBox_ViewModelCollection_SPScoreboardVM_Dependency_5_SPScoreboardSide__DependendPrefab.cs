using System.ComponentModel;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.GauntletUI.Data;
using TaleWorlds.GauntletUI.Layout;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.ViewModelCollection.Scoreboard;

namespace SandBox.GauntletUI.AutoGenerated1;

public class SPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_5_SPScoreboardSide__DependendPrefab : Widget
{
	private Widget _widget;

	private Widget _widget_0;

	private Widget _widget_0_0;

	private ListPanel _widget_0_0_0;

	private SPScoreboardSideVM _datasource_Root;

	private MBBindingList<SPScoreboardPartyVM> _datasource_Root_Parties;

	public SPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_5_SPScoreboardSide__DependendPrefab(UIContext context)
		: base(context)
	{
	}

	public void CreateWidgets()
	{
		_widget = this;
		_widget_0 = new Widget(base.Context);
		_widget.AddChild(_widget_0);
		_widget_0_0 = new Widget(base.Context);
		_widget_0.AddChild(_widget_0_0);
		_widget_0_0_0 = new ListPanel(base.Context);
		_widget_0_0.AddChild(_widget_0_0_0);
	}

	public void SetIds()
	{
	}

	public void SetAttributes()
	{
		base.WidthSizePolicy = SizePolicy.Fixed;
		base.HeightSizePolicy = SizePolicy.CoverChildren;
		base.SuggestedWidth = 630f;
		_widget_0.WidthSizePolicy = SizePolicy.StretchToParent;
		_widget_0.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0.VerticalAlignment = VerticalAlignment.Bottom;
		_widget_0_0.WidthSizePolicy = SizePolicy.StretchToParent;
		_widget_0_0.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0_0_0.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_0_0_0.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0_0_0.VerticalAlignment = VerticalAlignment.Top;
		_widget_0_0_0.StackLayout.LayoutMethod = LayoutMethod.VerticalBottomToTop;
	}

	public void DestroyDataSource()
	{
		if (_datasource_Root == null)
		{
			return;
		}
		_datasource_Root.PropertyChanged -= ViewModelPropertyChangedListenerOf_datasource_Root;
		_datasource_Root.PropertyChangedWithValue -= ViewModelPropertyChangedWithValueListenerOf_datasource_Root;
		_datasource_Root.PropertyChangedWithBoolValue -= ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root;
		_datasource_Root.PropertyChangedWithIntValue -= ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root;
		_datasource_Root.PropertyChangedWithFloatValue -= ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root;
		_datasource_Root.PropertyChangedWithUIntValue -= ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root;
		_datasource_Root.PropertyChangedWithColorValue -= ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root;
		_datasource_Root.PropertyChangedWithDoubleValue -= ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root;
		_datasource_Root.PropertyChangedWithVec2Value -= ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root;
		if (_datasource_Root_Parties != null)
		{
			_datasource_Root_Parties.ListChanged -= OnList_datasource_Root_PartiesChanged;
			for (int num = _widget_0_0_0.ChildCount - 1; num >= 0; num--)
			{
				Widget child = _widget_0_0_0.GetChild(num);
				((SPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate)child).OnBeforeRemovedChild(child);
				((SPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate)_widget_0_0_0.GetChild(num)).DestroyDataSource();
			}
			_datasource_Root_Parties = null;
		}
		_datasource_Root = null;
	}

	public void SetDataSource(SPScoreboardSideVM dataSource)
	{
		RefreshDataSource_datasource_Root(dataSource);
	}

	private void ViewModelPropertyChangedListenerOf_datasource_Root(object sender, PropertyChangedEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithValueListenerOf_datasource_Root(object sender, PropertyChangedWithValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root(object sender, PropertyChangedWithBoolValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root(object sender, PropertyChangedWithIntValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root(object sender, PropertyChangedWithFloatValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root(object sender, PropertyChangedWithUIntValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root(object sender, PropertyChangedWithColorValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root(object sender, PropertyChangedWithDoubleValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root(object sender, PropertyChangedWithVec2ValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root(e.PropertyName);
	}

	private void HandleViewModelPropertyChangeOf_datasource_Root(string propertyName)
	{
		if (propertyName == "Parties")
		{
			RefreshDataSource_datasource_Root_Parties(_datasource_Root.Parties);
		}
	}

	public void OnList_datasource_Root_PartiesChanged(object sender, TaleWorlds.Library.ListChangedEventArgs e)
	{
		switch (e.ListChangedType)
		{
		case TaleWorlds.Library.ListChangedType.Reset:
		{
			for (int num = _widget_0_0_0.ChildCount - 1; num >= 0; num--)
			{
				Widget child3 = _widget_0_0_0.GetChild(num);
				((SPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate)child3).OnBeforeRemovedChild(child3);
				Widget child4 = _widget_0_0_0.GetChild(num);
				((SPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate)child4).SetDataSource(null);
				_widget_0_0_0.RemoveChild(child4);
			}
			break;
		}
		case TaleWorlds.Library.ListChangedType.Sorted:
		{
			for (int i = 0; i < _datasource_Root_Parties.Count; i++)
			{
				SPScoreboardPartyVM bindingObject = _datasource_Root_Parties[i];
				_widget_0_0_0.FindChild((Widget widget) => widget.GetComponent<GeneratedWidgetData>().Data == bindingObject).SetSiblingIndex(i);
			}
			break;
		}
		case TaleWorlds.Library.ListChangedType.ItemAdded:
		{
			SPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate sPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate = new SPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate(base.Context);
			GeneratedWidgetData generatedWidgetData = new GeneratedWidgetData(sPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate);
			SPScoreboardPartyVM dataSource = (SPScoreboardPartyVM)(generatedWidgetData.Data = _datasource_Root_Parties[e.NewIndex]);
			sPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate.AddComponent(generatedWidgetData);
			_widget_0_0_0.AddChildAtIndex(sPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate, e.NewIndex);
			sPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate.CreateWidgets();
			sPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate.SetIds();
			sPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate.SetAttributes();
			sPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate.SetDataSource(dataSource);
			break;
		}
		case TaleWorlds.Library.ListChangedType.ItemBeforeDeleted:
		{
			Widget child2 = _widget_0_0_0.GetChild(e.NewIndex);
			((SPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate)child2).OnBeforeRemovedChild(child2);
			break;
		}
		case TaleWorlds.Library.ListChangedType.ItemDeleted:
		{
			Widget child = _widget_0_0_0.GetChild(e.NewIndex);
			((SPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate)child).SetDataSource(null);
			_widget_0_0_0.RemoveChild(child);
			break;
		}
		case TaleWorlds.Library.ListChangedType.ItemChanged:
			break;
		}
	}

	private void RefreshDataSource_datasource_Root(SPScoreboardSideVM newDataSource)
	{
		if (_datasource_Root != null)
		{
			_datasource_Root.PropertyChanged -= ViewModelPropertyChangedListenerOf_datasource_Root;
			_datasource_Root.PropertyChangedWithValue -= ViewModelPropertyChangedWithValueListenerOf_datasource_Root;
			_datasource_Root.PropertyChangedWithBoolValue -= ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root;
			_datasource_Root.PropertyChangedWithIntValue -= ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root;
			_datasource_Root.PropertyChangedWithFloatValue -= ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root;
			_datasource_Root.PropertyChangedWithUIntValue -= ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root;
			_datasource_Root.PropertyChangedWithColorValue -= ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root;
			_datasource_Root.PropertyChangedWithDoubleValue -= ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root;
			_datasource_Root.PropertyChangedWithVec2Value -= ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root;
			if (_datasource_Root_Parties != null)
			{
				_datasource_Root_Parties.ListChanged -= OnList_datasource_Root_PartiesChanged;
				for (int num = _widget_0_0_0.ChildCount - 1; num >= 0; num--)
				{
					Widget child = _widget_0_0_0.GetChild(num);
					((SPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate)child).OnBeforeRemovedChild(child);
					Widget child2 = _widget_0_0_0.GetChild(num);
					((SPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate)child2).SetDataSource(null);
					_widget_0_0_0.RemoveChild(child2);
				}
				_datasource_Root_Parties = null;
			}
			_datasource_Root = null;
		}
		_datasource_Root = newDataSource;
		if (_datasource_Root == null)
		{
			return;
		}
		_datasource_Root.PropertyChanged += ViewModelPropertyChangedListenerOf_datasource_Root;
		_datasource_Root.PropertyChangedWithValue += ViewModelPropertyChangedWithValueListenerOf_datasource_Root;
		_datasource_Root.PropertyChangedWithBoolValue += ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root;
		_datasource_Root.PropertyChangedWithIntValue += ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root;
		_datasource_Root.PropertyChangedWithFloatValue += ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root;
		_datasource_Root.PropertyChangedWithUIntValue += ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root;
		_datasource_Root.PropertyChangedWithColorValue += ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root;
		_datasource_Root.PropertyChangedWithDoubleValue += ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root;
		_datasource_Root.PropertyChangedWithVec2Value += ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root;
		_datasource_Root_Parties = _datasource_Root.Parties;
		if (_datasource_Root_Parties != null)
		{
			_datasource_Root_Parties.ListChanged += OnList_datasource_Root_PartiesChanged;
			for (int i = 0; i < _datasource_Root_Parties.Count; i++)
			{
				SPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate sPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate = new SPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate(base.Context);
				GeneratedWidgetData generatedWidgetData = new GeneratedWidgetData(sPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate);
				SPScoreboardPartyVM dataSource = (SPScoreboardPartyVM)(generatedWidgetData.Data = _datasource_Root_Parties[i]);
				sPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate.AddComponent(generatedWidgetData);
				_widget_0_0_0.AddChildAtIndex(sPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate, i);
				sPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate.CreateWidgets();
				sPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate.SetIds();
				sPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate.SetAttributes();
				sPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate.SetDataSource(dataSource);
			}
		}
	}

	private void RefreshDataSource_datasource_Root_Parties(MBBindingList<SPScoreboardPartyVM> newDataSource)
	{
		if (_datasource_Root_Parties != null)
		{
			_datasource_Root_Parties.ListChanged -= OnList_datasource_Root_PartiesChanged;
			for (int num = _widget_0_0_0.ChildCount - 1; num >= 0; num--)
			{
				Widget child = _widget_0_0_0.GetChild(num);
				((SPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate)child).OnBeforeRemovedChild(child);
				Widget child2 = _widget_0_0_0.GetChild(num);
				((SPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate)child2).SetDataSource(null);
				_widget_0_0_0.RemoveChild(child2);
			}
			_datasource_Root_Parties = null;
		}
		_datasource_Root_Parties = newDataSource;
		_datasource_Root_Parties = _datasource_Root.Parties;
		if (_datasource_Root_Parties != null)
		{
			_datasource_Root_Parties.ListChanged += OnList_datasource_Root_PartiesChanged;
			for (int i = 0; i < _datasource_Root_Parties.Count; i++)
			{
				SPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate sPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate = new SPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate(base.Context);
				GeneratedWidgetData generatedWidgetData = new GeneratedWidgetData(sPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate);
				SPScoreboardPartyVM dataSource = (SPScoreboardPartyVM)(generatedWidgetData.Data = _datasource_Root_Parties[i]);
				sPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate.AddComponent(generatedWidgetData);
				_widget_0_0_0.AddChildAtIndex(sPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate, i);
				sPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate.CreateWidgets();
				sPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate.SetIds();
				sPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate.SetAttributes();
				sPScoreboard__SandBox_ViewModelCollection_SPScoreboardVM_Dependency_9_ItemTemplate.SetDataSource(dataSource);
			}
		}
	}
}
