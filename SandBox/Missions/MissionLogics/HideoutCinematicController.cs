using System;
using System.Collections.Generic;
using SandBox.Objects.Cinematics;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.MissionLogics;

public class HideoutCinematicController : MissionLogic
{
	public delegate void OnInitialFadeOutFinished(ref Agent playerAgent, ref List<Agent> playerCompanions, ref Agent bossAgent, ref List<Agent> bossCompanions, ref float placementPerturbation, ref float placementAngle);

	public delegate void OnHideoutCinematicFinished();

	public delegate void OnHideoutCinematicStateChanged(HideoutCinematicState state);

	public delegate void OnHideoutCinematicTransition(HideoutCinematicState nextState, float duration);

	public readonly struct HideoutCinematicAgentInfo
	{
		public readonly Agent Agent;

		public readonly MatrixFrame InitialFrame;

		public readonly MatrixFrame TargetFrame;

		public readonly HideoutAgentType Type;

		public HideoutCinematicAgentInfo(Agent agent, HideoutAgentType type, in MatrixFrame initialFrame, in MatrixFrame targetFrame)
		{
			Agent = agent;
			InitialFrame = initialFrame;
			TargetFrame = targetFrame;
			Type = type;
		}

		public bool HasReachedTarget(float proximityThreshold = 0.5f)
		{
			return Agent.Position.Distance(TargetFrame.origin) <= proximityThreshold;
		}
	}

	public enum HideoutCinematicState
	{
		None,
		InitialFadeOut,
		PreCinematic,
		Cinematic,
		PostCinematic,
		Completed
	}

	public enum HideoutAgentType
	{
		Player,
		Boss,
		Ally,
		Bandit
	}

	public enum HideoutPreCinematicPhase
	{
		NotStarted,
		InitializeFormations,
		StopFormations,
		InitializeAgents,
		MoveAgents,
		Completed
	}

	public enum HideoutPostCinematicPhase
	{
		NotStarted,
		MoveAgents,
		FinalizeAgents,
		Completed
	}

	private const float AgentTargetProximityThreshold = 0.5f;

	private const float AgentMaxSpeedCinematicOverride = 0.65f;

	public const string HideoutSceneEntityTag = "hideout_boss_fight";

	public const float DefaultTransitionDuration = 0.4f;

	public const float DefaultStateDuration = 0.2f;

	public const float DefaultCinematicDuration = 8f;

	public const float DefaultPlacementPerturbation = 0.25f;

	public const float DefaultPlacementAngle = (float)Math.PI / 15f;

	private OnInitialFadeOutFinished _initialFadeOutFinished;

	private OnHideoutCinematicFinished _cinematicFinishedCallback;

	private OnHideoutCinematicStateChanged _stateChangedCallback;

	private OnHideoutCinematicTransition _transitionCallback;

	private float _cinematicDuration = 8f;

	private float _stateDuration = 0.2f;

	private float _transitionDuration = 0.4f;

	private float _remainingCinematicDuration = 8f;

	private float _remainingStateDuration = 0.2f;

	private float _remainingTransitionDuration = 0.4f;

	private List<Formation> _cachedAgentFormations;

	private List<HideoutCinematicAgentInfo> _hideoutAgentsInfo;

	private HideoutCinematicAgentInfo _bossAgentInfo;

	private HideoutCinematicAgentInfo _playerAgentInfo;

	private bool _isBehaviorInit;

	private HideoutPreCinematicPhase _preCinematicPhase;

	private HideoutPostCinematicPhase _postCinematicPhase;

	private HideoutBossFightBehavior _hideoutBossFightBehavior;

	public HideoutCinematicState State { get; private set; }

	public bool InStateTransition { get; private set; }

	public bool IsCinematicActive => State != HideoutCinematicState.None;

	public float CinematicDuration => _cinematicDuration;

	public float TransitionDuration => _transitionDuration;

	public override MissionBehaviorType BehaviorType => MissionBehaviorType.Logic;

