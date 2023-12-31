using System.ComponentModel;
using System.Numerics;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets.EscapeMenu;
using TaleWorlds.MountAndBlade.ViewModelCollection.EscapeMenu;

namespace TaleWorlds.MountAndBlade.GauntletUI.AutoGenerated1;

public class EscapeMenu__TaleWorlds_MountAndBlade_ViewModelCollection_EscapeMenu_EscapeMenuVM_Dependency_1_ItemTemplate : Widget
{
	private Widget _widget;

	private EscapeMenuButtonWidget _widget_0;

	private TextWidget _widget_0_0;

	private Widget _widget_1;

	private HintWidget _widget_1_0;

	private EscapeMenuItemVM _datasource_Root;

	private HintViewModel _datasource_Root_DisabledHint;

	public EscapeMenu__TaleWorlds_MountAndBlade_ViewModelCollection_EscapeMenu_EscapeMenuVM_Dependency_1_ItemTemplate(UIContext context)
		: base(context)
	{
	}

	public void CreateWidgets()
	{
		_widget = this;
		_widget_0 = new EscapeMenuButtonWidget(base.Context);
		_widget.AddChild(_widget_0);
		_widget_0_0 = new TextWidget(base.Context);
		_widget_0.AddChild(_widget_0_0);
		_widget_1 = new Widget(base.Context);
		_widget.AddChild(_widget_1);
		_widget_1_0 = new HintWidget(base.Context);
		_widget_1.AddChild(_widget_1_0);
	}

	public void SetIds()
	{
	}

