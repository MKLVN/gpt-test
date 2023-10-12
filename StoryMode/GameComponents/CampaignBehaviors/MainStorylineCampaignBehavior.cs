using StoryMode.Quests.PlayerClanQuests;
using StoryMode.StoryModeObjects;
using StoryMode.StoryModePhases;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace StoryMode.GameComponents.CampaignBehaviors;

public class MainStorylineCampaignBehavior : CampaignBehaviorBase
{
	public override void RegisterEvents()
	{
		CampaignEvents.CanHeroDieEvent.AddNonSerializedListener(this, CanHeroDie);
		CampaignEvents.ClanChangedKingdom.AddNonSerializedListener(this, OnClanChangedKingdom);
		CampaignEvents.OnGameLoadFinishedEvent.AddNonSerializedListener(this, OnGameLoadFinished);
	}

	private void OnGameLoadFinished()
	{
		if (Clan.PlayerClan.Kingdom != null && !Clan.PlayerClan.IsUnderMercenaryService)
		{
			Clan.PlayerClan.IsNoble = true;
		}
		int heroComesOfAge = Campaign.Current.Models.AgeModel.HeroComesOfAge;
		if (StoryModeHeroes.LittleSister.Age < (float)heroComesOfAge && !StoryModeHeroes.LittleSister.IsDisabled && !StoryModeHeroes.LittleSister.IsNotSpawned)
		{
			DisableHeroAction.Apply(StoryModeHeroes.LittleSister);
			StoryModeHeroes.LittleSister.ChangeState(Hero.CharacterStates.NotSpawned);
		}
		if (StoryModeHeroes.LittleBrother.Age < (float)heroComesOfAge && !StoryModeHeroes.LittleBrother.IsDisabled && !StoryModeHeroes.LittleBrother.IsNotSpawned)
		{
			DisableHeroAction.Apply(StoryModeHeroes.LittleBrother);
			StoryModeHeroes.LittleBrother.ChangeState(Hero.CharacterStates.NotSpawned);
		}
		if (!MBSaveLoad.IsUpdatingGameVersion || !(MBSaveLoad.LastLoadedGameVersion < ApplicationVersion.FromString("v1.2.0")))
		{
			return;
		}
		FirstPhase instance = FirstPhase.Instance;
		if (instance == null || !instance.AllPiecesCollected)
		{
			return;
		}
		ItemObject @object = Campaign.Current.ObjectManager.GetObject<ItemObject>("dragon_banner");
		bool flag = false;
		foreach (ItemRosterElement item in MobileParty.MainParty.ItemRoster)
		{
			if (item.EquipmentElement.Item == @object)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			StoryModeManager.Current.MainStoryLine.FirstPhase?.MergeDragonBanner();
		}
	}

	private void OnClanChangedKingdom(Clan clan, Kingdom oldKingdom, Kingdom newKingdom, ChangeKingdomAction.ChangeKingdomActionDetail detail, bool showNotification = true)
	{
		if (clan == Clan.PlayerClan && newKingdom != null && (detail == ChangeKingdomAction.ChangeKingdomActionDetail.CreateKingdom || detail == ChangeKingdomAction.ChangeKingdomActionDetail.JoinKingdom))
		{
			Clan.PlayerClan.IsNoble = true;
		}
	}

	public override void SyncData(IDataStore dataStore)
	{
	}

	private void CanHeroDie(Hero hero, KillCharacterAction.KillCharacterActionDetail causeOfDeath, ref bool result)
	{
		if (hero == StoryModeHeroes.Radagos && StoryModeManager.Current.MainStoryLine.TutorialPhase.IsCompleted && !Campaign.Current.QuestManager.IsThereActiveQuestWithType(typeof(RescueFamilyQuestBehavior.RescueFamilyQuest)) && !Campaign.Current.QuestManager.IsThereActiveQuestWithType(typeof(RebuildPlayerClanQuest)) && causeOfDeath == KillCharacterAction.KillCharacterActionDetail.Executed)
		{
			result = true;
		}
		else if (hero.IsSpecial && hero != StoryModeHeroes.RadagosHencman && !StoryModeManager.Current.MainStoryLine.IsCompleted)
		{
			result = false;
		}
	}
}
