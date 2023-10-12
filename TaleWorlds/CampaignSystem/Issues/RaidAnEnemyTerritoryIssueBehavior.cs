using System;
using System.Collections.Generic;
using System.Linq;
using Helpers;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.Extensions;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.Issues;

public class RaidAnEnemyTerritoryIssueBehavior : CampaignBehaviorBase
{
	public class RaidAnEnemyTerritoryIssue : IssueBase
	{
		private const int IssueDurationInDays = 60;

		private const int RelationLimitWithPlayer = -10;

		[SaveableField(10)]
		private readonly Kingdom _enemyKingdom;

		public override TextObject IssueBriefByIssueGiver
		{
			get
			{
				TextObject textObject = new TextObject("{=CrzFdo2H}Yes. It's about the war with the {ENEMYFACTION_INFORMALNAME}. [ib:hip][if:convo_excited]We need to tie up some of their forces. A relatively small force moving quickly through their lands and raiding their villages should be a good distraction. Their lords will need to chase the raiders and won't be able to threaten us elsewhere. You seem to be the right {?PLAYER.GENDER}warrior{?}man{\\?} for the job. What do you say? You'll have my gratitude and you'll be well rewarded if you succeed.");
				if (base.IssueOwner.GetTraitLevel(DefaultTraits.Mercy) + base.IssueOwner.GetTraitLevel(DefaultTraits.Honor) >= 0)
				{
					textObject = new TextObject("{=OlIWwLbP}Yes. It's about the war with the {ENEMYFACTION_INFORMALNAME}. [ib:closed][if:convo_pondering]We need to tie up some of their forces, and the easiest way to do that would be to raid their villages. It's a cruel business and will be hard on the common folk, but their lords will need to chase the raiders and it will prevent them from doing the same to us. If you take this on, I shall reward you if you succeed.");
				}
				textObject.SetTextVariable("ENEMYFACTION_INFORMALNAME", _enemyKingdom.InformalName);
				StringHelpers.SetCharacterProperties("PLAYER", CharacterObject.PlayerCharacter, textObject);
				return textObject;
			}
		}

		public override TextObject IssueAcceptByPlayer
		{
			get
			{
				TextObject textObject = new TextObject("{=bLfXzCyc}I'm at your service my {?ISSUE_OWNER.GENDER}lady{?}lord{\\?}. Just tell me the details.");
				StringHelpers.SetCharacterProperties("ISSUE_OWNER", base.IssueOwner.CharacterObject, textObject);
				return textObject;
			}
		}

		public override TextObject IssueQuestSolutionExplanationByIssueGiver
		{
			get
			{
				TextObject textObject = new TextObject("{=aRfMtTUT}Good. See if you can hit {NUMBER_OF_TARGET_VILLAGE} villages. They won't be able to ignore that kind of damage. I'll give you {BASE_REWARD}{GOLD_ICON} for doing that, and {EXTRA_REWARD}{GOLD_ICON} more for every extra one that you raid. Agreed?[if:convo_mocking_revenge]");
				if (base.IssueOwner.GetTraitLevel(DefaultTraits.Mercy) + base.IssueOwner.GetTraitLevel(DefaultTraits.Honor) > 0)
				{
					textObject = new TextObject("{=AEVIa5sQ}So be it. See if you can hit {NUMBER_OF_TARGET_VILLAGE} villages. [if:convo_stern]They won't be able to ignore that, and it will put a dent in their revenues. I'll give you {BASE_REWARD}{GOLD_ICON} for doing that, and {EXTRA_REWARD}{GOLD_ICON} more for every extra one that you raid. Do you agree?");
				}
				textObject.SetTextVariable("NUMBER_OF_TARGET_VILLAGE", 3);
				textObject.SetTextVariable("BASE_REWARD", 15000);
				textObject.SetTextVariable("EXTRA_REWARD", 3000);
				return textObject;
			}
		}

		public override TextObject IssueQuestSolutionAcceptByPlayer
		{
			get
			{
				TextObject textObject = new TextObject("{=nrRvyKgL}I'll strike into their territory as you command, my {?ISSUE_OWNER.GENDER}lady{?}lord{\\?}.");
				StringHelpers.SetCharacterProperties("ISSUE_OWNER", base.IssueOwner.CharacterObject, textObject);
				return textObject;
			}
		}

		public override bool IsThereAlternativeSolution => false;

		public override bool IsThereLordSolution => false;

		public override TextObject Title => new TextObject("{=DSlhMswt}Raid an Enemy Territory");

