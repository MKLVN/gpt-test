using System.Collections.Generic;
using StoryMode.StoryModePhases;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Party.PartyComponents;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace StoryMode.Quests.FirstPhase;

public class IstianasBannerPieceQuest : StoryModeQuestBase
{
	public enum HideoutBattleEndState
	{
		None,
		Retreated,
		Defeated,
		Victory
	}

	private const int MainPartyHealHitPointLimit = 50;

	private const int RaiderPartySize = 10;

	private const int RaiderPartyCount = 2;

	private const string IstianaRaiderPartyStringId = "istiana_banner_piece_quest_raider_party_";

	[SaveableField(1)]
	private readonly Settlement _hideout;

	[SaveableField(2)]
	private readonly List<MobileParty> _raiderParties;

	[SaveableField(3)]
	private HideoutBattleEndState _hideoutBattleEndState;

	private TextObject _startQuestLog => new TextObject("{=GxlPj4GC}Find the hideout that Istiana told you about and get the next banner piece.");

	public override TextObject Title => new TextObject("{=WTjAYUoD}Find another piece of the banner for Istiana");

	public override bool IsRemainingTimeHidden => false;

	public IstianasBannerPieceQuest(Hero questGiver, Settlement hideout)
		: base("istiana_banner_piece_quest", questGiver, StoryModeManager.Current.MainStoryLine.FirstPhase.FirstPhaseEndTime)
	{
		_hideout = hideout;
		StoryModeManager.Current.MainStoryLine.BusyHideouts.Add(_hideout.Hideout);
		_raiderParties = new List<MobileParty>();
		InitializeHideout();
		AddTrackedObject(_hideout);
		SetDialogs();
		InitializeQuestOnCreation();
		AddLog(_startQuestLog);
		_hideoutBattleEndState = HideoutBattleEndState.None;
	}

	protected override void OnFinalize()
	{
		base.OnFinalize();
		StoryModeManager.Current.MainStoryLine.BusyHideouts.Remove(_hideout.Hideout);
	}

	protected override void OnStartQuest()
	{
	}

	protected override void HourlyTick()
	{
	}

	protected override void RegisterEvents()
	{
		CampaignEvents.MapEventEnded.AddNonSerializedListener(this, OnMapEventEnded);
		CampaignEvents.GameMenuOpened.AddNonSerializedListener(this, OnGameMenuOpened);
	}

	protected override void SetDialogs()
	{
		Campaign.Current.ConversationManager.AddDialogFlow(DialogFlow.CreateDialogFlow("hero_main_options").PlayerLine(new TextObject("{=dlBFVkDj}About the task you gave me...")).Condition(conversation_lord_task_given_on_condition)
			.NpcLine(new TextObject("{=F26iH45g}What happened? Have you assembled the banner?"))
			.Condition(() => Hero.OneToOneConversationHero == base.QuestGiver)
			.PlayerLine(new TextObject("{=rY0fdQSb}No, I am still working on it..."))
			.CloseDialog(), this);
	}

	private bool conversation_lord_task_given_on_condition()
	{
		if (Hero.OneToOneConversationHero == base.QuestGiver)
		{
			return base.IsOngoing;
		}
		return false;
	}

	protected override void InitializeQuestOnGameLoad()
	{
		SetDialogs();
		StoryModeManager.Current.MainStoryLine.BusyHideouts.Add(_hideout.Hideout);
	}

	private void InitializeHideout()
	{
		_hideout.Hideout.IsSpotted = true;
		_hideout.IsVisible = true;
		_hideoutBattleEndState = HideoutBattleEndState.None;
		if (_hideout.Hideout.IsInfested)
		{
			return;
		}
		for (int i = 0; i < 2; i++)
		{
			if (!_hideout.Hideout.IsInfested)
			{
				_raiderParties.Add(CreateRaiderParty(i));
			}
		}
	}

	private MobileParty CreateRaiderParty(int number)
	{
		MobileParty mobileParty = BanditPartyComponent.CreateBanditParty("istiana_banner_piece_quest_raider_party_" + number, _hideout.OwnerClan, _hideout.Hideout, isBossParty: false);
		TroopRoster troopRoster = new TroopRoster(mobileParty.Party);
		CharacterObject @object = Campaign.Current.ObjectManager.GetObject<CharacterObject>(_hideout.Culture.StringId + "_bandit");
		troopRoster.AddToCounts(@object, 5);
		TroopRoster prisonerRoster = new TroopRoster(mobileParty.Party);
		mobileParty.InitializeMobilePartyAtPosition(troopRoster, prisonerRoster, _hideout.Position2D);
		mobileParty.SetCustomName(new TextObject("{=u1Pkt4HC}Raiders"));
		mobileParty.ActualClan = _hideout.OwnerClan;
		mobileParty.Position2D = _hideout.Position2D;
		mobileParty.Party.SetVisualAsDirty();
		float totalStrength = mobileParty.Party.TotalStrength;
		int initialGold = (int)(1f * MBRandom.RandomFloat * 20f * totalStrength + 50f);
		mobileParty.InitializePartyTrade(initialGold);
		mobileParty.Ai.SetMoveGoToSettlement(_hideout);
		mobileParty.Ai.SetDoNotMakeNewDecisions(doNotMakeNewDecisions: true);
		mobileParty.SetPartyUsedByQuest(isActivelyUsed: true);
		EnterSettlementAction.ApplyForParty(mobileParty, _hideout);
		return mobileParty;
	}

