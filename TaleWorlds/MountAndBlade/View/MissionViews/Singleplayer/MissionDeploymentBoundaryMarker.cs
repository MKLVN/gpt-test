using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.View.MissionViews.Singleplayer;

public class MissionDeploymentBoundaryMarker : MissionView
{
	public enum MissionDeploymentBoundaryType
	{
		StaticSceneBoundaries,
		DynamicDeploymentBoundaries
	}

	public const string AttackerStaticDeploymentBoundaryName = "walk_area";

	public const string DefenderStaticDeploymentBoundaryName = "deployment_castle_boundary";

	public readonly float MarkerInterval;

	public readonly MissionDeploymentBoundaryType DeploymentBoundaryType;

	private readonly Dictionary<string, List<GameEntity>>[] boundaryMarkersPerSide = new Dictionary<string, List<GameEntity>>[2];

	private readonly IEntityFactory entityFactory;

	private bool _boundaryMarkersRemoved = true;

	public MissionDeploymentBoundaryMarker(IEntityFactory entityFactory, MissionDeploymentBoundaryType deploymentBoundaryType, float markerInterval = 2f)
	{
		this.entityFactory = entityFactory;
		MarkerInterval = Math.Max(markerInterval, 0.0001f);
		DeploymentBoundaryType = deploymentBoundaryType;
	}

	public override void AfterStart()
	{
		base.AfterStart();
		AddBoundaryMarkers();
	}

	protected override void OnEndMission()
	{
		base.OnEndMission();
		TryRemoveBoundaryMarkers();
	}

	private BattleSideEnum GetBattleSideFromStaticBoundaryName(string boundaryName)
	{
		if (boundaryName.Contains("deployment_castle_boundary"))
		{
			return BattleSideEnum.Defender;
		}
		if (boundaryName.Contains("walk_area"))
		{
			return BattleSideEnum.Attacker;
		}
		Debug.FailedAssert("Unknown static boundary type " + boundaryName + ". Refer to scene artist.", "C:\\Develop\\MB3\\Source\\Bannerlord\\TaleWorlds.MountAndBlade.View\\MissionViews\\Singleplayer\\MissionDeploymentBoundaryMarker.cs", "GetBattleSideFromStaticBoundaryName", 65);
		return BattleSideEnum.Attacker;
	}

	public override void OnInitialDeploymentPlanMadeForSide(BattleSideEnum side, bool isFirstPlan)
	{
		bool flag = base.Mission.DeploymentPlan.HasDeploymentBoundaries(side, DeploymentPlanType.Initial);
		if (!(DeploymentBoundaryType == MissionDeploymentBoundaryType.DynamicDeploymentBoundaries && isFirstPlan && flag))
		{
			return;
		}
		foreach (KeyValuePair<string, List<Vec2>> deploymentBoundary in base.Mission.DeploymentPlan.GetDeploymentBoundaries(side, DeploymentPlanType.Initial))
		{
			AddBoundaryMarkerForSide(side, new KeyValuePair<string, ICollection<Vec2>>(deploymentBoundary.Key, deploymentBoundary.Value));
		}
	}

	public override void OnRemoveBehavior()
	{
		TryRemoveBoundaryMarkers();
		base.OnRemoveBehavior();
	}

	private void AddBoundaryMarkers()
	{
		for (int i = 0; i < 2; i++)
		{
			boundaryMarkersPerSide[i] = new Dictionary<string, List<GameEntity>>();
		}
		if (DeploymentBoundaryType == MissionDeploymentBoundaryType.StaticSceneBoundaries)
		{
			foreach (KeyValuePair<string, ICollection<Vec2>> boundary in base.Mission.Boundaries)
			{
				BattleSideEnum battleSideFromStaticBoundaryName = GetBattleSideFromStaticBoundaryName(boundary.Key);
				AddBoundaryMarkerForSide(battleSideFromStaticBoundaryName, boundary);
			}
			base.Mission.Boundaries.CollectionChanged += MissionStaticBoundaries_Changed;
		}
		_boundaryMarkersRemoved = false;
	}

