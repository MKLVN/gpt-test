using System.Collections.Generic;
using System.Linq;
using Helpers;
using StoryMode.Quests.TutorialPhase;
using StoryMode.StoryModeObjects;
using StoryMode.StoryModePhases;
using TaleWorlds.ActivitySystem;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.AgentOrigins;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Inventory;
using TaleWorlds.CampaignSystem.Overlay;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.SceneInformationPopupTypes;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace StoryMode.GameComponents.CampaignBehaviors;

public class TutorialPhaseCampaignBehavior : CampaignBehaviorBase
{
	private bool _controlledByBrother;

	private bool _notifyPlayerAboutPosition;

	private Equipment[] _mainHeroEquipmentBackup = new Equipment[2];

	private Equipment[] _brotherEquipmentBackup = new Equipment[2];

	public override void RegisterEvents()
	{
		CampaignEvents.OnNewGameCreatedPartialFollowUpEvent.AddNonSerializedListener(this, OnNewGameCreatedPartialFollowUp);
		CampaignEvents.TickEvent.AddNonSerializedListener(this, Tick);
		CampaignEvents.OnQuestCompletedEvent.AddNonSerializedListener(this, OnQuestCompleted);
		CampaignEvents.OnSettlementLeftEvent.AddNonSerializedListener(this, OnSettlementLeft);
		CampaignEvents.OnGameLoadedEvent.AddNonSerializedListener(this, OnGameLoaded);
		CampaignEvents.SettlementEntered.AddNonSerializedListener(this, OnSettlementEntered);
		CampaignEvents.DailyTickEvent.AddNonSerializedListener(this, DailyTick);
		CampaignEvents.OnGameLoadFinishedEvent.AddNonSerializedListener(this, OnGameLoadFinished);
		CampaignEvents.OnCharacterCreationIsOverEvent.AddNonSerializedListener(this, OnCharacterCreationIsOver);
		CampaignEvents.CanHaveQuestsOrIssuesEvent.AddNonSerializedListener(this, OnCanHaveQuestsOrIssuesInfoIsRequested);
		CampaignEvents.CanHeroMarryEvent.AddNonSerializedListener(this, CanHeroMarry);
		StoryModeEvents.OnStoryModeTutorialEndedEvent.AddNonSerializedListener(this, OnStoryModeTutorialEnded);
	}

	private void OnCanHaveQuestsOrIssuesInfoIsRequested(Hero hero, ref bool result)
	{
		Settlement settlement = Settlement.Find("village_ES3_2");
		if (!StoryModeManager.Current.MainStoryLine.TutorialPhase.IsCompleted && settlement.Notables.Contains(hero))
		{
			result = false;
		}
	}

	private void CanHeroMarry(Hero hero, ref bool result)
	{
		if (!TutorialPhase.Instance.IsCompleted && hero.Clan == Clan.PlayerClan)
		{
			result = false;
		}
	}

	public override void SyncData(IDataStore dataStore)
	{
		dataStore.SyncData("_mainHeroEquipmentBackup", ref _mainHeroEquipmentBackup);
		dataStore.SyncData("_brotherEquipmentBackup", ref _brotherEquipmentBackup);
	}

