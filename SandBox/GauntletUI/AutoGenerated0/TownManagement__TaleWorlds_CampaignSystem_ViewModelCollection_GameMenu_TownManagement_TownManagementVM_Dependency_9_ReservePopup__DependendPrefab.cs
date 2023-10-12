using System.ComponentModel;
using System.Numerics;
using TaleWorlds.CampaignSystem.ViewModelCollection.GameMenu.TownManagement;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.GauntletUI.GamepadNavigation;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets.Menu.TownManagement;

namespace SandBox.GauntletUI.AutoGenerated0;

public class TownManagement__TaleWorlds_CampaignSystem_ViewModelCollection_GameMenu_TownManagement_TownManagementVM_Dependency_9_ReservePopup__DependendPrefab : Widget
{
	private Widget _widget;

	private NavigationForcedScopeCollectionTargeter _widget_0;

	private NavigationScopeTargeter _widget_1;

	private SliderPopupWidget _widget_2;

	private SliderWidget _widget_2_0;

	private Widget _widget_2_0_0;

	private Widget _widget_2_0_1;

	private Widget _widget_2_0_2;

	private Widget _widget_2_0_3;

	private TextWidget _widget_2_1;

	private TextWidget _widget_2_2;

	private TextWidget _widget_2_3;

	private ButtonWidget _widget_2_4;

	private TownManagementReserveControlVM _datasource_Root;

	public TownManagement__TaleWorlds_CampaignSystem_ViewModelCollection_GameMenu_TownManagement_TownManagementVM_Dependency_9_ReservePopup__DependendPrefab(UIContext context)
		: base(context)
	{
	}

	public void CreateWidgets()
	{
		_widget = this;
		_widget_0 = new NavigationForcedScopeCollectionTargeter(base.Context);
		_widget.AddChild(_widget_0);
		_widget_1 = new NavigationScopeTargeter(base.Context);
		_widget.AddChild(_widget_1);
		_widget_2 = new SliderPopupWidget(base.Context);
		_widget.AddChild(_widget_2);
		_widget_2_0 = new SliderWidget(base.Context);
		_widget_2.AddChild(_widget_2_0);
		_widget_2_0_0 = new Widget(base.Context);
		_widget_2_0.AddChild(_widget_2_0_0);
		_widget_2_0_1 = new Widget(base.Context);
		_widget_2_0.AddChild(_widget_2_0_1);
		_widget_2_0_2 = new Widget(base.Context);
		_widget_2_0.AddChild(_widget_2_0_2);
		_widget_2_0_3 = new Widget(base.Context);
		_widget_2_0.AddChild(_widget_2_0_3);
		_widget_2_1 = new TextWidget(base.Context);
		_widget_2.AddChild(_widget_2_1);
		_widget_2_2 = new TextWidget(base.Context);
		_widget_2.AddChild(_widget_2_2);
		_widget_2_3 = new TextWidget(base.Context);
		_widget_2.AddChild(_widget_2_3);
		_widget_2_4 = new ButtonWidget(base.Context);
		_widget_2.AddChild(_widget_2_4);
	}

	public void SetIds()
	{
		_widget_2.Id = "PopupParent";
		_widget_2_0.Id = "ReserveAmountSlider";
		_widget_2_0_1.Id = "Filler";
		_widget_2_0_2.Id = "SliderHandle";
		_widget_2_2.Id = "SliderValueTextWidget";
		_widget_2_4.Id = "ClosePopupButton";
	}

