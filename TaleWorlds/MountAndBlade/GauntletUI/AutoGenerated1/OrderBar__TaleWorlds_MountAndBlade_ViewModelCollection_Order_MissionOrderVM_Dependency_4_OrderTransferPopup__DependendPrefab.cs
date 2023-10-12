using System.ComponentModel;
using System.Numerics;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.GauntletUI.Data;
using TaleWorlds.GauntletUI.GamepadNavigation;
using TaleWorlds.GauntletUI.Layout;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets;
using TaleWorlds.MountAndBlade.ViewModelCollection.Order;

namespace TaleWorlds.MountAndBlade.GauntletUI.AutoGenerated1;

public class OrderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_4_OrderTransferPopup__DependendPrefab : Widget
{
	private Widget _widget;

	private BrushWidget _widget_0;

	private ListPanel _widget_0_0;

	private TextWidget _widget_0_0_0;

	private NavigationScopeTargeter _widget_0_0_1;

	private NavigatableListPanel _widget_0_0_2;

	private NavigationScopeTargeter _widget_0_0_3;

	private SliderWidget _widget_0_0_4;

	private Widget _widget_0_0_4_0;

	private Widget _widget_0_0_4_1;

	private Widget _widget_0_0_4_1_0;

	private ImageWidget _widget_0_0_4_2;

	private TextWidget _widget_0_0_5;

	private OrderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_10_Standard_TriplePopupCloseButtons__DependendPrefab _widget_1;

	private MissionOrderTroopControllerVM _datasource_Root;

	private MBBindingList<OrderTroopItemVM> _datasource_Root_TransferTargetList;

	public OrderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_4_OrderTransferPopup__DependendPrefab(UIContext context)
		: base(context)
	{
	}

	public void CreateWidgets()
	{
		_widget = this;
		_widget_0 = new BrushWidget(base.Context);
		_widget.AddChild(_widget_0);
		_widget_0_0 = new ListPanel(base.Context);
		_widget_0.AddChild(_widget_0_0);
		_widget_0_0_0 = new TextWidget(base.Context);
		_widget_0_0.AddChild(_widget_0_0_0);
		_widget_0_0_1 = new NavigationScopeTargeter(base.Context);
		_widget_0_0.AddChild(_widget_0_0_1);
		_widget_0_0_2 = new NavigatableListPanel(base.Context);
		_widget_0_0.AddChild(_widget_0_0_2);
		_widget_0_0_3 = new NavigationScopeTargeter(base.Context);
		_widget_0_0.AddChild(_widget_0_0_3);
		_widget_0_0_4 = new SliderWidget(base.Context);
		_widget_0_0.AddChild(_widget_0_0_4);
		_widget_0_0_4_0 = new Widget(base.Context);
		_widget_0_0_4.AddChild(_widget_0_0_4_0);
		_widget_0_0_4_1 = new Widget(base.Context);
		_widget_0_0_4.AddChild(_widget_0_0_4_1);
		_widget_0_0_4_1_0 = new Widget(base.Context);
		_widget_0_0_4_1.AddChild(_widget_0_0_4_1_0);
		_widget_0_0_4_2 = new ImageWidget(base.Context);
		_widget_0_0_4.AddChild(_widget_0_0_4_2);
		_widget_0_0_5 = new TextWidget(base.Context);
		_widget_0_0.AddChild(_widget_0_0_5);
		_widget_1 = new OrderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_10_Standard_TriplePopupCloseButtons__DependendPrefab(base.Context);
		_widget.AddChild(_widget_1);
		_widget_1.CreateWidgets();
	}

	public void SetIds()
	{
		_widget_0_0_2.Id = "TransferTargets";
		_widget_0_0_4.Id = "TransferSlider";
		_widget_0_0_4_1.Id = "Filler";
		_widget_0_0_4_2.Id = "SliderHandle";
		_widget_1.SetIds();
	}

