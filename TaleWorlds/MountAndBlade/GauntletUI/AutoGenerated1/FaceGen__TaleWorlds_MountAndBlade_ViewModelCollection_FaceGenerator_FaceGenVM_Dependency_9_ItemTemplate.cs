using System.ComponentModel;
using System.Numerics;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.GauntletUI.Layout;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets;
using TaleWorlds.MountAndBlade.ViewModelCollection.FaceGenerator;

namespace TaleWorlds.MountAndBlade.GauntletUI.AutoGenerated1;

public class FaceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_9_ItemTemplate : Widget
{
	private Widget _widget;

	private NavigationTargetSwitcher _widget_0;

	private ListPanel _widget_1;

	private RichTextWidget _widget_1_0;

	private SliderWidget _widget_1_1;

	private Widget _widget_1_1_0;

	private Widget _widget_1_1_1;

	private Widget _widget_1_1_1_0;

	private Widget _widget_1_1_2;

	private ImageWidget _widget_1_1_3;

	private FaceGenPropertyVM _datasource_Root;

	public FaceGen__TaleWorlds_MountAndBlade_ViewModelCollection_FaceGenerator_FaceGenVM_Dependency_9_ItemTemplate(UIContext context)
		: base(context)
	{
	}

	public void CreateWidgets()
	{
		_widget = this;
		_widget_0 = new NavigationTargetSwitcher(base.Context);
		_widget.AddChild(_widget_0);
		_widget_1 = new ListPanel(base.Context);
		_widget.AddChild(_widget_1);
		_widget_1_0 = new RichTextWidget(base.Context);
		_widget_1.AddChild(_widget_1_0);
		_widget_1_1 = new SliderWidget(base.Context);
		_widget_1.AddChild(_widget_1_1);
		_widget_1_1_0 = new Widget(base.Context);
		_widget_1_1.AddChild(_widget_1_1_0);
		_widget_1_1_1 = new Widget(base.Context);
		_widget_1_1.AddChild(_widget_1_1_1);
		_widget_1_1_1_0 = new Widget(base.Context);
		_widget_1_1_1.AddChild(_widget_1_1_1_0);
		_widget_1_1_2 = new Widget(base.Context);
		_widget_1_1.AddChild(_widget_1_1_2);
		_widget_1_1_3 = new ImageWidget(base.Context);
		_widget_1_1.AddChild(_widget_1_1_3);
	}

	public void SetIds()
	{
		_widget_1.Id = "List";
		_widget_1_1.Id = "ScrollBar";
		_widget_1_1_1.Id = "Filler";
		_widget_1_1_3.Id = "SliderHandle";
	}

