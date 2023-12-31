using System.ComponentModel;
using System.Numerics;
using SandBox.ViewModelCollection.Missions.NameMarker;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.GauntletUI.Data;
using TaleWorlds.GauntletUI.Layout;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets.Mission.NameMarker;

namespace SandBox.GauntletUI.AutoGenerated0;

public class NameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_1_ItemTemplate : NameMarkerListPanel
{
	private NameMarkerListPanel _widget;

	private BrushWidget _widget_0;

	private ListPanel _widget_0_0;

	private ListPanel _widget_0_1;

	private TextWidget _widget_0_1_0;

	private ListPanel _widget_0_1_1;

	private BrushWidget _widget_0_1_1_0;

	private TextWidget _widget_0_1_1_1;

	private MissionNameMarkerTargetVM _datasource_Root;

	private MBBindingList<QuestMarkerVM> _datasource_Root_Quests;

	public NameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_1_ItemTemplate(UIContext context)
		: base(context)
	{
	}

	public void CreateWidgets()
	{
		_widget = this;
		_widget_0 = new BrushWidget(base.Context);
		_widget.AddChild(_widget_0);
		_widget_0_0 = new ListPanel(base.Context);
		_widget_0.AddChild(_widget_0_0);
		_widget_0_1 = new ListPanel(base.Context);
		_widget_0.AddChild(_widget_0_1);
		_widget_0_1_0 = new TextWidget(base.Context);
		_widget_0_1.AddChild(_widget_0_1_0);
		_widget_0_1_1 = new ListPanel(base.Context);
		_widget_0_1.AddChild(_widget_0_1_1);
		_widget_0_1_1_0 = new BrushWidget(base.Context);
		_widget_0_1_1.AddChild(_widget_0_1_1_0);
		_widget_0_1_1_1 = new TextWidget(base.Context);
		_widget_0_1_1.AddChild(_widget_0_1_1_1);
	}

	public void SetIds()
	{
		_widget_0.Id = "TypeWidget";
		_widget_0_1.Id = "NameAndDistanceContainer";
		_widget_0_1_0.Id = "NameTextWidget";
		_widget_0_1_1.Id = "DistanceInfo";
		_widget_0_1_1_0.Id = "DistanceIcon";
		_widget_0_1_1_1.Id = "DistanceText";
	}

