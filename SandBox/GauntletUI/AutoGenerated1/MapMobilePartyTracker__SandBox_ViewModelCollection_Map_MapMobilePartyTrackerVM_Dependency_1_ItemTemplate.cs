using System.ComponentModel;
using System.Numerics;
using SandBox.ViewModelCollection.Map;
using TaleWorlds.Core;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets.Map;

namespace SandBox.GauntletUI.AutoGenerated1;

public class MapMobilePartyTracker__SandBox_ViewModelCollection_Map_MapMobilePartyTrackerVM_Dependency_1_ItemTemplate : MobilePartyTrackerItemWidget
{
	private MobilePartyTrackerItemWidget _widget;

	private ButtonWidget _widget_0;

	private MaskedTextureWidget _widget_0_0;

	private Widget _widget_0_1;

	private ButtonWidget _widget_0_2;

	private ImageWidget _widget_0_2_0;

	private RichTextWidget _widget_0_3;

	private MobilePartyTrackItemVM _datasource_Root;

	private ImageIdentifierVM _datasource_Root_FactionVisual;

	public MapMobilePartyTracker__SandBox_ViewModelCollection_Map_MapMobilePartyTrackerVM_Dependency_1_ItemTemplate(UIContext context)
		: base(context)
	{
	}

	public void CreateWidgets()
	{
		_widget = this;
		_widget_0 = new ButtonWidget(base.Context);
		_widget.AddChild(_widget_0);
		_widget_0_0 = new MaskedTextureWidget(base.Context);
		_widget_0.AddChild(_widget_0_0);
		_widget_0_1 = new Widget(base.Context);
		_widget_0.AddChild(_widget_0_1);
		_widget_0_2 = new ButtonWidget(base.Context);
		_widget_0.AddChild(_widget_0_2);
		_widget_0_2_0 = new ImageWidget(base.Context);
		_widget_0_2.AddChild(_widget_0_2_0);
		_widget_0_3 = new RichTextWidget(base.Context);
		_widget_0.AddChild(_widget_0_3);
	}

	public void SetIds()
	{
		base.Id = "TrackerItemWidget";
		_widget_0.Id = "TrackerParent";
		_widget_0_0.Id = "FactionVisual";
		_widget_0_1.Id = "FrameVisualWidget";
	}