	public void SetAttributes()
	{
		base.WidthSizePolicy = SizePolicy.StretchToParent;
		base.HeightSizePolicy = SizePolicy.StretchToParent;
		base.Sprite = base.Context.SpriteData.GetSprite("BlankWhiteSquare_9");
		base.Color = new Color(0f, 0f, 0f, 0.5333334f);
		_widget_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0.SuggestedWidth = 900f;
		_widget_0.SuggestedHeight = 370f;
		_widget_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_0.Brush = base.Context.GetBrush("Frame1Brush");
		_widget_0_0.WidthSizePolicy = SizePolicy.StretchToParent;
		_widget_0_0.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_0_0.StackLayout.LayoutMethod = LayoutMethod.VerticalBottomToTop;
		_widget_0_0_0.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_0_0_0.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0_0_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_0_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_0_0.MarginTop = 15f;
		_widget_0_0_0.Brush = base.Context.GetBrush("Order.TransferPopup.TitleText");
		_widget_0_0_1.ScopeID = "TransferTargetsScope";
		_widget_0_0_1.ScopeParent = _widget_0_0_2;
		_widget_0_0_1.ScopeMovements = GamepadNavigationTypes.Horizontal;
		_widget_0_0_2.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_0_0_2.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0_0_2.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_0_2.MarginTop = 30f;
		_widget_0_0_2.StackLayout.LayoutMethod = LayoutMethod.HorizontalLeftToRight;
		_widget_0_0_3.ScopeID = "TransferSliderScope";
		_widget_0_0_3.ScopeParent = _widget_0_0_4;
		_widget_0_0_3.ScopeMovements = GamepadNavigationTypes.Horizontal;
		_widget_0_0_3.UpNavigationScope = "TransferTargetsScope";
		_widget_0_0_3.DownNavigationScope = "TransferTargetsScope";
		_widget_0_0_4.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0_0_4.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0_0_4.SuggestedWidth = 500f;
		_widget_0_0_4.SuggestedHeight = 24f;
		_widget_0_0_4.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_0_4.MarginTop = 60f;
		_widget_0_0_4.DoNotUpdateHandleSize = true;
		_widget_0_0_4.Filler = _widget_0_0_4_1;
		_widget_0_0_4.Handle = _widget_0_0_4_2;
		_widget_0_0_4.IsDiscrete = true;
		_widget_0_0_4.MinValueInt = 0;
		_widget_0_0_4.UpdateChildrenStates = true;
		_widget_0_0_4_0.DoNotAcceptEvents = true;
		_widget_0_0_4_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0_0_4_0.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0_0_4_0.SuggestedWidth = 510f;
		_widget_0_0_4_0.SuggestedHeight = 25f;
		_widget_0_0_4_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_0_4_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_0_4_0.Sprite = base.Context.SpriteData.GetSprite("minimal_slider_bed_9");
		_widget_0_0_4_1.ClipContents = true;
		_widget_0_0_4_1.DoNotAcceptEvents = true;
		_widget_0_0_4_1.WidthSizePolicy = SizePolicy.StretchToParent;
		_widget_0_0_4_1.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0_0_4_1.SuggestedHeight = 23f;
		_widget_0_0_4_1.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_0_4_1_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0_0_4_1_0.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0_0_4_1_0.SuggestedWidth = 492f;
		_widget_0_0_4_1_0.SuggestedHeight = 21f;
		_widget_0_0_4_1_0.Sprite = base.Context.SpriteData.GetSprite("minimal_slider_fill_9");
		_widget_0_0_4_1_0.PositionYOffset = 1f;
		_widget_0_0_4_1_0.ColorFactor = 1.2f;
		_widget_0_0_4_2.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0_0_4_2.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0_0_4_2.SuggestedWidth = 11f;
		_widget_0_0_4_2.SuggestedHeight = 27f;
		_widget_0_0_4_2.HorizontalAlignment = HorizontalAlignment.Left;
		_widget_0_0_4_2.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_0_4_2.Brush = base.Context.GetBrush("OrderOfBattle.Slider.SliderHandle");
		_widget_0_0_4_2.GamepadNavigationIndex = 0;
		_widget_0_0_5.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_0_0_5.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0_0_5.SuggestedWidth = 80f;
		_widget_0_0_5.SuggestedHeight = 30f;
		_widget_0_0_5.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_0_5.Brush = base.Context.GetBrush("Order.TransferPopup.SliderValue");
		_widget_1.SetAttributes();
		_widget_1.MarginTop = 480f;
		_widget_1.VerticalAlignment = VerticalAlignment.Center;
	}