		public override TextObject Description
		{
			get
			{
				TextObject textObject = new TextObject("{=JEuZoV1E}{ISSUE_OWNER.LINK} asks you to raid enemy villages to distract enemy war parties.");
				StringHelpers.SetCharacterProperties("ISSUE_OWNER", base.IssueOwner.CharacterObject, textObject);
				return textObject;
			}
		}

		internal static void AutoGeneratedStaticCollectObjectsRaidAnEnemyTerritoryIssue(object o, List<object> collectedObjects)
		{
			((RaidAnEnemyTerritoryIssue)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
		}

		protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
		{
			base.AutoGeneratedInstanceCollectObjects(collectedObjects);
			collectedObjects.Add(_enemyKingdom);
		}

		internal static object AutoGeneratedGetMemberValue_enemyKingdom(object o)
		{
			return ((RaidAnEnemyTerritoryIssue)o)._enemyKingdom;
		}

		public RaidAnEnemyTerritoryIssue(Hero issueGiver)
			: base(issueGiver, CampaignTime.DaysFromNow(60f))
		{
			_enemyKingdom = Kingdom.All.Where((Kingdom k) => k.IsAtWarWith(base.IssueOwner.MapFaction)).GetRandomElementInefficiently();
		}

		protected override float GetIssueEffectAmountInternal(IssueEffect issueEffect)
		{
			if (issueEffect == DefaultIssueEffects.ClanInfluence)
			{
				return -0.1f;
			}
			return 0f;
		}

		protected override void OnGameLoad()
		{
		}

		protected override void HourlyTick()
		{
		}

		protected override QuestBase GenerateIssueQuest(string questId)
		{
			return new RaidAnEnemyTerritoryQuest(questId, base.IssueOwner, CampaignTime.DaysFromNow(60f), _enemyKingdom);
		}

		public override IssueFrequency GetFrequency()
		{
			return IssueFrequency.VeryCommon;
		}

		protected override bool CanPlayerTakeQuestConditions(Hero issueGiver, out PreconditionFlags flag, out Hero relationHero, out SkillObject skill)
		{
			flag = PreconditionFlags.None;
			relationHero = null;
			skill = null;
			if (issueGiver.GetRelationWithPlayer() < -10f)
			{
				relationHero = issueGiver;
				flag |= PreconditionFlags.Relation;
			}
			if (Clan.PlayerClan.Kingdom != issueGiver.MapFaction)
			{
				flag |= PreconditionFlags.NotInSameFaction;
			}
			return flag == PreconditionFlags.None;
		}

		public override bool IssueStayAliveConditions()
		{
			if (_enemyKingdom.IsAtWarWith(base.IssueOwner.MapFaction) && !_enemyKingdom.IsEliminated)
			{
				return base.IssueOwner.MapFaction.IsKingdomFaction;
			}
			return false;
		}

		protected override void CompleteIssueWithTimedOutConsequences()
		{
		}
	}

	public class RaidAnEnemyTerritoryQuest : QuestBase
	{
		private const int RenownBonus = 5;

		private const int HonorXpBonus = 10;

		private const int InfluenceBonus = 20;

		private const int RelationBonusWithQuestGiver = 10;

		private const int HonorXpPenalty = -10;

		private const int RelationPenaltyWithQuestGiver = -5;

		[SaveableField(10)]
		private JournalLog _raidedVillagesTrackLog;

		[SaveableField(20)]
		private readonly Kingdom _enemyKingdom;

		[SaveableField(30)]
		private readonly List<Settlement> _raidedVillages;

		public override TextObject Title => new TextObject("{=DSlhMswt}Raid an Enemy Territory");

		public override bool IsRemainingTimeHidden => false;

		private TextObject _questAcceptedByPlayerLog
		{
			get
			{
				TextObject textObject = new TextObject("{=sYfvsMwN}{QUEST_GIVER.LINK} asked you to raid {NUMBER_OF_TARGET_VILLAGE} {ENEMYFACTION_INFORMALNAME} villages to distract their lords and weaken their armies. {?QUEST_GIVER.GENDER}She{?}He{\\?} offers {REWARD_GOLD}{GOLD_ICON} to thank you for your deeds.");
				StringHelpers.SetCharacterProperties("QUEST_GIVER", base.QuestGiver.CharacterObject, textObject);
				textObject.SetTextVariable("NUMBER_OF_TARGET_VILLAGE", 3);
				textObject.SetTextVariable("ENEMYFACTION_INFORMALNAME", _enemyKingdom.InformalName);
				textObject.SetTextVariable("EXTRA_REWARD", 3000);
				textObject.SetTextVariable("GOLD_ICON", "{=!}<img src=\"General\\Icons\\Coin@2x\" extend=\"8\">");
				textObject.SetTextVariable("REWARD_GOLD", 15000);
				return textObject;
			}
		}

