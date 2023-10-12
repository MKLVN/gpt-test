using System;
using System.Collections.Generic;
using System.Linq;
using SandBox.Conversation.MissionLogics;
using SandBox.Missions.MissionLogics;
using StoryMode.StoryModeObjects;
using StoryMode.StoryModePhases;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.AgentOrigins;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Objects;
using TaleWorlds.ObjectSystem;

namespace StoryMode.Missions;

public class TrainingFieldMissionController : MissionLogic
{
	public class TutorialObjective
	{
		private TextObject _name;

		public string Id { get; private set; }

		public bool IsFinished { get; private set; }

		public bool IsActive { get; private set; }

		public List<TutorialObjective> SubTasks { get; private set; }

		public float Score { get; private set; }

		public TutorialObjective(string id, bool isFinished = false, bool isActive = false)
		{
			_name = GameTexts.FindText("str_tutorial_" + id);
			Id = id;
			IsFinished = isFinished;
			IsActive = isActive;
			SubTasks = new List<TutorialObjective>();
			Score = 0f;
		}

		public void SetTextVariableOfName(string tag, int variable)
		{
			string text = _name.ToString();
			_name.SetTextVariable(tag, variable);
			if (text != _name.ToString())
			{
				_updateObjectivesWillBeCalled = true;
			}
		}

		public string GetNameString()
		{
			if (_name == null)
			{
				return "";
			}
			return _name.ToString();
		}

		public bool SetActive(bool isActive)
		{
			if (IsActive == isActive)
			{
				return false;
			}
			IsActive = isActive;
			_updateObjectivesWillBeCalled = true;
			return true;
		}

		public bool FinishTask()
		{
			if (IsFinished)
			{
				return false;
			}
			IsFinished = true;
			_updateObjectivesWillBeCalled = true;
			return true;
		}

		public void FinishSubTask(string subTaskName, float score)
		{
			TutorialObjective tutorialObjective = SubTasks.Find((TutorialObjective x) => x.Id == subTaskName);
			tutorialObjective.FinishTask();
			if (score != 0f && (tutorialObjective.Score > score || tutorialObjective.Score == 0f))
			{
				tutorialObjective.Score = score;
			}
			if (!SubTasks.Exists((TutorialObjective x) => !x.IsFinished))
			{
				FinishTask();
			}
			_updateObjectivesWillBeCalled = true;
		}

		public bool SetAllSubTasksInactive()
		{
			bool flag = false;
			foreach (TutorialObjective subTask in SubTasks)
			{
				bool flag2 = subTask.SetActive(isActive: false);
				flag = flag || flag2;
				if (subTask.SubTasks.Count > 0)
				{
					bool flag3 = subTask.SetAllSubTasksInactive();
					flag = flag || flag3;
				}
			}
			if (flag)
			{
				_updateObjectivesWillBeCalled = true;
			}
			return flag;
		}

		public void AddSubTask(TutorialObjective newSubTask)
		{
			SubTasks.Add(newSubTask);
			_updateObjectivesWillBeCalled = true;
		}

		public void RestoreScoreFromSave(float score)
		{
			Score = score;
			_updateObjectivesWillBeCalled = true;
		}
	}

	public struct DelayedAction
	{
		private float _orderGivenTime;

		private float _delayTime;

		private Action _order;

		private string _explanation;

		public DelayedAction(Action order, float delayTime, string explanation)
		{
			_orderGivenTime = Mission.Current.CurrentTime;
			_delayTime = delayTime;
			_order = order;
			_explanation = explanation;
		}

		public bool Update()
		{
			if (Mission.Current.CurrentTime - _orderGivenTime > _delayTime)
			{
				_order();
				return true;
			}
			return false;
		}
	}

	public enum MouseObjectives
	{
		None,
		AttackLeft,
		AttackRight,
		AttackUp,
		AttackDown,
		DefendLeft,
		DefendRight,
		DefendUp,
		DefendDown
	}

	private enum HorseReturningSituation
	{
		NotInPosition,
		BeginReturn,
		Returning,
		ReturnCompleted,
		Following
	}

	private const string SoundBasicMeleeGreet = "event:/mission/tutorial/vo/parrying/greet";

	private const string SoundBasicMeleeBlockLeft = "event:/mission/tutorial/vo/parrying/block_left";

	private const string SoundBasicMeleeBlockRight = "event:/mission/tutorial/vo/parrying/block_right";

	private const string SoundBasicMeleeBlockUp = "event:/mission/tutorial/vo/parrying/block_up";

	private const string SoundBasicMeleeBlockDown = "event:/mission/tutorial/vo/parrying/block_down";

	private const string SoundBasicMeleeAttackLeft = "event:/mission/tutorial/vo/parrying/attack_left";

	private const string SoundBasicMeleeAttackRight = "event:/mission/tutorial/vo/parrying/attack_right";

	private const string SoundBasicMeleeAttackUp = "event:/mission/tutorial/vo/parrying/attack_up";

	private const string SoundBasicMeleeAttackDown = "event:/mission/tutorial/vo/parrying/attack_down";

	private const string SoundBasicMeleeRemark = "event:/mission/tutorial/vo/parrying/remark";

	private const string SoundBasicMeleePraise = "event:/mission/tutorial/vo/parrying/praise";

	private const string SoundAdvancedMeleeGreet = "event:/mission/tutorial/vo/fighting/greet";

	private const string SoundAdvancedMeleeWarning = "event:/mission/tutorial/vo/fighting/warning";

	private const string SoundAdvancedMeleePlayerLose = "event:/mission/tutorial/vo/fighting/player_lose";

	private const string SoundAdvancedMeleePlayerWin = "event:/mission/tutorial/vo/fighting/player_win";

	private const string SoundRangedPickPrefix = "event:/mission/tutorial/vo/archery/pick_";

	private const string SoundRangedStartTraining = "event:/mission/tutorial/vo/archery/start_training";

	private const string SoundRangedHitTarget = "event:/mission/tutorial/vo/archery/hit_target";

	private const string SoundRangedMissTarget = "event:/mission/tutorial/vo/archery/miss_target";

	private const string SoundRangedFinish = "event:/mission/tutorial/vo/archery/finish";

	private const string SoundMountedPickPrefix = "event:/mission/tutorial/vo/riding/pick_";

	private const string SoundMountedMountHorse = "event:/mission/tutorial/vo/riding/mount_horse";

	private const string SoundMountedStartCourse = "event:/mission/tutorial/vo/riding/start_course";

	private const string SoundMountedCourseFinish = "event:/mission/tutorial/vo/riding/course_finish";

	private const string SoundMountedCoursePerfect = "event:/mission/tutorial/vo/riding/course_perfect";

	private const string FinishCourseSound = "event:/mission/tutorial/finish_course";

	private const string FinishTaskSound = "event:/mission/tutorial/finish_task";

	private const string HitTargetSound = "event:/mission/tutorial/hit_target";

	private TextObject _trainingFinishedText = new TextObject("{=cRvSuYC8}Choose another weapon or go to another training area.");

	private List<DelayedAction> _delayedActions = new List<DelayedAction>();

	private MissionConversationLogic _missionConversationHandler;

	private const string RangedNpcCharacter = "tutorial_npc_ranged";

	private const string BowTrainingShootingPositionTag = "bow_training_shooting_position";

	private const string SpawnerRangedNpcTag = "spawner_ranged_npc_tag";

	private const string RangedNpcSecondPosTag = "_ranged_npc_second_pos_tag";

	private const string RangedNpcTargetTag = "_ranged_npc_target";

	private const float ShootingPositionActivationDistance = 2f;

	private const string NameOfTheMeleeTraining = "Melee Training";

	private const string BasicMeleeNpcSpawnPointTag = "spawner_melee_npc";

	private const string BasicMeleeNpcCharacter = "tutorial_npc_basic_melee";

	private const string AdvancedMeleeNpcSpawnPointTagEasy = "spawner_adv_melee_npc_easy";

	private const string AdvancedMeleeNpcSpawnPointTagNormal = "spawner_adv_melee_npc_normal";

	private const string AdvancedMeleeNpcEasySecondPositionTag = "adv_melee_npc_easy_second_pos";

	private const string AdvancedMeleeNpcNormalSecondPositionTag = "adv_melee_npc_normal_second_pos";

	private const string AdvancedMeleeEasyNpcCharacter = "tutorial_npc_advanced_melee_easy";

	private const string AdvancedMeleeNormalNpcCharacter = "tutorial_npc_advanced_melee_normal";

	private const string AdvancedMeleeBattleAreaTag = "battle_area";

	private const string MountedAISpawnPositionTag = "_mounted_ai_spawn_position";

	private const string MountedAICharacter = "tutorial_npc_mounted_ai";

	private const string MountedAITargetTag = "_mounted_ai_target";

	private const string MountedAIWaitingPositionTag = "_mounted_ai_waiting_position";

	private const string CheckpointTag = "mounted_checkpoint";

	private const string HorseSpawnPositionTag = "spawner_horse";

	private const string FinishGateClosedTag = "finish_gate_closed";

	private const string FinishGateOpenTag = "finish_gate_open";

	private const string NameOfTheHorse = "old_horse";

	private List<TutorialArea> _trainingAreas = new List<TutorialArea>();

	private TutorialArea _activeTutorialArea;

	private List<Agent> _agents = new List<Agent>();

	private bool _courseFinished;

	private int _trainingProgress;

	private int _trainingSubTypeIndex = -1;

	private string _activeTrainingSubTypeTag = "";

	private float _beginningTime;

	private float _timeScore;

	private bool _showTutorialObjectivesAnyway;

	private Dictionary<string, float> _tutorialScores;

	private GameEntity _shootingPosition;

	private Agent _bowNpc;

	private WorldPosition _rangedNpcSpawnPosition;

	private WorldPosition _rangedTargetPosition;

	private Vec3 _rangedTargetRotation;

	private GameEntity _rangedNpcSpawnPoint;

	private int _rangedLastBrokenTargetCount;

	private List<DestructableComponent> _targetsForRangedNpc = new List<DestructableComponent>();

	private DestructableComponent _lastTargetGiven;

	private bool _atShootingPosition;

	private bool _targetPositionSet;

	private List<TutorialObjective> _rangedObjectives = new List<TutorialObjective>
	{
		new TutorialObjective("ranged_go_to_shooting_position"),
		new TutorialObjective("ranged_shoot_targets")
	};

	private TextObject _remainingTargetText = new TextObject("{=gBbm9beO}Hit all of the targets. {REMAINING_TARGET} {?REMAINING_TARGET>1}targets{?}target{\\?} left.");

	private Agent _meleeTrainer;

	private WorldPosition _meleeTrainerDefaultPosition;

	private float _timer;

	private List<TutorialObjective> _meleeObjectives = new List<TutorialObjective>
	{
		new TutorialObjective("melee_go_to_trainer"),
		new TutorialObjective("melee_defense"),
		new TutorialObjective("melee_attack")
	};

	private Agent _advancedMeleeTrainerEasy;

	private Agent _advancedMeleeTrainerNormal;

	private WorldPosition _advancedEasyMeleeTrainerDefaultPosition;

	private WorldPosition _advancedNormalMeleeTrainerDefaultPosition;

	private float _playerCampaignHealth;

	private float _playerHealth = 100f;

	private float _advancedMeleeTrainerEasyHealth = 100f;

	private float _advancedMeleeTrainerNormalHealth = 100f;

	private MatrixFrame _advancedMeleeTrainerEasyInitialPosition;

	private MatrixFrame _advancedMeleeTrainerEasySecondPosition;

	private MatrixFrame _advancedMeleeTrainerNormalInitialPosition;

	private MatrixFrame _advancedMeleeTrainerNormalSecondPosition;

	private TextObject _fightStartsIn = new TextObject("{=TNxWBS07}Fight will start in {REMAINING_TIME} {?REMAINING_TIME>1}seconds{?}second{\\?}...");

	private List<TutorialObjective> _advMeleeObjectives = new List<TutorialObjective>
	{
		new TutorialObjective("adv_melee_go_to_trainer"),
		new TutorialObjective("adv_melee_beat_easy_trainer"),
		new TutorialObjective("adv_melee_beat_normal_trainer")
	};

	private ActionIndexCache FallBackRiseAnimation = ActionIndexCache.Create("act_strike_fall_back_back_rise");

	private ActionIndexCache FallBackRiseAnimationContinue = ActionIndexCache.Create("act_strike_fall_back_back_rise_continue");

	private bool _playerLeftBattleArea;

	private GameEntity _finishGateClosed;

	private GameEntity _finishGateOpen;

	private int _finishGateStatus;

	private List<(VolumeBox, bool)> _checkpoints = new List<(VolumeBox, bool)>();

	private int _currentCheckpointIndex = -1;

	private int _mountedLastBrokenTargetCount;

	private float _enteringDotProduct;

	private Agent _horse;

	private WorldPosition _horseBeginningPosition;

	private HorseReturningSituation _horseBehaviorMode = HorseReturningSituation.ReturnCompleted;

	private List<TutorialObjective> _mountedObjectives = new List<TutorialObjective>
	{
		new TutorialObjective("mounted_mount_the_horse"),
		new TutorialObjective("mounted_hit_targets")
	};

	private Agent _mountedAI;

	private MatrixFrame _mountedAISpawnPosition;

	private MatrixFrame _mountedAIWaitingPosition;

	private int _mountedAICurrentCheckpointTarget = -1;

	private int _mountedAICurrentHitTarget;

	private bool _enteredRadiusOfTarget;

	private bool _allTargetsDestroyed;

	private List<DestructableComponent> _mountedAITargets = new List<DestructableComponent>();

	private bool _continueLoop = true;

