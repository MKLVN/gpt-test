using System.ComponentModel;
using System.Numerics;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.GauntletUI.Data;
using TaleWorlds.GauntletUI.Layout;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.ViewModelCollection.HUD;

namespace TaleWorlds.MountAndBlade.GauntletUI.AutoGenerated0;

public class MainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM : Widget, IGeneratedGauntletMovieRoot
{
	private Widget _widget;

	private Widget _widget_0;

	private Widget _widget_0_0;

	private CircleActionSelectorWidget _widget_0_1;

	private Widget _widget_0_2;

	private ListPanel _widget_0_3;

	private TextWidget _widget_0_3_0;

	private TextWidget _widget_0_3_1;

	private TextWidget _widget_0_3_2;

	private MissionMainAgentControllerEquipDropVM _datasource_Root;

	private MBBindingList<ControllerEquippedItemVM> _datasource_Root_EquippedWeapons;

	public MainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM(UIContext context)
		: base(context)
	{
	}

	private VisualDefinition CreateVisualDefinitionCircleBackground()
	{
		VisualDefinition visualDefinition = new VisualDefinition("CircleBackground", 0.15f, 0f, easeIn: false);
		visualDefinition.AddVisualState(new VisualState("Selected")
		{
			SuggestedHeight = 84f,
			SuggestedWidth = 85f
		});
		visualDefinition.AddVisualState(new VisualState("Default")
		{
			SuggestedHeight = 74f,
			SuggestedWidth = 75f
		});
		visualDefinition.AddVisualState(new VisualState("Pressed")
		{
			SuggestedHeight = 74f,
			SuggestedWidth = 75f
		});
		visualDefinition.AddVisualState(new VisualState("Hovered")
		{
			SuggestedHeight = 74f,
			SuggestedWidth = 75f
		});
		visualDefinition.AddVisualState(new VisualState("Disabled")
		{
			SuggestedHeight = 74f,
			SuggestedWidth = 75f
		});
		return visualDefinition;
	}

	private VisualDefinition CreateVisualDefinitionCircleGlow()
	{
		VisualDefinition visualDefinition = new VisualDefinition("CircleGlow", 0.15f, 0f, easeIn: false);
		visualDefinition.AddVisualState(new VisualState("Selected")
		{
			SuggestedHeight = 125f,
			SuggestedWidth = 127f
		});
		visualDefinition.AddVisualState(new VisualState("Default")
		{
			SuggestedHeight = 115f,
			SuggestedWidth = 117f
		});
		visualDefinition.AddVisualState(new VisualState("Pressed")
		{
			SuggestedHeight = 115f,
			SuggestedWidth = 117f
		});
		visualDefinition.AddVisualState(new VisualState("Hovered")
		{
			SuggestedHeight = 115f,
			SuggestedWidth = 117f
		});
		visualDefinition.AddVisualState(new VisualState("Disabled")
		{
			SuggestedHeight = 115f,
			SuggestedWidth = 117f
		});
		return visualDefinition;
	}

	public void CreateWidgets()
	{
		_widget = this;
		_widget_0 = new Widget(base.Context);
		_widget.AddChild(_widget_0);
		_widget_0_0 = new Widget(base.Context);
		_widget_0.AddChild(_widget_0_0);
		_widget_0_1 = new CircleActionSelectorWidget(base.Context);
		_widget_0.AddChild(_widget_0_1);
		_widget_0_2 = new Widget(base.Context);
		_widget_0.AddChild(_widget_0_2);
		_widget_0_3 = new ListPanel(base.Context);
		_widget_0.AddChild(_widget_0_3);
		_widget_0_3_0 = new TextWidget(base.Context);
		_widget_0_3.AddChild(_widget_0_3_0);
		_widget_0_3_1 = new TextWidget(base.Context);
		_widget_0_3.AddChild(_widget_0_3_1);
		_widget_0_3_2 = new TextWidget(base.Context);
		_widget_0_3.AddChild(_widget_0_3_2);
	}

	public void SetIds()
	{
		_widget_0.Id = "ActionContainer";
		_widget_0_2.Id = "DirectionWidget";
	}