	public void SetAttributes()
	{
		base.WidthSizePolicy = SizePolicy.Fixed;
		base.HeightSizePolicy = SizePolicy.Fixed;
		base.SuggestedHeight = 40f;
		base.TypeVisualWidget = _widget_0;
		base.NameTextWidget = _widget_0_1_0;
		base.DistanceTextWidget = _widget_0_1_1_1;
		base.DistanceIconWidget = _widget_0_1_1_0;
		base.StackLayout.LayoutMethod = LayoutMethod.VerticalBottomToTop;
		base.FarAlphaTarget = 0.5f;
		base.FarDistanceCutoff = 250f;
		base.CloseDistanceCutoff = 25f;
		base.IssueNotificationColor = new Color(1f, 1f, 1f);
		base.MainQuestNotificationColor = new Color(1f, 1f, 1f);
		base.EnemyColor = new Color(0.9294118f, 0.1098039f, 0.1411765f);
		base.FriendlyColor = new Color(0.3058824f, 0.8784314f, 0.2980392f);
		_widget_0.WidthSizePolicy = SizePolicy.StretchToParent;
		_widget_0.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_0.Brush = base.Context.GetBrush("NameMarker.VisualBrush");
		_widget_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_0.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_0_0.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0_0.StackLayout.LayoutMethod = LayoutMethod.HorizontalLeftToRight;
		_widget_0_0.PositionYOffset = -40f;
		_widget_0_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_1.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_0_1.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0_1.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_1.MarginTop = 50f;
		_widget_0_1.StackLayout.LayoutMethod = LayoutMethod.VerticalBottomToTop;
		_widget_0_1_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0_1_0.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0_1_0.SuggestedWidth = 150f;
		_widget_0_1_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_1_0.Brush = base.Context.GetBrush("NameMarker.TextBrush");
		_widget_0_1_0.OverrideDefaultStateSwitchingEnabled = true;
		_widget_0_1_0.ClipContents = false;
		_widget_0_1_1.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_0_1_1.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0_1_1.PositionYOffset = 0f;
		_widget_0_1_1.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_1_1.StackLayout.LayoutMethod = LayoutMethod.HorizontalLeftToRight;
		_widget_0_1_1_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0_1_1_0.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0_1_1_0.SuggestedWidth = 20f;
		_widget_0_1_1_0.SuggestedHeight = 28f;
		_widget_0_1_1_0.Brush = base.Context.GetBrush("NameMarker.Distance.Icon");
		_widget_0_1_1_0.VerticalAlignment = VerticalAlignment.Center;
		_widget_0_1_1_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_1_1_1.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_0_1_1_1.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_0_1_1_1.Brush = base.Context.GetBrush("NameMarker.Distance.Text");
		_widget_0_1_1_1.MarginLeft = 4f;
		_widget_0_1_1_1.MarginTop = 5f;
		_widget_0_1_1_1.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0_1_1_1.VerticalAlignment = VerticalAlignment.Center;
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
		_widget.PropertyChanged -= PropertyChangedListenerOf_widget;
		_widget.boolPropertyChanged -= boolPropertyChangedListenerOf_widget;
		_widget.floatPropertyChanged -= floatPropertyChangedListenerOf_widget;
		_widget.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget;
		_widget.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget;
		_widget.doublePropertyChanged -= doublePropertyChangedListenerOf_widget;
		_widget.intPropertyChanged -= intPropertyChangedListenerOf_widget;
		_widget.uintPropertyChanged -= uintPropertyChangedListenerOf_widget;
		_widget.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget;
		_widget_0_1_0.PropertyChanged -= PropertyChangedListenerOf_widget_0_1_0;
		_widget_0_1_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_1_0;
		_widget_0_1_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_1_0;
		_widget_0_1_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_1_0;
		_widget_0_1_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_1_0;
		_widget_0_1_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_1_0;
		_widget_0_1_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_1_0;
		_widget_0_1_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_1_0;
		_widget_0_1_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_1_0;
		_widget_0_1_1_1.PropertyChanged -= PropertyChangedListenerOf_widget_0_1_1_1;
		_widget_0_1_1_1.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_1_1_1;
		_widget_0_1_1_1.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_1_1_1;
		_widget_0_1_1_1.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_1_1_1;
		_widget_0_1_1_1.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_1_1_1;
		_widget_0_1_1_1.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_1_1_1;
		_widget_0_1_1_1.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_1_1_1;
		_widget_0_1_1_1.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_1_1_1;
		_widget_0_1_1_1.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_1_1_1;
		if (_datasource_Root_Quests != null)
		{
			_datasource_Root_Quests.ListChanged -= OnList_datasource_Root_QuestsChanged;
			for (int num = _widget_0_0.ChildCount - 1; num >= 0; num--)
			{
				Widget child = _widget_0_0.GetChild(num);
				((NameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate)child).OnBeforeRemovedChild(child);
				((NameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate)_widget_0_0.GetChild(num)).DestroyDataSource();
			}
			_datasource_Root_Quests = null;
		}
		_datasource_Root = null;
	}

	public void SetDataSource(MissionNameMarkerTargetVM dataSource)
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
		switch (propertyName)
		{
		case "Position":
			_datasource_Root.ScreenPosition = _widget.Position;
			break;
		case "HasIssue":
			_datasource_Root.IsTracked = _widget.HasIssue;
			break;
		case "HasMainQuest":
			_datasource_Root.IsQuestMainStory = _widget.HasMainQuest;
			break;
		case "IsEnemy":
			_datasource_Root.IsEnemy = _widget.IsEnemy;
			break;
		case "IsFriendly":
			_datasource_Root.IsFriendly = _widget.IsFriendly;
			break;
		case "NameType":
			_datasource_Root.NameType = _widget.NameType;
			break;
		case "IconType":
			_datasource_Root.IconType = _widget.IconType;
			break;
		case "IsMarkerEnabled":
			_datasource_Root.IsEnabled = _widget.IsMarkerEnabled;
			break;
		case "Distance":
			_datasource_Root.Distance = _widget.Distance;
			break;
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
		if (propertyName == "Text")
		{
			_datasource_Root.Name = _widget_0_1_0.Text;
		}
	}