	public void SetAttributes()
	{
		base.DoNotAcceptEvents = true;
		base.WidthSizePolicy = SizePolicy.CoverChildren;
		base.HeightSizePolicy = SizePolicy.CoverChildren;
		base.FrameVisualWidget = _widget_0_1;
		_widget_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0.SuggestedWidth = 120f;
		_widget_0.ClipContents = false;
		_widget_0.UpdateChildrenStates = false;
		_widget_0_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0_0.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0_0.SuggestedWidth = 74.8f;
		_widget_0_0.SuggestedHeight = 86.5f;
		_widget_0_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_0.VerticalAlignment = VerticalAlignment.Top;
		_widget_0_0.MarginTop = 12f;
		_widget_0_0.Brush = base.Context.GetBrush("Flat.Tuple.Banner.Small.Hero");
		_widget_0_0.IsDisabled = true;
		_widget_0_0.DoNotAcceptEvents = true;
		_widget_0_1.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0_1.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0_1.SuggestedWidth = 74.8f;
		_widget_0_1.SuggestedHeight = 98f;
		_widget_0_1.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_1.IsEnabled = false;
		_widget_0_1.DoNotAcceptEvents = true;
		_widget_0_2.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0_2.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0_2.SuggestedWidth = 22f;
		_widget_0_2.SuggestedHeight = 22f;
		_widget_0_2.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_2.DominantSelectedState = true;
		_widget_0_2.UpdateChildrenStates = true;
		_widget_0_2.DoNotPassEventsToChildren = true;
		_widget_0_2.MarginTop = 1f;
		_widget_0_2_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0_2_0.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0_2_0.SuggestedWidth = 14f;
		_widget_0_2_0.SuggestedHeight = 14f;
		_widget_0_2_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_2_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_2_0.Brush = base.Context.GetBrush("MobileTracker.Ball");
		_widget_0_3.WidthSizePolicy = SizePolicy.StretchToParent;
		_widget_0_3.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0_3.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_3.VerticalAlignment = VerticalAlignment.Top;
		_widget_0_3.Brush = base.Context.GetBrush("Map.MobilePartyTracker.Name");
		_widget_0_3.MarginTop = 100f;
		_widget_0_3.ClipContents = false;
		_widget_0_3.DoNotAcceptEvents = true;
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
			_widget_0.EventFire -= EventListenerOf_widget_0;
			_widget_0_2.EventFire -= EventListenerOf_widget_0_2;
			_widget_0_2.PropertyChanged -= PropertyChangedListenerOf_widget_0_2;
			_widget_0_2.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_2;
			_widget_0_2.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_2;
			_widget_0_2.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_2;
			_widget_0_2.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_2;
			_widget_0_2.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_2;
			_widget_0_2.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_2;
			_widget_0_2.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_2;
			_widget_0_2.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_2;
			_widget_0_3.PropertyChanged -= PropertyChangedListenerOf_widget_0_3;
			_widget_0_3.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_3;
			_widget_0_3.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_3;
			_widget_0_3.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_3;
			_widget_0_3.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_3;
			_widget_0_3.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_3;
			_widget_0_3.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_3;
			_widget_0_3.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_3;
			_widget_0_3.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_3;
			if (_datasource_Root_FactionVisual != null)
			{
				_datasource_Root_FactionVisual.PropertyChanged -= ViewModelPropertyChangedListenerOf_datasource_Root_FactionVisual;
				_datasource_Root_FactionVisual.PropertyChangedWithValue -= ViewModelPropertyChangedWithValueListenerOf_datasource_Root_FactionVisual;
				_datasource_Root_FactionVisual.PropertyChangedWithBoolValue -= ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_FactionVisual;
				_datasource_Root_FactionVisual.PropertyChangedWithIntValue -= ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_FactionVisual;
				_datasource_Root_FactionVisual.PropertyChangedWithFloatValue -= ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_FactionVisual;
				_datasource_Root_FactionVisual.PropertyChangedWithUIntValue -= ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_FactionVisual;
				_datasource_Root_FactionVisual.PropertyChangedWithColorValue -= ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_FactionVisual;
				_datasource_Root_FactionVisual.PropertyChangedWithDoubleValue -= ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_FactionVisual;
				_datasource_Root_FactionVisual.PropertyChangedWithVec2Value -= ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_FactionVisual;
				_widget_0_0.PropertyChanged -= PropertyChangedListenerOf_widget_0_0;
				_widget_0_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_0;
				_widget_0_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_0;
				_widget_0_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_0;
				_widget_0_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_0;
				_widget_0_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_0;
				_widget_0_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_0;
				_widget_0_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_0;
				_widget_0_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_0;
				_datasource_Root_FactionVisual = null;
			}
			_datasource_Root = null;
		}
	}

	public void SetDataSource(MobilePartyTrackItemVM dataSource)
	{
		RefreshDataSource_datasource_Root(dataSource);
	}

	private void EventListenerOf_widget_0(Widget widget, string commandName, object[] args)
	{
		if (commandName == "Click")
		{
			_datasource_Root.ExecuteGoToPosition();
		}
		if (commandName == "HoverBegin")
		{
			_datasource_Root.ExecuteShowTooltip();
		}
		if (commandName == "HoverEnd")
		{
			_datasource_Root.ExecuteHideTooltip();
		}
	}

	private void EventListenerOf_widget_0_2(Widget widget, string commandName, object[] args)
	{
		if (commandName == "Click")
		{
			_datasource_Root.ExecuteToggleTrack();
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
		switch (propertyName)
		{
		case "Position":
			_datasource_Root.PartyPosition = _widget.Position;
			break;
		case "IsBehind":
			_datasource_Root.IsBehind = _widget.IsBehind;
			break;
		case "IsArmy":
			_datasource_Root.IsArmy = _widget.IsArmy;
			break;
		case "IsActive":
			_datasource_Root.IsEnabled = _widget.IsActive;
			break;
		case "IsTracked":
			_datasource_Root.IsTracked = _widget.IsTracked;
			break;
		}
	}

	private void PropertyChangedListenerOf_widget_0_2(PropertyOwnerObject propertyOwnerObject, string propertyName, object e)
	{
		HandleWidgetPropertyChangeOf_widget_0_2(propertyName);
	}

	private void boolPropertyChangedListenerOf_widget_0_2(PropertyOwnerObject propertyOwnerObject, string propertyName, bool e)
	{
		HandleWidgetPropertyChangeOf_widget_0_2(propertyName);
	}

	private void floatPropertyChangedListenerOf_widget_0_2(PropertyOwnerObject propertyOwnerObject, string propertyName, float e)
	{
		HandleWidgetPropertyChangeOf_widget_0_2(propertyName);
	}

	private void Vec2PropertyChangedListenerOf_widget_0_2(PropertyOwnerObject propertyOwnerObject, string propertyName, Vec2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0_2(propertyName);
	}

	private void Vector2PropertyChangedListenerOf_widget_0_2(PropertyOwnerObject propertyOwnerObject, string propertyName, Vector2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0_2(propertyName);
	}

	private void doublePropertyChangedListenerOf_widget_0_2(PropertyOwnerObject propertyOwnerObject, string propertyName, double e)
	{
		HandleWidgetPropertyChangeOf_widget_0_2(propertyName);
	}

	private void intPropertyChangedListenerOf_widget_0_2(PropertyOwnerObject propertyOwnerObject, string propertyName, int e)
	{
		HandleWidgetPropertyChangeOf_widget_0_2(propertyName);
	}

	private void uintPropertyChangedListenerOf_widget_0_2(PropertyOwnerObject propertyOwnerObject, string propertyName, uint e)
	{
		HandleWidgetPropertyChangeOf_widget_0_2(propertyName);
	}

	private void ColorPropertyChangedListenerOf_widget_0_2(PropertyOwnerObject propertyOwnerObject, string propertyName, Color e)
	{
		HandleWidgetPropertyChangeOf_widget_0_2(propertyName);
	}

	private void HandleWidgetPropertyChangeOf_widget_0_2(string propertyName)
	{
		if (propertyName == "IsSelected")
		{
			_datasource_Root.IsTracked = _widget_0_2.IsSelected;
		}
	}

	private void PropertyChangedListenerOf_widget_0_3(PropertyOwnerObject propertyOwnerObject, string propertyName, object e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3(propertyName);
	}

	private void boolPropertyChangedListenerOf_widget_0_3(PropertyOwnerObject propertyOwnerObject, string propertyName, bool e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3(propertyName);
	}

	private void floatPropertyChangedListenerOf_widget_0_3(PropertyOwnerObject propertyOwnerObject, string propertyName, float e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3(propertyName);
	}

	private void Vec2PropertyChangedListenerOf_widget_0_3(PropertyOwnerObject propertyOwnerObject, string propertyName, Vec2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3(propertyName);
	}

	private void Vector2PropertyChangedListenerOf_widget_0_3(PropertyOwnerObject propertyOwnerObject, string propertyName, Vector2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3(propertyName);
	}

	private void doublePropertyChangedListenerOf_widget_0_3(PropertyOwnerObject propertyOwnerObject, string propertyName, double e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3(propertyName);
	}

	private void intPropertyChangedListenerOf_widget_0_3(PropertyOwnerObject propertyOwnerObject, string propertyName, int e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3(propertyName);
	}

	private void uintPropertyChangedListenerOf_widget_0_3(PropertyOwnerObject propertyOwnerObject, string propertyName, uint e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3(propertyName);
	}

	private void ColorPropertyChangedListenerOf_widget_0_3(PropertyOwnerObject propertyOwnerObject, string propertyName, Color e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3(propertyName);
	}

	private void HandleWidgetPropertyChangeOf_widget_0_3(string propertyName)
	{
		if (propertyName == "Text")
		{
			_datasource_Root.Name = _widget_0_3.Text;
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
		if (!(propertyName == "AdditionalArgs") && !(propertyName == "ImageId"))
		{
			_ = propertyName == "ImageTypeCode";
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
		case "FactionVisual":
			RefreshDataSource_datasource_Root_FactionVisual(_datasource_Root.FactionVisual);
			break;
		case "PartyPosition":
			_widget.Position = _datasource_Root.PartyPosition;
			break;
		case "IsBehind":
			_widget.IsBehind = _datasource_Root.IsBehind;
			break;
		case "IsArmy":
			_widget.IsArmy = _datasource_Root.IsArmy;
			break;
		case "IsEnabled":
			_widget.IsActive = _datasource_Root.IsEnabled;
			break;
		case "IsTracked":
			_widget.IsTracked = _datasource_Root.IsTracked;
			_widget_0_2.IsSelected = _datasource_Root.IsTracked;
			break;
		case "Name":
			_widget_0_3.Text = _datasource_Root.Name;
			break;
		}
	}

	private void ViewModelPropertyChangedListenerOf_datasource_Root_FactionVisual(object sender, PropertyChangedEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_FactionVisual(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithValueListenerOf_datasource_Root_FactionVisual(object sender, PropertyChangedWithValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_FactionVisual(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_FactionVisual(object sender, PropertyChangedWithBoolValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_FactionVisual(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_FactionVisual(object sender, PropertyChangedWithIntValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_FactionVisual(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_FactionVisual(object sender, PropertyChangedWithFloatValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_FactionVisual(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_FactionVisual(object sender, PropertyChangedWithUIntValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_FactionVisual(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_FactionVisual(object sender, PropertyChangedWithColorValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_FactionVisual(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_FactionVisual(object sender, PropertyChangedWithDoubleValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_FactionVisual(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_FactionVisual(object sender, PropertyChangedWithVec2ValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_FactionVisual(e.PropertyName);
	}

	private void HandleViewModelPropertyChangeOf_datasource_Root_FactionVisual(string propertyName)
	{
		switch (propertyName)
		{
		case "AdditionalArgs":
			_widget_0_0.AdditionalArgs = _datasource_Root_FactionVisual.AdditionalArgs;
			break;
		case "Id":
			_widget_0_0.ImageId = _datasource_Root_FactionVisual.Id;
			break;
		case "ImageTypeCode":
			_widget_0_0.ImageTypeCode = _datasource_Root_FactionVisual.ImageTypeCode;
			break;
		}
	}

	private void RefreshDataSource_datasource_Root(MobilePartyTrackItemVM newDataSource)
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
			_widget_0.EventFire -= EventListenerOf_widget_0;
			_widget_0_2.EventFire -= EventListenerOf_widget_0_2;
			_widget_0_2.PropertyChanged -= PropertyChangedListenerOf_widget_0_2;
			_widget_0_2.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_2;
			_widget_0_2.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_2;
			_widget_0_2.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_2;
			_widget_0_2.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_2;
			_widget_0_2.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_2;
			_widget_0_2.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_2;
			_widget_0_2.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_2;
			_widget_0_2.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_2;
			_widget_0_3.PropertyChanged -= PropertyChangedListenerOf_widget_0_3;
			_widget_0_3.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_3;
			_widget_0_3.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_3;
			_widget_0_3.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_3;
			_widget_0_3.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_3;
			_widget_0_3.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_3;
			_widget_0_3.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_3;
			_widget_0_3.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_3;
			_widget_0_3.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_3;
			if (_datasource_Root_FactionVisual != null)
			{
				_datasource_Root_FactionVisual.PropertyChanged -= ViewModelPropertyChangedListenerOf_datasource_Root_FactionVisual;
				_datasource_Root_FactionVisual.PropertyChangedWithValue -= ViewModelPropertyChangedWithValueListenerOf_datasource_Root_FactionVisual;
				_datasource_Root_FactionVisual.PropertyChangedWithBoolValue -= ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_FactionVisual;
				_datasource_Root_FactionVisual.PropertyChangedWithIntValue -= ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_FactionVisual;
				_datasource_Root_FactionVisual.PropertyChangedWithFloatValue -= ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_FactionVisual;
				_datasource_Root_FactionVisual.PropertyChangedWithUIntValue -= ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_FactionVisual;
				_datasource_Root_FactionVisual.PropertyChangedWithColorValue -= ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_FactionVisual;
				_datasource_Root_FactionVisual.PropertyChangedWithDoubleValue -= ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_FactionVisual;
				_datasource_Root_FactionVisual.PropertyChangedWithVec2Value -= ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_FactionVisual;
				_widget_0_0.PropertyChanged -= PropertyChangedListenerOf_widget_0_0;
				_widget_0_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_0;
				_widget_0_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_0;
				_widget_0_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_0;
				_widget_0_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_0;
				_widget_0_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_0;
				_widget_0_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_0;
				_widget_0_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_0;
				_widget_0_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_0;
				_datasource_Root_FactionVisual = null;
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
			_widget.Position = _datasource_Root.PartyPosition;
			_widget.IsBehind = _datasource_Root.IsBehind;
			_widget.IsArmy = _datasource_Root.IsArmy;
			_widget.IsActive = _datasource_Root.IsEnabled;
			_widget.IsTracked = _datasource_Root.IsTracked;
			_widget.PropertyChanged += PropertyChangedListenerOf_widget;
			_widget.boolPropertyChanged += boolPropertyChangedListenerOf_widget;
			_widget.floatPropertyChanged += floatPropertyChangedListenerOf_widget;
			_widget.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget;
			_widget.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget;
			_widget.doublePropertyChanged += doublePropertyChangedListenerOf_widget;
			_widget.intPropertyChanged += intPropertyChangedListenerOf_widget;
			_widget.uintPropertyChanged += uintPropertyChangedListenerOf_widget;
			_widget.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget;
			_widget_0.EventFire += EventListenerOf_widget_0;
			_widget_0_2.IsSelected = _datasource_Root.IsTracked;
			_widget_0_2.EventFire += EventListenerOf_widget_0_2;
			_widget_0_2.PropertyChanged += PropertyChangedListenerOf_widget_0_2;
			_widget_0_2.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_2;
			_widget_0_2.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_2;
			_widget_0_2.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_2;
			_widget_0_2.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_2;
			_widget_0_2.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_2;
			_widget_0_2.intPropertyChanged += intPropertyChangedListenerOf_widget_0_2;
			_widget_0_2.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_2;
			_widget_0_2.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_2;
			_widget_0_3.Text = _datasource_Root.Name;
			_widget_0_3.PropertyChanged += PropertyChangedListenerOf_widget_0_3;
			_widget_0_3.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_3;
			_widget_0_3.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_3;
			_widget_0_3.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_3;
			_widget_0_3.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_3;
			_widget_0_3.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_3;
			_widget_0_3.intPropertyChanged += intPropertyChangedListenerOf_widget_0_3;
			_widget_0_3.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_3;
			_widget_0_3.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_3;
			_datasource_Root_FactionVisual = _datasource_Root.FactionVisual;
			if (_datasource_Root_FactionVisual != null)
			{
				_datasource_Root_FactionVisual.PropertyChanged += ViewModelPropertyChangedListenerOf_datasource_Root_FactionVisual;
				_datasource_Root_FactionVisual.PropertyChangedWithValue += ViewModelPropertyChangedWithValueListenerOf_datasource_Root_FactionVisual;
				_datasource_Root_FactionVisual.PropertyChangedWithBoolValue += ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_FactionVisual;
				_datasource_Root_FactionVisual.PropertyChangedWithIntValue += ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_FactionVisual;
				_datasource_Root_FactionVisual.PropertyChangedWithFloatValue += ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_FactionVisual;
				_datasource_Root_FactionVisual.PropertyChangedWithUIntValue += ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_FactionVisual;
				_datasource_Root_FactionVisual.PropertyChangedWithColorValue += ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_FactionVisual;
				_datasource_Root_FactionVisual.PropertyChangedWithDoubleValue += ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_FactionVisual;
				_datasource_Root_FactionVisual.PropertyChangedWithVec2Value += ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_FactionVisual;
				_widget_0_0.AdditionalArgs = _datasource_Root_FactionVisual.AdditionalArgs;
				_widget_0_0.ImageId = _datasource_Root_FactionVisual.Id;
				_widget_0_0.ImageTypeCode = _datasource_Root_FactionVisual.ImageTypeCode;
				_widget_0_0.PropertyChanged += PropertyChangedListenerOf_widget_0_0;
				_widget_0_0.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_0;
				_widget_0_0.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_0;
				_widget_0_0.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_0;
				_widget_0_0.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_0;
				_widget_0_0.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_0;
				_widget_0_0.intPropertyChanged += intPropertyChangedListenerOf_widget_0_0;
				_widget_0_0.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_0;
				_widget_0_0.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_0;
			}
		}
	}

	private void RefreshDataSource_datasource_Root_FactionVisual(ImageIdentifierVM newDataSource)
	{
		if (_datasource_Root_FactionVisual != null)
		{
			_datasource_Root_FactionVisual.PropertyChanged -= ViewModelPropertyChangedListenerOf_datasource_Root_FactionVisual;
			_datasource_Root_FactionVisual.PropertyChangedWithValue -= ViewModelPropertyChangedWithValueListenerOf_datasource_Root_FactionVisual;
			_datasource_Root_FactionVisual.PropertyChangedWithBoolValue -= ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_FactionVisual;
			_datasource_Root_FactionVisual.PropertyChangedWithIntValue -= ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_FactionVisual;
			_datasource_Root_FactionVisual.PropertyChangedWithFloatValue -= ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_FactionVisual;
			_datasource_Root_FactionVisual.PropertyChangedWithUIntValue -= ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_FactionVisual;
			_datasource_Root_FactionVisual.PropertyChangedWithColorValue -= ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_FactionVisual;
			_datasource_Root_FactionVisual.PropertyChangedWithDoubleValue -= ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_FactionVisual;
			_datasource_Root_FactionVisual.PropertyChangedWithVec2Value -= ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_FactionVisual;
			_widget_0_0.PropertyChanged -= PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_0;
			_widget_0_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_0;
			_datasource_Root_FactionVisual = null;
		}
		_datasource_Root_FactionVisual = newDataSource;
		_datasource_Root_FactionVisual = _datasource_Root.FactionVisual;
		if (_datasource_Root_FactionVisual != null)
		{
			_datasource_Root_FactionVisual.PropertyChanged += ViewModelPropertyChangedListenerOf_datasource_Root_FactionVisual;
			_datasource_Root_FactionVisual.PropertyChangedWithValue += ViewModelPropertyChangedWithValueListenerOf_datasource_Root_FactionVisual;
			_datasource_Root_FactionVisual.PropertyChangedWithBoolValue += ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_FactionVisual;
			_datasource_Root_FactionVisual.PropertyChangedWithIntValue += ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_FactionVisual;
			_datasource_Root_FactionVisual.PropertyChangedWithFloatValue += ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_FactionVisual;
			_datasource_Root_FactionVisual.PropertyChangedWithUIntValue += ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_FactionVisual;
			_datasource_Root_FactionVisual.PropertyChangedWithColorValue += ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_FactionVisual;
			_datasource_Root_FactionVisual.PropertyChangedWithDoubleValue += ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_FactionVisual;
			_datasource_Root_FactionVisual.PropertyChangedWithVec2Value += ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_FactionVisual;
			_widget_0_0.AdditionalArgs = _datasource_Root_FactionVisual.AdditionalArgs;
			_widget_0_0.ImageId = _datasource_Root_FactionVisual.Id;
			_widget_0_0.ImageTypeCode = _datasource_Root_FactionVisual.ImageTypeCode;
			_widget_0_0.PropertyChanged += PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_0;
			_widget_0_0.intPropertyChanged += intPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_0;
		}
	}
}