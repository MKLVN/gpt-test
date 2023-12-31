using System.ComponentModel;
using System.Numerics;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.Library;

namespace SandBox.GauntletUI.AutoGenerated1;

public class ClanScreen__TaleWorlds_CampaignSystem_ViewModelCollection_ClanManagement_ClanManagementVM_Dependency_55_ItemTemplate : ListPanel
{
	private ListPanel _widget;

	private TextWidget _widget_0;

	private TextWidget _widget_1;

	private RichTextWidget _widget_2;

	private SelectableItemPropertyVM _datasource_Root;

	public ClanScreen__TaleWorlds_CampaignSystem_ViewModelCollection_ClanManagement_ClanManagementVM_Dependency_55_ItemTemplate(UIContext context)
		: base(context)
	{
	}

	public void CreateWidgets()
	{
		_widget = this;
		_widget_0 = new TextWidget(base.Context);
		_widget.AddChild(_widget_0);
		_widget_1 = new TextWidget(base.Context);
		_widget.AddChild(_widget_1);
		_widget_2 = new RichTextWidget(base.Context);
		_widget.AddChild(_widget_2);
	}

	public void SetIds()
	{
	}

	public void SetAttributes()
	{
		base.WidthSizePolicy = SizePolicy.StretchToParent;
		base.HeightSizePolicy = SizePolicy.CoverChildren;
		base.MarginTop = 5f;
		base.MarginBottom = 5f;
		_widget_0.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_0.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0.SuggestedHeight = 40f;
		_widget_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_0.Brush = base.Context.GetBrush("Clan.Stat.Name.Text");
		_widget_1.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_1.HeightSizePolicy = SizePolicy.Fixed;
		_widget_1.SuggestedHeight = 40f;
		_widget_1.VerticalAlignment = VerticalAlignment.Center;
		_widget_1.MarginLeft = 5f;
		_widget_1.MarginRight = 5f;
		_widget_1.Brush = base.Context.GetBrush("Clan.Stat.Seperator.Text");
		_widget_2.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_2.HeightSizePolicy = SizePolicy.Fixed;
		_widget_2.SuggestedHeight = 40f;
		_widget_2.VerticalAlignment = VerticalAlignment.Center;
		_widget_2.Brush = base.Context.GetBrush("Clan.Stat.Value.Text");
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
			_widget_0.PropertyChanged -= PropertyChangedListenerOf_widget_0;
			_widget_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0;
			_widget_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0;
			_widget_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0;
			_widget_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0;
			_widget_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0;
			_widget_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0;
			_widget_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0;
			_widget_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0;
			_widget_1.PropertyChanged -= PropertyChangedListenerOf_widget_1;
			_widget_1.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_1;
			_widget_1.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_1;
			_widget_1.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_1;
			_widget_1.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_1;
			_widget_1.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_1;
			_widget_1.intPropertyChanged -= intPropertyChangedListenerOf_widget_1;
			_widget_1.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_1;
			_widget_1.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_1;
			_widget_2.PropertyChanged -= PropertyChangedListenerOf_widget_2;
			_widget_2.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_2;
			_widget_2.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_2;
			_widget_2.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_2;
			_widget_2.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_2;
			_widget_2.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_2;
			_widget_2.intPropertyChanged -= intPropertyChangedListenerOf_widget_2;
			_widget_2.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_2;
			_widget_2.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_2;
			_datasource_Root = null;
		}
	}

	public void SetDataSource(SelectableItemPropertyVM dataSource)
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
		if (propertyName == "Text")
		{
			_datasource_Root.Name = _widget_0.Text;
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
		if (propertyName == "Text")
		{
			_datasource_Root.ColonText = _widget_1.Text;
		}
	}

	private void PropertyChangedListenerOf_widget_2(PropertyOwnerObject propertyOwnerObject, string propertyName, object e)
	{
		HandleWidgetPropertyChangeOf_widget_2(propertyName);
	}

	private void boolPropertyChangedListenerOf_widget_2(PropertyOwnerObject propertyOwnerObject, string propertyName, bool e)
	{
		HandleWidgetPropertyChangeOf_widget_2(propertyName);
	}

	private void floatPropertyChangedListenerOf_widget_2(PropertyOwnerObject propertyOwnerObject, string propertyName, float e)
	{
		HandleWidgetPropertyChangeOf_widget_2(propertyName);
	}

	private void Vec2PropertyChangedListenerOf_widget_2(PropertyOwnerObject propertyOwnerObject, string propertyName, Vec2 e)
	{
		HandleWidgetPropertyChangeOf_widget_2(propertyName);
	}

	private void Vector2PropertyChangedListenerOf_widget_2(PropertyOwnerObject propertyOwnerObject, string propertyName, Vector2 e)
	{
		HandleWidgetPropertyChangeOf_widget_2(propertyName);
	}

	private void doublePropertyChangedListenerOf_widget_2(PropertyOwnerObject propertyOwnerObject, string propertyName, double e)
	{
		HandleWidgetPropertyChangeOf_widget_2(propertyName);
	}

	private void intPropertyChangedListenerOf_widget_2(PropertyOwnerObject propertyOwnerObject, string propertyName, int e)
	{
		HandleWidgetPropertyChangeOf_widget_2(propertyName);
	}

	private void uintPropertyChangedListenerOf_widget_2(PropertyOwnerObject propertyOwnerObject, string propertyName, uint e)
	{
		HandleWidgetPropertyChangeOf_widget_2(propertyName);
	}

	private void ColorPropertyChangedListenerOf_widget_2(PropertyOwnerObject propertyOwnerObject, string propertyName, Color e)
	{
		HandleWidgetPropertyChangeOf_widget_2(propertyName);
	}

	private void HandleWidgetPropertyChangeOf_widget_2(string propertyName)
	{
		if (propertyName == "Text")
		{
			_datasource_Root.Value = _widget_2.Text;
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
		case "Name":
			_widget_0.Text = _datasource_Root.Name;
			break;
		case "ColonText":
			_widget_1.Text = _datasource_Root.ColonText;
			break;
		case "Value":
			_widget_2.Text = _datasource_Root.Value;
			break;
		}
	}

	private void RefreshDataSource_datasource_Root(SelectableItemPropertyVM newDataSource)
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
			_widget_1.PropertyChanged -= PropertyChangedListenerOf_widget_1;
			_widget_1.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_1;
			_widget_1.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_1;
			_widget_1.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_1;
			_widget_1.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_1;
			_widget_1.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_1;
			_widget_1.intPropertyChanged -= intPropertyChangedListenerOf_widget_1;
			_widget_1.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_1;
			_widget_1.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_1;
			_widget_2.PropertyChanged -= PropertyChangedListenerOf_widget_2;
			_widget_2.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_2;
			_widget_2.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_2;
			_widget_2.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_2;
			_widget_2.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_2;
			_widget_2.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_2;
			_widget_2.intPropertyChanged -= intPropertyChangedListenerOf_widget_2;
			_widget_2.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_2;
			_widget_2.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_2;
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
			_widget_0.Text = _datasource_Root.Name;
			_widget_0.PropertyChanged += PropertyChangedListenerOf_widget_0;
			_widget_0.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0;
			_widget_0.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0;
			_widget_0.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0;
			_widget_0.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0;
			_widget_0.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0;
			_widget_0.intPropertyChanged += intPropertyChangedListenerOf_widget_0;
			_widget_0.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0;
			_widget_0.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0;
			_widget_1.Text = _datasource_Root.ColonText;
			_widget_1.PropertyChanged += PropertyChangedListenerOf_widget_1;
			_widget_1.boolPropertyChanged += boolPropertyChangedListenerOf_widget_1;
			_widget_1.floatPropertyChanged += floatPropertyChangedListenerOf_widget_1;
			_widget_1.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_1;
			_widget_1.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_1;
			_widget_1.doublePropertyChanged += doublePropertyChangedListenerOf_widget_1;
			_widget_1.intPropertyChanged += intPropertyChangedListenerOf_widget_1;
			_widget_1.uintPropertyChanged += uintPropertyChangedListenerOf_widget_1;
			_widget_1.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_1;
			_widget_2.Text = _datasource_Root.Value;
			_widget_2.PropertyChanged += PropertyChangedListenerOf_widget_2;
			_widget_2.boolPropertyChanged += boolPropertyChangedListenerOf_widget_2;
			_widget_2.floatPropertyChanged += floatPropertyChangedListenerOf_widget_2;
			_widget_2.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_2;
			_widget_2.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_2;
			_widget_2.doublePropertyChanged += doublePropertyChangedListenerOf_widget_2;
			_widget_2.intPropertyChanged += intPropertyChangedListenerOf_widget_2;
			_widget_2.uintPropertyChanged += uintPropertyChangedListenerOf_widget_2;
			_widget_2.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_2;
		}
	}
}