		private TextObject _mainHeroRaidedAllVillagesLog => new TextObject("{=gMvDCnlx}You have successfully raided enemy villages and distracted enemy forces as promised.");

		private TextObject _mainHeroCouldNotRaidedAllVillagesLog
		{
			get
			{
				TextObject textObject = new TextObject("{=nRkLFBMl}You failed to raid at least {NUMBER_OF_TARGET_VILLAGE} villages and then report back. {QUEST_GIVER.LINK} is disappointed.");
				StringHelpers.SetCharacterProperties("QUEST_GIVER", base.QuestGiver.CharacterObject, textObject);
				return textObject;
			}
		}

		private TextObject _questGiverDiedLog
		{
			get
			{
				TextObject textObject = new TextObject("{=65BTaOl8}{QUEST_GIVER.LINK} died and your mission is canceled.");
				StringHelpers.SetCharacterProperties("QUEST_GIVER", base.QuestGiver.CharacterObject, textObject);
				return textObject;
			}
		}

		private TextObject _enemyIsOutOfVillagesLog
		{
			get
			{
				TextObject textObject = new TextObject("{=bIDvq6wA}The enemy no longer holds any villages. {QUEST_GIVER.LINK} has canceled your mission.");
				StringHelpers.SetCharacterProperties("QUEST_GIVER", base.QuestGiver.CharacterObject, textObject);
				return textObject;
			}
		}

		private TextObject _declaredWarOnQuestGiverFactionLog
		{
			get
			{
				TextObject textObject = new TextObject("{=2diuD0rT}Your clan/faction is now at war with {QUEST_GIVER.LINK}'s faction. Your agreement with {QUEST_GIVER.LINK} has been canceled.");
				StringHelpers.SetCharacterProperties("QUEST_GIVER", base.QuestGiver.CharacterObject, textObject);
				return textObject;
			}
		}

		private TextObject _playerDeclaredWarQuestLogText
		{
			get
			{
				TextObject textObject = new TextObject("{=bqeWVVEE}Your actions have started a war with {QUEST_GIVER.LINK}'s faction. {?QUEST_GIVER.GENDER}She{?}He{\\?} cancels your agreement and the quest is a failure.");
				StringHelpers.SetCharacterProperties("QUEST_GIVER", base.QuestGiver.CharacterObject, textObject);
				return textObject;
			}
		}

		private TextObject _declaredPeaceBetweenQuestGiverAndEnemyFactionsLog
		{
			get
			{
				TextObject textObject = new TextObject("{=AXsbnTBb}{QUEST_GIVER.LINK} has made peace with the {ENEMYFACTION_INFORMALNAME}. Your agreement with {QUEST_GIVER.LINK} has been canceled.");
				StringHelpers.SetCharacterProperties("QUEST_GIVER", base.QuestGiver.CharacterObject, textObject);
				textObject.SetTextVariable("ENEMYFACTION_INFORMALNAME", _enemyKingdom.InformalName);
				return textObject;
			}
		}

		private TextObject _factionLeftLog
		{
			get
			{
				TextObject textObject = new TextObject("{=c63DWZhr}You left {FACTION}. Your agreement with {QUEST_GIVER.LINK} is terminated.");
				textObject.SetTextVariable("FACTION", base.QuestGiver.MapFaction.EncyclopediaLinkWithName);
				textObject.SetCharacterProperties("QUEST_GIVER", base.QuestGiver.CharacterObject);
				return textObject;
			}
		}