	public void DestroyDataSource()
	{
		if (_datasource_Root == null)
		{
			return;
		}
		_widget_1.DestroyDataSource();
		_datasource_Root.PropertyChanged -= ViewModelPropertyChangedListenerOf_datasource_Root;
		_datasource_Root.PropertyChangedWithValue -= ViewModelPropertyChangedWithValueListenerOf_datasource_Root;
		_datasource_Root.PropertyChangedWithBoolValue -= ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root;
		_datasource_Root.PropertyChangedWithIntValue -= ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root;
		_datasource_Root.PropertyChangedWithFloatValue -= ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root;
		_datasource_Root.PropertyChangedWithUIntValue -= ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root;
		_datasource_Root.PropertyChangedWithColorValue -= ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root;
		_datasource_Root.PropertyChangedWithDoubleValue -= ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root;
		_datasource_Root.PropertyChangedWithVec2Value -= ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root;
		_widget.PropertyChanged -= PropertyChangedListenerOf_widget;
		_widget.boolPropertyChanged -= boolPropertyChangedListenerOf_widget;
		_widget.floatPropertyChanged -= floatPropertyChangedListenerOf_widget;
		_widget.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget;
		_widget.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget;
		_widget.doublePropertyChanged -= doublePropertyChangedListenerOf_widget;
		_widget.intPropertyChanged -= intPropertyChangedListenerOf_widget;
		_widget.uintPropertyChanged -= uintPropertyChangedListenerOf_widget;
		_widget.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget;
		_widget_0_0_0.PropertyChanged -= PropertyChangedListenerOf_widget_0_0_0;
		_widget_0_0_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_0_0;
		_widget_0_0_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_0_0;
		_widget_0_0_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_0_0;
		_widget_0_0_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_0_0;
		_widget_0_0_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_0_0;
		_widget_0_0_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_0_0;
		_widget_0_0_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_0_0;
		_widget_0_0_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_0_0;
		_widget_0_0_4.PropertyChanged -= PropertyChangedListenerOf_widget_0_0_4;
		_widget_0_0_4.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_0_4;
		_widget_0_0_4.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_0_4;
		_widget_0_0_4.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_0_4;
		_widget_0_0_4.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_0_4;
		_widget_0_0_4.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_0_4;
		_widget_0_0_4.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_0_4;
		_widget_0_0_4.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_0_4;
		_widget_0_0_4.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_0_4;
		_widget_0_0_5.PropertyChanged -= PropertyChangedListenerOf_widget_0_0_5;
		_widget_0_0_5.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_0_5;
		_widget_0_0_5.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_0_5;
		_widget_0_0_5.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_0_5;
		_widget_0_0_5.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_0_5;
		_widget_0_0_5.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_0_5;
		_widget_0_0_5.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_0_5;
		_widget_0_0_5.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_0_5;
		_widget_0_0_5.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_0_5;
		if (_datasource_Root_TransferTargetList != null)
		{
			_datasource_Root_TransferTargetList.ListChanged -= OnList_datasource_Root_TransferTargetListChanged;
			for (int num = _widget_0_0_2.ChildCount - 1; num >= 0; num--)
			{
				Widget child = _widget_0_0_2.GetChild(num);
				((OrderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate)child).OnBeforeRemovedChild(child);
				((OrderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate)_widget_0_0_2.GetChild(num)).DestroyDataSource();
			}
			_datasource_Root_TransferTargetList = null;
		}
		_datasource_Root = null;
	}

