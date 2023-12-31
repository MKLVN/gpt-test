using System.ComponentModel;
using TaleWorlds.GauntletUI;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.ViewModelCollection.HUD;

namespace TaleWorlds.MountAndBlade.GauntletUI.AutoGenerated0;

public class MainAgentCheerBarkController__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentCheerBarkControllerVM_Dependency_5_ItemTemplate : MainAgentCheerBarkController__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentCheerBarkControllerVM_Dependency_3_MainAgentCheerBarkNodeCircle__InheritedPrefab
{
	private MainAgentCheerBarkController__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentCheerBarkControllerVM_Dependency_3_MainAgentCheerBarkNodeCircle__InheritedPrefab _widget;

	private CheerBarkNodeItemVM _datasource_Root;

	public MainAgentCheerBarkController__TaleWorlds_MountAndBlade_ViewModelCollection_HUD_MissionMainAgentCheerBarkControllerVM_Dependency_5_ItemTemplate(UIContext context)
		: base(context)
	{
	}

	private VisualDefinition CreateVisualDefinitionCircleBackground()
	{
		VisualDefinition visualDefinition = new VisualDefinition("CircleBackground", 0.15f, 0f, easeIn: false);
		visualDefinition.AddVisualState(new VisualState("DisabledSelected")
		{
			SuggestedHeight = 84f,
			SuggestedWidth = 85f
		});
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
		visualDefinition.AddVisualState(new VisualState("DisabledSelected")
		{
			SuggestedHeight = 125f,
			SuggestedWidth = 127f
		});
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

	public override void CreateWidgets()
	{
		base.CreateWidgets();
		_widget = this;
	}

	public override void SetIds()
	{
		base.SetIds();
	}

	public override void SetAttributes()
	{
		base.SetAttributes();
	}

	public override void DestroyDataSource()
	{
		base.DestroyDataSource();
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

	public override void SetDataSource(CheerBarkNodeItemVM dataSource)
	{
		base.SetDataSource(dataSource);
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

	private void RefreshDataSource_datasource_Root(CheerBarkNodeItemVM newDataSource)
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