	private void Tick(float dt)
	{
		if (TutorialPhase.Instance.TutorialFocusSettlement != null || TutorialPhase.Instance.TutorialFocusMobileParty != null)
		{
			float num = -1f;
			Vec2 moveGoToPoint = Vec2.Invalid;
			if (TutorialPhase.Instance.TutorialFocusSettlement != null)
			{
				num = Campaign.Current.Models.MapDistanceModel.GetDistance(MobileParty.MainParty, TutorialPhase.Instance.TutorialFocusSettlement);
				moveGoToPoint = TutorialPhase.Instance.TutorialFocusSettlement.GatePosition;
			}
			else if (TutorialPhase.Instance.TutorialFocusMobileParty != null)
			{
				num = Campaign.Current.Models.MapDistanceModel.GetDistance(MobileParty.MainParty, TutorialPhase.Instance.TutorialFocusMobileParty);
				moveGoToPoint = TutorialPhase.Instance.TutorialFocusMobileParty.Position2D;
			}
			if (num > MobileParty.MainParty.SeeingRange * 5f)
			{
				_controlledByBrother = true;
				MobileParty.MainParty.Ai.SetMoveGoToPoint(moveGoToPoint);
			}
			if (_controlledByBrother && !_notifyPlayerAboutPosition)
			{
				_notifyPlayerAboutPosition = true;
				MBInformationManager.AddQuickInformation(new TextObject("{=hadftxlO}We have strayed too far from our path. I'll take the lead for some time. You follow me."), 0, StoryModeHeroes.ElderBrother.CharacterObject);
				Campaign.Current.TimeControlMode = CampaignTimeControlMode.StoppablePlay;
			}
			if (_controlledByBrother && num < MobileParty.MainParty.SeeingRange)
			{
				_controlledByBrother = false;
				_notifyPlayerAboutPosition = false;
				MobileParty.MainParty.Ai.SetMoveModeHold();
				MobileParty.MainParty.Ai.SetMoveGoToPoint(MobileParty.MainParty.Position2D);
				MBInformationManager.AddQuickInformation(new TextObject("{=4vsvniPd}I think we are on the right path now. You are the better rider so you should take the lead."), 0, StoryModeHeroes.ElderBrother.CharacterObject);
			}
		}
	}

	private void OnCharacterCreationIsOver()
	{
		ActivityManager.SetActivityAvailability("CompleteMainQuest", isAvailable: true);
		ActivityManager.StartActivity("CompleteMainQuest");
		_mainHeroEquipmentBackup[0] = Hero.MainHero.BattleEquipment.Clone();
		_mainHeroEquipmentBackup[1] = Hero.MainHero.CivilianEquipment.Clone();
		_brotherEquipmentBackup[0] = StoryModeHeroes.ElderBrother.BattleEquipment.Clone();
		_brotherEquipmentBackup[1] = StoryModeHeroes.ElderBrother.CivilianEquipment.Clone();
		Settlement settlement = Settlement.Find("village_ES3_2");
		StoryModeHeroes.LittleBrother.UpdateLastKnownClosestSettlement(settlement);
		StoryModeHeroes.LittleSister.UpdateLastKnownClosestSettlement(settlement);
		Hero.MainHero.Mother.UpdateLastKnownClosestSettlement(settlement);
		Hero.MainHero.Father.UpdateLastKnownClosestSettlement(settlement);
	}

	private void OnNewGameCreatedPartialFollowUp(CampaignGameStarter campaignGameStarter, int i)
	{
		if (i == 99)
		{
			PartyBase.MainParty.ItemRoster.Clear();
			AddDialogAndGameMenus(campaignGameStarter);
			InitializeTutorial();
		}
	}

	private void OnGameLoaded(CampaignGameStarter campaignGameStarter)
	{
		AddDialogAndGameMenus(campaignGameStarter);
		Settlement settlement = Settlement.Find("village_ES3_2");
		if (settlement.Notables.IsEmpty())
		{
			CreateHeadman(settlement);
			return;
		}
		TutorialPhase.Instance.TutorialVillageHeadman = settlement.Notables.First();
		if (!TutorialPhase.Instance.TutorialVillageHeadman.FirstName.Equals(new TextObject("{=Sb46O8WO}Orthos")))
		{
			TextObject textObject = new TextObject("{=JWLBKIkR}Headman {HEADMAN.FIRSTNAME}");
			TextObject firstName = new TextObject("{=Sb46O8WO}Orthos");
			TutorialPhase.Instance.TutorialVillageHeadman.SetName(textObject, firstName);
			StringHelpers.SetCharacterProperties("HEADMAN", TutorialPhase.Instance.TutorialVillageHeadman.CharacterObject, textObject);
		}
	}

