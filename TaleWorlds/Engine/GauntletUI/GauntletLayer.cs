using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.GauntletUI.Data;
using TaleWorlds.GauntletUI.PrefabSystem;
using TaleWorlds.Library;
using TaleWorlds.ScreenSystem;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.Engine.GauntletUI;

public class GauntletLayer : ScreenLayer
{
	public readonly TwoDimensionView _twoDimensionView;

	public readonly UIContext _gauntletUIContext;

	public readonly List<Tuple<IGauntletMovie, ViewModel>> _moviesAndDatasources;

	public readonly TwoDimensionEnginePlatform _twoDimensionEnginePlatform;

	public readonly EngineInputService _engineInputService;

	public readonly WidgetFactory _widgetFactory;

	public GauntletLayer(int localOrder, string categoryId = "GauntletLayer", bool shouldClear = false)
		: base(localOrder, categoryId)
	{
		_moviesAndDatasources = new List<Tuple<IGauntletMovie, ViewModel>>();
		_widgetFactory = UIResourceManager.WidgetFactory;
		ResourceDepot uIResourceDepot = UIResourceManager.UIResourceDepot;
		_twoDimensionView = TwoDimensionView.CreateTwoDimension();
		if (shouldClear)
		{
			_twoDimensionView.SetClearColor(255u);
			_twoDimensionView.SetRenderOption(View.ViewRenderOptions.ClearColor, value: true);
		}
		_twoDimensionEnginePlatform = new TwoDimensionEnginePlatform(_twoDimensionView);
		TwoDimensionContext twoDimensionContext = new TwoDimensionContext(_twoDimensionEnginePlatform, UIResourceManager.ResourceContext, uIResourceDepot);
		_engineInputService = new EngineInputService(base.Input);
		_gauntletUIContext = new UIContext(twoDimensionContext, base.Input, _engineInputService, UIResourceManager.SpriteData, UIResourceManager.FontFactory, UIResourceManager.BrushFactory);
		_gauntletUIContext.ScaleModifier = base.Scale;
		_gauntletUIContext.Initialize();
		base.MouseEnabled = true;
		_gauntletUIContext.EventManager.LoseFocus += EventManagerOnLoseFocus;
		_gauntletUIContext.EventManager.GainFocus += EventManagerOnGainFocus;
		_gauntletUIContext.EventManager.OnGetIsAvailableForGamepadNavigation = GetIsAvailableForGamepadNavigation;
		_gauntletUIContext.EventManager.OnGetLastScreenOrder = GetLastScreenOrder;
		_gauntletUIContext.EventManager.OnGetIsHitThisFrame = GetIsHitThisFrame;
		_gauntletUIContext.EventManager.OnGetIsBlockedAtPosition = GetIsBlockedAtPosition;
		_gauntletUIContext.EventManager.UsableArea = base.UsableArea;
	}

	private void EventManagerOnLoseFocus()
	{
		if (!base.IsFocusLayer)
		{
			ScreenManager.TryLoseFocus(this);
		}
	}

	private void EventManagerOnGainFocus()
	{
		ScreenManager.TrySetFocus(this);
	}

	public IGauntletMovie LoadMovie(string movieName, ViewModel dataSource)
	{
		bool doNotUseGeneratedPrefabs = NativeConfig.GetUIDoNotUseGeneratedPrefabs || UIConfig.DoNotUseGeneratedPrefabs;
		bool hotReloadEnabled = NativeConfig.GetUIDebugMode || UIConfig.DebugModeEnabled;
		IGauntletMovie gauntletMovie = GauntletMovie.Load(_gauntletUIContext, _widgetFactory, movieName, dataSource, doNotUseGeneratedPrefabs, hotReloadEnabled);
		_moviesAndDatasources.Add(new Tuple<IGauntletMovie, ViewModel>(gauntletMovie, dataSource));
		return gauntletMovie;
	}

	public void ReleaseMovie(IGauntletMovie movie)
	{
		Tuple<IGauntletMovie, ViewModel> item = _moviesAndDatasources.SingleOrDefault((Tuple<IGauntletMovie, ViewModel> t) => t.Item1 == movie);
		_moviesAndDatasources.Remove(item);
		movie.Release();
	}

	protected override void OnActivate()
	{
		base.OnActivate();
		_twoDimensionView.SetEnable(value: true);
	}

	protected override void OnDeactivate()
	{
		_twoDimensionView.Clear();
		_twoDimensionView.SetEnable(value: false);
		base.OnDeactivate();
	}

	protected override void Tick(float dt)
	{
		base.Tick(dt);
		_twoDimensionEnginePlatform.Reset();
		_gauntletUIContext.Update(dt);
		foreach (Tuple<IGauntletMovie, ViewModel> moviesAndDatasource in _moviesAndDatasources)
		{
			moviesAndDatasource.Item1.Update();
		}
		base.ActiveCursor = (CursorType)_gauntletUIContext.ActiveCursorOfContext;
	}

	protected override void LateTick(float dt)
	{
		base.LateTick(dt);
		_twoDimensionView.BeginFrame();
		_gauntletUIContext.LateUpdate(dt);
		_twoDimensionView.EndFrame();
	}