	public void SetAttributes()
	{
		base.WidthSizePolicy = SizePolicy.Fixed;
		base.HeightSizePolicy = SizePolicy.Fixed;
		base.SuggestedWidth = 227f;
		base.SuggestedHeight = 40f;
		base.HorizontalAlignment = HorizontalAlignment.Center;
		base.VerticalAlignment = VerticalAlignment.Center;
		base.MarginBottom = 30f;
		base.UseSiblingIndexForNavigation = true;
		_widget_0.DoNotPassEventsToChildren = true;
		_widget_0.WidthSizePolicy = SizePolicy.StretchToParent;
		_widget_0.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_0.Brush = base.Context.GetBrush("ButtonBrush2");
		_widget_0.PositiveBehaviorBrush = base.Context.GetBrush("ButtonBrush1");
		_widget_0_0.WidthSizePolicy = SizePolicy.StretchToParent;
		_widget_0_0.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_0_0.PositionYOffset = 1f;
		_widget_0_0.Brush = base.Context.GetBrush("OverlayPopup.ButtonText");
		_widget_0_0.ClipContents = false;
		_widget_1.WidthSizePolicy = SizePolicy.StretchToParent;
		_widget_1.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_1_0.WidthSizePolicy = SizePolicy.StretchToParent;
		_widget_1_0.HeightSizePolicy = SizePolicy.StretchToParent;
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
			_widget_0.EventFire -= EventListenerOf_widget_0;
			_widget_0.PropertyChanged -= PropertyChangedListenerOf_widget_0;
			_widget_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0;
			_widget_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0;
			_widget_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0;
			_widget_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0;
			_widget_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0;
			_widget_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0;
			_widget_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0;
			_widget_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0;
			_widget_0_0.PropertyChanged -= PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_0;
			_widget_0_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_0;
			_widget_1.PropertyChanged -= PropertyChangedListenerOf_widget_1;
			_widget_1.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_1;
			_widget_1.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_1;
			_widget_1.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_1;
			_widget_1.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_1;
			_widget_1.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_1;
			_widget_1.intPropertyChanged -= intPropertyChangedListenerOf_widget_1;
			_widget_1.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_1;
			_widget_1.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_1;
			if (_datasource_Root_DisabledHint != null)
			{
				_datasource_Root_DisabledHint.PropertyChanged -= ViewModelPropertyChangedListenerOf_datasource_Root_DisabledHint;
				_datasource_Root_DisabledHint.PropertyChangedWithValue -= ViewModelPropertyChangedWithValueListenerOf_datasource_Root_DisabledHint;
				_datasource_Root_DisabledHint.PropertyChangedWithBoolValue -= ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_DisabledHint;
				_datasource_Root_DisabledHint.PropertyChangedWithIntValue -= ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_DisabledHint;
				_datasource_Root_DisabledHint.PropertyChangedWithFloatValue -= ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_DisabledHint;
				_datasource_Root_DisabledHint.PropertyChangedWithUIntValue -= ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_DisabledHint;
				_datasource_Root_DisabledHint.PropertyChangedWithColorValue -= ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_DisabledHint;
				_datasource_Root_DisabledHint.PropertyChangedWithDoubleValue -= ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_DisabledHint;
				_datasource_Root_DisabledHint.PropertyChangedWithVec2Value -= ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_DisabledHint;
				_widget_1_0.EventFire -= EventListenerOf_widget_1_0;
				_datasource_Root_DisabledHint = null;
			}
			_datasource_Root = null;
		}
	}

	public void SetDataSource(EscapeMenuItemVM dataSource)
	{
		RefreshDataSource_datasource_Root(dataSource);
	}

	private void EventListenerOf_widget_0(Widget widget, string commandName, object[] args)
	{
		if (commandName == "Click")
		{
			_datasource_Root.ExecuteAction();
		}
	}

	private void EventListenerOf_widget_1_0(Widget widget, string commandName, object[] args)
	{
		if (commandName == "HoverBegin")
		{
			_datasource_Root_DisabledHint.ExecuteBeginHint();
		}
		if (commandName == "HoverEnd")
		{
			_datasource_Root_DisabledHint.ExecuteEndHint();
		}
	}

	private void PropertyChangedListenerOf_widget_0(PropertyOwnerObject propertyOwnerObject, string propertyName, object e)
	{
		HandleWidgetPropertyChangeOf_widget_0(propertyName);
	}

	private void boolPropertyChangedListenerOf_widget_0(PropertyOwnerObject propertyOwnerObject, string propertyName, bool e)
	{
		HandleWidgetPropertyChangeOf_widget_0(propertyName);
	}

	private void floatPropertyChangedListenerOf_widget_0(PropertyOwnerObject propertyOwnerObject, string propertyName, float e)
	{
		HandleWidgetPropertyChangeOf_widget_0(propertyName);
	}

	private void Vec2PropertyChangedListenerOf_widget_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Vec2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0(propertyName);
	}

	private void Vector2PropertyChangedListenerOf_widget_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Vector2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0(propertyName);
	}

	private void doublePropertyChangedListenerOf_widget_0(PropertyOwnerObject propertyOwnerObject, string propertyName, double e)
	{
		HandleWidgetPropertyChangeOf_widget_0(propertyName);
	}

	private void intPropertyChangedListenerOf_widget_0(PropertyOwnerObject propertyOwnerObject, string propertyName, int e)
	{
		HandleWidgetPropertyChangeOf_widget_0(propertyName);
	}

	private void uintPropertyChangedListenerOf_widget_0(PropertyOwnerObject propertyOwnerObject, string propertyName, uint e)
	{
		HandleWidgetPropertyChangeOf_widget_0(propertyName);
	}

	private void ColorPropertyChangedListenerOf_widget_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Color e)
	{
		HandleWidgetPropertyChangeOf_widget_0(propertyName);
	}

	private void HandleWidgetPropertyChangeOf_widget_0(string propertyName)
	{
		if (propertyName == "IsDisabled")
		{
			_datasource_Root.IsDisabled = _widget_0.IsDisabled;
		}
		else if (propertyName == "IsPositiveBehaviored")
		{
			_datasource_Root.IsPositiveBehaviored = _widget_0.IsPositiveBehaviored;
		}
	}

	private void PropertyChangedListenerOf_widget_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, object e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0(propertyName);
	}

	private void boolPropertyChangedListenerOf_widget_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, bool e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0(propertyName);
	}

	private void floatPropertyChangedListenerOf_widget_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, float e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0(propertyName);
	}

	private void Vec2PropertyChangedListenerOf_widget_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Vec2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0(propertyName);
	}

	private void Vector2PropertyChangedListenerOf_widget_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Vector2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0(propertyName);
	}

	private void doublePropertyChangedListenerOf_widget_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, double e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0(propertyName);
	}

	private void intPropertyChangedListenerOf_widget_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, int e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0(propertyName);
	}

	private void uintPropertyChangedListenerOf_widget_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, uint e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0(propertyName);
	}

	private void ColorPropertyChangedListenerOf_widget_0_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Color e)
	{
		HandleWidgetPropertyChangeOf_widget_0_0(propertyName);
	}

	private void HandleWidgetPropertyChangeOf_widget_0_0(string propertyName)
	{
		if (propertyName == "Text")
		{
			_datasource_Root.ActionText = _widget_0_0.Text;
		}
	}

	private void PropertyChangedListenerOf_widget_1(PropertyOwnerObject propertyOwnerObject, string propertyName, object e)
	{
		HandleWidgetPropertyChangeOf_widget_1(propertyName);
	}

	private void boolPropertyChangedListenerOf_widget_1(PropertyOwnerObject propertyOwnerObject, string propertyName, bool e)
	{
		HandleWidgetPropertyChangeOf_widget_1(propertyName);
	}

	private void floatPropertyChangedListenerOf_widget_1(PropertyOwnerObject propertyOwnerObject, string propertyName, float e)
	{
		HandleWidgetPropertyChangeOf_widget_1(propertyName);
	}

	private void Vec2PropertyChangedListenerOf_widget_1(PropertyOwnerObject propertyOwnerObject, string propertyName, Vec2 e)
	{
		HandleWidgetPropertyChangeOf_widget_1(propertyName);
	}

	private void Vector2PropertyChangedListenerOf_widget_1(PropertyOwnerObject propertyOwnerObject, string propertyName, Vector2 e)
	{
		HandleWidgetPropertyChangeOf_widget_1(propertyName);
	}

	private void doublePropertyChangedListenerOf_widget_1(PropertyOwnerObject propertyOwnerObject, string propertyName, double e)
	{
		HandleWidgetPropertyChangeOf_widget_1(propertyName);
	}

	private void intPropertyChangedListenerOf_widget_1(PropertyOwnerObject propertyOwnerObject, string propertyName, int e)
	{
		HandleWidgetPropertyChangeOf_widget_1(propertyName);
	}

	private void uintPropertyChangedListenerOf_widget_1(PropertyOwnerObject propertyOwnerObject, string propertyName, uint e)
	{
		HandleWidgetPropertyChangeOf_widget_1(propertyName);
	}

	private void ColorPropertyChangedListenerOf_widget_1(PropertyOwnerObject propertyOwnerObject, string propertyName, Color e)
	{
		HandleWidgetPropertyChangeOf_widget_1(propertyName);
	}

	private void HandleWidgetPropertyChangeOf_widget_1(string propertyName)
	{
		if (propertyName == "IsVisible")
		{
			_datasource_Root.IsDisabled = _widget_1.IsVisible;
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
		case "DisabledHint":
			RefreshDataSource_datasource_Root_DisabledHint(_datasource_Root.DisabledHint);
			break;
		case "IsDisabled":
			_widget_0.IsDisabled = _datasource_Root.IsDisabled;
			_widget_1.IsVisible = _datasource_Root.IsDisabled;
			break;
		case "IsPositiveBehaviored":
			_widget_0.IsPositiveBehaviored = _datasource_Root.IsPositiveBehaviored;
			break;
		case "ActionText":
			_widget_0_0.Text = _datasource_Root.ActionText;
			break;
		}
	}

	private void ViewModelPropertyChangedListenerOf_datasource_Root_DisabledHint(object sender, PropertyChangedEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_DisabledHint(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithValueListenerOf_datasource_Root_DisabledHint(object sender, PropertyChangedWithValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_DisabledHint(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_DisabledHint(object sender, PropertyChangedWithBoolValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_DisabledHint(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_DisabledHint(object sender, PropertyChangedWithIntValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_DisabledHint(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_DisabledHint(object sender, PropertyChangedWithFloatValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_DisabledHint(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_DisabledHint(object sender, PropertyChangedWithUIntValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_DisabledHint(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_DisabledHint(object sender, PropertyChangedWithColorValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_DisabledHint(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_DisabledHint(object sender, PropertyChangedWithDoubleValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_DisabledHint(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_DisabledHint(object sender, PropertyChangedWithVec2ValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_DisabledHint(e.PropertyName);
	}

	private void HandleViewModelPropertyChangeOf_datasource_Root_DisabledHint(string propertyName)
	{
	}

	private void RefreshDataSource_datasource_Root(EscapeMenuItemVM newDataSource)
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
			_widget_0.EventFire -= EventListenerOf_widget_0;
			_widget_0.PropertyChanged -= PropertyChangedListenerOf_widget_0;
			_widget_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0;
			_widget_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0;
			_widget_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0;
			_widget_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0;
			_widget_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0;
			_widget_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0;
			_widget_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0;
			_widget_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0;
			_widget_0_0.PropertyChanged -= PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_0;
			_widget_0_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_0;
			_widget_1.PropertyChanged -= PropertyChangedListenerOf_widget_1;
			_widget_1.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_1;
			_widget_1.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_1;
			_widget_1.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_1;
			_widget_1.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_1;
			_widget_1.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_1;
			_widget_1.intPropertyChanged -= intPropertyChangedListenerOf_widget_1;
			_widget_1.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_1;
			_widget_1.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_1;
			if (_datasource_Root_DisabledHint != null)
			{
				_datasource_Root_DisabledHint.PropertyChanged -= ViewModelPropertyChangedListenerOf_datasource_Root_DisabledHint;
				_datasource_Root_DisabledHint.PropertyChangedWithValue -= ViewModelPropertyChangedWithValueListenerOf_datasource_Root_DisabledHint;
				_datasource_Root_DisabledHint.PropertyChangedWithBoolValue -= ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_DisabledHint;
				_datasource_Root_DisabledHint.PropertyChangedWithIntValue -= ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_DisabledHint;
				_datasource_Root_DisabledHint.PropertyChangedWithFloatValue -= ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_DisabledHint;
				_datasource_Root_DisabledHint.PropertyChangedWithUIntValue -= ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_DisabledHint;
				_datasource_Root_DisabledHint.PropertyChangedWithColorValue -= ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_DisabledHint;
				_datasource_Root_DisabledHint.PropertyChangedWithDoubleValue -= ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_DisabledHint;
				_datasource_Root_DisabledHint.PropertyChangedWithVec2Value -= ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_DisabledHint;
				_widget_1_0.EventFire -= EventListenerOf_widget_1_0;
				_datasource_Root_DisabledHint = null;
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
			_widget_0.IsDisabled = _datasource_Root.IsDisabled;
			_widget_0.IsPositiveBehaviored = _datasource_Root.IsPositiveBehaviored;
			_widget_0.EventFire += EventListenerOf_widget_0;
			_widget_0.PropertyChanged += PropertyChangedListenerOf_widget_0;
			_widget_0.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0;
			_widget_0.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0;
			_widget_0.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0;
			_widget_0.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0;
			_widget_0.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0;
			_widget_0.intPropertyChanged += intPropertyChangedListenerOf_widget_0;
			_widget_0.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0;
			_widget_0.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0;
			_widget_0_0.Text = _datasource_Root.ActionText;
			_widget_0_0.PropertyChanged += PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_0;
			_widget_0_0.intPropertyChanged += intPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_0;
			_widget_1.IsVisible = _datasource_Root.IsDisabled;
			_widget_1.PropertyChanged += PropertyChangedListenerOf_widget_1;
			_widget_1.boolPropertyChanged += boolPropertyChangedListenerOf_widget_1;
			_widget_1.floatPropertyChanged += floatPropertyChangedListenerOf_widget_1;
			_widget_1.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_1;
			_widget_1.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_1;
			_widget_1.doublePropertyChanged += doublePropertyChangedListenerOf_widget_1;
			_widget_1.intPropertyChanged += intPropertyChangedListenerOf_widget_1;
			_widget_1.uintPropertyChanged += uintPropertyChangedListenerOf_widget_1;
			_widget_1.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_1;
			_datasource_Root_DisabledHint = _datasource_Root.DisabledHint;
			if (_datasource_Root_DisabledHint != null)
			{
				_datasource_Root_DisabledHint.PropertyChanged += ViewModelPropertyChangedListenerOf_datasource_Root_DisabledHint;
				_datasource_Root_DisabledHint.PropertyChangedWithValue += ViewModelPropertyChangedWithValueListenerOf_datasource_Root_DisabledHint;
				_datasource_Root_DisabledHint.PropertyChangedWithBoolValue += ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_DisabledHint;
				_datasource_Root_DisabledHint.PropertyChangedWithIntValue += ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_DisabledHint;
				_datasource_Root_DisabledHint.PropertyChangedWithFloatValue += ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_DisabledHint;
				_datasource_Root_DisabledHint.PropertyChangedWithUIntValue += ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_DisabledHint;
				_datasource_Root_DisabledHint.PropertyChangedWithColorValue += ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_DisabledHint;
				_datasource_Root_DisabledHint.PropertyChangedWithDoubleValue += ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_DisabledHint;
				_datasource_Root_DisabledHint.PropertyChangedWithVec2Value += ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_DisabledHint;
				_widget_1_0.EventFire += EventListenerOf_widget_1_0;
			}
		}
	}

	private void RefreshDataSource_datasource_Root_DisabledHint(HintViewModel newDataSource)
	{
		if (_datasource_Root_DisabledHint != null)
		{
			_datasource_Root_DisabledHint.PropertyChanged -= ViewModelPropertyChangedListenerOf_datasource_Root_DisabledHint;
			_datasource_Root_DisabledHint.PropertyChangedWithValue -= ViewModelPropertyChangedWithValueListenerOf_datasource_Root_DisabledHint;
			_datasource_Root_DisabledHint.PropertyChangedWithBoolValue -= ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_DisabledHint;
			_datasource_Root_DisabledHint.PropertyChangedWithIntValue -= ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_DisabledHint;
			_datasource_Root_DisabledHint.PropertyChangedWithFloatValue -= ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_DisabledHint;
			_datasource_Root_DisabledHint.PropertyChangedWithUIntValue -= ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_DisabledHint;
			_datasource_Root_DisabledHint.PropertyChangedWithColorValue -= ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_DisabledHint;
			_datasource_Root_DisabledHint.PropertyChangedWithDoubleValue -= ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_DisabledHint;
			_datasource_Root_DisabledHint.PropertyChangedWithVec2Value -= ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_DisabledHint;
			_widget_1_0.EventFire -= EventListenerOf_widget_1_0;
			_datasource_Root_DisabledHint = null;
		}
		_datasource_Root_DisabledHint = newDataSource;
		_datasource_Root_DisabledHint = _datasource_Root.DisabledHint;
		if (_datasource_Root_DisabledHint != null)
		{
			_datasource_Root_DisabledHint.PropertyChanged += ViewModelPropertyChangedListenerOf_datasource_Root_DisabledHint;
			_datasource_Root_DisabledHint.PropertyChangedWithValue += ViewModelPropertyChangedWithValueListenerOf_datasource_Root_DisabledHint;
			_datasource_Root_DisabledHint.PropertyChangedWithBoolValue += ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_DisabledHint;
			_datasource_Root_DisabledHint.PropertyChangedWithIntValue += ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_DisabledHint;
			_datasource_Root_DisabledHint.PropertyChangedWithFloatValue += ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_DisabledHint;
			_datasource_Root_DisabledHint.PropertyChangedWithUIntValue += ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_DisabledHint;
			_datasource_Root_DisabledHint.PropertyChangedWithColorValue += ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_DisabledHint;
			_datasource_Root_DisabledHint.PropertyChangedWithDoubleValue += ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_DisabledHint;
			_datasource_Root_DisabledHint.PropertyChangedWithVec2Value += ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_DisabledHint;
			_widget_1_0.EventFire += EventListenerOf_widget_1_0;
		}
	}
}