	private void OnStoryModeTutorialEnded()
	{
		Settlement settlement = Settlement.Find("village_ES3_2");
		if (settlement.Notables.Count > 1)
		{
			Debug.FailedAssert("There are more than one notable in tutorial phase, control it.", "C:\\Develop\\MB3\\Source\\Bannerlord\\StoryMode\\GameComponents\\CampaignBehaviors\\TutorialPhaseCampaignBehavior.cs", "OnStoryModeTutorialEnded", 188);
			foreach (Hero notable in settlement.Notables)
			{
				notable.SetPersonalRelation(Hero.MainHero, 0);
			}
		}
		else
		{
			Hero hero = settlement.Notables[0];
			hero.SetPersonalRelation(Hero.MainHero, 0);
			KillCharacterAction.ApplyByRemove(hero);
		}
		SpawnAllNotablesForVillage(settlement.Village);
		VolunteerModel volunteerModel = Campaign.Current.Models.VolunteerModel;
		foreach (Hero notable2 in settlement.Notables)
		{
			if (!notable2.IsAlive || !volunteerModel.CanHaveRecruits(notable2))
			{
				continue;
			}
			CharacterObject basicVolunteer = volunteerModel.GetBasicVolunteer(notable2);
			for (int i = 0; i < notable2.VolunteerTypes.Length; i++)
			{
				if (notable2.VolunteerTypes[i] == null && MBRandom.RandomFloat < 0.5f)
				{
					notable2.VolunteerTypes[i] = basicVolunteer;
				}
			}
		}
		DisableHeroAction.Apply(StoryModeHeroes.ElderBrother);
		StoryModeHeroes.ElderBrother.Clan = null;
		foreach (TroopRosterElement item in PartyBase.MainParty.MemberRoster.GetTroopRoster())
		{
			if (!item.Character.IsPlayerCharacter)
			{
				PartyBase.MainParty.MemberRoster.RemoveTroop(item.Character, PartyBase.MainParty.MemberRoster.GetTroopCount(item.Character));
			}
		}
		foreach (TroopRosterElement item2 in PartyBase.MainParty.PrisonRoster.GetTroopRoster())
		{
			if (item2.Character.IsHero)
			{
				DisableHeroAction.Apply(item2.Character.HeroObject);
			}
			else
			{
				PartyBase.MainParty.PrisonRoster.RemoveTroop(item2.Character, PartyBase.MainParty.PrisonRoster.GetTroopCount(item2.Character));
			}
		}
		TutorialPhase.Instance.RemoveTutorialFocusSettlement();
		PartyBase.MainParty.ItemRoster.Clear();
		Hero.MainHero.BattleEquipment.FillFrom(_mainHeroEquipmentBackup[0]);
		Hero.MainHero.CivilianEquipment.FillFrom(_mainHeroEquipmentBackup[1]);
		StoryModeHeroes.ElderBrother.BattleEquipment.FillFrom(_brotherEquipmentBackup[0]);
		StoryModeHeroes.ElderBrother.CivilianEquipment.FillFrom(_brotherEquipmentBackup[1]);
		PartyBase.MainParty.ItemRoster.AddToCounts(DefaultItems.Grain, 2);
		Hero.MainHero.Heal(Hero.MainHero.MaxHitPoints);
		Hero.MainHero.Gold = 1000;
		if (TutorialPhase.Instance.TutorialQuestPhase == TutorialQuestPhase.Finalized && !TutorialPhase.Instance.IsSkipped)
		{
			InformationManager.ShowInquiry(new InquiryData(new TextObject("{=EWD4Op6d}Notification").ToString(), new TextObject("{=GCbqpeDs}Tutorial is over. You are now free to explore Calradia.").ToString(), isAffirmativeOptionShown: true, isNegativeOptionShown: false, new TextObject("{=yS7PvrTD}OK").ToString(), null, delegate
			{
				MBInformationManager.ShowSceneNotification(new FindingFirstBannerPieceSceneNotificationItem(Hero.MainHero));
				CampaignEventDispatcher.Instance.RemoveListeners(this);
			}, null));
		}
	}