	public HideoutCinematicController()
	{
		State = HideoutCinematicState.None;
		_cinematicFinishedCallback = null;
		_transitionCallback = null;
		_stateChangedCallback = null;
		InStateTransition = false;
		_isBehaviorInit = false;
	}

	public void SetStateTransitionCallback(OnHideoutCinematicStateChanged onStateChanged, OnHideoutCinematicTransition onTransition)
	{
		_stateChangedCallback = onStateChanged;
		_transitionCallback = onTransition;
	}

	public void StartCinematic(OnInitialFadeOutFinished initialFadeOutFinished, OnHideoutCinematicFinished cinematicFinishedCallback, float transitionDuration = 0.4f, float stateDuration = 0.2f, float cinematicDuration = 8f)
	{
		if (_isBehaviorInit && State == HideoutCinematicState.None)
		{
			_cinematicFinishedCallback = cinematicFinishedCallback;
			_initialFadeOutFinished = initialFadeOutFinished;
			_preCinematicPhase = HideoutPreCinematicPhase.InitializeFormations;
			_postCinematicPhase = HideoutPostCinematicPhase.MoveAgents;
			_transitionDuration = transitionDuration;
			_stateDuration = stateDuration;
			_cinematicDuration = cinematicDuration;
			_remainingCinematicDuration = _cinematicDuration;
			BeginStateTransition(HideoutCinematicState.InitialFadeOut);
		}
		else if (!_isBehaviorInit)
		{
			Debug.FailedAssert("Hideout cinematic controller is not initialized.", "C:\\Develop\\MB3\\Source\\Bannerlord\\SandBox\\Missions\\MissionLogics\\HideoutCinematicController.cs", "StartCinematic", 195);
		}
		else if (State != 0)
		{
			Debug.FailedAssert("There is already an ongoing cinematic.", "C:\\Develop\\MB3\\Source\\Bannerlord\\SandBox\\Missions\\MissionLogics\\HideoutCinematicController.cs", "StartCinematic", 199);
		}
	}

	public MatrixFrame GetBanditsInitialFrame()
	{
		_hideoutBossFightBehavior.GetBanditsInitialFrame(out var frame);
		return frame;
	}

	public void GetBossStandingEyePosition(out Vec3 eyePosition)
	{
		if (_bossAgentInfo.Agent?.Monster != null)
		{
			eyePosition = _bossAgentInfo.InitialFrame.origin + Vec3.Up * (_bossAgentInfo.Agent.AgentScale * _bossAgentInfo.Agent.Monster.StandingEyeHeight);
			return;
		}
		eyePosition = Vec3.Zero;
		Debug.FailedAssert("false", "C:\\Develop\\MB3\\Source\\Bannerlord\\SandBox\\Missions\\MissionLogics\\HideoutCinematicController.cs", "GetBossStandingEyePosition", 218);
	}

	public void GetPlayerStandingEyePosition(out Vec3 eyePosition)
	{
		if (_playerAgentInfo.Agent?.Monster != null)
		{
			eyePosition = _playerAgentInfo.InitialFrame.origin + Vec3.Up * (_playerAgentInfo.Agent.AgentScale * _playerAgentInfo.Agent.Monster.StandingEyeHeight);
			return;
		}
		eyePosition = Vec3.Zero;
		Debug.FailedAssert("false", "C:\\Develop\\MB3\\Source\\Bannerlord\\SandBox\\Missions\\MissionLogics\\HideoutCinematicController.cs", "GetPlayerStandingEyePosition", 231);
	}

	public void GetScenePrefabParameters(out float innerRadius, out float outerRadius, out float walkDistance)
	{
		innerRadius = 0f;
		outerRadius = 0f;
		walkDistance = 0f;
		if (_hideoutBossFightBehavior != null)
		{
			innerRadius = _hideoutBossFightBehavior.InnerRadius;
			outerRadius = _hideoutBossFightBehavior.OuterRadius;
			walkDistance = _hideoutBossFightBehavior.WalkDistance;
		}
	}