	private List<Vec3> _mountedAICheckpointList = new List<Vec3>();

	private List<TutorialObjective> _detailedObjectives = new List<TutorialObjective>();

	private List<TutorialObjective> _tutorialObjectives = new List<TutorialObjective>();

	public Action UIStartTimer;

	public Func<float> UIEndTimer;

	public Action<string> TimerTick;

	public Action<TextObject> CurrentObjectiveTick;

	public Action<MouseObjectives> CurrentMouseObjectiveTick;

	public Action<List<TutorialObjective>> AllObjectivesTick;

	private static bool _updateObjectivesWillBeCalled;

	private Agent _brotherConversationAgent;

	public TextObject InitialCurrentObjective { get; private set; }

	public override void OnCreated()
	{
		base.OnCreated();
		base.Mission.DoesMissionRequireCivilianEquipment = false;
	}

	public override void AfterStart()
	{
		base.AfterStart();
		base.Mission.IsInventoryAccessible = false;
		base.Mission.IsQuestScreenAccessible = false;
		base.Mission.IsCharacterWindowAccessible = false;
		base.Mission.IsPartyWindowAccessible = false;
		base.Mission.IsKingdomWindowAccessible = false;
		base.Mission.IsClanWindowAccessible = false;
		base.Mission.IsEncyclopediaWindowAccessible = false;
		base.Mission.IsBannerWindowAccessible = false;
		_missionConversationHandler = base.Mission.GetMissionBehavior<MissionConversationLogic>();
		base.Mission.GetMissionBehavior<MissionAgentHandler>().SpawnPlayer(base.Mission.DoesMissionRequireCivilianEquipment, true, false, false, false, "");
		LoadTutorialScores();
		SpawnConversationBrother();
		CollectWeaponsAndObjectives();
		InitializeMeleeTraining();
		InitializeMountedTraining();
		InitializeAdvancedMeleeTraining();
		InitializeBowTraining();
		MakeAllAgentsImmortal();
		SetHorseMountable(mountable: false);
		InitialCurrentObjective = new TextObject("{=BTY2aZCt}Enter a training area.");
		_playerCampaignHealth = Agent.Main.Health;
	}

	private void LoadTutorialScores()
	{
		_tutorialScores = StoryModeManager.Current.MainStoryLine.GetTutorialScores();
	}

	protected override void OnEndMission()
	{
		base.OnEndMission();
		Agent.Main.Health = _playerCampaignHealth;
		StoryModeManager.Current.MainStoryLine.SetTutorialScores(_tutorialScores);
	}

	public override void OnRenderingStarted()
	{
		base.OnRenderingStarted();
		if (_brotherConversationAgent != null)
		{
			base.Mission.GetMissionBehavior<MissionConversationLogic>().StartConversation(_brotherConversationAgent, false, true);
		}
	}

	public override void OnMissionTick(float dt)
	{
		TrainingAreaUpdate();
		UpdateHorseBehavior();
		UpdateBowTraining();
		UpdateMountedAIBehavior();
		if (_updateObjectivesWillBeCalled)
		{
			UpdateObjectives();
		}
		for (int num = _delayedActions.Count - 1; num >= 0; num--)
		{
			if (_delayedActions[num].Update())
			{
				_delayedActions.RemoveAt(num);
			}
		}
	}

	private void UpdateObjectives()
	{
		if (_trainingSubTypeIndex == -1 || _showTutorialObjectivesAnyway)
		{
			AllObjectivesTick?.Invoke(_tutorialObjectives);
		}
		else
		{
			AllObjectivesTick?.Invoke(_detailedObjectives);
		}
		_updateObjectivesWillBeCalled = false;
	}

	private int GetSelectedTrainingSubTypeIndex()
	{
		TrainingIcon activeTrainingIcon = _activeTutorialArea.GetActiveTrainingIcon();
		if (activeTrainingIcon != null)
		{
			EnableAllTrainingIcons();
			activeTrainingIcon.DisableIcon();
			_activeTrainingSubTypeTag = activeTrainingIcon.GetTrainingSubTypeTag();
			return _activeTutorialArea.GetIndexFromTag(activeTrainingIcon.GetTrainingSubTypeTag());
		}
		return -1;
	}

	private string GetHighlightedWeaponRack()
	{
		foreach (TrainingIcon item in _activeTutorialArea.TrainingIconsReadOnly)
		{
			if (item.Focused)
			{
				return item.GetTrainingSubTypeTag();
			}
		}
		return "";
	}

	private void EnableAllTrainingIcons()
	{
		foreach (TrainingIcon item in _activeTutorialArea.TrainingIconsReadOnly)
		{
			item.EnableIcon();
		}
	}

	private void TrainingAreaUpdate()
	{
		CheckMainAgentEquipment();
		string[] volumeBoxTags;
		if (_activeTutorialArea != null)
		{
			if (_activeTutorialArea.IsPositionInsideTutorialArea(Agent.Main.Position, out volumeBoxTags))
			{
				InTrainingArea();
				if (_trainingSubTypeIndex != -1)
				{
					_activeTutorialArea.CheckWeapons(_trainingSubTypeIndex);
				}
			}
			else
			{
				OnTrainingAreaExit(enableTrainingIcons: true);
				_activeTutorialArea = null;
			}
		}
		else
		{
			foreach (TutorialArea trainingArea in _trainingAreas)
			{
				if (trainingArea.IsPositionInsideTutorialArea(Agent.Main.Position, out volumeBoxTags))
				{
					_activeTutorialArea = trainingArea;
					OnTrainingAreaEnter();
					break;
				}
			}
		}
		UpdateConversationPermission();
	}

	private void UpdateConversationPermission()
	{
		if (_brotherConversationAgent == null || Mission.Current.MainAgent == null || (_brotherConversationAgent.Position - Mission.Current.MainAgent.Position).LengthSquared > 4f)
		{
			_missionConversationHandler.DisableStartConversation(true);
		}
		else
		{
			_missionConversationHandler.DisableStartConversation(false);
		}
	}

	private void ResetTrainingArea()
	{
		OnTrainingAreaExit(enableTrainingIcons: true);
		OnTrainingAreaEnter();
	}

	private void OnTrainingAreaExit(bool enableTrainingIcons)
	{
		_activeTutorialArea.MarkTrainingIcons(mark: false);
		TutorialObjective tutorialObjective = _tutorialObjectives.Find((TutorialObjective x) => x.Id == _activeTutorialArea.TypeOfTraining.ToString());
		tutorialObjective.SetActive(isActive: false);
		tutorialObjective.SetAllSubTasksInactive();
		DropAllWeaponsOfMainAgent();
		SpecialTrainingAreaExit(_activeTutorialArea.TypeOfTraining);
		_activeTutorialArea.DeactivateAllWeapons(resetDestructibles: true);
		_trainingProgress = 0;
		_trainingSubTypeIndex = -1;
		EnableAllTrainingIcons();
		if (CheckAllObjectivesFinished())
		{
			CurrentObjectiveTick(new TextObject("{=77TavbOY}You have completed all tutorials. You can always come back to improve your score."));
			if (!_courseFinished)
			{
				_courseFinished = true;
				Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/finish_course"), Agent.Main.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
			}
		}
		else
		{
			CurrentObjectiveTick(new TextObject("{=BTY2aZCt}Enter a training area."));
		}
		TickMouseObjective(MouseObjectives.None);
		UIEndTimer();
	}

	private bool CheckAllObjectivesFinished()
	{
		foreach (TutorialObjective tutorialObjective in _tutorialObjectives)
		{
			if (!tutorialObjective.IsFinished)
			{
				return false;
			}
		}
		return true;
	}

	private void OnTrainingAreaEnter()
	{
		_tutorialObjectives.Find((TutorialObjective x) => x.Id == _activeTutorialArea.TypeOfTraining.ToString()).SetActive(isActive: true);
		DropAllWeaponsOfMainAgent();
		_trainingProgress = 0;
		_trainingSubTypeIndex = -1;
		SpecialTrainingAreaEnter(_activeTutorialArea.TypeOfTraining);
		CurrentObjectiveTick(new TextObject("{=WIUbM9Hc}Choose a weapon to begin training."));
		_activeTutorialArea.MarkTrainingIcons(mark: true);
	}

	private void InTrainingArea()
	{
		int selectedTrainingSubTypeIndex = GetSelectedTrainingSubTypeIndex();
		if (selectedTrainingSubTypeIndex >= 0)
		{
			OnStartTraining(selectedTrainingSubTypeIndex);
		}
		else
		{
			string highlightedWeaponRack = GetHighlightedWeaponRack();
			if (highlightedWeaponRack != "")
			{
				foreach (TutorialObjective tutorialObjective in _tutorialObjectives)
				{
					if (!(tutorialObjective.Id == _activeTutorialArea.TypeOfTraining.ToString()))
					{
						continue;
					}
					foreach (TutorialObjective subTask in tutorialObjective.SubTasks)
					{
						if (subTask.Id == highlightedWeaponRack)
						{
							subTask.SetActive(isActive: true);
						}
						else
						{
							subTask.SetActive(isActive: false);
						}
					}
					break;
				}
			}
			else
			{
				_tutorialObjectives.Find((TutorialObjective x) => x.Id == _activeTutorialArea.TypeOfTraining.ToString()).SetAllSubTasksInactive();
			}
		}
		SpecialInTrainingAreaUpdate(_activeTutorialArea.TypeOfTraining);
	}

	private void OnStartTraining(int index)
	{
		_showTutorialObjectivesAnyway = false;
		_activeTutorialArea.MarkTrainingIcons(mark: false);
		SpecialTrainingStart(_activeTutorialArea.TypeOfTraining);
		TickMouseObjective(MouseObjectives.None);
		UIEndTimer();
		DropAllWeaponsOfMainAgent();
		_activeTutorialArea.DeactivateAllWeapons(resetDestructibles: true);
		_activeTutorialArea.ActivateTaggedWeapons(index);
		_activeTutorialArea.EquipWeaponsToPlayer(index);
		_trainingProgress = 1;
		_trainingSubTypeIndex = index;
		UpdateObjectives();
	}

	private void EndTraining()
	{
		_trainingProgress = 0;
		_trainingSubTypeIndex = -1;
		_activeTutorialArea = null;
	}

	private void SuccessfullyFinishTraining(float score)
	{
		_tutorialObjectives.Find((TutorialObjective x) => x.Id == _activeTutorialArea.TypeOfTraining.ToString()).FinishSubTask(_activeTrainingSubTypeTag, score);
		if (_tutorialScores.ContainsKey(_activeTrainingSubTypeTag))
		{
			_tutorialScores[_activeTrainingSubTypeTag] = score;
		}
		else
		{
			_tutorialScores.Add(_activeTrainingSubTypeTag, score);
		}
		_activeTutorialArea.MarkTrainingIcons(mark: true);
		Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/finish_task"), Agent.Main.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
		_showTutorialObjectivesAnyway = true;
		UpdateObjectives();
	}

	private void RefillAmmoOfAgent(Agent agent)
	{
		for (EquipmentIndex equipmentIndex = EquipmentIndex.WeaponItemBeginSlot; equipmentIndex < EquipmentIndex.NumAllWeaponSlots; equipmentIndex++)
		{
			if (agent.Equipment[equipmentIndex].IsAnyConsumable() && agent.Equipment[equipmentIndex].Amount <= 1)
			{
				agent.SetWeaponAmountInSlot(equipmentIndex, agent.Equipment[equipmentIndex].ModifiedMaxAmount, enforcePrimaryItem: true);
			}
		}
	}

	private void SpecialTrainingAreaExit(TutorialArea.TrainingType trainingType)
	{
		if (_trainingSubTypeIndex != -1)
		{
			_activeTutorialArea.ResetBreakables(_trainingSubTypeIndex);
		}
		switch (trainingType)
		{
		case TutorialArea.TrainingType.Bow:
			OnBowTrainingExit();
			break;
		case TutorialArea.TrainingType.Mounted:
			OnMountedTrainingExit();
			break;
		case TutorialArea.TrainingType.AdvancedMelee:
			OnAdvancedTrainingExit();
			break;
		case TutorialArea.TrainingType.Melee:
			break;
		}
	}

	private void SpecialTrainingAreaEnter(TutorialArea.TrainingType trainingType)
	{
		switch (trainingType)
		{
		case TutorialArea.TrainingType.Bow:
			OnBowTrainingEnter();
			break;
		case TutorialArea.TrainingType.AdvancedMelee:
			OnAdvancedTrainingAreaEnter();
			break;
		case TutorialArea.TrainingType.Melee:
		case TutorialArea.TrainingType.Mounted:
			break;
		}
	}

	private void SpecialTrainingStart(TutorialArea.TrainingType trainingType)
	{
		if (_trainingSubTypeIndex != -1)
		{
			_activeTutorialArea.ResetBreakables(_trainingSubTypeIndex);
		}
		switch (trainingType)
		{
		case TutorialArea.TrainingType.Bow:
			OnBowTrainingStart();
			break;
		case TutorialArea.TrainingType.Mounted:
			OnMountedTrainingStart();
			break;
		case TutorialArea.TrainingType.AdvancedMelee:
			OnAdvancedTrainingStart();
			break;
		case TutorialArea.TrainingType.Melee:
			break;
		}
	}

	private void SpecialInTrainingAreaUpdate(TutorialArea.TrainingType trainingType)
	{
		switch (trainingType)
		{
		case TutorialArea.TrainingType.Bow:
			BowInTrainingAreaUpdate();
			break;
		case TutorialArea.TrainingType.Melee:
			MeleeTrainingUpdate();
			break;
		case TutorialArea.TrainingType.Mounted:
			MountedTrainingUpdate();
			break;
		case TutorialArea.TrainingType.AdvancedMelee:
			AdvancedMeleeTrainingUpdate();
			break;
		}
	}