	public void SetDataSource(MissionOrderTroopControllerVM dataSource)
	{
		RefreshDataSource_datasource_Root(dataSource);
	}

	private void PropertyChangedListenerOf_widget(PropertyOwnerObject propertyOwnerObject, string propertyName, object e)
	{
		HandleWidgetPropertyChangeOf_widget(propertyName);
	}

	private void boolPropertyChangedListenerOf_widget(PropertyOwnerObject propertyOwnerObject, string propertyName, bool e)
	{
		HandleWidgetPropertyChangeOf_widget(propertyName);
	}

	private void floatPropertyChangedListenerOf_widget(PropertyOwnerObject propertyOwnerObject, string propertyName, float e)
	{
		HandleWidgetPropertyChangeOf_widget(propertyName);
	}

	private void Vec2PropertyChangedListenerOf_widget(PropertyOwnerObject propertyOwnerObject, string propertyName, Vec2 e)
	{
		HandleWidgetPropertyChangeOf_widget(propertyName);
	}

	private void Vector2PropertyChangedListenerOf_widget(PropertyOwnerObject propertyOwnerObject, string propertyName, Vector2 e)
	{
		HandleWidgetPropertyChangeOf_widget(propertyName);
	}

	private void doublePropertyChangedListenerOf_widget(PropertyOwnerObject propertyOwnerObject, string propertyName, double e)
	{
		HandleWidgetPropertyChangeOf_widget(propertyName);
	}

	private void intPropertyChangedListenerOf_widget(PropertyOwnerObject propertyOwnerObject, string propertyName, int e)
	{
		HandleWidgetPropertyChangeOf_widget(propertyName);
	}

	private void uintPropertyChangedListenerOf_widget(PropertyOwnerObject propertyOwnerObject, string propertyName, uint e)
	{
		HandleWidgetPropertyChangeOf_widget(propertyName);
	}

	private void ColorPropertyChangedListenerOf_widget(PropertyOwnerObject propertyOwnerObject, string propertyName, Color e)
	{
		HandleWidgetPropertyChangeOf_widget(propertyName);
	}

	private void HandleWidgetPropertyChangeOf_widget(string propertyName)
	{
		if (propertyName == "IsVisible")
		{
			_datasource_Root.IsTransferActive = _widget.IsVisible;
		}
	}

