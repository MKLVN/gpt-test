using System.ComponentModel;
using TaleWorlds.CampaignSystem.ViewModelCollection.ArmyManagement;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.Library;

namespace SandBox.GauntletUI.AutoGenerated0;

public class ArmyManagement__TaleWorlds_CampaignSystem_ViewModelCollection_ArmyManagement_ArmyManagementVM_Dependency_3_Standard_VerticalScrollbar__DependendPrefab : Widget
{
	private Widget _widget;

	private Widget _widget_0;

	private Widget _widget_1;

	private Widget _widget_2;

	private ScrollbarWidget _widget_3;

	private ImageWidget _widget_3_0;

	private ArmyManagementVM _datasource_Root;

	public ArmyManagement__TaleWorlds_CampaignSystem_ViewModelCollection_ArmyManagement_ArmyManagementVM_Dependency_3_Standard_VerticalScrollbar__DependendPrefab(UIContext context)
		: base(context)
	{
	}

	public void CreateWidgets()
	{
		_widget = this;
		_widget_0 = new Widget(base.Context);
		_widget.AddChild(_widget_0);
		_widget_1 = new Widget(base.Context);
		_widget.AddChild(_widget_1);
		_widget_2 = new Widget(base.Context);
		_widget.AddChild(_widget_2);
		_widget_3 = new ScrollbarWidget(base.Context);
		_widget.AddChild(_widget_3);
		_widget_3_0 = new ImageWidget(base.Context);
		_widget_3.AddChild(_widget_3_0);
	}

	public void SetIds()
	{
		_widget_2.Id = "ScrollbarBlocker";
		_widget_3.Id = "Scrollbar";
		_widget_3_0.Id = "ScrollbarHandle";
	}

	public void SetAttributes()
	{
		base.WidthSizePolicy = SizePolicy.Fixed;
		base.HeightSizePolicy = SizePolicy.Fixed;
		base.SuggestedWidth = 22f;
		base.SuggestedHeight = 800f;
		_widget_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0.SuggestedWidth = 18f;
		_widget_0.SuggestedHeight = 13f;
		_widget_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0.VerticalAlignment = VerticalAlignment.Top;
		_widget_0.Sprite = base.Context.SpriteData.GetSprite("General\\Scrollbar.Vertical1\\scroller_stop_top");
		_widget_0.ExtendTop = 22f;
		_widget_0.ExtendBottom = 22f;
		_widget_0.ExtendLeft = 22f;
		_widget_0.ExtendRight = 22f;
		_widget_0.IsDisabled = true;
		_widget_1.WidthSizePolicy = SizePolicy.Fixed;
		_widget_1.HeightSizePolicy = SizePolicy.Fixed;
		_widget_1.SuggestedWidth = 18f;
		_widget_1.SuggestedHeight = 13f;
		_widget_1.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_1.VerticalAlignment = VerticalAlignment.Bottom;
		_widget_1.Sprite = base.Context.SpriteData.GetSprite("General\\Scrollbar.Vertical1\\scroller_stop_bottom");
		_widget_1.ExtendTop = 22f;
		_widget_1.ExtendBottom = 22f;
		_widget_1.ExtendLeft = 22f;
		_widget_1.ExtendRight = 22f;
		_widget_1.IsDisabled = true;
		_widget_2.WidthSizePolicy = SizePolicy.Fixed;
		_widget_2.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_2.SuggestedWidth = 22f;
		_widget_2.SuggestedHeight = 800f;
		_widget_2.HorizontalAlignment = HorizontalAlignment.Left;
		_widget_2.VerticalAlignment = VerticalAlignment.Bottom;
		_widget_2.MarginTop = 13f;
		_widget_2.MarginBottom = 13f;
		_widget_2.Sprite = base.Context.SpriteData.GetSprite("General\\Scrollbar.Vertical1\\scroller_bed_noscroll");
		_widget_2.ExtendLeft = 20f;
		_widget_2.ExtendRight = 20f;
		_widget_2.ExtendTop = 20f;
		_widget_2.ExtendBottom = 20f;
		_widget_3.WidthSizePolicy = SizePolicy.Fixed;
		_widget_3.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_3.SuggestedWidth = 22f;
		_widget_3.SuggestedHeight = 800f;
		_widget_3.HorizontalAlignment = HorizontalAlignment.Left;
		_widget_3.VerticalAlignment = VerticalAlignment.Bottom;
		_widget_3.MarginTop = 13f;
		_widget_3.MarginBottom = 13f;
		_widget_3.Brush = base.Context.GetBrush("Scrollbar.Vertical");
		_widget_3.AlignmentAxis = AlignmentAxis.Vertical;
		_widget_3.Handle = _widget_3_0;
		_widget_3.MaxValue = 100f;
		_widget_3.MinValue = 0f;
		_widget_3.UpdateChildrenStates = true;
		_widget_3_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_3_0.SuggestedWidth = 20f;
		_widget_3_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_3_0.VerticalAlignment = VerticalAlignment.Top;
		_widget_3_0.Brush = base.Context.GetBrush("Scrollbar.Vertical.Handle");
		_widget_3_0.MinHeight = 50f;
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
			_datasource_Root = null;
		}
	}

	public void SetDataSource(ArmyManagementVM dataSource)
	{
		RefreshDataSource_datasource_Root(dataSource);
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
	}

	private void RefreshDataSource_datasource_Root(ArmyManagementVM newDataSource)
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
		}
	}
}
