using System.Collections.Generic;
using System.Linq;
using Helpers;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.Issues;

public class ScoutEnemyGarrisonsIssueBehavior : CampaignBehaviorBase
{
	public class ScoutEnemyGarrisonsIssue : IssueBase
	{
		private const int MinimumRelationToTakeQuest = -10;

		[SaveableField(10)]
		private Settlement _settlement1;

		[SaveableField(20)]
		private Settlement _settlement2;

		[SaveableField(30)]
		private Settlement _settlement3;

		public override bool IsThereAlternativeSolution => false;

		public override bool IsThereLordSolution => false;

		protected override int RewardGold => 0;

		public override TextObject IssueBriefByIssueGiver => new TextObject("{=rrCkJgtd}We don't know enough about the enemy, [ib:closed][if:convo_thinking]where they are strong and where they are weak. I don't want to lead a huge army through their territory on a wild goose hunt. We need someone to ride through there swiftly, scouting out their garrisons. Can you do this?");

		public override TextObject IssueAcceptByPlayer
		{
			get
			{
				TextObject textObject = new TextObject("{=dGakGflE}Yes, your {?QUEST_GIVER.GENDER}ladyship{?}lordship{\\?}, I'll gladly do it.");
				StringHelpers.SetCharacterProperties("QUEST_GIVER", base.IssueOwner.CharacterObject, textObject);
				return textObject;
			}
		}

		public override TextObject IssueQuestSolutionExplanationByIssueGiver
		{
			get
			{
				TextObject textObject = new TextObject("{=seEyGLMz}Go deep into {ENEMY} territory, to {SETTLEMENT_1}, {SETTLEMENT_2} and {SETTLEMENT_3}. [ib:hip][if:convo_normal]I want to know every detail about them, what sort of fortifications they have, whether the walls are well-manned or undergarrisoned, and any other enemy forces in the vicinity.");
				textObject.SetTextVariable("ENEMY", _settlement1.MapFaction.Name);
				textObject.SetTextVariable("SETTLEMENT_1", _settlement1.Name);
				textObject.SetTextVariable("SETTLEMENT_2", _settlement2.Name);
				textObject.SetTextVariable("SETTLEMENT_3", _settlement3.Name);
				return textObject;
			}
		}

		public override TextObject IssueQuestSolutionAcceptByPlayer => new TextObject("{=g6P6nKIf}Consider it done, commander.");

		public override TextObject Title => new TextObject("{=G79IzJsZ}Scout Enemy Garrisons");

		public override TextObject Description
		{
			get
			{
				TextObject textObject = new TextObject("{=AdoaDR26}{QUEST_GIVER.LINK} asks you to scout {SETTLEMENT_1}, {SETTLEMENT_2} and {SETTLEMENT_3}.");
				StringHelpers.SetCharacterProperties("QUEST_GIVER", base.IssueOwner.CharacterObject, textObject);
				textObject.SetTextVariable("SETTLEMENT_1", _settlement1.Name);
				textObject.SetTextVariable("SETTLEMENT_2", _settlement2.Name);
				textObject.SetTextVariable("SETTLEMENT_3", _settlement3.Name);
				return textObject;
			}
		}

