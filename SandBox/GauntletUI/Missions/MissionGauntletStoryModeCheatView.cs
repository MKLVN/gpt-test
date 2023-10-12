using System;
using System.Collections.Generic;
using SandBox.ViewModelCollection.Map.Cheat;
using StoryMode.GameComponents.CampaignBehaviors;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;
using TaleWorlds.ScreenSystem;

namespace SandBox.GauntletUI.Missions;

[OverrideView(typeof(MissionCheatView))]
public class MissionGauntletStoryModeCheatView : MissionCheatView
{
	private GauntletLayer _gauntletLayer;

	private GameplayCheatsVM _dataSource;

	private bool _isActive;

	public override void OnMissionScreenFinalize()
	{
		((MissionView)this).OnMissionScreenFinalize();
		((MissionCheatView)this).FinalizeScreen();
	}

	public override bool GetIsCheatsAvailable()
	{
		AchievementsCampaignBehavior obj = Campaign.Current?.GetCampaignBehavior<AchievementsCampaignBehavior>();
		if (obj == null)
		{
			return true;
		}
		TextObject reason;
		return !obj.CheckAchievementSystemActivity(out reason);
	}

	public override void InitializeScreen()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		if (!_isActive)
		{
			_isActive = true;
			IEnumerable<GameplayCheatBase> missionCheatList = GameplayCheatsManager.GetMissionCheatList();
			_dataSource = new GameplayCheatsVM((Action)((MissionCheatView)this).FinalizeScreen, missionCheatList);
			InitializeKeyVisuals();
			_gauntletLayer = new GauntletLayer(4500);
			_gauntletLayer.LoadMovie("MapCheats", (ViewModel)(object)_dataSource);
			_gauntletLayer.Input.RegisterHotKeyCategory(HotKeyManager.GetCategory("GenericPanelGameKeyCategory"));
			_gauntletLayer.InputRestrictions.SetInputRestrictions();
			_gauntletLayer.IsFocusLayer = true;
			ScreenManager.TrySetFocus(_gauntletLayer);
			((ScreenBase)(object)((MissionView)this).MissionScreen).AddLayer((ScreenLayer)_gauntletLayer);
		}
	}

	public override void FinalizeScreen()
	{
		if (_isActive)
		{
			_isActive = false;
			((ScreenBase)(object)((MissionView)this).MissionScreen).RemoveLayer((ScreenLayer)_gauntletLayer);
			((ViewModel)(object)_dataSource)?.OnFinalize();
			_gauntletLayer = null;
			_dataSource = null;
		}
	}

	public override void OnMissionScreenTick(float dt)
	{
		((MissionView)this).OnMissionScreenTick(dt);
		if (_isActive)
		{
			HandleInput();
		}
	}

	private void HandleInput()
	{
		if (_gauntletLayer.Input.IsHotKeyReleased("Exit"))
		{
			UISoundsHelper.PlayUISound("event:/ui/default");
			GameplayCheatsVM dataSource = _dataSource;
			if (dataSource != null)
			{
				dataSource.ExecuteClose();
			}
		}
	}

	private void InitializeKeyVisuals()
	{
		_dataSource.SetCloseInputKey(HotKeyManager.GetCategory("GenericPanelGameKeyCategory").GetHotKey("Exit"));
	}
}
