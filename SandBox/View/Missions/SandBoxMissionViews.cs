using System;
using System.Collections.Generic;
using SandBox.Missions.AgentControllers;
using SandBox.View.Missions.Sound.Components;
using SandBox.View.Missions.Tournaments;
using SandBox.ViewModelCollection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Missions.Handlers;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;
using TaleWorlds.MountAndBlade.View.MissionViews.Order;
using TaleWorlds.MountAndBlade.View.MissionViews.Singleplayer;
using TaleWorlds.MountAndBlade.View.MissionViews.Sound;
using TaleWorlds.MountAndBlade.ViewModelCollection.OrderOfBattle;
using TaleWorlds.MountAndBlade.ViewModelCollection.Scoreboard;

namespace SandBox.View.Missions;

[ViewCreatorModule]
public class SandBoxMissionViews
{
	[ViewMethod("TownCenter")]
	public static MissionView[] OpenTownCenterMission(Mission mission)
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionCampaignView(),
			(MissionView)(object)new MissionConversationCameraView(),
			SandBoxViewCreator.CreateMissionConversationView(mission),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			ViewCreator.CreateMissionAgentStatusUIHandler(mission),
			ViewCreator.CreateMissionMainAgentEquipmentController(mission),
			ViewCreator.CreateMissionAgentLockVisualizerView(mission),
			SandBoxViewCreator.CreateMissionNameMarkerUIHandler(mission),
			(MissionView)new MissionItemContourControllerView(),
			(MissionView)new MissionAgentContourControllerView(),
			ViewCreator.CreateMissionBoundaryCrossingView(),
			ViewCreator.CreateMissionLeaveView(),
			ViewCreator.CreatePhotoModeView(),
			SandBoxViewCreator.CreateMissionBarterView(),
			ViewCreator.CreateSingleplayerMissionKillNotificationUIHandler(),
			(MissionView)new MissionBoundaryWallView(),
			(MissionView)(object)new MissionCampaignBattleSpectatorView()
		}.ToArray();
	}

	[ViewMethod("TownAmbush")]
	public static MissionView[] OpenTownAmbushMission(Mission mission)
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionCampaignView(),
			(MissionView)(object)new MissionConversationCameraView(),
			SandBoxViewCreator.CreateMissionConversationView(mission),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			ViewCreator.CreateMissionAgentStatusUIHandler(mission),
			ViewCreator.CreateMissionMainAgentEquipmentController(mission),
			ViewCreator.CreateMissionMainAgentCheerBarkControllerView(mission),
			ViewCreator.CreateMissionAgentLockVisualizerView(mission),
			ViewCreator.CreateMissionBoundaryCrossingView(),
			SandBoxViewCreator.CreateMissionBarterView(),
			ViewCreator.CreatePhotoModeView(),
			(MissionView)new MissionBoundaryWallView(),
			(MissionView)(object)new MissionCampaignBattleSpectatorView(),
			ViewCreator.CreateMissionFormationMarkerUIHandler(mission),
			(MissionView)new MissionFormationTargetSelectionHandler(),
			ViewCreator.CreateSingleplayerMissionKillNotificationUIHandler()
		}.ToArray();
	}

	[ViewMethod("FacialAnimationTest")]
	public static MissionView[] OpenFacialAnimationTest(Mission mission)
	{
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionCampaignView(),
			(MissionView)(object)new MissionConversationCameraView(),
			SandBoxViewCreator.CreateMissionConversationView(mission),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			ViewCreator.CreateMissionAgentStatusUIHandler(mission),
			ViewCreator.CreateMissionMainAgentEquipmentController(mission),
			ViewCreator.CreateMissionMainAgentCheerBarkControllerView(mission),
			ViewCreator.CreateMissionAgentLockVisualizerView(mission),
			ViewCreator.CreateMissionBoundaryCrossingView(),
			SandBoxViewCreator.CreateMissionBarterView(),
			(MissionView)new MissionBoundaryWallView(),
			ViewCreator.CreatePhotoModeView()
		}.ToArray();
	}

	[ViewMethod("Indoor")]
	public static MissionView[] OpenTavernMission(Mission mission)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionCampaignView(),
			(MissionView)(object)new MissionConversationCameraView(),
			SandBoxViewCreator.CreateMissionConversationView(mission),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			ViewCreator.CreateMissionAgentStatusUIHandler(mission),
			ViewCreator.CreateMissionMainAgentEquipmentController(mission),
			ViewCreator.CreateMissionAgentLockVisualizerView(mission),
			(MissionView)new MusicSilencedMissionView(),
			SandBoxViewCreator.CreateMissionBarterView(),
			ViewCreator.CreateMissionLeaveView(),
			SandBoxViewCreator.CreateBoardGameView(),
			SandBoxViewCreator.CreateMissionNameMarkerUIHandler(mission),
			(MissionView)new MissionItemContourControllerView(),
			(MissionView)new MissionAgentContourControllerView(),
			(MissionView)(object)new MissionCampaignBattleSpectatorView(),
			ViewCreator.CreatePhotoModeView(),
			ViewCreator.CreateSingleplayerMissionKillNotificationUIHandler()
		}.ToArray();
	}

	[ViewMethod("PrisonBreak")]
	public static MissionView[] OpenPrisonBreakMission(Mission mission)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionCampaignView(),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			ViewCreator.CreateMissionAgentStatusUIHandler(mission),
			ViewCreator.CreateMissionMainAgentEquipmentController(mission),
			(MissionView)new MusicSilencedMissionView(),
			SandBoxViewCreator.CreateMissionBarterView(),
			ViewCreator.CreateMissionLeaveView(),
			SandBoxViewCreator.CreateMissionNameMarkerUIHandler(mission),
			(MissionView)new MissionItemContourControllerView(),
			(MissionView)new MissionAgentContourControllerView(),
			ViewCreator.CreateSingleplayerMissionKillNotificationUIHandler()
		}.ToArray();
	}

	[ViewMethod("Village")]
	public static MissionView[] OpenVillageMission(Mission mission)
	{
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionCampaignView(),
			(MissionView)(object)new MissionConversationCameraView(),
			SandBoxViewCreator.CreateMissionConversationView(mission),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			ViewCreator.CreateMissionAgentStatusUIHandler(mission),
			ViewCreator.CreateMissionMainAgentEquipmentController(mission),
			ViewCreator.CreateMissionAgentLockVisualizerView(mission),
			ViewCreator.CreateMissionBoundaryCrossingView(),
			SandBoxViewCreator.CreateMissionBarterView(),
			ViewCreator.CreateMissionLeaveView(),
			(MissionView)new MissionBoundaryWallView(),
			SandBoxViewCreator.CreateMissionNameMarkerUIHandler(mission),
			(MissionView)new MissionItemContourControllerView(),
			(MissionView)new MissionAgentContourControllerView(),
			(MissionView)(object)new MissionCampaignBattleSpectatorView(),
			ViewCreator.CreatePhotoModeView(),
			ViewCreator.CreateSingleplayerMissionKillNotificationUIHandler()
		}.ToArray();
	}

	[ViewMethod("Retirement")]
	public static MissionView[] OpenRetirementMission(Mission mission)
	{
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionCampaignView(),
			(MissionView)(object)new MissionConversationCameraView(),
			SandBoxViewCreator.CreateMissionConversationView(mission),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			ViewCreator.CreateMissionAgentStatusUIHandler(mission),
			ViewCreator.CreateMissionMainAgentEquipmentController(mission),
			ViewCreator.CreateMissionAgentLockVisualizerView(mission),
			ViewCreator.CreateMissionBoundaryCrossingView(),
			SandBoxViewCreator.CreateMissionBarterView(),
			ViewCreator.CreateMissionLeaveView(),
			(MissionView)new MissionBoundaryWallView(),
			SandBoxViewCreator.CreateMissionNameMarkerUIHandler(mission),
			(MissionView)new MissionItemContourControllerView(),
			(MissionView)new MissionAgentContourControllerView(),
			ViewCreator.CreatePhotoModeView()
		}.ToArray();
	}

	[ViewMethod("ArenaPracticeFight")]
	public static MissionView[] OpenArenaStartMission(Mission mission)
	{
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionCampaignView(),
			(MissionView)(object)new MissionConversationCameraView(),
			SandBoxViewCreator.CreateMissionConversationView(mission),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			ViewCreator.CreateMissionAgentStatusUIHandler(mission),
			ViewCreator.CreateMissionMainAgentEquipmentController(mission),
			ViewCreator.CreateMissionMainAgentCheerBarkControllerView(mission),
			ViewCreator.CreateMissionAgentLockVisualizerView(mission),
			(MissionView)(object)new MissionAudienceHandler(0.4f + MBRandom.RandomFloat * 0.3f),
			SandBoxViewCreator.CreateMissionArenaPracticeFightView(),
			ViewCreator.CreateMissionLeaveView(),
			ViewCreator.CreateSingleplayerMissionKillNotificationUIHandler(),
			(MissionView)(object)new MusicArenaPracticeMissionView(),
			SandBoxViewCreator.CreateMissionBarterView(),
			(MissionView)new MissionItemContourControllerView(),
			(MissionView)new MissionAgentContourControllerView(),
			(MissionView)(object)new MissionCampaignBattleSpectatorView(),
			ViewCreator.CreatePhotoModeView(),
			(MissionView)(object)new ArenaPreloadView()
		}.ToArray();
	}

	[ViewMethod("ArenaDuelMission")]
	public static MissionView[] OpenArenaDuelMission(Mission mission)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionCampaignView(),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			ViewCreator.CreateMissionLeaveView(),
			ViewCreator.CreateSingleplayerMissionKillNotificationUIHandler(),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			(MissionView)new MusicSilencedMissionView(),
			ViewCreator.CreateMissionAgentStatusUIHandler(mission),
			ViewCreator.CreateMissionMainAgentEquipmentController(mission),
			ViewCreator.CreateMissionMainAgentCheerBarkControllerView(mission),
			ViewCreator.CreateMissionAgentLockVisualizerView(mission),
			(MissionView)(object)new MissionAudienceHandler(0.4f + MBRandom.RandomFloat * 0.3f),
			(MissionView)new MissionItemContourControllerView(),
			(MissionView)new MissionAgentContourControllerView(),
			(MissionView)(object)new MissionCampaignBattleSpectatorView(),
			ViewCreator.CreatePhotoModeView()
		}.ToArray();
	}

	[ViewMethod("TownMerchant")]
	public static MissionView[] OpenTownMerchantMission(Mission mission)
	{
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionCampaignView(),
			(MissionView)(object)new MissionConversationCameraView(),
			SandBoxViewCreator.CreateMissionConversationView(mission),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			ViewCreator.CreateMissionAgentStatusUIHandler(mission),
			ViewCreator.CreateMissionMainAgentEquipmentController(mission),
			ViewCreator.CreateMissionAgentLockVisualizerView(mission),
			ViewCreator.CreateMissionLeaveView(),
			SandBoxViewCreator.CreateMissionBarterView(),
			SandBoxViewCreator.CreateMissionNameMarkerUIHandler(mission),
			(MissionView)new MissionItemContourControllerView(),
			(MissionView)new MissionAgentContourControllerView(),
			(MissionView)(object)new MissionCampaignBattleSpectatorView(),
			ViewCreator.CreatePhotoModeView(),
			ViewCreator.CreateSingleplayerMissionKillNotificationUIHandler()
		}.ToArray();
	}

	[ViewMethod("Alley")]
	public static MissionView[] OpenAlleyMission(Mission mission)
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionCampaignView(),
			(MissionView)(object)new MissionConversationCameraView(),
			SandBoxViewCreator.CreateMissionConversationView(mission),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateMissionLeaveView(),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			ViewCreator.CreateMissionAgentStatusUIHandler(mission),
			ViewCreator.CreateMissionMainAgentEquipmentController(mission),
			ViewCreator.CreateMissionMainAgentCheerBarkControllerView(mission),
			ViewCreator.CreateMissionAgentLockVisualizerView(mission),
			ViewCreator.CreateMissionBoundaryCrossingView(),
			SandBoxViewCreator.CreateMissionBarterView(),
			(MissionView)new MissionBoundaryWallView(),
			(MissionView)new MissionItemContourControllerView(),
			(MissionView)new MissionAgentContourControllerView(),
			(MissionView)(object)new MissionCampaignBattleSpectatorView(),
			ViewCreator.CreatePhotoModeView(),
			ViewCreator.CreateSingleplayerMissionKillNotificationUIHandler()
		}.ToArray();
	}

	[ViewMethod("SneakTeam3")]
	public static MissionView[] OpenSneakTeam3Mission(Mission mission)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionConversationCameraView(),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			ViewCreator.CreateMissionAgentStatusUIHandler(mission),
			ViewCreator.CreateMissionMainAgentEquipmentController(mission),
			ViewCreator.CreateMissionMainAgentCheerBarkControllerView(mission),
			ViewCreator.CreateMissionAgentLockVisualizerView(mission),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			ViewCreator.CreateMissionBoundaryCrossingView(),
			(MissionView)new MissionBoundaryWallView(),
			(MissionView)(object)new MissionCampaignBattleSpectatorView(),
			ViewCreator.CreatePhotoModeView(),
			ViewCreator.CreateSingleplayerMissionKillNotificationUIHandler()
		}.ToArray();
	}

	[ViewMethod("SimpleMountedPlayer")]
	public static MissionView[] OpenSimpleMountedPlayerMission(Mission mission)
	{
		return new List<MissionView>().ToArray();
	}

	[ViewMethod("Battle")]
	public static MissionView[] OpenBattleMission(Mission mission)
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		List<MissionView> obj = new List<MissionView>
		{
			(MissionView)(object)new MissionCampaignView(),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateMissionAgentLabelUIHandler(mission),
			ViewCreator.CreateMissionBattleScoreUIHandler(mission, (ScoreboardBaseVM)new SPScoreboardVM(null)),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission)
		};
		MissionView val = ViewCreator.CreateMissionOrderUIHandler((Mission)null);
		obj.Add(val);
		obj.Add((MissionView)new OrderTroopPlacer());
		obj.Add((MissionView)(object)new MissionSingleplayerViewHandler());
		obj.Add(ViewCreator.CreateMissionAgentStatusUIHandler(mission));
		obj.Add(ViewCreator.CreateMissionMainAgentEquipmentController(mission));
		obj.Add(ViewCreator.CreateMissionMainAgentCheerBarkControllerView(mission));
		obj.Add(ViewCreator.CreateMissionAgentLockVisualizerView(mission));
		obj.Add((MissionView)new MusicBattleMissionView(false));
		obj.Add((MissionView)new DeploymentMissionView());
		obj.Add((MissionView)new MissionDeploymentBoundaryMarker((IEntityFactory)new BorderFlagEntityFactory("swallowtail_banner"), (MissionDeploymentBoundaryType)1, 2f));
		obj.Add(ViewCreator.CreateMissionBoundaryCrossingView());
		obj.Add((MissionView)new MissionBoundaryWallView());
		obj.Add(ViewCreator.CreateMissionFormationMarkerUIHandler(mission));
		obj.Add((MissionView)new MissionFormationTargetSelectionHandler());
		obj.Add(ViewCreator.CreateSingleplayerMissionKillNotificationUIHandler());
		obj.Add(ViewCreator.CreateMissionSpectatorControlView(mission));
		obj.Add((MissionView)new MissionItemContourControllerView());
		obj.Add((MissionView)new MissionAgentContourControllerView());
		obj.Add((MissionView)(object)new MissionPreloadView());
		obj.Add((MissionView)(object)new MissionCampaignBattleSpectatorView());
		obj.Add(ViewCreator.CreatePhotoModeView());
		ISiegeDeploymentView val2 = (ISiegeDeploymentView)(object)((val is ISiegeDeploymentView) ? val : null);
		obj.Add((MissionView)new MissionEntitySelectionUIHandler((Action<GameEntity>)val2.OnEntitySelection, (Action<GameEntity>)val2.OnEntityHover));
		obj.Add(ViewCreator.CreateMissionOrderOfBattleUIHandler(mission, (OrderOfBattleVM)new SPOrderOfBattleVM()));
		return obj.ToArray();
	}

	[ViewMethod("AlleyFight")]
	public static MissionView[] OpenAlleyFightMission(Mission mission)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionCampaignView(),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			ViewCreator.CreateMissionBattleScoreUIHandler(mission, (ScoreboardBaseVM)new SPScoreboardVM(null)),
			ViewCreator.CreateMissionAgentLabelUIHandler(mission),
			ViewCreator.CreateMissionOrderUIHandler((Mission)null),
			(MissionView)new OrderTroopPlacer(),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			ViewCreator.CreateMissionAgentStatusUIHandler(mission),
			ViewCreator.CreateMissionMainAgentEquipmentController(mission),
			ViewCreator.CreateMissionMainAgentCheerBarkControllerView(mission),
			ViewCreator.CreateMissionAgentLockVisualizerView(mission),
			ViewCreator.CreateMissionBoundaryCrossingView(),
			(MissionView)new MissionBoundaryWallView(),
			ViewCreator.CreateMissionFormationMarkerUIHandler(mission),
			(MissionView)new MissionFormationTargetSelectionHandler(),
			ViewCreator.CreateSingleplayerMissionKillNotificationUIHandler(),
			ViewCreator.CreateMissionSpectatorControlView(mission),
			(MissionView)new MissionItemContourControllerView(),
			(MissionView)new MissionAgentContourControllerView(),
			(MissionView)(object)new MissionCampaignBattleSpectatorView(),
			ViewCreator.CreatePhotoModeView()
		}.ToArray();
	}

	[ViewMethod("HideoutBattle")]
	public static MissionView[] OpenHideoutBattleMission(Mission mission)
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionCampaignView(),
			(MissionView)(object)new MissionConversationCameraView(),
			(MissionView)(object)new MissionHideoutCinematicView(),
			SandBoxViewCreator.CreateMissionConversationView(mission),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			ViewCreator.CreateMissionBattleScoreUIHandler(mission, (ScoreboardBaseVM)new SPScoreboardVM(null)),
			ViewCreator.CreateMissionAgentLabelUIHandler(mission),
			ViewCreator.CreateMissionOrderUIHandler((Mission)null),
			(MissionView)new OrderTroopPlacer(),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			(MissionView)new MusicSilencedMissionView(),
			ViewCreator.CreateMissionAgentStatusUIHandler(mission),
			ViewCreator.CreateMissionMainAgentEquipmentController(mission),
			ViewCreator.CreateMissionMainAgentCheerBarkControllerView(mission),
			ViewCreator.CreateMissionAgentLockVisualizerView(mission),
			ViewCreator.CreateMissionBoundaryCrossingView(),
			(MissionView)new MissionBoundaryWallView(),
			ViewCreator.CreateMissionFormationMarkerUIHandler(mission),
			(MissionView)new MissionFormationTargetSelectionHandler(),
			ViewCreator.CreateSingleplayerMissionKillNotificationUIHandler(),
			ViewCreator.CreateMissionSpectatorControlView(mission),
			(MissionView)new MissionItemContourControllerView(),
			(MissionView)new MissionAgentContourControllerView(),
			(MissionView)(object)new MissionCampaignBattleSpectatorView(),
			(MissionView)(object)new MissionPreloadView(),
			ViewCreator.CreatePhotoModeView()
		}.ToArray();
	}

	[ViewMethod("EnteringSettlementBattle")]
	public static MissionView[] OpenBattleMissionWhileEnteringSettlement(Mission mission)
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionCampaignView(),
			(MissionView)(object)new MissionConversationCameraView(),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			SandBoxViewCreator.CreateMissionConversationView(mission),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			ViewCreator.CreateMissionBattleScoreUIHandler(mission, (ScoreboardBaseVM)new SPScoreboardVM(null)),
			ViewCreator.CreateMissionAgentLabelUIHandler(mission),
			ViewCreator.CreateMissionOrderUIHandler((Mission)null),
			(MissionView)new OrderTroopPlacer(),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			ViewCreator.CreateMissionAgentStatusUIHandler(mission),
			ViewCreator.CreateMissionMainAgentEquipmentController(mission),
			ViewCreator.CreateMissionMainAgentCheerBarkControllerView(mission),
			ViewCreator.CreateMissionAgentLockVisualizerView(mission),
			ViewCreator.CreateMissionBoundaryCrossingView(),
			(MissionView)new MissionBoundaryWallView(),
			ViewCreator.CreateMissionFormationMarkerUIHandler(mission),
			(MissionView)new MissionFormationTargetSelectionHandler(),
			ViewCreator.CreateSingleplayerMissionKillNotificationUIHandler(),
			ViewCreator.CreateMissionSpectatorControlView(mission),
			(MissionView)new MissionItemContourControllerView(),
			(MissionView)new MissionAgentContourControllerView(),
			(MissionView)(object)new MissionCampaignBattleSpectatorView(),
			ViewCreator.CreatePhotoModeView()
		}.ToArray();
	}

	[ViewMethod("CombatWithDialogue")]
	public static MissionView[] OpenCombatMissionWithDialogue(Mission mission)
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionCampaignView(),
			(MissionView)(object)new MissionConversationCameraView(),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			SandBoxViewCreator.CreateMissionConversationView(mission),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			ViewCreator.CreateMissionBattleScoreUIHandler(mission, (ScoreboardBaseVM)new SPScoreboardVM(null)),
			ViewCreator.CreateMissionAgentLabelUIHandler(mission),
			ViewCreator.CreateMissionOrderUIHandler((Mission)null),
			(MissionView)new OrderTroopPlacer(),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			ViewCreator.CreateMissionAgentStatusUIHandler(mission),
			ViewCreator.CreateMissionMainAgentEquipmentController(mission),
			ViewCreator.CreateMissionMainAgentCheerBarkControllerView(mission),
			ViewCreator.CreateMissionAgentLockVisualizerView(mission),
			ViewCreator.CreateMissionBoundaryCrossingView(),
			(MissionView)new MissionBoundaryWallView(),
			ViewCreator.CreateMissionFormationMarkerUIHandler(mission),
			(MissionView)new MissionFormationTargetSelectionHandler(),
			ViewCreator.CreateSingleplayerMissionKillNotificationUIHandler(),
			ViewCreator.CreateMissionSpectatorControlView(mission),
			(MissionView)new MissionItemContourControllerView(),
			(MissionView)new MissionAgentContourControllerView(),
			(MissionView)(object)new MissionCampaignBattleSpectatorView(),
			ViewCreator.CreatePhotoModeView()
		}.ToArray();
	}

	[ViewMethod("SiegeEngine")]
	public static MissionView[] OpenTestSiegeEngineMission(Mission mission)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionConversationCameraView(),
			ViewCreator.CreateMissionOrderUIHandler((Mission)null),
			(MissionView)new OrderTroopPlacer()
		}.ToArray();
	}

	[ViewMethod("CustomCameraMission")]
	public static MissionView[] OpenCustomCameraMission(Mission mission)
	{
		return new List<MissionView>
		{
			(MissionView)(object)new MissionConversationCameraView(),
			(MissionView)(object)new MissionCustomCameraView()
		}.ToArray();
	}

	[ViewMethod("AmbushBattle")]
	public static MissionView[] OpenAmbushBattleMission(Mission mission)
	{
		throw new NotImplementedException("Ambush battle is not implemented.");
	}

	[ViewMethod("Ambush")]
	public static MissionView[] OpenAmbushMission(Mission mission)
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionCampaignView(),
			(MissionView)(object)new MissionConversationCameraView(),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			ViewCreator.CreateMissionAgentStatusUIHandler(mission),
			ViewCreator.CreateMissionMainAgentEquipmentController(mission),
			ViewCreator.CreateMissionMainAgentCheerBarkControllerView(mission),
			ViewCreator.CreateMissionAgentLockVisualizerView(mission),
			(MissionView)(object)new MissionAmbushView(),
			ViewCreator.CreateMissionBoundaryCrossingView(),
			(MissionView)new MissionBoundaryWallView(),
			ViewCreator.CreateMissionFormationMarkerUIHandler(mission),
			(MissionView)new MissionFormationTargetSelectionHandler(),
			ViewCreator.CreateSingleplayerMissionKillNotificationUIHandler(),
			(MissionView)(object)new MissionCampaignBattleSpectatorView(),
			ViewCreator.CreatePhotoModeView()
		}.ToArray();
	}

	[ViewMethod("Camp")]
	public static MissionView[] OpenCampMission(Mission mission)
	{
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionCampaignView(),
			(MissionView)(object)new MissionConversationCameraView(),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			ViewCreator.CreateMissionAgentStatusUIHandler(mission),
			ViewCreator.CreateMissionMainAgentEquipmentController(mission),
			ViewCreator.CreateMissionMainAgentCheerBarkControllerView(mission),
			ViewCreator.CreateMissionAgentLockVisualizerView(mission),
			ViewCreator.CreateMissionBoundaryCrossingView(),
			(MissionView)new MissionBoundaryWallView(),
			(MissionView)(object)new MissionCampaignBattleSpectatorView(),
			ViewCreator.CreatePhotoModeView(),
			ViewCreator.CreateSingleplayerMissionKillNotificationUIHandler()
		}.ToArray();
	}

	[ViewMethod("SiegeMissionWithDeployment")]
	public static MissionView[] OpenSiegeMissionWithDeployment(Mission mission)
	{
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected O, but got Unknown
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected O, but got Unknown
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected O, but got Unknown
		List<MissionView> list = new List<MissionView>();
		mission.GetMissionBehavior<SiegeDeploymentHandler>();
		list.Add((MissionView)(object)new MissionCampaignView());
		list.Add((MissionView)(object)new MissionConversationCameraView());
		list.Add(ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode));
		list.Add(ViewCreator.CreateOptionsUIHandler());
		list.Add(ViewCreator.CreateMissionMainAgentEquipDropView(mission));
		list.Add(ViewCreator.CreateMissionAgentLabelUIHandler(mission));
		list.Add(ViewCreator.CreateMissionBattleScoreUIHandler(mission, (ScoreboardBaseVM)new SPScoreboardVM(null)));
		MissionView val = ViewCreator.CreateMissionOrderUIHandler((Mission)null);
		list.Add(ViewCreator.CreateMissionAgentStatusUIHandler(mission));
		list.Add(ViewCreator.CreateMissionMainAgentEquipmentController(mission));
		list.Add(ViewCreator.CreateMissionMainAgentCheerBarkControllerView(mission));
		list.Add(ViewCreator.CreateMissionAgentLockVisualizerView(mission));
		list.Add(val);
		list.Add((MissionView)new OrderTroopPlacer());
		list.Add((MissionView)(object)new MissionSingleplayerViewHandler());
		list.Add((MissionView)new MusicBattleMissionView(true));
		list.Add((MissionView)new DeploymentMissionView());
		list.Add((MissionView)new MissionDeploymentBoundaryMarker((IEntityFactory)new BorderFlagEntityFactory("swallowtail_banner"), (MissionDeploymentBoundaryType)0, 2f));
		list.Add(ViewCreator.CreateMissionBoundaryCrossingView());
		list.Add(ViewCreator.CreateSingleplayerMissionKillNotificationUIHandler());
		list.Add(ViewCreator.CreatePhotoModeView());
		list.Add(ViewCreator.CreateMissionFormationMarkerUIHandler(mission));
		list.Add((MissionView)new MissionFormationTargetSelectionHandler());
		ISiegeDeploymentView val2 = (ISiegeDeploymentView)(object)((val is ISiegeDeploymentView) ? val : null);
		list.Add((MissionView)new MissionEntitySelectionUIHandler((Action<GameEntity>)val2.OnEntitySelection, (Action<GameEntity>)val2.OnEntityHover));
		list.Add(ViewCreator.CreateMissionSpectatorControlView(mission));
		list.Add((MissionView)new MissionItemContourControllerView());
		list.Add((MissionView)new MissionAgentContourControllerView());
		list.Add((MissionView)(object)new MissionPreloadView());
		list.Add((MissionView)(object)new MissionCampaignBattleSpectatorView());
		list.Add(ViewCreator.CreateMissionOrderOfBattleUIHandler(mission, (OrderOfBattleVM)new SPOrderOfBattleVM()));
		list.Add(ViewCreator.CreateMissionSiegeEngineMarkerView(mission));
		return list.ToArray();
	}

	[ViewMethod("SiegeMissionNoDeployment")]
	public static MissionView[] OpenSiegeMissionNoDeployment(Mission mission)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionCampaignView(),
			(MissionView)(object)new MissionConversationCameraView(),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			ViewCreator.CreateMissionAgentLabelUIHandler(mission),
			ViewCreator.CreateMissionBattleScoreUIHandler(mission, (ScoreboardBaseVM)new SPScoreboardVM(null)),
			ViewCreator.CreateMissionOrderUIHandler((Mission)null),
			(MissionView)new OrderTroopPlacer(),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			ViewCreator.CreateMissionAgentStatusUIHandler(mission),
			ViewCreator.CreateMissionMainAgentEquipmentController(mission),
			ViewCreator.CreateMissionMainAgentCheerBarkControllerView(mission),
			ViewCreator.CreateMissionAgentLockVisualizerView(mission),
			ViewCreator.CreateSingleplayerMissionKillNotificationUIHandler(),
			ViewCreator.CreatePhotoModeView(),
			ViewCreator.CreateMissionFormationMarkerUIHandler(mission),
			(MissionView)new MissionFormationTargetSelectionHandler(),
			(MissionView)new MusicBattleMissionView(true),
			ViewCreator.CreateMissionBoundaryCrossingView(),
			(MissionView)new MissionBoundaryWallView(),
			ViewCreator.CreateMissionSpectatorControlView(mission),
			(MissionView)new MissionItemContourControllerView(),
			(MissionView)new MissionAgentContourControllerView(),
			(MissionView)(object)new MissionPreloadView(),
			(MissionView)(object)new MissionCampaignBattleSpectatorView(),
			ViewCreator.CreateMissionSiegeEngineMarkerView(mission)
		}.ToArray();
	}

	[ViewMethod("SiegeLordsHallFightMission")]
	public static MissionView[] OpenSiegeLordsHallFightMission(Mission mission)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionCampaignView(),
			(MissionView)(object)new MissionConversationCameraView(),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			ViewCreator.CreateMissionBattleScoreUIHandler(mission, (ScoreboardBaseVM)new SPScoreboardVM(null)),
			ViewCreator.CreateMissionAgentLabelUIHandler(mission),
			ViewCreator.CreateMissionOrderUIHandler((Mission)null),
			(MissionView)new OrderTroopPlacer(),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			ViewCreator.CreateMissionAgentStatusUIHandler(mission),
			ViewCreator.CreateMissionMainAgentEquipmentController(mission),
			ViewCreator.CreateMissionMainAgentCheerBarkControllerView(mission),
			ViewCreator.CreateMissionBoundaryCrossingView(),
			(MissionView)new MissionBoundaryWallView(),
			ViewCreator.CreateMissionFormationMarkerUIHandler(mission),
			(MissionView)new MissionFormationTargetSelectionHandler(),
			ViewCreator.CreateSingleplayerMissionKillNotificationUIHandler(),
			ViewCreator.CreateMissionSpectatorControlView(mission),
			(MissionView)new MissionItemContourControllerView(),
			(MissionView)new MissionAgentContourControllerView(),
			(MissionView)(object)new MissionPreloadView(),
			ViewCreator.CreatePhotoModeView()
		}.ToArray();
	}

	[ViewMethod("Siege")]
	public static MissionView[] OpenSiegeMission(Mission mission)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		List<MissionView> list = new List<MissionView>();
		mission.GetMissionBehavior<SiegeDeploymentHandler>();
		list.Add((MissionView)(object)new MissionCampaignView());
		list.Add((MissionView)(object)new MissionConversationCameraView());
		list.Add(ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode));
		list.Add(ViewCreator.CreateOptionsUIHandler());
		list.Add(ViewCreator.CreateMissionMainAgentEquipDropView(mission));
		MissionView val = ViewCreator.CreateMissionOrderUIHandler((Mission)null);
		list.Add(val);
		list.Add((MissionView)new OrderTroopPlacer());
		list.Add((MissionView)(object)new MissionSingleplayerViewHandler());
		list.Add((MissionView)new DeploymentMissionView());
		list.Add((MissionView)new MissionDeploymentBoundaryMarker((IEntityFactory)new BorderFlagEntityFactory("swallowtail_banner"), (MissionDeploymentBoundaryType)0, 2f));
		list.Add(ViewCreator.CreateMissionBoundaryCrossingView());
		list.Add(ViewCreator.CreateSingleplayerMissionKillNotificationUIHandler());
		list.Add(ViewCreator.CreateMissionAgentStatusUIHandler(mission));
		list.Add(ViewCreator.CreateMissionMainAgentEquipmentController(mission));
		list.Add(ViewCreator.CreateMissionMainAgentCheerBarkControllerView(mission));
		list.Add(ViewCreator.CreateMissionAgentLockVisualizerView(mission));
		list.Add(ViewCreator.CreateMissionSpectatorControlView(mission));
		list.Add(ViewCreator.CreatePhotoModeView());
		ISiegeDeploymentView val2 = (ISiegeDeploymentView)(object)((val is ISiegeDeploymentView) ? val : null);
		list.Add((MissionView)new MissionEntitySelectionUIHandler((Action<GameEntity>)val2.OnEntitySelection, (Action<GameEntity>)val2.OnEntityHover));
		list.Add(ViewCreator.CreateMissionFormationMarkerUIHandler(mission));
		list.Add((MissionView)new MissionFormationTargetSelectionHandler());
		list.Add((MissionView)new MissionItemContourControllerView());
		list.Add((MissionView)new MissionAgentContourControllerView());
		list.Add((MissionView)(object)new MissionCampaignBattleSpectatorView());
		list.Add(ViewCreator.CreateMissionSiegeEngineMarkerView(mission));
		return list.ToArray();
	}

	[ViewMethod("SiegeMissionForTutorial")]
	public static MissionView[] OpenSiegeMissionForTutorial(Mission mission)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		Debug.FailedAssert("Do not use SiegeForTutorial! Use campaign!", "C:\\Develop\\MB3\\Source\\Bannerlord\\SandBox.View\\Missions\\SandBoxMissionViews.cs", "OpenSiegeMissionForTutorial", 876);
		List<MissionView> obj = new List<MissionView>
		{
			(MissionView)(object)new MissionConversationCameraView(),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission)
		};
		MissionView val = ViewCreator.CreateMissionOrderUIHandler((Mission)null);
		obj.Add(val);
		obj.Add((MissionView)new OrderTroopPlacer());
		obj.Add((MissionView)(object)new MissionSingleplayerViewHandler());
		obj.Add(ViewCreator.CreateMissionAgentStatusUIHandler(mission));
		obj.Add(ViewCreator.CreateMissionMainAgentEquipmentController(mission));
		obj.Add(ViewCreator.CreateMissionMainAgentCheerBarkControllerView(mission));
		obj.Add(ViewCreator.CreateMissionAgentLockVisualizerView(mission));
		obj.Add(ViewCreator.CreateMissionSpectatorControlView(mission));
		obj.Add(ViewCreator.CreatePhotoModeView());
		obj.Add(ViewCreator.CreateMissionSiegeEngineMarkerView(mission));
		ISiegeDeploymentView val2 = (ISiegeDeploymentView)(object)((val is ISiegeDeploymentView) ? val : null);
		obj.Add((MissionView)new MissionEntitySelectionUIHandler((Action<GameEntity>)val2.OnEntitySelection, (Action<GameEntity>)val2.OnEntityHover));
		obj.Add((MissionView)new MissionDeploymentBoundaryMarker((IEntityFactory)new BorderFlagEntityFactory("swallowtail_banner"), (MissionDeploymentBoundaryType)0, 2f));
		obj.Add((MissionView)(object)new MissionCampaignBattleSpectatorView());
		return obj.ToArray();
	}

	[ViewMethod("AmbushBattleForTutorial")]
	public static MissionView[] OpenAmbushMissionForTutorial(Mission mission)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		List<MissionView> list = new List<MissionView>();
		list.Add((MissionView)(object)new MissionCampaignView());
		list.Add((MissionView)(object)new MissionConversationCameraView());
		if (mission.GetMissionBehavior<AmbushMissionController>().IsPlayerAmbusher)
		{
			list.Add((MissionView)new MissionDeploymentBoundaryMarker((IEntityFactory)new BorderFlagEntityFactory("swallowtail_banner"), (MissionDeploymentBoundaryType)0, 2f));
		}
		list.Add(ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode));
		list.Add(ViewCreator.CreateOptionsUIHandler());
		list.Add(ViewCreator.CreateMissionMainAgentEquipDropView(mission));
		list.Add(ViewCreator.CreateMissionOrderUIHandler((Mission)null));
		list.Add((MissionView)new OrderTroopPlacer());
		list.Add((MissionView)(object)new MissionSingleplayerViewHandler());
		list.Add((MissionView)(object)new MissionAmbushView());
		list.Add(ViewCreator.CreatePhotoModeView());
		list.Add((MissionView)(object)new MissionAmbushIntroView());
		list.Add((MissionView)new MissionDeploymentBoundaryMarker((IEntityFactory)new BorderFlagEntityFactory("swallowtail_banner"), (MissionDeploymentBoundaryType)0, 2f));
		list.Add((MissionView)(object)new MissionCampaignBattleSpectatorView());
		return list.ToArray();
	}

	[ViewMethod("FormationTest")]
	public static MissionView[] OpenFormationTestMission(Mission mission)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionConversationCameraView(),
			ViewCreator.CreateMissionOrderUIHandler((Mission)null),
			(MissionView)new OrderTroopPlacer()
		}.ToArray();
	}

	[ViewMethod("VillageBattle")]
	public static MissionView[] OpenVillageBattleMission(Mission mission)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionCampaignView(),
			(MissionView)(object)new MissionConversationCameraView(),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			ViewCreator.CreateMissionBattleScoreUIHandler(mission, (ScoreboardBaseVM)new SPScoreboardVM(null)),
			ViewCreator.CreateMissionOrderUIHandler((Mission)null),
			(MissionView)new OrderTroopPlacer(),
			ViewCreator.CreateMissionAgentStatusUIHandler(mission),
			ViewCreator.CreateMissionMainAgentEquipmentController(mission),
			ViewCreator.CreateMissionMainAgentCheerBarkControllerView(mission),
			ViewCreator.CreateMissionAgentLockVisualizerView(mission),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			ViewCreator.CreateMissionBoundaryCrossingView(),
			(MissionView)new MissionBoundaryWallView(),
			ViewCreator.CreateMissionFormationMarkerUIHandler(mission),
			(MissionView)new MissionFormationTargetSelectionHandler(),
			ViewCreator.CreateMissionSpectatorControlView(mission),
			(MissionView)new MissionItemContourControllerView(),
			(MissionView)new MissionAgentContourControllerView(),
			(MissionView)(object)new MissionCampaignBattleSpectatorView(),
			ViewCreator.CreatePhotoModeView(),
			ViewCreator.CreateSingleplayerMissionKillNotificationUIHandler()
		}.ToArray();
	}

	[ViewMethod("SettlementTest")]
	public static MissionView[] OpenSettlementTestMission(Mission mission)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionConversationCameraView(),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			ViewCreator.CreateMissionAgentStatusUIHandler(mission),
			ViewCreator.CreateMissionMainAgentEquipmentController(mission),
			ViewCreator.CreateMissionMainAgentCheerBarkControllerView(mission),
			ViewCreator.CreateMissionAgentLockVisualizerView(mission),
			ViewCreator.CreateMissionBoundaryCrossingView(),
			(MissionView)new MissionBoundaryWallView(),
			ViewCreator.CreateMissionSpectatorControlView(mission),
			(MissionView)(object)new MissionCampaignBattleSpectatorView(),
			ViewCreator.CreatePhotoModeView()
		}.ToArray();
	}

	[ViewMethod("EquipmentTest")]
	public static MissionView[] OpenEquipmentTestMission(Mission mission)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionConversationCameraView(),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			ViewCreator.CreateMissionBoundaryCrossingView(),
			(MissionView)new MissionBoundaryWallView(),
			(MissionView)(object)new MissionCampaignBattleSpectatorView(),
			ViewCreator.CreatePhotoModeView()
		}.ToArray();
	}

	[ViewMethod("FacialAnimTest")]
	public static MissionView[] OpenFacialAnimTestMission(Mission mission)
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		return new List<MissionView>
		{
			(MissionView)(object)new MissionConversationCameraView(),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			ViewCreator.CreateMissionAgentStatusUIHandler(mission),
			ViewCreator.CreateMissionMainAgentEquipmentController(mission),
			ViewCreator.CreateMissionMainAgentCheerBarkControllerView(mission),
			ViewCreator.CreateMissionAgentLockVisualizerView(mission),
			ViewCreator.CreateMissionBoundaryCrossingView(),
			SandBoxViewCreator.CreateMissionConversationView(mission),
			SandBoxViewCreator.CreateMissionBarterView(),
			(MissionView)new MissionBoundaryWallView(),
			(MissionView)(object)new MissionCampaignBattleSpectatorView(),
			ViewCreator.CreatePhotoModeView()
		}.ToArray();
	}

	[ViewMethod("EquipItemTool")]
	public static MissionView[] OpenEquipItemToolMission(Mission mission)
	{
		return new List<MissionView>
		{
			(MissionView)(object)new MissionConversationCameraView(),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			(MissionView)(object)new MissionEquipItemToolView(),
			ViewCreator.CreateMissionLeaveView()
		}.ToArray();
	}

	[ViewMethod("Conversation")]
	public static MissionView[] OpenConversationMission(Mission mission)
	{
		return new List<MissionView>
		{
			(MissionView)(object)new MissionCampaignView(),
			(MissionView)(object)new MissionConversationCameraView(),
			(MissionView)(object)new MissionSingleplayerViewHandler(),
			SandBoxViewCreator.CreateMissionConversationView(mission),
			ViewCreator.CreateMissionSingleplayerEscapeMenu(CampaignOptions.IsIronmanMode),
			ViewCreator.CreateOptionsUIHandler(),
			ViewCreator.CreateMissionMainAgentEquipDropView(mission),
			SandBoxViewCreator.CreateMissionBarterView(),
			ViewCreator.CreateMissionAgentLockVisualizerView(mission),
			(MissionView)(object)new MissionCampaignBattleSpectatorView(),
			ViewCreator.CreatePhotoModeView()
		}.ToArray();
	}
}
