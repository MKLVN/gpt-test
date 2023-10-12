using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.MissionLogics;

public class IndoorMissionController : MissionLogic
{
	private MissionAgentHandler _missionAgentHandler;

	public override void OnCreated()
	{
		base.OnCreated();
		base.Mission.DoesMissionRequireCivilianEquipment = true;
	}

	public override void OnBehaviorInitialize()
	{
		base.OnBehaviorInitialize();
		_missionAgentHandler = base.Mission.GetMissionBehavior<MissionAgentHandler>();
	}

	public override void AfterStart()
	{
		base.AfterStart();
		base.Mission.SetMissionMode(MissionMode.StartUp, atStart: true);
		base.Mission.IsInventoryAccessible = !Campaign.Current.IsMainHeroDisguised;
		base.Mission.IsQuestScreenAccessible = true;
		_missionAgentHandler.SpawnPlayer(base.Mission.DoesMissionRequireCivilianEquipment, noHorses: true);
		_missionAgentHandler.SpawnLocationCharacters();
	}
}