		internal static void AutoGeneratedStaticCollectObjectsRaidAnEnemyTerritoryQuest(object o, List<object> collectedObjects)
		{
			((RaidAnEnemyTerritoryQuest)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
		}

		protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
		{
			base.AutoGeneratedInstanceCollectObjects(collectedObjects);
			collectedObjects.Add(_raidedVillagesTrackLog);
			collectedObjects.Add(_enemyKingdom);
			collectedObjects.Add(_raidedVillages);
		}

		internal static object AutoGeneratedGetMemberValue_raidedVillagesTrackLog(object o)
		{
			return ((RaidAnEnemyTerritoryQuest)o)._raidedVillagesTrackLog;
		}

		internal static object AutoGeneratedGetMemberValue_enemyKingdom(object o)
		{
			return ((RaidAnEnemyTerritoryQuest)o)._enemyKingdom;
		}

		internal static object AutoGeneratedGetMemberValue_raidedVillages(object o)
		{
			return ((RaidAnEnemyTerritoryQuest)o)._raidedVillages;
		}

		public RaidAnEnemyTerritoryQuest(string questId, Hero questGiver, CampaignTime duration, Kingdom enemyKingdom)
			: base(questId, questGiver, duration, 15000)
		{
			_enemyKingdom = enemyKingdom;
			_raidedVillages = new List<Settlement>();
			SetDialogs();
			InitializeQuestOnCreation();
		}

		protected override void InitializeQuestOnGameLoad()
		{
			SetDialogs();
		}

		protected override void HourlyTick()
		{
		}

		protected override void OnTimedOut()
		{
			if (_raidedVillages.Count >= 3)
			{
				MainHeroRaidedAllVillages();
			}
			else
			{
				MainHeroCouldNotRaidedAllVillages();
			}
		}

		protected override void OnBeforeTimedOut(ref bool completeWithSuccess, ref bool doNotResolveTheQuest)
		{
			if (_raidedVillages.Count >= 3)
			{
				completeWithSuccess = true;
			}
		}

		protected override void RegisterEvents()
		{
			base.RegisterEvents();
			CampaignEvents.DailyTickEvent.AddNonSerializedListener(this, DailyTick);
			CampaignEvents.RaidCompletedEvent.AddNonSerializedListener(this, OnRaidCompleted);
			CampaignEvents.HeroKilledEvent.AddNonSerializedListener(this, OnHeroKilled);
			CampaignEvents.OnSettlementOwnerChangedEvent.AddNonSerializedListener(this, OnSettlementOwnerChanged);
			CampaignEvents.WarDeclared.AddNonSerializedListener(this, OnWarDeclared);
			CampaignEvents.MakePeace.AddNonSerializedListener(this, OnMakePeace);
			CampaignEvents.ClanChangedKingdom.AddNonSerializedListener(this, OnClanChangedKingdom);
		}

		private void OnClanChangedKingdom(Clan clan, Kingdom oldKingdom, Kingdom newKingdom, ChangeKingdomAction.ChangeKingdomActionDetail detail, bool showNotification = true)
		{
			if (clan == Clan.PlayerClan && oldKingdom == base.QuestGiver.MapFaction)
			{
				FactionLeft();
			}
		}

		private void DailyTick()
		{
			if (base.QuestDueTime.IsPast && _raidedVillages.Count >= 3)
			{
				MainHeroRaidedAllVillages();
			}
		}

		private void OnRaidCompleted(BattleSideEnum winnerSide, RaidEventComponent raidEvent)
		{
			MapEvent mapEvent = raidEvent.MapEvent;
			if (mapEvent.IsRaid && mapEvent.IsPlayerMapEvent && mapEvent.MapEventSettlement.IsVillage && mapEvent.PlayerSide == winnerSide && !_raidedVillages.Contains(mapEvent.MapEventSettlement))
			{
				_raidedVillages.Add(mapEvent.MapEventSettlement);
				_raidedVillagesTrackLog.UpdateCurrentProgress(_raidedVillages.Count);
				if (_raidedVillages.Count >= 3)
				{
					TextObject textObject = new TextObject("{=VM9xDun7}You have successfully raided target villages. Go back to {QUEST_GIVER.LINK} to get your reward.");
					textObject.SetCharacterProperties("QUEST_GIVER", base.QuestGiver.CharacterObject);
					MBInformationManager.AddQuickInformation(textObject);
				}
			}
		}

		private void OnHeroKilled(Hero victim, Hero killer, KillCharacterAction.KillCharacterActionDetail detail, bool showNotification = true)
		{
			if (victim == base.QuestGiver)
			{
				if (_raidedVillages.Count < 3)
				{
					QuestGiverDied();
				}
				else
				{
					MainHeroRaidedAllVillages();
				}
			}
		}

		private void OnSettlementOwnerChanged(Settlement settlement, bool openToClaim, Hero newOwner, Hero oldOwner, Hero capturerHero, ChangeOwnerOfSettlementAction.ChangeOwnerOfSettlementDetail detail)
		{
			if (oldOwner.MapFaction == _enemyKingdom && _enemyKingdom.Settlements.Count < 3 - _raidedVillages.Count)
			{
				if (_raidedVillages.Count < 3)
				{
					EnemyIsOutOfVillages();
				}
				else
				{
					MainHeroRaidedAllVillages();
				}
			}
		}

		private void OnWarDeclared(IFaction faction1, IFaction faction2, DeclareWarAction.DeclareWarDetail detail)
		{
			if ((faction1 == base.QuestGiver.MapFaction && faction2 == Clan.PlayerClan) || (faction1 == Clan.PlayerClan && faction2 == base.QuestGiver.MapFaction))
			{
				if (_raidedVillages.Count < 3)
				{
					QuestHelper.CheckWarDeclarationAndFailOrCancelTheQuest(this, faction1, faction2, detail, _playerDeclaredWarQuestLogText, _declaredWarOnQuestGiverFactionLog);
				}
				else
				{
					MainHeroRaidedAllVillages();
				}
			}
		}

		private void OnMakePeace(IFaction side1Faction, IFaction side2Faction, MakePeaceAction.MakePeaceDetail detail)
		{
			if ((side1Faction == base.QuestGiver.MapFaction && side2Faction == _enemyKingdom) || (side1Faction == _enemyKingdom && side2Faction == base.QuestGiver.MapFaction))
			{
				if (_raidedVillages.Count < 3)
				{
					DeclaredPeaceBetweenQuestGiverAndEnemyFactions();
				}
				else
				{
					MainHeroRaidedAllVillages();
				}
			}
		}

		protected override void SetDialogs()
		{
			OfferDialogFlow = DialogFlow.CreateDialogFlow("issue_classic_quest_start").NpcLine(new TextObject("{=R21SLyGK}Excellent. You are a brave and loyal warrior. You have my thanks.[ib:hip][if:convo_excited]")).Condition(() => Hero.OneToOneConversationHero == base.QuestGiver)
				.Consequence(QuestAcceptedByPlayerConsequences)
				.CloseDialog();
			DiscussDialogFlow = DialogFlow.CreateDialogFlow("quest_discuss").NpcLine(new TextObject("{=eMrClHp2}Is there any progress on the task I gave you?[ib:hip][if:convo_astonished]")).Condition(DiscussCondition)
				.BeginPlayerOptions()
				.PlayerOption(new TextObject("{=XOv5B84a}Yes, my {?QUEST_GIVER.GENDER}lady{?}lord{\\?}. I raided {RAIDED_VILLAGE_COUNT} villages as you commanded."))
				.Condition(() => _raidedVillages.Count >= 3)
				.NpcLine(new TextObject("{=J4yakjtP}Splendid. You have served me well. Take your well-earned reward.[ib:hip][if:convo_grateful]"))
				.Consequence(delegate
				{
					MainHeroRaidedAllVillages();
					MapEventHelper.OnConversationEnd();
				})
				.CloseDialog()
				.PlayerOption(new TextObject("{=8JvcDnh6}Not yet my {?QUEST_GIVER.GENDER}lady{?}lord{\\?}. I am working on it."))
				.NpcLine(new TextObject("{=EuhvSsPZ}Good. Keep them busy.[if:convo_normal]"))
				.Consequence(MapEventHelper.OnConversationEnd)
				.CloseDialog()
				.PlayerOption(new TextObject("{=pnQN6LrV}The time is not quite right, my {?QUEST_GIVER.GENDER}lady{?}lord{\\?}. I don't want to ride into a trap."))
				.NpcLine(new TextObject("{=DXD3ag49}Well... I hope this delay is for a good reason.[ib:closed2][if:convo_thinking]"))
				.Consequence(MapEventHelper.OnConversationEnd)
				.CloseDialog()
				.EndPlayerOptions()
				.CloseDialog();
		}

		private void QuestAcceptedByPlayerConsequences()
		{
			StartQuest();
			_raidedVillagesTrackLog = AddDiscreteLog(_questAcceptedByPlayerLog, new TextObject("{=RFH1lDMj}Raided Village Count"), 0, 3);
		}

		private bool DiscussCondition()
		{
			if (Hero.OneToOneConversationHero == base.QuestGiver)
			{
				StringHelpers.SetCharacterProperties("QUEST_GIVER", base.QuestGiver.CharacterObject);
				MBTextManager.SetTextVariable("RAIDED_VILLAGE_COUNT", _raidedVillages.Count);
				return true;
			}
			return false;
		}

		private void MainHeroRaidedAllVillages()
		{
			AddLog(_mainHeroRaidedAllVillagesLog);
			Clan.PlayerClan.AddRenown(5f);
			TraitLevelingHelper.OnIssueSolvedThroughQuest(Hero.MainHero, new Tuple<TraitObject, int>[1]
			{
				new Tuple<TraitObject, int>(DefaultTraits.Honor, 10)
			});
			ChangeClanInfluenceAction.Apply(Clan.PlayerClan, 20f);
			RelationshipChangeWithQuestGiver = 10;
			GiveGoldAction.ApplyBetweenCharacters(null, Hero.MainHero, RewardGold);
			if (_raidedVillages.Count > 3)
			{
				int amount = (_raidedVillages.Count - 3) * 3000;
				GiveGoldAction.ApplyBetweenCharacters(null, Hero.MainHero, amount);
			}
			CompleteQuestWithSuccess();
		}

		private void MainHeroCouldNotRaidedAllVillages()
		{
			AddLog(_mainHeroCouldNotRaidedAllVillagesLog);
			TraitLevelingHelper.OnIssueSolvedThroughQuest(Hero.MainHero, new Tuple<TraitObject, int>[1]
			{
				new Tuple<TraitObject, int>(DefaultTraits.Honor, -10)
			});
			RelationshipChangeWithQuestGiver = -5;
		}

		private void QuestGiverDied()
		{
			AddLog(_questGiverDiedLog);
			CompleteQuestWithCancel();
		}

		private void EnemyIsOutOfVillages()
		{
			AddLog(_enemyIsOutOfVillagesLog);
			CompleteQuestWithCancel();
		}

		private void DeclaredPeaceBetweenQuestGiverAndEnemyFactions()
		{
			AddLog(_declaredPeaceBetweenQuestGiverAndEnemyFactionsLog);
			CompleteQuestWithCancel();
		}

		private void FactionLeft()
		{
			AddLog(_factionLeftLog);
			CompleteQuestWithCancel();
		}
	}