	public void SetAttributes()
	{
		base.WidthSizePolicy = SizePolicy.StretchToParent;
		base.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_0.CollectionID = "ReserverPopupCollection";
		_widget_0.CollectionParent = _widget_2;
		_widget_1.ScopeID = "ReservePopupScope";
		_widget_1.ScopeParent = _widget_2;
		_widget_1.ScopeMovements = GamepadNavigationTypes.Vertical;
		_widget_2.WidthSizePolicy = SizePolicy.Fixed;
		_widget_2.HeightSizePolicy = SizePolicy.Fixed;
		_widget_2.SuggestedWidth = 450f;
		_widget_2.SuggestedHeight = 170f;
		_widget_2.HorizontalAlignment = HorizontalAlignment.Right;
		_widget_2.VerticalAlignment = VerticalAlignment.Top;
		_widget_2.MarginTop = 435f;
		_widget_2.MarginRight = 210f;
		_widget_2.Sprite = base.Context.SpriteData.GetSprite("reserve_popup_9");
		_widget_2.ClosePopupWidget = _widget_2_4;
		_widget_2.ReserveAmountSlider = _widget_2_0;
		_widget_2.SliderValueTextWidget = _widget_2_2;
		_widget_2.PopupParentWidget = _widget.FindChild(new BindingPath("..\\TownManagementPopup\\InnerPanel\\ManagementPlacementList\\TopHalf\\TopHalfListPanel\\ReservePanel\\ReserveListPanel\\ReserveManagementButton"));
		_widget_2_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_2_0.HeightSizePolicy = SizePolicy.Fixed;
		_widget_2_0.SuggestedWidth = 370f;
		_widget_2_0.SuggestedHeight = 37f;
		_widget_2_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_2_0.VerticalAlignment = VerticalAlignment.Top;
		_widget_2_0.MarginTop = 25f;
		_widget_2_0.DoNotUpdateHandleSize = true;
		_widget_2_0.Filler = _widget_2_0_1;
		_widget_2_0.Handle = _widget_2_0_2;
		_widget_2_0.IsDiscrete = true;
		_widget_2_0.DiscreteIncrementInterval = 100;
		_widget_2_0.MinValueInt = 0;
		_widget_2_0_0.DoNotAcceptEvents = true;
		_widget_2_0_0.WidthSizePolicy = SizePolicy.StretchToParent;
		_widget_2_0_0.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_2_0_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_2_0_0.Sprite = base.Context.SpriteData.GetSprite("BlankWhiteSquare_9");
		_widget_2_0_0.Color = new Color(0.1098039f, 0.09411766f, 1f / 17f);
		_widget_2_0_1.DoNotAcceptEvents = true;
		_widget_2_0_1.WidthSizePolicy = SizePolicy.StretchToParent;
		_widget_2_0_1.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_2_0_1.VerticalAlignment = VerticalAlignment.Center;
		_widget_2_0_1.Sprite = base.Context.SpriteData.GetSprite("BlankWhiteSquare_9");
		_widget_2_0_1.Color = new Color(0.3921569f, 0.2901961f, 0.07450981f);
		_widget_2_0_2.WidthSizePolicy = SizePolicy.Fixed;
		_widget_2_0_2.HeightSizePolicy = SizePolicy.Fixed;
		_widget_2_0_2.SuggestedWidth = 7f;
		_widget_2_0_2.SuggestedHeight = 37f;
		_widget_2_0_2.HorizontalAlignment = HorizontalAlignment.Left;
		_widget_2_0_2.VerticalAlignment = VerticalAlignment.Center;
		_widget_2_0_2.Sprite = base.Context.SpriteData.GetSprite("SPGeneral\\TownManagement\\reserve_slider_indicator");
		_widget_2_0_2.GamepadNavigationIndex = 0;
		_widget_2_0_3.WidthSizePolicy = SizePolicy.StretchToParent;
		_widget_2_0_3.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_2_0_3.VerticalAlignment = VerticalAlignment.Center;
		_widget_2_0_3.Sprite = base.Context.SpriteData.GetSprite("reserve_slider_frame_9");
		_widget_2_0_3.ExtendLeft = 4f;
		_widget_2_0_3.ExtendTop = 4f;
		_widget_2_0_3.ExtendRight = 4f;
		_widget_2_0_3.ExtendBottom = 5f;
		_widget_2_0_3.IsEnabled = false;
		_widget_2_1.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_2_1.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_2_1.MarginLeft = 30f;
		_widget_2_1.MarginTop = 70f;
		_widget_2_1.IsDisabled = true;
		_widget_2_1.Text = "0";
		_widget_2_1.Brush = base.Context.GetBrush("TownManagement.Reserve.Amount.Text");
		_widget_2_2.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_2_2.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_2_2.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_2_2.MarginTop = 70f;
		_widget_2_2.IsDisabled = true;
		_widget_2_2.Brush = base.Context.GetBrush("TownManagement.Reserve.Amount.Text");
		_widget_2_3.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_2_3.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_2_3.HorizontalAlignment = HorizontalAlignment.Right;
		_widget_2_3.MarginRight = 30f;
		_widget_2_3.MarginTop = 70f;
		_widget_2_3.Brush = base.Context.GetBrush("TownManagement.Reserve.Amount.Text");
		_widget_2_3.IsDisabled = true;
		_widget_2_4.WidthSizePolicy = SizePolicy.Fixed;
		_widget_2_4.HeightSizePolicy = SizePolicy.Fixed;
		_widget_2_4.SuggestedWidth = 48f;
		_widget_2_4.SuggestedHeight = 48f;
		_widget_2_4.VerticalAlignment = VerticalAlignment.Bottom;
		_widget_2_4.MarginBottom = 25f;
		_widget_2_4.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_2_4.Brush = base.Context.GetBrush("TownManagement.Reserve.ConfirmButton");
		_widget_2_4.GamepadNavigationIndex = 1;
	}