	public override void OnBehaviorInitialize()
	{
		base.OnBehaviorInitialize();
		GameEntity gameEntity = base.Mission.Scene.FindEntityWithTag("hideout_boss_fight");
		_hideoutBossFightBehavior = gameEntity?.GetFirstScriptOfType<HideoutBossFightBehavior>();
		_isBehaviorInit = gameEntity != null && _hideoutBossFightBehavior != null;
	}

	public override void OnMissionTick(float dt)
	{
		if (!_isBehaviorInit || !IsCinematicActive)
		{
			return;
		}
		if (InStateTransition)
		{
			TickStateTransition(dt);
			return;
		}
		switch (State)
		{
		case HideoutCinematicState.InitialFadeOut:
			if (TickInitialFadeOut(dt))
			{
				BeginStateTransition(HideoutCinematicState.PreCinematic);
			}
			break;
		case HideoutCinematicState.PreCinematic:
			if (TickPreCinematic(dt))
			{
				BeginStateTransition(HideoutCinematicState.Cinematic);
			}
			break;
		case HideoutCinematicState.Cinematic:
			if (TickCinematic(dt))
			{
				BeginStateTransition(HideoutCinematicState.PostCinematic);
			}
			break;
		case HideoutCinematicState.PostCinematic:
			if (TickPostCinematic(dt))
			{
				BeginStateTransition(HideoutCinematicState.Completed);
			}
			break;
		case HideoutCinematicState.Completed:
			_cinematicFinishedCallback?.Invoke();
			State = HideoutCinematicState.None;
			break;
		}
	}

	private void TickStateTransition(float dt)
	{
		_remainingTransitionDuration -= dt;
		if (_remainingTransitionDuration <= 0f)
		{
			InStateTransition = false;
			_stateChangedCallback?.Invoke(State);
			_remainingStateDuration = _stateDuration;
		}
	}

	private bool TickInitialFadeOut(float dt)
	{
		_remainingStateDuration -= dt;
		if (_remainingStateDuration <= 0f)
		{
			Agent playerAgent = null;
			Agent bossAgent = null;
			List<Agent> playerCompanions = null;
			List<Agent> bossCompanions = null;
			float placementPerturbation = 0.25f;
			float placementAngle = (float)Math.PI / 15f;
			_initialFadeOutFinished?.Invoke(ref playerAgent, ref playerCompanions, ref bossAgent, ref bossCompanions, ref placementPerturbation, ref placementAngle);
			ComputeAgentFrames(playerAgent, playerCompanions, bossAgent, bossCompanions, placementPerturbation, placementAngle);
		}
		return _remainingStateDuration <= 0f;
	}

