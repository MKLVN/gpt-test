using System.Collections.Generic;
using System.Linq;
using SandBox.Conversation.MissionLogics;
using SandBox.Objects.AnimationPoints;
using SandBox.Objects.AreaMarkers;
using SandBox.Objects.Usables;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.MissionLogics;

public class HideoutMissionController : MissionLogic, IMissionAgentSpawnLogic, IMissionBehavior
{
	private class MissionSide
	{
		private readonly BattleSideEnum _side;

		private readonly IMissionTroopSupplier _troopSupplier;

		public readonly bool IsPlayerSide;

		private int _numberOfSpawnedTroops;

		public bool TroopSpawningActive { get; private set; }

		public int NumberOfActiveTroops => _numberOfSpawnedTroops - _troopSupplier.NumRemovedTroops;

		public int NumberOfTroopsNotSupplied => _troopSupplier.NumTroopsNotSupplied;

		public MissionSide(BattleSideEnum side, IMissionTroopSupplier troopSupplier, bool isPlayerSide)
		{
			_side = side;
			IsPlayerSide = isPlayerSide;
			_troopSupplier = troopSupplier;
		}

		public void SpawnTroops(List<CommonAreaMarker> areaMarkers, List<PatrolArea> patrolAreas, Dictionary<Agent, UsedObject> defenderAgentObjects, int spawnCount)
		{
			int num = 0;
			bool flag = false;
			List<StandingPoint> list = new List<StandingPoint>();
			foreach (CommonAreaMarker areaMarker in areaMarkers)
			{
				foreach (UsableMachine item in areaMarker.GetUsableMachinesInRange())
				{
					list.AddRange(item.StandingPoints);
				}
			}
			List<IAgentOriginBase> list2 = _troopSupplier.SupplyTroops(spawnCount).ToList();
			for (int i = 0; i < list2.Count; i++)
			{
				if (BattleSideEnum.Attacker == _side)
				{
					Mission.Current.SpawnTroop(list2[i], isPlayerSide: true, hasFormation: true, spawnWithHorse: false, isReinforcement: false, 0, 0, isAlarmed: true, wieldInitialWeapons: true, forceDismounted: true, null, null);
					_numberOfSpawnedTroops++;
				}
				else
				{
					if (areaMarkers.Count <= num)
					{
						continue;
					}
					StandingPoint standingPoint = null;
					int num2 = list2.Count - i;
					if (num2 < list.Count / 2 && num2 < 4)
					{
						flag = true;
					}
					if (!flag)
					{
						list.Shuffle();
						standingPoint = list.FirstOrDefault((StandingPoint point) => !point.IsDeactivated && !point.IsDisabled && !point.HasUser);
					}
					else
					{
						IEnumerable<PatrolArea> source = patrolAreas.Where((PatrolArea area) => area.StandingPoints.All((StandingPoint point) => !point.HasUser && !point.HasAIMovingTo));
						if (!source.IsEmpty())
						{
							standingPoint = source.First().StandingPoints[0];
						}
					}
					if (standingPoint != null && !standingPoint.IsDisabled)
					{
						MatrixFrame globalFrame = standingPoint.GameEntity.GetGlobalFrame();
						globalFrame.rotation.OrthonormalizeAccordingToForwardAndKeepUpAsZAxis();
						Agent agent = Mission.Current.SpawnTroop(list2[i], isPlayerSide: false, hasFormation: false, spawnWithHorse: false, isReinforcement: false, 0, 0, isAlarmed: false, wieldInitialWeapons: false, forceDismounted: false, globalFrame.origin, globalFrame.rotation.f.AsVec2.Normalized(), "_hideout_bandit");
						InitializeBanditAgent(agent, standingPoint, flag, defenderAgentObjects);
						_numberOfSpawnedTroops++;
						int groupId = ((AnimationPoint)standingPoint).GroupId;
						if (flag)
						{
							continue;
						}
						foreach (StandingPoint standingPoint2 in standingPoint.GameEntity.Parent.GetFirstScriptOfType<UsableMachine>().StandingPoints)
						{
							int groupId2 = ((AnimationPoint)standingPoint2).GroupId;
							if (groupId == groupId2 && standingPoint2 != standingPoint)
							{
								standingPoint2.SetDisabledAndMakeInvisible();
							}
						}
					}
					else
					{
						num++;
					}
				}
			}
			foreach (Formation item2 in Mission.Current.AttackerTeam.FormationsIncludingEmpty)
			{
				if (item2.CountOfUnits > 0)
				{
					item2.SetMovementOrder(MovementOrder.MovementOrderMove(item2.QuerySystem.MedianPosition));
				}
				item2.FiringOrder = FiringOrder.FiringOrderHoldYourFire;
				if (Mission.Current.AttackerTeam == Mission.Current.PlayerTeam)
				{
					item2.PlayerOwner = Mission.Current.MainAgent;
				}
			}
		}