	private void PropertyChangedListenerOf_widget_0_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, object e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_0(propertyName);
	}

	private void boolPropertyChangedListenerOf_widget_0_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, bool e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_0(propertyName);
	}

	private void floatPropertyChangedListenerOf_widget_0_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, float e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_0(propertyName);
	}

	private void Vec2PropertyChangedListenerOf_widget_0_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Vec2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_0(propertyName);
	}

	private void Vector2PropertyChangedListenerOf_widget_0_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Vector2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_0(propertyName);
	}

	private void doublePropertyChangedListenerOf_widget_0_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, double e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_0(propertyName);
	}

	private void intPropertyChangedListenerOf_widget_0_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, int e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_0(propertyName);
	}

	private void uintPropertyChangedListenerOf_widget_0_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, uint e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_0(propertyName);
	}

	private void ColorPropertyChangedListenerOf_widget_0_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Color e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_0(propertyName);
	}

	private void HandleWidgetPropertyChangeOf_widget_0_0_0(string propertyName)
	{
		if (propertyName == "Text")
		{
			_datasource_Root.TransferTitleText = _widget_0_0_0.Text;
		}
	}

	private void PropertyChangedListenerOf_widget_0_0_4(PropertyOwnerObject propertyOwnerObject, string propertyName, object e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_4(propertyName);
	}

	private void boolPropertyChangedListenerOf_widget_0_0_4(PropertyOwnerObject propertyOwnerObject, string propertyName, bool e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_4(propertyName);
	}

	private void floatPropertyChangedListenerOf_widget_0_0_4(PropertyOwnerObject propertyOwnerObject, string propertyName, float e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_4(propertyName);
	}

	private void Vec2PropertyChangedListenerOf_widget_0_0_4(PropertyOwnerObject propertyOwnerObject, string propertyName, Vec2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_4(propertyName);
	}

	private void Vector2PropertyChangedListenerOf_widget_0_0_4(PropertyOwnerObject propertyOwnerObject, string propertyName, Vector2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_4(propertyName);
	}

	private void doublePropertyChangedListenerOf_widget_0_0_4(PropertyOwnerObject propertyOwnerObject, string propertyName, double e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_4(propertyName);
	}

	private void intPropertyChangedListenerOf_widget_0_0_4(PropertyOwnerObject propertyOwnerObject, string propertyName, int e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_4(propertyName);
	}

	private void uintPropertyChangedListenerOf_widget_0_0_4(PropertyOwnerObject propertyOwnerObject, string propertyName, uint e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_4(propertyName);
	}

	private void ColorPropertyChangedListenerOf_widget_0_0_4(PropertyOwnerObject propertyOwnerObject, string propertyName, Color e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_4(propertyName);
	}

	private void HandleWidgetPropertyChangeOf_widget_0_0_4(string propertyName)
	{
		if (propertyName == "MaxValueInt")
		{
			_datasource_Root.TransferMaxValue = _widget_0_0_4.MaxValueInt;
		}
		else if (propertyName == "ValueInt")
		{
			_datasource_Root.TransferValue = _widget_0_0_4.ValueInt;
		}
	}

	private void PropertyChangedListenerOf_widget_0_0_5(PropertyOwnerObject propertyOwnerObject, string propertyName, object e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_5(propertyName);
	}

	private void boolPropertyChangedListenerOf_widget_0_0_5(PropertyOwnerObject propertyOwnerObject, string propertyName, bool e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_5(propertyName);
	}

	private void floatPropertyChangedListenerOf_widget_0_0_5(PropertyOwnerObject propertyOwnerObject, string propertyName, float e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_5(propertyName);
	}

	private void Vec2PropertyChangedListenerOf_widget_0_0_5(PropertyOwnerObject propertyOwnerObject, string propertyName, Vec2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_5(propertyName);
	}

	private void Vector2PropertyChangedListenerOf_widget_0_0_5(PropertyOwnerObject propertyOwnerObject, string propertyName, Vector2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_5(propertyName);
	}

	private void doublePropertyChangedListenerOf_widget_0_0_5(PropertyOwnerObject propertyOwnerObject, string propertyName, double e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_5(propertyName);
	}

	private void intPropertyChangedListenerOf_widget_0_0_5(PropertyOwnerObject propertyOwnerObject, string propertyName, int e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_5(propertyName);
	}

	private void uintPropertyChangedListenerOf_widget_0_0_5(PropertyOwnerObject propertyOwnerObject, string propertyName, uint e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_5(propertyName);
	}

	private void ColorPropertyChangedListenerOf_widget_0_0_5(PropertyOwnerObject propertyOwnerObject, string propertyName, Color e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0_5(propertyName);
	}

	private void HandleWidgetPropertyChangeOf_widget_0_0_5(string propertyName)
	{
		if (propertyName == "IntText")
		{
			_datasource_Root.TransferValue = _widget_0_0_5.IntText;
		}
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
		switch (propertyName)
		{
		case "TransferTargetList":
			RefreshDataSource_datasource_Root_TransferTargetList(_datasource_Root.TransferTargetList);
			break;
		case "IsTransferActive":
			_widget.IsVisible = _datasource_Root.IsTransferActive;
			break;
		case "TransferTitleText":
			_widget_0_0_0.Text = _datasource_Root.TransferTitleText;
			break;
		case "TransferMaxValue":
			_widget_0_0_4.MaxValueInt = _datasource_Root.TransferMaxValue;
			break;
		case "TransferValue":
			_widget_0_0_4.ValueInt = _datasource_Root.TransferValue;
			_widget_0_0_5.IntText = _datasource_Root.TransferValue;
			break;
		}
	}

	public void OnList_datasource_Root_TransferTargetListChanged(object sender, TaleWorlds.Library.ListChangedEventArgs e)
	{
		switch (e.ListChangedType)
		{
		case TaleWorlds.Library.ListChangedType.Reset:
		{
			for (int num = _widget_0_0_2.ChildCount - 1; num >= 0; num--)
			{
				Widget child3 = _widget_0_0_2.GetChild(num);
				((OrderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate)child3).OnBeforeRemovedChild(child3);
				Widget child4 = _widget_0_0_2.GetChild(num);
				((OrderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate)child4).SetDataSource(null);
				_widget_0_0_2.RemoveChild(child4);
			}
			break;
		}
		case TaleWorlds.Library.ListChangedType.Sorted:
		{
			for (int i = 0; i < _datasource_Root_TransferTargetList.Count; i++)
			{
				OrderTroopItemVM bindingObject = _datasource_Root_TransferTargetList[i];
				_widget_0_0_2.FindChild((Widget widget) => widget.GetComponent<GeneratedWidgetData>().Data == bindingObject).SetSiblingIndex(i);
			}
			break;
		}
		case TaleWorlds.Library.ListChangedType.ItemAdded:
		{
			OrderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate orderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate = new OrderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate(base.Context);
			GeneratedWidgetData generatedWidgetData = new GeneratedWidgetData(orderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate);
			OrderTroopItemVM dataSource = (OrderTroopItemVM)(generatedWidgetData.Data = _datasource_Root_TransferTargetList[e.NewIndex]);
			orderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate.AddComponent(generatedWidgetData);
			_widget_0_0_2.AddChildAtIndex(orderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate, e.NewIndex);
			orderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate.CreateWidgets();
			orderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate.SetIds();
			orderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate.SetAttributes();
			orderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate.SetDataSource(dataSource);
			break;
		}
		case TaleWorlds.Library.ListChangedType.ItemBeforeDeleted:
		{
			Widget child2 = _widget_0_0_2.GetChild(e.NewIndex);
			((OrderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate)child2).OnBeforeRemovedChild(child2);
			break;
		}
		case TaleWorlds.Library.ListChangedType.ItemDeleted:
		{
			Widget child = _widget_0_0_2.GetChild(e.NewIndex);
			((OrderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate)child).SetDataSource(null);
			_widget_0_0_2.RemoveChild(child);
			break;
		}
		case TaleWorlds.Library.ListChangedType.ItemChanged:
			break;
		}
	}

	private void RefreshDataSource_datasource_Root(MissionOrderTroopControllerVM newDataSource)
	{
		if (_datasource_Root != null)
		{
			_widget_1.SetDataSource(null);
			_datasource_Root.PropertyChanged -= ViewModelPropertyChangedListenerOf_datasource_Root;
			_datasource_Root.PropertyChangedWithValue -= ViewModelPropertyChangedWithValueListenerOf_datasource_Root;
			_datasource_Root.PropertyChangedWithBoolValue -= ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root;
			_datasource_Root.PropertyChangedWithIntValue -= ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root;
			_datasource_Root.PropertyChangedWithFloatValue -= ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root;
			_datasource_Root.PropertyChangedWithUIntValue -= ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root;
			_datasource_Root.PropertyChangedWithColorValue -= ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root;
			_datasource_Root.PropertyChangedWithDoubleValue -= ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root;
			_datasource_Root.PropertyChangedWithVec2Value -= ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root;
			_widget.PropertyChanged -= PropertyChangedListenerOf_widget;
			_widget.boolPropertyChanged -= boolPropertyChangedListenerOf_widget;
			_widget.floatPropertyChanged -= floatPropertyChangedListenerOf_widget;
			_widget.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget;
			_widget.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget;
			_widget.doublePropertyChanged -= doublePropertyChangedListenerOf_widget;
			_widget.intPropertyChanged -= intPropertyChangedListenerOf_widget;
			_widget.uintPropertyChanged -= uintPropertyChangedListenerOf_widget;
			_widget.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget;
			_widget_0_0_0.PropertyChanged -= PropertyChangedListenerOf_widget_0_0_0;
			_widget_0_0_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_0_0;
			_widget_0_0_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_0_0;
			_widget_0_0_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_0_0;
			_widget_0_0_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_0_0;
			_widget_0_0_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_0_0;
			_widget_0_0_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_0_0;
			_widget_0_0_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_0_0;
			_widget_0_0_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_0_0;
			_widget_0_0_4.PropertyChanged -= PropertyChangedListenerOf_widget_0_0_4;
			_widget_0_0_4.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_0_4;
			_widget_0_0_4.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_0_4;
			_widget_0_0_4.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_0_4;
			_widget_0_0_4.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_0_4;
			_widget_0_0_4.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_0_4;
			_widget_0_0_4.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_0_4;
			_widget_0_0_4.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_0_4;
			_widget_0_0_4.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_0_4;
			_widget_0_0_5.PropertyChanged -= PropertyChangedListenerOf_widget_0_0_5;
			_widget_0_0_5.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_0_5;
			_widget_0_0_5.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_0_5;
			_widget_0_0_5.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_0_5;
			_widget_0_0_5.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_0_5;
			_widget_0_0_5.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_0_5;
			_widget_0_0_5.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_0_5;
			_widget_0_0_5.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_0_5;
			_widget_0_0_5.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_0_5;
			if (_datasource_Root_TransferTargetList != null)
			{
				_datasource_Root_TransferTargetList.ListChanged -= OnList_datasource_Root_TransferTargetListChanged;
				for (int num = _widget_0_0_2.ChildCount - 1; num >= 0; num--)
				{
					Widget child = _widget_0_0_2.GetChild(num);
					((OrderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate)child).OnBeforeRemovedChild(child);
					Widget child2 = _widget_0_0_2.GetChild(num);
					((OrderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate)child2).SetDataSource(null);
					_widget_0_0_2.RemoveChild(child2);
				}
				_datasource_Root_TransferTargetList = null;
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
		_widget.IsVisible = _datasource_Root.IsTransferActive;
		_widget.PropertyChanged += PropertyChangedListenerOf_widget;
		_widget.boolPropertyChanged += boolPropertyChangedListenerOf_widget;
		_widget.floatPropertyChanged += floatPropertyChangedListenerOf_widget;
		_widget.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget;
		_widget.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget;
		_widget.doublePropertyChanged += doublePropertyChangedListenerOf_widget;
		_widget.intPropertyChanged += intPropertyChangedListenerOf_widget;
		_widget.uintPropertyChanged += uintPropertyChangedListenerOf_widget;
		_widget.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget;
		_widget_0_0_0.Text = _datasource_Root.TransferTitleText;
		_widget_0_0_0.PropertyChanged += PropertyChangedListenerOf_widget_0_0_0;
		_widget_0_0_0.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_0_0;
		_widget_0_0_0.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_0_0;
		_widget_0_0_0.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_0_0;
		_widget_0_0_0.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_0_0;
		_widget_0_0_0.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_0_0;
		_widget_0_0_0.intPropertyChanged += intPropertyChangedListenerOf_widget_0_0_0;
		_widget_0_0_0.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_0_0;
		_widget_0_0_0.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_0_0;
		_widget_0_0_4.MaxValueInt = _datasource_Root.TransferMaxValue;
		_widget_0_0_4.ValueInt = _datasource_Root.TransferValue;
		_widget_0_0_4.PropertyChanged += PropertyChangedListenerOf_widget_0_0_4;
		_widget_0_0_4.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_0_4;
		_widget_0_0_4.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_0_4;
		_widget_0_0_4.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_0_4;
		_widget_0_0_4.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_0_4;
		_widget_0_0_4.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_0_4;
		_widget_0_0_4.intPropertyChanged += intPropertyChangedListenerOf_widget_0_0_4;
		_widget_0_0_4.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_0_4;
		_widget_0_0_4.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_0_4;
		_widget_0_0_5.IntText = _datasource_Root.TransferValue;
		_widget_0_0_5.PropertyChanged += PropertyChangedListenerOf_widget_0_0_5;
		_widget_0_0_5.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_0_5;
		_widget_0_0_5.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_0_5;
		_widget_0_0_5.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_0_5;
		_widget_0_0_5.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_0_5;
		_widget_0_0_5.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_0_5;
		_widget_0_0_5.intPropertyChanged += intPropertyChangedListenerOf_widget_0_0_5;
		_widget_0_0_5.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_0_5;
		_widget_0_0_5.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_0_5;
		_datasource_Root_TransferTargetList = _datasource_Root.TransferTargetList;
		if (_datasource_Root_TransferTargetList != null)
		{
			_datasource_Root_TransferTargetList.ListChanged += OnList_datasource_Root_TransferTargetListChanged;
			for (int i = 0; i < _datasource_Root_TransferTargetList.Count; i++)
			{
				OrderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate orderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate = new OrderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate(base.Context);
				GeneratedWidgetData generatedWidgetData = new GeneratedWidgetData(orderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate);
				OrderTroopItemVM dataSource = (OrderTroopItemVM)(generatedWidgetData.Data = _datasource_Root_TransferTargetList[i]);
				orderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate.AddComponent(generatedWidgetData);
				_widget_0_0_2.AddChildAtIndex(orderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate, i);
				orderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate.CreateWidgets();
				orderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate.SetIds();
				orderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate.SetAttributes();
				orderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate.SetDataSource(dataSource);
			}
		}
		_widget_1.SetDataSource(_datasource_Root);
	}

	private void RefreshDataSource_datasource_Root_TransferTargetList(MBBindingList<OrderTroopItemVM> newDataSource)
	{
		if (_datasource_Root_TransferTargetList != null)
		{
			_datasource_Root_TransferTargetList.ListChanged -= OnList_datasource_Root_TransferTargetListChanged;
			for (int num = _widget_0_0_2.ChildCount - 1; num >= 0; num--)
			{
				Widget child = _widget_0_0_2.GetChild(num);
				((OrderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate)child).OnBeforeRemovedChild(child);
				Widget child2 = _widget_0_0_2.GetChild(num);
				((OrderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate)child2).SetDataSource(null);
				_widget_0_0_2.RemoveChild(child2);
			}
			_datasource_Root_TransferTargetList = null;
		}
		_datasource_Root_TransferTargetList = newDataSource;
		_datasource_Root_TransferTargetList = _datasource_Root.TransferTargetList;
		if (_datasource_Root_TransferTargetList != null)
		{
			_datasource_Root_TransferTargetList.ListChanged += OnList_datasource_Root_TransferTargetListChanged;
			for (int i = 0; i < _datasource_Root_TransferTargetList.Count; i++)
			{
				OrderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate orderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate = new OrderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate(base.Context);
				GeneratedWidgetData generatedWidgetData = new GeneratedWidgetData(orderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate);
				OrderTroopItemVM dataSource = (OrderTroopItemVM)(generatedWidgetData.Data = _datasource_Root_TransferTargetList[i]);
				orderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate.AddComponent(generatedWidgetData);
				_widget_0_0_2.AddChildAtIndex(orderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate, i);
				orderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate.CreateWidgets();
				orderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate.SetIds();
				orderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate.SetAttributes();
				orderBar__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_9_ItemTemplate.SetDataSource(dataSource);
			}
		}
	}
}