		internal static void AutoGeneratedStaticCollectObjectsScoutEnemyGarrisonsIssue(object o, List<object> collectedObjects)
		{
			((ScoutEnemyGarrisonsIssue)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
		}

		protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
		{
			base.AutoGeneratedInstanceCollectObjects(collectedObjects);
			collectedObjects.Add(_settlement1);
			collectedObjects.Add(_settlement2);
			collectedObjects.Add(_settlement3);
		}

		internal static object AutoGeneratedGetMemberValue_settlement1(object o)
		{
			return ((ScoutEnemyGarrisonsIssue)o)._settlement1;
		}

		internal static object AutoGeneratedGetMemberValue_settlement2(object o)
		{
			return ((ScoutEnemyGarrisonsIssue)o)._settlement2;
		}

		internal static object AutoGeneratedGetMemberValue_settlement3(object o)
		{
			return ((ScoutEnemyGarrisonsIssue)o)._settlement3;
		}

		public ScoutEnemyGarrisonsIssue(Hero issueOwner, List<Settlement> settlements)
			: base(issueOwner, CampaignTime.DaysFromNow(15f))
		{
			_settlement1 = settlements[0];
			_settlement2 = settlements[1];
			_settlement3 = settlements[2];
		}

		protected override void OnGameLoad()
		{
		}

		protected override void HourlyTick()
		{
		}

		protected override QuestBase GenerateIssueQuest(string questId)
		{
			return new ScoutEnemyGarrisonsQuest(questId, base.IssueOwner, _settlement1, _settlement2, _settlement3);
		}

		public override IssueFrequency GetFrequency()
		{
			return IssueFrequency.VeryCommon;
		}

		protected override bool CanPlayerTakeQuestConditions(Hero issueGiver, out PreconditionFlags flag, out Hero relationHero, out SkillObject skill)
		{
			relationHero = null;
			skill = null;
			flag = PreconditionFlags.None;
			if (issueGiver.GetRelationWithPlayer() < -10f)
			{
				flag |= PreconditionFlags.Relation;
				relationHero = issueGiver;
			}
			if (Hero.MainHero.IsKingdomLeader)
			{
				flag |= PreconditionFlags.MainHeroIsKingdomLeader;
			}
			if (issueGiver.MapFaction.IsAtWarWith(Hero.MainHero.MapFaction))
			{
				flag |= PreconditionFlags.AtWar;
			}
			if (Clan.PlayerClan.Tier < 2)
			{
				flag |= PreconditionFlags.ClanTier;
			}
			if (Hero.MainHero.GetSkillValue(DefaultSkills.Scouting) < 30)
			{
				flag |= PreconditionFlags.Skill;
				skill = DefaultSkills.Scouting;
			}
			if (Hero.MainHero.MapFaction != base.IssueOwner.MapFaction)
			{
				flag |= PreconditionFlags.NotInSameFaction;
			}
			return flag == PreconditionFlags.None;
		}

		public override bool IssueStayAliveConditions()
		{
			bool flag = _settlement1.MapFaction.IsAtWarWith(base.IssueOwner.MapFaction) && _settlement2.MapFaction.IsAtWarWith(base.IssueOwner.MapFaction) && _settlement3.MapFaction.IsAtWarWith(base.IssueOwner.MapFaction);
			if (!flag)
			{
				flag = TryToUpdateSettlements();
			}
			if (flag)
			{
				return base.IssueOwner.MapFaction.IsKingdomFaction;
			}
			return false;
		}

		protected override float GetIssueEffectAmountInternal(IssueEffect issueEffect)
		{
			if (issueEffect == DefaultIssueEffects.ClanInfluence)
			{
				return -0.1f;
			}
			return 0f;
		}

		private bool TryToUpdateSettlements()
		{
			Kingdom randomElementWithPredicate = Kingdom.All.GetRandomElementWithPredicate((Kingdom x) => x.IsAtWarWith(base.IssueOwner.MapFaction));
			if (randomElementWithPredicate != null)
			{
				List<Settlement> list = randomElementWithPredicate.Settlements.Where((Settlement x) => SuitableSettlementCondition(x, base.IssueOwner)).ToList();
				if (list.Count >= 5)
				{
					list = list.Take(3).ToList();
					_settlement1 = list[0];
					_settlement2 = list[1];
					_settlement3 = list[2];
					return true;
				}
			}
			return false;
		}

		protected override void CompleteIssueWithTimedOutConsequences()
		{
		}
	}

	public class ScoutEnemyGarrisonsQuest : QuestBase
	{
		[SaveableField(10)]
		private QuestSettlement _questSettlement1;

		[SaveableField(20)]
		private QuestSettlement _questSettlement2;

		[SaveableField(30)]
		private QuestSettlement _questSettlement3;

		[SaveableField(40)]
		private int _scoutedSettlementCount;

		[SaveableField(50)]
		private JournalLog _startQuestLog;

		public override bool IsRemainingTimeHidden => false;

		public override TextObject Title => new TextObject("{=G79IzJsZ}Scout Enemy Garrisons");