		public void SpawnRemainingTroopsForBossFight(List<MatrixFrame> spawnFrames, int spawnCount)
		{
			List<IAgentOriginBase> list = _troopSupplier.SupplyTroops(spawnCount).ToList();
			for (int i = 0; i < list.Count; i++)
			{
				MatrixFrame matrixFrame = spawnFrames.FirstOrDefault();
				matrixFrame.rotation.OrthonormalizeAccordingToForwardAndKeepUpAsZAxis();
				Agent agent = Mission.Current.SpawnTroop(list[i], isPlayerSide: false, hasFormation: false, spawnWithHorse: false, isReinforcement: false, 0, 0, isAlarmed: false, wieldInitialWeapons: false, forceDismounted: false, matrixFrame.origin, matrixFrame.rotation.f.AsVec2.Normalized(), "_hideout_bandit");
				AgentFlag agentFlags = agent.GetAgentFlags();
				if (agentFlags.HasAnyFlag(AgentFlag.CanRetreat))
				{
					agent.SetAgentFlags(agentFlags & ~AgentFlag.CanRetreat);
				}
				_numberOfSpawnedTroops++;
			}
			foreach (Formation item in Mission.Current.AttackerTeam.FormationsIncludingEmpty)
			{
				if (item.CountOfUnits > 0)
				{
					item.SetMovementOrder(MovementOrder.MovementOrderMove(item.QuerySystem.MedianPosition));
				}
				item.FiringOrder = FiringOrder.FiringOrderHoldYourFire;
				if (Mission.Current.AttackerTeam == Mission.Current.PlayerTeam)
				{
					item.PlayerOwner = Mission.Current.MainAgent;
				}
			}
		}

		private void InitializeBanditAgent(Agent agent, StandingPoint spawnPoint, bool isPatrolling, Dictionary<Agent, UsedObject> defenderAgentObjects)
		{
			UsableMachine usableMachine = (isPatrolling ? spawnPoint.GameEntity.Parent.GetScriptComponents<PatrolArea>().FirstOrDefault() : spawnPoint.GameEntity.Parent.GetScriptComponents<UsableMachine>().FirstOrDefault());
			if (isPatrolling)
			{
				((IDetachment)usableMachine).AddAgent(agent, -1);
				agent.WieldInitialWeapons();
			}
			else
			{
				agent.UseGameObject(spawnPoint);
			}
			defenderAgentObjects.Add(agent, new UsedObject(usableMachine, isPatrolling));
			AgentFlag agentFlags = agent.GetAgentFlags();
			agent.SetAgentFlags((agentFlags | AgentFlag.CanGetAlarmed) & ~AgentFlag.CanRetreat);
			agent.GetComponent<CampaignAgentComponent>().CreateAgentNavigator();
			SimulateTick(agent);
		}

		private void SimulateTick(Agent agent)
		{
			int num = MBRandom.RandomInt(1, 20);
			for (int i = 0; i < num; i++)
			{
				if (agent.IsUsingGameObject)
				{
					agent.CurrentlyUsedGameObject.SimulateTick(0.1f);
				}
			}
		}

		public void SetSpawnTroops(bool spawnTroops)
		{
			TroopSpawningActive = spawnTroops;
		}
	}

	private class UsedObject
	{
		public readonly UsableMachine Machine;

		public readonly UsableMachineAIBase MachineAI;

		public bool IsMachineAITicked;

		public UsedObject(UsableMachine machine, bool isMachineAITicked)
		{
			Machine = machine;
			MachineAI = machine.CreateAIBehaviorObject();
			IsMachineAITicked = isMachineAITicked;
		}
	}