	private void AddBoundaryMarkerForSide(BattleSideEnum side, KeyValuePair<string, ICollection<Vec2>> boundary)
	{
		string key = boundary.Key;
		if (!boundaryMarkersPerSide[(int)side].ContainsKey(key))
		{
			Banner banner = side switch
			{
				BattleSideEnum.Defender => base.Mission.DefenderTeam.Banner, 
				BattleSideEnum.Attacker => base.Mission.AttackerTeam.Banner, 
				_ => null, 
			};
			List<GameEntity> list = new List<GameEntity>();
			List<Vec2> list2 = boundary.Value.ToList();
			for (int i = 0; i < list2.Count; i++)
			{
				MarkLine(new Vec3(list2[i]), new Vec3(list2[(i + 1) % list2.Count]), list, banner);
			}
			boundaryMarkersPerSide[(int)side][key] = list;
		}
	}

	private void TryRemoveBoundaryMarkers()
	{
		if (_boundaryMarkersRemoved)
		{
			return;
		}
		if (DeploymentBoundaryType == MissionDeploymentBoundaryType.StaticSceneBoundaries)
		{
			base.Mission.Boundaries.CollectionChanged -= MissionStaticBoundaries_Changed;
		}
		for (int i = 0; i < 2; i++)
		{
			foreach (string item in boundaryMarkersPerSide[i].Keys.ToList())
			{
				RemoveBoundaryMarker(item, (BattleSideEnum)i);
			}
		}
		_boundaryMarkersRemoved = true;
	}

	private void RemoveBoundaryMarker(string boundaryName, BattleSideEnum side)
	{
		if (!boundaryMarkersPerSide[(int)side].TryGetValue(boundaryName, out var value))
		{
			return;
		}
		foreach (GameEntity item in value)
		{
			item.Remove(103);
		}
		boundaryMarkersPerSide[(int)side].Remove(boundaryName);
	}

	private void MissionStaticBoundaries_Changed(object sender, NotifyCollectionChangedEventArgs e)
	{
		switch (e.Action)
		{
		case NotifyCollectionChangedAction.Add:
		{
			foreach (object newItem in e.NewItems)
			{
				string text = newItem.ToString();
				KeyValuePair<string, ICollection<Vec2>> boundary = new KeyValuePair<string, ICollection<Vec2>>(text, base.Mission.Boundaries[text]);
				BattleSideEnum battleSideFromStaticBoundaryName2 = GetBattleSideFromStaticBoundaryName(text);
				AddBoundaryMarkerForSide(battleSideFromStaticBoundaryName2, boundary);
			}
			break;
		}
		case NotifyCollectionChangedAction.Remove:
		{
			foreach (object oldItem in e.OldItems)
			{
				string boundaryName = oldItem.ToString();
				BattleSideEnum battleSideFromStaticBoundaryName = GetBattleSideFromStaticBoundaryName(boundaryName);
				RemoveBoundaryMarker(boundaryName, battleSideFromStaticBoundaryName);
			}
			break;
		}
		default:
			Debug.FailedAssert("Invalid state", "C:\\Develop\\MB3\\Source\\Bannerlord\\TaleWorlds.MountAndBlade.View\\MissionViews\\Singleplayer\\MissionDeploymentBoundaryMarker.cs", "MissionStaticBoundaries_Changed", 197);
			break;
		}
	}

	protected void MarkLine(Vec3 startPoint, Vec3 endPoint, List<GameEntity> boundary, Banner banner = null)
	{
		Scene scene = base.Mission.Scene;
		Vec3 vec = endPoint - startPoint;
		float length = vec.Length;
		Vec3 vec2 = vec;
		vec2.Normalize();
		vec2 *= MarkerInterval;
		for (float num = 0f; num < length; num += MarkerInterval)
		{
			MatrixFrame frame = MatrixFrame.Identity;
			frame.rotation.RotateAboutUp(vec.RotationZ + (float)Math.PI / 2f);
			frame.origin = startPoint;
			if (!scene.GetHeightAtPoint(frame.origin.AsVec2, BodyFlags.CommonCollisionExcludeFlagsForCombat, ref frame.origin.z))
			{
				frame.origin.z = 0f;
			}
			frame.origin.z -= 0.5f;
			frame.Scale(Vec3.One * 0.4f);
			GameEntity gameEntity = entityFactory.MakeEntity(banner);
			gameEntity.SetFrame(ref frame);
			boundary.Add(gameEntity);
			startPoint += vec2;
		}
	}
}