	private bool TickPreCinematic(float dt)
	{
		Scene scene = base.Mission.Scene;
		_remainingStateDuration -= dt;
		switch (_preCinematicPhase)
		{
		case HideoutPreCinematicPhase.InitializeFormations:
		{
			_playerAgentInfo.Agent.Controller = Agent.ControllerType.AI;
			bool isTeleportingAgents2 = base.Mission.IsTeleportingAgents;
			base.Mission.IsTeleportingAgents = true;
			_hideoutBossFightBehavior.GetAlliesInitialFrame(out var frame);
			foreach (Formation item in base.Mission.Teams.Attacker.FormationsIncludingEmpty)
			{
				if (item.CountOfUnits > 0)
				{
					WorldPosition position = new WorldPosition(scene, frame.origin);
					item.SetMovementOrder(MovementOrder.MovementOrderMove(position));
				}
			}
			_hideoutBossFightBehavior.GetBanditsInitialFrame(out var frame2);
			foreach (Formation item2 in base.Mission.Teams.Defender.FormationsIncludingEmpty)
			{
				if (item2.CountOfUnits > 0)
				{
					WorldPosition position2 = new WorldPosition(scene, frame2.origin);
					item2.SetMovementOrder(MovementOrder.MovementOrderMove(position2));
				}
			}
			foreach (HideoutCinematicAgentInfo item3 in _hideoutAgentsInfo)
			{
				Agent agent3 = item3.Agent;
				Vec3 vec = (agent3.LookDirection = item3.InitialFrame.rotation.f);
				Vec2 direction = vec.AsVec2.Normalized();
				agent3.SetMovementDirection(in direction);
			}
			base.Mission.IsTeleportingAgents = isTeleportingAgents2;
			_preCinematicPhase = HideoutPreCinematicPhase.StopFormations;
			break;
		}
		case HideoutPreCinematicPhase.StopFormations:
			foreach (Formation item4 in base.Mission.Teams.Attacker.FormationsIncludingEmpty)
			{
				if (item4.CountOfUnits > 0)
				{
					item4.SetMovementOrder(MovementOrder.MovementOrderStop);
				}
			}
			foreach (Formation item5 in base.Mission.Teams.Defender.FormationsIncludingEmpty)
			{
				if (item5.CountOfUnits > 0)
				{
					item5.SetMovementOrder(MovementOrder.MovementOrderStop);
				}
			}
			_preCinematicPhase = HideoutPreCinematicPhase.InitializeAgents;
			break;
		case HideoutPreCinematicPhase.InitializeAgents:
		{
			bool isTeleportingAgents = base.Mission.IsTeleportingAgents;
			base.Mission.IsTeleportingAgents = true;
			_cachedAgentFormations = new List<Formation>();
			foreach (HideoutCinematicAgentInfo item6 in _hideoutAgentsInfo)
			{
				Agent agent2 = item6.Agent;
				_cachedAgentFormations.Add(agent2.Formation);
				agent2.Formation = null;
				MatrixFrame initialFrame = item6.InitialFrame;
				WorldPosition worldPosition = new WorldPosition(scene, initialFrame.origin);
				Vec3 f = initialFrame.rotation.f;
				agent2.TeleportToPosition(worldPosition.GetGroundVec3());
				agent2.LookDirection = f;
				Vec2 direction = f.AsVec2.Normalized();
				agent2.SetMovementDirection(in direction);
			}
			base.Mission.IsTeleportingAgents = isTeleportingAgents;
			_preCinematicPhase = HideoutPreCinematicPhase.MoveAgents;
			break;
		}
		case HideoutPreCinematicPhase.MoveAgents:
			foreach (HideoutCinematicAgentInfo item7 in _hideoutAgentsInfo)
			{
				Agent agent = item7.Agent;
				MatrixFrame targetFrame = item7.TargetFrame;
				WorldPosition scriptedPosition = new WorldPosition(scene, targetFrame.origin);
				agent.SetMaximumSpeedLimit(0.65f, isMultiplier: false);
				agent.SetScriptedPositionAndDirection(ref scriptedPosition, targetFrame.rotation.f.AsVec2.RotationInRadians, addHumanLikeDelay: true);
			}
			_preCinematicPhase = HideoutPreCinematicPhase.Completed;
			break;
		}
		if (_preCinematicPhase == HideoutPreCinematicPhase.Completed)
		{
			return _remainingStateDuration <= 0f;
		}
		return false;
	}

	private bool TickCinematic(float dt)
	{
		_remainingCinematicDuration -= dt;
		_remainingStateDuration -= dt;
		if (_remainingCinematicDuration <= 0f && _remainingStateDuration <= 0f)
		{
			return true;
		}
		return false;
	}

