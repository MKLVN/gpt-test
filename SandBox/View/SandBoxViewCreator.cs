using System;
using System.Collections.Generic;
using System.Reflection;
using SandBox.View.Map;
using SandBox.View.Menu;
using SandBox.View.Missions;
using SandBox.View.Missions.Tournaments;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;
using TaleWorlds.MountAndBlade.View.MissionViews.Singleplayer;
using TaleWorlds.ScreenSystem;

namespace SandBox.View;

public static class SandBoxViewCreator
{
	private static Dictionary<string, MethodInfo> _viewCreators;

	private static Dictionary<Type, Type> _actualViewTypes;

	private static List<Type> _defaultTypes;

	static SandBoxViewCreator()
	{
		_viewCreators = new Dictionary<string, MethodInfo>();
		_actualViewTypes = new Dictionary<Type, Type>();
		_defaultTypes = new List<Type>();
		Assembly[] viewAssemblies = GetViewAssemblies();
		Assembly assembly = typeof(ViewCreatorModule).Assembly;
		CheckAssemblyScreens(assembly);
		Assembly[] array = viewAssemblies;
		for (int i = 0; i < array.Length; i++)
		{
			CheckAssemblyScreens(array[i]);
		}
		CollectDefaults(assembly);
		array = viewAssemblies;
		for (int i = 0; i < array.Length; i++)
		{
			CollectDefaults(array[i]);
		}
		array = viewAssemblies;
		for (int i = 0; i < array.Length; i++)
		{
			CheckOverridenViews(array[i]);
		}
	}

	private static void CheckAssemblyScreens(Assembly assembly)
	{
		foreach (Type item in assembly.GetTypesSafe())
		{
			object[] customAttributes = item.GetCustomAttributes(typeof(ViewCreatorModule), inherit: false);
			if (customAttributes == null || customAttributes.Length != 1 || !(customAttributes[0] is ViewCreatorModule))
			{
				continue;
			}
			MethodInfo[] methods = item.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (MethodInfo methodInfo in methods)
			{
				if (methodInfo.GetCustomAttributes(typeof(ViewMethod), inherit: false)[0] is ViewMethod viewMethod)
				{
					_viewCreators.Add(viewMethod.Name, methodInfo);
				}
			}
		}
	}

	private static void CheckOverridenViews(Assembly assembly)
	{
		foreach (Type item in assembly.GetTypesSafe())
		{
			if (!typeof(MapView).IsAssignableFrom(item) && !typeof(MenuView).IsAssignableFrom(item) && !typeof(MissionView).IsAssignableFrom(item) && !typeof(ScreenBase).IsAssignableFrom(item))
			{
				continue;
			}
			object[] customAttributes = item.GetCustomAttributes(typeof(OverrideView), inherit: false);
			if (customAttributes == null || customAttributes.Length != 1)
			{
				continue;
			}
			object obj = customAttributes[0];
			OverrideView val = (OverrideView)((obj is OverrideView) ? obj : null);
			if (val == null)
			{
				continue;
			}
			if (!_actualViewTypes.ContainsKey(val.BaseType))
			{
				_actualViewTypes.Add(val.BaseType, item);
			}
			else
			{
				_actualViewTypes[val.BaseType] = item;
			}
			if (!_defaultTypes.Contains(val.BaseType))
			{
				continue;
			}
			for (int i = 0; i < _defaultTypes.Count; i++)
			{
				if (_defaultTypes[i] == val.BaseType)
				{
					_defaultTypes[i] = item;
				}
			}
		}
	}

	private static void CollectDefaults(Assembly assembly)
	{
		foreach (Type item in assembly.GetTypesSafe())
		{
			if (typeof(MissionBehavior).IsAssignableFrom(item))
			{
				object[] customAttributes = item.GetCustomAttributes(typeof(DefaultView), inherit: false);
				if (customAttributes != null && customAttributes.Length == 1)
				{
					_defaultTypes.Add(item);
				}
			}
		}
	}

	private static Assembly[] GetViewAssemblies()
	{
		List<Assembly> list = new List<Assembly>();
		Assembly assembly = typeof(ViewCreatorModule).Assembly;
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		foreach (Assembly assembly2 in assemblies)
		{
			AssemblyName[] referencedAssemblies = assembly2.GetReferencedAssemblies();
			for (int j = 0; j < referencedAssemblies.Length; j++)
			{
				if (referencedAssemblies[j].ToString() == assembly.GetName().ToString())
				{
					list.Add(assembly2);
					break;
				}
			}
		}
		return list.ToArray();
	}

	public static ScreenBase CreateSaveLoadScreen(bool isSaving)
	{
		return ViewCreatorManager.CreateScreenView<SaveLoadScreen>(new object[1] { isSaving });
	}

	public static MissionView CreateMissionCraftingView()
	{
		return null;
	}

	public static MissionView CreateMissionNameMarkerUIHandler(Mission mission = null)
	{
		return ViewCreatorManager.CreateMissionView<MissionNameMarkerUIHandler>(mission != null, mission, Array.Empty<object>());
	}

	public static MissionView CreateMissionConversationView(Mission mission)
	{
		return ViewCreatorManager.CreateMissionView<MissionConversationView>(true, mission, Array.Empty<object>());
	}

	public static MissionView CreateMissionBarterView()
	{
		return ViewCreatorManager.CreateMissionView<BarterView>(false, (Mission)null, Array.Empty<object>());
	}

	public static MissionView CreateMissionTournamentView()
	{
		return ViewCreatorManager.CreateMissionView<MissionTournamentView>(false, (Mission)null, Array.Empty<object>());
	}

	public static MapView CreateMapView<T>(params object[] parameters) where T : MapView
	{
		Type type = typeof(T);
		if (_actualViewTypes.ContainsKey(typeof(T)))
		{
			type = _actualViewTypes[typeof(T)];
		}
		return Activator.CreateInstance(type, parameters) as MapView;
	}

	public static MenuView CreateMenuView<T>(params object[] parameters) where T : MenuView
	{
		Type type = typeof(T);
		if (_actualViewTypes.ContainsKey(typeof(T)))
		{
			type = _actualViewTypes[typeof(T)];
		}
		return Activator.CreateInstance(type, parameters) as MenuView;
	}

	public static MissionView CreateBoardGameView()
	{
		return ViewCreatorManager.CreateMissionView<BoardGameView>(false, (Mission)null, Array.Empty<object>());
	}

	public static MissionView CreateMissionAmbushDeploymentView()
	{
		return ViewCreatorManager.CreateMissionView<MissionAmbushDeploymentView>(false, (Mission)null, Array.Empty<object>());
	}

	public static MissionView CreateMissionArenaPracticeFightView()
	{
		return ViewCreatorManager.CreateMissionView<MissionArenaPracticeFightView>(false, (Mission)null, Array.Empty<object>());
	}
}
