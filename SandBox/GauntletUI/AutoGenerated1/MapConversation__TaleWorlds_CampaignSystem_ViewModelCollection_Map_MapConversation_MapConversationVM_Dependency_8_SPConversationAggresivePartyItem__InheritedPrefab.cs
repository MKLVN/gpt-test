using System.ComponentModel;
using System.Numerics;
using TaleWorlds.CampaignSystem.ViewModelCollection.Conversation;
using TaleWorlds.CampaignSystem.ViewModelCollection.Quests;
using TaleWorlds.Core;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.GauntletUI.Data;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets;

namespace SandBox.GauntletUI.AutoGenerated1;

public class MapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_8_SPConversationAggresivePartyItem__InheritedPrefab : Widget
{
	private Widget _widget;

	private Widget _widget_0;

	private ImageIdentifierWidget _widget_1;

	private TextWidget _widget_2;

	private HintWidget _widget_3;

	private ListPanel _widget_4;

	private ConversationAggressivePartyItemVM _datasource_Root;

	private ImageIdentifierVM _datasource_Root_LeaderVisual;

	private MBBindingList<QuestMarkerVM> _datasource_Root_Quests;

	public MapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_8_SPConversationAggresivePartyItem__InheritedPrefab(UIContext context)
		: base(context)
	{
	}

	public virtual void CreateWidgets()
	{
		_widget = this;
		_widget_0 = new Widget(base.Context);
		_widget.AddChild(_widget_0);
		_widget_1 = new ImageIdentifierWidget(base.Context);
		_widget.AddChild(_widget_1);
		_widget_2 = new TextWidget(base.Context);
		_widget.AddChild(_widget_2);
		_widget_3 = new HintWidget(base.Context);
		_widget.AddChild(_widget_3);
		_widget_4 = new ListPanel(base.Context);
		_widget.AddChild(_widget_4);
	}

	public virtual void SetIds()
	{
	}

	public virtual void SetAttributes()
	{
		base.WidthSizePolicy = SizePolicy.Fixed;
		base.HeightSizePolicy = SizePolicy.Fixed;
		base.SuggestedWidth = 50f;
		base.SuggestedHeight = 50f;
		base.HorizontalAlignment = HorizontalAlignment.Left;
		_widget_0.DoNotAcceptEvents = true;
		_widget_0.WidthSizePolicy = SizePolicy.Fixed;
		_widget_0.HeightSizePolicy = SizePolicy.Fixed;
		_widget_0.SuggestedWidth = 50f;
		_widget_0.SuggestedHeight = 35.5f;
		_widget_0.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_0.Sprite = base.Context.SpriteData.GetSprite("BlankWhiteSquare");
		_widget_0.CircularClipEnabled = true;
		_widget_0.CircularClipRadius = 45f;
		_widget_0.CircularClipSmoothingRadius = 5f;
		_widget_0.CircularClipXOffset = 0f;
		_widget_0.CircularClipYOffset = -25f;
		_widget_0.IsVisible = false;
		_widget_1.DoNotAcceptEvents = true;
		_widget_1.WidthSizePolicy = SizePolicy.Fixed;
		_widget_1.HeightSizePolicy = SizePolicy.Fixed;
		_widget_1.SuggestedWidth = 50f;
		_widget_1.SuggestedHeight = 35.5f;
		_widget_1.HorizontalAlignment = HorizontalAlignment.Center;
		_widget_1.CircularClipEnabled = true;
		_widget_1.CircularClipRadius = 45f;
		_widget_1.CircularClipSmoothingRadius = 5f;
		_widget_1.CircularClipXOffset = 0f;
		_widget_1.CircularClipYOffset = -25f;
		_widget_2.DoNotAcceptEvents = true;
		_widget_2.WidthSizePolicy = SizePolicy.StretchToParent;
		_widget_2.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_2.HorizontalAlignment = HorizontalAlignment.Left;
		_widget_2.VerticalAlignment = VerticalAlignment.Bottom;
		_widget_2.Brush = base.Context.GetBrush("Conversation.PartySize.Text");
		_widget_3.WidthSizePolicy = SizePolicy.StretchToParent;
		_widget_3.HeightSizePolicy = SizePolicy.StretchToParent;
		_widget_3.IsDisabled = true;
		_widget_4.WidthSizePolicy = SizePolicy.CoverChildren;
		_widget_4.HeightSizePolicy = SizePolicy.CoverChildren;
		_widget_4.HorizontalAlignment = HorizontalAlignment.Right;
		_widget_4.VerticalAlignment = VerticalAlignment.Top;
	}

