using System.ComponentModel;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.GauntletUI.Data;
using TaleWorlds.GauntletUI.Layout;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets;
using TaleWorlds.MountAndBlade.ViewModelCollection.FaceGenerator;

namespace TaleWorlds.MountAndBlade.GauntletUI.AutoGenerated1;

public class FaceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_18_FaceGenGrid__DependendPrefab : ListPanel
{
	private ListPanel _widget;

	private ScrollbarWidget _widget_0;

	private Widget _widget_0_0;

	private ImageWidget _widget_0_1;

	private ScrollablePanel _widget_1;

	private Widget _widget_1_0;

	private NavigatableGridWidget _widget_1_0_0;

	private Widget _widget_1_1;

	private FaceGenVM _datasource_Root;

	private MBBindingList<FacegenListItemVM> _datasource_Root_BeardTypes;

	public FaceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_18_FaceGenGrid__DependendPrefab(UIContext context)
		: base(context)
	{
	}

	public void CreateWidgets()
	{
		_widget = this;
		_widget_0 = new ScrollbarWidget(base.Context);
		_widget.AddChild(_widget_0);
		_widget_0_0 = new Widget(base.Context);
		_widget_0.AddChild(_widget_0_0);
		_widget_0_1 = new ImageWidget(base.Context);
		_widget_0.AddChild(_widget_0_1);
		_widget_1 = new ScrollablePanel(base.Context);
		_widget.AddChild(_widget_1);
		_widget_1_0 = new Widget(base.Context);
		_widget_1.AddChild(_widget_1_0);
		_widget_1_0_0 = new NavigatableGridWidget(base.Context);
		_widget_1_0.AddChild(_widget_1_0_0);
		_widget_1_1 = new Widget(base.Context);
		_widget_1.AddChild(_widget_1_1);
	}

	public void SetIds()
	{
		_widget_0.Id = "VerticalScrollbar";
		_widget_0_1.Id = "VerticalScrollbarHandle";
		_widget_1_0.Id = "ClipRect";
		_widget_1_0_0.Id = "Grid";
	}

	public void SetAttributes()
	{
		base.WidthSizePolicy = SizePolicy.StretchToParent;
		base.HeightSizePolicy = SizePolicy.StretchToParent;
		base.StackLayout.LayoutMethod = LayoutMethod.HorizontalRightToLeft;
		base.DoNotUseCustomScaleAndChildren = true;
		_widget_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_0.SuggestedWidth = 8f;
		_widget_0.HorizontalAlignment = HorizontalAlignment.Right;
		_widget_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_0.MarginTop = 15f;
		_widget_0.MarginBottom = 15f;
		_widget_0.AlignmentAxis = AlignmentAxis.Vertical;
		_widget_0.Handle = _widget_0_1;
		_widget_0.MaxValue = 100f;
		_widget_0.MinValue = 0f;
		_widget_0_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0_0.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_0_0.SuggestedWidth = 4f;
		_widget_0_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_0.Sprite = base.Context.SpriteData.GetSprite("BlankWhiteSquare_9");
		_widget_0_0.Color = new Color(0.3529412f, 0.2509804f, 0.2f);
		_widget_0_0.AlphaFactor = 0.2f;
		_widget_0_1.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0_1.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0_1.SuggestedHeight = 10f;
		_widget_0_1.SuggestedWidth = 8f;
		_widget_0_1.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_1.Brush = base.Context.GetBrush("FaceGen.Scrollbar.Handle");
		_widget_1.WidthSizePolicy = SizePolicy.StretchToParent;
		_widget_1.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_1.AutoHideScrollBars = true;
		_widget_1.ClipRect = _widget_1_0;
		_widget_1.InnerPanel = _widget_1_0_0;
		_widget_1.VerticalScrollbar = _widget_0;
		_widget_1_0.WidthSizePolicy = SizePolicy.StretchToParent;
		_widget_1_0.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_1_0.ClipContents = true;
		_widget_1_0_0.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_1_0_0.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_1_0_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_1_0_0.ColumnCount = 5;
		_widget_1_0_0.DefaultCellHeight = 112f;
		_widget_1_0_0.DefaultCellWidth = 112f;
		_widget_1_0_0.MinIndex = 2001;
		_widget_1_0_0.MaxIndex = 3000;
		_widget_1_1.DoNotAcceptEvents = true;
		_widget_1_1.WidthSizePolicy = SizePolicy.Fixed;
		_widget_1_1.HeightSizePolicy = SizePolicy.Fixed;
		_widget_1_1.SuggestedWidth = 576f;
		_widget_1_1.SuggestedHeight = 57f;
		_widget_1_1.HorizontalAlignment = HorizontalAlignment.Right;
		_widget_1_1.PositionXOffset = 13f;
		_widget_1_1.VerticalAlignment = VerticalAlignment.Bottom;
		_widget_1_1.Sprite = base.Context.SpriteData.GetSprite("General\\CharacterCreation\\character_creation_scroll_gradient");
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
		if (_datasource_Root_BeardTypes != null)
		{
			_datasource_Root_BeardTypes.ListChanged -= OnList_datasource_Root_BeardTypesChanged;
			for (int num = _widget_1_0_0.ChildCount - 1; num >= 0; num--)
			{
				Widget child = _widget_1_0_0.GetChild(num);
				((FaceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate)child).OnBeforeRemovedChild(child);
				((FaceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate)_widget_1_0_0.GetChild(num)).DestroyDataSource();
			}
			_datasource_Root_BeardTypes = null;
		}
		_datasource_Root = null;
	}