		private TextObject _playerStartsQuestLogText
		{
			get
			{
				TextObject textObject = new TextObject("{=8avwit9N}{QUEST_GIVER.LINK}, the army commander of {FACTION} has told you that they need detailed information about enemy fortifications and troop numbers of the enemy. {?QUEST_GIVER.GENDER}She{?}He{\\?} wanted you to scout {SETTLEMENT_1}, {SETTLEMENT_2} and {SETTLEMENT_3}.");
				StringHelpers.SetCharacterProperties("QUEST_GIVER", base.QuestGiver.CharacterObject, textObject);
				textObject.SetTextVariable("FACTION", base.QuestGiver.MapFaction.EncyclopediaLinkWithName);
				textObject.SetTextVariable("SETTLEMENT_1", _questSettlement1.Settlement.EncyclopediaLinkWithName);
				textObject.SetTextVariable("SETTLEMENT_2", _questSettlement2.Settlement.EncyclopediaLinkWithName);
				textObject.SetTextVariable("SETTLEMENT_3", _questSettlement3.Settlement.EncyclopediaLinkWithName);
				return textObject;
			}
		}

		private TextObject _settlementBecomeNeutralLogText => new TextObject("{=wgX2nL5Z}{SETTLEMENT} is no longer in control of enemy. There is no need to scout that settlement.");

		private TextObject _armyDisbandedQuestCancelLogText => new TextObject("{=JiHaL6IV}Army has disbanded and your mission has been canceled.");

		private TextObject _noLongerAllyQuestCancelLogText
		{
			get
			{
				TextObject textObject = new TextObject("{=vTnSa9rr}You are no longer allied with {QUEST_GIVER.LINK}'s faction. Your agreement with {QUEST_GIVER.LINK} was terminated.");
				StringHelpers.SetCharacterProperties("QUEST_GIVER", base.QuestGiver.CharacterObject, textObject);
				return textObject;
			}
		}

		private TextObject _allTargetsAreNeutral => new TextObject("{=LC2F84GR}None of the target settlements are in control of the enemy. Army Commander has canceled the mission.");

		private TextObject _scoutFinishedForSettlementWallLevel1LogText => new TextObject("{=5kxDhBWk}Your scouts have returned from {SETTLEMENT}. According to their report {SETTLEMENT}'s garrison has {GARRISON_SIZE} men and walls are not high enough but can be useful with sufficient garrison support.");

		private TextObject _scoutFinishedForSettlementWallLevel2LogText => new TextObject("{=GUqjL6xk}Your scouts have returned from {SETTLEMENT}. According to their report {SETTLEMENT}'s garrison has {GARRISON_SIZE} men and walls are high enough to defend against invaders.");

		private TextObject _scoutFinishedForSettlementWallLevel3LogText => new TextObject("{=YErURO5l}Your scouts have returned from {SETTLEMENT}. According to their report {SETTLEMENT}'s garrison has {GARRISON_SIZE} men and walls are too high and hard to breach.");

		private TextObject _questSuccess => new TextObject("{=Qy7Zmmvk}You have successfully scouted the target settlements.");

		private TextObject _questTimedOut => new TextObject("{=GzodT3vS}You have failed to scout the enemy settlements in time.");

