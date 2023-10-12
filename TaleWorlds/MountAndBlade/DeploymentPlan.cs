using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class DeploymentPlan
{
	public const float VerticalFormationGap = 3f;

	public const float HorizontalFormationGap = 2f;

	public const float DeployZoneMinimumWidth = 100f;

	public const float DeployZoneForwardMargin = 10f;

	public const float DeployZoneExtraWidthPerTroop = 1.5f;

	public const float MaxSafetyScore = 100f;

	public readonly BattleSideEnum Side;

	public readonly DeploymentPlanType Type;

	public readonly SpawnPathData SpawnPathData;

	private readonly Mission _mission;

	private int _planCount;

	private bool _spawnWithHorses;

	private readonly int[] _formationMountedTroopCounts;

	private readonly int[] _formationFootTroopCounts;

	private readonly FormationDeploymentPlan[] _formationPlans;

	private MatrixFrame _deploymentFrame;

	private float _deploymentWidth;

	private readonly Dictionary<string, List<Vec2>> _deploymentBoundaries;

	private readonly SortedList<FormationDeploymentOrder, FormationDeploymentPlan>[] _deploymentFlanks = new SortedList<FormationDeploymentOrder, FormationDeploymentPlan>[4];

	public bool SpawnWithHorses => _spawnWithHorses;

	public int PlanCount => _planCount;

	public bool IsPlanMade { get; private set; }

	public float SpawnPathOffset { get; private set; }

	public bool HasDeploymentBoundaries { get; private set; }

	public bool IsSafeToDeploy => SafetyScore >= 50f;

	public float SafetyScore { get; private set; }

	public int FootTroopCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 11; i++)
			{
				num += _formationFootTroopCounts[i];
			}
			return num;
		}
	}

	public int MountedTroopCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 11; i++)
			{
				num += _formationMountedTroopCounts[i];
			}
			return num;
		}
	}

	public int TroopCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 11; i++)
			{
				num += _formationFootTroopCounts[i] + _formationMountedTroopCounts[i];
			}
			return num;
		}
	}

	public MatrixFrame DeploymentFrame => _deploymentFrame;

	public float DeploymentWidth => _deploymentWidth;

	public MBReadOnlyDictionary<string, List<Vec2>> DeploymentBoundaries => _deploymentBoundaries.GetReadOnlyDictionary();

	public static DeploymentPlan CreateInitialPlan(Mission mission, BattleSideEnum side)
	{
		return new DeploymentPlan(mission, side, DeploymentPlanType.Initial, SpawnPathData.Invalid);
	}

	public static DeploymentPlan CreateReinforcementPlan(Mission mission, BattleSideEnum side)
	{
		return new DeploymentPlan(mission, side, DeploymentPlanType.Reinforcement, SpawnPathData.Invalid);
	}

	public static DeploymentPlan CreateReinforcementPlanWithSpawnPath(Mission mission, BattleSideEnum side, SpawnPathData spawnPathData)
	{
		return new DeploymentPlan(mission, side, DeploymentPlanType.Reinforcement, spawnPathData);
	}

	private DeploymentPlan(Mission mission, BattleSideEnum side, DeploymentPlanType type, SpawnPathData spawnPathData)
	{
		_mission = mission;
		_planCount = 0;
		Side = side;
		Type = type;
		SpawnPathData = spawnPathData;
		_formationPlans = new FormationDeploymentPlan[11];
		_formationFootTroopCounts = new int[11];
		_formationMountedTroopCounts = new int[11];
		_deploymentFrame = MatrixFrame.Identity;
		_deploymentWidth = 0f;
		_deploymentBoundaries = new Dictionary<string, List<Vec2>>();
		IsPlanMade = false;
		SpawnPathOffset = 0f;
		SafetyScore = 100f;
		for (int i = 0; i < _formationPlans.Length; i++)
		{
			FormationClass fClass = (FormationClass)i;
			_formationPlans[i] = new FormationDeploymentPlan(fClass);
		}
		for (int j = 0; j < 4; j++)
		{
			_deploymentFlanks[j] = new SortedList<FormationDeploymentOrder, FormationDeploymentPlan>(FormationDeploymentOrder.GetComparer());
		}
		ClearAddedTroops();
		ClearPlan();
	}

	public void SetSpawnWithHorses(bool value)
	{
		_spawnWithHorses = value;
	}

	public void ClearAddedTroops()
	{
		for (int i = 0; i < 11; i++)
		{
			_formationFootTroopCounts[i] = 0;
			_formationMountedTroopCounts[i] = 0;
		}
	}

	public void ClearPlan()
	{
		FormationDeploymentPlan[] formationPlans = _formationPlans;
		for (int i = 0; i < formationPlans.Length; i++)
		{
			formationPlans[i].Clear();
		}
		SortedList<FormationDeploymentOrder, FormationDeploymentPlan>[] deploymentFlanks = _deploymentFlanks;
		for (int i = 0; i < deploymentFlanks.Length; i++)
		{
			deploymentFlanks[i].Clear();
		}
		IsPlanMade = false;
		_deploymentBoundaries.Clear();
		HasDeploymentBoundaries = false;
	}

	public void AddTroops(FormationClass formationClass, int footTroopCount, int mountedTroopCount)
	{
		if (footTroopCount + mountedTroopCount > 0 && formationClass < (FormationClass)11)
		{
			_formationFootTroopCounts[(int)formationClass] += footTroopCount;
			_formationMountedTroopCounts[(int)formationClass] += mountedTroopCount;
		}
	}

	public void PlanBattleDeployment(FormationSceneSpawnEntry[,] formationSceneSpawnEntries, float spawnPathOffset = 0f)
	{
		SpawnPathOffset = spawnPathOffset;
		bool hasSpawnPath = _mission.HasSpawnPath;
		bool isFieldBattle = _mission.IsFieldBattle;
		PlanFormationDimensions();
		if (hasSpawnPath)
		{
			PlanFieldBattleDeploymentFromSpawnPath(spawnPathOffset);
		}
		else if (isFieldBattle)
		{
			PlanFieldBattleDeploymentFromSceneData(formationSceneSpawnEntries);
		}
		else
		{
			PlanBattleDeploymentFromSceneData(formationSceneSpawnEntries);
		}
		if (hasSpawnPath || isFieldBattle)
		{
			PlanDeploymentZone();
			return;
		}
		GetFormationDeploymentFrame(FormationClass.Infantry, out _deploymentFrame);
		_deploymentWidth = 0f;
		_deploymentBoundaries.Clear();
		HasDeploymentBoundaries = false;
	}

	public FormationDeploymentPlan GetFormationPlan(FormationClass fClass)
	{
		return _formationPlans[(int)fClass];
	}

	public bool GetFormationDeploymentFrame(FormationClass fClass, out MatrixFrame frame)
	{
		FormationDeploymentPlan formationPlan = GetFormationPlan(fClass);
		if (formationPlan.HasFrame())
		{
			frame = formationPlan.GetGroundFrame();
			return true;
		}
		frame = MatrixFrame.Identity;
		return false;
	}

	public bool IsPositionInsideDeploymentBoundaries(in Vec2 position)
	{
		bool result = false;
		foreach (KeyValuePair<string, List<Vec2>> deploymentBoundary in _deploymentBoundaries)
		{
			List<Vec2> value = deploymentBoundary.Value;
			if (MBSceneUtilities.IsPointInsideBoundaries(in position, value))
			{
				return true;
			}
		}
		return result;
	}

	public bool IsPlanSuitableForFormations((int, int)[] troopDataPerFormationClass)
	{
		if (troopDataPerFormationClass.Length == 11)
		{
			for (int i = 0; i < 11; i++)
			{
				FormationClass fClass = (FormationClass)i;
				FormationDeploymentPlan formationPlan = GetFormationPlan(fClass);
				(int, int) tuple = troopDataPerFormationClass[i];
				if (formationPlan.PlannedFootTroopCount != tuple.Item1 || formationPlan.PlannedMountedTroopCount != tuple.Item2)
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	public Vec2 GetClosestBoundaryPosition(in Vec2 position)
	{
		Vec2 result = position;
		float num = float.MaxValue;
		foreach (KeyValuePair<string, List<Vec2>> deploymentBoundary in _deploymentBoundaries)
		{
			List<Vec2> value = deploymentBoundary.Value;
			if (value.Count > 2)
			{
				Vec2 closestPoint;
				float num2 = MBSceneUtilities.FindClosestPointToBoundaries(in position, value, out closestPoint);
				if (num2 < num)
				{
					num = num2;
					result = closestPoint;
				}
			}
		}
		return result;
	}

	public void UpdateSafetyScore()
	{
		if (_mission.Teams == null)
		{
			return;
		}
		float num = 100f;
		Vec2 asVec = _deploymentFrame.origin.AsVec2;
		Team team = ((Side == BattleSideEnum.Attacker) ? _mission.Teams.Defender : ((Side == BattleSideEnum.Defender) ? _mission.Teams.Attacker : null));
		if (team != null)
		{
			foreach (Formation item in team.FormationsIncludingEmpty)
			{
				if (item.CountOfUnits > 0)
				{
					float num2 = asVec.Distance(item.QuerySystem.AveragePosition);
					if (num >= num2)
					{
						num = num2;
					}
				}
			}
		}
		team = ((Side == BattleSideEnum.Attacker) ? _mission.Teams.DefenderAlly : ((Side == BattleSideEnum.Defender) ? _mission.Teams.AttackerAlly : null));
		if (team != null)
		{
			foreach (Formation item2 in team.FormationsIncludingEmpty)
			{
				if (item2.CountOfUnits > 0)
				{
					float num3 = asVec.Distance(item2.QuerySystem.AveragePosition);
					if (num >= num3)
					{
						num = num3;
					}
				}
			}
		}
		SafetyScore = num;
	}

	public WorldFrame GetFrameFromFormationSpawnEntity(GameEntity formationSpawnEntity, float depthOffset = 0f)
	{
		MatrixFrame globalFrame = formationSpawnEntity.GetGlobalFrame();
		globalFrame.rotation.OrthonormalizeAccordingToForwardAndKeepUpAsZAxis();
		WorldPosition worldPosition = new WorldPosition(_mission.Scene, UIntPtr.Zero, globalFrame.origin, hasValidZ: false);
		WorldPosition origin = worldPosition;
		if (depthOffset != 0f)
		{
			origin.SetVec2(origin.AsVec2 - depthOffset * globalFrame.rotation.f.AsVec2);
			if (!origin.IsValid || origin.GetNavMesh() == UIntPtr.Zero)
			{
				origin = worldPosition;
			}
		}
		return new WorldFrame(globalFrame.rotation, origin);
	}

	public (float, float) GetFormationSpawnWidthAndDepth(FormationClass formationNo, int troopCount, bool hasMountedTroops, bool considerCavalryAsInfantry = false)
	{
		bool flag = !considerCavalryAsInfantry && hasMountedTroops;
		float defaultUnitDiameter = Formation.GetDefaultUnitDiameter(flag);
		int unitSpacingOf = ArrangementOrder.GetUnitSpacingOf(ArrangementOrder.ArrangementOrderEnum.Line);
		float num = (flag ? Formation.CavalryInterval(unitSpacingOf) : Formation.InfantryInterval(unitSpacingOf));
		float num2 = (flag ? Formation.CavalryDistance(unitSpacingOf) : Formation.InfantryDistance(unitSpacingOf));
		float num3 = (float)TaleWorlds.Library.MathF.Max(0, troopCount - 1) * (num + defaultUnitDiameter) + defaultUnitDiameter;
		float num4 = (flag ? 18f : 9f);
		int b = (int)(num3 / TaleWorlds.Library.MathF.Sqrt(num4 * (float)troopCount + 1f));
		b = TaleWorlds.Library.MathF.Max(1, b);
		float num5 = (float)troopCount / (float)b;
		float item = TaleWorlds.Library.MathF.Max(0f, num5 - 1f) * (num + defaultUnitDiameter) + defaultUnitDiameter;
		float item2 = (float)(b - 1) * (num2 + defaultUnitDiameter) + defaultUnitDiameter;
		return (item, item2);
	}

	private void PlanFieldBattleDeploymentFromSpawnPath(float pathOffset = 0f)
	{
		for (int i = 0; i < _formationPlans.Length; i++)
		{
			int num = _formationFootTroopCounts[i] + _formationMountedTroopCounts[i];
			FormationDeploymentPlan formationDeploymentPlan = _formationPlans[i];
			FormationDeploymentFlank defaultFlank = formationDeploymentPlan.GetDefaultFlank(_spawnWithHorses, num, FootTroopCount);
			FormationClass formationClass = (FormationClass)i;
			int offset = ((num <= 0 && formationClass != FormationClass.NumberOfRegularFormations) ? 1 : 0);
			FormationDeploymentOrder flankDeploymentOrder = formationDeploymentPlan.GetFlankDeploymentOrder(offset);
			_deploymentFlanks[(int)defaultFlank].Add(flankDeploymentOrder, formationDeploymentPlan);
		}
		float horizontalCenterOffset = ComputeHorizontalCenterOffset();
		((Type != 0) ? SpawnPathData : _mission.GetInitialSpawnPathDataOfSide(Side)).GetOrientedSpawnPathPosition(out var spawnPathPosition, out var spawnPathDirection, pathOffset);
		DeployFlanks(spawnPathPosition, spawnPathDirection, horizontalCenterOffset);
		SortedList<FormationDeploymentOrder, FormationDeploymentPlan>[] deploymentFlanks = _deploymentFlanks;
		for (int j = 0; j < deploymentFlanks.Length; j++)
		{
			deploymentFlanks[j].Clear();
		}
		IsPlanMade = true;
		_planCount++;
	}

	private void PlanFieldBattleDeploymentFromSceneData(FormationSceneSpawnEntry[,] formationSceneSpawnEntries)
	{
		if (formationSceneSpawnEntries == null || formationSceneSpawnEntries.GetLength(0) != 2 || formationSceneSpawnEntries.GetLength(1) != _formationPlans.Length)
		{
			return;
		}
		int side = (int)Side;
		int num = ((Side != BattleSideEnum.Attacker) ? 1 : 0);
		Dictionary<GameEntity, float> spawnDepths = new Dictionary<GameEntity, float>();
		bool flag = Type == DeploymentPlanType.Initial;
		for (int i = 0; i < _formationPlans.Length; i++)
		{
			FormationDeploymentPlan formationDeploymentPlan = _formationPlans[i];
			FormationSceneSpawnEntry formationSceneSpawnEntry = formationSceneSpawnEntries[side, i];
			FormationSceneSpawnEntry formationSceneSpawnEntry2 = formationSceneSpawnEntries[num, i];
			GameEntity gameEntity = (flag ? formationSceneSpawnEntry.SpawnEntity : formationSceneSpawnEntry.ReinforcementSpawnEntity);
			GameEntity gameEntity2 = (flag ? formationSceneSpawnEntry2.SpawnEntity : formationSceneSpawnEntry2.ReinforcementSpawnEntity);
			if (gameEntity != null && gameEntity2 != null)
			{
				WorldFrame frame = ComputeFieldBattleDeploymentFrameForFormation(formationDeploymentPlan, gameEntity, gameEntity2, ref spawnDepths);
				formationDeploymentPlan.SetFrame(frame);
			}
			else
			{
				formationDeploymentPlan.SetFrame(WorldFrame.Invalid);
			}
			formationDeploymentPlan.SetSpawnClass(formationSceneSpawnEntry.FormationClass);
		}
		IsPlanMade = true;
		_planCount++;
	}

	private void PlanBattleDeploymentFromSceneData(FormationSceneSpawnEntry[,] formationSceneSpawnEntries)
	{
		if (formationSceneSpawnEntries == null || formationSceneSpawnEntries.GetLength(0) != 2 || formationSceneSpawnEntries.GetLength(1) != _formationPlans.Length)
		{
			return;
		}
		int side = (int)Side;
		Dictionary<GameEntity, float> spawnDepths = new Dictionary<GameEntity, float>();
		bool flag = Type == DeploymentPlanType.Initial;
		for (int i = 0; i < _formationPlans.Length; i++)
		{
			FormationDeploymentPlan formationDeploymentPlan = _formationPlans[i];
			FormationSceneSpawnEntry formationSceneSpawnEntry = formationSceneSpawnEntries[side, i];
			GameEntity gameEntity = (flag ? formationSceneSpawnEntry.SpawnEntity : formationSceneSpawnEntry.ReinforcementSpawnEntity);
			if (gameEntity != null)
			{
				float andUpdateSpawnDepth = GetAndUpdateSpawnDepth(ref spawnDepths, gameEntity, formationDeploymentPlan);
				formationDeploymentPlan.SetFrame(GetFrameFromFormationSpawnEntity(gameEntity, andUpdateSpawnDepth));
			}
			else
			{
				formationDeploymentPlan.SetFrame(WorldFrame.Invalid);
			}
			formationDeploymentPlan.SetSpawnClass(formationSceneSpawnEntry.FormationClass);
		}
		IsPlanMade = true;
		_planCount++;
	}

	private void PlanFormationDimensions()
	{
		for (int i = 0; i < _formationPlans.Length; i++)
		{
			int num = _formationFootTroopCounts[i];
			int num2 = _formationMountedTroopCounts[i];
			int num3 = num + num2;
			if (num3 > 0)
			{
				FormationDeploymentPlan formationDeploymentPlan = _formationPlans[i];
				bool hasMountedTroops = MissionDeploymentPlan.HasSignificantMountedTroops(num, num2);
				var (width, depth) = GetFormationSpawnWidthAndDepth(formationDeploymentPlan.Class, num3, hasMountedTroops, !_spawnWithHorses);
				formationDeploymentPlan.SetPlannedDimensions(width, depth);
				formationDeploymentPlan.SetPlannedTroopCount(num, num2);
			}
		}
	}

	private void PlanDeploymentZone()
	{
		GetFormationDeploymentFrame(FormationClass.Infantry, out _deploymentFrame);
		float num = 0f;
		float num2 = 0f;
		for (int i = 0; i < 10; i++)
		{
			FormationClass fClass = (FormationClass)i;
			FormationDeploymentPlan formationPlan = GetFormationPlan(fClass);
			if (formationPlan.HasFrame())
			{
				MatrixFrame matrixFrame = _deploymentFrame.TransformToLocal(formationPlan.GetGroundFrame());
				num = Math.Max(matrixFrame.origin.y, num);
				num2 = Math.Max(Math.Abs(matrixFrame.origin.x), num2);
			}
		}
		num += 10f;
		_deploymentFrame.Advance(num);
		_deploymentBoundaries.Clear();
		float val = 2f * num2 + 1.5f * (float)TroopCount;
		_deploymentWidth = Math.Max(val, 100f);
		foreach (KeyValuePair<string, ICollection<Vec2>> boundary in _mission.Boundaries)
		{
			string key = boundary.Key;
			ICollection<Vec2> value = boundary.Value;
			List<Vec2> value2 = ComputeDeploymentBoundariesFromMissionBoundaries(value);
			_deploymentBoundaries.Add(key, value2);
		}
		HasDeploymentBoundaries = true;
	}

	private void DeployFlanks(Vec2 deployPosition, Vec2 deployDirection, float horizontalCenterOffset)
	{
		(float flankWidth, float flankDepth) tuple = PlanFlankDeployment(FormationDeploymentFlank.Front, deployPosition, deployDirection, 0f, horizontalCenterOffset);
		float item = tuple.flankWidth;
		float item2 = tuple.flankDepth;
		item2 += 3f;
		float item3 = PlanFlankDeployment(FormationDeploymentFlank.Rear, deployPosition, deployDirection, item2, horizontalCenterOffset).flankWidth;
		float num = TaleWorlds.Library.MathF.Max(item, item3);
		float num2 = ComputeFlankDepth(FormationDeploymentFlank.Front, countPositiveNumTroops: true);
		num2 += 3f;
		float num3 = ComputeFlankWidth(FormationDeploymentFlank.Left);
		float horizontalOffset = horizontalCenterOffset + 2f + 0.5f * (num + num3);
		PlanFlankDeployment(FormationDeploymentFlank.Left, deployPosition, deployDirection, num2, horizontalOffset);
		float num4 = ComputeFlankWidth(FormationDeploymentFlank.Right);
		float horizontalOffset2 = horizontalCenterOffset - (2f + 0.5f * (num + num4));
		PlanFlankDeployment(FormationDeploymentFlank.Right, deployPosition, deployDirection, num2, horizontalOffset2);
	}

	private (float flankWidth, float flankDepth) PlanFlankDeployment(FormationDeploymentFlank flankFlank, Vec2 deployPosition, Vec2 deployDirection, float verticalOffset = 0f, float horizontalOffset = 0f)
	{
		Mat3 identity = Mat3.Identity;
		identity.RotateAboutUp(deployDirection.RotationInRadians);
		float num = 0f;
		float num2 = 0f;
		Vec2 vec = deployDirection.LeftVec();
		WorldPosition position = new WorldPosition(_mission.Scene, UIntPtr.Zero, deployPosition.ToVec3(), hasValidZ: false);
		foreach (KeyValuePair<FormationDeploymentOrder, FormationDeploymentPlan> item in _deploymentFlanks[(int)flankFlank])
		{
			FormationDeploymentPlan value = item.Value;
			Vec2 destination = position.AsVec2 - (num2 + verticalOffset) * deployDirection + horizontalOffset * vec;
			Vec3 lastPointOnNavigationMeshFromWorldPositionToDestination = _mission.Scene.GetLastPointOnNavigationMeshFromWorldPositionToDestination(ref position, destination);
			WorldFrame frame = new WorldFrame(origin: new WorldPosition(_mission.Scene, UIntPtr.Zero, lastPointOnNavigationMeshFromWorldPositionToDestination, hasValidZ: false), rotation: identity);
			value.SetFrame(frame);
			float num3 = value.PlannedDepth + 3f;
			num2 += num3;
			num = TaleWorlds.Library.MathF.Max(num, value.PlannedWidth);
		}
		num2 = TaleWorlds.Library.MathF.Max(num2 - 3f, 0f);
		return (num, num2);
	}

	private WorldFrame ComputeFieldBattleDeploymentFrameForFormation(FormationDeploymentPlan formationPlan, GameEntity formationSceneEntity, GameEntity counterSideFormationSceneEntity, ref Dictionary<GameEntity, float> spawnDepths)
	{
		Vec3 globalPosition = formationSceneEntity.GlobalPosition;
		Vec2 asVec = (counterSideFormationSceneEntity.GlobalPosition - globalPosition).AsVec2;
		asVec.Normalize();
		float andUpdateSpawnDepth = GetAndUpdateSpawnDepth(ref spawnDepths, formationSceneEntity, formationPlan);
		WorldPosition origin = new WorldPosition(_mission.Scene, UIntPtr.Zero, globalPosition, hasValidZ: false);
		origin.SetVec2(origin.AsVec2 - andUpdateSpawnDepth * asVec);
		Mat3 identity = Mat3.Identity;
		identity.RotateAboutUp(asVec.RotationInRadians);
		return new WorldFrame(identity, origin);
	}

	private float ComputeFlankWidth(FormationDeploymentFlank flank)
	{
		float num = 0f;
		foreach (KeyValuePair<FormationDeploymentOrder, FormationDeploymentPlan> item in _deploymentFlanks[(int)flank])
		{
			num = TaleWorlds.Library.MathF.Max(num, item.Value.PlannedWidth);
		}
		return num;
	}

	private float ComputeFlankDepth(FormationDeploymentFlank flank, bool countPositiveNumTroops = false)
	{
		float num = 0f;
		foreach (KeyValuePair<FormationDeploymentOrder, FormationDeploymentPlan> item in _deploymentFlanks[(int)flank])
		{
			if (!countPositiveNumTroops)
			{
				num += item.Value.PlannedDepth + 3f;
			}
			else if (item.Value.PlannedTroopCount > 0)
			{
				num += item.Value.PlannedDepth + 3f;
			}
		}
		return num - 3f;
	}

	private float ComputeHorizontalCenterOffset()
	{
		float num = TaleWorlds.Library.MathF.Max(ComputeFlankWidth(FormationDeploymentFlank.Front), ComputeFlankWidth(FormationDeploymentFlank.Rear));
		float num2 = ComputeFlankWidth(FormationDeploymentFlank.Left);
		float num3 = ComputeFlankWidth(FormationDeploymentFlank.Right);
		float num4 = num / 2f + num2 + 2f;
		return (num / 2f + num3 + 2f - num4) / 2f;
	}

	private float GetAndUpdateSpawnDepth(ref Dictionary<GameEntity, float> spawnDepths, GameEntity spawnEntity, FormationDeploymentPlan formationPlan)
	{
		float value;
		bool num = spawnDepths.TryGetValue(spawnEntity, out value);
		float num2 = (formationPlan.HasDimensions ? (formationPlan.PlannedDepth + 3f) : 0f);
		if (!num)
		{
			value = 0f;
			spawnDepths[spawnEntity] = num2;
		}
		else if (formationPlan.HasDimensions)
		{
			spawnDepths[spawnEntity] = value + num2;
		}
		return value;
	}

	private List<Vec2> ComputeDeploymentBoundariesFromMissionBoundaries(ICollection<Vec2> missionBoundaries)
	{
		List<Vec2> boundaries = new List<Vec2>();
		float maxLength = _deploymentWidth / 2f;
		if (missionBoundaries.Count > 2)
		{
			Vec2 asVec = _deploymentFrame.origin.AsVec2;
			Vec2 vec = _deploymentFrame.rotation.s.AsVec2.Normalized();
			Vec2 vec2 = _deploymentFrame.rotation.f.AsVec2.Normalized();
			List<Vec2> boundaries2 = missionBoundaries.ToList();
			List<(Vec2, Vec2)> list = new List<(Vec2, Vec2)>();
			Vec2 vec3 = ClampRayToMissionBoundaries(boundaries2, asVec, vec, maxLength);
			AddDeploymentBoundaryPoint(boundaries, vec3);
			Vec2 vec4 = ClampRayToMissionBoundaries(boundaries2, asVec, -vec, maxLength);
			AddDeploymentBoundaryPoint(boundaries, vec4);
			if (MBMath.IntersectRayWithBoundaryList(vec3, -vec2, boundaries2, out var intersectionPoint) && (intersectionPoint - vec3).Length > 0.1f)
			{
				list.Add((intersectionPoint, vec3));
				AddDeploymentBoundaryPoint(boundaries, intersectionPoint);
			}
			list.Add((vec3, vec4));
			if (MBMath.IntersectRayWithBoundaryList(vec4, -vec2, boundaries2, out var intersectionPoint2) && (intersectionPoint2 - vec4).Length > 0.1f)
			{
				list.Add((vec4, intersectionPoint2));
				AddDeploymentBoundaryPoint(boundaries, intersectionPoint2);
			}
			foreach (Vec2 missionBoundary in missionBoundaries)
			{
				bool flag = true;
				foreach (var item in list)
				{
					Vec2 vec5 = missionBoundary - item.Item1;
					Vec2 vec6 = item.Item2 - item.Item1;
					if (vec6.x * vec5.y - vec6.y * vec5.x <= 0f)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					AddDeploymentBoundaryPoint(boundaries, missionBoundary);
				}
			}
			MBSceneUtilities.RadialSortBoundaries(ref boundaries);
		}
		return boundaries;
	}

	private void AddDeploymentBoundaryPoint(List<Vec2> deploymentBoundaries, Vec2 point)
	{
		if (!deploymentBoundaries.Exists((Vec2 boundaryPoint) => boundaryPoint.Distance(point) <= 0.1f))
		{
			deploymentBoundaries.Add(point);
		}
	}

	private Vec2 ClampRayToMissionBoundaries(List<Vec2> boundaries, Vec2 origin, Vec2 direction, float maxLength)
	{
		if (_mission.IsPositionInsideBoundaries(origin))
		{
			Vec2 vec = origin + direction * maxLength;
			if (_mission.IsPositionInsideBoundaries(vec))
			{
				return vec;
			}
		}
		if (MBMath.IntersectRayWithBoundaryList(origin, direction, boundaries, out var intersectionPoint))
		{
			return intersectionPoint;
		}
		return origin;
	}
}
