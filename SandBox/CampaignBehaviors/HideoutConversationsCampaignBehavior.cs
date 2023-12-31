using SandBox.Missions.MissionLogics;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.MountAndBlade;

namespace SandBox.CampaignBehaviors;

public class HideoutConversationsCampaignBehavior : CampaignBehaviorBase
{
	public override void RegisterEvents()
	{
		CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener(this, OnSessionLaunched);
	}

	public override void SyncData(IDataStore dataStore)
	{
	}

	private void OnSessionLaunched(CampaignGameStarter campaignGameStarter)
	{
		AddDialogs(campaignGameStarter);
	}

	private void AddDialogs(CampaignGameStarter campaignGameStarter)
	{
		campaignGameStarter.AddDialogLine("bandit_hideout_start_defender", "start", "bandit_hideout_defender", "{=nYCXzAYH}You! You've cut quite a swathe through my men there, damn you. How about we settle this, one-on-one?", bandit_hideout_start_defender_on_condition, null);
		campaignGameStarter.AddPlayerLine("bandit_hideout_start_defender_1", "bandit_hideout_defender", "close_window", "{=dzXaXKaC}Very well.", null, bandit_hideout_start_duel_fight_on_consequence);
		campaignGameStarter.AddPlayerLine("bandit_hideout_start_defender_2", "bandit_hideout_defender", "close_window", "{=ukRZd2AA}I don't fight duels with brigands.", null, bandit_hideout_continue_battle_on_consequence);
	}

	private bool bandit_hideout_start_defender_on_condition()
	{
		PartyBase encounteredParty = PlayerEncounter.EncounteredParty;
		if (encounteredParty == null || encounteredParty.IsMobile || !encounteredParty.MapFaction.IsBanditFaction)
		{
			return false;
		}
		if (encounteredParty.MapFaction.IsBanditFaction && encounteredParty.IsSettlement && encounteredParty.Settlement.IsHideout && Mission.Current != null)
		{
			return Mission.Current.GetMissionBehavior<HideoutMissionController>() != null;
		}
		return false;
	}

	private void bandit_hideout_start_duel_fight_on_consequence()
	{
		Campaign.Current.ConversationManager.ConversationEndOneShot += HideoutMissionController.StartBossFightDuelMode;
	}

	private void bandit_hideout_continue_battle_on_consequence()
	{
		Campaign.Current.ConversationManager.ConversationEndOneShot += HideoutMissionController.StartBossFightBattleMode;
	}
}