		internal static void AutoGeneratedStaticCollectObjectsScoutEnemyGarrisonsQuest(object o, List<object> collectedObjects)
		{
			((ScoutEnemyGarrisonsQuest)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
		}

		protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
		{
			base.AutoGeneratedInstanceCollectObjects(collectedObjects);
			collectedObjects.Add(_questSettlement1);
			collectedObjects.Add(_questSettlement2);
			collectedObjects.Add(_questSettlement3);
			collectedObjects.Add(_startQuestLog);
		}

		internal static object AutoGeneratedGetMemberValue_questSettlement1(object o)
		{
			return ((ScoutEnemyGarrisonsQuest)o)._questSettlement1;
		}

		internal static object AutoGeneratedGetMemberValue_questSettlement2(object o)
		{
			return ((ScoutEnemyGarrisonsQuest)o)._questSettlement2;
		}

		internal static object AutoGeneratedGetMemberValue_questSettlement3(object o)
		{
			return ((ScoutEnemyGarrisonsQuest)o)._questSettlement3;
		}

		internal static object AutoGeneratedGetMemberValue_scoutedSettlementCount(object o)
		{
			return ((ScoutEnemyGarrisonsQuest)o)._scoutedSettlementCount;
		}

		internal static object AutoGeneratedGetMemberValue_startQuestLog(object o)
		{
			return ((ScoutEnemyGarrisonsQuest)o)._startQuestLog;
		}

		public ScoutEnemyGarrisonsQuest(string questId, Hero questGiver, Settlement settlement1, Settlement settlement2, Settlement settlement3)
			: base(questId, questGiver, CampaignTime.DaysFromNow(15f), 0)
		{
			_questSettlement1 = new QuestSettlement(settlement1, 0);
			_questSettlement2 = new QuestSettlement(settlement2, 0);
			_questSettlement3 = new QuestSettlement(settlement3, 0);
			SetDialogs();
			InitializeQuestOnCreation();
		}

		protected override void InitializeQuestOnGameLoad()
		{
			SetDialogs();
		}

		protected override void SetDialogs()
		{
			OfferDialogFlow = DialogFlow.CreateDialogFlow("issue_classic_quest_start").NpcLine(new TextObject("{=lyGvyZK4}Very well. When you reach one of their fortresses, spend some time observing. Don't move on to the next one at once. You don't need to find me to report back the details, just send your messengers.")).Condition(() => Hero.OneToOneConversationHero == base.QuestGiver)
				.Consequence(QuestAcceptedConsequences)
				.CloseDialog();
			DiscussDialogFlow = DialogFlow.CreateDialogFlow("quest_discuss").NpcLine(new TextObject("{=x3TO0gkN}Is there any progress on the task I gave you?[ib:closed][if:convo_normal]")).Condition(() => Hero.OneToOneConversationHero == base.QuestGiver)
				.Consequence(delegate
				{
					Campaign.Current.ConversationManager.ConversationEndOneShot += MapEventHelper.OnConversationEnd;
				})
				.BeginPlayerOptions()
				.PlayerOption(new TextObject("{=W5ab31gQ}Soon, commander. We are still working on it."))
				.NpcLine(new TextObject("{=U3LR7dyK}Good. I'll be waiting for your messengers.[if:convo_thinking]"))
				.CloseDialog()
				.PlayerOption(new TextObject("{=v75k1FoT}Not yet. We need to make more preparations."))
				.NpcLine(new TextObject("{=zYKeYZAo}All right. Don't rush this but also don't wait too long."))
				.CloseDialog()
				.EndPlayerOptions()
				.CloseDialog();
		}

		private void QuestAcceptedConsequences()
		{
			StartQuest();
			AddTrackedObject(_questSettlement1.Settlement);
			AddTrackedObject(_questSettlement2.Settlement);
			AddTrackedObject(_questSettlement3.Settlement);
			_scoutedSettlementCount = 0;
			_startQuestLog = AddDiscreteLog(_playerStartsQuestLogText, new TextObject("{=jpBpwgAs}Settlements"), _scoutedSettlementCount, 3);
		}

		protected override void RegisterEvents()
		{
			CampaignEvents.ClanChangedKingdom.AddNonSerializedListener(this, OnClanChangedKingdom);
			CampaignEvents.ArmyDispersed.AddNonSerializedListener(this, OnArmyDispersed);
			CampaignEvents.OnSettlementOwnerChangedEvent.AddNonSerializedListener(this, OnSettlementOwnerChanged);
		}

		protected override void HourlyTick()
		{
			if (!base.IsOngoing)
			{
				return;
			}
			List<QuestSettlement> list = new List<QuestSettlement> { _questSettlement1, _questSettlement2, _questSettlement3 };
			if (list.TrueForAll((QuestSettlement x) => !x.Settlement.MapFaction.IsAtWarWith(base.QuestGiver.MapFaction)))
			{
				AddLog(_allTargetsAreNeutral);
				CompleteQuestWithCancel();
				return;
			}
			foreach (QuestSettlement item in list)
			{
				if (item.IsScoutingCompleted())
				{
					continue;
				}
				if (Campaign.Current.Models.MapDistanceModel.GetDistance(MobileParty.MainParty, item.Settlement) <= MobileParty.MainParty.SeeingRange)
				{
					item.CurrentScoutProgress++;
					if (item.CurrentScoutProgress == 1)
					{
						TextObject textObject = new TextObject("{=qfjRGjM4}Your scouts started to gather information about {SETTLEMENT}.");
						textObject.SetTextVariable("SETTLEMENT", item.Settlement.Name);
						MBInformationManager.AddQuickInformation(textObject);
					}
					else if (item.IsScoutingCompleted())
					{
						_startQuestLog.UpdateCurrentProgress(++_scoutedSettlementCount);
						RemoveTrackedObject(item.Settlement);
						TextObject empty = TextObject.Empty;
						empty = ((item.Settlement.Town.GetWallLevel() == 1) ? _scoutFinishedForSettlementWallLevel1LogText : ((item.Settlement.Town.GetWallLevel() != 2) ? _scoutFinishedForSettlementWallLevel3LogText : _scoutFinishedForSettlementWallLevel2LogText));
						empty.SetTextVariable("SETTLEMENT", item.Settlement.EncyclopediaLinkWithName);
						int num = item.Settlement.Town.GarrisonParty?.MemberRoster.TotalHealthyCount ?? 0;
						int num2 = (int)item.Settlement.Militia;
						empty.SetTextVariable("GARRISON_SIZE", num + num2);
						AddLog(empty);
					}
				}
				else
				{
					item.ResetCurrentProgress();
				}
			}
			if (list.TrueForAll((QuestSettlement x) => x.IsScoutingCompleted()))
			{
				AllScoutingDone();
			}
		}

		private void OnSettlementOwnerChanged(Settlement settlement, bool openToClaim, Hero newOwner, Hero oldOwner, Hero capturerHero, ChangeOwnerOfSettlementAction.ChangeOwnerOfSettlementDetail detail)
		{
			List<QuestSettlement> list = new List<QuestSettlement> { _questSettlement1, _questSettlement2, _questSettlement3 };
			foreach (QuestSettlement item in list)
			{
				if (settlement == item.Settlement && (newOwner.MapFaction == base.QuestGiver.MapFaction || !newOwner.MapFaction.IsAtWarWith(base.QuestGiver.MapFaction)))
				{
					item.IsCompletedThroughBeingNeutral = true;
					item.SetScoutingCompleted();
					_startQuestLog.UpdateCurrentProgress(++_scoutedSettlementCount);
					if (IsTracked(item.Settlement))
					{
						RemoveTrackedObject(item.Settlement);
					}
					TextObject settlementBecomeNeutralLogText = _settlementBecomeNeutralLogText;
					settlementBecomeNeutralLogText.SetTextVariable("SETTLEMENT", item.Settlement.EncyclopediaLinkWithName);
					AddLog(settlementBecomeNeutralLogText);
					if (list.TrueForAll((QuestSettlement x) => x.IsCompletedThroughBeingNeutral))
					{
						AddLog(_allTargetsAreNeutral);
						CompleteQuestWithCancel();
					}
					break;
				}
			}
		}

		private void OnArmyDispersed(Army army, Army.ArmyDispersionReason reason, bool isPlayersArmy)
		{
			if (army.ArmyOwner == base.QuestGiver)
			{
				AddLog(_armyDisbandedQuestCancelLogText);
				CompleteQuestWithCancel();
			}
		}

		private void OnClanChangedKingdom(Clan clan, Kingdom oldKingdom, Kingdom newKingdom, ChangeKingdomAction.ChangeKingdomActionDetail detail, bool showNotification = true)
		{
			if (clan == Clan.PlayerClan && oldKingdom == base.QuestGiver.MapFaction)
			{
				AddLog(_noLongerAllyQuestCancelLogText);
				CompleteQuestWithCancel();
			}
		}

		private void AllScoutingDone()
		{
			AddLog(_questSuccess);
			GainRenownAction.Apply(Hero.MainHero, 3f);
			GainKingdomInfluenceAction.ApplyForDefault(Hero.MainHero, 10f);
			RelationshipChangeWithQuestGiver = 3;
			CompleteQuestWithSuccess();
		}

		protected override void OnTimedOut()
		{
			AddLog(_questTimedOut);
			RelationshipChangeWithQuestGiver = -2;
		}
	}

