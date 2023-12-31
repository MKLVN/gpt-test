using System.ComponentModel;
using System.Numerics;
using TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement.Supporters;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.Library;

namespace SandBox.GauntletUI.AutoGenerated1;

public class ClanScreen__TaleWorlds_CampaignSystem_ViewModelCollection_ClanManagement_ClanManagementVM_Dependency_51_ClanSupporterGroupTuple__InheritedPrefab : ButtonWidget
{
	private ButtonWidget _widget;

	private ListPanel _widget_0;

	private TextWidget _widget_0_0;

	private RichTextWidget _widget_0_1;

	private ClanSupporterGroupVM _datasource_Root;

	public ClanScreen__TaleWorlds_CampaignSystem_ViewModelCollection_ClanManagement_ClanManagementVM_Dependency_51_ClanSupporterGroupTuple__InheritedPrefab(UIContext context)
		: base(context)
	{
	}

	public virtual void CreateWidgets()
	{
		_widget = this;
		_widget_0 = new ListPanel(base.Context);
		_widget.AddChild(_widget_0);
		_widget_0_0 = new TextWidget(base.Context);
		_widget_0.AddChild(_widget_0_0);
		_widget_0_1 = new RichTextWidget(base.Context);
		_widget_0.AddChild(_widget_0_1);
	}

	public virtual void SetIds()
	{
	}

	public virtual void SetAttributes()
	{
		base.WidthSizePolicy = SizePolicy.Fixed;
		base.HeightSizePolicy = SizePolicy.Fixed;
		base.SuggestedWidth = 585f;
		base.SuggestedHeight = 87f;
		base.Brush = base.Context.GetBrush("Clan.Item.Tuple");
		_widget_0.WidthSizePolicy = SizePolicy.StretchToParent;
		_widget_0.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_0.MarginLeft = 10f;
		_widget_0.DoNotAcceptEvents = true;
		_widget_0_0.DoNotAcceptEvents = true;
		_widget_0_0.WidthSizePolicy = SizePolicy.StretchToParent;
		_widget_0_0.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_0_0.MarginLeft = 94f;
		_widget_0_0.Brush = base.Context.GetBrush("Clan.Tuple.Name.Text");
		_widget_0_1.DoNotAcceptEvents = true;
		_widget_0_1.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0_1.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_0_1.SuggestedWidth = 90f;
		_widget_0_1.HorizontalAlignment = HorizontalAlignment.Right;
		_widget_0_1.Brush = base.Context.GetBrush("Clan.Tuple.Name.Text");
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
			_datasource_Root = null;
		}
	}

	public virtual void SetDataSource(ClanSupporterGroupVM dataSource)
	{
		RefreshDataSource_datasource_Root(dataSource);
	}

	private void EventListenerOf_widget(Widget widget, string commandName, object[] args)
	{
		if (commandName == "Click")
		{
			_datasource_Root.ExecuteSelect();
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
		if (propertyName == "IsSelected")
		{
			_datasource_Root.IsSelected = _widget.IsSelected;
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
			_datasource_Root.Name = _widget_0_0.Text;
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
		if (propertyName == "Text")
		{
			_datasource_Root.TotalInfluence = _widget_0_1.Text;
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
		case "IsSelected":
			_widget.IsSelected = _datasource_Root.IsSelected;
			break;
		case "Name":
			_widget_0_0.Text = _datasource_Root.Name;
			break;
		case "TotalInfluence":
			_widget_0_1.Text = _datasource_Root.TotalInfluence;
			break;
		}
	}

	private void RefreshDataSource_datasource_Root(ClanSupporterGroupVM newDataSource)
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
			_widget.IsSelected = _datasource_Root.IsSelected;
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
			_widget_0_0.Text = _datasource_Root.Name;
			_widget_0_0.PropertyChanged += PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_0;
			_widget_0_0.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_0;
			_widget_0_0.intPropertyChanged += intPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_0;
			_widget_0_0.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_0;
			_widget_0_1.Text = _datasource_Root.TotalInfluence;
			_widget_0_1.PropertyChanged += PropertyChangedListenerOf_widget_0_1;
			_widget_0_1.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_1;
			_widget_0_1.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_1;
			_widget_0_1.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_1;
			_widget_0_1.intPropertyChanged += intPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_1;
			_widget_0_1.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_1;
		}
	}
}
