using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.CampaignSystem.ViewModelCollection.Quests;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.Screens;
using TaleWorlds.ScreenSystem;
using TaleWorlds.TwoDimension;

namespace SandBox.GauntletUI;

[GameStateScreen(typeof(QuestsState))]
public class GauntletQuestsScreen : ScreenBase, IGameStateListener
{
	private QuestsVM _dataSource;

	private GauntletLayer _gauntletLayer;

	private SpriteCategory _questCategory;

	private readonly QuestsState _questsState;

	public GauntletQuestsScreen(QuestsState questsState)
	{
		_questsState = questsState;
	}

	protected override void OnFrameTick(float dt)
	{
		base.OnFrameTick(dt);
		LoadingWindow.DisableGlobalLoadingWindow();
		if (_gauntletLayer.Input.IsHotKeyDownAndReleased("Exit") || _gauntletLayer.Input.IsHotKeyDownAndReleased("Confirm") || _gauntletLayer.Input.IsGameKeyDownAndReleased(42))
		{
			UISoundsHelper.PlayUISound("event:/ui/default");
			_dataSource.ExecuteClose();
		}
	}

	void IGameStateListener.OnActivate()
	{
		base.OnActivate();
		SpriteData spriteData = UIResourceManager.SpriteData;
		TwoDimensionEngineResourceContext resourceContext = UIResourceManager.ResourceContext;
		ResourceDepot uIResourceDepot = UIResourceManager.UIResourceDepot;
		_questCategory = spriteData.SpriteCategories["ui_quest"];
		_questCategory.Load(resourceContext, uIResourceDepot);
		_dataSource = new QuestsVM(CloseQuestsScreen);
		_dataSource.SetDoneInputKey(HotKeyManager.GetCategory("GenericPanelGameKeyCategory").GetHotKey("Confirm"));
		_gauntletLayer = new GauntletLayer(1, "GauntletLayer", shouldClear: true);
		_gauntletLayer.InputRestrictions.SetInputRestrictions();
		_gauntletLayer.Input.RegisterHotKeyCategory(HotKeyManager.GetCategory("GenericPanelGameKeyCategory"));
		_gauntletLayer.Input.RegisterHotKeyCategory(HotKeyManager.GetCategory("GenericCampaignPanelsGameKeyCategory"));
		_gauntletLayer.LoadMovie("QuestsScreen", _dataSource);
		_gauntletLayer.IsFocusLayer = true;
		AddLayer(_gauntletLayer);
		ScreenManager.TrySetFocus(_gauntletLayer);
		Game.Current.EventManager.TriggerEvent(new TutorialContextChangedEvent(TutorialContexts.QuestsScreen));
		if (_questsState.InitialSelectedIssue != null)
		{
			_dataSource.SetSelectedIssue(_questsState.InitialSelectedIssue);
		}
		else if (_questsState.InitialSelectedQuest != null)
		{
			_dataSource.SetSelectedQuest(_questsState.InitialSelectedQuest);
		}
		else if (_questsState.InitialSelectedLog != null)
		{
			_dataSource.SetSelectedLog(_questsState.InitialSelectedLog);
		}
		UISoundsHelper.PlayUISound("event:/ui/panels/panel_quest_open");
		_gauntletLayer._gauntletUIContext.EventManager.GainNavigationAfterFrames(2);
	}

	void IGameStateListener.OnDeactivate()
	{
		base.OnDeactivate();
		_questCategory.Unload();
		_gauntletLayer.IsFocusLayer = false;
		ScreenManager.TryLoseFocus(_gauntletLayer);
		RemoveLayer(_gauntletLayer);
		Game.Current.EventManager.TriggerEvent(new TutorialContextChangedEvent(TutorialContexts.None));
	}

	void IGameStateListener.OnInitialize()
	{
	}

	void IGameStateListener.OnFinalize()
	{
		_dataSource?.OnFinalize();
		_dataSource = null;
		_gauntletLayer = null;
	}

	private void CloseQuestsScreen()
	{
		Game.Current.GameStateManager.PopState();
	}
}
