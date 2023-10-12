using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Diamond;

namespace TaleWorlds.MountAndBlade;

public static class CompressionMission
{
	public static readonly CompressionInfo.Float DebugScaleValueCompressionInfo;

	public static readonly CompressionInfo.Integer AgentCompressionInfo;

	public static readonly CompressionInfo.Integer WeaponAttachmentIndexCompressionInfo;

	public static readonly CompressionInfo.Integer AgentOffsetCompressionInfo;

	public static readonly CompressionInfo.Integer AgentHealthCompressionInfo;

	public static readonly CompressionInfo.Integer AgentControllerCompressionInfo;

	public static readonly CompressionInfo.Integer TeamCompressionInfo;

	public static readonly CompressionInfo.Integer TeamSideCompressionInfo;

	public static readonly CompressionInfo.Integer RoundEndReasonCompressionInfo;

	public static readonly CompressionInfo.Integer TeamScoreCompressionInfo;

	public static readonly CompressionInfo.Integer FactionCompressionInfo;

	public static readonly CompressionInfo.Integer MissionOrderTypeCompressionInfo;

	public static readonly CompressionInfo.Integer MissionRoundCountCompressionInfo;

	public static readonly CompressionInfo.Integer MissionRoundStateCompressionInfo;

	public static readonly CompressionInfo.Integer RoundTimeCompressionInfo;

	public static readonly CompressionInfo.Integer SelectedTroopIndexCompressionInfo;

	public static readonly CompressionInfo.Integer MissileCompressionInfo;

	public static readonly CompressionInfo.Float MissileSpeedCompressionInfo;

	public static readonly CompressionInfo.Integer MissileCollisionReactionCompressionInfo;

	public static readonly CompressionInfo.Integer FlagCapturePointIndexCompressionInfo;

	public static readonly CompressionInfo.Integer FlagpoleIndexCompressionInfo;

	public static readonly CompressionInfo.Float FlagCapturePointDurationCompressionInfo;

	public static readonly CompressionInfo.Float FlagProgressCompressionInfo;

	public static readonly CompressionInfo.Float FlagClassicProgressCompressionInfo;

	public static readonly CompressionInfo.Integer FlagDirectionEnumCompressionInfo;

	public static readonly CompressionInfo.Float FlagSpeedCompressionInfo;

	public static readonly CompressionInfo.Integer FlagCaptureResultCompressionInfo;

	public static readonly CompressionInfo.Integer UsableGameObjectDestructionStateCompressionInfo;

	public static readonly CompressionInfo.Float UsableGameObjectHealthCompressionInfo;

	public static readonly CompressionInfo.Float UsableGameObjectBlowMagnitude;

	public static readonly CompressionInfo.Float UsableGameObjectBlowDirection;

	public static readonly CompressionInfo.Float CapturePointProgressCompressionInfo;

	public static readonly CompressionInfo.Integer ItemSlotCompressionInfo;

	public static readonly CompressionInfo.Integer WieldSlotCompressionInfo;

	public static readonly CompressionInfo.Integer ItemDataCompressionInfo;

	public static readonly CompressionInfo.Integer WeaponReloadPhaseCompressionInfo;

	public static readonly CompressionInfo.Integer WeaponUsageIndexCompressionInfo;

	public static readonly CompressionInfo.Integer TauntIndexCompressionInfo;

	public static readonly CompressionInfo.Integer BarkIndexCompressionInfo;

	public static readonly CompressionInfo.Integer UsageDirectionCompressionInfo;

	public static readonly CompressionInfo.Float SpawnedItemVelocityCompressionInfo;

	public static readonly CompressionInfo.Float SpawnedItemAngularVelocityCompressionInfo;

	public static readonly CompressionInfo.UnsignedInteger SpawnedItemWeaponSpawnFlagCompressionInfo;

	public static readonly CompressionInfo.Integer RangedSiegeWeaponAmmoCompressionInfo;

	public static readonly CompressionInfo.Integer RangedSiegeWeaponAmmoIndexCompressionInfo;

	public static readonly CompressionInfo.Integer RangedSiegeWeaponStateCompressionInfo;

	public static readonly CompressionInfo.Integer SiegeLadderStateCompressionInfo;

	public static readonly CompressionInfo.Integer BatteringRamStateCompressionInfo;

	public static readonly CompressionInfo.Integer SiegeLadderAnimationStateCompressionInfo;

	public static readonly CompressionInfo.Float SiegeMachineComponentAngularSpeedCompressionInfo;

	public static readonly CompressionInfo.Integer SiegeTowerGateStateCompressionInfo;

	public static readonly CompressionInfo.Integer NumberOfPacesCompressionInfo;

	public static readonly CompressionInfo.Float WalkingSpeedLimitCompressionInfo;

	public static readonly CompressionInfo.Float StepSizeCompressionInfo;

	public static readonly CompressionInfo.Integer BoneIndexCompressionInfo;

	public static readonly CompressionInfo.Integer AgentPrefabComponentIndexCompressionInfo;