	public class RaidAnEnemyTerritoryIssueTypeDefiner : SaveableTypeDefiner
	{
		public RaidAnEnemyTerritoryIssueTypeDefiner()
			: base(586800)
		{
		}

		protected override void DefineClassTypes()
		{
			AddClassDefinition(typeof(RaidAnEnemyTerritoryIssue), 1);
			AddClassDefinition(typeof(RaidAnEnemyTerritoryQuest), 2);
		}
	}

	private const int BaseRewardGold = 15000;

	private const int ExtraRewardMultiplier = 3000;

	private const int TargetRaidVillageCount = 3;

	private const IssueBase.IssueFrequency RaidAnEnemyTerritoryIssueFrequency = IssueBase.IssueFrequency.VeryCommon;

	public override void RegisterEvents()
	{
		CampaignEvents.OnCheckForIssueEvent.AddNonSerializedListener(this, OnCheckForIssue);
	}

	public void OnCheckForIssue(Hero hero)
	{
		if (ConditionsHold(hero))
		{
			Campaign.Current.IssueManager.AddPotentialIssueData(hero, new PotentialIssueData(OnStartIssue, typeof(RaidAnEnemyTerritoryIssue), IssueBase.IssueFrequency.VeryCommon));
		}
		else
		{
			Campaign.Current.IssueManager.AddPotentialIssueData(hero, new PotentialIssueData(typeof(RaidAnEnemyTerritoryIssue), IssueBase.IssueFrequency.VeryCommon));
		}
	}

	private bool ConditionsHold(Hero issueGiver)
	{
		if (issueGiver.IsLord && issueGiver.MapFaction.IsKingdomFaction && issueGiver == ((Kingdom)issueGiver.MapFaction).Leader && issueGiver.GetTraitLevel(DefaultTraits.Mercy) <= 0 && issueGiver.GetTraitLevel(DefaultTraits.Calculating) >= 0)
		{
			return GetAtWarWithFactionCount(issueGiver) >= 1;
		}
		return false;
	}

	private int GetAtWarWithFactionCount(Hero issueGiver)
	{
		int num = 0;
		foreach (Kingdom item in Kingdom.All)
		{
			if (issueGiver.MapFaction != item && issueGiver.MapFaction.IsAtWarWith(item) && item.Settlements.Count > 1)
			{
				num++;
			}
		}
		return num;
	}

	private IssueBase OnStartIssue(in PotentialIssueData pid, Hero issueOwner)
	{
		return new RaidAnEnemyTerritoryIssue(issueOwner);
	}

	public override void SyncData(IDataStore dataStore)
	{
	}
}