	public void SetAttributes()
	{
		base.WidthSizePolicy = SizePolicy.StretchToParent;
		base.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0.SuggestedWidth = 200f;
		_widget_0.SuggestedHeight = 200f;
		_widget_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0.VerticalAlignment = VerticalAlignment.Bottom;
		_widget_0.PositionYOffset = -130f;
		_widget_0_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0_0.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0_0.SuggestedWidth = 459f;
		_widget_0_0.SuggestedHeight = 459f;
		_widget_0_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_0.Sprite = base.Context.SpriteData.GetSprite("General\\RadialMenu\\radial_menu_bg");
		_widget_0_0.Color = new Color(0f, 0f, 0f, 0.4666667f);
		_widget_0_1.WidthSizePolicy = SizePolicy.StretchToParent;
		_widget_0_1.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_0_1.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_1.VerticalAlignment = VerticalAlignment.Bottom;
		_widget_0_1.DistanceFromCenterModifier = 160f;
		_widget_0_1.DirectionWidget = _widget_0_2;
		_widget_0_2.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0_2.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0_2.SuggestedWidth = 13f;
		_widget_0_2.SuggestedHeight = 13f;
		_widget_0_2.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_2.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_2.Sprite = base.Context.SpriteData.GetSprite("BlankWhiteCircle");
		_widget_0_2.AlphaFactor = 0.5f;
		_widget_0_3.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_0_3.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0_3.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_3.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_3.StackLayout.LayoutMethod = LayoutMethod.VerticalBottomToTop;
		_widget_0_3_0.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_0_3_0.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0_3_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_3_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_3_0.Brush = base.Context.GetBrush("Mission.DropCircle.ItemText");
		_widget_0_3_0.ClipContents = false;
		_widget_0_3_1.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_0_3_1.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0_3_1.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_3_1.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_3_1.Brush = base.Context.GetBrush("Mission.DropCircle.ItemText");
		_widget_0_3_1.ClipContents = false;
		_widget_0_3_2.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_0_3_2.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0_3_2.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_3_2.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_3_2.Brush = base.Context.GetBrush("Mission.DropCircle.ItemText");
		_widget_0_3_2.ClipContents = false;
	}

	public void RefreshBindingWithChildren()
	{
		MissionMainAgentControllerEquipDropVM datasource_Root = _datasource_Root;
		SetDataSource(null);
		SetDataSource(datasource_Root);
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
		_widget_0.PropertyChanged -= PropertyChangedListenerOf_widget_0;
		_widget_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0;
		_widget_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0;
		_widget_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0;
		_widget_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0;
		_widget_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0;
		_widget_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0;
		_widget_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0;
		_widget_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0;
		_widget_0_3_0.PropertyChanged -= PropertyChangedListenerOf_widget_0_3_0;
		_widget_0_3_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_3_0;
		_widget_0_3_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_3_0;
		_widget_0_3_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_3_0;
		_widget_0_3_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_3_0;
		_widget_0_3_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_3_0;
		_widget_0_3_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_3_0;
		_widget_0_3_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_3_0;
		_widget_0_3_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_3_0;
		_widget_0_3_1.PropertyChanged -= PropertyChangedListenerOf_widget_0_3_1;
		_widget_0_3_1.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_3_1;
		_widget_0_3_1.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_3_1;
		_widget_0_3_1.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_3_1;
		_widget_0_3_1.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_3_1;
		_widget_0_3_1.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_3_1;
		_widget_0_3_1.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_3_1;
		_widget_0_3_1.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_3_1;
		_widget_0_3_1.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_3_1;
		_widget_0_3_2.PropertyChanged -= PropertyChangedListenerOf_widget_0_3_2;
		_widget_0_3_2.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_3_2;
		_widget_0_3_2.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_3_2;
		_widget_0_3_2.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_3_2;
		_widget_0_3_2.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_3_2;
		_widget_0_3_2.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_3_2;
		_widget_0_3_2.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_3_2;
		_widget_0_3_2.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_3_2;
		_widget_0_3_2.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_3_2;
		if (_datasource_Root_EquippedWeapons != null)
		{
			_datasource_Root_EquippedWeapons.ListChanged -= OnList_datasource_Root_EquippedWeaponsChanged;
			for (int num = _widget_0_1.ChildCount - 1; num >= 0; num--)
			{
				Widget child = _widget_0_1.GetChild(num);
				((MainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate)child).OnBeforeRemovedChild(child);
				((MainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate)_widget_0_1.GetChild(num)).DestroyDataSource();
			}
			_datasource_Root_EquippedWeapons = null;
		}
		_datasource_Root = null;
	}