	private bool TickPostCinematic(float dt)
	{
		_remainingStateDuration -= dt;
		switch (_postCinematicPhase)
		{
		case HideoutPostCinematicPhase.MoveAgents:
		{
			int num = 0;
			foreach (HideoutCinematicAgentInfo item in _hideoutAgentsInfo)
			{
				Agent agent2 = item.Agent;
				if (!item.HasReachedTarget())
				{
					MatrixFrame targetFrame = item.TargetFrame;
					agent2.TeleportToPosition(new WorldPosition(base.Mission.Scene, targetFrame.origin).GetGroundVec3());
					Vec2 direction = targetFrame.rotation.f.AsVec2.Normalized();
					agent2.SetMovementDirection(in direction);
				}
				agent2.Formation = _cachedAgentFormations[num];
				num++;
			}
			_postCinematicPhase = HideoutPostCinematicPhase.FinalizeAgents;
			break;
		}
		case HideoutPostCinematicPhase.FinalizeAgents:
			foreach (HideoutCinematicAgentInfo item2 in _hideoutAgentsInfo)
			{
				Agent agent = item2.Agent;
				agent.DisableScriptedMovement();
				agent.SetMaximumSpeedLimit(-1f, isMultiplier: false);
			}
			_postCinematicPhase = HideoutPostCinematicPhase.Completed;
			break;
		}
		if (_postCinematicPhase == HideoutPostCinematicPhase.Completed)
		{
			return _remainingStateDuration <= 0f;
		}
		return false;
	}

	private void BeginStateTransition(HideoutCinematicState nextState)
	{
		State = nextState;
		_remainingTransitionDuration = _transitionDuration;
		InStateTransition = true;
		_transitionCallback?.Invoke(State, _remainingTransitionDuration);
	}

	private bool CheckNavMeshValidity(ref Vec3 initial, ref Vec3 target)
	{
		Scene scene = base.Mission.Scene;
		bool result = false;
		bool navigationMeshForPosition = scene.GetNavigationMeshForPosition(ref initial);
		bool navigationMeshForPosition2 = scene.GetNavigationMeshForPosition(ref target);
		if (navigationMeshForPosition && navigationMeshForPosition2)
		{
			WorldPosition position = new WorldPosition(scene, initial);
			WorldPosition destination = new WorldPosition(scene, target);
			result = scene.DoesPathExistBetweenPositions(position, destination);
		}
		return result;
	}

	private void ComputeAgentFrames(Agent playerAgent, List<Agent> playerCompanions, Agent bossAgent, List<Agent> bossCompanions, float placementPerturbation, float placementAngle)
	{
		_hideoutAgentsInfo = new List<HideoutCinematicAgentInfo>();
		_hideoutBossFightBehavior.GetPlayerFrames(out var initialFrame, out var targetFrame, placementPerturbation);
		_playerAgentInfo = new HideoutCinematicAgentInfo(playerAgent, HideoutAgentType.Player, in initialFrame, in targetFrame);
		_hideoutAgentsInfo.Add(_playerAgentInfo);
		_hideoutBossFightBehavior.GetAllyFrames(out var initialFrames, out var targetFrames, playerCompanions.Count, placementAngle, placementPerturbation);
		for (int i = 0; i < playerCompanions.Count; i++)
		{
			initialFrame = initialFrames[i];
			targetFrame = targetFrames[i];
			_hideoutAgentsInfo.Add(new HideoutCinematicAgentInfo(playerCompanions[i], HideoutAgentType.Ally, in initialFrame, in targetFrame));
		}
		_hideoutBossFightBehavior.GetBossFrames(out initialFrame, out targetFrame, placementPerturbation);
		_bossAgentInfo = new HideoutCinematicAgentInfo(bossAgent, HideoutAgentType.Boss, in initialFrame, in targetFrame);
		_hideoutAgentsInfo.Add(_bossAgentInfo);
		_hideoutBossFightBehavior.GetBanditFrames(out initialFrames, out targetFrames, bossCompanions.Count, placementAngle, placementPerturbation);
		for (int j = 0; j < bossCompanions.Count; j++)
		{
			initialFrame = initialFrames[j];
			targetFrame = targetFrames[j];
			_hideoutAgentsInfo.Add(new HideoutCinematicAgentInfo(bossCompanions[j], HideoutAgentType.Bandit, in initialFrame, in targetFrame));
		}
	}
}
