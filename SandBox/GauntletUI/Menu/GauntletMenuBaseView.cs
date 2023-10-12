using SandBox.View.Menu;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.CampaignSystem.ViewModelCollection.GameMenu;
using TaleWorlds.Core;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.GauntletUI.Data;
using TaleWorlds.InputSystem;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.ScreenSystem;

namespace SandBox.GauntletUI.Menu;

[OverrideView(typeof(MenuBaseView))]
public class GauntletMenuBaseView : MenuView
{
	private GauntletLayer _layerAsGauntletLayer;

	private IGauntletMovie _movie;

	public GameMenuVM GameMenuDataSource { get; private set; }

	protected override void OnInitialize()
	{
		base.OnInitialize();
		GameMenuDataSource = new GameMenuVM(base.MenuContext);
		GameKey gameKey = HotKeyManager.GetCategory("Generic").GetGameKey(4);
		GameMenuDataSource.AddHotKey(GameMenuOption.LeaveType.Leave, gameKey);
		base.Layer = base.MenuViewContext.FindLayer<GauntletLayer>("BasicLayer");
		if (base.Layer == null)
		{
			base.Layer = new GauntletLayer(100)
			{
				Name = "BasicLayer"
			};
			base.MenuViewContext.AddLayer(base.Layer);
		}
		_layerAsGauntletLayer = base.Layer as GauntletLayer;
		_movie = _layerAsGauntletLayer.LoadMovie("GameMenu", GameMenuDataSource);
		ScreenManager.TrySetFocus(base.Layer);
		_layerAsGauntletLayer._gauntletUIContext.ContextAlpha = 1f;
		MBInformationManager.HideInformations();
		GainGamepadNavigationAfterSeconds(0.25f);
	}

	protected override void OnActivate()
	{
		base.OnActivate();
		GameMenuDataSource.Refresh(forceUpdateItems: true);
	}

	protected override void OnResume()
	{
		base.OnResume();
		GameMenuDataSource.Refresh(forceUpdateItems: true);
	}

	protected override void OnFinalize()
	{
		GameMenuDataSource.OnFinalize();
		GameMenuDataSource = null;
		ScreenManager.TryLoseFocus(base.Layer);
		_layerAsGauntletLayer.ReleaseMovie(_movie);
		_layerAsGauntletLayer = null;
		base.Layer = null;
		_movie = null;
		base.OnFinalize();
	}

	protected override void OnFrameTick(float dt)
	{
		base.OnFrameTick(dt);
		GameMenuDataSource.OnFrameTick();
	}

	protected override void OnMapConversationActivated()
	{
		base.OnMapConversationActivated();
		if (_layerAsGauntletLayer?._gauntletUIContext != null)
		{
			_layerAsGauntletLayer._gauntletUIContext.ContextAlpha = 0f;
		}
	}

	protected override void OnMapConversationDeactivated()
	{
		base.OnMapConversationDeactivated();
		if (_layerAsGauntletLayer?._gauntletUIContext != null)
		{
			_layerAsGauntletLayer._gauntletUIContext.ContextAlpha = 1f;
		}
	}

	protected override void OnMenuContextUpdated(MenuContext newMenuContext)
	{
		base.OnMenuContextUpdated(newMenuContext);
		GameMenuDataSource.UpdateMenuContext(newMenuContext);
	}

	protected override void OnBackgroundMeshNameSet(string name)
	{
		base.OnBackgroundMeshNameSet(name);
		GameMenuDataSource.Background = name;
	}

	private void GainGamepadNavigationAfterSeconds(float seconds)
	{
		_layerAsGauntletLayer._gauntletUIContext.EventManager.GainNavigationAfterTime(seconds, () => GameMenuDataSource.ItemList.Count > 0);
	}
}