	private void OnMapEventEnded(MapEvent mapEvent)
	{
		if (PlayerEncounter.Current == null || !mapEvent.IsPlayerMapEvent || Settlement.CurrentSettlement != _hideout)
		{
			return;
		}
		if (mapEvent.WinningSide == mapEvent.PlayerSide)
		{
			_hideoutBattleEndState = HideoutBattleEndState.Victory;
		}
		else if (mapEvent.WinningSide == BattleSideEnum.None)
		{
			_hideoutBattleEndState = HideoutBattleEndState.Retreated;
			if (Hero.MainHero.IsPrisoner && _raiderParties.Contains(Hero.MainHero.PartyBelongedToAsPrisoner.MobileParty))
			{
				EndCaptivityAction.ApplyByPeace(Hero.MainHero);
				if (Hero.MainHero.HitPoints < 50)
				{
					Hero.MainHero.Heal(50 - Hero.MainHero.HitPoints);
				}
				InformationManager.ShowInquiry(new InquiryData(new TextObject("{=FPhWhjq7}Defeated").ToString(), new TextObject("{=rbjjDYXj}You were defeated by the raiders in the hideout but you managed to escape. You need to wait to be able to attack again.").ToString(), isAffirmativeOptionShown: true, isNegativeOptionShown: false, new TextObject("{=yQtzabbe}Close").ToString(), null, null, null));
			}
			if (_hideout.Parties.Count == 0)
			{
				InitializeHideout();
			}
			_hideoutBattleEndState = HideoutBattleEndState.None;
		}
		else
		{
			_hideoutBattleEndState = HideoutBattleEndState.Defeated;
		}
	}

	private void OnGameMenuOpened(MenuCallbackArgs args)
	{
		if (_hideoutBattleEndState != HideoutBattleEndState.Victory && Settlement.CurrentSettlement == _hideout && !_hideout.Hideout.IsInfested)
		{
			InitializeHideout();
		}
		if (_hideoutBattleEndState == HideoutBattleEndState.Victory)
		{
			StoryMode.StoryModePhases.FirstPhase.Instance.CollectBannerPiece();
			CompleteQuestWithSuccess();
			_hideoutBattleEndState = HideoutBattleEndState.None;
		}
		else if (_hideoutBattleEndState == HideoutBattleEndState.Retreated || _hideoutBattleEndState == HideoutBattleEndState.Defeated)
		{
			if (Hero.MainHero.IsPrisoner)
			{
				EndCaptivityAction.ApplyByPeace(Hero.MainHero);
			}
			if (Hero.MainHero.HitPoints < 50)
			{
				Hero.MainHero.Heal(50 - Hero.MainHero.HitPoints);
			}
			InformationManager.ShowInquiry(new InquiryData(new TextObject("{=FPhWhjq7}Defeated").ToString(), new TextObject("{=vxDVCK3n}You were defeated by the raiders in the hideout but you managed to escape. You need to wait to be able to attack again.").ToString(), isAffirmativeOptionShown: true, isNegativeOptionShown: false, new TextObject("{=yQtzabbe}Close").ToString(), null, null, null));
			if (_hideout.Parties.Count == 0)
			{
				InitializeHideout();
			}
		}
		_hideoutBattleEndState = HideoutBattleEndState.None;
	}

	internal static void AutoGeneratedStaticCollectObjectsIstianasBannerPieceQuest(object o, List<object> collectedObjects)
	{
		((IstianasBannerPieceQuest)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		base.AutoGeneratedInstanceCollectObjects(collectedObjects);
		collectedObjects.Add(_hideout);
		collectedObjects.Add(_raiderParties);
	}

	internal static object AutoGeneratedGetMemberValue_hideout(object o)
	{
		return ((IstianasBannerPieceQuest)o)._hideout;
	}

	internal static object AutoGeneratedGetMemberValue_raiderParties(object o)
	{
		return ((IstianasBannerPieceQuest)o)._raiderParties;
	}

	internal static object AutoGeneratedGetMemberValue_hideoutBattleEndState(object o)
	{
		return ((IstianasBannerPieceQuest)o)._hideoutBattleEndState;
	}
}
