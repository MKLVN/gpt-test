using System.ComponentModel;
using System.Numerics;
using SandBox.ViewModelCollection.Nameplate.NameplateNotifications;
using TaleWorlds.Core;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets.Nameplate.Notifications;

namespace SandBox.GauntletUI.AutoGenerated0;

public class SettlementNameplate__SandBox_ViewModelCollection_Nameplate_SettlementNameplatesVM_Dependency_3_ItemTemplate : NameplateNotificationListPanel
{
	private NameplateNotificationListPanel _widget;

	private ListPanel _widget_0;

	private Widget _widget_0_0;

	private Widget _widget_0_1;

	private ImageIdentifierWidget _widget_0_1_0;

	private TextWidget _widget_0_2;

	private TextWidget _widget_0_3;

	private SettlementNotificationItemBaseVM _datasource_Root;

	private ImageIdentifierVM _datasource_Root_CharacterVisual;

	public SettlementNameplate__SandBox_ViewModelCollection_Nameplate_SettlementNameplatesVM_Dependency_3_ItemTemplate(UIContext context)
		: base(context)
	{
	}

	public void CreateWidgets()
	{
		_widget = this;
		_widget_0 = new ListPanel(base.Context);
		_widget.AddChild(_widget_0);
		_widget_0_0 = new Widget(base.Context);
		_widget_0.AddChild(_widget_0_0);
		_widget_0_1 = new Widget(base.Context);
		_widget_0.AddChild(_widget_0_1);
		_widget_0_1_0 = new ImageIdentifierWidget(base.Context);
		_widget_0_1.AddChild(_widget_0_1_0);
		_widget_0_2 = new TextWidget(base.Context);
		_widget_0.AddChild(_widget_0_2);
		_widget_0_3 = new TextWidget(base.Context);
		_widget_0.AddChild(_widget_0_3);
	}

	public void SetIds()
	{
		_widget_0.Id = "NotificationBaseWidget";
		_widget_0_0.Id = "RelationVisualWidget";
	}