	public void SetDataSource(MissionMainAgentControllerEquipDropVM dataSource)
	{
		RefreshDataSource_datasource_Root(dataSource);
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
		if (propertyName == "IsVisible")
		{
			_datasource_Root.IsActive = _widget_0.IsVisible;
		}
	}

	private void PropertyChangedListenerOf_widget_0_3_0(PropertyOwnerObject propertyOwnerObject, string propertyName, object e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_0(propertyName);
	}

	private void boolPropertyChangedListenerOf_widget_0_3_0(PropertyOwnerObject propertyOwnerObject, string propertyName, bool e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_0(propertyName);
	}

	private void floatPropertyChangedListenerOf_widget_0_3_0(PropertyOwnerObject propertyOwnerObject, string propertyName, float e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_0(propertyName);
	}

	private void Vec2PropertyChangedListenerOf_widget_0_3_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Vec2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_0(propertyName);
	}

	private void Vector2PropertyChangedListenerOf_widget_0_3_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Vector2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_0(propertyName);
	}

	private void doublePropertyChangedListenerOf_widget_0_3_0(PropertyOwnerObject propertyOwnerObject, string propertyName, double e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_0(propertyName);
	}

	private void intPropertyChangedListenerOf_widget_0_3_0(PropertyOwnerObject propertyOwnerObject, string propertyName, int e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_0(propertyName);
	}

	private void uintPropertyChangedListenerOf_widget_0_3_0(PropertyOwnerObject propertyOwnerObject, string propertyName, uint e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_0(propertyName);
	}

	private void ColorPropertyChangedListenerOf_widget_0_3_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Color e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_0(propertyName);
	}

	private void HandleWidgetPropertyChangeOf_widget_0_3_0(string propertyName)
	{
		_ = propertyName == "Text";
	}

	private void PropertyChangedListenerOf_widget_0_3_1(PropertyOwnerObject propertyOwnerObject, string propertyName, object e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_1(propertyName);
	}

	private void boolPropertyChangedListenerOf_widget_0_3_1(PropertyOwnerObject propertyOwnerObject, string propertyName, bool e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_1(propertyName);
	}

	private void floatPropertyChangedListenerOf_widget_0_3_1(PropertyOwnerObject propertyOwnerObject, string propertyName, float e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_1(propertyName);
	}

	private void Vec2PropertyChangedListenerOf_widget_0_3_1(PropertyOwnerObject propertyOwnerObject, string propertyName, Vec2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_1(propertyName);
	}

	private void Vector2PropertyChangedListenerOf_widget_0_3_1(PropertyOwnerObject propertyOwnerObject, string propertyName, Vector2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_1(propertyName);
	}

	private void doublePropertyChangedListenerOf_widget_0_3_1(PropertyOwnerObject propertyOwnerObject, string propertyName, double e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_1(propertyName);
	}

	private void intPropertyChangedListenerOf_widget_0_3_1(PropertyOwnerObject propertyOwnerObject, string propertyName, int e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_1(propertyName);
	}

	private void uintPropertyChangedListenerOf_widget_0_3_1(PropertyOwnerObject propertyOwnerObject, string propertyName, uint e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_1(propertyName);
	}

	private void ColorPropertyChangedListenerOf_widget_0_3_1(PropertyOwnerObject propertyOwnerObject, string propertyName, Color e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_1(propertyName);
	}

	private void HandleWidgetPropertyChangeOf_widget_0_3_1(string propertyName)
	{
		if (propertyName == "Text")
		{
			_datasource_Root.PressToEquipText = _widget_0_3_1.Text;
		}
	}

	private void PropertyChangedListenerOf_widget_0_3_2(PropertyOwnerObject propertyOwnerObject, string propertyName, object e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_2(propertyName);
	}

	private void boolPropertyChangedListenerOf_widget_0_3_2(PropertyOwnerObject propertyOwnerObject, string propertyName, bool e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_2(propertyName);
	}

	private void floatPropertyChangedListenerOf_widget_0_3_2(PropertyOwnerObject propertyOwnerObject, string propertyName, float e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_2(propertyName);
	}

	private void Vec2PropertyChangedListenerOf_widget_0_3_2(PropertyOwnerObject propertyOwnerObject, string propertyName, Vec2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_2(propertyName);
	}

	private void Vector2PropertyChangedListenerOf_widget_0_3_2(PropertyOwnerObject propertyOwnerObject, string propertyName, Vector2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_2(propertyName);
	}

	private void doublePropertyChangedListenerOf_widget_0_3_2(PropertyOwnerObject propertyOwnerObject, string propertyName, double e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_2(propertyName);
	}

	private void intPropertyChangedListenerOf_widget_0_3_2(PropertyOwnerObject propertyOwnerObject, string propertyName, int e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_2(propertyName);
	}

	private void uintPropertyChangedListenerOf_widget_0_3_2(PropertyOwnerObject propertyOwnerObject, string propertyName, uint e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_2(propertyName);
	}

	private void ColorPropertyChangedListenerOf_widget_0_3_2(PropertyOwnerObject propertyOwnerObject, string propertyName, Color e)
	{
		HandleWidgetPropertyChangeOf_widget_0_3_2(propertyName);
	}

	private void HandleWidgetPropertyChangeOf_widget_0_3_2(string propertyName)
	{
		if (propertyName == "Text")
		{
			_datasource_Root.HoldToDropText = _widget_0_3_2.Text;
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
		case "EquippedWeapons":
			RefreshDataSource_datasource_Root_EquippedWeapons(_datasource_Root.EquippedWeapons);
			break;
		case "IsActive":
			_widget_0.IsVisible = _datasource_Root.IsActive;
			break;
		case "SelectedItemText":
			break;
		case "PressToEquipText":
			_widget_0_3_1.Text = _datasource_Root.PressToEquipText;
			break;
		case "HoldToDropText":
			_widget_0_3_2.Text = _datasource_Root.HoldToDropText;
			break;
		}
	}

	public void OnList_datasource_Root_EquippedWeaponsChanged(object sender, TaleWorlds.Library.ListChangedEventArgs e)
	{
		switch (e.ListChangedType)
		{
		case TaleWorlds.Library.ListChangedType.Reset:
		{
			for (int num = _widget_0_1.ChildCount - 1; num >= 0; num--)
			{
				Widget child3 = _widget_0_1.GetChild(num);
				((MainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate)child3).OnBeforeRemovedChild(child3);
				Widget child4 = _widget_0_1.GetChild(num);
				((MainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate)child4).SetDataSource(null);
				_widget_0_1.RemoveChild(child4);
			}
			break;
		}
		case TaleWorlds.Library.ListChangedType.Sorted:
		{
			for (int i = 0; i < _datasource_Root_EquippedWeapons.Count; i++)
			{
				ControllerEquippedItemVM bindingObject = _datasource_Root_EquippedWeapons[i];
				_widget_0_1.FindChild((Widget widget) => widget.GetComponent<GeneratedWidgetData>().Data == bindingObject).SetSiblingIndex(i);
			}
			break;
		}
		case TaleWorlds.Library.ListChangedType.ItemAdded:
		{
			MainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate mainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate = new MainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate(base.Context);
			GeneratedWidgetData generatedWidgetData = new GeneratedWidgetData(mainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate);
			ControllerEquippedItemVM dataSource = (ControllerEquippedItemVM)(generatedWidgetData.Data = _datasource_Root_EquippedWeapons[e.NewIndex]);
			mainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate.AddComponent(generatedWidgetData);
			_widget_0_1.AddChildAtIndex(mainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate, e.NewIndex);
			mainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate.CreateWidgets();
			mainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate.SetIds();
			mainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate.SetAttributes();
			mainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate.SetDataSource(dataSource);
			break;
		}
		case TaleWorlds.Library.ListChangedType.ItemBeforeDeleted:
		{
			Widget child2 = _widget_0_1.GetChild(e.NewIndex);
			((MainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate)child2).OnBeforeRemovedChild(child2);
			break;
		}
		case TaleWorlds.Library.ListChangedType.ItemDeleted:
		{
			Widget child = _widget_0_1.GetChild(e.NewIndex);
			((MainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate)child).SetDataSource(null);
			_widget_0_1.RemoveChild(child);
			break;
		}
		case TaleWorlds.Library.ListChangedType.ItemChanged:
			break;
		}
	}

	private void RefreshDataSource_datasource_Root(MissionMainAgentControllerEquipDropVM newDataSource)
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
			_widget_0.PropertyChanged -= PropertyChangedListenerOf_widget_0;
			_widget_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0;
			_widget_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0;
			_widget_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0;
			_widget_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0;
			_widget_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0;
			_widget_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0;
			_widget_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0;
			_widget_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0;
			_widget_0_3_0.PropertyChanged -= PropertyChangedListenerOf_widget_0_3_0;
			_widget_0_3_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_3_0;
			_widget_0_3_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_3_0;
			_widget_0_3_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_3_0;
			_widget_0_3_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_3_0;
			_widget_0_3_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_3_0;
			_widget_0_3_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_3_0;
			_widget_0_3_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_3_0;
			_widget_0_3_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_3_0;
			_widget_0_3_1.PropertyChanged -= PropertyChangedListenerOf_widget_0_3_1;
			_widget_0_3_1.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_3_1;
			_widget_0_3_1.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_3_1;
			_widget_0_3_1.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_3_1;
			_widget_0_3_1.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_3_1;
			_widget_0_3_1.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_3_1;
			_widget_0_3_1.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_3_1;
			_widget_0_3_1.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_3_1;
			_widget_0_3_1.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_3_1;
			_widget_0_3_2.PropertyChanged -= PropertyChangedListenerOf_widget_0_3_2;
			_widget_0_3_2.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_3_2;
			_widget_0_3_2.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_3_2;
			_widget_0_3_2.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_3_2;
			_widget_0_3_2.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_3_2;
			_widget_0_3_2.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_3_2;
			_widget_0_3_2.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_3_2;
			_widget_0_3_2.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_3_2;
			_widget_0_3_2.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_3_2;
			if (_datasource_Root_EquippedWeapons != null)
			{
				_datasource_Root_EquippedWeapons.ListChanged -= OnList_datasource_Root_EquippedWeaponsChanged;
				for (int num = _widget_0_1.ChildCount - 1; num >= 0; num--)
				{
					Widget child = _widget_0_1.GetChild(num);
					((MainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate)child).OnBeforeRemovedChild(child);
					Widget child2 = _widget_0_1.GetChild(num);
					((MainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate)child2).SetDataSource(null);
					_widget_0_1.RemoveChild(child2);
				}
				_datasource_Root_EquippedWeapons = null;
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
		_widget_0.IsVisible = _datasource_Root.IsActive;
		_widget_0.PropertyChanged += PropertyChangedListenerOf_widget_0;
		_widget_0.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0;
		_widget_0.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0;
		_widget_0.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0;
		_widget_0.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0;
		_widget_0.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0;
		_widget_0.intPropertyChanged += intPropertyChangedListenerOf_widget_0;
		_widget_0.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0;
		_widget_0.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0;
		_widget_0_3_0.PropertyChanged += PropertyChangedListenerOf_widget_0_3_0;
		_widget_0_3_0.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_3_0;
		_widget_0_3_0.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_3_0;
		_widget_0_3_0.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_3_0;
		_widget_0_3_0.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_3_0;
		_widget_0_3_0.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_3_0;
		_widget_0_3_0.intPropertyChanged += intPropertyChangedListenerOf_widget_0_3_0;
		_widget_0_3_0.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_3_0;
		_widget_0_3_0.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_3_0;
		_widget_0_3_1.Text = _datasource_Root.PressToEquipText;
		_widget_0_3_1.PropertyChanged += PropertyChangedListenerOf_widget_0_3_1;
		_widget_0_3_1.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_3_1;
		_widget_0_3_1.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_3_1;
		_widget_0_3_1.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_3_1;
		_widget_0_3_1.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_3_1;
		_widget_0_3_1.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_3_1;
		_widget_0_3_1.intPropertyChanged += intPropertyChangedListenerOf_widget_0_3_1;
		_widget_0_3_1.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_3_1;
		_widget_0_3_1.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_3_1;
		_widget_0_3_2.Text = _datasource_Root.HoldToDropText;
		_widget_0_3_2.PropertyChanged += PropertyChangedListenerOf_widget_0_3_2;
		_widget_0_3_2.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_3_2;
		_widget_0_3_2.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_3_2;
		_widget_0_3_2.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_3_2;
		_widget_0_3_2.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_3_2;
		_widget_0_3_2.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_3_2;
		_widget_0_3_2.intPropertyChanged += intPropertyChangedListenerOf_widget_0_3_2;
		_widget_0_3_2.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_3_2;
		_widget_0_3_2.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_3_2;
		_datasource_Root_EquippedWeapons = _datasource_Root.EquippedWeapons;
		if (_datasource_Root_EquippedWeapons != null)
		{
			_datasource_Root_EquippedWeapons.ListChanged += OnList_datasource_Root_EquippedWeaponsChanged;
			for (int i = 0; i < _datasource_Root_EquippedWeapons.Count; i++)
			{
				MainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate mainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate = new MainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate(base.Context);
				GeneratedWidgetData generatedWidgetData = new GeneratedWidgetData(mainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate);
				ControllerEquippedItemVM dataSource = (ControllerEquippedItemVM)(generatedWidgetData.Data = _datasource_Root_EquippedWeapons[i]);
				mainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate.AddComponent(generatedWidgetData);
				_widget_0_1.AddChildAtIndex(mainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate, i);
				mainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate.CreateWidgets();
				mainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate.SetIds();
				mainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate.SetAttributes();
				mainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate.SetDataSource(dataSource);
			}
		}
	}

	private void RefreshDataSource_datasource_Root_EquippedWeapons(MBBindingList<ControllerEquippedItemVM> newDataSource)
	{
		if (_datasource_Root_EquippedWeapons != null)
		{
			_datasource_Root_EquippedWeapons.ListChanged -= OnList_datasource_Root_EquippedWeaponsChanged;
			for (int num = _widget_0_1.ChildCount - 1; num >= 0; num--)
			{
				Widget child = _widget_0_1.GetChild(num);
				((MainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate)child).OnBeforeRemovedChild(child);
				Widget child2 = _widget_0_1.GetChild(num);
				((MainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate)child2).SetDataSource(null);
				_widget_0_1.RemoveChild(child2);
			}
			_datasource_Root_EquippedWeapons = null;
		}
		_datasource_Root_EquippedWeapons = newDataSource;
		_datasource_Root_EquippedWeapons = _datasource_Root.EquippedWeapons;
		if (_datasource_Root_EquippedWeapons != null)
		{
			_datasource_Root_EquippedWeapons.ListChanged += OnList_datasource_Root_EquippedWeaponsChanged;
			for (int i = 0; i < _datasource_Root_EquippedWeapons.Count; i++)
			{
				MainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate mainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate = new MainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate(base.Context);
				GeneratedWidgetData generatedWidgetData = new GeneratedWidgetData(mainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate);
				ControllerEquippedItemVM dataSource = (ControllerEquippedItemVM)(generatedWidgetData.Data = _datasource_Root_EquippedWeapons[i]);
				mainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate.AddComponent(generatedWidgetData);
				_widget_0_1.AddChildAtIndex(mainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate, i);
				mainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate.CreateWidgets();
				mainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate.SetIds();
				mainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate.SetAttributes();
				mainAgentControllerEquipDrop__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentControllerEquipDropVM_Dependency_1_ItemTemplate.SetDataSource(dataSource);
			}
		}
	}
}
