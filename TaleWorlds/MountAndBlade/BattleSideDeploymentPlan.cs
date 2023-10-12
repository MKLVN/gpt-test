using System.Collections.Generic;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class BattleSideDeploymentPlan
{
	public readonly BattleSideEnum Side;

	private readonly Mission _mission;

	private readonly DeploymentPlan _initialPlan;

	private bool _spawnWithHorses;

	private bool _reinforcementPlansCreated;

	private readonly List<DeploymentPlan> _reinforcementPlans;

	private DeploymentPlan _currentReinforcementPlan;

	public bool SpawnWithHorses => _spawnWithHorses;

	public BattleSideDeploymentPlan(Mission mission, BattleSideEnum side)
	{
		_mission = mission;
		Side = side;
		_spawnWithHorses = false;
		_initialPlan = DeploymentPlan.CreateInitialPlan(_mission, side);
		_reinforcementPlans = new List<DeploymentPlan>();
		_reinforcementPlansCreated = false;
		_currentReinforcementPlan = _initialPlan;
	}

	public void CreateReinforcementPlans()
	{
		if (_reinforcementPlansCreated)
		{
			return;
		}
		if (_mission.HasSpawnPath)
		{
			foreach (SpawnPathData item2 in _mission.GetReinforcementPathsDataOfSide(Side))
			{
				DeploymentPlan item = DeploymentPlan.CreateReinforcementPlanWithSpawnPath(_mission, Side, item2);
				_reinforcementPlans.Add(item);
			}
			_currentReinforcementPlan = _reinforcementPlans[0];
		}
		else
		{
			DeploymentPlan deploymentPlan = DeploymentPlan.CreateReinforcementPlan(_mission, Side);
			_reinforcementPlans.Add(deploymentPlan);
			_currentReinforcementPlan = deploymentPlan;
		}
		_reinforcementPlansCreated = true;
	}

	public void SetSpawnWithHorses(bool value)
	{
		_spawnWithHorses = value;
		_initialPlan.SetSpawnWithHorses(value);
		foreach (DeploymentPlan reinforcementPlan in _reinforcementPlans)
		{
			reinforcementPlan.SetSpawnWithHorses(value);
		}
	}

	public void PlanBattleDeployment(FormationSceneSpawnEntry[,] formationSceneSpawnEntries, DeploymentPlanType planType, float spawnPathOffset)
	{
		switch (planType)
		{
		case DeploymentPlanType.Initial:
			if (!_initialPlan.IsPlanMade)
			{
				_initialPlan.PlanBattleDeployment(formationSceneSpawnEntries, spawnPathOffset);
			}
			break;
		case DeploymentPlanType.Reinforcement:
		{
			foreach (DeploymentPlan reinforcementPlan in _reinforcementPlans)
			{
				if (!reinforcementPlan.IsPlanMade)
				{
					reinforcementPlan.PlanBattleDeployment(formationSceneSpawnEntries);
				}
			}
			break;
		}
		}
	}

	public void UpdateReinforcementPlans()
	{
		if (!_reinforcementPlansCreated || _reinforcementPlans.Count <= 1)
		{
			return;
		}
		foreach (DeploymentPlan reinforcementPlan in _reinforcementPlans)
		{
			reinforcementPlan.UpdateSafetyScore();
		}
		if (!_currentReinforcementPlan.IsSafeToDeploy)
		{
			_currentReinforcementPlan = _reinforcementPlans.MaxBy((DeploymentPlan plan) => plan.SafetyScore);
		}
	}

	public void ClearPlans(DeploymentPlanType planType)
	{
		switch (planType)
		{
		case DeploymentPlanType.Initial:
			_initialPlan.ClearPlan();
			break;
		case DeploymentPlanType.Reinforcement:
		{
			foreach (DeploymentPlan reinforcementPlan in _reinforcementPlans)
			{
				reinforcementPlan.ClearPlan();
			}
			break;
		}
		}
	}

	public void ClearAddedTroops(DeploymentPlanType planType)
	{
		if (planType == DeploymentPlanType.Initial)
		{
			_initialPlan.ClearAddedTroops();
			return;
		}
		foreach (DeploymentPlan reinforcementPlan in _reinforcementPlans)
		{
			reinforcementPlan.ClearAddedTroops();
		}
	}

	public void AddTroops(FormationClass formationClass, int footTroopCount, int mountedTroopCount, DeploymentPlanType planType)
	{
		if (planType == DeploymentPlanType.Initial)
		{
			_initialPlan.AddTroops(formationClass, footTroopCount, mountedTroopCount);
			return;
		}
		foreach (DeploymentPlan reinforcementPlan in _reinforcementPlans)
		{
			reinforcementPlan.AddTroops(formationClass, footTroopCount, mountedTroopCount);
		}
	}

	public bool IsFirstPlan(DeploymentPlanType planType)
	{
		if (planType == DeploymentPlanType.Initial)
		{
			return _initialPlan.PlanCount == 1;
		}
		if (_reinforcementPlansCreated)
		{
			return _currentReinforcementPlan.PlanCount == 1;
		}
		return false;
	}

	public bool IsPlanMade(DeploymentPlanType planType)
	{
		if (planType == DeploymentPlanType.Initial)
		{
			return _initialPlan.IsPlanMade;
		}
		if (_reinforcementPlansCreated)
		{
			return _currentReinforcementPlan.IsPlanMade;
		}
		return false;
	}

	public float GetSpawnPathOffset(DeploymentPlanType planType)
	{
		if (planType == DeploymentPlanType.Initial)
		{
			return _initialPlan.SpawnPathOffset;
		}
		if (!_reinforcementPlansCreated)
		{
			return 0f;
		}
		return _currentReinforcementPlan.SpawnPathOffset;
	}

	public int GetTroopCount(DeploymentPlanType planType)
	{
		if (planType == DeploymentPlanType.Initial)
		{
			return _initialPlan.TroopCount;
		}
		if (!_reinforcementPlansCreated)
		{
			return 0;
		}
		return _currentReinforcementPlan.TroopCount;
	}

	public MatrixFrame GetDeploymentFrame(DeploymentPlanType planType)
	{
		if (planType == DeploymentPlanType.Initial)
		{
			return _initialPlan.DeploymentFrame;
		}
		if (!_reinforcementPlansCreated)
		{
			return MatrixFrame.Identity;
		}
		return _currentReinforcementPlan.DeploymentFrame;
	}

	public MBReadOnlyDictionary<string, List<Vec2>> GetDeploymentBoundaries(DeploymentPlanType planType)
	{
		if (planType == DeploymentPlanType.Initial)
		{
			return _initialPlan.DeploymentBoundaries;
		}
		if (!_reinforcementPlansCreated)
		{
			return null;
		}
		return _currentReinforcementPlan.DeploymentBoundaries;
	}

	public float GetDeploymentWidth(DeploymentPlanType planType)
	{
		if (planType == DeploymentPlanType.Initial)
		{
			return _initialPlan.DeploymentWidth;
		}
		if (!_reinforcementPlansCreated)
		{
			return 0f;
		}
		return _currentReinforcementPlan.DeploymentWidth;
	}

	public bool HasDeploymentBoundaries(DeploymentPlanType planType)
	{
		if (planType == DeploymentPlanType.Initial)
		{
			return _initialPlan.HasDeploymentBoundaries;
		}
		if (_reinforcementPlansCreated)
		{
			return _currentReinforcementPlan.HasDeploymentBoundaries;
		}
		return false;
	}

	public IFormationDeploymentPlan GetFormationPlan(FormationClass fClass, DeploymentPlanType planType)
	{
		if (planType == DeploymentPlanType.Initial)
		{
			return _initialPlan.GetFormationPlan(fClass);
		}
		return _currentReinforcementPlan.GetFormationPlan(fClass);
	}

	public bool IsInitialPlanSuitableForFormations((int, int)[] troopDataPerFormationClass)
	{
		return _initialPlan.IsPlanSuitableForFormations(troopDataPerFormationClass);
	}

	public bool IsPositionInsideInitialDeploymentBoundaries(in Vec2 position)
	{
		return _initialPlan.IsPositionInsideDeploymentBoundaries(in position);
	}

	public Vec2 GetClosestInitialDeploymentBoundaryPosition(in Vec2 position)
	{
		return _initialPlan.GetClosestBoundaryPosition(in position);
	}
}
