using System.ComponentModel;
using System.Numerics;
using TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.GauntletUI.Layout;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets.Crafting;

namespace SandBox.GauntletUI.AutoGenerated1;

public class Crafting__TaleWorlds_CampaignSystem_ViewModelCollection_WeaponCrafting_CraftingVM_Dependency_5_ItemTemplate : Widget
{
	private Widget _widget;

	private ListPanel _widget_0;

	private CraftingMaterialVisualBrushWidget _widget_0_0;

	private Widget _widget_0_1;

	private TextWidget _widget_0_1_0;

	private HintWidget _widget_1;

	private CraftingResourceItemVM _datasource_Root;

	private HintViewModel _datasource_Root_ResourceHint;

	public Crafting__TaleWorlds_CampaignSystem_ViewModelCollection_WeaponCrafting_CraftingVM_Dependency_5_ItemTemplate(UIContext context)
		: base(context)
	{
	}

	public void CreateWidgets()
	{
		_widget = this;
		_widget_0 = new ListPanel(base.Context);
		_widget.AddChild(_widget_0);
		_widget_0_0 = new CraftingMaterialVisualBrushWidget(base.Context);
		_widget_0.AddChild(_widget_0_0);
		_widget_0_1 = new Widget(base.Context);
		_widget_0.AddChild(_widget_0_1);
		_widget_0_1_0 = new TextWidget(base.Context);
		_widget_0_1.AddChild(_widget_0_1_0);
		_widget_1 = new HintWidget(base.Context);
		_widget.AddChild(_widget_1);
	}

	public void SetIds()
	{
	}