	private void PropertyChangedListenerOf_widget_0_1_1_1(PropertyOwnerObject propertyOwnerObject, string propertyName, object e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1_1_1(propertyName);
	}

	private void boolPropertyChangedListenerOf_widget_0_1_1_1(PropertyOwnerObject propertyOwnerObject, string propertyName, bool e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1_1_1(propertyName);
	}

	private void floatPropertyChangedListenerOf_widget_0_1_1_1(PropertyOwnerObject propertyOwnerObject, string propertyName, float e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1_1_1(propertyName);
	}

	private void Vec2PropertyChangedListenerOf_widget_0_1_1_1(PropertyOwnerObject propertyOwnerObject, string propertyName, Vec2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1_1_1(propertyName);
	}

	private void Vector2PropertyChangedListenerOf_widget_0_1_1_1(PropertyOwnerObject propertyOwnerObject, string propertyName, Vector2 e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1_1_1(propertyName);
	}

	private void doublePropertyChangedListenerOf_widget_0_1_1_1(PropertyOwnerObject propertyOwnerObject, string propertyName, double e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1_1_1(propertyName);
	}

	private void intPropertyChangedListenerOf_widget_0_1_1_1(PropertyOwnerObject propertyOwnerObject, string propertyName, int e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1_1_1(propertyName);
	}

	private void uintPropertyChangedListenerOf_widget_0_1_1_1(PropertyOwnerObject propertyOwnerObject, string propertyName, uint e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1_1_1(propertyName);
	}

	private void ColorPropertyChangedListenerOf_widget_0_1_1_1(PropertyOwnerObject propertyOwnerObject, string propertyName, Color e)
	{
		HandleWidgetPropertyChangeOf_widget_0_1_1_1(propertyName);
	}

	private void HandleWidgetPropertyChangeOf_widget_0_1_1_1(string propertyName)
	{
		if (propertyName == "IntText")
		{
			_datasource_Root.Distance = _widget_0_1_1_1.IntText;
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
		case "Quests":
			RefreshDataSource_datasource_Root_Quests(_datasource_Root.Quests);
			break;
		case "ScreenPosition":
			_widget.Position = _datasource_Root.ScreenPosition;
			break;
		case "IsTracked":
			_widget.HasIssue = _datasource_Root.IsTracked;
			break;
		case "IsQuestMainStory":
			_widget.HasMainQuest = _datasource_Root.IsQuestMainStory;
			break;
		case "IsEnemy":
			_widget.IsEnemy = _datasource_Root.IsEnemy;
			break;
		case "IsFriendly":
			_widget.IsFriendly = _datasource_Root.IsFriendly;
			break;
		case "NameType":
			_widget.NameType = _datasource_Root.NameType;
			break;
		case "IconType":
			_widget.IconType = _datasource_Root.IconType;
			break;
		case "IsEnabled":
			_widget.IsMarkerEnabled = _datasource_Root.IsEnabled;
			break;
		case "Distance":
			_widget.Distance = _datasource_Root.Distance;
			_widget_0_1_1_1.IntText = _datasource_Root.Distance;
			break;
		case "Name":
			_widget_0_1_0.Text = _datasource_Root.Name;
			break;
		}
	}

