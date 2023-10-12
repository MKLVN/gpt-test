using System.ComponentModel;
using System.Numerics;
using TaleWorlds.CampaignSystem.ViewModelCollection.Input;
using TaleWorlds.CampaignSystem.ViewModelCollection.Quests;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.GauntletUI.ExtraWidgets;
using TaleWorlds.GauntletUI.GamepadNavigation;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets;

namespace SandBox.GauntletUI.AutoGenerated1;

public class QuestsScreen__TaleWorlds_CampaignSystem_ViewModelCollection_Quests_QuestsVM_Dependency_7_Standard_DialogCloseButtons__DependendPrefab : ListPanel
{
	private ListPanel _widget;

	private NavigationScopeTargeter _widget_0;

	private ButtonWidget _widget_1;

	private TextWidget _widget_1_0;

	private InputKeyVisualWidget _widget_1_0_0;

	private ButtonWidget _widget_2;

	private TextWidget _widget_2_0;

	private InputKeyVisualWidget _widget_2_0_0;

	private QuestsVM _datasource_Root;

	private InputKeyItemVM _datasource_Root_DoneInputKey;

	public QuestsScreen__TaleWorlds_CampaignSystem_ViewModelCollection_Quests_QuestsVM_Dependency_7_Standard_DialogCloseButtons__DependendPrefab(UIContext context)
		: base(context)
	{
	}

	public void CreateWidgets()
	{
		_widget = this;
		_widget_0 = new NavigationScopeTargeter(base.Context);
		_widget.AddChild(_widget_0);
		_widget_1 = new ButtonWidget(base.Context);
		_widget.AddChild(_widget_1);
		_widget_1_0 = new TextWidget(base.Context);
		_widget_1.AddChild(_widget_1_0);
		_widget_1_0_0 = new InputKeyVisualWidget(base.Context);
		_widget_1_0.AddChild(_widget_1_0_0);
		_widget_2 = new ButtonWidget(base.Context);
		_widget.AddChild(_widget_2);
		_widget_2_0 = new TextWidget(base.Context);
		_widget_2.AddChild(_widget_2_0);
		_widget_2_0_0 = new InputKeyVisualWidget(base.Context);
		_widget_2_0.AddChild(_widget_2_0_0);
	}

	public void SetIds()
	{
	}