	private enum HideoutMissionState
	{
		NotDecided,
		WithoutBossFight,
		InitialFightBeforeBossFight,
		CutSceneBeforeBossFight,
		ConversationBetweenLeaders,
		BossFightWithDuel,
		BossFightWithAll
	}

	private const int FirstPhaseEndInSeconds = 4;

	private readonly List<CommonAreaMarker> _areaMarkers;

	private readonly List<PatrolArea> _patrolAreas;

	private readonly Dictionary<Agent, UsedObject> _defenderAgentObjects;

	private readonly MissionSide[] _missionSides;

	private List<Agent> _duelPhaseAllyAgents;

	private List<Agent> _duelPhaseBanditAgents;

	private BattleAgentLogic _battleAgentLogic;

	private BattleEndLogic _battleEndLogic;

	private AgentVictoryLogic _agentVictoryLogic;

	private HideoutCinematicController _cinematicController;

	private HideoutMissionState _hideoutMissionState;

	private Agent _bossAgent;

	private Team _enemyTeam;

	private Timer _firstPhaseEndTimer;

	private bool _troopsInitialized;

	private bool _isMissionInitialized;

	private bool _battleResolved;

	private int _firstPhaseEnemyTroopCount;

	private int _firstPhasePlayerSideTroopCount;

	private MissionMode _oldMissionMode;

	public HideoutMissionController(IMissionTroopSupplier[] suppliers, BattleSideEnum playerSide, int firstPhaseEnemyTroopCount, int firstPhasePlayerSideTroopCount)
	{
		_areaMarkers = new List<CommonAreaMarker>();
		_patrolAreas = new List<PatrolArea>();
		_defenderAgentObjects = new Dictionary<Agent, UsedObject>();
		_firstPhaseEnemyTroopCount = firstPhaseEnemyTroopCount;
		_firstPhasePlayerSideTroopCount = firstPhasePlayerSideTroopCount;
		_missionSides = new MissionSide[2];
		for (int i = 0; i < 2; i++)
		{
			IMissionTroopSupplier troopSupplier = suppliers[i];
			bool isPlayerSide = i == (int)playerSide;
			_missionSides[i] = new MissionSide((BattleSideEnum)i, troopSupplier, isPlayerSide);
		}
	}

	public override void OnCreated()
	{
		base.OnCreated();
		base.Mission.DoesMissionRequireCivilianEquipment = false;
	}

	public override void OnBehaviorInitialize()
	{
		base.OnBehaviorInitialize();
		_battleAgentLogic = base.Mission.GetMissionBehavior<BattleAgentLogic>();
		_battleEndLogic = base.Mission.GetMissionBehavior<BattleEndLogic>();
		_battleEndLogic.ChangeCanCheckForEndCondition(canCheckForEndCondition: false);
		_agentVictoryLogic = base.Mission.GetMissionBehavior<AgentVictoryLogic>();
		_cinematicController = base.Mission.GetMissionBehavior<HideoutCinematicController>();
		base.Mission.IsMainAgentObjectInteractionEnabled = false;
	}

	public override void OnObjectStoppedBeingUsed(Agent userAgent, UsableMissionObject usedObject)
	{
		if (usedObject != null && usedObject is AnimationPoint && userAgent.IsActive() && userAgent.IsAIControlled && userAgent.CurrentWatchState == Agent.WatchState.Patrolling)
		{
			((IDetachment)usedObject.GameEntity.Parent.GetFirstScriptOfType<PatrolArea>())?.AddAgent(userAgent, -1);
		}
	}