	protected override void OnLateUpdate(float dt)
	{
		base.OnLateUpdate(dt);
		_engineInputService.UpdateInputDevices(base.KeyboardEnabled, base.MouseEnabled, base.GamepadEnabled);
	}

	protected override void Update(IReadOnlyList<int> lastKeysPressed)
	{
		_gauntletUIContext.EventManager.FocusedWidget?.HandleInput(lastKeysPressed);
	}

	protected override void OnFinalize()
	{
		foreach (Tuple<IGauntletMovie, ViewModel> moviesAndDatasource in _moviesAndDatasources)
		{
			moviesAndDatasource.Item1.Release();
		}
		_gauntletUIContext.EventManager.LoseFocus -= EventManagerOnLoseFocus;
		_gauntletUIContext.EventManager.GainFocus -= EventManagerOnGainFocus;
		_gauntletUIContext.EventManager.OnGetIsAvailableForGamepadNavigation = null;
		_gauntletUIContext.EventManager.OnGetLastScreenOrder = null;
		_gauntletUIContext.EventManager.OnGetIsHitThisFrame = null;
		_gauntletUIContext.EventManager.OnGetIsBlockedAtPosition = null;
		_gauntletUIContext.OnFinalize();
		base.OnFinalize();
	}

	protected override void RefreshGlobalOrder(ref int currentOrder)
	{
		_twoDimensionView.SetRenderOrder(currentOrder);
		currentOrder++;
	}

	public override void ProcessEvents()
	{
		base.ProcessEvents();
		_gauntletUIContext.UpdateInput(base._usedInputs);
	}

	public override bool HitTest(Vector2 position)
	{
		foreach (Tuple<IGauntletMovie, ViewModel> moviesAndDatasource in _moviesAndDatasources)
		{
			if (_gauntletUIContext.HitTest(moviesAndDatasource.Item1.RootWidget, position))
			{
				return true;
			}
		}
		return false;
	}

	private bool GetIsBlockedAtPosition(Vector2 position)
	{
		return ScreenManager.IsLayerBlockedAtPosition(this, position);
	}

	public override bool HitTest()
	{
		foreach (Tuple<IGauntletMovie, ViewModel> moviesAndDatasource in _moviesAndDatasources)
		{
			if (_gauntletUIContext.HitTest(moviesAndDatasource.Item1.RootWidget))
			{
				return true;
			}
		}
		_gauntletUIContext.EventManager.SetHoveredView(null);
		return false;
	}

	public override bool FocusTest()
	{
		foreach (Tuple<IGauntletMovie, ViewModel> moviesAndDatasource in _moviesAndDatasources)
		{
			if (_gauntletUIContext.FocusTest(moviesAndDatasource.Item1.RootWidget))
			{
				return true;
			}
		}
		return false;
	}

	public override bool IsFocusedOnInput()
	{
		return _gauntletUIContext.EventManager.FocusedWidget is EditableTextWidget;
	}

	protected override void OnLoseFocus()
	{
		_gauntletUIContext.EventManager.ClearFocus();
	}

	public override void OnOnScreenKeyboardDone(string inputText)
	{
		base.OnOnScreenKeyboardDone(inputText);
		_gauntletUIContext.OnOnScreenkeyboardTextInputDone(inputText);
	}

	public override void OnOnScreenKeyboardCanceled()
	{
		base.OnOnScreenKeyboardCanceled();
		_gauntletUIContext.OnOnScreenKeyboardCanceled();
	}

	public override void UpdateLayout()
	{
		base.UpdateLayout();
		_gauntletUIContext.ScaleModifier = base.Scale;
		_gauntletUIContext.EventManager.UsableArea = base.UsableArea;
		_moviesAndDatasources.ForEach(delegate(Tuple<IGauntletMovie, ViewModel> m)
		{
			m.Item2.RefreshValues();
		});
		_moviesAndDatasources.ForEach(delegate(Tuple<IGauntletMovie, ViewModel> m)
		{
			m.Item1.RefreshBindingWithChildren();
		});
		_gauntletUIContext.EventManager.UpdateLayout();
	}

	public bool GetIsAvailableForGamepadNavigation()
	{
		if (base.LastActiveState && base.IsActive && (base.MouseEnabled || base.GamepadEnabled))
		{
			if (!base.IsFocusLayer)
			{
				return (base.InputRestrictions.InputUsageMask & InputUsageMask.Mouse) != 0;
			}
			return true;
		}
		return false;
	}

	private bool GetIsHitThisFrame()
	{
		return base.IsHitThisFrame;
	}

	private int GetLastScreenOrder()
	{
		return base.ScreenOrderInLastFrame;
	}

	public override void DrawDebugInfo()
	{
		foreach (Tuple<IGauntletMovie, ViewModel> moviesAndDatasource in _moviesAndDatasources)
		{
			IGauntletMovie item = moviesAndDatasource.Item1;
			ViewModel item2 = moviesAndDatasource.Item2;
			Imgui.Text("Movie: " + item.MovieName);
			Imgui.Text("Data Source: " + (item2?.GetType().Name ?? "No Datasource"));
		}
		base.DrawDebugInfo();
		Imgui.Text("Press 'Shift+F' to take widget hierarchy snapshot.");
		_gauntletUIContext.DrawWidgetDebugInfo();
	}
}
