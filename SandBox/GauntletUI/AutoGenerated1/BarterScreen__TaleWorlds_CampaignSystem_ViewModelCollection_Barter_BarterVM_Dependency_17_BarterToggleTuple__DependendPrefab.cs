using System.ComponentModel;
using System.Numerics;
using TaleWorlds.CampaignSystem.ViewModelCollection.Barter;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.GauntletUI.Layout;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets.Party;

namespace SandBox.GauntletUI.AutoGenerated1;

public class BarterScreen__TaleWorlds_CampaignSystem_ViewModelCollection_Barter_BarterVM_Dependency_17_BarterToggleTuple__DependendPrefab : PartyHeaderToggleWidget
{
	private PartyHeaderToggleWidget _widget;

	private ListPanel _widget_0;

	private BrushWidget _widget_0_0;

	private RichTextWidget _widget_0_1;

	private RichTextWidget _widget_0_2;

	private ButtonWidget _widget_1;

	private HintWidget _widget_1_0;

	private BarterVM _datasource_Root;

	public BarterScreen__TaleWorlds_CampaignSystem_ViewModelCollection_Barter_BarterVM_Dependency_17_BarterToggleTuple__DependendPrefab(UIContext context)
		: base(context)
	{
	}

	private VisualDefinition CreateVisualDefinitionToggle()
	{
		VisualDefinition visualDefinition = new VisualDefinition("Toggle", 0.045f, 0f, easeIn: false);
		visualDefinition.AddVisualState(new VisualState("Default")
		{
			SuggestedWidth = 465f
		});
		visualDefinition.AddVisualState(new VisualState("Pressed")
		{
			SuggestedWidth = 465f
		});
		visualDefinition.AddVisualState(new VisualState("Selected")
		{
			SuggestedWidth = 465f
		});
		visualDefinition.AddVisualState(new VisualState("Hovered")
		{
			SuggestedWidth = 465f
		});
		return visualDefinition;
	}

	public void CreateWidgets()
	{
		_widget = this;
		_widget_0 = new ListPanel(base.Context);
		_widget.AddChild(_widget_0);
		_widget_0_0 = new BrushWidget(base.Context);
		_widget_0.AddChild(_widget_0_0);
		_widget_0_1 = new RichTextWidget(base.Context);
		_widget_0.AddChild(_widget_0_1);
		_widget_0_2 = new RichTextWidget(base.Context);
		_widget_0.AddChild(_widget_0_2);
		_widget_1 = new ButtonWidget(base.Context);
		_widget.AddChild(_widget_1);
		_widget_1_0 = new HintWidget(base.Context);
		_widget_1.AddChild(_widget_1_0);
	}

	public void SetIds()
	{
		_widget_0.Id = "Description";
		_widget_0_0.Id = "CollapseIndicator";
		_widget_1.Id = "TransferAll";
	}

	public void SetAttributes()
	{
		base.VisualDefinition = CreateVisualDefinitionToggle();
		base.WidthSizePolicy = SizePolicy.Fixed;
		base.HeightSizePolicy = SizePolicy.Fixed;
		base.SuggestedWidth = 465f;
		base.SuggestedHeight = 73f;
		base.VerticalAlignment = VerticalAlignment.Top;
		base.MarginTop = 4f;
		base.Brush = base.Context.GetBrush("Barter.LeftPanel.Toggle");
		base.CollapseIndicator = _widget_0_0;
		base.UpdateChildrenStates = true;
		_widget_0.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_0.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_0.MarginBottom = 10f;
		_widget_0.IsDisabled = true;
		_widget_0.StackLayout.LayoutMethod = LayoutMethod.HorizontalLeftToRight;
		_widget_0.UpdateChildrenStates = true;
		_widget_0.DoNotPassEventsToChildren = true;
		_widget_0_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0_0.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0_0.SuggestedWidth = 40f;
		_widget_0_0.SuggestedHeight = 40f;
		_widget_0_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_0.PositionYOffset = 5f;
		_widget_0_0.MarginRight = 5f;
		_widget_0_0.Brush = base.Context.GetBrush("Party.Toggle.ExpandIndicator");
		_widget_0_1.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_0_1.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_0_1.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_1.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_1.MarginRight = 5f;
		_widget_0_1.Brush = base.Context.GetBrush("Party.Text.Toggle");
		_widget_0_2.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_0_2.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_0_2.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_2.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_2.MarginLeft = 5f;
		_widget_0_2.Brush = base.Context.GetBrush("Party.Text.Toggle");
		_widget_0_2.Text = "";
		_widget_1.DoNotPassEventsToChildren = true;
		_widget_1.WidthSizePolicy = SizePolicy.Fixed;
		_widget_1.HeightSizePolicy = SizePolicy.Fixed;
		_widget_1.SuggestedWidth = 42f;
		_widget_1.SuggestedHeight = 42f;
		_widget_1.HorizontalAlignment = HorizontalAlignment.Right;
		_widget_1.VerticalAlignment = VerticalAlignment.Center;
		_widget_1.MarginRight = 5f;
		_widget_1.MarginLeft = 5f;
		_widget_1.Brush = base.Context.GetBrush("ButtonLeftDoubleArrowBrush1");
		_widget_1_0.WidthSizePolicy = SizePolicy.StretchToParent;
		_widget_1_0.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_1_0.IsDisabled = true;
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
			_widget_0_1.PropertyChanged -= PropertyChangedListenerOf_widget_0_1;
			_widget_0_1.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_1;
			_widget_0_1.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_1;
			_widget_0_1.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_1;
			_widget_0_1.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_1;
			_widget_1.EventFire -= EventListenerOf_widget_1;
			_widget_1_0.EventFire -= EventListenerOf_widget_1_0;
			_datasource_Root = null;
		}
	}

	public void SetDataSource(BarterVM dataSource)
	{
		RefreshDataSource_datasource_Root(dataSource);
	}

	private void EventListenerOf_widget(Widget widget, string commandName, object[] args)
	{
		_ = commandName == "Drop";
	}

	private void EventListenerOf_widget_1(Widget widget, string commandName, object[] args)
	{
		if (commandName == "Click")
		{
			_datasource_Root.ExecuteTransferAllLeftItem();
		}
	}

	private void EventListenerOf_widget_1_0(Widget widget, string commandName, object[] args)
	{
		_ = commandName == "HoverBegin";
		_ = commandName == "HoverEnd";
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
		if (propertyName == "Text")
		{
			_datasource_Root.ItemLbl = _widget_0_1.Text;
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
		if (propertyName == "ItemLbl")
		{
			_widget_0_1.Text = _datasource_Root.ItemLbl;
		}
	}

	private void RefreshDataSource_datasource_Root(BarterVM newDataSource)
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
			_widget_0_1.PropertyChanged -= PropertyChangedListenerOf_widget_0_1;
			_widget_0_1.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_1;
			_widget_0_1.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_1;
			_widget_0_1.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_1;
			_widget_0_1.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_1;
			_widget_1.EventFire -= EventListenerOf_widget_1;
			_widget_1_0.EventFire -= EventListenerOf_widget_1_0;
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
			_widget.EventFire += EventListenerOf_widget;
			_widget_0_1.Text = _datasource_Root.ItemLbl;
			_widget_0_1.PropertyChanged += PropertyChangedListenerOf_widget_0_1;
			_widget_0_1.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_1;
			_widget_0_1.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_1;
			_widget_0_1.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_1;
			_widget_0_1.intPropertyChanged += intPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_1;
			_widget_1.EventFire += EventListenerOf_widget_1;
			_widget_1_0.EventFire += EventListenerOf_widget_1_0;
		}
	}
}