	public class QuestSettlement
	{
		private const int CompleteScoutAfterHours = 8;

		[SaveableField(10)]
		public Settlement Settlement;

		[SaveableField(20)]
		public int CurrentScoutProgress;

		public bool IsCompletedThroughBeingNeutral;

		internal static void AutoGeneratedStaticCollectObjectsQuestSettlement(object o, List<object> collectedObjects)
		{
			((QuestSettlement)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
		}

		protected virtual void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
		{
			collectedObjects.Add(Settlement);
		}

		internal static object AutoGeneratedGetMemberValueSettlement(object o)
		{
			return ((QuestSettlement)o).Settlement;
		}

		internal static object AutoGeneratedGetMemberValueCurrentScoutProgress(object o)
		{
			return ((QuestSettlement)o).CurrentScoutProgress;
		}

		public QuestSettlement(Settlement settlement, int currentScoutProgress)
		{
			Settlement = settlement;
			CurrentScoutProgress = currentScoutProgress;
			IsCompletedThroughBeingNeutral = false;
		}

		public bool IsScoutingCompleted()
		{
			return CurrentScoutProgress >= 8;
		}

		public void SetScoutingCompleted()
		{
			CurrentScoutProgress = 8;
		}

		public void ResetCurrentProgress()
		{
			CurrentScoutProgress = 0;
		}
	}