	public void SetAttributes()
	{
		base.WidthSizePolicy = SizePolicy.CoverChildren;
		base.HeightSizePolicy = SizePolicy.CoverChildren;
		base.HorizontalAlignment = HorizontalAlignment.Center;
		base.VerticalAlignment = VerticalAlignment.Bottom;
		_widget_0.ScopeID = "DialogCloseButtonsScope";
		_widget_0.ScopeParent = _widget;
		_widget_0.ScopeMovements = GamepadNavigationTypes.Horizontal;
		_widget_0.HasCircularMovement = true;
		_widget_1.WidthSizePolicy = SizePolicy.Fixed;
		_widget_1.HeightSizePolicy = SizePolicy.Fixed;
		_widget_1.SuggestedWidth = 337f;
		_widget_1.SuggestedHeight = 75f;
		_widget_1.Brush = base.Context.GetBrush("Standard.DialogCloseButtons.CancelButton");
		_widget_1.IsEnabled = false;
		_widget_1.IsVisible = false;
		_widget_1.UpdateChildrenStates = true;
		_widget_1.GamepadNavigationIndex = -1;
		_widget_1_0.DoNotAcceptEvents = true;
		_widget_1_0.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_1_0.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_1_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_1_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_1_0.PositionYOffset = 13f;
		_widget_1_0.Brush = base.Context.GetBrush("Standard.DialogCloseButtons.ButtonText");
		_widget_1_0.Text = "- Missing -";
		_widget_1_0_0.DoNotAcceptEvents = true;
		_widget_1_0_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_1_0_0.HeightSizePolicy = SizePolicy.Fixed;
		_widget_1_0_0.SuggestedWidth = 48f;
		_widget_1_0_0.SuggestedHeight = 48f;
		_widget_1_0_0.HorizontalAlignment = HorizontalAlignment.Left;
		_widget_1_0_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_1_0_0.PositionXOffset = -44f;
		_widget_2.WidthSizePolicy = SizePolicy.Fixed;
		_widget_2.HeightSizePolicy = SizePolicy.Fixed;
		_widget_2.SuggestedWidth = 337f;
		_widget_2.SuggestedHeight = 75f;
		_widget_2.Brush = base.Context.GetBrush("Standard.DialogCloseButtons.DoneButton");
		_widget_2.IsEnabled = true;
		_widget_2.IsVisible = true;
		_widget_2.UpdateChildrenStates = true;
		_widget_2.GamepadNavigationIndex = -1;
		_widget_2_0.DoNotAcceptEvents = true;
		_widget_2_0.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_2_0.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_2_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_2_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_2_0.PositionYOffset = 13f;
		_widget_2_0.Brush = base.Context.GetBrush("Standard.DialogCloseButtons.ButtonText");
		_widget_2_0_0.DoNotAcceptEvents = true;
		_widget_2_0_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_2_0_0.HeightSizePolicy = SizePolicy.Fixed;
		_widget_2_0_0.SuggestedWidth = 48f;
		_widget_2_0_0.SuggestedHeight = 48f;
		_widget_2_0_0.HorizontalAlignment = HorizontalAlignment.Left;
		_widget_2_0_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_2_0_0.PositionXOffset = -44f;
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
			_widget_1.EventFire -= EventListenerOf_widget_1;
			_widget_1_0_0.PropertyChanged -= PropertyChangedListenerOf_widget_1_0_0;
			_widget_1_0_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_1_0_0;
			_widget_1_0_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_1_0_0;
			_widget_1_0_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_1_0_0;
			_widget_1_0_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_1_0_0;
			_widget_1_0_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_1_0_0;
			_widget_1_0_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_1_0_0;
			_widget_1_0_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_1_0_0;
			_widget_1_0_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_1_0_0;
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
			if (_datasource_Root_DoneInputKey != null)
			{
				_datasource_Root_DoneInputKey.PropertyChanged -= ViewModelPropertyChangedListenerOf_datasource_Root_DoneInputKey;
				_datasource_Root_DoneInputKey.PropertyChangedWithValue -= ViewModelPropertyChangedWithValueListenerOf_datasource_Root_DoneInputKey;
				_datasource_Root_DoneInputKey.PropertyChangedWithBoolValue -= ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_DoneInputKey;
				_datasource_Root_DoneInputKey.PropertyChangedWithIntValue -= ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_DoneInputKey;
				_datasource_Root_DoneInputKey.PropertyChangedWithFloatValue -= ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_DoneInputKey;
				_datasource_Root_DoneInputKey.PropertyChangedWithUIntValue -= ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_DoneInputKey;
				_datasource_Root_DoneInputKey.PropertyChangedWithColorValue -= ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_DoneInputKey;
				_datasource_Root_DoneInputKey.PropertyChangedWithDoubleValue -= ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_DoneInputKey;
				_datasource_Root_DoneInputKey.PropertyChangedWithVec2Value -= ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_DoneInputKey;
				_widget_2_0_0.PropertyChanged -= PropertyChangedListenerOf_widget_2_0_0;
				_widget_2_0_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_2_0_0;
				_widget_2_0_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_2_0_0;
				_widget_2_0_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_2_0_0;
				_widget_2_0_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_2_0_0;
				_widget_2_0_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_2_0_0;
				_widget_2_0_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_2_0_0;
				_widget_2_0_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_2_0_0;
				_widget_2_0_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_2_0_0;
				_datasource_Root_DoneInputKey = null;
			}
			_datasource_Root = null;
		}
	}

	public void SetDataSource(QuestsVM dataSource)
	{
		RefreshDataSource_datasource_Root(dataSource);
	}

	private void EventListenerOf_widget_1(Widget widget, string commandName, object[] args)
	{
		_ = commandName == "Click";
	}

	private void EventListenerOf_widget_2(Widget widget, string commandName, object[] args)
	{
		if (commandName == "Click")
		{
			_datasource_Root.ExecuteClose();
		}
	}

	private void PropertyChangedListenerOf_widget_1_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, object e)
	{
		HandleWidgetPropertyChangeOf_widget_1_0_0(propertyName);
	}

	private void boolPropertyChangedListenerOf_widget_1_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, bool e)
	{
		HandleWidgetPropertyChangeOf_widget_1_0_0(propertyName);
	}

	private void floatPropertyChangedListenerOf_widget_1_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, float e)
	{
		HandleWidgetPropertyChangeOf_widget_1_0_0(propertyName);
	}

	private void Vec2PropertyChangedListenerOf_widget_1_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Vec2 e)
	{
		HandleWidgetPropertyChangeOf_widget_1_0_0(propertyName);
	}

	private void Vector2PropertyChangedListenerOf_widget_1_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Vector2 e)
	{
		HandleWidgetPropertyChangeOf_widget_1_0_0(propertyName);
	}

	private void doublePropertyChangedListenerOf_widget_1_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, double e)
	{
		HandleWidgetPropertyChangeOf_widget_1_0_0(propertyName);
	}

	private void intPropertyChangedListenerOf_widget_1_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, int e)
	{
		HandleWidgetPropertyChangeOf_widget_1_0_0(propertyName);
	}

	private void uintPropertyChangedListenerOf_widget_1_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, uint e)
	{
		HandleWidgetPropertyChangeOf_widget_1_0_0(propertyName);
	}

	private void ColorPropertyChangedListenerOf_widget_1_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Color e)
	{
		HandleWidgetPropertyChangeOf_widget_1_0_0(propertyName);
	}

	private void HandleWidgetPropertyChangeOf_widget_1_0_0(string propertyName)
	{
		if (!(propertyName == "KeyID"))
		{
			_ = propertyName == "IsVisible";
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
		if (propertyName == "Text")
		{
			_datasource_Root.DoneLbl = _widget_2_0.Text;
		}
	}

	private void PropertyChangedListenerOf_widget_2_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, object e)
	{
		HandleWidgetPropertyChangeOf_widget_2_0_0(propertyName);
	}

	private void boolPropertyChangedListenerOf_widget_2_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, bool e)
	{
		HandleWidgetPropertyChangeOf_widget_2_0_0(propertyName);
	}

	private void floatPropertyChangedListenerOf_widget_2_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, float e)
	{
		HandleWidgetPropertyChangeOf_widget_2_0_0(propertyName);
	}

	private void Vec2PropertyChangedListenerOf_widget_2_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Vec2 e)
	{
		HandleWidgetPropertyChangeOf_widget_2_0_0(propertyName);
	}

	private void Vector2PropertyChangedListenerOf_widget_2_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Vector2 e)
	{
		HandleWidgetPropertyChangeOf_widget_2_0_0(propertyName);
	}

	private void doublePropertyChangedListenerOf_widget_2_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, double e)
	{
		HandleWidgetPropertyChangeOf_widget_2_0_0(propertyName);
	}

	private void intPropertyChangedListenerOf_widget_2_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, int e)
	{
		HandleWidgetPropertyChangeOf_widget_2_0_0(propertyName);
	}

	private void uintPropertyChangedListenerOf_widget_2_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, uint e)
	{
		HandleWidgetPropertyChangeOf_widget_2_0_0(propertyName);
	}

	private void ColorPropertyChangedListenerOf_widget_2_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Color e)
	{
		HandleWidgetPropertyChangeOf_widget_2_0_0(propertyName);
	}

	private void HandleWidgetPropertyChangeOf_widget_2_0_0(string propertyName)
	{
		if (propertyName == "KeyID")
		{
			_datasource_Root_DoneInputKey.KeyID = _widget_2_0_0.KeyID;
		}
		else if (propertyName == "IsVisible")
		{
			_datasource_Root_DoneInputKey.IsVisible = _widget_2_0_0.IsVisible;
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
		case "DoneInputKey":
			RefreshDataSource_datasource_Root_DoneInputKey(_datasource_Root.DoneInputKey);
			break;
		case "KeyID":
			break;
		case "IsVisible":
			break;
		case "DoneLbl":
			_widget_2_0.Text = _datasource_Root.DoneLbl;
			break;
		}
	}

	private void ViewModelPropertyChangedListenerOf_datasource_Root_DoneInputKey(object sender, PropertyChangedEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_DoneInputKey(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithValueListenerOf_datasource_Root_DoneInputKey(object sender, PropertyChangedWithValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_DoneInputKey(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_DoneInputKey(object sender, PropertyChangedWithBoolValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_DoneInputKey(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_DoneInputKey(object sender, PropertyChangedWithIntValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_DoneInputKey(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_DoneInputKey(object sender, PropertyChangedWithFloatValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_DoneInputKey(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_DoneInputKey(object sender, PropertyChangedWithUIntValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_DoneInputKey(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_DoneInputKey(object sender, PropertyChangedWithColorValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_DoneInputKey(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_DoneInputKey(object sender, PropertyChangedWithDoubleValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_DoneInputKey(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_DoneInputKey(object sender, PropertyChangedWithVec2ValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_DoneInputKey(e.PropertyName);
	}

	private void HandleViewModelPropertyChangeOf_datasource_Root_DoneInputKey(string propertyName)
	{
		if (propertyName == "KeyID")
		{
			_widget_2_0_0.KeyID = _datasource_Root_DoneInputKey.KeyID;
		}
		else if (propertyName == "IsVisible")
		{
			_widget_2_0_0.IsVisible = _datasource_Root_DoneInputKey.IsVisible;
		}
	}

	private void RefreshDataSource_datasource_Root(QuestsVM newDataSource)
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
			_widget_1.EventFire -= EventListenerOf_widget_1;
			_widget_1_0_0.PropertyChanged -= PropertyChangedListenerOf_widget_1_0_0;
			_widget_1_0_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_1_0_0;
			_widget_1_0_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_1_0_0;
			_widget_1_0_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_1_0_0;
			_widget_1_0_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_1_0_0;
			_widget_1_0_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_1_0_0;
			_widget_1_0_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_1_0_0;
			_widget_1_0_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_1_0_0;
			_widget_1_0_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_1_0_0;
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
			if (_datasource_Root_DoneInputKey != null)
			{
				_datasource_Root_DoneInputKey.PropertyChanged -= ViewModelPropertyChangedListenerOf_datasource_Root_DoneInputKey;
				_datasource_Root_DoneInputKey.PropertyChangedWithValue -= ViewModelPropertyChangedWithValueListenerOf_datasource_Root_DoneInputKey;
				_datasource_Root_DoneInputKey.PropertyChangedWithBoolValue -= ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_DoneInputKey;
				_datasource_Root_DoneInputKey.PropertyChangedWithIntValue -= ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_DoneInputKey;
				_datasource_Root_DoneInputKey.PropertyChangedWithFloatValue -= ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_DoneInputKey;
				_datasource_Root_DoneInputKey.PropertyChangedWithUIntValue -= ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_DoneInputKey;
				_datasource_Root_DoneInputKey.PropertyChangedWithColorValue -= ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_DoneInputKey;
				_datasource_Root_DoneInputKey.PropertyChangedWithDoubleValue -= ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_DoneInputKey;
				_datasource_Root_DoneInputKey.PropertyChangedWithVec2Value -= ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_DoneInputKey;
				_widget_2_0_0.PropertyChanged -= PropertyChangedListenerOf_widget_2_0_0;
				_widget_2_0_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_2_0_0;
				_widget_2_0_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_2_0_0;
				_widget_2_0_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_2_0_0;
				_widget_2_0_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_2_0_0;
				_widget_2_0_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_2_0_0;
				_widget_2_0_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_2_0_0;
				_widget_2_0_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_2_0_0;
				_widget_2_0_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_2_0_0;
				_datasource_Root_DoneInputKey = null;
			}
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
			_widget_1.EventFire += EventListenerOf_widget_1;
			_widget_1_0_0.PropertyChanged += PropertyChangedListenerOf_widget_1_0_0;
			_widget_1_0_0.boolPropertyChanged += boolPropertyChangedListenerOf_widget_1_0_0;
			_widget_1_0_0.floatPropertyChanged += floatPropertyChangedListenerOf_widget_1_0_0;
			_widget_1_0_0.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_1_0_0;
			_widget_1_0_0.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_1_0_0;
			_widget_1_0_0.doublePropertyChanged += doublePropertyChangedListenerOf_widget_1_0_0;
			_widget_1_0_0.intPropertyChanged += intPropertyChangedListenerOf_widget_1_0_0;
			_widget_1_0_0.uintPropertyChanged += uintPropertyChangedListenerOf_widget_1_0_0;
			_widget_1_0_0.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_1_0_0;
			_widget_2.EventFire += EventListenerOf_widget_2;
			_widget_2_0.Text = _datasource_Root.DoneLbl;
			_widget_2_0.PropertyChanged += PropertyChangedListenerOf_widget_2_0;
			_widget_2_0.boolPropertyChanged += boolPropertyChangedListenerOf_widget_2_0;
			_widget_2_0.floatPropertyChanged += floatPropertyChangedListenerOf_widget_2_0;
			_widget_2_0.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_2_0;
			_widget_2_0.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_2_0;
			_widget_2_0.doublePropertyChanged += doublePropertyChangedListenerOf_widget_2_0;
			_widget_2_0.intPropertyChanged += intPropertyChangedListenerOf_widget_2_0;
			_widget_2_0.uintPropertyChanged += uintPropertyChangedListenerOf_widget_2_0;
			_widget_2_0.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_2_0;
			_datasource_Root_DoneInputKey = _datasource_Root.DoneInputKey;
			if (_datasource_Root_DoneInputKey != null)
			{
				_datasource_Root_DoneInputKey.PropertyChanged += ViewModelPropertyChangedListenerOf_datasource_Root_DoneInputKey;
				_datasource_Root_DoneInputKey.PropertyChangedWithValue += ViewModelPropertyChangedWithValueListenerOf_datasource_Root_DoneInputKey;
				_datasource_Root_DoneInputKey.PropertyChangedWithBoolValue += ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_DoneInputKey;
				_datasource_Root_DoneInputKey.PropertyChangedWithIntValue += ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_DoneInputKey;
				_datasource_Root_DoneInputKey.PropertyChangedWithFloatValue += ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_DoneInputKey;
				_datasource_Root_DoneInputKey.PropertyChangedWithUIntValue += ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_DoneInputKey;
				_datasource_Root_DoneInputKey.PropertyChangedWithColorValue += ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_DoneInputKey;
				_datasource_Root_DoneInputKey.PropertyChangedWithDoubleValue += ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_DoneInputKey;
				_datasource_Root_DoneInputKey.PropertyChangedWithVec2Value += ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_DoneInputKey;
				_widget_2_0_0.KeyID = _datasource_Root_DoneInputKey.KeyID;
				_widget_2_0_0.IsVisible = _datasource_Root_DoneInputKey.IsVisible;
				_widget_2_0_0.PropertyChanged += PropertyChangedListenerOf_widget_2_0_0;
				_widget_2_0_0.boolPropertyChanged += boolPropertyChangedListenerOf_widget_2_0_0;
				_widget_2_0_0.floatPropertyChanged += floatPropertyChangedListenerOf_widget_2_0_0;
				_widget_2_0_0.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_2_0_0;
				_widget_2_0_0.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_2_0_0;
				_widget_2_0_0.doublePropertyChanged += doublePropertyChangedListenerOf_widget_2_0_0;
				_widget_2_0_0.intPropertyChanged += intPropertyChangedListenerOf_widget_2_0_0;
				_widget_2_0_0.uintPropertyChanged += uintPropertyChangedListenerOf_widget_2_0_0;
				_widget_2_0_0.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_2_0_0;
			}
		}
	}

	private void RefreshDataSource_datasource_Root_DoneInputKey(InputKeyItemVM newDataSource)
	{
		if (_datasource_Root_DoneInputKey != null)
		{
			_datasource_Root_DoneInputKey.PropertyChanged -= ViewModelPropertyChangedListenerOf_datasource_Root_DoneInputKey;
			_datasource_Root_DoneInputKey.PropertyChangedWithValue -= ViewModelPropertyChangedWithValueListenerOf_datasource_Root_DoneInputKey;
			_datasource_Root_DoneInputKey.PropertyChangedWithBoolValue -= ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_DoneInputKey;
			_datasource_Root_DoneInputKey.PropertyChangedWithIntValue -= ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_DoneInputKey;
			_datasource_Root_DoneInputKey.PropertyChangedWithFloatValue -= ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_DoneInputKey;
			_datasource_Root_DoneInputKey.PropertyChangedWithUIntValue -= ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_DoneInputKey;
			_datasource_Root_DoneInputKey.PropertyChangedWithColorValue -= ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_DoneInputKey;
			_datasource_Root_DoneInputKey.PropertyChangedWithDoubleValue -= ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_DoneInputKey;
			_datasource_Root_DoneInputKey.PropertyChangedWithVec2Value -= ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_DoneInputKey;
			_widget_2_0_0.PropertyChanged -= PropertyChangedListenerOf_widget_2_0_0;
			_widget_2_0_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_2_0_0;
			_widget_2_0_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_2_0_0;
			_widget_2_0_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_2_0_0;
			_widget_2_0_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_2_0_0;
			_widget_2_0_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_2_0_0;
			_widget_2_0_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_2_0_0;
			_widget_2_0_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_2_0_0;
			_widget_2_0_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_2_0_0;
			_datasource_Root_DoneInputKey = null;
		}
		_datasource_Root_DoneInputKey = newDataSource;
		_datasource_Root_DoneInputKey = _datasource_Root.DoneInputKey;
		if (_datasource_Root_DoneInputKey != null)
		{
			_datasource_Root_DoneInputKey.PropertyChanged += ViewModelPropertyChangedListenerOf_datasource_Root_DoneInputKey;
			_datasource_Root_DoneInputKey.PropertyChangedWithValue += ViewModelPropertyChangedWithValueListenerOf_datasource_Root_DoneInputKey;
			_datasource_Root_DoneInputKey.PropertyChangedWithBoolValue += ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_DoneInputKey;
			_datasource_Root_DoneInputKey.PropertyChangedWithIntValue += ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_DoneInputKey;
			_datasource_Root_DoneInputKey.PropertyChangedWithFloatValue += ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_DoneInputKey;
			_datasource_Root_DoneInputKey.PropertyChangedWithUIntValue += ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_DoneInputKey;
			_datasource_Root_DoneInputKey.PropertyChangedWithColorValue += ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_DoneInputKey;
			_datasource_Root_DoneInputKey.PropertyChangedWithDoubleValue += ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_DoneInputKey;
			_datasource_Root_DoneInputKey.PropertyChangedWithVec2Value += ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_DoneInputKey;
			_widget_2_0_0.KeyID = _datasource_Root_DoneInputKey.KeyID;
			_widget_2_0_0.IsVisible = _datasource_Root_DoneInputKey.IsVisible;
			_widget_2_0_0.PropertyChanged += PropertyChangedListenerOf_widget_2_0_0;
			_widget_2_0_0.boolPropertyChanged += boolPropertyChangedListenerOf_widget_2_0_0;
			_widget_2_0_0.floatPropertyChanged += floatPropertyChangedListenerOf_widget_2_0_0;
			_widget_2_0_0.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_2_0_0;
			_widget_2_0_0.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_2_0_0;
			_widget_2_0_0.doublePropertyChanged += doublePropertyChangedListenerOf_widget_2_0_0;
			_widget_2_0_0.intPropertyChanged += intPropertyChangedListenerOf_widget_2_0_0;
			_widget_2_0_0.uintPropertyChanged += uintPropertyChangedListenerOf_widget_2_0_0;
			_widget_2_0_0.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_2_0_0;
		}
	}
}