	public void SetAttributes()
	{
		base.WidthSizePolicy = SizePolicy.Fixed;
		base.HeightSizePolicy = SizePolicy.CoverChildren;
		base.SuggestedWidth = 50f;
		base.VerticalAlignment = VerticalAlignment.Center;
		base.FadeTime = 0.4f;
		base.RelationVisualWidget = _widget_0_0;
		base.StayAmount = 3f;
		_widget_0.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_0.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0.SuggestedWidth = 234f;
		_widget_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_0.Sprite = base.Context.SpriteData.GetSprite("SPGeneral\\Nameplates\\Notification\\base");
		_widget_0.AlphaFactor = 0.6f;
		_widget_0_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0_0.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0_0.SuggestedWidth = 3f;
		_widget_0_0.SuggestedHeight = 26f;
		_widget_0_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_0.Sprite = base.Context.SpriteData.GetSprite("SPGeneral\\Nameplates\\Notification\\relation_status");
		_widget_0_1.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0_1.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0_1.SuggestedWidth = 30f;
		_widget_0_1.SuggestedHeight = 26f;
		_widget_0_1.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_1.MarginLeft = 4f;
		_widget_0_1.Sprite = base.Context.SpriteData.GetSprite("SPGeneral\\Nameplates\\Notification\\avatar");
		_widget_0_1_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0_1_0.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0_1_0.SuggestedWidth = 36f;
		_widget_0_1_0.SuggestedHeight = 26f;
		_widget_0_1_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_1_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_2.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_0_2.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0_2.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_2.MarginLeft = 9f;
		_widget_0_2.Brush = base.Context.GetBrush("Settlement.Notification.Name.Text");
		_widget_0_3.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_0_3.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0_3.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_3.MarginLeft = 4f;
		_widget_0_3.Brush = base.Context.GetBrush("Settlement.Notification.Value.Text");
		_widget_0_3.MarginRight = 20f;
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
			_widget.EventFire -= EventListenerOf_widget;
			_widget.PropertyChanged -= PropertyChangedListenerOf_widget;
			_widget.boolPropertyChanged -= boolPropertyChangedListenerOf_widget;
			_widget.floatPropertyChanged -= floatPropertyChangedListenerOf_widget;
			_widget.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget;
			_widget.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget;
			_widget.doublePropertyChanged -= doublePropertyChangedListenerOf_widget;
			_widget.intPropertyChanged -= intPropertyChangedListenerOf_widget;
			_widget.uintPropertyChanged -= uintPropertyChangedListenerOf_widget;
			_widget.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget;
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
			if (_datasource_Root_CharacterVisual != null)
			{
				_datasource_Root_CharacterVisual.PropertyChanged -= ViewModelPropertyChangedListenerOf_datasource_Root_CharacterVisual;
				_datasource_Root_CharacterVisual.PropertyChangedWithValue -= ViewModelPropertyChangedWithValueListenerOf_datasource_Root_CharacterVisual;
				_datasource_Root_CharacterVisual.PropertyChangedWithBoolValue -= ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_CharacterVisual;
				_datasource_Root_CharacterVisual.PropertyChangedWithIntValue -= ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_CharacterVisual;
				_datasource_Root_CharacterVisual.PropertyChangedWithFloatValue -= ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_CharacterVisual;
				_datasource_Root_CharacterVisual.PropertyChangedWithUIntValue -= ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_CharacterVisual;
				_datasource_Root_CharacterVisual.PropertyChangedWithColorValue -= ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_CharacterVisual;
				_datasource_Root_CharacterVisual.PropertyChangedWithDoubleValue -= ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_CharacterVisual;
				_datasource_Root_CharacterVisual.PropertyChangedWithVec2Value -= ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_CharacterVisual;
				_widget_0_1_0.PropertyChanged -= PropertyChangedListenerOf_widget_0_1_0;
				_widget_0_1_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_1_0;
				_widget_0_1_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_1_0;
				_widget_0_1_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_1_0;
				_widget_0_1_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_1_0;
				_widget_0_1_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_1_0;
				_widget_0_1_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_1_0;
				_widget_0_1_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_1_0;
				_widget_0_1_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_1_0;
				_datasource_Root_CharacterVisual = null;
			}
			_datasource_Root = null;
		}
	}

	public void SetDataSource(SettlementNotificationItemBaseVM dataSource)
	{
		RefreshDataSource_datasource_Root(dataSource);
	}

	private void EventListenerOf_widget(Widget widget, string commandName, object[] args)
	{
		if (commandName == "OnRemove")
		{
			_datasource_Root.ExecuteRemove();
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
		if (propertyName == "RelationType")
		{
			_datasource_Root.RelationType = _widget.RelationType;
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
		if (propertyName == "Text")
		{
			_datasource_Root.CharacterName = _widget_0_2.Text;
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
			_datasource_Root.Text = _widget_0_3.Text;
		}
	}

	private void PropertyChangedListenerOf_widget_0_1_0(PropertyOwnerObject propertyOwnerObject, string propertyName, object e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1_0(propertyName);
	}

	private void boolPropertyChangedListenerOf_widget_0_1_0(PropertyOwnerObject propertyOwnerObject, string propertyName, bool e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1_0(propertyName);
	}

	private void floatPropertyChangedListenerOf_widget_0_1_0(PropertyOwnerObject propertyOwnerObject, string propertyName, float e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1_0(propertyName);
	}

	private void Vec2PropertyChangedListenerOf_widget_0_1_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Vec2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1_0(propertyName);
	}

	private void Vector2PropertyChangedListenerOf_widget_0_1_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Vector2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1_0(propertyName);
	}

	private void doublePropertyChangedListenerOf_widget_0_1_0(PropertyOwnerObject propertyOwnerObject, string propertyName, double e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1_0(propertyName);
	}

	private void intPropertyChangedListenerOf_widget_0_1_0(PropertyOwnerObject propertyOwnerObject, string propertyName, int e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1_0(propertyName);
	}

	private void uintPropertyChangedListenerOf_widget_0_1_0(PropertyOwnerObject propertyOwnerObject, string propertyName, uint e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1_0(propertyName);
	}

	private void ColorPropertyChangedListenerOf_widget_0_1_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Color e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1_0(propertyName);
	}

	private void HandleWidgetPropertyChangeOf_widget_0_1_0(string propertyName)
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
		case "CharacterVisual":
			RefreshDataSource_datasource_Root_CharacterVisual(_datasource_Root.CharacterVisual);
			break;
		case "RelationType":
			_widget.RelationType = _datasource_Root.RelationType;
			break;
		case "CharacterName":
			_widget_0_2.Text = _datasource_Root.CharacterName;
			break;
		case "Text":
			_widget_0_3.Text = _datasource_Root.Text;
			break;
		}
	}

	private void ViewModelPropertyChangedListenerOf_datasource_Root_CharacterVisual(object sender, PropertyChangedEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_CharacterVisual(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithValueListenerOf_datasource_Root_CharacterVisual(object sender, PropertyChangedWithValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_CharacterVisual(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_CharacterVisual(object sender, PropertyChangedWithBoolValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_CharacterVisual(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_CharacterVisual(object sender, PropertyChangedWithIntValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_CharacterVisual(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_CharacterVisual(object sender, PropertyChangedWithFloatValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_CharacterVisual(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_CharacterVisual(object sender, PropertyChangedWithUIntValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_CharacterVisual(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_CharacterVisual(object sender, PropertyChangedWithColorValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_CharacterVisual(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_CharacterVisual(object sender, PropertyChangedWithDoubleValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_CharacterVisual(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_CharacterVisual(object sender, PropertyChangedWithVec2ValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_CharacterVisual(e.PropertyName);
	}

	private void HandleViewModelPropertyChangeOf_datasource_Root_CharacterVisual(string propertyName)
	{
		switch (propertyName)
		{
		case "AdditionalArgs":
			_widget_0_1_0.AdditionalArgs = _datasource_Root_CharacterVisual.AdditionalArgs;
			break;
		case "Id":
			_widget_0_1_0.ImageId = _datasource_Root_CharacterVisual.Id;
			break;
		case "ImageTypeCode":
			_widget_0_1_0.ImageTypeCode = _datasource_Root_CharacterVisual.ImageTypeCode;
			break;
		}
	}

	private void RefreshDataSource_datasource_Root(SettlementNotificationItemBaseVM newDataSource)
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
			_widget.EventFire -= EventListenerOf_widget;
			_widget.PropertyChanged -= PropertyChangedListenerOf_widget;
			_widget.boolPropertyChanged -= boolPropertyChangedListenerOf_widget;
			_widget.floatPropertyChanged -= floatPropertyChangedListenerOf_widget;
			_widget.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget;
			_widget.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget;
			_widget.doublePropertyChanged -= doublePropertyChangedListenerOf_widget;
			_widget.intPropertyChanged -= intPropertyChangedListenerOf_widget;
			_widget.uintPropertyChanged -= uintPropertyChangedListenerOf_widget;
			_widget.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget;
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
			if (_datasource_Root_CharacterVisual != null)
			{
				_datasource_Root_CharacterVisual.PropertyChanged -= ViewModelPropertyChangedListenerOf_datasource_Root_CharacterVisual;
				_datasource_Root_CharacterVisual.PropertyChangedWithValue -= ViewModelPropertyChangedWithValueListenerOf_datasource_Root_CharacterVisual;
				_datasource_Root_CharacterVisual.PropertyChangedWithBoolValue -= ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_CharacterVisual;
				_datasource_Root_CharacterVisual.PropertyChangedWithIntValue -= ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_CharacterVisual;
				_datasource_Root_CharacterVisual.PropertyChangedWithFloatValue -= ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_CharacterVisual;
				_datasource_Root_CharacterVisual.PropertyChangedWithUIntValue -= ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_CharacterVisual;
				_datasource_Root_CharacterVisual.PropertyChangedWithColorValue -= ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_CharacterVisual;
				_datasource_Root_CharacterVisual.PropertyChangedWithDoubleValue -= ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_CharacterVisual;
				_datasource_Root_CharacterVisual.PropertyChangedWithVec2Value -= ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_CharacterVisual;
				_widget_0_1_0.PropertyChanged -= PropertyChangedListenerOf_widget_0_1_0;
				_widget_0_1_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_1_0;
				_widget_0_1_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_1_0;
				_widget_0_1_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_1_0;
				_widget_0_1_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_1_0;
				_widget_0_1_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_1_0;
				_widget_0_1_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_1_0;
				_widget_0_1_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_1_0;
				_widget_0_1_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_1_0;
				_datasource_Root_CharacterVisual = null;
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
			_widget.RelationType = _datasource_Root.RelationType;
			_widget.EventFire += EventListenerOf_widget;
			_widget.PropertyChanged += PropertyChangedListenerOf_widget;
			_widget.boolPropertyChanged += boolPropertyChangedListenerOf_widget;
			_widget.floatPropertyChanged += floatPropertyChangedListenerOf_widget;
			_widget.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget;
			_widget.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget;
			_widget.doublePropertyChanged += doublePropertyChangedListenerOf_widget;
			_widget.intPropertyChanged += intPropertyChangedListenerOf_widget;
			_widget.uintPropertyChanged += uintPropertyChangedListenerOf_widget;
			_widget.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget;
			_widget_0_2.Text = _datasource_Root.CharacterName;
			_widget_0_2.PropertyChanged += PropertyChangedListenerOf_widget_0_2;
			_widget_0_2.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_2;
			_widget_0_2.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_2;
			_widget_0_2.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_2;
			_widget_0_2.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_2;
			_widget_0_2.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_2;
			_widget_0_2.intPropertyChanged += intPropertyChangedListenerOf_widget_0_2;
			_widget_0_2.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_2;
			_widget_0_2.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_2;
			_widget_0_3.Text = _datasource_Root.Text;
			_widget_0_3.PropertyChanged += PropertyChangedListenerOf_widget_0_3;
			_widget_0_3.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_3;
			_widget_0_3.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_3;
			_widget_0_3.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_3;
			_widget_0_3.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_3;
			_widget_0_3.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_3;
			_widget_0_3.intPropertyChanged += intPropertyChangedListenerOf_widget_0_3;
			_widget_0_3.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_3;
			_widget_0_3.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_3;
			_datasource_Root_CharacterVisual = _datasource_Root.CharacterVisual;
			if (_datasource_Root_CharacterVisual != null)
			{
				_datasource_Root_CharacterVisual.PropertyChanged += ViewModelPropertyChangedListenerOf_datasource_Root_CharacterVisual;
				_datasource_Root_CharacterVisual.PropertyChangedWithValue += ViewModelPropertyChangedWithValueListenerOf_datasource_Root_CharacterVisual;
				_datasource_Root_CharacterVisual.PropertyChangedWithBoolValue += ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_CharacterVisual;
				_datasource_Root_CharacterVisual.PropertyChangedWithIntValue += ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_CharacterVisual;
				_datasource_Root_CharacterVisual.PropertyChangedWithFloatValue += ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_CharacterVisual;
				_datasource_Root_CharacterVisual.PropertyChangedWithUIntValue += ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_CharacterVisual;
				_datasource_Root_CharacterVisual.PropertyChangedWithColorValue += ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_CharacterVisual;
				_datasource_Root_CharacterVisual.PropertyChangedWithDoubleValue += ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_CharacterVisual;
				_datasource_Root_CharacterVisual.PropertyChangedWithVec2Value += ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_CharacterVisual;
				_widget_0_1_0.AdditionalArgs = _datasource_Root_CharacterVisual.AdditionalArgs;
				_widget_0_1_0.ImageId = _datasource_Root_CharacterVisual.Id;
				_widget_0_1_0.ImageTypeCode = _datasource_Root_CharacterVisual.ImageTypeCode;
				_widget_0_1_0.PropertyChanged += PropertyChangedListenerOf_widget_0_1_0;
				_widget_0_1_0.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_1_0;
				_widget_0_1_0.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_1_0;
				_widget_0_1_0.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_1_0;
				_widget_0_1_0.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_1_0;
				_widget_0_1_0.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_1_0;
				_widget_0_1_0.intPropertyChanged += intPropertyChangedListenerOf_widget_0_1_0;
				_widget_0_1_0.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_1_0;
				_widget_0_1_0.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_1_0;
			}
		}
	}

	private void RefreshDataSource_datasource_Root_CharacterVisual(ImageIdentifierVM newDataSource)
	{
		if (_datasource_Root_CharacterVisual != null)
		{
			_datasource_Root_CharacterVisual.PropertyChanged -= ViewModelPropertyChangedListenerOf_datasource_Root_CharacterVisual;
			_datasource_Root_CharacterVisual.PropertyChangedWithValue -= ViewModelPropertyChangedWithValueListenerOf_datasource_Root_CharacterVisual;
			_datasource_Root_CharacterVisual.PropertyChangedWithBoolValue -= ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_CharacterVisual;
			_datasource_Root_CharacterVisual.PropertyChangedWithIntValue -= ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_CharacterVisual;
			_datasource_Root_CharacterVisual.PropertyChangedWithFloatValue -= ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_CharacterVisual;
			_datasource_Root_CharacterVisual.PropertyChangedWithUIntValue -= ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_CharacterVisual;
			_datasource_Root_CharacterVisual.PropertyChangedWithColorValue -= ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_CharacterVisual;
			_datasource_Root_CharacterVisual.PropertyChangedWithDoubleValue -= ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_CharacterVisual;
			_datasource_Root_CharacterVisual.PropertyChangedWithVec2Value -= ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_CharacterVisual;
			_widget_0_1_0.PropertyChanged -= PropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_1_0;
			_datasource_Root_CharacterVisual = null;
		}
		_datasource_Root_CharacterVisual = newDataSource;
		_datasource_Root_CharacterVisual = _datasource_Root.CharacterVisual;
		if (_datasource_Root_CharacterVisual != null)
		{
			_datasource_Root_CharacterVisual.PropertyChanged += ViewModelPropertyChangedListenerOf_datasource_Root_CharacterVisual;
			_datasource_Root_CharacterVisual.PropertyChangedWithValue += ViewModelPropertyChangedWithValueListenerOf_datasource_Root_CharacterVisual;
			_datasource_Root_CharacterVisual.PropertyChangedWithBoolValue += ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_CharacterVisual;
			_datasource_Root_CharacterVisual.PropertyChangedWithIntValue += ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_CharacterVisual;
			_datasource_Root_CharacterVisual.PropertyChangedWithFloatValue += ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_CharacterVisual;
			_datasource_Root_CharacterVisual.PropertyChangedWithUIntValue += ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_CharacterVisual;
			_datasource_Root_CharacterVisual.PropertyChangedWithColorValue += ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_CharacterVisual;
			_datasource_Root_CharacterVisual.PropertyChangedWithDoubleValue += ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_CharacterVisual;
			_datasource_Root_CharacterVisual.PropertyChangedWithVec2Value += ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_CharacterVisual;
			_widget_0_1_0.AdditionalArgs = _datasource_Root_CharacterVisual.AdditionalArgs;
			_widget_0_1_0.ImageId = _datasource_Root_CharacterVisual.Id;
			_widget_0_1_0.ImageTypeCode = _datasource_Root_CharacterVisual.ImageTypeCode;
			_widget_0_1_0.PropertyChanged += PropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.intPropertyChanged += intPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_1_0;
		}
	}
}