	private void InitializeTutorial()
	{
		Hero elderBrother = StoryModeHeroes.ElderBrother;
		elderBrother.ChangeState(Hero.CharacterStates.Active);
		AddHeroToPartyAction.Apply(elderBrother, MobileParty.MainParty, showNotification: false);
		elderBrother.SetHasMet();
		DisableHeroAction.Apply(StoryModeHeroes.Tacitus);
		DisableHeroAction.Apply(StoryModeHeroes.LittleBrother);
		DisableHeroAction.Apply(StoryModeHeroes.LittleSister);
		DisableHeroAction.Apply(StoryModeHeroes.Radagos);
		DisableHeroAction.Apply(StoryModeHeroes.ImperialMentor);
		DisableHeroAction.Apply(StoryModeHeroes.AntiImperialMentor);
		DisableHeroAction.Apply(StoryModeHeroes.RadagosHencman);
		Settlement settlement = Settlement.Find("village_ES3_2");
		CreateHeadman(settlement);
		PartyBase.MainParty.ItemRoster.AddToCounts(DefaultItems.Grain, 1);
	}

	private void CreateHeadman(Settlement settlement)
	{
		Hero hero = HeroCreator.CreateHeroAtOccupation(Occupation.Headman, settlement);
		TextObject textObject = new TextObject("{=JWLBKIkR}Headman {HEADMAN.FIRSTNAME}");
		TextObject firstName = new TextObject("{=Sb46O8WO}Orthos");
		hero.SetName(textObject, firstName);
		StringHelpers.SetCharacterProperties("HEADMAN", hero.CharacterObject, textObject);
		hero.AddPower(Campaign.Current.Models.NotablePowerModel.NotableDisappearPowerLimit * 2);
		TutorialPhase.Instance.TutorialVillageHeadman = hero;
	}

	private void AddDialogAndGameMenus(CampaignGameStarter campaignGameStarter)
	{
		campaignGameStarter.AddDialogLine("storymode_conversation_blocker", "start", "close_window", "{=9XnFlRR0}Interaction with this person is disabled during tutorial stage.", storymode_conversation_blocker_on_condition, null, 1000000);
		campaignGameStarter.AddGameMenu("storymode_game_menu_blocker", "{=pVKkclVk}Interactions are limited during tutorial phase. This interaction is disabled.", storymode_game_menu_blocker_on_init);
		campaignGameStarter.AddGameMenuOption("storymode_game_menu_blocker", "game_menu_blocker_leave", "{=3sRdGQou}Leave", game_menu_leave_condition, game_menu_leave_on_consequence, isLeave: true);
		campaignGameStarter.AddGameMenu("storymode_tutorial_village_game_menu", "{=7VFLb3Qj}You have arrived at the village.", storymode_tutorial_village_game_menu_on_init, GameOverlays.MenuOverlayType.SettlementWithBoth);
		campaignGameStarter.AddGameMenuOption("storymode_tutorial_village_game_menu", "storymode_tutorial_village_enter", "{=Xrz05hYE}Take a walk around", storymode_tutorial_village_enter_on_condition, storymode_tutorial_village_enter_on_consequence);
		campaignGameStarter.AddGameMenuOption("storymode_tutorial_village_game_menu", "storymode_tutorial_village_hostile_action", "{=GM3tAYMr}Take a hostile action", raid_village_menu_option_condition, null);
		campaignGameStarter.AddGameMenuOption("storymode_tutorial_village_game_menu", "storymode_tutorial_village_recruit", "{=E31IJyqs}Recruit troops", recruit_troops_village_menu_option_condition, storymode_recruit_volunteers_on_consequence);
		campaignGameStarter.AddGameMenuOption("storymode_tutorial_village_game_menu", "storymode_tutorial_village_buy", "{=VN4ctHIU}Buy products", buy_products_village_menu_option_condition, storymode_ui_village_buy_good_on_consequence);
		campaignGameStarter.AddGameMenuOption("storymode_tutorial_village_game_menu", "storymode_tutorial_village_wait", "{=zEoHYEUS}Wait here for some time", wait_village_menu_option_condition, null);
		campaignGameStarter.AddGameMenuOption("storymode_tutorial_village_game_menu", "storymode_tutorial_village_leave", "{=3sRdGQou}Leave", game_menu_leave_on_condition, game_menu_leave_on_consequence, isLeave: true);
	}