	public static readonly CompressionInfo.Integer MultiplayerPollRejectReasonCompressionInfo;

	public static readonly CompressionInfo.Integer MultiplayerNotificationCompressionInfo;

	public static readonly CompressionInfo.Integer MultiplayerNotificationParameterCompressionInfo;

	public static readonly CompressionInfo.Integer PerkListIndexCompressionInfo;

	public static readonly CompressionInfo.Integer PerkIndexCompressionInfo;

	public static readonly CompressionInfo.Float FlagDominationMoraleCompressionInfo;

	public static readonly CompressionInfo.Integer TdmGoldChangeCompressionInfo;

	public static readonly CompressionInfo.Integer TdmGoldGainTypeCompressionInfo;

	public static readonly CompressionInfo.Integer DuelAreaIndexCompressionInfo;

	public static readonly CompressionInfo.Integer AutomatedBattleIndexCompressionInfo;

	public static readonly CompressionInfo.Integer SiegeMoraleCompressionInfo;

	public static readonly CompressionInfo.Integer SiegeMoralePerFlagCompressionInfo;

	public static CompressionInfo.Integer ActionSetCompressionInfo;

	public static CompressionInfo.Integer MonsterUsageSetCompressionInfo;

	public static readonly CompressionInfo.Integer OrderTypeCompressionInfo;

	public static readonly CompressionInfo.Integer FormationClassCompressionInfo;

	public static readonly CompressionInfo.Float OrderPositionCompressionInfo;

	public static readonly CompressionInfo.Integer SynchedMissionObjectReadableRecordTypeIndex;

