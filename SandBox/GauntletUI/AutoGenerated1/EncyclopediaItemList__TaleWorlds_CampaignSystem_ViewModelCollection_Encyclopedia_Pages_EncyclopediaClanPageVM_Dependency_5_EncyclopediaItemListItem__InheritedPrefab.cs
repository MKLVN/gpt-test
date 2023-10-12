using System.ComponentModel;
using System.Numerics;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia.List;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.GauntletUI.ExtraWidgets;
using TaleWorlds.GauntletUI.Layout;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets.Encyclopedia;

namespace SandBox.GauntletUI.AutoGenerated1;

public class EncyclopediaItemList__TaleWorlds_CampaignSystem_ViewModelCollection_Encyclopedia_Pages_EncyclopediaClanPageVM_Dependency_5_EncyclopediaItemListItem__InheritedPrefab : EncyclopediaListItemButtonWidget
{
	private EncyclopediaListItemButtonWidget _widget;

	private ListPanel _widget_0;

	private Widget _widget_0_0;

	private Widget _widget_0_1;

	private ScrollingTextWidget _widget_0_2;

	private TextWidget _widget_0_3;

	private EncyclopediaListItemVM _datasource_Root;

	public EncyclopediaItemList__TaleWorlds_CampaignSystem_ViewModelCollection_Encyclopedia_Pages_EncyclopediaClanPageVM_Dependency_5_EncyclopediaItemListItem__InheritedPrefab(UIContext context)
		: base(context)
	{
	}

	public virtual void CreateWidgets()
	{
		_widget = this;
		_widget_0 = new ListPanel(base.Context);
		_widget.AddChild(_widget_0);
		_widget_0_0 = new Widget(base.Context);
		_widget_0.AddChild(_widget_0_0);
		_widget_0_1 = new Widget(base.Context);
		_widget_0.AddChild(_widget_0_1);
		_widget_0_2 = new ScrollingTextWidget(base.Context);
		_widget_0.AddChild(_widget_0_2);
		_widget_0_3 = new TextWidget(base.Context);
		_widget_0.AddChild(_widget_0_3);
	}

	public virtual void SetIds()
	{
		_widget_0.Id = "ItemParentListPanel";
		_widget_0_2.Id = "ListItemNameTextWidget";
		_widget_0_3.Id = "ListComparedValueTextWidget";
	}

	public virtual void SetAttributes()
	{
		base.DoNotPassEventsToChildren = true;
		base.WidthSizePolicy = SizePolicy.StretchToParent;
		base.HeightSizePolicy = SizePolicy.CoverChildren;
		base.SuggestedHeight = 37f;
		base.Brush = base.Context.GetBrush("Encyclopedia.ListButton");
		base.InfoAvailableItemNameBrush = base.Context.GetBrush("EncyclopediaList.Filter.Name.Text");
		base.InfoUnvailableItemNameBrush = base.Context.GetBrush("EncyclopediaList.Item.InfoUnavailable.Name.Text");
		base.ListItemNameTextWidget = _widget_0_2;
		base.ListComparedValueTextWidget = _widget_0_3;
		_widget_0.WidthSizePolicy = SizePolicy.StretchToParent;
		_widget_0.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0.StackLayout.LayoutMethod = LayoutMethod.HorizontalLeftToRight;
		_widget_0_0.DoNotPassEventsToChildren = true;
		_widget_0_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0_0.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0_0.SuggestedWidth = 35f;
		_widget_0_0.SuggestedHeight = 35f;
		_widget_0_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_0.Sprite = base.Context.SpriteData.GetSprite("Encyclopedia\\star_without_glow");
		_widget_0_0.Color = new Color(0.9960785f, 0.7568628f, 0.3411765f);
		_widget_0_1.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0_1.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0_1.SuggestedWidth = 35f;
		_widget_0_1.SuggestedHeight = 35f;
		_widget_0_1.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_1.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_2.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0_2.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0_2.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_2.SuggestedWidth = 500f;
		_widget_0_2.MarginLeft = 5f;
		_widget_0_3.WidthSizePolicy = SizePolicy.StretchToParent;
		_widget_0_3.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0_3.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_3.MarginLeft = 30f;
	}

