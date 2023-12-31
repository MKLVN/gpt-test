using System.Collections;
using System.Collections.Generic;
using SandBox.CampaignBehaviors;
using SandBox.Issues;
using TaleWorlds.Library;
using TaleWorlds.SaveSystem.Definition;

namespace Sandbox;

internal class AutoGeneratedSaveManager : IAutoGeneratedSaveManager
{
	public void Initialize(DefinitionContext definitionContext)
	{
		TypeDefinition obj = (TypeDefinition)definitionContext.TryGetTypeDefinition(new TypeSaveId(1087001));
		CollectObjectsDelegate collectObjectsDelegate = FamilyFeudIssueBehavior.FamilyFeudIssue.AutoGeneratedStaticCollectObjectsFamilyFeudIssue;
		obj.InitializeForAutoGeneration(collectObjectsDelegate);
		obj.GetPropertyDefinitionWithId(new MemberTypeId(4, 30)).InitializeForAutoGeneration(FamilyFeudIssueBehavior.FamilyFeudIssue.AutoGeneratedGetMemberValueCounterOfferHero);
		obj.GetFieldDefinitionWithId(new MemberTypeId(4, 10)).InitializeForAutoGeneration(FamilyFeudIssueBehavior.FamilyFeudIssue.AutoGeneratedGetMemberValue_targetVillage);
		obj.GetFieldDefinitionWithId(new MemberTypeId(4, 20)).InitializeForAutoGeneration(FamilyFeudIssueBehavior.FamilyFeudIssue.AutoGeneratedGetMemberValue_targetNotable);
		TypeDefinition obj2 = (TypeDefinition)definitionContext.TryGetTypeDefinition(new TypeSaveId(1087002));
		CollectObjectsDelegate collectObjectsDelegate2 = FamilyFeudIssueBehavior.FamilyFeudIssueQuest.AutoGeneratedStaticCollectObjectsFamilyFeudIssueQuest;
		obj2.InitializeForAutoGeneration(collectObjectsDelegate2);
		obj2.GetFieldDefinitionWithId(new MemberTypeId(4, 10)).InitializeForAutoGeneration(FamilyFeudIssueBehavior.FamilyFeudIssueQuest.AutoGeneratedGetMemberValue_targetSettlement);
		obj2.GetFieldDefinitionWithId(new MemberTypeId(4, 20)).InitializeForAutoGeneration(FamilyFeudIssueBehavior.FamilyFeudIssueQuest.AutoGeneratedGetMemberValue_targetNotable);
		obj2.GetFieldDefinitionWithId(new MemberTypeId(4, 30)).InitializeForAutoGeneration(FamilyFeudIssueBehavior.FamilyFeudIssueQuest.AutoGeneratedGetMemberValue_culprit);
		obj2.GetFieldDefinitionWithId(new MemberTypeId(4, 40)).InitializeForAutoGeneration(FamilyFeudIssueBehavior.FamilyFeudIssueQuest.AutoGeneratedGetMemberValue_culpritJoinedPlayerParty);
		obj2.GetFieldDefinitionWithId(new MemberTypeId(4, 50)).InitializeForAutoGeneration(FamilyFeudIssueBehavior.FamilyFeudIssueQuest.AutoGeneratedGetMemberValue_checkForMissionEvents);
		obj2.GetFieldDefinitionWithId(new MemberTypeId(4, 70)).InitializeForAutoGeneration(FamilyFeudIssueBehavior.FamilyFeudIssueQuest.AutoGeneratedGetMemberValue_rewardGold);
		TypeDefinition obj3 = (TypeDefinition)definitionContext.TryGetTypeDefinition(new TypeSaveId(1088001));
		CollectObjectsDelegate collectObjectsDelegate3 = NotableWantsDaughterFoundIssueBehavior.NotableWantsDaughterFoundIssue.AutoGeneratedStaticCollectObjectsNotableWantsDaughterFoundIssue;
		obj3.InitializeForAutoGeneration(collectObjectsDelegate3);
		TypeDefinition obj4 = (TypeDefinition)definitionContext.TryGetTypeDefinition(new TypeSaveId(1088002));
		CollectObjectsDelegate collectObjectsDelegate4 = NotableWantsDaughterFoundIssueBehavior.NotableWantsDaughterFoundIssueQuest.AutoGeneratedStaticCollectObjectsNotableWantsDaughterFoundIssueQuest;
		obj4.InitializeForAutoGeneration(collectObjectsDelegate4);
		obj4.GetFieldDefinitionWithId(new MemberTypeId(4, 10)).InitializeForAutoGeneration(NotableWantsDaughterFoundIssueBehavior.NotableWantsDaughterFoundIssueQuest.AutoGeneratedGetMemberValue_daughterHero);
		obj4.GetFieldDefinitionWithId(new MemberTypeId(4, 20)).InitializeForAutoGeneration(NotableWantsDaughterFoundIssueBehavior.NotableWantsDaughterFoundIssueQuest.AutoGeneratedGetMemberValue_rogueHero);
		obj4.GetFieldDefinitionWithId(new MemberTypeId(4, 50)).InitializeForAutoGeneration(NotableWantsDaughterFoundIssueBehavior.NotableWantsDaughterFoundIssueQuest.AutoGeneratedGetMemberValue_isQuestTargetMission);
		obj4.GetFieldDefinitionWithId(new MemberTypeId(4, 60)).InitializeForAutoGeneration(NotableWantsDaughterFoundIssueBehavior.NotableWantsDaughterFoundIssueQuest.AutoGeneratedGetMemberValue_didPlayerBeatRouge);
		obj4.GetFieldDefinitionWithId(new MemberTypeId(4, 70)).InitializeForAutoGeneration(NotableWantsDaughterFoundIssueBehavior.NotableWantsDaughterFoundIssueQuest.AutoGeneratedGetMemberValue_exitedQuestSettlementForTheFirstTime);
		obj4.GetFieldDefinitionWithId(new MemberTypeId(4, 80)).InitializeForAutoGeneration(NotableWantsDaughterFoundIssueBehavior.NotableWantsDaughterFoundIssueQuest.AutoGeneratedGetMemberValue_isTrackerLogAdded);
		obj4.GetFieldDefinitionWithId(new MemberTypeId(4, 90)).InitializeForAutoGeneration(NotableWantsDaughterFoundIssueBehavior.NotableWantsDaughterFoundIssueQuest.AutoGeneratedGetMemberValue_isDaughterPersuaded);
		obj4.GetFieldDefinitionWithId(new MemberTypeId(4, 91)).InitializeForAutoGeneration(NotableWantsDaughterFoundIssueBehavior.NotableWantsDaughterFoundIssueQuest.AutoGeneratedGetMemberValue_isDaughterCaptured);
		obj4.GetFieldDefinitionWithId(new MemberTypeId(4, 100)).InitializeForAutoGeneration(NotableWantsDaughterFoundIssueBehavior.NotableWantsDaughterFoundIssueQuest.AutoGeneratedGetMemberValue_acceptedDaughtersEscape);
		obj4.GetFieldDefinitionWithId(new MemberTypeId(4, 110)).InitializeForAutoGeneration(NotableWantsDaughterFoundIssueBehavior.NotableWantsDaughterFoundIssueQuest.AutoGeneratedGetMemberValue_targetVillage);
		obj4.GetFieldDefinitionWithId(new MemberTypeId(4, 120)).InitializeForAutoGeneration(NotableWantsDaughterFoundIssueBehavior.NotableWantsDaughterFoundIssueQuest.AutoGeneratedGetMemberValue_villageIsRaidedTalkWithDaughter);
		obj4.GetFieldDefinitionWithId(new MemberTypeId(4, 140)).InitializeForAutoGeneration(NotableWantsDaughterFoundIssueBehavior.NotableWantsDaughterFoundIssueQuest.AutoGeneratedGetMemberValue_villagesAndAlreadyVisitedBooleans);
		obj4.GetFieldDefinitionWithId(new MemberTypeId(4, 130)).InitializeForAutoGeneration(NotableWantsDaughterFoundIssueBehavior.NotableWantsDaughterFoundIssueQuest.AutoGeneratedGetMemberValue_questDifficultyMultiplier);
		TypeDefinition obj5 = (TypeDefinition)definitionContext.TryGetTypeDefinition(new TypeSaveId(345001));
		CollectObjectsDelegate collectObjectsDelegate5 = ProdigalSonIssueBehavior.ProdigalSonIssue.AutoGeneratedStaticCollectObjectsProdigalSonIssue;
		obj5.InitializeForAutoGeneration(collectObjectsDelegate5);
		obj5.GetFieldDefinitionWithId(new MemberTypeId(4, 10)).InitializeForAutoGeneration(ProdigalSonIssueBehavior.ProdigalSonIssue.AutoGeneratedGetMemberValue_prodigalSon);
		obj5.GetFieldDefinitionWithId(new MemberTypeId(4, 20)).InitializeForAutoGeneration(ProdigalSonIssueBehavior.ProdigalSonIssue.AutoGeneratedGetMemberValue_targetHero);
		obj5.GetFieldDefinitionWithId(new MemberTypeId(4, 30)).InitializeForAutoGeneration(ProdigalSonIssueBehavior.ProdigalSonIssue.AutoGeneratedGetMemberValue_targetHouse);
		TypeDefinition obj6 = (TypeDefinition)definitionContext.TryGetTypeDefinition(new TypeSaveId(345002));
		CollectObjectsDelegate collectObjectsDelegate6 = ProdigalSonIssueBehavior.ProdigalSonIssueQuest.AutoGeneratedStaticCollectObjectsProdigalSonIssueQuest;
		obj6.InitializeForAutoGeneration(collectObjectsDelegate6);
		obj6.GetFieldDefinitionWithId(new MemberTypeId(4, 10)).InitializeForAutoGeneration(ProdigalSonIssueBehavior.ProdigalSonIssueQuest.AutoGeneratedGetMemberValue_targetHero);
		obj6.GetFieldDefinitionWithId(new MemberTypeId(4, 20)).InitializeForAutoGeneration(ProdigalSonIssueBehavior.ProdigalSonIssueQuest.AutoGeneratedGetMemberValue_prodigalSon);
		obj6.GetFieldDefinitionWithId(new MemberTypeId(4, 30)).InitializeForAutoGeneration(ProdigalSonIssueBehavior.ProdigalSonIssueQuest.AutoGeneratedGetMemberValue_playerTalkedToTargetHero);
		obj6.GetFieldDefinitionWithId(new MemberTypeId(4, 40)).InitializeForAutoGeneration(ProdigalSonIssueBehavior.ProdigalSonIssueQuest.AutoGeneratedGetMemberValue_targetHouse);
		obj6.GetFieldDefinitionWithId(new MemberTypeId(4, 50)).InitializeForAutoGeneration(ProdigalSonIssueBehavior.ProdigalSonIssueQuest.AutoGeneratedGetMemberValue_questDifficulty);
		obj6.GetFieldDefinitionWithId(new MemberTypeId(4, 60)).InitializeForAutoGeneration(ProdigalSonIssueBehavior.ProdigalSonIssueQuest.AutoGeneratedGetMemberValue_isHouseFightFinished);
		obj6.GetFieldDefinitionWithId(new MemberTypeId(4, 70)).InitializeForAutoGeneration(ProdigalSonIssueBehavior.ProdigalSonIssueQuest.AutoGeneratedGetMemberValue_playerTriedToPersuade);
		TypeDefinition obj7 = (TypeDefinition)definitionContext.TryGetTypeDefinition(new TypeSaveId(310001));
		CollectObjectsDelegate collectObjectsDelegate7 = RivalGangMovingInIssueBehavior.RivalGangMovingInIssue.AutoGeneratedStaticCollectObjectsRivalGangMovingInIssue;
		obj7.InitializeForAutoGeneration(collectObjectsDelegate7);
		obj7.GetPropertyDefinitionWithId(new MemberTypeId(4, 207)).InitializeForAutoGeneration(RivalGangMovingInIssueBehavior.RivalGangMovingInIssue.AutoGeneratedGetMemberValueRivalGangLeader);
		TypeDefinition obj8 = (TypeDefinition)definitionContext.TryGetTypeDefinition(new TypeSaveId(310002));
		CollectObjectsDelegate collectObjectsDelegate8 = RivalGangMovingInIssueBehavior.RivalGangMovingInIssueQuest.AutoGeneratedStaticCollectObjectsRivalGangMovingInIssueQuest;
		obj8.InitializeForAutoGeneration(collectObjectsDelegate8);
		obj8.GetFieldDefinitionWithId(new MemberTypeId(4, 10)).InitializeForAutoGeneration(RivalGangMovingInIssueBehavior.RivalGangMovingInIssueQuest.AutoGeneratedGetMemberValue_rivalGangLeader);
		obj8.GetFieldDefinitionWithId(new MemberTypeId(4, 60)).InitializeForAutoGeneration(RivalGangMovingInIssueBehavior.RivalGangMovingInIssueQuest.AutoGeneratedGetMemberValue_timeoutDurationInDays);
		obj8.GetFieldDefinitionWithId(new MemberTypeId(4, 70)).InitializeForAutoGeneration(RivalGangMovingInIssueBehavior.RivalGangMovingInIssueQuest.AutoGeneratedGetMemberValue_isFinalStage);
		obj8.GetFieldDefinitionWithId(new MemberTypeId(4, 80)).InitializeForAutoGeneration(RivalGangMovingInIssueBehavior.RivalGangMovingInIssueQuest.AutoGeneratedGetMemberValue_isReadyToBeFinalized);
		obj8.GetFieldDefinitionWithId(new MemberTypeId(4, 90)).InitializeForAutoGeneration(RivalGangMovingInIssueBehavior.RivalGangMovingInIssueQuest.AutoGeneratedGetMemberValue_hasBetrayedQuestGiver);
		obj8.GetFieldDefinitionWithId(new MemberTypeId(4, 20)).InitializeForAutoGeneration(RivalGangMovingInIssueBehavior.RivalGangMovingInIssueQuest.AutoGeneratedGetMemberValue_rivalGangLeaderParty);
		obj8.GetFieldDefinitionWithId(new MemberTypeId(4, 30)).InitializeForAutoGeneration(RivalGangMovingInIssueBehavior.RivalGangMovingInIssueQuest.AutoGeneratedGetMemberValue_preparationCompletionTime);
		obj8.GetFieldDefinitionWithId(new MemberTypeId(4, 40)).InitializeForAutoGeneration(RivalGangMovingInIssueBehavior.RivalGangMovingInIssueQuest.AutoGeneratedGetMemberValue_questTimeoutTime);
		obj8.GetFieldDefinitionWithId(new MemberTypeId(4, 110)).InitializeForAutoGeneration(RivalGangMovingInIssueBehavior.RivalGangMovingInIssueQuest.AutoGeneratedGetMemberValue_preparationsComplete);
		obj8.GetFieldDefinitionWithId(new MemberTypeId(4, 120)).InitializeForAutoGeneration(RivalGangMovingInIssueBehavior.RivalGangMovingInIssueQuest.AutoGeneratedGetMemberValue_rewardGold);
		obj8.GetFieldDefinitionWithId(new MemberTypeId(4, 130)).InitializeForAutoGeneration(RivalGangMovingInIssueBehavior.RivalGangMovingInIssueQuest.AutoGeneratedGetMemberValue_issueDifficulty);
		TypeDefinition obj9 = (TypeDefinition)definitionContext.TryGetTypeDefinition(new TypeSaveId(585901));
		CollectObjectsDelegate collectObjectsDelegate9 = RuralNotableInnAndOutIssueBehavior.RuralNotableInnAndOutIssue.AutoGeneratedStaticCollectObjectsRuralNotableInnAndOutIssue;
		obj9.InitializeForAutoGeneration(collectObjectsDelegate9);
		TypeDefinition obj10 = (TypeDefinition)definitionContext.TryGetTypeDefinition(new TypeSaveId(585902));
		CollectObjectsDelegate collectObjectsDelegate10 = RuralNotableInnAndOutIssueBehavior.RuralNotableInnAndOutIssueQuest.AutoGeneratedStaticCollectObjectsRuralNotableInnAndOutIssueQuest;
		obj10.InitializeForAutoGeneration(collectObjectsDelegate10);
		obj10.GetFieldDefinitionWithId(new MemberTypeId(4, 1)).InitializeForAutoGeneration(RuralNotableInnAndOutIssueBehavior.RuralNotableInnAndOutIssueQuest.AutoGeneratedGetMemberValue_tryCount);
		TypeDefinition obj11 = (TypeDefinition)definitionContext.TryGetTypeDefinition(new TypeSaveId(340001));
		CollectObjectsDelegate collectObjectsDelegate11 = SnareTheWealthyIssueBehavior.SnareTheWealthyIssue.AutoGeneratedStaticCollectObjectsSnareTheWealthyIssue;
		obj11.InitializeForAutoGeneration(collectObjectsDelegate11);
		obj11.GetFieldDefinitionWithId(new MemberTypeId(4, 1)).InitializeForAutoGeneration(SnareTheWealthyIssueBehavior.SnareTheWealthyIssue.AutoGeneratedGetMemberValue_targetMerchantCharacter);
		TypeDefinition obj12 = (TypeDefinition)definitionContext.TryGetTypeDefinition(new TypeSaveId(340002));
		CollectObjectsDelegate collectObjectsDelegate12 = SnareTheWealthyIssueBehavior.SnareTheWealthyIssueQuest.AutoGeneratedStaticCollectObjectsSnareTheWealthyIssueQuest;
		obj12.InitializeForAutoGeneration(collectObjectsDelegate12);
		obj12.GetFieldDefinitionWithId(new MemberTypeId(4, 1)).InitializeForAutoGeneration(SnareTheWealthyIssueBehavior.SnareTheWealthyIssueQuest.AutoGeneratedGetMemberValue_targetMerchantCharacter);
		obj12.GetFieldDefinitionWithId(new MemberTypeId(4, 2)).InitializeForAutoGeneration(SnareTheWealthyIssueBehavior.SnareTheWealthyIssueQuest.AutoGeneratedGetMemberValue_targetSettlement);
		obj12.GetFieldDefinitionWithId(new MemberTypeId(4, 3)).InitializeForAutoGeneration(SnareTheWealthyIssueBehavior.SnareTheWealthyIssueQuest.AutoGeneratedGetMemberValue_caravanParty);
		obj12.GetFieldDefinitionWithId(new MemberTypeId(4, 4)).InitializeForAutoGeneration(SnareTheWealthyIssueBehavior.SnareTheWealthyIssueQuest.AutoGeneratedGetMemberValue_gangParty);
		obj12.GetFieldDefinitionWithId(new MemberTypeId(4, 5)).InitializeForAutoGeneration(SnareTheWealthyIssueBehavior.SnareTheWealthyIssueQuest.AutoGeneratedGetMemberValue_questDifficulty);
		obj12.GetFieldDefinitionWithId(new MemberTypeId(4, 6)).InitializeForAutoGeneration(SnareTheWealthyIssueBehavior.SnareTheWealthyIssueQuest.AutoGeneratedGetMemberValue_playerChoice);
		obj12.GetFieldDefinitionWithId(new MemberTypeId(4, 7)).InitializeForAutoGeneration(SnareTheWealthyIssueBehavior.SnareTheWealthyIssueQuest.AutoGeneratedGetMemberValue_canEncounterConversationStart);
		obj12.GetFieldDefinitionWithId(new MemberTypeId(4, 8)).InitializeForAutoGeneration(SnareTheWealthyIssueBehavior.SnareTheWealthyIssueQuest.AutoGeneratedGetMemberValue_isCaravanFollowing);
		TypeDefinition obj13 = (TypeDefinition)definitionContext.TryGetTypeDefinition(new TypeSaveId(121251));
		CollectObjectsDelegate collectObjectsDelegate13 = TheSpyPartyIssueQuestBehavior.TheSpyPartyIssue.AutoGeneratedStaticCollectObjectsTheSpyPartyIssue;
		obj13.InitializeForAutoGeneration(collectObjectsDelegate13);
		obj13.GetFieldDefinitionWithId(new MemberTypeId(4, 10)).InitializeForAutoGeneration(TheSpyPartyIssueQuestBehavior.TheSpyPartyIssue.AutoGeneratedGetMemberValue_selectedSettlement);
		TypeDefinition obj14 = (TypeDefinition)definitionContext.TryGetTypeDefinition(new TypeSaveId(121252));
		CollectObjectsDelegate collectObjectsDelegate14 = TheSpyPartyIssueQuestBehavior.TheSpyPartyIssueQuest.AutoGeneratedStaticCollectObjectsTheSpyPartyIssueQuest;
		obj14.InitializeForAutoGeneration(collectObjectsDelegate14);
		obj14.GetFieldDefinitionWithId(new MemberTypeId(4, 10)).InitializeForAutoGeneration(TheSpyPartyIssueQuestBehavior.TheSpyPartyIssueQuest.AutoGeneratedGetMemberValue_selectedSettlement);
		obj14.GetFieldDefinitionWithId(new MemberTypeId(4, 20)).InitializeForAutoGeneration(TheSpyPartyIssueQuestBehavior.TheSpyPartyIssueQuest.AutoGeneratedGetMemberValue_selectedSpy);
		obj14.GetFieldDefinitionWithId(new MemberTypeId(4, 30)).InitializeForAutoGeneration(TheSpyPartyIssueQuestBehavior.TheSpyPartyIssueQuest.AutoGeneratedGetMemberValue_playerLearnedHasHair);
		obj14.GetFieldDefinitionWithId(new MemberTypeId(4, 40)).InitializeForAutoGeneration(TheSpyPartyIssueQuestBehavior.TheSpyPartyIssueQuest.AutoGeneratedGetMemberValue_playerLearnedHasNoMarkings);
		obj14.GetFieldDefinitionWithId(new MemberTypeId(4, 50)).InitializeForAutoGeneration(TheSpyPartyIssueQuestBehavior.TheSpyPartyIssueQuest.AutoGeneratedGetMemberValue_playerLearnedHasBigSword);
		obj14.GetFieldDefinitionWithId(new MemberTypeId(4, 60)).InitializeForAutoGeneration(TheSpyPartyIssueQuestBehavior.TheSpyPartyIssueQuest.AutoGeneratedGetMemberValue_playerLearnedHasBeard);
		obj14.GetFieldDefinitionWithId(new MemberTypeId(4, 70)).InitializeForAutoGeneration(TheSpyPartyIssueQuestBehavior.TheSpyPartyIssueQuest.AutoGeneratedGetMemberValue_issueDifficultyMultiplier);
		obj14.GetFieldDefinitionWithId(new MemberTypeId(4, 80)).InitializeForAutoGeneration(TheSpyPartyIssueQuestBehavior.TheSpyPartyIssueQuest.AutoGeneratedGetMemberValue_currentDifficultySuffix);
		TypeDefinition obj15 = (TypeDefinition)definitionContext.TryGetTypeDefinition(new TypeSaveId(515254));
		CollectObjectsDelegate collectObjectsDelegate15 = AlleyCampaignBehavior.PlayerAlleyData.AutoGeneratedStaticCollectObjectsPlayerAlleyData;
		obj15.InitializeForAutoGeneration(collectObjectsDelegate15);
		obj15.GetFieldDefinitionWithId(new MemberTypeId(2, 1)).InitializeForAutoGeneration(AlleyCampaignBehavior.PlayerAlleyData.AutoGeneratedGetMemberValueAlley);
		obj15.GetFieldDefinitionWithId(new MemberTypeId(2, 2)).InitializeForAutoGeneration(AlleyCampaignBehavior.PlayerAlleyData.AutoGeneratedGetMemberValueAssignedClanMember);
		obj15.GetFieldDefinitionWithId(new MemberTypeId(2, 3)).InitializeForAutoGeneration(AlleyCampaignBehavior.PlayerAlleyData.AutoGeneratedGetMemberValueUnderAttackBy);
		obj15.GetFieldDefinitionWithId(new MemberTypeId(2, 4)).InitializeForAutoGeneration(AlleyCampaignBehavior.PlayerAlleyData.AutoGeneratedGetMemberValueTroopRoster);
		obj15.GetFieldDefinitionWithId(new MemberTypeId(2, 5)).InitializeForAutoGeneration(AlleyCampaignBehavior.PlayerAlleyData.AutoGeneratedGetMemberValueLastRecruitTime);
		obj15.GetFieldDefinitionWithId(new MemberTypeId(2, 6)).InitializeForAutoGeneration(AlleyCampaignBehavior.PlayerAlleyData.AutoGeneratedGetMemberValueAttackResponseDueDate);
		TypeDefinition obj16 = (TypeDefinition)definitionContext.TryGetTypeDefinition(new TypeSaveId(121253));
		CollectObjectsDelegate collectObjectsDelegate16 = TheSpyPartyIssueQuestBehavior.SuspectNpc.AutoGeneratedStaticCollectObjectsSuspectNpc;
		obj16.InitializeForAutoGeneration(collectObjectsDelegate16);
		obj16.GetFieldDefinitionWithId(new MemberTypeId(1, 10)).InitializeForAutoGeneration(TheSpyPartyIssueQuestBehavior.SuspectNpc.AutoGeneratedGetMemberValueCharacterObject);
		obj16.GetFieldDefinitionWithId(new MemberTypeId(1, 20)).InitializeForAutoGeneration(TheSpyPartyIssueQuestBehavior.SuspectNpc.AutoGeneratedGetMemberValueHasHair);
		obj16.GetFieldDefinitionWithId(new MemberTypeId(1, 30)).InitializeForAutoGeneration(TheSpyPartyIssueQuestBehavior.SuspectNpc.AutoGeneratedGetMemberValueHasBigSword);
		obj16.GetFieldDefinitionWithId(new MemberTypeId(1, 40)).InitializeForAutoGeneration(TheSpyPartyIssueQuestBehavior.SuspectNpc.AutoGeneratedGetMemberValueWithoutMarkings);
		obj16.GetFieldDefinitionWithId(new MemberTypeId(1, 50)).InitializeForAutoGeneration(TheSpyPartyIssueQuestBehavior.SuspectNpc.AutoGeneratedGetMemberValueHasBeard);
		SaveId saveId = SaveId.ReadSaveIdFrom(new StringReader("2 1 0 515254 "));
		ContainerDefinition obj17 = (ContainerDefinition)definitionContext.TryGetTypeDefinition(saveId);
		CollectObjectsDelegate collectObjectsDelegate17 = AutoGeneratedStaticCollectObjectsForList0;
		obj17.InitializeForAutoGeneration(collectObjectsDelegate17, hasNoChildObject: false);
		SaveId saveId2 = SaveId.ReadSaveIdFrom(new StringReader("2 5 0 515254 "));
		ContainerDefinition obj18 = (ContainerDefinition)definitionContext.TryGetTypeDefinition(saveId2);
		CollectObjectsDelegate collectObjectsDelegate18 = AutoGeneratedStaticCollectObjectsForList1;
		obj18.InitializeForAutoGeneration(collectObjectsDelegate18, hasNoChildObject: false);
		SaveId saveId3 = SaveId.ReadSaveIdFrom(new StringReader("2 6 0 515254 "));
		ContainerDefinition obj19 = (ContainerDefinition)definitionContext.TryGetTypeDefinition(saveId3);
		CollectObjectsDelegate collectObjectsDelegate19 = AutoGeneratedStaticCollectObjectsForList2;
		obj19.InitializeForAutoGeneration(collectObjectsDelegate19, hasNoChildObject: false);
	}

	private static void AutoGeneratedStaticCollectObjectsForList0(object o, List<object> collectedObjects)
	{
		IList list = (IList)o;
		for (int i = 0; i < list.Count; i++)
		{
			AlleyCampaignBehavior.PlayerAlleyData item = (AlleyCampaignBehavior.PlayerAlleyData)list[i];
			collectedObjects.Add(item);
		}
	}

	private static void AutoGeneratedStaticCollectObjectsForList1(object o, List<object> collectedObjects)
	{
		IList list = (IList)o;
		for (int i = 0; i < list.Count; i++)
		{
			AlleyCampaignBehavior.PlayerAlleyData item = (AlleyCampaignBehavior.PlayerAlleyData)list[i];
			collectedObjects.Add(item);
		}
	}

	private static void AutoGeneratedStaticCollectObjectsForList2(object o, List<object> collectedObjects)
	{
		IList list = (IList)o;
		for (int i = 0; i < list.Count; i++)
		{
			AlleyCampaignBehavior.PlayerAlleyData item = (AlleyCampaignBehavior.PlayerAlleyData)list[i];
			collectedObjects.Add(item);
		}
	}
}