	static CompressionMission()
	{
		DebugScaleValueCompressionInfo = new CompressionInfo.Float(0.5f, 1.5f, 13);
		AgentCompressionInfo = new CompressionInfo.Integer(-1, 11);
		WeaponAttachmentIndexCompressionInfo = new CompressionInfo.Integer(0, 8);
		AgentOffsetCompressionInfo = new CompressionInfo.Integer(0, 8);
		AgentHealthCompressionInfo = new CompressionInfo.Integer(-1, 11);
		AgentControllerCompressionInfo = new CompressionInfo.Integer(0, 2, maximumValueGiven: true);
		TeamCompressionInfo = new CompressionInfo.Integer(-1, 10);
		TeamSideCompressionInfo = new CompressionInfo.Integer(-1, 4);
		RoundEndReasonCompressionInfo = new CompressionInfo.Integer(-1, 2, maximumValueGiven: true);
		TeamScoreCompressionInfo = new CompressionInfo.Integer(-1023000, 1023000, maximumValueGiven: true);
		FactionCompressionInfo = new CompressionInfo.Integer(0, 4);
		MissionOrderTypeCompressionInfo = new CompressionInfo.Integer(-1, 5);
		MissionRoundCountCompressionInfo = new CompressionInfo.Integer(-1, 7);
		MissionRoundStateCompressionInfo = new CompressionInfo.Integer(-1, 5, maximumValueGiven: true);
		RoundTimeCompressionInfo = new CompressionInfo.Integer(0, MultiplayerOptions.OptionType.RoundTimeLimit.GetMaximumValue(), maximumValueGiven: true);
		SelectedTroopIndexCompressionInfo = new CompressionInfo.Integer(-1, 15, maximumValueGiven: true);
		MissileCompressionInfo = new CompressionInfo.Integer(0, 10);
		MissileSpeedCompressionInfo = new CompressionInfo.Float(0f, 12, 0.05f);
		MissileCollisionReactionCompressionInfo = new CompressionInfo.Integer(0, 3, maximumValueGiven: true);
		FlagCapturePointIndexCompressionInfo = new CompressionInfo.Integer(0, 3);
		FlagpoleIndexCompressionInfo = new CompressionInfo.Integer(0, 5, maximumValueGiven: true);
		FlagCapturePointDurationCompressionInfo = new CompressionInfo.Float(-1f, 14, 0.01f);
		FlagProgressCompressionInfo = new CompressionInfo.Float(-1f, 1f, 12);
		FlagClassicProgressCompressionInfo = new CompressionInfo.Float(0f, 1f, 11);
		FlagDirectionEnumCompressionInfo = new CompressionInfo.Integer(-1, 2, maximumValueGiven: true);
		FlagSpeedCompressionInfo = new CompressionInfo.Float(-1f, 14, 0.01f);
		FlagCaptureResultCompressionInfo = new CompressionInfo.Integer(0, 3, maximumValueGiven: true);
		UsableGameObjectDestructionStateCompressionInfo = new CompressionInfo.Integer(0, 3);
		UsableGameObjectHealthCompressionInfo = new CompressionInfo.Float(-1f, 18, 0.1f);
		UsableGameObjectBlowMagnitude = new CompressionInfo.Float(0f, DestructableComponent.MaxBlowMagnitude, 8);
		UsableGameObjectBlowDirection = new CompressionInfo.Float(-1f, 1f, 7);
		CapturePointProgressCompressionInfo = new CompressionInfo.Float(0f, 1f, 10);
		ItemSlotCompressionInfo = new CompressionInfo.Integer(0, 4, maximumValueGiven: true);
		WieldSlotCompressionInfo = new CompressionInfo.Integer(-1, 4, maximumValueGiven: true);
		ItemDataCompressionInfo = new CompressionInfo.Integer(0, 10);
		WeaponReloadPhaseCompressionInfo = new CompressionInfo.Integer(0, 9, maximumValueGiven: true);
		WeaponUsageIndexCompressionInfo = new CompressionInfo.Integer(0, 2);
		TauntIndexCompressionInfo = new CompressionInfo.Integer(0, TauntUsageManager.GetTauntItemCount() - 1, maximumValueGiven: true);
		BarkIndexCompressionInfo = new CompressionInfo.Integer(0, SkinVoiceManager.VoiceType.MpBarks.Length - 1, maximumValueGiven: true);
		UsageDirectionCompressionInfo = new CompressionInfo.Integer(-1, 9, maximumValueGiven: true);
		SpawnedItemVelocityCompressionInfo = new CompressionInfo.Float(-100f, 100f, 12);
		SpawnedItemAngularVelocityCompressionInfo = new CompressionInfo.Float(-100f, 100f, 12);
		SpawnedItemWeaponSpawnFlagCompressionInfo = new CompressionInfo.UnsignedInteger(0u, EnumHelper.GetCombinedUIntEnumFlagsValue(typeof(Mission.WeaponSpawnFlags)), maximumValueGiven: true);
		RangedSiegeWeaponAmmoCompressionInfo = new CompressionInfo.Integer(0, 7);
		RangedSiegeWeaponAmmoIndexCompressionInfo = new CompressionInfo.Integer(0, 3);
		RangedSiegeWeaponStateCompressionInfo = new CompressionInfo.Integer(0, 8, maximumValueGiven: true);
		SiegeLadderStateCompressionInfo = new CompressionInfo.Integer(0, 9, maximumValueGiven: true);
		BatteringRamStateCompressionInfo = new CompressionInfo.Integer(0, 2, maximumValueGiven: true);
		SiegeLadderAnimationStateCompressionInfo = new CompressionInfo.Integer(0, 2, maximumValueGiven: true);
		SiegeMachineComponentAngularSpeedCompressionInfo = new CompressionInfo.Float(-20f, 20f, 12);
		SiegeTowerGateStateCompressionInfo = new CompressionInfo.Integer(0, 3, maximumValueGiven: true);
		NumberOfPacesCompressionInfo = new CompressionInfo.Integer(0, 3);
		WalkingSpeedLimitCompressionInfo = new CompressionInfo.Float(-0.01f, 9, 0.01f);
		StepSizeCompressionInfo = new CompressionInfo.Float(-0.01f, 7, 0.01f);
		BoneIndexCompressionInfo = new CompressionInfo.Integer(0, 63, maximumValueGiven: true);
		AgentPrefabComponentIndexCompressionInfo = new CompressionInfo.Integer(0, 4);
		MultiplayerPollRejectReasonCompressionInfo = new CompressionInfo.Integer(0, 3, maximumValueGiven: true);
		MultiplayerNotificationCompressionInfo = new CompressionInfo.Integer(0, MultiplayerGameNotificationsComponent.NotificationCount, maximumValueGiven: true);
		MultiplayerNotificationParameterCompressionInfo = new CompressionInfo.Integer(-1, 8);
		PerkListIndexCompressionInfo = new CompressionInfo.Integer(0, 2);
		PerkIndexCompressionInfo = new CompressionInfo.Integer(0, 4);
		FlagDominationMoraleCompressionInfo = new CompressionInfo.Float(-1f, 8, 0.01f);
		TdmGoldChangeCompressionInfo = new CompressionInfo.Integer(0, 2000, maximumValueGiven: true);
		TdmGoldGainTypeCompressionInfo = new CompressionInfo.Integer(0, 12);
		DuelAreaIndexCompressionInfo = new CompressionInfo.Integer(0, 4);
		AutomatedBattleIndexCompressionInfo = new CompressionInfo.Integer(0, 10, maximumValueGiven: true);
		SiegeMoraleCompressionInfo = new CompressionInfo.Integer(0, 1440, maximumValueGiven: true);
		SiegeMoralePerFlagCompressionInfo = new CompressionInfo.Integer(0, 90, maximumValueGiven: true);
		OrderTypeCompressionInfo = new CompressionInfo.Integer(0, 42, maximumValueGiven: true);
		FormationClassCompressionInfo = new CompressionInfo.Integer(-1, 10, maximumValueGiven: true);
		OrderPositionCompressionInfo = new CompressionInfo.Float(-100000f, 100000f, 24);
		SynchedMissionObjectReadableRecordTypeIndex = new CompressionInfo.Integer(-1, 8);
	}
}
