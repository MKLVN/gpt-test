using System.ComponentModel;
using System.Numerics;
using TaleWorlds.GauntletUI;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets.Mission.OrderOfBattle;
using TaleWorlds.MountAndBlade.ViewModelCollection.Order;

namespace TaleWorlds.MountAndBlade.GauntletUI.AutoGenerated0;

public class OrderRadial__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_12_ItemTemplate : OrderOfBattleFormationFilterVisualBrushWidget
{
	private OrderOfBattleFormationFilterVisualBrushWidget _widget;

	private OrderTroopItemFilterVM _datasource_Root;

	public OrderRadial__TaleWorlds_MountAndBlade_ViewModelCollection_Order_MissionOrderVM_Dependency_12_ItemTemplate(UIContext context)
		: base(context)
	{
	}

	public void CreateWidgets()
	{
		_widget = this;
	}

	public void SetIds()
	{
	}

	public void SetAttributes()
	{
		base.WidthSizePolicy = SizePolicy.Fixed;
		base.HeightSizePolicy = SizePolicy.Fixed;
		base.SuggestedWidth = 20f;
		base.SuggestedHeight = 20f;
		base.Brush = base.Context.GetBrush("OrderOfBattle.Formation.Class.Type");
		base.UnsetBrush = base.Context.GetBrush("OrderOfBattle.Filter.Unset");
		base.SpearBrush = base.Context.GetBrush("OrderOfBattle.Filter.Spear");
		base.ShieldBrush = base.Context.GetBrush("OrderOfBattle.Filter.Shield");
		base.ThrownBrush = base.Context.GetBrush("OrderOfBattle.Filter.Thrown");
		base.HeavyBrush = base.Context.GetBrush("OrderOfBattle.Filter.Heavy");
		base.HighTierBrush = base.Context.GetBrush("OrderOfBattle.Filter.HighTier");
		base.LowTierBrush = base.Context.GetBrush("OrderOfBattle.Filter.LowTier");
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
			_datasource_Root = null;
		}
	}

	public void SetDataSource(OrderTroopItemFilterVM dataSource)
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
		if (propertyName == "FormationFilter")
		{
			_datasource_Root.FilterTypeValue = _widget.FormationFilter;
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
		if (propertyName == "FilterTypeValue")
		{
			_widget.FormationFilter = _datasource_Root.FilterTypeValue;
		}
	}

	private void RefreshDataSource_datasource_Root(OrderTroopItemFilterVM newDataSource)
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
			_widget.FormationFilter = _datasource_Root.FilterTypeValue;
			_widget.PropertyChanged += PropertyChangedListenerOf_widget;
			_widget.boolPropertyChanged += boolPropertyChangedListenerOf_widget;
			_widget.floatPropertyChanged += floatPropertyChangedListenerOf_widget;
			_widget.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget;
			_widget.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget;
			_widget.doublePropertyChanged += doublePropertyChangedListenerOf_widget;
			_widget.intPropertyChanged += intPropertyChangedListenerOf_widget;
			_widget.uintPropertyChanged += uintPropertyChangedListenerOf_widget;
			_widget.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget;
		}
	}
}