	public void SetAttributes()
	{
		base.WidthSizePolicy = SizePolicy.CoverChildren;
		base.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_0.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0.FromTarget = _widget;
		_widget_0.ToTarget = _widget_1_1_3;
		_widget_1.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_1.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_1.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_1.StackLayout.LayoutMethod = LayoutMethod.VerticalBottomToTop;
		_widget_1_0.DoNotAcceptEvents = true;
		_widget_1_0.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_1_0.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_1_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_1_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_1_0.Brush = base.Context.GetBrush("FaceGen.Property.Text");
		_widget_1_0.IsEnabled = false;
		_widget_1_1.WidthSizePolicy = SizePolicy.Fixed;
		_widget_1_1.HeightSizePolicy = SizePolicy.Fixed;
		_widget_1_1.SuggestedWidth = 338f;
		_widget_1_1.SuggestedHeight = 42f;
		_widget_1_1.VerticalAlignment = VerticalAlignment.Center;
		_widget_1_1.Filler = _widget_1_1_1;
		_widget_1_1.Handle = _widget_1_1_3;
		_widget_1_1.MarginBottom = 15f;
		_widget_1_1.DoNotUpdateHandleSize = true;
		_widget_1_1.UpdateValueOnScroll = false;
		_widget_1_1_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_1_1_0.HeightSizePolicy = SizePolicy.Fixed;
		_widget_1_1_0.SuggestedWidth = 362f;
		_widget_1_1_0.SuggestedHeight = 38f;
		_widget_1_1_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_1_1_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_1_1_0.Sprite = base.Context.SpriteData.GetSprite("SPGeneral\\SPOptions\\standart_slider_canvas");
		_widget_1_1_0.IsEnabled = false;
		_widget_1_1_1.WidthSizePolicy = SizePolicy.Fixed;
		_widget_1_1_1.HeightSizePolicy = SizePolicy.Fixed;
		_widget_1_1_1.SuggestedWidth = 345f;
		_widget_1_1_1.SuggestedHeight = 35f;
		_widget_1_1_1.VerticalAlignment = VerticalAlignment.Center;
		_widget_1_1_1.Sprite = base.Context.SpriteData.GetSprite("SPGeneral\\SPOptions\\standart_slider_fill");
		_widget_1_1_1.ClipContents = true;
		_widget_1_1_1_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_1_1_1_0.HeightSizePolicy = SizePolicy.Fixed;
		_widget_1_1_1_0.SuggestedWidth = 345f;
		_widget_1_1_1_0.SuggestedHeight = 35f;
		_widget_1_1_1_0.HorizontalAlignment = HorizontalAlignment.Left;
		_widget_1_1_1_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_1_1_1_0.Sprite = base.Context.SpriteData.GetSprite("SPGeneral\\SPOptions\\standart_slider_fill");
		_widget_1_1_2.WidthSizePolicy = SizePolicy.Fixed;
		_widget_1_1_2.HeightSizePolicy = SizePolicy.Fixed;
		_widget_1_1_2.SuggestedWidth = 400f;
		_widget_1_1_2.SuggestedHeight = 65f;
		_widget_1_1_2.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_1_1_2.VerticalAlignment = VerticalAlignment.Center;
		_widget_1_1_2.Sprite = base.Context.SpriteData.GetSprite("SPGeneral\\SPOptions\\standart_slider_frame");
		_widget_1_1_2.IsEnabled = false;
		_widget_1_1_3.WidthSizePolicy = SizePolicy.Fixed;
		_widget_1_1_3.HeightSizePolicy = SizePolicy.Fixed;
		_widget_1_1_3.SuggestedWidth = 14f;
		_widget_1_1_3.SuggestedHeight = 38f;
		_widget_1_1_3.HorizontalAlignment = HorizontalAlignment.Left;
		_widget_1_1_3.VerticalAlignment = VerticalAlignment.Center;
		_widget_1_1_3.Brush = base.Context.GetBrush("SPOptions.Slider.Handle");
		_widget_1_1_3.DoNotAcceptEvents = true;
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
			_widget_1.PropertyChanged -= PropertyChangedListenerOf_widget_1;
			_widget_1.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_1;
			_widget_1.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_1;
			_widget_1.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_1;
			_widget_1.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_1;
			_widget_1.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_1;
			_widget_1.intPropertyChanged -= intPropertyChangedListenerOf_widget_1;
			_widget_1.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_1;
			_widget_1.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_1;
			_widget_1_0.PropertyChanged -= PropertyChangedListenerOf_widget_1_0;
			_widget_1_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_1_0;
			_widget_1_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_1_0;
			_widget_1_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_1_0;
			_widget_1_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_1_0;
			_widget_1_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_1_0;
			_widget_1_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_1_0;
			_widget_1_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_1_0;
			_widget_1_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_1_0;
			_widget_1_1.PropertyChanged -= PropertyChangedListenerOf_widget_1_1;
			_widget_1_1.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_1_1;
			_widget_1_1.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_1_1;
			_widget_1_1.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_1_1;
			_widget_1_1.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_1_1;
			_widget_1_1.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_1_1;
			_widget_1_1.intPropertyChanged -= intPropertyChangedListenerOf_widget_1_1;
			_widget_1_1.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_1_1;
			_widget_1_1.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_1_1;
			_datasource_Root = null;
		}
	}

	public void SetDataSource(FaceGenPropertyVM dataSource)
	{
		RefreshDataSource_datasource_Root(dataSource);
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
		if (propertyName == "IsEnabled")
		{
			_datasource_Root.IsEnabled = _widget_1.IsEnabled;
		}
	}

	private void PropertyChangedListenerOf_widget_1_0(PropertyOwnerObject propertyOwnerObject, string propertyName, object e)
	{
		HandleWidgetPropertyChangeOf_widget_1_0(propertyName);
	}

	private void boolPropertyChangedListenerOf_widget_1_0(PropertyOwnerObject propertyOwnerObject, string propertyName, bool e)
	{
		HandleWidgetPropertyChangeOf_widget_1_0(propertyName);
	}

	private void floatPropertyChangedListenerOf_widget_1_0(PropertyOwnerObject propertyOwnerObject, string propertyName, float e)
	{
		HandleWidgetPropertyChangeOf_widget_1_0(propertyName);
	}

	private void Vec2PropertyChangedListenerOf_widget_1_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Vec2 e)
	{
		HandleWidgetPropertyChangeOf_widget_1_0(propertyName);
	}

	private void Vector2PropertyChangedListenerOf_widget_1_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Vector2 e)
	{
		HandleWidgetPropertyChangeOf_widget_1_0(propertyName);
	}

	private void doublePropertyChangedListenerOf_widget_1_0(PropertyOwnerObject propertyOwnerObject, string propertyName, double e)
	{
		HandleWidgetPropertyChangeOf_widget_1_0(propertyName);
	}

	private void intPropertyChangedListenerOf_widget_1_0(PropertyOwnerObject propertyOwnerObject, string propertyName, int e)
	{
		HandleWidgetPropertyChangeOf_widget_1_0(propertyName);
	}

	private void uintPropertyChangedListenerOf_widget_1_0(PropertyOwnerObject propertyOwnerObject, string propertyName, uint e)
	{
		HandleWidgetPropertyChangeOf_widget_1_0(propertyName);
	}

	private void ColorPropertyChangedListenerOf_widget_1_0(PropertyOwnerObject propertyOwnerObject, string propertyName, Color e)
	{
		HandleWidgetPropertyChangeOf_widget_1_0(propertyName);
	}

	private void HandleWidgetPropertyChangeOf_widget_1_0(string propertyName)
	{
		if (propertyName == "Text")
		{
			_datasource_Root.Name = _widget_1_0.Text;
		}
	}

	private void PropertyChangedListenerOf_widget_1_1(PropertyOwnerObject propertyOwnerObject, string propertyName, object e)
	{
		HandleWidgetPropertyChangeOf_widget_1_1(propertyName);
	}

	private void boolPropertyChangedListenerOf_widget_1_1(PropertyOwnerObject propertyOwnerObject, string propertyName, bool e)
	{
		HandleWidgetPropertyChangeOf_widget_1_1(propertyName);
	}

	private void floatPropertyChangedListenerOf_widget_1_1(PropertyOwnerObject propertyOwnerObject, string propertyName, float e)
	{
		HandleWidgetPropertyChangeOf_widget_1_1(propertyName);
	}

	private void Vec2PropertyChangedListenerOf_widget_1_1(PropertyOwnerObject propertyOwnerObject, string propertyName, Vec2 e)
	{
		HandleWidgetPropertyChangeOf_widget_1_1(propertyName);
	}

	private void Vector2PropertyChangedListenerOf_widget_1_1(PropertyOwnerObject propertyOwnerObject, string propertyName, Vector2 e)
	{
		HandleWidgetPropertyChangeOf_widget_1_1(propertyName);
	}

	private void doublePropertyChangedListenerOf_widget_1_1(PropertyOwnerObject propertyOwnerObject, string propertyName, double e)
	{
		HandleWidgetPropertyChangeOf_widget_1_1(propertyName);
	}

	private void intPropertyChangedListenerOf_widget_1_1(PropertyOwnerObject propertyOwnerObject, string propertyName, int e)
	{
		HandleWidgetPropertyChangeOf_widget_1_1(propertyName);
	}

	private void uintPropertyChangedListenerOf_widget_1_1(PropertyOwnerObject propertyOwnerObject, string propertyName, uint e)
	{
		HandleWidgetPropertyChangeOf_widget_1_1(propertyName);
	}

	private void ColorPropertyChangedListenerOf_widget_1_1(PropertyOwnerObject propertyOwnerObject, string propertyName, Color e)
	{
		HandleWidgetPropertyChangeOf_widget_1_1(propertyName);
	}

	private void HandleWidgetPropertyChangeOf_widget_1_1(string propertyName)
	{
		switch (propertyName)
		{
		case "MaxValueFloat":
			_datasource_Root.Max = _widget_1_1.MaxValueFloat;
			break;
		case "MinValueFloat":
			_datasource_Root.Min = _widget_1_1.MinValueFloat;
			break;
		case "ValueFloat":
			_datasource_Root.Value = _widget_1_1.ValueFloat;
			break;
		case "IsDiscrete":
			_datasource_Root.IsDiscrete = _widget_1_1.IsDiscrete;
			break;
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
		case "IsEnabled":
			_widget_1.IsEnabled = _datasource_Root.IsEnabled;
			break;
		case "Name":
			_widget_1_0.Text = _datasource_Root.Name;
			break;
		case "Max":
			_widget_1_1.MaxValueFloat = _datasource_Root.Max;
			break;
		case "Min":
			_widget_1_1.MinValueFloat = _datasource_Root.Min;
			break;
		case "Value":
			_widget_1_1.ValueFloat = _datasource_Root.Value;
			break;
		case "IsDiscrete":
			_widget_1_1.IsDiscrete = _datasource_Root.IsDiscrete;
			break;
		}
	}

	private void RefreshDataSource_datasource_Root(FaceGenPropertyVM newDataSource)
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
			_widget_1.PropertyChanged -= PropertyChangedListenerOf_widget_1;
			_widget_1.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_1;
			_widget_1.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_1;
			_widget_1.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_1;
			_widget_1.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_1;
			_widget_1.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_1;
			_widget_1.intPropertyChanged -= intPropertyChangedListenerOf_widget_1;
			_widget_1.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_1;
			_widget_1.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_1;
			_widget_1_0.PropertyChanged -= PropertyChangedListenerOf_widget_1_0;
			_widget_1_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_1_0;
			_widget_1_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_1_0;
			_widget_1_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_1_0;
			_widget_1_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_1_0;
			_widget_1_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_1_0;
			_widget_1_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_1_0;
			_widget_1_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_1_0;
			_widget_1_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_1_0;
			_widget_1_1.PropertyChanged -= PropertyChangedListenerOf_widget_1_1;
			_widget_1_1.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_1_1;
			_widget_1_1.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_1_1;
			_widget_1_1.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_1_1;
			_widget_1_1.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_1_1;
			_widget_1_1.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_1_1;
			_widget_1_1.intPropertyChanged -= intPropertyChangedListenerOf_widget_1_1;
			_widget_1_1.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_1_1;
			_widget_1_1.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_1_1;
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
			_widget_1.IsEnabled = _datasource_Root.IsEnabled;
			_widget_1.PropertyChanged += PropertyChangedListenerOf_widget_1;
			_widget_1.boolPropertyChanged += boolPropertyChangedListenerOf_widget_1;
			_widget_1.floatPropertyChanged += floatPropertyChangedListenerOf_widget_1;
			_widget_1.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_1;
			_widget_1.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_1;
			_widget_1.doublePropertyChanged += doublePropertyChangedListenerOf_widget_1;
			_widget_1.intPropertyChanged += intPropertyChangedListenerOf_widget_1;
			_widget_1.uintPropertyChanged += uintPropertyChangedListenerOf_widget_1;
			_widget_1.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_1;
			_widget_1_0.Text = _datasource_Root.Name;
			_widget_1_0.PropertyChanged += PropertyChangedListenerOf_widget_1_0;
			_widget_1_0.boolPropertyChanged += boolPropertyChangedListenerOf_widget_1_0;
			_widget_1_0.floatPropertyChanged += floatPropertyChangedListenerOf_widget_1_0;
			_widget_1_0.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_1_0;
			_widget_1_0.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_1_0;
			_widget_1_0.doublePropertyChanged += doublePropertyChangedListenerOf_widget_1_0;
			_widget_1_0.intPropertyChanged += intPropertyChangedListenerOf_widget_1_0;
			_widget_1_0.uintPropertyChanged += uintPropertyChangedListenerOf_widget_1_0;
			_widget_1_0.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_1_0;
			_widget_1_1.MaxValueFloat = _datasource_Root.Max;
			_widget_1_1.MinValueFloat = _datasource_Root.Min;
			_widget_1_1.ValueFloat = _datasource_Root.Value;
			_widget_1_1.IsDiscrete = _datasource_Root.IsDiscrete;
			_widget_1_1.PropertyChanged += PropertyChangedListenerOf_widget_1_1;
			_widget_1_1.boolPropertyChanged += boolPropertyChangedListenerOf_widget_1_1;
			_widget_1_1.floatPropertyChanged += floatPropertyChangedListenerOf_widget_1_1;
			_widget_1_1.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_1_1;
			_widget_1_1.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_1_1;
			_widget_1_1.doublePropertyChanged += doublePropertyChangedListenerOf_widget_1_1;
			_widget_1_1.intPropertyChanged += intPropertyChangedListenerOf_widget_1_1;
			_widget_1_1.uintPropertyChanged += uintPropertyChangedListenerOf_widget_1_1;
			_widget_1_1.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_1_1;
		}
	}
}