	private bool recruit_troops_village_menu_option_condition(MenuCallbackArgs args)
	{
		args.optionLeaveType = GameMenuOption.LeaveType.Recruit;
		return RecruitAndBuyProductsConditionsHold(args);
	}

	private bool buy_products_village_menu_option_condition(MenuCallbackArgs args)
	{
		args.optionLeaveType = GameMenuOption.LeaveType.Trade;
		return RecruitAndBuyProductsConditionsHold(args);
	}

	private bool RecruitAndBuyProductsConditionsHold(MenuCallbackArgs args)
	{
		args.Tooltip = ((args.IsEnabled = TutorialPhase.Instance.TutorialQuestPhase >= TutorialQuestPhase.RecruitAndPurchaseStarted) ? TextObject.Empty : new TextObject("{=TeMExjrH}This option is disabled during current active quest."));
		return true;
	}

	private bool raid_village_menu_option_condition(MenuCallbackArgs args)
	{
		args.optionLeaveType = GameMenuOption.LeaveType.HostileAction;
		return PlaceholderOptionsClickableCondition(args);
	}

	private bool wait_village_menu_option_condition(MenuCallbackArgs args)
	{
		args.optionLeaveType = GameMenuOption.LeaveType.Wait;
		return PlaceholderOptionsClickableCondition(args);
	}

	private bool PlaceholderOptionsClickableCondition(MenuCallbackArgs args)
	{
		args.IsEnabled = false;
		args.Tooltip = new TextObject("{=F7VxtCSd}This option is disabled during tutorial phase.");
		return true;
	}

	private void storymode_recruit_volunteers_on_consequence(MenuCallbackArgs args)
	{
		TutorialPhase.Instance.PrepareRecruitOptionForTutorial();
		args.MenuContext.OpenRecruitVolunteers();
	}

	private void storymode_ui_village_buy_good_on_consequence(MenuCallbackArgs args)
	{
		InventoryManager.OpenScreenAsTrade(TutorialPhase.Instance.GetAndPrepareBuyProductsOptionForTutorial(Settlement.CurrentSettlement.Village), Settlement.CurrentSettlement.Village);
	}

	[GameMenuInitializationHandler("storymode_tutorial_village_game_menu")]
	private static void storymode_tutorial_village_game_menu_on_init_background(MenuCallbackArgs args)
	{
		args.MenuContext.SetBackgroundMeshName(Settlement.CurrentSettlement.Village.WaitMeshName);
	}

	[GameMenuInitializationHandler("storymode_game_menu_blocker")]
	private static void storymode_tutorial_blocker_game_menu_on_init_background(MenuCallbackArgs args)
	{
		args.MenuContext.SetBackgroundMeshName(SettlementHelper.FindNearestVillage().Village.WaitMeshName);
	}

	private void storymode_game_menu_blocker_on_init(MenuCallbackArgs args)
	{
		if (Settlement.CurrentSettlement != null && Settlement.CurrentSettlement.StringId == "village_ES3_2")
		{
			GameMenu.SwitchToMenu("storymode_tutorial_village_game_menu");
		}
	}