	public void OnList_datasource_Root_QuestsChanged(object sender, TaleWorlds.Library.ListChangedEventArgs e)
	{
		switch (e.ListChangedType)
		{
		case TaleWorlds.Library.ListChangedType.Reset:
		{
			for (int num = _widget_0_0.ChildCount - 1; num >= 0; num--)
			{
				Widget child3 = _widget_0_0.GetChild(num);
				((NameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate)child3).OnBeforeRemovedChild(child3);
				Widget child4 = _widget_0_0.GetChild(num);
				((NameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate)child4).SetDataSource(null);
				_widget_0_0.RemoveChild(child4);
			}
			break;
		}
		case TaleWorlds.Library.ListChangedType.Sorted:
		{
			for (int i = 0; i < _datasource_Root_Quests.Count; i++)
			{
				QuestMarkerVM bindingObject = _datasource_Root_Quests[i];
				_widget_0_0.FindChild((Widget widget) => widget.GetComponent<GeneratedWidgetData>().Data == bindingObject).SetSiblingIndex(i);
			}
			break;
		}
		case TaleWorlds.Library.ListChangedType.ItemAdded:
		{
			NameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate nameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate = new NameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate(base.Context);
			GeneratedWidgetData generatedWidgetData = new GeneratedWidgetData(nameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate);
			QuestMarkerVM dataSource = (QuestMarkerVM)(generatedWidgetData.Data = _datasource_Root_Quests[e.NewIndex]);
			nameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate.AddComponent(generatedWidgetData);
			_widget_0_0.AddChildAtIndex(nameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate, e.NewIndex);
			nameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate.CreateWidgets();
			nameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate.SetIds();
			nameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate.SetAttributes();
			nameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate.SetDataSource(dataSource);
			break;
		}
		case TaleWorlds.Library.ListChangedType.ItemBeforeDeleted:
		{
			Widget child2 = _widget_0_0.GetChild(e.NewIndex);
			((NameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate)child2).OnBeforeRemovedChild(child2);
			break;
		}
		case TaleWorlds.Library.ListChangedType.ItemDeleted:
		{
			Widget child = _widget_0_0.GetChild(e.NewIndex);
			((NameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate)child).SetDataSource(null);
			_widget_0_0.RemoveChild(child);
			break;
		}
		case TaleWorlds.Library.ListChangedType.ItemChanged:
			break;
		}
	}

	private void RefreshDataSource_datasource_Root(MissionNameMarkerTargetVM newDataSource)
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
			_widget_0_1_0.PropertyChanged -= PropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_0.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_1_0;
			_widget_0_1_1_1.PropertyChanged -= PropertyChangedListenerOf_widget_0_1_1_1;
			_widget_0_1_1_1.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_0_1_1_1;
			_widget_0_1_1_1.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_0_1_1_1;
			_widget_0_1_1_1.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_0_1_1_1;
			_widget_0_1_1_1.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_0_1_1_1;
			_widget_0_1_1_1.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_0_1_1_1;
			_widget_0_1_1_1.intPropertyChanged -= intPropertyChangedListenerOf_widget_0_1_1_1;
			_widget_0_1_1_1.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_0_1_1_1;
			_widget_0_1_1_1.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_0_1_1_1;
			if (_datasource_Root_Quests != null)
			{
				_datasource_Root_Quests.ListChanged -= OnList_datasource_Root_QuestsChanged;
				for (int num = _widget_0_0.ChildCount - 1; num >= 0; num--)
				{
					Widget child = _widget_0_0.GetChild(num);
					((NameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate)child).OnBeforeRemovedChild(child);
					Widget child2 = _widget_0_0.GetChild(num);
					((NameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate)child2).SetDataSource(null);
					_widget_0_0.RemoveChild(child2);
				}
				_datasource_Root_Quests = null;
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
		_widget.Position = _datasource_Root.ScreenPosition;
		_widget.HasIssue = _datasource_Root.IsTracked;
		_widget.HasMainQuest = _datasource_Root.IsQuestMainStory;
		_widget.IsEnemy = _datasource_Root.IsEnemy;
		_widget.IsFriendly = _datasource_Root.IsFriendly;
		_widget.NameType = _datasource_Root.NameType;
		_widget.IconType = _datasource_Root.IconType;
		_widget.IsMarkerEnabled = _datasource_Root.IsEnabled;
		_widget.Distance = _datasource_Root.Distance;
		_widget.PropertyChanged += PropertyChangedListenerOf_widget;
		_widget.boolPropertyChanged += boolPropertyChangedListenerOf_widget;
		_widget.floatPropertyChanged += floatPropertyChangedListenerOf_widget;
		_widget.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget;
		_widget.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget;
		_widget.doublePropertyChanged += doublePropertyChangedListenerOf_widget;
		_widget.intPropertyChanged += intPropertyChangedListenerOf_widget;
		_widget.uintPropertyChanged += uintPropertyChangedListenerOf_widget;
		_widget.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget;
		_widget_0_1_0.Text = _datasource_Root.Name;
		_widget_0_1_0.PropertyChanged += PropertyChangedListenerOf_widget_0_1_0;
		_widget_0_1_0.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_1_0;
		_widget_0_1_0.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_1_0;
		_widget_0_1_0.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_1_0;
		_widget_0_1_0.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_1_0;
		_widget_0_1_0.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_1_0;
		_widget_0_1_0.intPropertyChanged += intPropertyChangedListenerOf_widget_0_1_0;
		_widget_0_1_0.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_1_0;
		_widget_0_1_0.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_1_0;
		_widget_0_1_1_1.IntText = _datasource_Root.Distance;
		_widget_0_1_1_1.PropertyChanged += PropertyChangedListenerOf_widget_0_1_1_1;
		_widget_0_1_1_1.boolPropertyChanged += boolPropertyChangedListenerOf_widget_0_1_1_1;
		_widget_0_1_1_1.floatPropertyChanged += floatPropertyChangedListenerOf_widget_0_1_1_1;
		_widget_0_1_1_1.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_0_1_1_1;
		_widget_0_1_1_1.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_0_1_1_1;
		_widget_0_1_1_1.doublePropertyChanged += doublePropertyChangedListenerOf_widget_0_1_1_1;
		_widget_0_1_1_1.intPropertyChanged += intPropertyChangedListenerOf_widget_0_1_1_1;
		_widget_0_1_1_1.uintPropertyChanged += uintPropertyChangedListenerOf_widget_0_1_1_1;
		_widget_0_1_1_1.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_0_1_1_1;
		_datasource_Root_Quests = _datasource_Root.Quests;
		if (_datasource_Root_Quests != null)
		{
			_datasource_Root_Quests.ListChanged += OnList_datasource_Root_QuestsChanged;
			for (int i = 0; i < _datasource_Root_Quests.Count; i++)
			{
				NameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate nameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate = new NameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate(base.Context);
				GeneratedWidgetData generatedWidgetData = new GeneratedWidgetData(nameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate);
				QuestMarkerVM dataSource = (QuestMarkerVM)(generatedWidgetData.Data = _datasource_Root_Quests[i]);
				nameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate.AddComponent(generatedWidgetData);
				_widget_0_0.AddChildAtIndex(nameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate, i);
				nameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate.CreateWidgets();
				nameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate.SetIds();
				nameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate.SetAttributes();
				nameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate.SetDataSource(dataSource);
			}
		}
	}