	public class ScoutEnemyGarrisonsIssueTypeDefiner : SaveableTypeDefiner
	{
		public ScoutEnemyGarrisonsIssueTypeDefiner()
			: base(97600)
		{
		}

		protected override void DefineClassTypes()
		{
			AddClassDefinition(typeof(ScoutEnemyGarrisonsIssue), 1);
			AddClassDefinition(typeof(ScoutEnemyGarrisonsQuest), 2);
			AddClassDefinition(typeof(QuestSettlement), 3);
		}
	}

	private const IssueBase.IssueFrequency ScoutEnemyGarrisonsIssueFrequency = IssueBase.IssueFrequency.VeryCommon;

	private const int QuestDurationInDays = 15;

	public override void RegisterEvents()
	{
		CampaignEvents.OnCheckForIssueEvent.AddNonSerializedListener(this, OnCheckForIssue);
	}

	public void OnCheckForIssue(Hero hero)
	{
		if (ConditionsHold(hero, out var settlements))
		{
			Campaign.Current.IssueManager.AddPotentialIssueData(hero, new PotentialIssueData(OnStartIssue, typeof(ScoutEnemyGarrisonsIssue), IssueBase.IssueFrequency.VeryCommon, settlements));
		}
		else
		{
			Campaign.Current.IssueManager.AddPotentialIssueData(hero, new PotentialIssueData(typeof(ScoutEnemyGarrisonsIssue), IssueBase.IssueFrequency.VeryCommon));
		}
	}

	private bool ConditionsHold(Hero issueGiver, out List<Settlement> settlements)
	{
		settlements = new List<Settlement>();
		if (issueGiver.MapFaction.IsKingdomFaction && issueGiver.IsFactionLeader && !issueGiver.IsMinorFactionHero && !issueGiver.IsPrisoner && !issueGiver.IsFugitive)
		{
			if (issueGiver.GetMapPoint() != null)
			{
				Kingdom randomElementWithPredicate = Kingdom.All.GetRandomElementWithPredicate((Kingdom x) => x.IsAtWarWith(issueGiver.MapFaction));
				if (randomElementWithPredicate != null)
				{
					List<Settlement> list = randomElementWithPredicate.Settlements.Where((Settlement x) => SuitableSettlementCondition(x, issueGiver)).ToList();
					if (list.Count >= 5)
					{
						list = list.OrderBy((Settlement y) => issueGiver.GetMapPoint().Position2D.Distance(y.Position2D)).ToList();
						settlements = list.Take(3).ToList();
						return true;
					}
				}
			}
			return false;
		}
		return false;
	}

	private IssueBase OnStartIssue(in PotentialIssueData pid, Hero issueOwner)
	{
		return new ScoutEnemyGarrisonsIssue(issueOwner, pid.RelatedObject as List<Settlement>);
	}

	public override void SyncData(IDataStore dataStore)
	{
	}

	private static bool SuitableSettlementCondition(Settlement settlement, Hero issueGiver)
	{
		if (settlement.IsFortification && settlement.MapFaction.IsAtWarWith(issueGiver.MapFaction))
		{
			if (settlement.IsUnderSiege)
			{
				return settlement.SiegeEvent.BesiegerCamp.LeaderParty.MapFaction != Hero.MainHero.MapFaction;
			}
			return true;
		}
		return false;
	}
}