	private void storymode_tutorial_village_game_menu_on_init(MenuCallbackArgs args)
	{
		if (!StoryModeManager.Current.MainStoryLine.IsPlayerInteractionRestricted)
		{
			GameMenu.SwitchToMenu("village_outside");
			return;
		}
		Settlement currentSettlement = Settlement.CurrentSettlement;
		Campaign.Current.GameMenuManager.MenuLocations.Clear();
		Campaign.Current.GameMenuManager.MenuLocations.AddRange(currentSettlement.LocationComplex.GetListOfLocations());
	}

	private bool storymode_conversation_blocker_on_condition()
	{
		return StoryModeManager.Current.MainStoryLine.IsPlayerInteractionRestricted;
	}

	private bool storymode_tutorial_village_enter_on_condition(MenuCallbackArgs args)
	{
		List<Location> currentLocations = Settlement.CurrentSettlement.LocationComplex.GetListOfLocations().ToList();
		GameMenuOption.IssueQuestFlags issueQuestFlags = Campaign.Current.IssueManager.CheckIssueForMenuLocations(currentLocations, getIssuesWithoutAQuest: true);
		args.OptionQuestData |= issueQuestFlags;
		args.OptionQuestData |= Campaign.Current.QuestManager.CheckQuestForMenuLocations(currentLocations);
		args.optionLeaveType = GameMenuOption.LeaveType.Mission;
		args.IsEnabled = !TutorialPhase.Instance.LockTutorialVillageEnter;
		if (!args.IsEnabled)
		{
			args.Tooltip = new TextObject("{=tWwXEWh6}Use the portrait to talk and enter the mission.");
		}
		return true;
	}

	private void storymode_tutorial_village_enter_on_consequence(MenuCallbackArgs args)
	{
		if (MobileParty.MainParty.CurrentSettlement == null)
		{
			PlayerEncounter.EnterSettlement();
		}
		VillageEncounter villageEncounter = PlayerEncounter.LocationEncounter as VillageEncounter;
		if (TutorialPhase.Instance.TutorialQuestPhase == TutorialQuestPhase.TravelToVillageStarted)
		{
			villageEncounter.CreateAndOpenMissionController(LocationComplex.Current.GetLocationWithId("village_center"), null, StoryModeHeroes.ElderBrother.CharacterObject);
		}
		else
		{
			villageEncounter.CreateAndOpenMissionController(LocationComplex.Current.GetLocationWithId("village_center"));
		}
	}

	private bool game_menu_leave_on_condition(MenuCallbackArgs args)
	{
		args.optionLeaveType = GameMenuOption.LeaveType.Leave;
		return true;
	}

	private bool game_menu_leave_condition(MenuCallbackArgs args)
	{
		args.optionLeaveType = GameMenuOption.LeaveType.Leave;
		return true;
	}

	private void game_menu_leave_on_consequence(MenuCallbackArgs args)
	{
		PlayerEncounter.Finish();
	}

	private void SpawnYourBrotherInLocation(Hero hero, string locationId)
	{
		if (LocationComplex.Current != null)
		{
			Location locationWithId = LocationComplex.Current.GetLocationWithId(locationId);
			Monster baseMonsterFromRace = FaceGen.GetBaseMonsterFromRace(hero.CharacterObject.Race);
			AgentData agentData = new AgentData(new PartyAgentOrigin(PartyBase.MainParty, hero.CharacterObject)).Monster(baseMonsterFromRace).NoHorses(noHorses: true);
			locationWithId.AddCharacter(new LocationCharacter(agentData, SandBoxManager.Instance.AgentBehaviorManager.AddFixedCharacterBehaviors, null, fixedLocation: true, LocationCharacter.CharacterRelations.Friendly, null, useCivilianEquipment: true, isFixedCharacter: false, null, isHidden: false, isVisualTracked: true));
		}
	}