	public virtual void DestroyDataSource()
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
		_widget_2.PropertyChanged -= PropertyChangedListenerOf_widget_2;
		_widget_2.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_2;
		_widget_2.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_2;
		_widget_2.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_2;
		_widget_2.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_2;
		_widget_2.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_2;
		_widget_2.intPropertyChanged -= intPropertyChangedListenerOf_widget_2;
		_widget_2.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_2;
		_widget_2.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_2;
		_widget_3.EventFire -= EventListenerOf_widget_3;
		if (_datasource_Root_LeaderVisual != null)
		{
			_datasource_Root_LeaderVisual.PropertyChanged -= ViewModelPropertyChangedListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithValue -= ViewModelPropertyChangedWithValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithBoolValue -= ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithIntValue -= ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithFloatValue -= ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithUIntValue -= ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithColorValue -= ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithDoubleValue -= ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithVec2Value -= ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_LeaderVisual;
			_widget_1.PropertyChanged -= PropertyChangedListenerOf_widget_1;
			_widget_1.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_1;
			_widget_1.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_1;
			_widget_1.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_1;
			_widget_1.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_1;
			_widget_1.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_1;
			_widget_1.intPropertyChanged -= intPropertyChangedListenerOf_widget_1;
			_widget_1.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_1;
			_widget_1.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_1;
			_datasource_Root_LeaderVisual = null;
		}
		if (_datasource_Root_Quests != null)
		{
			_datasource_Root_Quests.ListChanged -= OnList_datasource_Root_QuestsChanged;
			for (int num = _widget_4.ChildCount - 1; num >= 0; num--)
			{
				Widget child = _widget_4.GetChild(num);
				((MapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate)child).OnBeforeRemovedChild(child);
				((MapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate)_widget_4.GetChild(num)).DestroyDataSource();
			}
			_datasource_Root_Quests = null;
		}
		_datasource_Root = null;
	}

	public virtual void SetDataSource(ConversationAggressivePartyItemVM dataSource)
	{
		RefreshDataSource_datasource_Root(dataSource);
	}

	private void EventListenerOf_widget_3(Widget widget, string commandName, object[] args)
	{
		if (commandName == "HoverBegin")
		{
			_datasource_Root.ExecuteShowPartyTooltip();
		}
		if (commandName == "HoverEnd")
		{
			_datasource_Root.ExecuteHideTooltip();
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
		if (propertyName == "IntText")
		{
			_datasource_Root.HealthyAmount = _widget_2.IntText;
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
		if (!(propertyName == "AdditionalArgs") && !(propertyName == "ImageId"))
		{
			_ = propertyName == "ImageTypeCode";
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
		case "LeaderVisual":
			RefreshDataSource_datasource_Root_LeaderVisual(_datasource_Root.LeaderVisual);
			break;
		case "Quests":
			RefreshDataSource_datasource_Root_Quests(_datasource_Root.Quests);
			break;
		case "HealthyAmount":
			_widget_2.IntText = _datasource_Root.HealthyAmount;
			break;
		}
	}

	private void ViewModelPropertyChangedListenerOf_datasource_Root_LeaderVisual(object sender, PropertyChangedEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_LeaderVisual(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithValueListenerOf_datasource_Root_LeaderVisual(object sender, PropertyChangedWithValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_LeaderVisual(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_LeaderVisual(object sender, PropertyChangedWithBoolValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_LeaderVisual(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_LeaderVisual(object sender, PropertyChangedWithIntValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_LeaderVisual(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_LeaderVisual(object sender, PropertyChangedWithFloatValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_LeaderVisual(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_LeaderVisual(object sender, PropertyChangedWithUIntValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_LeaderVisual(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_LeaderVisual(object sender, PropertyChangedWithColorValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_LeaderVisual(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_LeaderVisual(object sender, PropertyChangedWithDoubleValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_LeaderVisual(e.PropertyName);
	}

	private void ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_LeaderVisual(object sender, PropertyChangedWithVec2ValueEventArgs e)
	{
		HandleViewModelPropertyChangeOf_datasource_Root_LeaderVisual(e.PropertyName);
	}

	private void HandleViewModelPropertyChangeOf_datasource_Root_LeaderVisual(string propertyName)
	{
		switch (propertyName)
		{
		case "AdditionalArgs":
			_widget_1.AdditionalArgs = _datasource_Root_LeaderVisual.AdditionalArgs;
			break;
		case "Id":
			_widget_1.ImageId = _datasource_Root_LeaderVisual.Id;
			break;
		case "ImageTypeCode":
			_widget_1.ImageTypeCode = _datasource_Root_LeaderVisual.ImageTypeCode;
			break;
		}
	}

	public void OnList_datasource_Root_QuestsChanged(object sender, TaleWorlds.Library.ListChangedEventArgs e)
	{
		switch (e.ListChangedType)
		{
		case TaleWorlds.Library.ListChangedType.Reset:
		{
			for (int num = _widget_4.ChildCount - 1; num >= 0; num--)
			{
				Widget child3 = _widget_4.GetChild(num);
				((MapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate)child3).OnBeforeRemovedChild(child3);
				Widget child4 = _widget_4.GetChild(num);
				((MapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate)child4).SetDataSource(null);
				_widget_4.RemoveChild(child4);
			}
			break;
		}
		case TaleWorlds.Library.ListChangedType.Sorted:
		{
			for (int i = 0; i < _datasource_Root_Quests.Count; i++)
			{
				QuestMarkerVM bindingObject = _datasource_Root_Quests[i];
				_widget_4.FindChild((Widget widget) => widget.GetComponent<GeneratedWidgetData>().Data == bindingObject).SetSiblingIndex(i);
			}
			break;
		}
		case TaleWorlds.Library.ListChangedType.ItemAdded:
		{
			MapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate mapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate = new MapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate(base.Context);
			GeneratedWidgetData generatedWidgetData = new GeneratedWidgetData(mapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate);
			QuestMarkerVM dataSource = (QuestMarkerVM)(generatedWidgetData.Data = _datasource_Root_Quests[e.NewIndex]);
			mapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate.AddComponent(generatedWidgetData);
			_widget_4.AddChildAtIndex(mapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate, e.NewIndex);
			mapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate.CreateWidgets();
			mapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate.SetIds();
			mapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate.SetAttributes();
			mapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate.SetDataSource(dataSource);
			break;
		}
		case TaleWorlds.Library.ListChangedType.ItemBeforeDeleted:
		{
			Widget child2 = _widget_4.GetChild(e.NewIndex);
			((MapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate)child2).OnBeforeRemovedChild(child2);
			break;
		}
		case TaleWorlds.Library.ListChangedType.ItemDeleted:
		{
			Widget child = _widget_4.GetChild(e.NewIndex);
			((MapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate)child).SetDataSource(null);
			_widget_4.RemoveChild(child);
			break;
		}
		case TaleWorlds.Library.ListChangedType.ItemChanged:
			break;
		}
	}

	private void RefreshDataSource_datasource_Root(ConversationAggressivePartyItemVM newDataSource)
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
			_widget_2.PropertyChanged -= PropertyChangedListenerOf_widget_2;
			_widget_2.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_2;
			_widget_2.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_2;
			_widget_2.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_2;
			_widget_2.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_2;
			_widget_2.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_2;
			_widget_2.intPropertyChanged -= intPropertyChangedListenerOf_widget_2;
			_widget_2.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_2;
			_widget_2.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_2;
			_widget_3.EventFire -= EventListenerOf_widget_3;
			if (_datasource_Root_LeaderVisual != null)
			{
				_datasource_Root_LeaderVisual.PropertyChanged -= ViewModelPropertyChangedListenerOf_datasource_Root_LeaderVisual;
				_datasource_Root_LeaderVisual.PropertyChangedWithValue -= ViewModelPropertyChangedWithValueListenerOf_datasource_Root_LeaderVisual;
				_datasource_Root_LeaderVisual.PropertyChangedWithBoolValue -= ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_LeaderVisual;
				_datasource_Root_LeaderVisual.PropertyChangedWithIntValue -= ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_LeaderVisual;
				_datasource_Root_LeaderVisual.PropertyChangedWithFloatValue -= ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_LeaderVisual;
				_datasource_Root_LeaderVisual.PropertyChangedWithUIntValue -= ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_LeaderVisual;
				_datasource_Root_LeaderVisual.PropertyChangedWithColorValue -= ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_LeaderVisual;
				_datasource_Root_LeaderVisual.PropertyChangedWithDoubleValue -= ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_LeaderVisual;
				_datasource_Root_LeaderVisual.PropertyChangedWithVec2Value -= ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_LeaderVisual;
				_widget_1.PropertyChanged -= PropertyChangedListenerOf_widget_1;
				_widget_1.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_1;
				_widget_1.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_1;
				_widget_1.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_1;
				_widget_1.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_1;
				_widget_1.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_1;
				_widget_1.intPropertyChanged -= intPropertyChangedListenerOf_widget_1;
				_widget_1.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_1;
				_widget_1.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_1;
				_datasource_Root_LeaderVisual = null;
			}
			if (_datasource_Root_Quests != null)
			{
				_datasource_Root_Quests.ListChanged -= OnList_datasource_Root_QuestsChanged;
				for (int num = _widget_4.ChildCount - 1; num >= 0; num--)
				{
					Widget child = _widget_4.GetChild(num);
					((MapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate)child).OnBeforeRemovedChild(child);
					Widget child2 = _widget_4.GetChild(num);
					((MapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate)child2).SetDataSource(null);
					_widget_4.RemoveChild(child2);
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
		_widget_2.IntText = _datasource_Root.HealthyAmount;
		_widget_2.PropertyChanged += PropertyChangedListenerOf_widget_2;
		_widget_2.boolPropertyChanged += boolPropertyChangedListenerOf_widget_2;
		_widget_2.floatPropertyChanged += floatPropertyChangedListenerOf_widget_2;
		_widget_2.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_2;
		_widget_2.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_2;
		_widget_2.doublePropertyChanged += doublePropertyChangedListenerOf_widget_2;
		_widget_2.intPropertyChanged += intPropertyChangedListenerOf_widget_2;
		_widget_2.uintPropertyChanged += uintPropertyChangedListenerOf_widget_2;
		_widget_2.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_2;
		_widget_3.EventFire += EventListenerOf_widget_3;
		_datasource_Root_LeaderVisual = _datasource_Root.LeaderVisual;
		if (_datasource_Root_LeaderVisual != null)
		{
			_datasource_Root_LeaderVisual.PropertyChanged += ViewModelPropertyChangedListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithValue += ViewModelPropertyChangedWithValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithBoolValue += ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithIntValue += ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithFloatValue += ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithUIntValue += ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithColorValue += ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithDoubleValue += ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithVec2Value += ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_LeaderVisual;
			_widget_1.AdditionalArgs = _datasource_Root_LeaderVisual.AdditionalArgs;
			_widget_1.ImageId = _datasource_Root_LeaderVisual.Id;
			_widget_1.ImageTypeCode = _datasource_Root_LeaderVisual.ImageTypeCode;
			_widget_1.PropertyChanged += PropertyChangedListenerOf_widget_1;
			_widget_1.boolPropertyChanged += boolPropertyChangedListenerOf_widget_1;
			_widget_1.floatPropertyChanged += floatPropertyChangedListenerOf_widget_1;
			_widget_1.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_1;
			_widget_1.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_1;
			_widget_1.doublePropertyChanged += doublePropertyChangedListenerOf_widget_1;
			_widget_1.intPropertyChanged += intPropertyChangedListenerOf_widget_1;
			_widget_1.uintPropertyChanged += uintPropertyChangedListenerOf_widget_1;
			_widget_1.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_1;
		}
		_datasource_Root_Quests = _datasource_Root.Quests;
		if (_datasource_Root_Quests != null)
		{
			_datasource_Root_Quests.ListChanged += OnList_datasource_Root_QuestsChanged;
			for (int i = 0; i < _datasource_Root_Quests.Count; i++)
			{
				MapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate mapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate = new MapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate(base.Context);
				GeneratedWidgetData generatedWidgetData = new GeneratedWidgetData(mapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate);
				QuestMarkerVM dataSource = (QuestMarkerVM)(generatedWidgetData.Data = _datasource_Root_Quests[i]);
				mapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate.AddComponent(generatedWidgetData);
				_widget_4.AddChildAtIndex(mapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate, i);
				mapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate.CreateWidgets();
				mapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate.SetIds();
				mapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate.SetAttributes();
				mapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate.SetDataSource(dataSource);
			}
		}
	}

	private void RefreshDataSource_datasource_Root_LeaderVisual(ImageIdentifierVM newDataSource)
	{
		if (_datasource_Root_LeaderVisual != null)
		{
			_datasource_Root_LeaderVisual.PropertyChanged -= ViewModelPropertyChangedListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithValue -= ViewModelPropertyChangedWithValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithBoolValue -= ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithIntValue -= ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithFloatValue -= ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithUIntValue -= ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithColorValue -= ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithDoubleValue -= ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithVec2Value -= ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_LeaderVisual;
			_widget_1.PropertyChanged -= PropertyChangedListenerOf_widget_1;
			_widget_1.boolPropertyChanged -= boolPropertyChangedListenerOf_widget_1;
			_widget_1.floatPropertyChanged -= floatPropertyChangedListenerOf_widget_1;
			_widget_1.Vec2PropertyChanged -= Vec2PropertyChangedListenerOf_widget_1;
			_widget_1.Vector2PropertyChanged -= Vector2PropertyChangedListenerOf_widget_1;
			_widget_1.doublePropertyChanged -= doublePropertyChangedListenerOf_widget_1;
			_widget_1.intPropertyChanged -= intPropertyChangedListenerOf_widget_1;
			_widget_1.uintPropertyChanged -= uintPropertyChangedListenerOf_widget_1;
			_widget_1.ColorPropertyChanged -= ColorPropertyChangedListenerOf_widget_1;
			_datasource_Root_LeaderVisual = null;
		}
		_datasource_Root_LeaderVisual = newDataSource;
		_datasource_Root_LeaderVisual = _datasource_Root.LeaderVisual;
		if (_datasource_Root_LeaderVisual != null)
		{
			_datasource_Root_LeaderVisual.PropertyChanged += ViewModelPropertyChangedListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithValue += ViewModelPropertyChangedWithValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithBoolValue += ViewModelPropertyChangedWithBoolValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithIntValue += ViewModelPropertyChangedWithIntValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithFloatValue += ViewModelPropertyChangedWithFloatValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithUIntValue += ViewModelPropertyChangedWithUIntValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithColorValue += ViewModelPropertyChangedWithColorValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithDoubleValue += ViewModelPropertyChangedWithDoubleValueListenerOf_datasource_Root_LeaderVisual;
			_datasource_Root_LeaderVisual.PropertyChangedWithVec2Value += ViewModelPropertyChangedWithVec2ValueListenerOf_datasource_Root_LeaderVisual;
			_widget_1.AdditionalArgs = _datasource_Root_LeaderVisual.AdditionalArgs;
			_widget_1.ImageId = _datasource_Root_LeaderVisual.Id;
			_widget_1.ImageTypeCode = _datasource_Root_LeaderVisual.ImageTypeCode;
			_widget_1.PropertyChanged += PropertyChangedListenerOf_widget_1;
			_widget_1.boolPropertyChanged += boolPropertyChangedListenerOf_widget_1;
			_widget_1.floatPropertyChanged += floatPropertyChangedListenerOf_widget_1;
			_widget_1.Vec2PropertyChanged += Vec2PropertyChangedListenerOf_widget_1;
			_widget_1.Vector2PropertyChanged += Vector2PropertyChangedListenerOf_widget_1;
			_widget_1.doublePropertyChanged += doublePropertyChangedListenerOf_widget_1;
			_widget_1.intPropertyChanged += intPropertyChangedListenerOf_widget_1;
			_widget_1.uintPropertyChanged += uintPropertyChangedListenerOf_widget_1;
			_widget_1.ColorPropertyChanged += ColorPropertyChangedListenerOf_widget_1;
		}
	}

	private void RefreshDataSource_datasource_Root_Quests(MBBindingList<QuestMarkerVM> newDataSource)
	{
		if (_datasource_Root_Quests != null)
		{
			_datasource_Root_Quests.ListChanged -= OnList_datasource_Root_QuestsChanged;
			for (int num = _widget_4.ChildCount - 1; num >= 0; num--)
			{
				Widget child = _widget_4.GetChild(num);
				((MapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate)child).OnBeforeRemovedChild(child);
				Widget child2 = _widget_4.GetChild(num);
				((MapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate)child2).SetDataSource(null);
				_widget_4.RemoveChild(child2);
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
				MapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate mapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate = new MapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate(base.Context);
				GeneratedWidgetData generatedWidgetData = new GeneratedWidgetData(mapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate);
				QuestMarkerVM dataSource = (QuestMarkerVM)(generatedWidgetData.Data = _datasource_Root_Quests[i]);
				mapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate.AddComponent(generatedWidgetData);
				_widget_4.AddChildAtIndex(mapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate, i);
				mapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate.CreateWidgets();
				mapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate.SetIds();
				mapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate.SetAttributes();
				mapConversation__TaleWorlds_CampaignSystem_ViewModelCollection_Map_MapConversation_MapConversationVM_Dependency_11_ItemTemplate.SetDataSource(dataSource);
			}
		}
	}
}