	private void DropAllWeaponsOfMainAgent()
	{
		Mission.Current.MainAgent.SetActionChannel(1, ActionIndexCache.act_none, ignorePriority: true, 0uL);
		for (EquipmentIndex equipmentIndex = EquipmentIndex.WeaponItemBeginSlot; equipmentIndex <= EquipmentIndex.Weapon3; equipmentIndex++)
		{
			if (!Mission.Current.MainAgent.Equipment[equipmentIndex].IsEmpty)
			{
				Mission.Current.MainAgent.DropItem(equipmentIndex);
			}
		}
	}

	private void RemoveAllWeaponsFromMainAgent()
	{
		for (EquipmentIndex equipmentIndex = EquipmentIndex.WeaponItemBeginSlot; equipmentIndex <= EquipmentIndex.Weapon3; equipmentIndex++)
		{
			if (!Mission.Current.MainAgent.Equipment[equipmentIndex].IsEmpty)
			{
				Mission.Current.MainAgent.RemoveEquippedWeapon(equipmentIndex);
			}
		}
	}

	private void CollectWeaponsAndObjectives()
	{
		List<GameEntity> entities = new List<GameEntity>();
		Mission.Current.Scene.GetEntities(ref entities);
		foreach (GameEntity item in entities)
		{
			if (item.HasTag("bow_training_shooting_position"))
			{
				_shootingPosition = item;
			}
			if (item.GetFirstScriptOfType<TutorialArea>() != null)
			{
				_trainingAreas.Add(item.GetFirstScriptOfType<TutorialArea>());
				_tutorialObjectives.Add(new TutorialObjective(_trainingAreas[_trainingAreas.Count - 1].TypeOfTraining.ToString()));
				foreach (string subTrainingTag in _trainingAreas[_trainingAreas.Count - 1].GetSubTrainingTags())
				{
					_tutorialObjectives[_tutorialObjectives.Count - 1].AddSubTask(new TutorialObjective(subTrainingTag));
					if (_tutorialScores.ContainsKey(subTrainingTag))
					{
						_tutorialObjectives[_tutorialObjectives.Count - 1].SubTasks.Last().RestoreScoreFromSave(_tutorialScores[subTrainingTag]);
					}
				}
			}
			if (item.HasTag("mounted_checkpoint") && item.GetFirstScriptOfType<VolumeBox>() != null)
			{
				bool flag = false;
				for (int i = 0; i < _checkpoints.Count; i++)
				{
					if (int.Parse(item.Tags[1]) < int.Parse(_checkpoints[i].Item1.GameEntity.Tags[1]))
					{
						_checkpoints.Insert(i, ValueTuple.Create(item.GetFirstScriptOfType<VolumeBox>(), item2: false));
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					_checkpoints.Add(ValueTuple.Create(item.GetFirstScriptOfType<VolumeBox>(), item2: false));
				}
			}
			if (!item.HasScriptOfType<DestructableComponent>())
			{
				continue;
			}
			if (item.HasTag("_ranged_npc_target"))
			{
				_targetsForRangedNpc.Add(item.GetFirstScriptOfType<DestructableComponent>());
			}
			else if (item.HasTag("_mounted_ai_target"))
			{
				int num = int.Parse(item.Tags[1]);
				while (num > _mountedAITargets.Count - 1)
				{
					_mountedAITargets.Add(null);
				}
				_mountedAITargets[num] = item.GetFirstScriptOfType<DestructableComponent>();
			}
		}
	}

	private void MakeAllAgentsImmortal()
	{
		foreach (Agent agent in Mission.Current.Agents)
		{
			agent.SetMortalityState(Agent.MortalityState.Immortal);
			if (!agent.IsMount)
			{
				agent.WieldInitialWeapons();
			}
			_agents.Add(agent);
		}
	}

	private bool HasAllWeaponsPicked()
	{
		return _activeTutorialArea.HasMainAgentPickedAll(_trainingSubTypeIndex);
	}

	private void CheckMainAgentEquipment()
	{
		if (_trainingSubTypeIndex == -1)
		{
			RemoveAllWeaponsFromMainAgent();
		}
		else
		{
			_activeTutorialArea.CheckMainAgentEquipment(_trainingSubTypeIndex);
		}
	}

	private void StartTimer()
	{
		_beginningTime = base.Mission.CurrentTime;
	}

	private void EndTimer()
	{
		_timeScore = base.Mission.CurrentTime - _beginningTime;
	}

	private void SpawnConversationBrother()
	{
		if (!TutorialPhase.Instance.TalkedWithBrotherForTheFirstTime)
		{
			WorldFrame worldFrame = new WorldFrame(Agent.Main.Frame.rotation, new WorldPosition(base.Mission.Scene, Agent.Main.Position));
			worldFrame.Origin.SetVec2(Agent.Main.GetWorldFrame().Origin.AsVec2 + Vec2.Forward * 3f);
			worldFrame.Rotation.RotateAboutUp((float)Math.PI);
			MatrixFrame matrixFrame = worldFrame.ToGroundMatrixFrame();
			CharacterObject characterObject = StoryModeHeroes.ElderBrother.CharacterObject;
			AgentBuildData agentBuildData = new AgentBuildData(characterObject).Team(base.Mission.SpectatorTeam).InitialPosition(in matrixFrame.origin);
			Vec2 direction = matrixFrame.rotation.f.AsVec2.Normalized();
			AgentBuildData agentBuildData2 = agentBuildData.InitialDirection(in direction).CivilianEquipment(civilianEquipment: false).NoHorses(noHorses: true)
				.NoWeapons(noWeapons: true)
				.ClothingColor1(base.Mission.PlayerTeam.Color)
				.ClothingColor2(base.Mission.PlayerTeam.Color2)
				.TroopOrigin(new PartyAgentOrigin(PartyBase.MainParty, characterObject))
				.MountKey(MountCreationKey.GetRandomMountKeyString(characterObject.Equipment[EquipmentIndex.ArmorItemEndSlot].Item, characterObject.GetMountKeySeed()));
			_brotherConversationAgent = base.Mission.SpawnAgent(agentBuildData2);
		}
	}

	private void InitializeBowTraining()
	{
		_shootingPosition.SetVisibilityExcludeParents(visible: false);
		_bowNpc = SpawnBowNPC();
		_rangedNpcSpawnPosition = _bowNpc.GetWorldPosition();
		_bowNpc.SetAIBehaviorValues(HumanAIComponent.AISimpleBehaviorKind.Ranged, 0f, 6f, 0f, 66f, 0f);
		_bowNpc.SetAIBehaviorValues(HumanAIComponent.AISimpleBehaviorKind.GoToPos, 0f, 6f, 0f, 66f, 0f);
		_bowNpc.SetAIBehaviorValues(HumanAIComponent.AISimpleBehaviorKind.AttackEntityRanged, 66f, 6f, 666f, 120f, 6f);
		GiveMoveOrderToRangedAgent(_shootingPosition.GlobalPosition.ToWorldPosition(), _shootingPosition.GetGlobalFrame().rotation.f.NormalizedCopy());
	}

	private void GiveMoveOrderToRangedAgent(WorldPosition worldPosition, Vec3 rotation)
	{
		if (!worldPosition.AsVec2.NearlyEquals(_rangedTargetPosition.AsVec2, 0.001f) || !worldPosition.GetGroundVec3().NearlyEquals(_rangedTargetPosition.GetGroundVec3(), 0.001f) || !rotation.NearlyEquals(_rangedTargetRotation))
		{
			_rangedTargetPosition = worldPosition;
			_rangedTargetRotation = rotation;
			_bowNpc.SetWatchState(Agent.WatchState.Patrolling);
			_targetPositionSet = false;
			_delayedActions.Add(new DelayedAction(delegate
			{
				_bowNpc.ClearTargetFrame();
				_bowNpc.SetScriptedPositionAndDirection(ref worldPosition, _rangedTargetRotation.AsVec2.RotationInRadians, addHumanLikeDelay: true);
			}, 2f, "move order for ranged npc."));
		}
	}

	private GameEntity GetValidTarget()
	{
		foreach (DestructableComponent item in _targetsForRangedNpc)
		{
			if (!item.IsDestroyed)
			{
				_lastTargetGiven = item;
				return _lastTargetGiven.GameEntity;
			}
		}
		foreach (DestructableComponent item2 in _targetsForRangedNpc)
		{
			item2.Reset();
		}
		_lastTargetGiven = _targetsForRangedNpc[0];
		return _lastTargetGiven.GameEntity;
	}

	private void UpdateBowTraining()
	{
		if ((_bowNpc.MovementFlags & Agent.MovementControlFlag.MoveMask) != 0 || !((_rangedTargetPosition.GetGroundVec3() - _bowNpc.Position).LengthSquared < 0.16000001f))
		{
			return;
		}
		if (!_targetPositionSet)
		{
			_bowNpc.DisableScriptedMovement();
			_bowNpc.SetTargetPositionAndDirection(_bowNpc.Position.AsVec2, _rangedTargetRotation);
			_targetPositionSet = true;
			if ((_bowNpc.Position - _shootingPosition.GlobalPosition).LengthSquared > (_bowNpc.Position - _rangedNpcSpawnPosition.GetGroundVec3()).LengthSquared)
			{
				_atShootingPosition = false;
				return;
			}
			_bowNpc.SetWatchState(Agent.WatchState.Alarmed);
			_bowNpc.SetScriptedTargetEntityAndPosition(GetValidTarget(), _bowNpc.GetWorldPosition());
			_atShootingPosition = true;
		}
		else if (_atShootingPosition && _lastTargetGiven.IsDestroyed)
		{
			_bowNpc.SetScriptedTargetEntityAndPosition(GetValidTarget(), _bowNpc.GetWorldPosition());
		}
	}

	private void OnBowTrainingEnter()
	{
	}

	private Agent SpawnBowNPC()
	{
		MatrixFrame matrixFrame = MatrixFrame.Identity;
		_rangedNpcSpawnPoint = base.Mission.Scene.FindEntityWithTag("spawner_ranged_npc_tag");
		if (_rangedNpcSpawnPoint != null)
		{
			matrixFrame = _rangedNpcSpawnPoint.GetGlobalFrame();
			matrixFrame.rotation.OrthonormalizeAccordingToForwardAndKeepUpAsZAxis();
		}
		else
		{
			Debug.FailedAssert("There are no spawn points for bow npc.", "C:\\Develop\\MB3\\Source\\Bannerlord\\StoryMode\\Missions\\TrainingFieldMissionController.cs", "SpawnBowNPC", 1129);
		}
		Location locationWithId = LocationComplex.Current.GetLocationWithId("training_field");
		CharacterObject @object = Game.Current.ObjectManager.GetObject<CharacterObject>("tutorial_npc_ranged");
		Monster baseMonsterFromRace = TaleWorlds.Core.FaceGen.GetBaseMonsterFromRace(@object.Race);
		AgentData agentData = new AgentData(new PartyAgentOrigin(PartyBase.MainParty, @object)).Monster(baseMonsterFromRace).NoHorses(noHorses: true);
		locationWithId.AddCharacter(new LocationCharacter(agentData, SandBoxManager.Instance.AgentBehaviorManager.AddFixedCharacterBehaviors, null, fixedLocation: true, LocationCharacter.CharacterRelations.Friendly, null, useCivilianEquipment: true, isFixedCharacter: false, null, isHidden: false, isVisualTracked: true));
		AgentBuildData agentBuildData = new AgentBuildData(@object).Team(base.Mission.PlayerTeam).InitialPosition(in matrixFrame.origin);
		Vec2 direction = matrixFrame.rotation.f.AsVec2;
		AgentBuildData agentBuildData2 = agentBuildData.InitialDirection(in direction).CivilianEquipment(civilianEquipment: false).NoHorses(noHorses: true)
			.NoWeapons(noWeapons: false)
			.ClothingColor1(base.Mission.PlayerTeam.Color)
			.ClothingColor2(base.Mission.PlayerTeam.Color2)
			.TroopOrigin(new PartyAgentOrigin(PartyBase.MainParty, @object))
			.MountKey(MountCreationKey.GetRandomMountKeyString(@object.Equipment[EquipmentIndex.ArmorItemEndSlot].Item, @object.GetMountKeySeed()))
			.Controller(Agent.ControllerType.AI);
		Agent agent = base.Mission.SpawnAgent(agentBuildData2);
		agent.SetTeam(Mission.Current.PlayerAllyTeam, sync: false);
		return agent;
	}

	private void BowInTrainingAreaUpdate()
	{
		if (_trainingProgress == 1)
		{
			if (HasAllWeaponsPicked())
			{
				_rangedLastBrokenTargetCount = 0;
				LoadCrossbowForStarting();
				_trainingProgress++;
				CurrentObjectiveTick(new TextObject("{=kwW6v202}Go to shooting position"));
				_shootingPosition.SetVisibilityExcludeParents(visible: true);
				_detailedObjectives = _rangedObjectives.ConvertAll((TutorialObjective x) => new TutorialObjective(x.Id));
				_detailedObjectives[1].SetTextVariableOfName("HIT", _activeTutorialArea.GetBrokenBreakableCount(_trainingSubTypeIndex));
				_detailedObjectives[1].SetTextVariableOfName("ALL", _activeTutorialArea.GetBreakablesCount(_trainingSubTypeIndex));
				_detailedObjectives[0].SetActive(isActive: true);
				Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/vo/archery/pick_" + _trainingSubTypeIndex), Agent.Main.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
			}
		}
		else if (_trainingProgress == 2)
		{
			if ((_shootingPosition.GetGlobalFrame().origin - Agent.Main.Position).LengthSquared < 4f)
			{
				_trainingProgress++;
				_shootingPosition.SetVisibilityExcludeParents(visible: false);
				_activeTutorialArea.MarkAllTargets(_trainingSubTypeIndex, mark: true);
				_remainingTargetText.SetTextVariable("REMAINING_TARGET", _activeTutorialArea.GetUnbrokenBreakableCount(_trainingSubTypeIndex));
				CurrentObjectiveTick(_remainingTargetText);
				_detailedObjectives[0].FinishTask();
				_detailedObjectives[1].SetActive(isActive: true);
			}
		}
		else if (_trainingProgress == 4)
		{
			int brokenBreakableCount = _activeTutorialArea.GetBrokenBreakableCount(_trainingSubTypeIndex);
			_remainingTargetText.SetTextVariable("REMAINING_TARGET", _activeTutorialArea.GetUnbrokenBreakableCount(_trainingSubTypeIndex));
			CurrentObjectiveTick(_remainingTargetText);
			_detailedObjectives[1].SetTextVariableOfName("HIT", brokenBreakableCount);
			if (brokenBreakableCount != _rangedLastBrokenTargetCount)
			{
				_rangedLastBrokenTargetCount = brokenBreakableCount;
				_activeTutorialArea.ResetMarkingTargetTimers(_trainingSubTypeIndex);
			}
			if (MBRandom.NondeterministicRandomInt % 4 == 3)
			{
				Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/vo/archery/hit_target"), Agent.Main.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
			}
			if (_activeTutorialArea.AllBreakablesAreBroken(_trainingSubTypeIndex))
			{
				_detailedObjectives[1].FinishTask();
				_trainingProgress++;
				BowTrainingEndedSuccessfully();
			}
		}
	}

	public void LoadCrossbowForStarting()
	{
		for (EquipmentIndex equipmentIndex = EquipmentIndex.WeaponItemBeginSlot; equipmentIndex < EquipmentIndex.NumAllWeaponSlots; equipmentIndex++)
		{
			MissionWeapon missionWeapon = Agent.Main.Equipment[equipmentIndex];
			if (!missionWeapon.IsEmpty && missionWeapon.Item.PrimaryWeapon.WeaponClass == WeaponClass.Crossbow && missionWeapon.Ammo == 0)
			{
				Agent.Main.Equipment.GetAmmoCountAndIndexOfType(missionWeapon.Item.Type, out var _, out var eIndex);
				Agent.Main.SetReloadAmmoInSlot(equipmentIndex, eIndex, 1);
				Agent.Main.SetWeaponReloadPhaseAsClient(equipmentIndex, missionWeapon.ReloadPhaseCount);
			}
		}
	}

	public override void OnAgentShootMissile(Agent shooterAgent, EquipmentIndex weaponIndex, Vec3 position, Vec3 velocity, Mat3 orientation, bool hasRigidBody, int forcedMissileIndex = -1)
	{
		base.OnAgentShootMissile(shooterAgent, weaponIndex, position, velocity, orientation, hasRigidBody, forcedMissileIndex);
		TutorialArea activeTutorialArea = _activeTutorialArea;
		if (activeTutorialArea != null && activeTutorialArea.TypeOfTraining == TutorialArea.TrainingType.Bow && _trainingProgress == 3)
		{
			_trainingProgress++;
			_activeTutorialArea.MakeDestructible(_trainingSubTypeIndex);
			UIStartTimer();
			CurrentObjectiveTick(new TextObject("{=9kGnzjrU}Timer Started."));
			StartTimer();
			Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/vo/archery/start_training"), Agent.Main.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
		}
		RefillAmmoOfAgent(shooterAgent);
	}

	private void BowTrainingEndedSuccessfully()
	{
		EndTimer();
		_activeTutorialArea.HideBoundaries();
		CurrentObjectiveTick(_trainingFinishedText);
		TextObject textObject = new TextObject("{=xVFupnFu}You've successfully hit all of the targets in ({TIME_SCORE}) seconds.");
		float score = UIEndTimer();
		textObject.SetTextVariable("TIME_SCORE", new TextObject(score.ToString("0.0")));
		MBInformationManager.AddQuickInformation(textObject);
		SuccessfullyFinishTraining(score);
		_shootingPosition.SetVisibilityExcludeParents(visible: false);
		Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/vo/archery/finish"), Agent.Main.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
	}

	private void OnBowTrainingStart()
	{
		_shootingPosition.SetVisibilityExcludeParents(visible: false);
		GiveMoveOrderToRangedAgent(_rangedNpcSpawnPoint.GlobalPosition.ToWorldPosition(), _rangedNpcSpawnPoint.GetGlobalFrame().rotation.f.NormalizedCopy());
		foreach (DestructableComponent item in _targetsForRangedNpc)
		{
			item.Reset();
			item.GameEntity.SetVisibilityExcludeParents(visible: false);
		}
	}

	private void OnBowTrainingExit()
	{
		_shootingPosition.SetVisibilityExcludeParents(visible: false);
		GiveMoveOrderToRangedAgent(_shootingPosition.GlobalPosition.ToWorldPosition(), _shootingPosition.GetGlobalFrame().rotation.f.NormalizedCopy());
		foreach (DestructableComponent item in _targetsForRangedNpc)
		{
			item.Reset();
			item.GameEntity.SetVisibilityExcludeParents(visible: true);
		}
	}

	private void InitializeAdvancedMeleeTraining()
	{
		_advancedMeleeTrainerEasy = SpawnAdvancedMeleeTrainerEasy();
		_advancedEasyMeleeTrainerDefaultPosition = _advancedMeleeTrainerEasy.GetWorldPosition();
		_advancedMeleeTrainerEasy.SetAgentFlags(_advancedMeleeTrainerEasy.GetAgentFlags() & ~AgentFlag.CanGetAlarmed);
		_advancedMeleeTrainerEasyInitialPosition = base.Mission.Scene.FindEntityWithTag("spawner_adv_melee_npc_easy").GetGlobalFrame();
		_advancedMeleeTrainerEasySecondPosition = base.Mission.Scene.FindEntityWithTag("adv_melee_npc_easy_second_pos").GetGlobalFrame();
		_advancedMeleeTrainerNormal = SpawnAdvancedMeleeTrainerNormal();
		_advancedNormalMeleeTrainerDefaultPosition = _advancedMeleeTrainerNormal.GetWorldPosition();
		_advancedMeleeTrainerNormal.SetAgentFlags(_advancedMeleeTrainerNormal.GetAgentFlags() & ~AgentFlag.CanGetAlarmed);
		_advancedMeleeTrainerNormalInitialPosition = base.Mission.Scene.FindEntityWithTag("spawner_adv_melee_npc_normal").GetGlobalFrame();
		_advancedMeleeTrainerNormalSecondPosition = base.Mission.Scene.FindEntityWithTag("adv_melee_npc_normal_second_pos").GetGlobalFrame();
		BeginNPCFight();
	}

	private Agent SpawnAdvancedMeleeTrainerEasy()
	{
		_advancedMeleeTrainerEasyInitialPosition = MatrixFrame.Identity;
		GameEntity gameEntity = base.Mission.Scene.FindEntityWithTag("spawner_adv_melee_npc_easy");
		if (gameEntity != null)
		{
			_advancedMeleeTrainerEasyInitialPosition = gameEntity.GetGlobalFrame();
			_advancedMeleeTrainerEasyInitialPosition.rotation.OrthonormalizeAccordingToForwardAndKeepUpAsZAxis();
		}
		else
		{
			Debug.FailedAssert("There are no spawn points for advanced melee trainer.", "C:\\Develop\\MB3\\Source\\Bannerlord\\StoryMode\\Missions\\TrainingFieldMissionController.cs", "SpawnAdvancedMeleeTrainerEasy", 1349);
		}
		CharacterObject @object = Game.Current.ObjectManager.GetObject<CharacterObject>("tutorial_npc_advanced_melee_easy");
		AgentBuildData agentBuildData = new AgentBuildData(@object).Team(base.Mission.PlayerTeam).InitialPosition(in _advancedMeleeTrainerEasyInitialPosition.origin);
		Vec2 direction = _advancedMeleeTrainerEasyInitialPosition.rotation.f.AsVec2;
		AgentBuildData agentBuildData2 = agentBuildData.InitialDirection(in direction).CivilianEquipment(civilianEquipment: false).NoHorses(noHorses: true)
			.NoWeapons(noWeapons: false)
			.ClothingColor1(base.Mission.PlayerTeam.Color)
			.ClothingColor2(base.Mission.PlayerTeam.Color2)
			.TroopOrigin(new PartyAgentOrigin(PartyBase.MainParty, @object))
			.MountKey(MountCreationKey.GetRandomMountKeyString(@object.Equipment[EquipmentIndex.ArmorItemEndSlot].Item, @object.GetMountKeySeed()))
			.Controller(Agent.ControllerType.AI);
		Agent agent = base.Mission.SpawnAgent(agentBuildData2);
		agent.SetTeam(Mission.Current.DefenderTeam, sync: false);
		return agent;
	}

	private Agent SpawnAdvancedMeleeTrainerNormal()
	{
		_advancedMeleeTrainerNormalInitialPosition = MatrixFrame.Identity;
		GameEntity gameEntity = base.Mission.Scene.FindEntityWithTag("spawner_adv_melee_npc_normal");
		if (gameEntity != null)
		{
			_advancedMeleeTrainerNormalInitialPosition = gameEntity.GetGlobalFrame();
			_advancedMeleeTrainerNormalInitialPosition.rotation.OrthonormalizeAccordingToForwardAndKeepUpAsZAxis();
		}
		else
		{
			Debug.FailedAssert("There are no spawn points for advanced melee trainer.", "C:\\Develop\\MB3\\Source\\Bannerlord\\StoryMode\\Missions\\TrainingFieldMissionController.cs", "SpawnAdvancedMeleeTrainerNormal", 1381);
		}
		CharacterObject @object = Game.Current.ObjectManager.GetObject<CharacterObject>("tutorial_npc_advanced_melee_normal");
		AgentBuildData agentBuildData = new AgentBuildData(@object).Team(base.Mission.PlayerTeam).InitialPosition(in _advancedMeleeTrainerNormalInitialPosition.origin);
		Vec2 direction = _advancedMeleeTrainerNormalInitialPosition.rotation.f.AsVec2;
		AgentBuildData agentBuildData2 = agentBuildData.InitialDirection(in direction).CivilianEquipment(civilianEquipment: false).NoHorses(noHorses: true)
			.NoWeapons(noWeapons: false)
			.ClothingColor1(base.Mission.PlayerTeam.Color)
			.ClothingColor2(base.Mission.PlayerTeam.Color2)
			.TroopOrigin(new PartyAgentOrigin(PartyBase.MainParty, @object))
			.MountKey(MountCreationKey.GetRandomMountKeyString(@object.Equipment[EquipmentIndex.ArmorItemEndSlot].Item, @object.GetMountKeySeed()))
			.Controller(Agent.ControllerType.AI);
		Agent agent = base.Mission.SpawnAgent(agentBuildData2);
		agent.SetTeam(Mission.Current.DefenderTeam, sync: false);
		return agent;
	}

	private void AdvancedMeleeTrainingUpdate()
	{
		if (_trainingSubTypeIndex == -1)
		{
			return;
		}
		if (_trainingProgress == 1)
		{
			if (HasAllWeaponsPicked())
			{
				_playerLeftBattleArea = false;
				_detailedObjectives = _advMeleeObjectives.ConvertAll((TutorialObjective x) => new TutorialObjective(x.Id));
				_detailedObjectives[0].SetActive(isActive: true);
				_trainingProgress++;
				CurrentObjectiveTick(new TextObject("{=HhuBPfJn}Go to the trainer."));
				WorldPosition scriptedPosition = _advancedMeleeTrainerNormalSecondPosition.origin.ToWorldPosition();
				_advancedMeleeTrainerNormal.SetScriptedPositionAndDirection(ref scriptedPosition, _advancedMeleeTrainerNormalSecondPosition.rotation.f.AsVec2.RotationInRadians, addHumanLikeDelay: true);
				_advancedMeleeTrainerNormal.SetTeam(Mission.Current.PlayerAllyTeam, sync: false);
				_advancedMeleeTrainerEasy.SetTeam(Mission.Current.PlayerAllyTeam, sync: false);
			}
		}
		else if (_trainingProgress == 2)
		{
			if ((_advancedMeleeTrainerEasy.Position - Agent.Main.Position).LengthSquared < 6f)
			{
				_detailedObjectives[0].FinishTask();
				_detailedObjectives[1].SetActive(isActive: true);
				_timer = base.Mission.CurrentTime;
				_trainingProgress++;
				_fightStartsIn.SetTextVariable("REMAINING_TIME", 3);
				CurrentObjectiveTick(_fightStartsIn);
			}
		}
		else if (_trainingProgress == 3)
		{
			if (base.Mission.CurrentTime - _timer > 3f)
			{
				_playerHealth = Agent.Main.HealthLimit;
				_advancedMeleeTrainerEasyHealth = _advancedMeleeTrainerEasy.HealthLimit;
				_advancedMeleeTrainerNormal.SetTeam(Mission.Current.PlayerEnemyTeam, sync: false);
				_advancedMeleeTrainerEasy.SetTeam(Mission.Current.PlayerEnemyTeam, sync: false);
				_advancedMeleeTrainerEasy.SetWatchState(Agent.WatchState.Alarmed);
				_advancedMeleeTrainerEasy.DisableScriptedMovement();
				_trainingProgress++;
				CurrentObjectiveTick(new TextObject("{=4hdp6SK0}Defeat the trainer!"));
			}
			else if (base.Mission.CurrentTime - _timer > 2f)
			{
				_fightStartsIn.SetTextVariable("REMAINING_TIME", 1);
				CurrentObjectiveTick(_fightStartsIn);
			}
			else if (base.Mission.CurrentTime - _timer > 1f)
			{
				_fightStartsIn.SetTextVariable("REMAINING_TIME", 2);
				CurrentObjectiveTick(_fightStartsIn);
			}
		}
		else if (_trainingProgress == 4)
		{
			if (_playerHealth <= 1f)
			{
				_trainingProgress = 9;
				CurrentObjectiveTick(new TextObject("{=SvYCz6z6}You've lost. You can restart the training by interacting weapon rack."));
				_timer = base.Mission.CurrentTime;
				ActionIndexCache fallBackRiseAnimation = FallBackRiseAnimation;
				Agent.Main.SetActionChannel(0, fallBackRiseAnimation, ignorePriority: false, 0uL);
				Agent.Main.Health = 1.1f;
				Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/vo/fighting/player_lose"), _advancedMeleeTrainerNormal.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
				OnLost();
			}
			else if (_advancedMeleeTrainerEasyHealth <= 1f)
			{
				_detailedObjectives[1].FinishTask();
				_detailedObjectives[2].SetActive(isActive: true);
				CurrentObjectiveTick(new TextObject("{=ikhWkw7T}You've successfully defeated rookie trainer. Go to veteran trainer."));
				_timer = base.Mission.CurrentTime;
				_trainingProgress++;
				OnEasyTrainerBeaten();
				_advancedMeleeTrainerNormal.SetTeam(Mission.Current.PlayerAllyTeam, sync: false);
				_advancedMeleeTrainerEasy.SetTeam(Mission.Current.PlayerAllyTeam, sync: false);
				ActionIndexCache fallBackRiseAnimation2 = FallBackRiseAnimation;
				_advancedMeleeTrainerEasy.SetActionChannel(0, fallBackRiseAnimation2, ignorePriority: false, 0uL);
			}
			else
			{
				Agent.Main.Health = _playerHealth;
				CheckAndHandlePlayerInsideBattleArea();
			}
		}
		else if (_trainingProgress == 5)
		{
			if ((_advancedMeleeTrainerNormal.Position - Agent.Main.Position).LengthSquared < 6f && (_advancedMeleeTrainerNormal.Position - _advancedMeleeTrainerNormalInitialPosition.origin).LengthSquared < 6f)
			{
				_timer = base.Mission.CurrentTime;
				_trainingProgress++;
				_fightStartsIn.SetTextVariable("REMAINING_TIME", 3);
				CurrentObjectiveTick(_fightStartsIn);
			}
		}
		else if (_trainingProgress == 6)
		{
			if (base.Mission.CurrentTime - _timer > 3f)
			{
				_playerHealth = Agent.Main.HealthLimit;
				_advancedMeleeTrainerNormalHealth = _advancedMeleeTrainerNormal.HealthLimit;
				_advancedMeleeTrainerNormal.SetTeam(Mission.Current.PlayerEnemyTeam, sync: false);
				_advancedMeleeTrainerEasy.SetTeam(Mission.Current.PlayerEnemyTeam, sync: false);
				_advancedMeleeTrainerNormal.SetWatchState(Agent.WatchState.Alarmed);
				_advancedMeleeTrainerNormal.DisableScriptedMovement();
				_trainingProgress++;
				CurrentObjectiveTick(new TextObject("{=4hdp6SK0}Defeat the trainer!"));
			}
			else if (base.Mission.CurrentTime - _timer > 2f)
			{
				_fightStartsIn.SetTextVariable("REMAINING_TIME", 1);
				CurrentObjectiveTick(_fightStartsIn);
			}
			else if (base.Mission.CurrentTime - _timer > 1f)
			{
				_fightStartsIn.SetTextVariable("REMAINING_TIME", 2);
				CurrentObjectiveTick(_fightStartsIn);
			}
		}
		else if (_trainingProgress == 7)
		{
			if (_playerHealth <= 1f)
			{
				ResetTrainingArea();
				CurrentObjectiveTick(new TextObject("{=SvYCz6z6}You've lost. You can restart the training by interacting weapon rack."));
				_timer = base.Mission.CurrentTime;
				_trainingProgress++;
				ActionIndexCache fallBackRiseAnimation3 = FallBackRiseAnimation;
				Agent.Main.SetActionChannel(0, fallBackRiseAnimation3, ignorePriority: false, 0uL);
				Agent.Main.Health = 1.1f;
				OnLost();
			}
			else if (_advancedMeleeTrainerNormalHealth <= 1f)
			{
				_detailedObjectives[2].FinishTask();
				SuccessfullyFinishTraining(0f);
				CurrentObjectiveTick(new TextObject("{=1RaUauBS}You've successfully finished the training."));
				_timer = base.Mission.CurrentTime;
				_trainingProgress++;
				MakeTrainersPatrolling();
				ActionIndexCache fallBackRiseAnimation4 = FallBackRiseAnimation;
				_advancedMeleeTrainerNormal.SetActionChannel(0, fallBackRiseAnimation4, ignorePriority: false, 0uL);
				Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/vo/fighting/player_win"), _advancedMeleeTrainerNormal.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
			}
			else
			{
				Agent.Main.Health = _playerHealth;
				CheckAndHandlePlayerInsideBattleArea();
			}
		}
	}

	private void CheckAndHandlePlayerInsideBattleArea()
	{
		if (!_activeTutorialArea.IsPositionInsideTutorialArea(Agent.Main.Position, out var volumeBoxTags))
		{
			return;
		}
		if (string.IsNullOrEmpty(volumeBoxTags.FirstOrDefault((string x) => x == "battle_area")))
		{
			if (!_playerLeftBattleArea)
			{
				_playerLeftBattleArea = true;
				OnPlayerLeftBattleArea();
			}
		}
		else if (_playerLeftBattleArea)
		{
			_playerLeftBattleArea = false;
			OnPlayerReEnteredBattleArea();
		}
	}

	private void OnPlayerLeftBattleArea()
	{
		if (_trainingProgress == 4)
		{
			_advancedMeleeTrainerEasy.SetWatchState(Agent.WatchState.Patrolling);
			WorldPosition scriptedPosition = _advancedMeleeTrainerEasyInitialPosition.origin.ToWorldPosition();
			_advancedMeleeTrainerEasy.SetScriptedPositionAndDirection(ref scriptedPosition, _advancedMeleeTrainerEasySecondPosition.rotation.f.AsVec2.RotationInRadians, addHumanLikeDelay: true);
		}
		else if (_trainingProgress == 7)
		{
			_advancedMeleeTrainerNormal.SetWatchState(Agent.WatchState.Patrolling);
			WorldPosition scriptedPosition2 = _advancedMeleeTrainerNormalInitialPosition.origin.ToWorldPosition();
			_advancedMeleeTrainerNormal.SetScriptedPositionAndDirection(ref scriptedPosition2, _advancedMeleeTrainerNormalInitialPosition.rotation.f.AsVec2.RotationInRadians, addHumanLikeDelay: true);
		}
	}

	private void OnPlayerReEnteredBattleArea()
	{
		if (_trainingProgress == 4)
		{
			_advancedMeleeTrainerEasy.DisableScriptedMovement();
			_advancedMeleeTrainerEasy.SetWatchState(Agent.WatchState.Alarmed);
		}
		else if (_trainingProgress == 7)
		{
			_advancedMeleeTrainerNormal.DisableScriptedMovement();
			_advancedMeleeTrainerNormal.SetWatchState(Agent.WatchState.Alarmed);
		}
	}

	private void OnEasyTrainerBeaten()
	{
		_advancedMeleeTrainerEasy.SetWatchState(Agent.WatchState.Patrolling);
		WorldPosition scriptedPosition = _advancedMeleeTrainerEasySecondPosition.origin.ToWorldPosition();
		_advancedMeleeTrainerEasy.SetScriptedPositionAndDirection(ref scriptedPosition, _advancedMeleeTrainerEasySecondPosition.rotation.f.AsVec2.RotationInRadians, addHumanLikeDelay: true);
		_advancedMeleeTrainerNormal.SetWatchState(Agent.WatchState.Patrolling);
		WorldPosition scriptedPosition2 = _advancedMeleeTrainerNormalInitialPosition.origin.ToWorldPosition();
		_advancedMeleeTrainerNormal.SetScriptedPositionAndDirection(ref scriptedPosition2, _advancedMeleeTrainerNormalInitialPosition.rotation.f.AsVec2.RotationInRadians, addHumanLikeDelay: true);
		Agent.Main.Health = Agent.Main.HealthLimit;
	}

	private void MakeTrainersPatrolling()
	{
		WorldPosition scriptedPosition = _advancedMeleeTrainerEasyInitialPosition.origin.ToWorldPosition();
		_advancedMeleeTrainerEasy.SetWatchState(Agent.WatchState.Patrolling);
		_advancedMeleeTrainerEasy.SetTeam(Mission.Current.PlayerAllyTeam, sync: false);
		_advancedMeleeTrainerEasy.SetScriptedPositionAndDirection(ref scriptedPosition, _advancedMeleeTrainerEasyInitialPosition.rotation.f.AsVec2.RotationInRadians, addHumanLikeDelay: true);
		SetAgentDefensiveness(_advancedMeleeTrainerNormal, 0f);
		WorldPosition scriptedPosition2 = _advancedMeleeTrainerNormalInitialPosition.origin.ToWorldPosition();
		_advancedMeleeTrainerNormal.SetWatchState(Agent.WatchState.Patrolling);
		_advancedMeleeTrainerNormal.SetTeam(Mission.Current.PlayerAllyTeam, sync: false);
		_advancedMeleeTrainerNormal.SetScriptedPositionAndDirection(ref scriptedPosition2, _advancedMeleeTrainerNormalInitialPosition.rotation.f.AsVec2.RotationInRadians, addHumanLikeDelay: true);
		SetAgentDefensiveness(_advancedMeleeTrainerNormal, 0f);
		_delayedActions.Add(new DelayedAction(delegate
		{
			Agent.Main.Health = Agent.Main.HealthLimit;
		}, 1.5f, "Agent health recover after advanced melee fight"));
	}

	private void OnLost()
	{
		MakeTrainersPatrolling();
	}

	private void BeginNPCFight()
	{
		_advancedMeleeTrainerEasy.DisableScriptedMovement();
		_advancedMeleeTrainerEasy.SetWatchState(Agent.WatchState.Alarmed);
		_advancedMeleeTrainerEasy.SetTeam(Mission.Current.DefenderTeam, sync: false);
		SetAgentDefensiveness(_advancedMeleeTrainerEasy, 4f);
		_advancedMeleeTrainerNormal.DisableScriptedMovement();
		_advancedMeleeTrainerNormal.SetWatchState(Agent.WatchState.Alarmed);
		_advancedMeleeTrainerNormal.SetTeam(Mission.Current.AttackerTeam, sync: false);
		SetAgentDefensiveness(_advancedMeleeTrainerNormal, 4f);
	}

	private void OnAdvancedTrainingStart()
	{
		MakeTrainersPatrolling();
		Agent.Main.Health = Agent.Main.HealthLimit;
	}

	private void OnAdvancedTrainingExit()
	{
		Agent.Main.Health = Agent.Main.HealthLimit;
		BeginNPCFight();
	}

	private void OnAdvancedTrainingAreaEnter()
	{
		MakeTrainersPatrolling();
		Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/vo/fighting/greet"), _advancedMeleeTrainerNormal.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
	}

	private void SetAgentDefensiveness(Agent agent, float formationOrderDefensivenessFactor)
	{
		agent.Defensiveness = formationOrderDefensivenessFactor;
	}

	private void InitializeMeleeTraining()
	{
		MatrixFrame matrixFrame = MatrixFrame.Identity;
		GameEntity gameEntity = base.Mission.Scene.FindEntityWithTag("spawner_melee_npc");
		if (gameEntity != null)
		{
			matrixFrame = gameEntity.GetGlobalFrame();
			matrixFrame.rotation.OrthonormalizeAccordingToForwardAndKeepUpAsZAxis();
		}
		else
		{
			Debug.FailedAssert("There are no spawn points for basic melee trainer.", "C:\\Develop\\MB3\\Source\\Bannerlord\\StoryMode\\Missions\\TrainingFieldMissionController.cs", "InitializeMeleeTraining", 1739);
		}
		CharacterObject @object = Game.Current.ObjectManager.GetObject<CharacterObject>("tutorial_npc_basic_melee");
		AgentBuildData agentBuildData = new AgentBuildData(@object).Team(base.Mission.PlayerTeam).InitialPosition(in matrixFrame.origin);
		Vec2 direction = matrixFrame.rotation.f.AsVec2;
		AgentBuildData agentBuildData2 = agentBuildData.InitialDirection(in direction).CivilianEquipment(civilianEquipment: false).NoHorses(noHorses: true)
			.NoWeapons(noWeapons: false)
			.ClothingColor1(base.Mission.PlayerTeam.Color)
			.ClothingColor2(base.Mission.PlayerTeam.Color2)
			.TroopOrigin(new PartyAgentOrigin(PartyBase.MainParty, @object))
			.MountKey(MountCreationKey.GetRandomMountKeyString(@object.Equipment[EquipmentIndex.ArmorItemEndSlot].Item, @object.GetMountKeySeed()))
			.Controller(Agent.ControllerType.None);
		Agent agent = base.Mission.SpawnAgent(agentBuildData2);
		agent.SetTeam(Mission.Current.DefenderTeam, sync: false);
		_meleeTrainer = agent;
		_meleeTrainerDefaultPosition = _meleeTrainer.GetWorldPosition();
	}

	private void MeleeTrainingUpdate()
	{
		float lengthSquared = (_meleeTrainer.Position - _meleeTrainerDefaultPosition.GetGroundVec3()).LengthSquared;
		if (lengthSquared > 1f)
		{
			if (_meleeTrainer.MovementFlags == Agent.MovementControlFlag.DefendDown)
			{
				_meleeTrainer.MovementFlags &= ~Agent.MovementControlFlag.DefendDown;
			}
			else if ((_meleeTrainer.MovementFlags & Agent.MovementControlFlag.AttackMask) != 0)
			{
				_meleeTrainer.MovementFlags &= ~Agent.MovementControlFlag.AttackMask;
				_meleeTrainer.MovementFlags |= Agent.MovementControlFlag.DefendDown;
			}
			else
			{
				_meleeTrainer.SetTargetPosition(_meleeTrainerDefaultPosition.AsVec2);
			}
			TickMouseObjective(MouseObjectives.None);
		}
		else if (lengthSquared < 0.1f)
		{
			SwordTraining();
		}
	}

	private void SwordTraining()
	{
		if (_trainingProgress == 1)
		{
			if (HasAllWeaponsPicked())
			{
				_detailedObjectives = _meleeObjectives.ConvertAll((TutorialObjective x) => new TutorialObjective(x.Id));
				_detailedObjectives[1].SetTextVariableOfName("HIT", 0);
				_detailedObjectives[1].SetTextVariableOfName("ALL", 4);
				_detailedObjectives[2].SetTextVariableOfName("HIT", 0);
				_detailedObjectives[2].SetTextVariableOfName("ALL", 4);
				_detailedObjectives[0].SetActive(isActive: true);
				_trainingProgress++;
				CurrentObjectiveTick(new TextObject("{=Zb1uFhsY}Go to trainer."));
			}
			TickMouseObjective(MouseObjectives.None);
		}
		else if ((_meleeTrainer.Position - Agent.Main.Position).LengthSquared < 4f)
		{
			_meleeTrainer.SetTargetPositionAndDirection(_meleeTrainer.Position.AsVec2, Agent.Main.GetEyeGlobalPosition() - _meleeTrainer.GetWorldFrame().Rotation.s * 0.1f - _meleeTrainer.GetEyeGlobalPosition());
			if (_trainingProgress == 2)
			{
				_detailedObjectives[0].FinishTask();
				_detailedObjectives[1].SetActive(isActive: true);
				Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/vo/parrying/block_left"), _meleeTrainer.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
				CurrentObjectiveTick(new TextObject("{=Db98U6fF}Defend from left."));
				_trainingProgress++;
			}
			else if (_trainingProgress == 3)
			{
				if (base.Mission.CurrentTime - _timer > 2f && Agent.Main.GetCurrentActionDirection(1) == Agent.UsageDirection.DefendLeft && Agent.Main.GetCurrentActionProgress(1) > 0.1f && Agent.Main.GetCurrentActionType(1) != Agent.ActionCodeType.Guard)
				{
					_meleeTrainer.MovementFlags = (Agent.MovementControlFlag)0u;
					_timer = base.Mission.CurrentTime;
				}
				else
				{
					_meleeTrainer.MovementFlags = Agent.MovementControlFlag.AttackRight;
				}
				TickMouseObjective(MouseObjectives.DefendLeft);
			}
			else if (_trainingProgress == 4)
			{
				if (base.Mission.CurrentTime - _timer > 1.5f && Agent.Main.GetCurrentActionDirection(1) == Agent.UsageDirection.DefendRight && Agent.Main.GetCurrentActionProgress(1) > 0.1f && Agent.Main.GetCurrentActionType(1) != Agent.ActionCodeType.Guard)
				{
					_meleeTrainer.MovementFlags = (Agent.MovementControlFlag)0u;
					_timer = base.Mission.CurrentTime;
				}
				else
				{
					_meleeTrainer.MovementFlags = Agent.MovementControlFlag.AttackLeft;
				}
				TickMouseObjective(MouseObjectives.DefendRight);
			}
			else if (_trainingProgress == 5)
			{
				if (base.Mission.CurrentTime - _timer > 1.5f && Agent.Main.GetCurrentActionDirection(1) == Agent.UsageDirection.AttackEnd && Agent.Main.GetCurrentActionProgress(1) > 0.1f && Agent.Main.GetCurrentActionType(1) != Agent.ActionCodeType.Guard)
				{
					_meleeTrainer.MovementFlags = (Agent.MovementControlFlag)0u;
					_timer = base.Mission.CurrentTime;
				}
				else
				{
					_meleeTrainer.MovementFlags = Agent.MovementControlFlag.AttackUp;
				}
				TickMouseObjective(MouseObjectives.DefendUp);
			}
			else if (_trainingProgress == 6)
			{
				if (base.Mission.CurrentTime - _timer > 1.5f && Agent.Main.GetCurrentActionDirection(1) == Agent.UsageDirection.DefendDown && Agent.Main.GetCurrentActionProgress(1) > 0.1f && Agent.Main.GetCurrentActionType(1) != Agent.ActionCodeType.Guard)
				{
					_meleeTrainer.MovementFlags = (Agent.MovementControlFlag)0u;
					_timer = base.Mission.CurrentTime;
				}
				else
				{
					_meleeTrainer.MovementFlags = Agent.MovementControlFlag.AttackDown;
				}
				TickMouseObjective(MouseObjectives.DefendDown);
			}
			else if (_trainingProgress == 7)
			{
				_meleeTrainer.MovementFlags |= Agent.MovementControlFlag.DefendRight;
				TickMouseObjective(MouseObjectives.AttackLeft);
			}
			else if (_trainingProgress == 8)
			{
				if (base.Mission.CurrentTime - _timer > 1f)
				{
					_meleeTrainer.MovementFlags |= Agent.MovementControlFlag.DefendLeft;
				}
				TickMouseObjective(MouseObjectives.AttackRight);
			}
			else if (_trainingProgress == 9)
			{
				if (base.Mission.CurrentTime - _timer > 1f)
				{
					_meleeTrainer.MovementFlags |= Agent.MovementControlFlag.DefendUp;
				}
				TickMouseObjective(MouseObjectives.AttackUp);
			}
			else if (_trainingProgress == 10)
			{
				if (base.Mission.CurrentTime - _timer > 1f)
				{
					_meleeTrainer.MovementFlags |= Agent.MovementControlFlag.DefendDown;
				}
				TickMouseObjective(MouseObjectives.AttackDown);
			}
			else if (_trainingProgress == 11)
			{
				_meleeTrainer.MovementFlags = (Agent.MovementControlFlag)0u;
				_trainingProgress++;
				Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/vo/parrying/praise"), _meleeTrainer.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
				SuccessfullyFinishTraining(0f);
			}
		}
		else
		{
			TickMouseObjective(MouseObjectives.None);
			if (_meleeTrainer.MovementFlags == Agent.MovementControlFlag.DefendDown)
			{
				_meleeTrainer.MovementFlags &= ~Agent.MovementControlFlag.DefendDown;
			}
			else if ((_meleeTrainer.MovementFlags & Agent.MovementControlFlag.AttackMask) != 0)
			{
				_meleeTrainer.MovementFlags &= ~Agent.MovementControlFlag.AttackMask;
				_meleeTrainer.MovementFlags |= Agent.MovementControlFlag.DefendDown;
			}
		}
	}

	private void ShieldTraining()
	{
		if (_trainingProgress == 1)
		{
			if (HasAllWeaponsPicked())
			{
				_trainingProgress++;
				MBInformationManager.AddQuickInformation(new TextObject("{=Zb1uFhsY}Go to trainer."));
			}
		}
		else if ((_meleeTrainer.Position - Agent.Main.Position).LengthSquared < 3f)
		{
			if (_trainingProgress == 2)
			{
				_meleeTrainer.SetLookAgent(Agent.Main);
				if ((_meleeTrainer.Position - Agent.Main.Position).LengthSquared < 1.5f)
				{
					MBInformationManager.AddQuickInformation(new TextObject("{=WysXGbM6}Right click to defend"));
					_trainingProgress++;
				}
			}
			else if (_trainingProgress == 3)
			{
				if (base.Mission.CurrentTime - _timer > 2f && (Agent.Main.MovementFlags & Agent.MovementControlFlag.DefendMask) != 0)
				{
					_meleeTrainer.MovementFlags = (Agent.MovementControlFlag)0u;
					_timer = base.Mission.CurrentTime;
				}
				else
				{
					_meleeTrainer.MovementFlags = Agent.MovementControlFlag.AttackLeft;
				}
			}
			else if (_trainingProgress == 4)
			{
				if (base.Mission.CurrentTime - _timer > 2f && (Agent.Main.MovementFlags & Agent.MovementControlFlag.DefendMask) != 0)
				{
					_meleeTrainer.MovementFlags = (Agent.MovementControlFlag)0u;
					_timer = base.Mission.CurrentTime;
				}
				else
				{
					_meleeTrainer.MovementFlags = Agent.MovementControlFlag.AttackRight;
				}
			}
			else if (_trainingProgress == 5)
			{
				_meleeTrainer.MovementFlags = (Agent.MovementControlFlag)0u;
			}
		}
		else if (_meleeTrainer.MovementFlags == Agent.MovementControlFlag.DefendDown)
		{
			_meleeTrainer.MovementFlags &= ~Agent.MovementControlFlag.DefendDown;
		}
		else if ((_meleeTrainer.MovementFlags & Agent.MovementControlFlag.AttackMask) != 0)
		{
			_meleeTrainer.MovementFlags &= ~Agent.MovementControlFlag.AttackMask;
			_meleeTrainer.MovementFlags |= Agent.MovementControlFlag.DefendDown;
		}
	}

	public override void OnScoreHit(Agent affectedAgent, Agent affectorAgent, WeaponComponentData attackerWeapon, bool isBlocked, bool isSiegeEngineHit, in Blow blow, in AttackCollisionData collisionData, float damagedHp, float hitDistance, float shotDifficulty)
	{
		base.OnScoreHit(affectedAgent, affectorAgent, attackerWeapon, isBlocked, isSiegeEngineHit, in blow, in collisionData, damagedHp, hitDistance, shotDifficulty);
		if (isBlocked)
		{
			for (EquipmentIndex equipmentIndex = EquipmentIndex.WeaponItemBeginSlot; equipmentIndex <= EquipmentIndex.Weapon3; equipmentIndex++)
			{
				if (!affectedAgent.Equipment[equipmentIndex].IsEmpty && affectedAgent.Equipment[equipmentIndex].IsShield())
				{
					affectedAgent.ChangeWeaponHitPoints(equipmentIndex, affectedAgent.Equipment[equipmentIndex].ModifiedMaxHitPoints);
				}
			}
		}
		TutorialArea activeTutorialArea = _activeTutorialArea;
		if (activeTutorialArea != null && activeTutorialArea.TypeOfTraining == TutorialArea.TrainingType.Melee)
		{
			if (affectedAgent.Controller == Agent.ControllerType.Player)
			{
				if (_trainingProgress >= 3 && _trainingProgress <= 6 && isBlocked)
				{
					_timer = base.Mission.CurrentTime;
					if (_trainingProgress == 3 && affectedAgent.GetCurrentActionDirection(1) == Agent.UsageDirection.DefendLeft)
					{
						_detailedObjectives[1].SetTextVariableOfName("HIT", 1);
						Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/vo/parrying/block_right"), _meleeTrainer.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
						CurrentObjectiveTick(new TextObject("{=7wmkPNbI}Defend from right."));
						_trainingProgress++;
					}
					else if (_trainingProgress == 4 && affectedAgent.GetCurrentActionDirection(1) == Agent.UsageDirection.DefendRight)
					{
						_detailedObjectives[1].SetTextVariableOfName("HIT", 2);
						Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/vo/parrying/block_up"), _meleeTrainer.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
						CurrentObjectiveTick(new TextObject("{=CEqKkY3m}Defend from up."));
						_trainingProgress++;
					}
					else if (_trainingProgress == 5 && affectedAgent.GetCurrentActionDirection(1) == Agent.UsageDirection.AttackEnd)
					{
						_detailedObjectives[1].SetTextVariableOfName("HIT", 3);
						Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/vo/parrying/block_down"), _meleeTrainer.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
						CurrentObjectiveTick(new TextObject("{=Qdz5Hely}Defend from down."));
						_trainingProgress++;
					}
					else if (_trainingProgress == 6 && affectedAgent.GetCurrentActionDirection(1) == Agent.UsageDirection.DefendDown)
					{
						_detailedObjectives[1].SetTextVariableOfName("HIT", 4);
						_detailedObjectives[1].FinishTask();
						_detailedObjectives[2].SetActive(isActive: true);
						Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/vo/parrying/attack_left"), _meleeTrainer.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
						CurrentObjectiveTick(new TextObject("{=8QX1QHAJ}Attack from left."));
						_trainingProgress++;
					}
				}
			}
			else if (affectedAgent == _meleeTrainer && affectorAgent != null && affectorAgent.Controller == Agent.ControllerType.Player && _trainingProgress >= 7 && _trainingProgress <= 10 && isBlocked)
			{
				_meleeTrainer.MovementFlags = (Agent.MovementControlFlag)0u;
				_timer = base.Mission.CurrentTime;
				if (_trainingProgress == 7 && affectorAgent.GetCurrentActionDirection(1) == Agent.UsageDirection.AttackLeft)
				{
					_detailedObjectives[2].SetTextVariableOfName("HIT", 1);
					Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/vo/parrying/attack_right"), _meleeTrainer.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
					CurrentObjectiveTick(new TextObject("{=fC60rYwy}Attack from right."));
					_trainingProgress++;
				}
				else if (_trainingProgress == 8 && affectorAgent.GetCurrentActionDirection(1) == Agent.UsageDirection.AttackRight)
				{
					_detailedObjectives[2].SetTextVariableOfName("HIT", 2);
					Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/vo/parrying/attack_up"), _meleeTrainer.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
					CurrentObjectiveTick(new TextObject("{=j2dW9fZt}Attack from up."));
					_trainingProgress++;
				}
				else if (_trainingProgress == 9 && affectorAgent.GetCurrentActionDirection(1) == Agent.UsageDirection.AttackUp)
				{
					_detailedObjectives[2].SetTextVariableOfName("HIT", 3);
					Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/vo/parrying/attack_down"), _meleeTrainer.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
					CurrentObjectiveTick(new TextObject("{=X9Vmjipn}Attack from down."));
					_trainingProgress++;
				}
				else if (_trainingProgress == 10 && affectorAgent.GetCurrentActionDirection(1) == Agent.UsageDirection.AttackDown)
				{
					_detailedObjectives[2].SetTextVariableOfName("HIT", 4);
					_detailedObjectives[2].FinishTask();
					CurrentObjectiveTick(_trainingFinishedText);
					TickMouseObjective(MouseObjectives.None);
					if (Agent.Main.Equipment.HasShield())
					{
						MBInformationManager.AddQuickInformation(new TextObject("{=PiOiQ3u5}You've successfully finished the sword and shield tutorial."));
					}
					else
					{
						MBInformationManager.AddQuickInformation(new TextObject("{=GZaYmg95}You've successfully finished the sword tutorial."));
					}
					_trainingProgress++;
				}
				else
				{
					MBInformationManager.AddQuickInformation(new TextObject("{=fBJRdxh2}Try again."));
					Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/vo/parrying/remark"), _meleeTrainer.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
				}
			}
		}
		if (!isBlocked)
		{
			if (affectedAgent.Controller == Agent.ControllerType.Player)
			{
				_playerHealth -= blow.InflictedDamage;
				Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/vo/fighting/warning"), _advancedMeleeTrainerNormal.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
			}
			else if (affectedAgent == _advancedMeleeTrainerEasy)
			{
				_advancedMeleeTrainerEasyHealth -= blow.InflictedDamage;
			}
			else if (affectedAgent == _advancedMeleeTrainerNormal)
			{
				_advancedMeleeTrainerNormalHealth -= blow.InflictedDamage;
			}
		}
	}

	private void TickMouseObjective(MouseObjectives objective)
	{
		CurrentMouseObjectiveTick?.Invoke(GetAdjustedMouseObjective(objective));
	}

	private bool IsAttackDirection(MouseObjectives objective)
	{
		switch (objective)
		{
		case MouseObjectives.AttackLeft:
		case MouseObjectives.AttackRight:
		case MouseObjectives.AttackUp:
		case MouseObjectives.AttackDown:
			return true;
		case MouseObjectives.DefendLeft:
		case MouseObjectives.DefendRight:
		case MouseObjectives.DefendUp:
		case MouseObjectives.DefendDown:
			return false;
		default:
			return false;
		}
	}

	private MouseObjectives GetAdjustedMouseObjective(MouseObjectives baseObjective)
	{
		if (IsAttackDirection(baseObjective))
		{
			return BannerlordConfig.AttackDirectionControl switch
			{
				0 => GetInverseDirection(baseObjective), 
				1 => baseObjective, 
				_ => MouseObjectives.None, 
			};
		}
		if (BannerlordConfig.DefendDirectionControl == 0)
		{
			return baseObjective;
		}
		return MouseObjectives.None;
	}

	private MouseObjectives GetInverseDirection(MouseObjectives objective)
	{
		switch (objective)
		{
		case MouseObjectives.None:
			return MouseObjectives.None;
		case MouseObjectives.AttackLeft:
			return MouseObjectives.AttackRight;
		case MouseObjectives.AttackRight:
			return MouseObjectives.AttackLeft;
		case MouseObjectives.AttackUp:
			return MouseObjectives.AttackDown;
		case MouseObjectives.AttackDown:
			return MouseObjectives.AttackUp;
		case MouseObjectives.DefendLeft:
			return MouseObjectives.DefendRight;
		case MouseObjectives.DefendRight:
			return MouseObjectives.DefendLeft;
		case MouseObjectives.DefendUp:
			return MouseObjectives.DefendDown;
		case MouseObjectives.DefendDown:
			return MouseObjectives.DefendUp;
		default:
			Debug.FailedAssert($"Inverse direction is not defined for: {objective}", "C:\\Develop\\MB3\\Source\\Bannerlord\\StoryMode\\Missions\\TrainingFieldMissionController.cs", "GetInverseDirection", 2267);
			return MouseObjectives.None;
		}
	}

	private void InitializeMountedTraining()
	{
		_horse = SpawnHorse();
		_horse.Controller = Agent.ControllerType.None;
		_horseBeginningPosition = _horse.GetWorldPosition();
		_finishGateClosed = base.Mission.Scene.FindEntityWithTag("finish_gate_closed");
		_finishGateOpen = base.Mission.Scene.FindEntityWithTag("finish_gate_open");
		_mountedAIWaitingPosition = base.Mission.Scene.FindEntityWithTag("_mounted_ai_waiting_position").GetGlobalFrame();
		_mountedAI = SpawnMountedAI();
		_mountedAI.SetWatchState(Agent.WatchState.Alarmed);
		for (int i = 0; i < _checkpoints.Count; i++)
		{
			_mountedAICheckpointList.Add(_checkpoints[i].Item1.GameEntity.GlobalPosition);
			if (i < _checkpoints.Count - 1)
			{
				_mountedAICheckpointList.Add((_checkpoints[i].Item1.GameEntity.GlobalPosition + _checkpoints[i + 1].Item1.GameEntity.GlobalPosition) / 2f);
			}
		}
	}

	private Agent SpawnMountedAI()
	{
		_mountedAISpawnPosition = MatrixFrame.Identity;
		GameEntity gameEntity = base.Mission.Scene.FindEntityWithTag("_mounted_ai_spawn_position");
		if (gameEntity != null)
		{
			_mountedAISpawnPosition = gameEntity.GetGlobalFrame();
			_mountedAISpawnPosition.rotation.OrthonormalizeAccordingToForwardAndKeepUpAsZAxis();
		}
		else
		{
			Debug.FailedAssert("There are no spawn points for mounted ai.", "C:\\Develop\\MB3\\Source\\Bannerlord\\StoryMode\\Missions\\TrainingFieldMissionController.cs", "SpawnMountedAI", 2311);
		}
		CharacterObject @object = Game.Current.ObjectManager.GetObject<CharacterObject>("tutorial_npc_mounted_ai");
		AgentBuildData agentBuildData = new AgentBuildData(@object).Team(base.Mission.PlayerTeam).InitialPosition(in _mountedAISpawnPosition.origin);
		Vec2 direction = _mountedAISpawnPosition.rotation.f.AsVec2;
		AgentBuildData agentBuildData2 = agentBuildData.InitialDirection(in direction).CivilianEquipment(civilianEquipment: false).NoHorses(noHorses: false)
			.NoWeapons(noWeapons: false)
			.ClothingColor1(base.Mission.PlayerTeam.Color)
			.ClothingColor2(base.Mission.PlayerTeam.Color2)
			.TroopOrigin(new PartyAgentOrigin(PartyBase.MainParty, @object))
			.MountKey(MountCreationKey.GetRandomMountKeyString(@object.Equipment[EquipmentIndex.ArmorItemEndSlot].Item, @object.GetMountKeySeed()))
			.Controller(Agent.ControllerType.AI);
		Agent agent = base.Mission.SpawnAgent(agentBuildData2);
		agent.SetTeam(Mission.Current.PlayerTeam, sync: false);
		return agent;
	}

	private void UpdateMountedAIBehavior()
	{
		if (_mountedAICurrentCheckpointTarget == -1)
		{
			if (_continueLoop && (_mountedAISpawnPosition.origin - _mountedAI.Position).LengthSquared < 6.25f)
			{
				_mountedAICurrentCheckpointTarget++;
				MatrixFrame globalFrame = _checkpoints[_mountedAICurrentCheckpointTarget].Item1.GameEntity.GetGlobalFrame();
				WorldPosition scriptedPosition = globalFrame.origin.ToWorldPosition();
				_mountedAI.SetScriptedPositionAndDirection(ref scriptedPosition, globalFrame.rotation.f.AsVec2.RotationInRadians, addHumanLikeDelay: true);
				SetFinishGateStatus(open: false);
				_mountedAI.SetWatchState(Agent.WatchState.Alarmed);
			}
			return;
		}
		bool flag = false;
		if ((_checkpoints[_mountedAICurrentCheckpointTarget].Item1.GameEntity.GetGlobalFrame().origin.ToWorldPosition().AsVec2 - _mountedAI.Position.ToWorldPosition().AsVec2).LengthSquared < 25f)
		{
			flag = true;
			_mountedAICurrentCheckpointTarget++;
			if (_mountedAICurrentCheckpointTarget > _checkpoints.Count - 1)
			{
				_mountedAICurrentCheckpointTarget = -1;
				if (_continueLoop)
				{
					GoToStartingPosition();
				}
				else
				{
					WorldPosition scriptedPosition2 = _mountedAIWaitingPosition.origin.ToWorldPosition();
					_mountedAI.SetScriptedPositionAndDirection(ref scriptedPosition2, _mountedAISpawnPosition.rotation.f.AsVec2.RotationInRadians, addHumanLikeDelay: true);
				}
			}
			else if (_mountedAICurrentCheckpointTarget == _checkpoints.Count - 1)
			{
				SetFinishGateStatus(open: true);
				_mountedAI.SetWatchState(Agent.WatchState.Patrolling);
			}
		}
		else if ((_mountedAITargets[_mountedAICurrentHitTarget].GameEntity.GetGlobalFrame().origin.ToWorldPosition().AsVec2 - _mountedAI.Position.ToWorldPosition().AsVec2).LengthSquared < 169f)
		{
			_enteredRadiusOfTarget = true;
		}
		else if ((!_allTargetsDestroyed && _mountedAITargets[_mountedAICurrentHitTarget].IsDestroyed) || (_enteredRadiusOfTarget && (_mountedAITargets[_mountedAICurrentHitTarget].GameEntity.GetGlobalFrame().origin.ToWorldPosition().AsVec2 - _mountedAI.Position.ToWorldPosition().AsVec2).LengthSquared > 169f))
		{
			_enteredRadiusOfTarget = false;
			flag = true;
			_mountedAICurrentHitTarget++;
			if (_mountedAICurrentHitTarget > _mountedAITargets.Count - 1)
			{
				_mountedAICurrentHitTarget = 0;
				_allTargetsDestroyed = true;
			}
		}
		if (flag && _mountedAICurrentCheckpointTarget != -1)
		{
			MatrixFrame globalFrame2 = _checkpoints[_mountedAICurrentCheckpointTarget].Item1.GameEntity.GetGlobalFrame();
			WorldPosition scriptedPosition3 = globalFrame2.origin.ToWorldPosition();
			_mountedAI.SetScriptedPositionAndDirection(ref scriptedPosition3, globalFrame2.rotation.f.AsVec2.RotationInRadians, addHumanLikeDelay: true);
			if (!_allTargetsDestroyed)
			{
				_mountedAI.SetScriptedTargetEntityAndPosition(_mountedAITargets[_mountedAICurrentHitTarget].GameEntity, default(WorldPosition));
			}
		}
	}

	private void GoToStartingPosition()
	{
		WorldPosition scriptedPosition = _mountedAISpawnPosition.origin.ToWorldPosition();
		_mountedAI.SetScriptedPositionAndDirection(ref scriptedPosition, _mountedAISpawnPosition.rotation.f.AsVec2.RotationInRadians, addHumanLikeDelay: true);
		RestoreAndShowAllMountedAITargets();
	}

	private void RestoreAndShowAllMountedAITargets()
	{
		_allTargetsDestroyed = false;
		foreach (DestructableComponent mountedAITarget in _mountedAITargets)
		{
			mountedAITarget.Reset();
			mountedAITarget.GameEntity.SetVisibilityExcludeParents(visible: true);
		}
	}

	private void HideAllMountedAITargets()
	{
		_allTargetsDestroyed = true;
		foreach (DestructableComponent mountedAITarget in _mountedAITargets)
		{
			mountedAITarget.Reset();
			mountedAITarget.GameEntity.SetVisibilityExcludeParents(visible: false);
		}
	}

	private void UpdateHorseBehavior()
	{
		if (_horse != null && _horse.RiderAgent == null)
		{
			if (_horse.IsAIControlled && _horse.CommonAIComponent.IsPanicked)
			{
				_horse.CommonAIComponent.StopRetreating();
			}
			if (_horseBehaviorMode != HorseReturningSituation.BeginReturn && !_trainingAreas.Find((TutorialArea x) => x.TypeOfTraining == TutorialArea.TrainingType.Mounted).IsPositionInsideTutorialArea(_horse.Position, out var _))
			{
				_horseBehaviorMode = HorseReturningSituation.BeginReturn;
				TutorialArea activeTutorialArea = _activeTutorialArea;
				if (activeTutorialArea != null && activeTutorialArea.TypeOfTraining == TutorialArea.TrainingType.Mounted && _trainingProgress > 1)
				{
					ResetTrainingArea();
				}
			}
			else
			{
				TutorialArea activeTutorialArea2 = _activeTutorialArea;
				if ((activeTutorialArea2 == null || activeTutorialArea2.TypeOfTraining != TutorialArea.TrainingType.Mounted) && (_horseBehaviorMode == HorseReturningSituation.NotInPosition || _horseBehaviorMode == HorseReturningSituation.Following))
				{
					_horseBehaviorMode = HorseReturningSituation.BeginReturn;
				}
				else
				{
					TutorialArea activeTutorialArea3 = _activeTutorialArea;
					if (activeTutorialArea3 != null && activeTutorialArea3.TypeOfTraining == TutorialArea.TrainingType.Mounted && !Agent.Main.HasMount && _trainingProgress > 2)
					{
						_horseBehaviorMode = HorseReturningSituation.Following;
					}
				}
			}
			switch (_horseBehaviorMode)
			{
			case HorseReturningSituation.BeginReturn:
				if ((_horse.Position - _horseBeginningPosition.GetGroundVec3()).Length > 1f)
				{
					_horse.Controller = Agent.ControllerType.AI;
					_horse.SetScriptedPosition(ref _horseBeginningPosition, addHumanLikeDelay: false);
					_horseBehaviorMode = HorseReturningSituation.Returning;
				}
				else
				{
					_horseBehaviorMode = HorseReturningSituation.ReturnCompleted;
				}
				break;
			case HorseReturningSituation.Returning:
				if ((_horse.Position - _horseBeginningPosition.GetGroundVec3()).Length < 0.5f)
				{
					if (_horse.GetCurrentVelocity().LengthSquared <= 0f)
					{
						_horseBehaviorMode = HorseReturningSituation.ReturnCompleted;
					}
					else if (_horse.Controller == Agent.ControllerType.AI)
					{
						_horse.Controller = Agent.ControllerType.None;
						_horse.MovementFlags &= ~Agent.MovementControlFlag.MoveMask;
					}
				}
				else if (_horse.Controller == Agent.ControllerType.None)
				{
					_horseBehaviorMode = HorseReturningSituation.BeginReturn;
				}
				break;
			case HorseReturningSituation.ReturnCompleted:
				if ((_horse.Position - _horseBeginningPosition.GetGroundVec3()).Length > 1f)
				{
					TutorialArea activeTutorialArea4 = _activeTutorialArea;
					if (activeTutorialArea4 != null && activeTutorialArea4.TypeOfTraining == TutorialArea.TrainingType.Mounted)
					{
						_horseBehaviorMode = HorseReturningSituation.NotInPosition;
						_horse.Controller = Agent.ControllerType.None;
						_horse.MovementFlags &= ~Agent.MovementControlFlag.MoveMask;
					}
				}
				break;
			case HorseReturningSituation.Following:
				if ((_horse.Position - Agent.Main.Position).Length > 3f)
				{
					_horse.Controller = Agent.ControllerType.AI;
					Vec3 position = Agent.Main.Position + (_horse.Position - Agent.Main.Position).NormalizedCopy() * 3f;
					WorldPosition position2 = new WorldPosition(Agent.Main.Mission.Scene, position);
					_horse.SetScriptedPosition(ref position2, addHumanLikeDelay: false);
				}
				break;
			}
		}
		else if (_horse.RiderAgent != null && _horseBehaviorMode != 0)
		{
			_horseBehaviorMode = HorseReturningSituation.NotInPosition;
			_horse.Controller = Agent.ControllerType.None;
			_horse.MovementFlags &= ~Agent.MovementControlFlag.MoveMask;
		}
	}

	private Agent SpawnHorse()
	{
		MatrixFrame globalFrame = base.Mission.Scene.FindEntityWithTag("spawner_horse").GetGlobalFrame();
		ItemObject @object = MBObjectManager.Instance.GetObject<ItemObject>("old_horse");
		ItemRosterElement rosterElement = new ItemRosterElement(@object, 1);
		ItemObject object2 = MBObjectManager.Instance.GetObject<ItemObject>("light_harness");
		ItemRosterElement harnessRosterElement = new ItemRosterElement(object2);
		Agent agent = null;
		if (@object.HasHorseComponent)
		{
			Mission current = Mission.Current;
			ref Vec3 origin = ref globalFrame.origin;
			Vec2 initialDirection = globalFrame.rotation.f.AsVec2.Normalized();
			agent = current.SpawnMonster(rosterElement, harnessRosterElement, in origin, in initialDirection);
			AnimalSpawnSettings.CheckAndSetAnimalAgentFlags(base.Mission.Scene.FindEntityWithTag("spawner_melee_npc"), agent);
		}
		return agent;
	}

	private void MountedTrainingUpdate()
	{
		bool flag = false;
		if (_trainingProgress > 2 && _trainingProgress < 5)
		{
			flag = CheckpointUpdate();
		}
		if (Agent.Main.HasMount)
		{
			_activeTutorialArea.ActivateBoundaries();
		}
		else
		{
			_activeTutorialArea.HideBoundaries();
		}
		if (_trainingProgress == 1)
		{
			if (HasAllWeaponsPicked())
			{
				_activeTutorialArea.MakeDestructible(_trainingSubTypeIndex);
				_detailedObjectives = _mountedObjectives.ConvertAll((TutorialObjective x) => new TutorialObjective(x.Id));
				_detailedObjectives[1].SetTextVariableOfName("HIT", _activeTutorialArea.GetBrokenBreakableCount(_trainingSubTypeIndex));
				_detailedObjectives[1].SetTextVariableOfName("ALL", _activeTutorialArea.GetBreakablesCount(_trainingSubTypeIndex));
				_detailedObjectives[0].SetActive(isActive: true);
				Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/vo/riding/pick_" + _trainingSubTypeIndex), Agent.Main.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
				SetHorseMountable(mountable: true);
				_mountedLastBrokenTargetCount = 0;
				_trainingProgress++;
				CurrentObjectiveTick(new TextObject("{=h31YaM4b}Mount the horse."));
			}
		}
		else if (_trainingProgress == 2)
		{
			if (Agent.Main.HasMount)
			{
				_activeTutorialArea.ResetBreakables(_trainingSubTypeIndex, makeIndestructible: false);
				_detailedObjectives[0].FinishTask();
				_detailedObjectives[1].SetActive(isActive: true);
				_activeTutorialArea.ActivateBoundaries();
				_trainingProgress++;
				CurrentObjectiveTick(new TextObject("{=gJBNUAJd}Finish the track and hit as many targets as you can."));
			}
		}
		else if (_trainingProgress == 3)
		{
			if (_checkpoints[0].Item2)
			{
				_activeTutorialArea.ResetBreakables(_trainingSubTypeIndex, makeIndestructible: false);
				ResetCheckpoints();
				(VolumeBox, bool) value = _checkpoints[0];
				value.Item2 = true;
				_checkpoints[0] = value;
				StartTimer();
				UIStartTimer();
				MBInformationManager.AddQuickInformation(new TextObject("{=HvGW2DvS}Track started."));
				Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/vo/riding/start_course"), Agent.Main.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
				_trainingProgress++;
			}
			else if (!Agent.Main.HasMount)
			{
				_trainingProgress = 1;
			}
		}
		else if (_trainingProgress == 4)
		{
			int brokenBreakableCount = _activeTutorialArea.GetBrokenBreakableCount(_trainingSubTypeIndex);
			_detailedObjectives[1].SetTextVariableOfName("HIT", brokenBreakableCount);
			if (brokenBreakableCount != _mountedLastBrokenTargetCount)
			{
				Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/hit_target"), Agent.Main.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
				_mountedLastBrokenTargetCount = brokenBreakableCount;
			}
			if (flag)
			{
				_detailedObjectives[1].FinishTask();
				_trainingProgress++;
				MountedTrainingEndedSuccessfully();
			}
		}
		else if (_trainingProgress == 5 && !Agent.Main.HasMount)
		{
			_trainingProgress++;
			SetHorseMountable(mountable: false);
			CurrentObjectiveTick(_trainingFinishedText);
		}
	}

	private void ResetCheckpoints()
	{
		for (int i = 0; i < _checkpoints.Count; i++)
		{
			_checkpoints[i] = ValueTuple.Create(_checkpoints[i].Item1, item2: false);
		}
		_currentCheckpointIndex = -1;
	}

	private bool CheckpointUpdate()
	{
		for (int i = 0; i < _checkpoints.Count; i++)
		{
			if (_checkpoints[i].Item1.IsPointIn(Agent.Main.Position))
			{
				if (_currentCheckpointIndex == -1)
				{
					_enteringDotProduct = Vec3.DotProduct(Agent.Main.Velocity, _checkpoints[i].Item1.GameEntity.GetFrame().rotation.f);
					_currentCheckpointIndex = i;
				}
				return false;
			}
		}
		bool result = false;
		if (_currentCheckpointIndex != -1)
		{
			float num = Vec3.DotProduct(_checkpoints[_currentCheckpointIndex].Item1.GameEntity.GetFrame().rotation.f, Agent.Main.Velocity);
			if (num > 0f == _enteringDotProduct > 0f)
			{
				if ((_currentCheckpointIndex == 0 || _checkpoints[_currentCheckpointIndex - 1].Item2) && num > 0f)
				{
					_checkpoints[_currentCheckpointIndex] = ValueTuple.Create(_checkpoints[_currentCheckpointIndex].Item1, item2: true);
					int num2 = 0;
					for (int j = 0; j < _checkpoints.Count; j++)
					{
						if (_checkpoints[j].Item2)
						{
							num2++;
						}
					}
					if (_currentCheckpointIndex == _checkpoints.Count - 1)
					{
						result = true;
					}
					if (_currentCheckpointIndex == _checkpoints.Count - 2)
					{
						SetFinishGateStatus(open: true);
					}
				}
				else if (num < 0f)
				{
					MBInformationManager.AddQuickInformation(new TextObject("{=kvTEeUWO}Wrong way!"));
				}
			}
		}
		_currentCheckpointIndex = -1;
		return result;
	}

	private void SetHorseMountable(bool mountable)
	{
		if (mountable)
		{
			Agent.Main.SetAgentFlags(Agent.Main.GetAgentFlags() | AgentFlag.CanRide);
		}
		else
		{
			Agent.Main.SetAgentFlags(Agent.Main.GetAgentFlags() & ~AgentFlag.CanRide);
		}
	}

	private void OnMountedTrainingStart()
	{
		ResetCheckpoints();
		_continueLoop = false;
		HideAllMountedAITargets();
	}

	private void OnMountedTrainingExit()
	{
		SetHorseMountable(mountable: false);
		ResetCheckpoints();
		_continueLoop = true;
		GoToStartingPosition();
	}

	private void SetFinishGateStatus(bool open)
	{
		if (open)
		{
			_finishGateStatus++;
			if (_finishGateStatus == 1)
			{
				_finishGateClosed.SetVisibilityExcludeParents(visible: false);
				_finishGateOpen.SetVisibilityExcludeParents(visible: true);
			}
		}
		else
		{
			_finishGateStatus = TaleWorlds.Library.MathF.Max(0, _finishGateStatus - 1);
			if (_finishGateStatus == 0)
			{
				_finishGateClosed.SetVisibilityExcludeParents(visible: true);
				_finishGateOpen.SetVisibilityExcludeParents(visible: false);
			}
		}
	}

	private void MountedTrainingEndedSuccessfully()
	{
		UIEndTimer();
		EndTimer();
		int brokenBreakableCount = _activeTutorialArea.GetBrokenBreakableCount(_trainingSubTypeIndex);
		int breakablesCount = _activeTutorialArea.GetBreakablesCount(_trainingSubTypeIndex);
		float num = _timeScore + (float)(_activeTutorialArea.GetBreakablesCount(_trainingSubTypeIndex) - _activeTutorialArea.GetBrokenBreakableCount(_trainingSubTypeIndex));
		TextObject textObject = new TextObject("{=W49eUmpT}You can dismount from horse with {CROUCH_KEY}, or {ACTION_KEY} while looking at the horse.");
		textObject.SetTextVariable("CROUCH_KEY", HyperlinkTexts.GetKeyHyperlinkText(HotKeyManager.GetHotKeyId("CombatHotKeyCategory", 15)));
		textObject.SetTextVariable("ACTION_KEY", HyperlinkTexts.GetKeyHyperlinkText(HotKeyManager.GetHotKeyId("CombatHotKeyCategory", 13)));
		CurrentObjectiveTick(textObject);
		if (breakablesCount - brokenBreakableCount == 0)
		{
			Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/vo/riding/course_perfect"), Agent.Main.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
			TextObject textObject2 = new TextObject("{=veHe94Ec}You've successfully finished the track in ({TIME_SCORE}) seconds without missing any targets!");
			textObject2.SetTextVariable("TIME_SCORE", new TextObject(num.ToString("0.0")));
			MBInformationManager.AddQuickInformation(textObject2);
		}
		else
		{
			Mission.Current.MakeSound(SoundEvent.GetEventIdFromString("event:/mission/tutorial/vo/riding/course_finish"), Agent.Main.GetEyeGlobalPosition(), soundCanBePredicted: true, isReliable: false, -1, -1);
			TextObject textObject3 = new TextObject("{=QLgkR3qN}You've successfully finished the track in ({TIME_SCORE}) seconds. You've received ({PENALTY_SECONDS}) seconds penalty from ({MISSED_TARGETS}) missed targets.");
			textObject3.SetTextVariable("TIME_SCORE", new TextObject(num.ToString("0.0")));
			textObject3.SetTextVariable("PENALTY_SECONDS", new TextObject((num - _timeScore).ToString("0.0")));
			textObject3.SetTextVariable("MISSED_TARGETS", breakablesCount - brokenBreakableCount);
			MBInformationManager.AddQuickInformation(textObject3);
		}
		SetFinishGateStatus(open: false);
		SuccessfullyFinishTraining(num);
	}
}