	private void RefreshDataSource_datasource_Root_Quests(MBBindingList<QuestMarkerVM> newDataSource)
	{
		if (_datasource_Root_Quests != null)
		{
			_datasource_Root_Quests.ListChanged -= OnList_datasource_Root_QuestsChanged;
			for (int num = _widget_0_0.ChildCount - 1; num >= 0; num--)
			{
				Widget child = _widget_0_0.GetChild(num);
				((NameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate)child).OnBeforeRemovedChild(child);
				Widget child2 = _widget_0_0.GetChild(num);
				((NameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate)child2).SetDataSource(null);
				_widget_0_0.RemoveChild(child2);
			}
			_datasource_Root_Quests = null;
		}
		_datasource_Root_Quests = newDataSource;
		_datasource_Root_Quests = _datasource_Root.Quests;
		if (_datasource_Root_Quests != null)
		{
			_datasource_Root_Quests.ListChanged += OnList_datasource_Root_QuestsChanged;
			for (int i = 0; i < _datasource_Root_Quests.Count; i++)
			{
				NameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate nameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate = new NameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate(base.Context);
				GeneratedWidgetData generatedWidgetData = new GeneratedWidgetData(nameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate);
				QuestMarkerVM dataSource = (QuestMarkerVM)(generatedWidgetData.Data = _datasource_Root_Quests[i]);
				nameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate.AddComponent(generatedWidgetData);
				_widget_0_0.AddChildAtIndex(nameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate, i);
				nameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate.CreateWidgets();
				nameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate.SetIds();
				nameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate.SetAttributes();
				nameMarker__SandBox_ViewModelCollection_Missions_NameMarker_MissionNameMarkerVM_Dependency_2_ItemTemplate.SetDataSource(dataSource);
			}
		}
	}
}