	public void DestroyDataSource()
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
			_widget.PropertyChanged -= PropertyChangedListenerOf_widget;
			_widget.boolPropertyChanged -= boolPropertyChangedListenerOf_widget;
			_widget.floatPropertyChanged -= floatPropertyChangedListenerOf_widget;
			_widget.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget;
			_widget.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget;
			_widget.doublePropertyChanged -= doublePropertyChangedListenerOf_widget;
			_widget.intPropertyChanged -= intPropertyChangedListenerOf_widget;
			_widget.uintPropertyChanged -= uintPropertyChangedListenerOf_widget;
			_widget.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget;
			_widget_2.EventFire -= EventListenerOf_widget_2;
			_widget_2_0.PropertyChanged -= PropertyChangedListenerOf_widget_2_0;
			_widget_2_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_2_0;
			_widget_2_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_2_0;
			_widget_2_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_2_0;
			_widget_2_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_2_0;
			_widget_2_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_2_0;
			_widget_2_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_2_0;
			_widget_2_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_2_0;
			_widget_2_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_2_0;
			_widget_2_2.PropertyChanged -= PropertyChangedListenerOf_widget_2_2;
			_widget_2_2.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_2_2;
			_widget_2_2.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_2_2;
			_widget_2_2.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_2_2;
			_widget_2_2.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_2_2;
			_widget_2_2.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_2_2;
			_widget_2_2.intPropertyChanged -= intPropertyChangedListenerOf_widget_2_2;
			_widget_2_2.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_2_2;
			_widget_2_2.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_2_2;
			_widget_2_3.PropertyChanged -= PropertyChangedListenerOf_widget_2_3;
			_widget_2_3.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_2_3;
			_widget_2_3.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_2_3;
			_widget_2_3.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_2_3;
			_widget_2_3.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_2_3;
			_widget_2_3.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_2_3;
			_widget_2_3.intPropertyChanged -= intPropertyChangedListenerOf_widget_2_3;
			_widget_2_3.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_2_3;
			_widget_2_3.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_2_3;
			_widget_2_4.EventFire -= EventListenerOf_widget_2_4;
			_datasource_Root = null;
		}
	}

	public void SetDataSource(TownManagementReserveControlVM dataSource)
	{
		RefreshDataSource_datasource_Root(dataSource);
	}

	private void EventListenerOf_widget_2(Widget widget, string commandName, object[] args)
	{
		if (commandName == "ClosePopup")
		{
			_datasource_Root.ExecuteUpdateReserve();
		}
	}

	private void EventListenerOf_widget_2_4(Widget widget, string commandName, object[] args)
	{
		if (commandName == "Click")
		{
			_datasource_Root.ExecuteUpdateReserve();
		}
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
			_datasource_Root.IsEnabled = _widget.IsVisible;
		}
	}

	private void PropertyChangedListenerOf_widget_2_0(PropertyOwnerObject propertyOwnerObject, string propertyName, object e)
	{
		HandleWidgetPropertyChangeOf_widget_2_0(propertyName);
	}

	private void boolPropertyChangedListenerOf_widget_2_0(PropertyOwnerObject propertyOwnerObject, string propertyName, bool e)
	{
		HandleWidgetPropertyChangeOf_widget_2_0(propertyName);
	}

	private void floatPropertyChangedListenerOf_widget_2_0(PropertyOwnerObject propertyOwnerObject, string propertyName, float e)
	{
		HandleWidgetPropertyChangeOf_widget_2_0(propertyName);
	}

	private void Vec2PropertyChangedListenerOf_widget_2_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Vec2 e)
	{
		HandleWidgetPropertyChangeOf_widget_2_0(propertyName);
	}

	private void Vector2PropertyChangedListenerOf_widget_2_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Vector2 e)
	{
		HandleWidgetPropertyChangeOf_widget_2_0(propertyName);
	}

	private void doublePropertyChangedListenerOf_widget_2_0(PropertyOwnerObject propertyOwnerObject, string propertyName, double e)
	{
		HandleWidgetPropertyChangeOf_widget_2_0(propertyName);
	}

	private void intPropertyChangedListenerOf_widget_2_0(PropertyOwnerObject propertyOwnerObject, string propertyName, int e)
	{
		HandleWidgetPropertyChangeOf_widget_2_0(propertyName);
	}

	private void uintPropertyChangedListenerOf_widget_2_0(PropertyOwnerObject propertyOwnerObject, string propertyName, uint e)
	{
		HandleWidgetPropertyChangeOf_widget_2_0(propertyName);
	}

	private void ColorPropertyChangedListenerOf_widget_2_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Color e)
	{
		HandleWidgetPropertyChangeOf_widget_2_0(propertyName);
	}

	private void HandleWidgetPropertyChangeOf_widget_2_0(string propertyName)
	{
		if (propertyName == "MaxValueInt")
		{
			_datasource_Root.MaxReserveAmount = _widget_2_0.MaxValueInt;
		}
		else if (propertyName == "ValueInt")
		{
			_datasource_Root.CurrentGivenAmount = _widget_2_0.ValueInt;
		}
	}

	private void PropertyChangedListenerOf_widget_2_2(PropertyOwnerObject propertyOwnerObject, string propertyName, object e)
	{
		HandleWidgetPropertyChangeOf_widget_2_2(propertyName);
	}

	private void boolPropertyChangedListenerOf_widget_2_2(PropertyOwnerObject propertyOwnerObject, string propertyName, bool e)
	{
		HandleWidgetPropertyChangeOf_widget_2_2(propertyName);
	}

	private void floatPropertyChangedListenerOf_widget_2_2(PropertyOwnerObject propertyOwnerObject, string propertyName, float e)
	{
		HandleWidgetPropertyChangeOf_widget_2_2(propertyName);
	}

	private void Vec2PropertyChangedListenerOf_widget_2_2(PropertyOwnerObject propertyOwnerObject, string propertyName, Vec2 e)
	{
		HandleWidgetPropertyChangeOf_widget_2_2(propertyName);
	}

	private void Vector2PropertyChangedListenerOf_widget_2_2(PropertyOwnerObject propertyOwnerObject, string propertyName, Vector2 e)
	{
		HandleWidgetPropertyChangeOf_widget_2_2(propertyName);
	}

	private void doublePropertyChangedListenerOf_widget_2_2(PropertyOwnerObject propertyOwnerObject, string propertyName, double e)
	{
		HandleWidgetPropertyChangeOf_widget_2_2(propertyName);
	}

	private void intPropertyChangedListenerOf_widget_2_2(PropertyOwnerObject propertyOwnerObject, string propertyName, int e)
	{
		HandleWidgetPropertyChangeOf_widget_2_2(propertyName);
	}

	private void uintPropertyChangedListenerOf_widget_2_2(PropertyOwnerObject propertyOwnerObject, string propertyName, uint e)
	{
		HandleWidgetPropertyChangeOf_widget_2_2(propertyName);
	}

	private void ColorPropertyChangedListenerOf_widget_2_2(PropertyOwnerObject propertyOwnerObject, string propertyName, Color e)
	{
		HandleWidgetPropertyChangeOf_widget_2_2(propertyName);
	}

	private void HandleWidgetPropertyChangeOf_widget_2_2(string propertyName)
	{
		if (propertyName == "Text")
		{
			_datasource_Root.CurrentReserveText = _widget_2_2.Text;
		}
	}

	private void PropertyChangedListenerOf_widget_2_3(PropertyOwnerObject propertyOwnerObject, string propertyName, object e)
	{
		HandleWidgetPropertyChangeOf_widget_2_3(propertyName);
	}

	private void boolPropertyChangedListenerOf_widget_2_3(PropertyOwnerObject propertyOwnerObject, string propertyName, bool e)
	{
		HandleWidgetPropertyChangeOf_widget_2_3(propertyName);
	}

	private void floatPropertyChangedListenerOf_widget_2_3(PropertyOwnerObject propertyOwnerObject, string propertyName, float e)
	{
		HandleWidgetPropertyChangeOf_widget_2_3(propertyName);
	}

	private void Vec2PropertyChangedListenerOf_widget_2_3(PropertyOwnerObject propertyOwnerObject, string propertyName, Vec2 e)
	{
		HandleWidgetPropertyChangeOf_widget_2_3(propertyName);
	}

	private void Vector2PropertyChangedListenerOf_widget_2_3(PropertyOwnerObject propertyOwnerObject, string propertyName, Vector2 e)
	{
		HandleWidgetPropertyChangeOf_widget_2_3(propertyName);
	}

	private void doublePropertyChangedListenerOf_widget_2_3(PropertyOwnerObject propertyOwnerObject, string propertyName, double e)
	{
		HandleWidgetPropertyChangeOf_widget_2_3(propertyName);
	}

	private void intPropertyChangedListenerOf_widget_2_3(PropertyOwnerObject propertyOwnerObject, string propertyName, int e)
	{
		HandleWidgetPropertyChangeOf_widget_2_3(propertyName);
	}

	private void uintPropertyChangedListenerOf_widget_2_3(PropertyOwnerObject propertyOwnerObject, string propertyName, uint e)
	{
		HandleWidgetPropertyChangeOf_widget_2_3(propertyName);
	}

	private void ColorPropertyChangedListenerOf_widget_2_3(PropertyOwnerObject propertyOwnerObject, string propertyName, Color e)
	{
		HandleWidgetPropertyChangeOf_widget_2_3(propertyName);
	}

	private void HandleWidgetPropertyChangeOf_widget_2_3(string propertyName)
	{
		if (propertyName == "IntText")
		{
			_datasource_Root.MaxReserveAmount = _widget_2_3.IntText;
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
		case "IsEnabled":
			_widget.IsVisible = _datasource_Root.IsEnabled;
			break;
		case "MaxReserveAmount":
			_widget_2_0.MaxValueInt = _datasource_Root.MaxReserveAmount;
			_widget_2_3.IntText = _datasource_Root.MaxReserveAmount;
			break;
		case "CurrentGivenAmount":
			_widget_2_0.ValueInt = _datasource_Root.CurrentGivenAmount;
			break;
		case "CurrentReserveText":
			_widget_2_2.Text = _datasource_Root.CurrentReserveText;
			break;
		}
	}

	private void RefreshDataSource_datasource_Root(TownManagementReserveControlVM newDataSource)
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
			_widget.PropertyChanged -= PropertyChangedListenerOf_widget;
			_widget.boolPropertyChanged -= boolPropertyChangedListenerOf_widget;
			_widget.floatPropertyChanged -= floatPropertyChangedListenerOf_widget;
			_widget.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget;
			_widget.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget;
			_widget.doublePropertyChanged -= doublePropertyChangedListenerOf_widget;
			_widget.intPropertyChanged -= intPropertyChangedListenerOf_widget;
			_widget.uintPropertyChanged -= uintPropertyChangedListenerOf_widget;
			_widget.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget;
			_widget_2.EventFire -= EventListenerOf_widget_2;
			_widget_2_0.PropertyChanged -= PropertyChangedListenerOf_widget_2_0;
			_widget_2_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_2_0;
			_widget_2_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_2_0;
			_widget_2_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_2_0;
			_widget_2_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_2_0;
			_widget_2_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_2_0;
			_widget_2_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_2_0;
			_widget_2_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_2_0;
			_widget_2_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_2_0;
			_widget_2_2.PropertyChanged -= PropertyChangedListenerOf_widget_2_2;
			_widget_2_2.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_2_2;
			_widget_2_2.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_2_2;
			_widget_2_2.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_2_2;
			_widget_2_2.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_2_2;
			_widget_2_2.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_2_2;
			_widget_2_2.intPropertyChanged -= intPropertyChangedListenerOf_widget_2_2;
			_widget_2_2.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_2_2;
			_widget_2_2.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_2_2;
			_widget_2_3.PropertyChanged -= PropertyChangedListenerOf_widget_2_3;
			_widget_2_3.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_2_3;
			_widget_2_3.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_2_3;
			_widget_2_3.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_2_3;
			_widget_2_3.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_2_3;
			_widget_2_3.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_2_3;
			_widget_2_3.intPropertyChanged -= intPropertyChangedListenerOf_widget_2_3;
			_widget_2_3.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_2_3;
			_widget_2_3.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_2_3;
			_widget_2_4.EventFire -= EventListenerOf_widget_2_4;
			_datasource_Root = null;
		}
		_datasource_Root = newDataSource;
		if (_datasource_Root != null)
		{
			_datasource_Root.PropertyChanged += ViewModelPropertyChangedListenerOf_datasource_Root;
			_datasource_Root.PropertyChangedWithValue += ViewModelPropertyChangedWithValueListenerOf_datasource_Root;
			_datasource_Root.PropertyChangedWithBoolValue += ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root;
			_datasource_Root.PropertyChangedWithIntValue += ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root;
			_datasource_Root.PropertyChangedWithFloatValue += ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root;
			_datasource_Root.PropertyChangedWithUIntValue += ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root;
			_datasource_Root.PropertyChangedWithColorValue += ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root;
			_datasource_Root.PropertyChangedWithDoubleValue += ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root;
			_datasource_Root.PropertyChangedWithVec2Value += ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root;
			_widget.IsVisible = _datasource_Root.IsEnabled;
			_widget.PropertyChanged += PropertyChangedListenerOf_widget;
			_widget.boolPropertyChanged += boolPropertyChangedListenerOf_widget;
			_widget.floatPropertyChanged += floatPropertyChangedListenerOf_widget;
			_widget.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget;
			_widget.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget;
			_widget.doublePropertyChanged += doublePropertyChangedListenerOf_widget;
			_widget.intPropertyChanged += intPropertyChangedListenerOf_widget;
			_widget.uintPropertyChanged += uintPropertyChangedListenerOf_widget;
			_widget.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget;
			_widget_2.EventFire += EventListenerOf_widget_2;
			_widget_2_0.MaxValueInt = _datasource_Root.MaxReserveAmount;
			_widget_2_0.ValueInt = _datasource_Root.CurrentGivenAmount;
			_widget_2_0.PropertyChanged += PropertyChangedListenerOf_widget_2_0;
			_widget_2_0.boolPropertyChanged += boolPropertyChangedListenerOf_widget_2_0;
			_widget_2_0.floatPropertyChanged += floatPropertyChangedListenerOf_widget_2_0;
			_widget_2_0.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_2_0;
			_widget_2_0.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_2_0;
			_widget_2_0.doublePropertyChanged += doublePropertyChangedListenerOf_widget_2_0;
			_widget_2_0.intPropertyChanged += intPropertyChangedListenerOf_widget_2_0;
			_widget_2_0.uintPropertyChanged += uintPropertyChangedListenerOf_widget_2_0;
			_widget_2_0.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_2_0;
			_widget_2_2.Text = _datasource_Root.CurrentReserveText;
			_widget_2_2.PropertyChanged += PropertyChangedListenerOf_widget_2_2;
			_widget_2_2.boolPropertyChanged += boolPropertyChangedListenerOf_widget_2_2;
			_widget_2_2.floatPropertyChanged += floatPropertyChangedListenerOf_widget_2_2;
			_widget_2_2.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_2_2;
			_widget_2_2.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_2_2;
			_widget_2_2.doublePropertyChanged += doublePropertyChangedListenerOf_widget_2_2;
			_widget_2_2.intPropertyChanged += intPropertyChangedListenerOf_widget_2_2;
			_widget_2_2.uintPropertyChanged += uintPropertyChangedListenerOf_widget_2_2;
			_widget_2_2.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_2_2;
			_widget_2_3.IntText = _datasource_Root.MaxReserveAmount;
			_widget_2_3.PropertyChanged += PropertyChangedListenerOf_widget_2_3;
			_widget_2_3.boolPropertyChanged += boolPropertyChangedListenerOf_widget_2_3;
			_widget_2_3.floatPropertyChanged += floatPropertyChangedListenerOf_widget_2_3;
			_widget_2_3.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_2_3;
			_widget_2_3.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_2_3;
			_widget_2_3.doublePropertyChanged += doublePropertyChangedListenerOf_widget_2_3;
			_widget_2_3.intPropertyChanged += intPropertyChangedListenerOf_widget_2_3;
			_widget_2_3.uintPropertyChanged += uintPropertyChangedListenerOf_widget_2_3;
			_widget_2_3.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_2_3;
			_widget_2_4.EventFire += EventListenerOf_widget_2_4;
		}
	}
}