	private void OnQuestCompleted(QuestBase quest, QuestBase.QuestCompleteDetails detail)
	{
		if (quest is TravelToVillageTutorialQuest)
		{
			new TalkToTheHeadmanTutorialQuest(Settlement.CurrentSettlement.Notables.First((Hero n) => n.IsHeadman)).StartQuest();
			TutorialPhase.Instance.SetTutorialQuestPhase(TutorialQuestPhase.TalkToTheHeadmanStarted);
		}
		else if (quest is TalkToTheHeadmanTutorialQuest)
		{
			new LocateAndRescueTravellerTutorialQuest(Settlement.CurrentSettlement.Notables.First((Hero n) => n.IsHeadman)).StartQuest();
			TutorialPhase.Instance.SetTutorialQuestPhase(TutorialQuestPhase.LocateAndRescueTravellerStarted);
		}
		else if (quest is LocateAndRescueTravellerTutorialQuest)
		{
			new FindHideoutTutorialQuest(quest.QuestGiver, SettlementHelper.FindNearestHideout(null, quest.QuestGiver.CurrentSettlement)).StartQuest();
			TutorialPhase.Instance.SetTutorialQuestPhase(TutorialQuestPhase.FindHideoutStarted);
		}
	}

	private void OnSettlementEntered(MobileParty party, Settlement settlement, Hero hero)
	{
		if (!(settlement.StringId == "village_ES3_2") || TutorialPhase.Instance.IsCompleted)
		{
			return;
		}
		if (party != null)
		{
			if (party.IsMainParty)
			{
				SpawnYourBrotherInLocation(StoryModeHeroes.ElderBrother, "village_center");
			}
			else if (!party.IsMilitia)
			{
				party.Ai.SetMoveGoToSettlement(SettlementHelper.FindNearestSettlement((Settlement s) => s != settlement && (s.IsFortification || s.IsVillage) && settlement != s && settlement.MapFaction == s.MapFaction, party));
			}
		}
		if (party == null && hero != null && !hero.IsNotable)
		{
			TeleportHeroAction.ApplyImmediateTeleportToSettlement(hero, SettlementHelper.FindNearestSettlement((Settlement s) => s != settlement && (s.IsFortification || s.IsVillage) && settlement != s && settlement.MapFaction == s.MapFaction, settlement));
		}
	}

	private void OnSettlementLeft(MobileParty party, Settlement settlement)
	{
		if (settlement.StringId == "tutorial_training_field" && party == MobileParty.MainParty && TutorialPhase.Instance.TutorialQuestPhase == TutorialQuestPhase.None)
		{
			new TravelToVillageTutorialQuest().StartQuest();
			TutorialPhase.Instance.SetTutorialQuestPhase(TutorialQuestPhase.TravelToVillageStarted);
			Campaign.Current.IssueManager.ToggleAllIssueTracks(enableTrack: false);
		}
		if (party == MobileParty.MainParty)
		{
			CheckIfMainPartyStarving();
		}
	}

	private void DailyTick()
	{
		Campaign.Current.IssueManager.ToggleAllIssueTracks(enableTrack: false);
		CheckIfMainPartyStarving();
	}

	private void OnGameLoadFinished()
	{
		if (Settlement.CurrentSettlement != null && Settlement.CurrentSettlement.StringId == "village_ES3_2" && !TutorialPhase.Instance.IsCompleted)
		{
			SpawnYourBrotherInLocation(StoryModeHeroes.ElderBrother, "village_center");
		}
	}

	private void CheckIfMainPartyStarving()
	{
		if (!TutorialPhase.Instance.IsCompleted && PartyBase.MainParty.IsStarving)
		{
			PartyBase.MainParty.ItemRoster.AddToCounts(DefaultItems.Grain, 1);
		}
	}

	private void SpawnAllNotablesForVillage(Village village)
	{
		int targetNotableCountForSettlement = Campaign.Current.Models.NotableSpawnModel.GetTargetNotableCountForSettlement(village.Settlement, Occupation.RuralNotable);
		for (int i = 0; i < targetNotableCountForSettlement; i++)
		{
			HeroCreator.CreateHeroAtOccupation(Occupation.RuralNotable, village.Settlement);
		}
	}
}