	public void SetAttributes()
	{
		base.WidthSizePolicy = SizePolicy.Fixed;
		base.HeightSizePolicy = SizePolicy.Fixed;
		base.SuggestedWidth = 95f;
		base.SuggestedHeight = 96f;
		base.VerticalAlignment = VerticalAlignment.Bottom;
		base.DoNotPassEventsToChildren = true;
		_widget_0.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_0.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0.StackLayout.LayoutMethod = LayoutMethod.VerticalBottomToTop;
		_widget_0_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0_0.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0_0.SuggestedWidth = 90f;
		_widget_0_0.SuggestedHeight = 55f;
		_widget_0_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_0.Brush = base.Context.GetBrush("Crafting.Material.Brush");
		_widget_0_0.IsBig = true;
		_widget_0_1.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0_1.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0_1.SuggestedWidth = 90f;
		_widget_0_1.SuggestedHeight = 24f;
		_widget_0_1.VerticalAlignment = VerticalAlignment.Bottom;
		_widget_0_1.Sprite = base.Context.SpriteData.GetSprite("Crafting\\number_background");
		_widget_0_1.Color = new Color(0.937255f, 0.6705883f, 0.4196079f);
		_widget_0_1_0.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_0_1_0.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0_1_0.Brush = base.Context.GetBrush("Refinement.Amount.Text");
		_widget_0_1_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_1_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_1_0.MarginTop = 5f;
		_widget_1.WidthSizePolicy = SizePolicy.StretchToParent;
		_widget_1.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_1.IsDisabled = true;
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
			_widget_0_0.PropertyChanged -= PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_0;
			_widget_0_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_0;
			_widget_0_1_0.PropertyChanged -= PropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_1_0;
			if (_datasource_Root_ResourceHint != null)
			{
				_datasource_Root_ResourceHint.PropertyChanged -= ViewModelPropertyChangedListenerOf_datasource_Root_ResourceHint;
				_datasource_Root_ResourceHint.PropertyChangedWithValue -= ViewModelPropertyChangedWithValueListenerOf_datasource_Root_ResourceHint;
				_datasource_Root_ResourceHint.PropertyChangedWithBoolValue -= ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_ResourceHint;
				_datasource_Root_ResourceHint.PropertyChangedWithIntValue -= ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_ResourceHint;
				_datasource_Root_ResourceHint.PropertyChangedWithFloatValue -= ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_ResourceHint;
				_datasource_Root_ResourceHint.PropertyChangedWithUIntValue -= ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_ResourceHint;
				_datasource_Root_ResourceHint.PropertyChangedWithColorValue -= ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_ResourceHint;
				_datasource_Root_ResourceHint.PropertyChangedWithDoubleValue -= ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_ResourceHint;
				_datasource_Root_ResourceHint.PropertyChangedWithVec2Value -= ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_ResourceHint;
				_widget_1.EventFire -= EventListenerOf_widget_1;
				_datasource_Root_ResourceHint = null;
			}
			_datasource_Root = null;
		}
	}

	public void SetDataSource(CraftingResourceItemVM dataSource)
	{
		RefreshDataSource_datasource_Root(dataSource);
	}

	private void EventListenerOf_widget_1(Widget widget, string commandName, object[] args)
	{
		if (commandName == "HoverBegin")
		{
			_datasource_Root_ResourceHint.ExecuteBeginHint();
		}
		if (commandName == "HoverEnd")
		{
			_datasource_Root_ResourceHint.ExecuteEndHint();
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
		if (propertyName == "MaterialType")
		{
			_datasource_Root.ResourceMaterialTypeAsStr = _widget_0_0.MaterialType;
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
		if (propertyName == "IntText")
		{
			_datasource_Root.ResourceAmount = _widget_0_1_0.IntText;
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
		case "ResourceHint":
			RefreshDataSource_datasource_Root_ResourceHint(_datasource_Root.ResourceHint);
			break;
		case "ResourceMaterialTypeAsStr":
			_widget_0_0.MaterialType = _datasource_Root.ResourceMaterialTypeAsStr;
			break;
		case "ResourceAmount":
			_widget_0_1_0.IntText = _datasource_Root.ResourceAmount;
			break;
		}
	}

	private void ViewModelPropertyChangedListenerOf_datasource_Root_ResourceHint(object sender, PropertyChangedEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_ResourceHint(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithValueListenerOf_datasource_Root_ResourceHint(object sender, PropertyChangedWithValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_ResourceHint(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_ResourceHint(object sender, PropertyChangedWithBoolValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_ResourceHint(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_ResourceHint(object sender, PropertyChangedWithIntValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_ResourceHint(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_ResourceHint(object sender, PropertyChangedWithFloatValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_ResourceHint(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_ResourceHint(object sender, PropertyChangedWithUIntValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_ResourceHint(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_ResourceHint(object sender, PropertyChangedWithColorValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_ResourceHint(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_ResourceHint(object sender, PropertyChangedWithDoubleValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_ResourceHint(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_ResourceHint(object sender, PropertyChangedWithVec2ValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_ResourceHint(e.PropertyName);
	}

	private void HandleViewModelPropertyChangeOf_datasource_Root_ResourceHint(string propertyName)
	{
	}

	private void RefreshDataSource_datasource_Root(CraftingResourceItemVM newDataSource)
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
			_widget_0_0.PropertyChanged -= PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_0;
			_widget_0_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_0;
			_widget_0_1_0.PropertyChanged -= PropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_1_0;
			if (_datasource_Root_ResourceHint != null)
			{
				_datasource_Root_ResourceHint.PropertyChanged -= ViewModelPropertyChangedListenerOf_datasource_Root_ResourceHint;
				_datasource_Root_ResourceHint.PropertyChangedWithValue -= ViewModelPropertyChangedWithValueListenerOf_datasource_Root_ResourceHint;
				_datasource_Root_ResourceHint.PropertyChangedWithBoolValue -= ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_ResourceHint;
				_datasource_Root_ResourceHint.PropertyChangedWithIntValue -= ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_ResourceHint;
				_datasource_Root_ResourceHint.PropertyChangedWithFloatValue -= ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_ResourceHint;
				_datasource_Root_ResourceHint.PropertyChangedWithUIntValue -= ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_ResourceHint;
				_datasource_Root_ResourceHint.PropertyChangedWithColorValue -= ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_ResourceHint;
				_datasource_Root_ResourceHint.PropertyChangedWithDoubleValue -= ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_ResourceHint;
				_datasource_Root_ResourceHint.PropertyChangedWithVec2Value -= ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_ResourceHint;
				_widget_1.EventFire -= EventListenerOf_widget_1;
				_datasource_Root_ResourceHint = null;
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
			_widget_0_0.MaterialType = _datasource_Root.ResourceMaterialTypeAsStr;
			_widget_0_0.PropertyChanged += PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_0;
			_widget_0_0.intPropertyChanged += intPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_0;
			_widget_0_1_0.IntText = _datasource_Root.ResourceAmount;
			_widget_0_1_0.PropertyChanged += PropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.intPropertyChanged += intPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_1_0;
			_datasource_Root_ResourceHint = _datasource_Root.ResourceHint;
			if (_datasource_Root_ResourceHint != null)
			{
				_datasource_Root_ResourceHint.PropertyChanged += ViewModelPropertyChangedListenerOf_datasource_Root_ResourceHint;
				_datasource_Root_ResourceHint.PropertyChangedWithValue += ViewModelPropertyChangedWithValueListenerOf_datasource_Root_ResourceHint;
				_datasource_Root_ResourceHint.PropertyChangedWithBoolValue += ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_ResourceHint;
				_datasource_Root_ResourceHint.PropertyChangedWithIntValue += ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_ResourceHint;
				_datasource_Root_ResourceHint.PropertyChangedWithFloatValue += ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_ResourceHint;
				_datasource_Root_ResourceHint.PropertyChangedWithUIntValue += ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_ResourceHint;
				_datasource_Root_ResourceHint.PropertyChangedWithColorValue += ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_ResourceHint;
				_datasource_Root_ResourceHint.PropertyChangedWithDoubleValue += ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_ResourceHint;
				_datasource_Root_ResourceHint.PropertyChangedWithVec2Value += ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_ResourceHint;
				_widget_1.EventFire += EventListenerOf_widget_1;
			}
		}
	}

	private void RefreshDataSource_datasource_Root_ResourceHint(HintViewModel newDataSource)
	{
		if (_datasource_Root_ResourceHint != null)
		{
			_datasource_Root_ResourceHint.PropertyChanged -= ViewModelPropertyChangedListenerOf_datasource_Root_ResourceHint;
			_datasource_Root_ResourceHint.PropertyChangedWithValue -= ViewModelPropertyChangedWithValueListenerOf_datasource_Root_ResourceHint;
			_datasource_Root_ResourceHint.PropertyChangedWithBoolValue -= ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_ResourceHint;
			_datasource_Root_ResourceHint.PropertyChangedWithIntValue -= ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_ResourceHint;
			_datasource_Root_ResourceHint.PropertyChangedWithFloatValue -= ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_ResourceHint;
			_datasource_Root_ResourceHint.PropertyChangedWithUIntValue -= ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_ResourceHint;
			_datasource_Root_ResourceHint.PropertyChangedWithColorValue -= ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_ResourceHint;
			_datasource_Root_ResourceHint.PropertyChangedWithDoubleValue -= ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_ResourceHint;
			_datasource_Root_ResourceHint.PropertyChangedWithVec2Value -= ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_ResourceHint;
			_widget_1.EventFire -= EventListenerOf_widget_1;
			_datasource_Root_ResourceHint = null;
		}
		_datasource_Root_ResourceHint = newDataSource;
		_datasource_Root_ResourceHint = _datasource_Root.ResourceHint;
		if (_datasource_Root_ResourceHint != null)
		{
			_datasource_Root_ResourceHint.PropertyChanged += ViewModelPropertyChangedListenerOf_datasource_Root_ResourceHint;
			_datasource_Root_ResourceHint.PropertyChangedWithValue += ViewModelPropertyChangedWithValueListenerOf_datasource_Root_ResourceHint;
			_datasource_Root_ResourceHint.PropertyChangedWithBoolValue += ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_ResourceHint;
			_datasource_Root_ResourceHint.PropertyChangedWithIntValue += ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_ResourceHint;
			_datasource_Root_ResourceHint.PropertyChangedWithFloatValue += ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_ResourceHint;
			_datasource_Root_ResourceHint.PropertyChangedWithUIntValue += ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_ResourceHint;
			_datasource_Root_ResourceHint.PropertyChangedWithColorValue += ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_ResourceHint;
			_datasource_Root_ResourceHint.PropertyChangedWithDoubleValue += ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_ResourceHint;
			_datasource_Root_ResourceHint.PropertyChangedWithVec2Value += ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_ResourceHint;
			_widget_1.EventFire += EventListenerOf_widget_1;
		}
	}
}