	public override void OnAgentAlarmedStateChanged(Agent agent, Agent.AIStateFlag flag)
	{
		bool num = flag == Agent.AIStateFlag.Alarmed;
		if (num || flag == Agent.AIStateFlag.Cautious)
		{
			if (agent.IsUsingGameObject)
			{
				agent.StopUsingGameObject();
			}
			else
			{
				agent.DisableScriptedMovement();
				if (agent.IsAIControlled && agent.AIMoveToGameObjectIsEnabled())
				{
					agent.AIMoveToGameObjectDisable();
					agent.Formation?.Team.DetachmentManager.RemoveScoresOfAgentFromDetachments(agent);
				}
			}
			_defenderAgentObjects[agent].IsMachineAITicked = false;
		}
		else if (flag == Agent.AIStateFlag.None)
		{
			_defenderAgentObjects[agent].IsMachineAITicked = true;
			agent.TryToSheathWeaponInHand(Agent.HandIndex.MainHand, Agent.WeaponWieldActionType.WithAnimation);
			((IDetachment)_defenderAgentObjects[agent].Machine).AddAgent(agent, -1);
		}
		if (num)
		{
			agent.SetWantsToYell();
		}
	}

	public override void OnMissionTick(float dt)
	{
		if (!_isMissionInitialized)
		{
			InitializeMission();
			_isMissionInitialized = true;
			return;
		}
		if (!_troopsInitialized)
		{
			_troopsInitialized = true;
			foreach (Agent agent in base.Mission.Agents)
			{
				_battleAgentLogic.OnAgentBuild(agent, null);
			}
		}
		UsedObjectTick(dt);
		if (!_battleResolved)
		{
			CheckBattleResolved();
		}
	}

	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		if (_hideoutMissionState == HideoutMissionState.BossFightWithDuel)
		{
			foreach (Agent agent in base.Mission.Agents)
			{
				if (agent != affectedAgent && agent != affectorAgent && agent.IsActive() && agent.GetLookAgent() == affectedAgent)
				{
					agent.SetLookAgent(null);
				}
			}
			return;
		}
		if (_hideoutMissionState == HideoutMissionState.InitialFightBeforeBossFight && affectedAgent.IsMainAgent)
		{
			base.Mission.PlayerTeam.PlayerOrderController.SelectAllFormations();
			affectedAgent.Formation = null;
			base.Mission.PlayerTeam.PlayerOrderController.SetOrder(OrderType.Retreat);
		}
	}

	private void InitializeMission()
	{
		base.Mission.GetMissionBehavior<MissionConversationLogic>().DisableStartConversation(isDisabled: true);
		base.Mission.SetMissionMode(MissionMode.Stealth, atStart: true);
		_areaMarkers.AddRange(from area in base.Mission.ActiveMissionObjects.FindAllWithType<CommonAreaMarker>()
			orderby area.AreaIndex
			select area);
		_patrolAreas.AddRange(from area in base.Mission.ActiveMissionObjects.FindAllWithType<PatrolArea>()
			orderby area.AreaIndex
			select area);
		DecideMissionState();
		base.Mission.MakeDefaultDeploymentPlans();
		for (int i = 0; i < 2; i++)
		{
			int spawnCount;
			if (_missionSides[i].IsPlayerSide)
			{
				spawnCount = _firstPhasePlayerSideTroopCount;
			}
			else
			{
				if (_missionSides[i].NumberOfTroopsNotSupplied <= _firstPhaseEnemyTroopCount)
				{
					Debug.FailedAssert("_missionSides[i].NumberOfTroopsNotSupplied <= _firstPhaseEnemyTroopCount", "C:\\Develop\\MB3\\Source\\Bannerlord\\SandBox\\Missions\\MissionLogics\\HideoutMissionController.cs", "InitializeMission", 449);
					_firstPhaseEnemyTroopCount = (int)((float)_missionSides[i].NumberOfTroopsNotSupplied * 0.7f);
				}
				spawnCount = ((_hideoutMissionState == HideoutMissionState.InitialFightBeforeBossFight) ? _firstPhaseEnemyTroopCount : _missionSides[i].NumberOfTroopsNotSupplied);
			}
			_missionSides[i].SpawnTroops(_areaMarkers, _patrolAreas, _defenderAgentObjects, spawnCount);
		}
	}

	private void UsedObjectTick(float dt)
	{
		foreach (KeyValuePair<Agent, UsedObject> defenderAgentObject in _defenderAgentObjects)
		{
			if (defenderAgentObject.Value.IsMachineAITicked)
			{
				defenderAgentObject.Value.MachineAI.Tick(defenderAgentObject.Key, null, null, dt);
			}
		}
	}

	protected override void OnEndMission()
	{
		int num = 0;
		if (_hideoutMissionState == HideoutMissionState.BossFightWithDuel)
		{
			if (Agent.Main == null || !Agent.Main.IsActive())
			{
				num = _duelPhaseAllyAgents?.Count ?? 0;
			}
			else if (_bossAgent == null || !_bossAgent.IsActive())
			{
				PlayerEncounter.EnemySurrender = true;
			}
		}
		if (MobileParty.MainParty.MemberRoster.TotalHealthyCount <= num && MapEvent.PlayerMapEvent.BattleState == BattleState.None)
		{
			MapEvent.PlayerMapEvent.SetOverrideWinner(BattleSideEnum.Defender);
		}
	}

	private void CheckBattleResolved()
	{
		if (_hideoutMissionState == HideoutMissionState.CutSceneBeforeBossFight || _hideoutMissionState == HideoutMissionState.ConversationBetweenLeaders)
		{
			return;
		}
		if (IsSideDepleted(BattleSideEnum.Attacker))
		{
			if (_hideoutMissionState == HideoutMissionState.BossFightWithDuel)
			{
				OnDuelOver(BattleSideEnum.Defender);
			}
			_battleEndLogic.ChangeCanCheckForEndCondition(canCheckForEndCondition: true);
			_battleResolved = true;
		}
		else
		{
			if (!IsSideDepleted(BattleSideEnum.Defender))
			{
				return;
			}
			if (_hideoutMissionState == HideoutMissionState.InitialFightBeforeBossFight)
			{
				if (_firstPhaseEndTimer == null)
				{
					_firstPhaseEndTimer = new Timer(base.Mission.CurrentTime, 4f);
					_oldMissionMode = Mission.Current.Mode;
					Mission.Current.SetMissionMode(MissionMode.CutScene, atStart: false);
				}
				else if (_firstPhaseEndTimer.Check(base.Mission.CurrentTime))
				{
					_cinematicController.StartCinematic(OnInitialFadeOutOver, OnCutSceneOver);
				}
			}
			else
			{
				if (_hideoutMissionState == HideoutMissionState.BossFightWithDuel)
				{
					OnDuelOver(BattleSideEnum.Attacker);
				}
				_battleEndLogic.ChangeCanCheckForEndCondition(canCheckForEndCondition: true);
				MapEvent.PlayerMapEvent.SetOverrideWinner(BattleSideEnum.Attacker);
				_battleResolved = true;
			}
		}
	}

	public void StartSpawner(BattleSideEnum side)
	{
		_missionSides[(int)side].SetSpawnTroops(spawnTroops: true);
	}

	public void StopSpawner(BattleSideEnum side)
	{
		_missionSides[(int)side].SetSpawnTroops(spawnTroops: false);
	}

	public bool IsSideSpawnEnabled(BattleSideEnum side)
	{
		return _missionSides[(int)side].TroopSpawningActive;
	}

	public float GetReinforcementInterval()
	{
		return 0f;
	}

	public bool IsSideDepleted(BattleSideEnum side)
	{
		bool flag = _missionSides[(int)side].NumberOfActiveTroops == 0;
		if (!flag)
		{
			if ((Agent.Main == null || !Agent.Main.IsActive()) && side == BattleSideEnum.Attacker)
			{
				if (_hideoutMissionState == HideoutMissionState.BossFightWithDuel || _hideoutMissionState == HideoutMissionState.InitialFightBeforeBossFight)
				{
					flag = true;
				}
				else if (_hideoutMissionState == HideoutMissionState.WithoutBossFight || _hideoutMissionState == HideoutMissionState.BossFightWithAll)
				{
					bool num = base.Mission.Teams.Attacker.FormationsIncludingEmpty.Any((Formation f) => f.CountOfUnits > 0 && f.GetReadonlyMovementOrderReference().OrderType == OrderType.Charge);
					bool flag2 = base.Mission.Teams.Defender.ActiveAgents.Any((Agent t) => t.CurrentWatchState == Agent.WatchState.Alarmed);
					flag = !num && !flag2;
				}
			}
			else if (side == BattleSideEnum.Defender && _hideoutMissionState == HideoutMissionState.BossFightWithDuel && (_bossAgent == null || !_bossAgent.IsActive()))
			{
				flag = true;
			}
		}
		else if (side == BattleSideEnum.Defender && _hideoutMissionState == HideoutMissionState.InitialFightBeforeBossFight && (Agent.Main == null || !Agent.Main.IsActive()))
		{
			flag = false;
		}
		return flag;
	}

	private void DecideMissionState()
	{
		MissionSide missionSide = _missionSides[0];
		_hideoutMissionState = (missionSide.IsPlayerSide ? HideoutMissionState.WithoutBossFight : HideoutMissionState.InitialFightBeforeBossFight);
	}

	private void SetWatchStateOfAIAgents(Agent.WatchState state)
	{
		foreach (Agent agent in base.Mission.Agents)
		{
			if (agent.IsAIControlled)
			{
				agent.SetWatchState(state);
			}
		}
	}

	private void SpawnBossAndBodyguards()
	{
		MissionSide missionSide = _missionSides[0];
		MatrixFrame banditsInitialFrame = _cinematicController.GetBanditsInitialFrame();
		missionSide.SpawnRemainingTroopsForBossFight(new List<MatrixFrame> { banditsInitialFrame }, missionSide.NumberOfTroopsNotSupplied);
		_bossAgent = SelectBossAgent();
		_bossAgent.WieldInitialWeapons(Agent.WeaponWieldActionType.InstantAfterPickUp, Equipment.InitialWeaponEquipPreference.MeleeForMainHand);
		foreach (Agent activeAgent in _enemyTeam.ActiveAgents)
		{
			if (activeAgent != _bossAgent)
			{
				activeAgent.WieldInitialWeapons(Agent.WeaponWieldActionType.WithAnimationUninterruptible);
			}
		}
	}

	private Agent SelectBossAgent()
	{
		Agent agent = null;
		Agent agent2 = null;
		foreach (Agent agent3 in base.Mission.Agents)
		{
			if (agent3.Team == _enemyTeam && agent3.IsHuman)
			{
				if (agent3.IsHero)
				{
					agent = agent3;
					break;
				}
				if (agent3.Character.Culture.IsBandit && (agent3.Character.Culture as CultureObject)?.BanditBoss != null && ((CultureObject)agent3.Character.Culture).BanditBoss == agent3.Character)
				{
					agent = agent3;
				}
				if (agent2 == null || agent3.Character.Level > agent2.Character.Level)
				{
					agent2 = agent3;
				}
			}
		}
		return agent ?? agent2;
	}

	private void OnInitialFadeOutOver(ref Agent playerAgent, ref List<Agent> playerCompanions, ref Agent bossAgent, ref List<Agent> bossCompanions, ref float placementPerturbation, ref float placementAngle)
	{
		_hideoutMissionState = HideoutMissionState.CutSceneBeforeBossFight;
		_enemyTeam = base.Mission.PlayerEnemyTeam;
		SpawnBossAndBodyguards();
		base.Mission.PlayerTeam.SetIsEnemyOf(_enemyTeam, isEnemyOf: false);
		SetWatchStateOfAIAgents(Agent.WatchState.Patrolling);
		if (Agent.Main.IsUsingGameObject)
		{
			Agent.Main.StopUsingGameObject(isSuccessful: false);
		}
		playerAgent = Agent.Main;
		playerCompanions = base.Mission.Agents.Where((Agent x) => x.IsActive() && x.Team == base.Mission.PlayerTeam && x.IsHuman && x.IsAIControlled).ToList();
		bossAgent = _bossAgent;
		bossCompanions = base.Mission.Agents.Where((Agent x) => x.IsActive() && x.Team == _enemyTeam && x.IsHuman && x.IsAIControlled && x != _bossAgent).ToList();
	}

	private void OnCutSceneOver()
	{
		Mission.Current.SetMissionMode(_oldMissionMode, atStart: false);
		_hideoutMissionState = HideoutMissionState.ConversationBetweenLeaders;
		MissionConversationLogic missionBehavior = base.Mission.GetMissionBehavior<MissionConversationLogic>();
		missionBehavior.DisableStartConversation(isDisabled: false);
		missionBehavior.StartConversation(_bossAgent, setActionsInstantly: false);
	}

	private void OnDuelOver(BattleSideEnum winnerSide)
	{
		AgentVictoryLogic missionBehavior = base.Mission.GetMissionBehavior<AgentVictoryLogic>();
		missionBehavior?.SetCheerActionGroup(AgentVictoryLogic.CheerActionGroupEnum.HighCheerActions);
		missionBehavior?.SetCheerReactionTimerSettings(0.25f, 3f);
		if (winnerSide == BattleSideEnum.Attacker && _duelPhaseAllyAgents != null)
		{
			foreach (Agent duelPhaseAllyAgent in _duelPhaseAllyAgents)
			{
				if (duelPhaseAllyAgent.State == AgentState.Active)
				{
					duelPhaseAllyAgent.SetTeam(base.Mission.PlayerTeam, sync: true);
					duelPhaseAllyAgent.SetWatchState(Agent.WatchState.Alarmed);
				}
			}
			return;
		}
		if (winnerSide != 0 || _duelPhaseBanditAgents == null)
		{
			return;
		}
		foreach (Agent duelPhaseBanditAgent in _duelPhaseBanditAgents)
		{
			if (duelPhaseBanditAgent.State == AgentState.Active)
			{
				duelPhaseBanditAgent.SetTeam(_enemyTeam, sync: true);
				duelPhaseBanditAgent.SetWatchState(Agent.WatchState.Alarmed);
			}
		}
	}

	public static void StartBossFightDuelMode()
	{
		(Mission.Current?.GetMissionBehavior<HideoutMissionController>())?.StartBossFightDuelModeInternal();
	}

	private void StartBossFightDuelModeInternal()
	{
		base.Mission.GetMissionBehavior<MissionConversationLogic>().DisableStartConversation(isDisabled: true);
		base.Mission.PlayerTeam.SetIsEnemyOf(_enemyTeam, isEnemyOf: true);
		_duelPhaseAllyAgents = base.Mission.Agents.Where((Agent x) => x.IsActive() && x.Team == base.Mission.PlayerTeam && x.IsHuman && x.IsAIControlled && x != Agent.Main).ToList();
		_duelPhaseBanditAgents = base.Mission.Agents.Where((Agent x) => x.IsActive() && x.Team == _enemyTeam && x.IsHuman && x.IsAIControlled && x != _bossAgent).ToList();
		foreach (Agent duelPhaseAllyAgent in _duelPhaseAllyAgents)
		{
			duelPhaseAllyAgent.SetTeam(Team.Invalid, sync: true);
			WorldPosition position = duelPhaseAllyAgent.GetWorldPosition();
			duelPhaseAllyAgent.SetScriptedPosition(ref position, addHumanLikeDelay: false);
			duelPhaseAllyAgent.SetLookAgent(Agent.Main);
		}
		foreach (Agent duelPhaseBanditAgent in _duelPhaseBanditAgents)
		{
			duelPhaseBanditAgent.SetTeam(Team.Invalid, sync: true);
			WorldPosition position2 = duelPhaseBanditAgent.GetWorldPosition();
			duelPhaseBanditAgent.SetScriptedPosition(ref position2, addHumanLikeDelay: false);
			duelPhaseBanditAgent.SetLookAgent(_bossAgent);
		}
		_bossAgent.SetWatchState(Agent.WatchState.Alarmed);
		_hideoutMissionState = HideoutMissionState.BossFightWithDuel;
	}

	public static void StartBossFightBattleMode()
	{
		(Mission.Current?.GetMissionBehavior<HideoutMissionController>())?.StartBossFightBattleModeInternal();
	}

	private void StartBossFightBattleModeInternal()
	{
		base.Mission.GetMissionBehavior<MissionConversationLogic>().DisableStartConversation(isDisabled: true);
		base.Mission.PlayerTeam.SetIsEnemyOf(_enemyTeam, isEnemyOf: true);
		SetWatchStateOfAIAgents(Agent.WatchState.Alarmed);
		_hideoutMissionState = HideoutMissionState.BossFightWithAll;
		foreach (Formation item in base.Mission.PlayerTeam.FormationsIncludingEmpty)
		{
			if (item.CountOfUnits > 0)
			{
				item.SetMovementOrder(MovementOrder.MovementOrderCharge);
				item.FiringOrder = FiringOrder.FiringOrderFireAtWill;
			}
		}
	}
}