	public void SetDataSource(FaceGenVM dataSource)
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
		if (propertyName == "BeardTypes")
		{
			RefreshDataSource_datasource_Root_BeardTypes(_datasource_Root.BeardTypes);
		}
	}

	public void OnList_datasource_Root_BeardTypesChanged(object sender, TaleWorlds.Library.ListChangedEventArgs e)
	{
		switch (e.ListChangedType)
		{
		case TaleWorlds.Library.ListChangedType.Reset:
		{
			for (int num = _widget_1_0_0.ChildCount - 1; num >= 0; num--)
			{
				Widget child3 = _widget_1_0_0.GetChild(num);
				((FaceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate)child3).OnBeforeRemovedChild(child3);
				Widget child4 = _widget_1_0_0.GetChild(num);
				((FaceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate)child4).SetDataSource(null);
				_widget_1_0_0.RemoveChild(child4);
			}
			break;
		}
		case TaleWorlds.Library.ListChangedType.Sorted:
		{
			for (int i = 0; i < _datasource_Root_BeardTypes.Count; i++)
			{
				FacegenListItemVM bindingObject = _datasource_Root_BeardTypes[i];
				_widget_1_0_0.FindChild((Widget widget) => widget.GetComponent<GeneratedWidgetData>().Data == bindingObject).SetSiblingIndex(i);
			}
			break;
		}
		case TaleWorlds.Library.ListChangedType.ItemAdded:
		{
			FaceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate faceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate = new FaceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate(base.Context);
			GeneratedWidgetData generatedWidgetData = new GeneratedWidgetData(faceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate);
			FacegenListItemVM dataSource = (FacegenListItemVM)(generatedWidgetData.Data = _datasource_Root_BeardTypes[e.NewIndex]);
			faceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate.AddComponent(generatedWidgetData);
			_widget_1_0_0.AddChildAtIndex(faceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate, e.NewIndex);
			faceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate.CreateWidgets();
			faceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate.SetIds();
			faceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate.SetAttributes();
			faceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate.SetDataSource(dataSource);
			break;
		}
		case TaleWorlds.Library.ListChangedType.ItemBeforeDeleted:
		{
			Widget child2 = _widget_1_0_0.GetChild(e.NewIndex);
			((FaceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate)child2).OnBeforeRemovedChild(child2);
			break;
		}
		case TaleWorlds.Library.ListChangedType.ItemDeleted:
		{
			Widget child = _widget_1_0_0.GetChild(e.NewIndex);
			((FaceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate)child).SetDataSource(null);
			_widget_1_0_0.RemoveChild(child);
			break;
		}
		case TaleWorlds.Library.ListChangedType.ItemChanged:
			break;
		}
	}

	private void RefreshDataSource_datasource_Root(FaceGenVM newDataSource)
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
			if (_datasource_Root_BeardTypes != null)
			{
				_datasource_Root_BeardTypes.ListChanged -= OnList_datasource_Root_BeardTypesChanged;
				for (int num = _widget_1_0_0.ChildCount - 1; num >= 0; num--)
				{
					Widget child = _widget_1_0_0.GetChild(num);
					((FaceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate)child).OnBeforeRemovedChild(child);
					Widget child2 = _widget_1_0_0.GetChild(num);
					((FaceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate)child2).SetDataSource(null);
					_widget_1_0_0.RemoveChild(child2);
				}
				_datasource_Root_BeardTypes = null;
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
		_datasource_Root_BeardTypes = _datasource_Root.BeardTypes;
		if (_datasource_Root_BeardTypes != null)
		{
			_datasource_Root_BeardTypes.ListChanged += OnList_datasource_Root_BeardTypesChanged;
			for (int i = 0; i < _datasource_Root_BeardTypes.Count; i++)
			{
				FaceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate faceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate = new FaceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate(base.Context);
				GeneratedWidgetData generatedWidgetData = new GeneratedWidgetData(faceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate);
				FacegenListItemVM dataSource = (FacegenListItemVM)(generatedWidgetData.Data = _datasource_Root_BeardTypes[i]);
				faceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate.AddComponent(generatedWidgetData);
				_widget_1_0_0.AddChildAtIndex(faceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate, i);
				faceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate.CreateWidgets();
				faceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate.SetIds();
				faceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate.SetAttributes();
				faceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate.SetDataSource(dataSource);
			}
		}
	}

	private void RefreshDataSource_datasource_Root_BeardTypes(MBBindingList<FacegenListItemVM> newDataSource)
	{
		if (_datasource_Root_BeardTypes != null)
		{
			_datasource_Root_BeardTypes.ListChanged -= OnList_datasource_Root_BeardTypesChanged;
			for (int num = _widget_1_0_0.ChildCount - 1; num >= 0; num--)
			{
				Widget child = _widget_1_0_0.GetChild(num);
				((FaceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate)child).OnBeforeRemovedChild(child);
				Widget child2 = _widget_1_0_0.GetChild(num);
				((FaceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate)child2).SetDataSource(null);
				_widget_1_0_0.RemoveChild(child2);
			}
			_datasource_Root_BeardTypes = null;
		}
		_datasource_Root_BeardTypes = newDataSource;
		_datasource_Root_BeardTypes = _datasource_Root.BeardTypes;
		if (_datasource_Root_BeardTypes != null)
		{
			_datasource_Root_BeardTypes.ListChanged += OnList_datasource_Root_BeardTypesChanged;
			for (int i = 0; i < _datasource_Root_BeardTypes.Count; i++)
			{
				FaceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate faceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate = new FaceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate(base.Context);
				GeneratedWidgetData generatedWidgetData = new GeneratedWidgetData(faceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate);
				FacegenListItemVM dataSource = (FacegenListItemVM)(generatedWidgetData.Data = _datasource_Root_BeardTypes[i]);
				faceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate.AddComponent(generatedWidgetData);
				_widget_1_0_0.AddChildAtIndex(faceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate, i);
				faceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate.CreateWidgets();
				faceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate.SetIds();
				faceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate.SetAttributes();
				faceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_25_ItemTemplate.SetDataSource(dataSource);
			}
		}
	}
}