	public virtual void DestroyDataSource()
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
			_widget_0_0.PropertyChanged -= PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_0;
			_widget_0_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_0;
			_widget_0_1.PropertyChanged -= PropertyChangedListenerOf_widget_0_1;
			_widget_0_1.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_1;
			_widget_0_1.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_1;
			_widget_0_1.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_1;
			_widget_0_1.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_1;
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
			_datasource_Root = null;
		}
	}

	public virtual void SetDataSource(EncyclopediaListItemVM dataSource)
	{
		RefreshDataSource_datasource_Root(dataSource);
	}

	private void EventListenerOf_widget(Widget widget, string commandName, object[] args)
	{
		if (commandName == "Click")
		{
			_datasource_Root.Execute();
		}
		if (commandName == "HoverBegin")
		{
			_datasource_Root.ExecuteBeginTooltip();
		}
		if (commandName == "HoverEnd")
		{
			_datasource_Root.ExecuteEndTooltip();
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
		case "IsHidden":
			_datasource_Root.IsFiltered = _widget.IsHidden;
			break;
		case "ListItemId":
			_datasource_Root.Id = _widget.ListItemId;
			break;
		case "IsInfoAvailable":
			_datasource_Root.PlayerCanSeeValues = _widget.IsInfoAvailable;
			break;
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
		if (propertyName == "IsVisible")
		{
			_datasource_Root.IsBookmarked = _widget_0_0.IsVisible;
		}
	}

	private void PropertyChangedListenerOf_widget_0_1(PropertyOwnerObject propertyOwnerObject, string propertyName, object e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1(propertyName);
	}

	private void boolPropertyChangedListenerOf_widget_0_1(PropertyOwnerObject propertyOwnerObject, string propertyName, bool e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1(propertyName);
	}

	private void floatPropertyChangedListenerOf_widget_0_1(PropertyOwnerObject propertyOwnerObject, string propertyName, float e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1(propertyName);
	}

	private void Vec2PropertyChangedListenerOf_widget_0_1(PropertyOwnerObject propertyOwnerObject, string propertyName, Vec2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1(propertyName);
	}

	private void Vector2PropertyChangedListenerOf_widget_0_1(PropertyOwnerObject propertyOwnerObject, string propertyName, Vector2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1(propertyName);
	}

	private void doublePropertyChangedListenerOf_widget_0_1(PropertyOwnerObject propertyOwnerObject, string propertyName, double e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1(propertyName);
	}

	private void intPropertyChangedListenerOf_widget_0_1(PropertyOwnerObject propertyOwnerObject, string propertyName, int e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1(propertyName);
	}

	private void uintPropertyChangedListenerOf_widget_0_1(PropertyOwnerObject propertyOwnerObject, string propertyName, uint e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1(propertyName);
	}

	private void ColorPropertyChangedListenerOf_widget_0_1(PropertyOwnerObject propertyOwnerObject, string propertyName, Color e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1(propertyName);
	}

	private void HandleWidgetPropertyChangeOf_widget_0_1(string propertyName)
	{
		if (propertyName == "IsHidden")
		{
			_datasource_Root.IsBookmarked = _widget_0_1.IsHidden;
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
			_datasource_Root.Name = _widget_0_2.Text;
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
			_datasource_Root.ComparedValue = _widget_0_3.Text;
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
		case "IsFiltered":
			_widget.IsHidden = _datasource_Root.IsFiltered;
			break;
		case "Id":
			_widget.ListItemId = _datasource_Root.Id;
			break;
		case "PlayerCanSeeValues":
			_widget.IsInfoAvailable = _datasource_Root.PlayerCanSeeValues;
			break;
		case "IsBookmarked":
			_widget_0_0.IsVisible = _datasource_Root.IsBookmarked;
			_widget_0_1.IsHidden = _datasource_Root.IsBookmarked;
			break;
		case "Name":
			_widget_0_2.Text = _datasource_Root.Name;
			break;
		case "ComparedValue":
			_widget_0_3.Text = _datasource_Root.ComparedValue;
			break;
		}
	}

	private void RefreshDataSource_datasource_Root(EncyclopediaListItemVM newDataSource)
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
			_widget_0_0.PropertyChanged -= PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_0;
			_widget_0_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_0;
			_widget_0_1.PropertyChanged -= PropertyChangedListenerOf_widget_0_1;
			_widget_0_1.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_1;
			_widget_0_1.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_1;
			_widget_0_1.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_1;
			_widget_0_1.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_1;
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
			_widget.IsHidden = _datasource_Root.IsFiltered;
			_widget.ListItemId = _datasource_Root.Id;
			_widget.IsInfoAvailable = _datasource_Root.PlayerCanSeeValues;
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
			_widget_0_0.IsVisible = _datasource_Root.IsBookmarked;
			_widget_0_0.PropertyChanged += PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_0;
			_widget_0_0.intPropertyChanged += intPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_0;
			_widget_0_1.IsHidden = _datasource_Root.IsBookmarked;
			_widget_0_1.PropertyChanged += PropertyChangedListenerOf_widget_0_1;
			_widget_0_1.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_1;
			_widget_0_1.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_1;
			_widget_0_1.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_1;
			_widget_0_1.intPropertyChanged += intPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_1;
			_widget_0_2.Text = _datasource_Root.Name;
			_widget_0_2.PropertyChanged += PropertyChangedListenerOf_widget_0_2;
			_widget_0_2.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_2;
			_widget_0_2.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_2;
			_widget_0_2.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_2;
			_widget_0_2.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_2;
			_widget_0_2.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_2;
			_widget_0_2.intPropertyChanged += intPropertyChangedListenerOf_widget_0_2;
			_widget_0_2.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_2;
			_widget_0_2.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_2;
			_widget_0_3.Text = _datasource_Root.ComparedValue;
			_widget_0_3.PropertyChanged += PropertyChangedListenerOf_widget_0_3;
			_widget_0_3.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_3;
			_widget_0_3.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_3;
			_widget_0_3.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_3;
			_widget_0_3.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_3;
			_widget_0_3.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_3;
			_widget_0_3.intPropertyChanged += intPropertyChangedListenerOf_widget_0_3;
			_widget_0_3.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_3;
			_widget_0_3.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_3;
		}
	}
}
