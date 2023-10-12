using System.Collections.Generic;
using System.Linq;
using Helpers;
using SandBox.Conversation;
using SandBox.Missions.AgentBehaviors;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.CampaignSystem.Election;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.Extensions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Party.PartyComponents;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace SandBox.CampaignBehaviors;

public class CompanionRolesCampaignBehavior : CampaignBehaviorBase
{
	private const int CompanionRelationLimit = -10;

	private const int NeededGoldToGrantFief = 20000;

	private const int NeededInfluenceToGrantFief = 500;

	private const int RelationGainWhenCompanionToLordAction = 50;

	private const int NewCreatedHeroForCompanionClanMaxAge = 50;

	private const int NewHeroSkillUpperLimit = 175;

	private const int NewHeroSkillLowerLimit = 125;

	private Settlement _selectedFief;

	private bool _playerConfirmedTheAction;

	private List<int> _alreadyUsedIconIdsForNewClans = new List<int>();

	private bool _partyCreatedAfterRescueForCompanion;

	private bool _partyScreenOpenedForPartyCreationAfterRescue;

	private static CompanionRolesCampaignBehavior CurrentBehavior => Campaign.Current.GetCampaignBehavior<CompanionRolesCampaignBehavior>();

	public override void RegisterEvents()
	{
		CampaignEvents.CompanionRemoved.AddNonSerializedListener(this, OnCompanionRemoved);
		CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener(this, OnSessionLaunched);
		CampaignEvents.HeroRelationChanged.AddNonSerializedListener(this, OnHeroRelationChanged);
	}

	public override void SyncData(IDataStore dataStore)
	{
		dataStore.SyncData("_alreadyUsedIconIdsForNewClans", ref _alreadyUsedIconIdsForNewClans);
	}

	private void OnHeroRelationChanged(Hero effectiveHero, Hero effectiveHeroGainedRelationWith, int relationChange, bool showNotification, ChangeRelationAction.ChangeRelationDetail detail, Hero originalHero, Hero originalGainedRelationWith)
	{
		if (((effectiveHero == Hero.MainHero && effectiveHeroGainedRelationWith.IsPlayerCompanion) || (effectiveHero.IsPlayerCompanion && effectiveHeroGainedRelationWith == Hero.MainHero)) && relationChange < 0 && effectiveHero.GetRelation(effectiveHeroGainedRelationWith) < -10)
		{
			KillCharacterAction.ApplyByRemove(effectiveHero.IsPlayerCompanion ? effectiveHero : effectiveHeroGainedRelationWith);
		}
	}

	public void OnSessionLaunched(CampaignGameStarter campaignGameStarter)
	{
		AddDialogs(campaignGameStarter);
	}

	protected void AddDialogs(CampaignGameStarter campaignGameStarter)
	{
		campaignGameStarter.AddPlayerLine("companion_rejoin_after_emprisonment_role", "hero_main_options", "companion_rejoin", "{=!}{COMPANION_REJOIN_LINE}", companion_rejoin_after_emprisonment_role_on_condition, companion_rejoin_after_emprisonment_role_on_consequence);
		campaignGameStarter.AddDialogLine("companion_rejoin", "companion_rejoin", "close_window", "{=akpaap9e}As you wish.", null, null);
		campaignGameStarter.AddPlayerLine("companion_start_role", "hero_main_options", "companion_role_pretalk", "{=d4t6oUCn}About your position in the clan...", companion_role_discuss_on_condition, null);
		campaignGameStarter.AddDialogLine("companion_pretalk", "companion_role_pretalk", "companion_role", "{=V6jXzuMv}{COMPANION_ROLE}", companion_has_role_on_condition, null);
		campaignGameStarter.AddPlayerLine("companion_talk_fire", "companion_role", "companion_fire", "{=pRsCnGoo}I no longer have need of your services.", () => Hero.OneToOneConversationHero.IsPlayerCompanion && Settlement.CurrentSettlement == null, null);
		campaignGameStarter.AddPlayerLine("companion_talk_fire_2", "companion_role", "companion_assign_new_role", "{=2g18dlwo}I would like to assign you a new role.", companion_assign_role_on_condition, null);
		campaignGameStarter.AddDialogLine("companion_assign_new_role", "companion_assign_new_role", "companion_roles", "{=5ajobQiL}What role do you have in mind?", null, null);
		campaignGameStarter.AddPlayerLine("companion_talk_fire_3", "companion_role", "companion_okay", "{=D33fIGQe}Never mind.", null, null);
		campaignGameStarter.AddPlayerLine("companion_becomes_engineer", "companion_roles", "companion_okay", "{=E91oU7oi}I no longer need you as Engineer.", companion_fire_engineer_on_condition, companion_delete_party_role_consequence);
		campaignGameStarter.AddPlayerLine("companion_becomes_surgeon", "companion_roles", "companion_okay", "{=Dga7sQOu}I no longer need you as Surgeon.", companion_fire_surgeon_on_condition, companion_delete_party_role_consequence);
		campaignGameStarter.AddPlayerLine("companion_becomes_quartermaster", "companion_roles", "companion_okay", "{=GjpJN2xE}I no longer need you as Quartermaster.", companion_fire_quartermaster_on_condition, companion_delete_party_role_consequence);
		campaignGameStarter.AddPlayerLine("companion_becomes_scout", "companion_roles", "companion_okay", "{=EUQnsZFb}I no longer need you as Scout.", companion_fire_scout_on_condition, companion_delete_party_role_consequence);
		campaignGameStarter.AddDialogLine("companion_role_response", "companion_okay", "hero_main_options", "{=dzXaXKaC}Very well.", null, null);
		campaignGameStarter.AddPlayerLine("companion_becomes_engineer_2", "companion_roles", "give_companion_roles", "{=UuFPafDj}Engineer {CURRENTLY_HELD_ENGINEER}", companion_becomes_engineer_on_condition, companion_becomes_engineer_on_consequence);
		campaignGameStarter.AddPlayerLine("companion_becomes_surgeon_2", "companion_roles", "give_companion_roles", "{=6xZ8U3Yz}Surgeon {CURRENTLY_HELD_SURGEON}", companion_becomes_surgeon_on_condition, companion_becomes_surgeon_on_consequence);
		campaignGameStarter.AddPlayerLine("companion_becomes_quartermaster_2", "companion_roles", "give_companion_roles", "{=B0VLXHHz}Quartermaster {CURRENTLY_HELD_QUARTERMASTER}", companion_becomes_quartermaster_on_condition, companion_becomes_quartermaster_on_consequence);
		campaignGameStarter.AddPlayerLine("companion_becomes_scout_2", "companion_roles", "give_companion_roles", "{=3aziL3Gs}Scout {CURRENTLY_HELD_SCOUT}", companion_becomes_scout_on_condition, companion_becomes_scout_on_consequence);
		campaignGameStarter.AddDialogLine("companion_role_response_2", "give_companion_roles", "hero_main_options", "{=5hhxQBTj}I would be honored.", null, null);
		campaignGameStarter.AddPlayerLine("companion_talk_return", "companion_roles", "companion_okay", "{=D33fIGQe}Never mind.", null, null);
		campaignGameStarter.AddDialogLine("companion_start_mission", "hero_main_options", "companion_mission_pretalk", "{=4ry48jbg}I have a mission for you...", () => HeroHelper.IsCompanionInPlayerParty(Hero.OneToOneConversationHero), null);
		campaignGameStarter.AddDialogLine("companion_pretalk_2", "companion_mission_pretalk", "companion_mission", "{=7EoBCTX0}What do you want me to do?", null, null);
		campaignGameStarter.AddPlayerLine("companion_mission_gather_troops", "companion_mission", "companion_recruit_troops", "{=MDik3Kfn}I want you to recruit some troops.", null, null);
		campaignGameStarter.AddPlayerLine("companion_mission_forage", "companion_mission", "companion_forage", "{=kAbebv72}I want you to go forage some food.", null, null);
		campaignGameStarter.AddPlayerLine("companion_mission_patrol", "companion_mission", "companion_patrol", "{=OMaM6ihN}I want you to patrol the area.", null, null);
		campaignGameStarter.AddPlayerLine("companion_mission_cancel", "companion_mission", "hero_main_options", "{=D33fIGQe}Never mind.", null, null);
		campaignGameStarter.AddDialogLine("companion_forage_1", "companion_forage", "companion_forage_2", "{=o2g6Wi9K}As you wish. Will I take some troops with me?", null, null);
		campaignGameStarter.AddPlayerLine("companion_forage_2", "companion_forage_2", "companion_forage_troops", "{=lVbQCibL}Yes. Take these troops with you.", null, null);
		campaignGameStarter.AddPlayerLine("companion_forage_3", "companion_forage_2", "companion_forage_3", "{=3bOcF1Cw}I can't spare anyone now. You will need to go alone.", null, null);
		campaignGameStarter.AddDialogLine("companion_fire", "companion_fire", "companion_fire2", "{=bUzU50P8}What? Why? Did I do something wrong?[ib:closed]", null, null);
		campaignGameStarter.AddPlayerLine("companion_fire_age", "companion_fire2", "companion_fire3", "{=ywtuRAmP}Time has taken its toll on us all, friend. It's time that you retire.", null, null);
		campaignGameStarter.AddPlayerLine("companion_fire_no_fit", "companion_fire2", "companion_fire3", "{=1s3bHupn}You're not getting along with the rest of the company. It's better you go.", null, null);
		campaignGameStarter.AddPlayerLine("companion_fire_no_fit_2", "companion_fire2", "companion_fire3", "{=Q0xPr6CP}I cannot be sure of your loyalty any longer.", null, null);
		campaignGameStarter.AddPlayerLine("companion_fire_underperforming", "companion_fire2", "companion_fire3", "{=aCwCaWGC}Your skills are not what I need.", null, null);
		campaignGameStarter.AddPlayerLine("companion_fire_cancel", "companion_fire2", "companion_fire_cancel", "{=8VlqJteC}I was just jesting. I need you more than ever. Now go back to your job.", null, companion_talk_done_on_consequence);
		campaignGameStarter.AddDialogLine("companion_fire_cancel2", "companion_fire_cancel", "close_window", "{=vctta154}Well {PLAYER.NAME}, it is certainly good to see you still retain your sense of humor.[if:convo_nervous][rb:unsure]", null, null);
		campaignGameStarter.AddDialogLine("companion_fire_farewell", "companion_fire3", "close_window", "{=LrbyNgAa}{AGREE_TO_LEAVE}[rb:unsure]", companion_agrees_to_leave_on_condition, companion_fire_on_consequence);
		campaignGameStarter.AddPlayerLine("turn_companion_to_lord_start", "hero_main_options", "turn_companion_to_lord_talk_answer", "{=B9uT9wa6}I wish to reward you for your services.", turn_companion_to_lord_on_condition, null);
		campaignGameStarter.AddDialogLine("turn_companion_to_lord_start_answer_2", "turn_companion_to_lord_talk_answer", "companion_leading_caravan", "{=IkH0pVhC}I would be honored, my {?PLAYER.GENDER}lady{?}lord{\\?}. But I can't take on any new responsibilities while leading this caravan. If you wish to relieve me of my duties, we can discuss this further.", companion_is_leading_caravan_condition, null);
		campaignGameStarter.AddPlayerLine("turn_companion_to_lord_start_answer_player", "companion_leading_caravan", "lord_pretalk", "{=i7k0AXsO}I see. We will speak again when you are relieved from your duty.", null, null);
		campaignGameStarter.AddDialogLine("turn_companion_to_lord_start_answer", "turn_companion_to_lord_talk_answer", "turn_companion_to_lord_talk", "{=TXO1ihiZ}Thank you, my {?PLAYER.GENDER}lady{?}lord{\\?}. I have often thought about that. If I had a fief, with revenues, and perhaps a title to go with it, I could marry well and pass my wealth down to my heirs, and of course raise troops to help defend the realm.", null, null);
		campaignGameStarter.AddPlayerLine("turn_companion_to_lord_has_fief", "turn_companion_to_lord_talk", "check_player_has_fief_to_grant", "{=KqazzTWV}Indeed. You have shed your blood for me, and you deserve a fief of your own..", null, fief_grant_answer_consequence);
		campaignGameStarter.AddDialogLine("turn_companion_to_lord_has_no_fief", "check_player_has_fief_to_grant", "player_has_no_fief_to_grant", "{=Wx5ysDp1}My {?PLAYER.GENDER}lady{?}lord{\\?}, as much as I appreciate the gesture, I am not sure that you have a suitable estate to grant me.", turn_companion_to_lord_no_fief_on_condition, null);
		campaignGameStarter.AddPlayerLine("turn_companion_to_lord_has_no_fief_player_answer", "player_has_no_fief_to_grant", "player_has_no_fief_to_grant_answer", "{=6uUzWz46}I see. Maybe we will speak again when I have one.", null, null);
		campaignGameStarter.AddDialogLine("turn_companion_to_lord_has_no_fief_companion_answer", "player_has_no_fief_to_grant_answer", "hero_main_options", "{=PP3LzCKk}As you wish, my {?PLAYER.GENDER}lady{?}lord{\\?}.", null, null);
		campaignGameStarter.AddDialogLine("turn_companion_to_lord_has_fief_answer", "check_player_has_fief_to_grant", "player_has_fief_list", "{=ArNB7aaL}Where exactly did you have in mind?[rf:happy]", null, null);
		campaignGameStarter.AddRepeatablePlayerLine("turn_companion_to_lord_has_fief_list", "player_has_fief_list", "player_selected_fief_to_grant", "{=3rHeoq6r}{SETTLEMENT_NAME}.", "{=sxc2D6NJ}I am thinking of a different location.", "check_player_has_fief_to_grant", list_player_fief_on_condition, list_player_fief_selected_on_consequence, 100, list_player_fief_clickable_condition);
		campaignGameStarter.AddPlayerLine("turn_companion_to_lord_has_fief_list_cancel", "player_has_fief_list", "turn_companion_to_lord_fief_conclude", "{=UEbesbKZ}Actually, I have changed my mind.", null, list_player_fief_cancel_on_consequence);
		campaignGameStarter.AddDialogLine("turn_companion_to_lord_fief_selected", "player_selected_fief_to_grant", "turn_companion_to_lord_fief_selected_answer", "{=Mt9abZzi}{SETTLEMENT_NAME}? This is a great honor, my {?PLAYER.GENDER}lady{?}lord{\\?}. I will protect it until the last drop of my blood.[rb:very_positive][rf:happy]", fief_selected_on_condition, null);
		campaignGameStarter.AddPlayerLine("turn_companion_to_lord_fief_selected_confirm", "turn_companion_to_lord_fief_selected_answer", "turn_companion_to_lord_fief_selected_confirm_box", "{=TtlwXnVc}I am pleased to grant you the title of {CULTURE_SPECIFIC_TITLE} and the fiefdom of {SETTLEMENT_NAME}.. You richly deserve it.", null, null, 100, fief_selected_confirm_clickable_on_condition);
		campaignGameStarter.AddPlayerLine("turn_companion_to_lord_fief_selected_reject", "turn_companion_to_lord_fief_selected_answer", "turn_companion_to_lord_fief_conclude", "{=LDGMSQJJ}Very well. Let me think on this a bit longer", null, null);
		campaignGameStarter.AddDialogLine("turn_companion_to_lord_fief_selected_confirm_box", "turn_companion_to_lord_fief_selected_confirm_box", "turn_companion_to_lord_fief_conclude", "{=LOiZfCEy}My {?PLAYER.GENDER}lady{?}lord{\\?}, it would be an honor if you were to choose the name of my noble house.", null, turn_companion_to_lord_consequence);
		campaignGameStarter.AddDialogLine("turn_companion_to_lord_done_answer_thanks", "turn_companion_to_lord_fief_conclude", "close_window", "{=dpYhBgAC}Thank you my {?PLAYER.GENDER}lady{?}lord{\\?}. I will always remember this grand gesture.[rb:positive][rf:happy]", companion_thanks_on_condition, companion_talk_done_on_consequence);
		campaignGameStarter.AddDialogLine("turn_companion_to_lord_done_answer_rejected", "turn_companion_to_lord_fief_conclude", "hero_main_options", "{=SVEptNxR}It's only normal that you have second thoughts. I will be right by your side if you change your mind, my {?PLAYER.GENDER}lady{?}lord{\\?}.[rb:positive][rb:unsure]", null, companion_talk_done_on_consequence);
		campaignGameStarter.AddDialogLine("rescue_companion_start", "start", "rescue_companion_option_acknowledgement", "{=FVOfzPot}{SALUTATION}... Thank you for freeing me.", companion_rescue_start_condition, null);
		campaignGameStarter.AddPlayerLine("rescue_companion_option_acknowledgement", "rescue_companion_option_acknowledgement", "rescue_companion_preoptions", "{=YyNywO6Z}Think nothing of it. I'm glad you're safe.", null, null);
		campaignGameStarter.AddDialogLine("rescue_companion_preoptions", "rescue_companion_preoptions", "rescue_companion_options", "{=kaVMFgBs}What now?", companion_rescue_start_condition, null);
		campaignGameStarter.AddPlayerLine("rescue_companion_option_1", "rescue_companion_options", "rescue_companion_join_party", "{=drIfaTa7}Rejoin the others and let's be off.", null, companion_rescue_answer_options_join_party_consequence);
		campaignGameStarter.AddPlayerLine("rescue_companion_option_2", "rescue_companion_options", "rescue_companion_lead_party", "{=Y6Z8qNW9}I'll need you to lead a party.", null, null, 100, lead_a_party_clickable_condition);
		campaignGameStarter.AddPlayerLine("rescue_companion_option_3", "rescue_companion_options", "rescue_companion_do_nothing", "{=dRKk0E1V}Unfortunately, I can't take you back right now.", null, null);
		campaignGameStarter.AddDialogLine("rescue_companion_lead_party_answer", "rescue_companion_lead_party", "close_window", "{=Q9Ltufg5}Tell me who to command.", null, companion_rescue_answer_options_lead_party_consequence);
		campaignGameStarter.AddDialogLine("rescue_companion_join_party_answer", "rescue_companion_join_party", "close_window", "{=92mngWSd}All right. It's good to be back.", null, end_rescue_companion);
		campaignGameStarter.AddDialogLine("rescue_companion_do_nothing_answer", "rescue_companion_do_nothing", "close_window", "{=gT2O4YXc}I will go off on my own, then. I can stay busy. But I'll remember - I owe you one!", null, end_rescue_companion);
		campaignGameStarter.AddDialogLine("rescue_companion_lead_party_create_party_continue_0", "start", "party_screen_rescue_continue", "{=ppi6eVos}As you wish.", party_screen_continue_conversation_condition, null);
		campaignGameStarter.AddDialogLine("rescue_companion_lead_party_create_party_continue_1", "party_screen_rescue_continue", "rescue_companion_options", "{=ttWBYlxS}So, what shall I do?", party_screen_opened_but_party_is_not_created_after_rescue_condition, party_screen_opened_but_party_is_not_created_after_rescue_consequence);
		campaignGameStarter.AddDialogLine("rescue_companion_lead_party_create_party_continue_2", "party_screen_rescue_continue", "close_window", "{=DiEKuVGF}We'll make ready to set out at once.", party_screen_opened_and_party_is_created_after_rescue_condition, end_rescue_companion);
		campaignGameStarter.AddDialogLine("default_conversation_for_wrongly_created_heroes", "start", "close_window", "{=BaeqKlQ6}I am not allowed to talk with you.", null, null, 0);
	}

	private static bool turn_companion_to_lord_no_fief_on_condition()
	{
		return !Hero.MainHero.Clan.Settlements.Any((Settlement x) => x.IsTown || x.IsCastle);
	}

	private static bool turn_companion_to_lord_on_condition()
	{
		Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
		if (oneToOneConversationHero != null && oneToOneConversationHero.IsPlayerCompanion && Hero.MainHero.IsKingdomLeader)
		{
			CurrentBehavior._playerConfirmedTheAction = false;
			return true;
		}
		return false;
	}

	private static bool companion_is_leading_caravan_condition()
	{
		Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
		if (oneToOneConversationHero != null && oneToOneConversationHero.IsPlayerCompanion && oneToOneConversationHero.PartyBelongedTo != null)
		{
			return oneToOneConversationHero.PartyBelongedTo.IsCaravan;
		}
		return false;
	}

	private static void fief_grant_answer_consequence()
	{
		ConversationSentence.SetObjectsToRepeatOver(Hero.MainHero.Clan.Settlements.Where((Settlement x) => x.IsTown || x.IsCastle).ToList());
	}

	private static bool list_player_fief_clickable_condition(out TextObject explanation)
	{
		explanation = TextObject.Empty;
		Kingdom kingdom = Hero.MainHero.MapFaction as Kingdom;
		Settlement fief = ConversationSentence.CurrentProcessedRepeatObject as Settlement;
		if (fief.SiegeEvent != null)
		{
			explanation = new TextObject("{=arCGUuR5}The settlement is under siege.");
			return false;
		}
		if (fief.Town.IsOwnerUnassigned || kingdom.UnresolvedDecisions.Any((KingdomDecision x) => (x is SettlementClaimantDecision settlementClaimantDecision && settlementClaimantDecision.Settlement == fief) || (x is SettlementClaimantPreliminaryDecision settlementClaimantPreliminaryDecision && settlementClaimantPreliminaryDecision.Settlement == fief)))
		{
			explanation = new TextObject("{=OiPqa3L8}This settlement's ownership will be decided through voting.");
			return false;
		}
		return true;
	}

	private static bool list_player_fief_on_condition()
	{
		if (ConversationSentence.CurrentProcessedRepeatObject is Settlement settlement)
		{
			ConversationSentence.SelectedRepeatLine.SetTextVariable("SETTLEMENT_NAME", settlement.Name);
		}
		return true;
	}

	private void list_player_fief_selected_on_consequence()
	{
		_selectedFief = ConversationSentence.SelectedRepeatObject as Settlement;
	}

	private static void turn_companion_to_lord_consequence()
	{
		TextObject textObject = new TextObject("{=ntDH7J3H}This action costs {NEEDED_GOLD_TO_GRANT_FIEF}{GOLD_ICON} and {NEEDED_INFLUENCE_TO_GRANT_FIEF}{INFLUENCE_ICON}. You will also be granting {SETTLEMENT} to {COMPANION.NAME}.");
		textObject.SetTextVariable("NEEDED_GOLD_TO_GRANT_FIEF", 20000);
		textObject.SetTextVariable("NEEDED_INFLUENCE_TO_GRANT_FIEF", 500);
		textObject.SetTextVariable("INFLUENCE_ICON", "{=!}<img src=\"General\\Icons\\Influence@2x\" extend=\"7\">");
		textObject.SetTextVariable("GOLD_ICON", "{=!}<img src=\"General\\Icons\\Coin@2x\" extend=\"8\">");
		textObject.SetCharacterProperties("COMPANION", Hero.OneToOneConversationHero.CharacterObject);
		textObject.SetTextVariable("SETTLEMENT", CurrentBehavior._selectedFief.Name);
		InformationManager.ShowInquiry(new InquiryData(new TextObject("{=awjomtnJ}Are you sure?").ToString(), textObject.ToString(), isAffirmativeOptionShown: true, isNegativeOptionShown: true, new TextObject("{=aeouhelq}Yes").ToString(), new TextObject("{=8OkPHu4f}No").ToString(), ConfirmTurningCompanionToLordConsequence, RejectTurningCompanionToLordConsequence));
	}

	private static void ConfirmTurningCompanionToLordConsequence()
	{
		CurrentBehavior._playerConfirmedTheAction = true;
		TextObject textObject = new TextObject("{=4eStbG4S}Select {COMPANION.NAME}{.o} clan name: ");
		StringHelpers.SetCharacterProperties("COMPANION", Hero.OneToOneConversationHero.CharacterObject);
		InformationManager.ShowTextInquiry(new TextInquiryData(textObject.ToString(), string.Empty, isAffirmativeOptionShown: true, isNegativeOptionShown: false, GameTexts.FindText("str_done").ToString(), null, ClanNameSelectionIsDone, null, shouldInputBeObfuscated: false, FactionHelper.IsClanNameApplicable));
	}

	private static void RejectTurningCompanionToLordConsequence()
	{
		CurrentBehavior._playerConfirmedTheAction = false;
		Campaign.Current.ConversationManager.ContinueConversation();
	}

	private static void ClanNameSelectionIsDone(string clanName)
	{
		Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
		RemoveCompanionAction.ApplyByByTurningToLord(Hero.MainHero.Clan, oneToOneConversationHero);
		oneToOneConversationHero.SetNewOccupation(Occupation.Lord);
		TextObject textObject = GameTexts.FindText("str_generic_clan_name");
		textObject.SetTextVariable("CLAN_NAME", new TextObject(clanName));
		int randomBannerIdForNewClan = GetRandomBannerIdForNewClan();
		Clan clan = Clan.CreateCompanionToLordClan(oneToOneConversationHero, CurrentBehavior._selectedFief, textObject, randomBannerIdForNewClan);
		if (oneToOneConversationHero.PartyBelongedTo == MobileParty.MainParty)
		{
			MobileParty.MainParty.MemberRoster.AddToCounts(oneToOneConversationHero.CharacterObject, -1);
		}
		MobileParty partyBelongedTo = oneToOneConversationHero.PartyBelongedTo;
		if (partyBelongedTo == null)
		{
			MobileParty mobileParty = LordPartyComponent.CreateLordParty(null, oneToOneConversationHero, MobileParty.MainParty.Position2D, 3f, CurrentBehavior._selectedFief, oneToOneConversationHero);
			mobileParty.MemberRoster.AddToCounts(clan.Culture.BasicTroop, MBRandom.RandomInt(12, 15));
			mobileParty.MemberRoster.AddToCounts(clan.Culture.EliteBasicTroop, MBRandom.RandomInt(10, 15));
		}
		else
		{
			partyBelongedTo.ActualClan = clan;
			partyBelongedTo.Party.SetVisualAsDirty();
		}
		AdjustCompanionsEquipment(oneToOneConversationHero);
		SpawnNewHeroesForNewCompanionClan(oneToOneConversationHero, clan, CurrentBehavior._selectedFief);
		GiveGoldAction.ApplyBetweenCharacters(Hero.MainHero, oneToOneConversationHero, 20000);
		GainKingdomInfluenceAction.ApplyForDefault(Hero.MainHero, -500f);
		ChangeRelationAction.ApplyPlayerRelation(oneToOneConversationHero, 50);
		Campaign.Current.ConversationManager.ContinueConversation();
	}

	private static void AdjustCompanionsEquipment(Hero companionHero)
	{
		Equipment newEquipmentForCompanion = GetNewEquipmentForCompanion(companionHero, isCivilian: true);
		Equipment newEquipmentForCompanion2 = GetNewEquipmentForCompanion(companionHero, isCivilian: false);
		Equipment equipment = new Equipment(isCivilian: true);
		Equipment equipment2 = new Equipment(isCivilian: false);
		for (int i = 0; i < 12; i++)
		{
			if (newEquipmentForCompanion2[i].Item != null && (companionHero.BattleEquipment[i].Item == null || companionHero.BattleEquipment[i].Item.Tier < newEquipmentForCompanion2[i].Item.Tier))
			{
				equipment2[i] = newEquipmentForCompanion2[i];
			}
			else
			{
				equipment2[i] = companionHero.BattleEquipment[i];
			}
			if (newEquipmentForCompanion[i].Item != null && (companionHero.CivilianEquipment[i].Item == null || companionHero.CivilianEquipment[i].Item.Tier < newEquipmentForCompanion[i].Item.Tier))
			{
				equipment[i] = newEquipmentForCompanion[i];
			}
			else
			{
				equipment[i] = companionHero.CivilianEquipment[i];
			}
		}
		EquipmentHelper.AssignHeroEquipmentFromEquipment(companionHero, equipment);
		EquipmentHelper.AssignHeroEquipmentFromEquipment(companionHero, equipment2);
	}

	private static int GetRandomBannerIdForNewClan()
	{
		MBReadOnlyList<int> possibleClanBannerIconsIDs = Hero.MainHero.MapFaction.Culture.PossibleClanBannerIconsIDs;
		int num = possibleClanBannerIconsIDs.GetRandomElement();
		if (CurrentBehavior._alreadyUsedIconIdsForNewClans.Contains(num))
		{
			bool flag = false;
			int num2 = 0;
			do
			{
				num = possibleClanBannerIconsIDs.GetRandomElement();
				num2++;
			}
			while (CurrentBehavior._alreadyUsedIconIdsForNewClans.Contains(num) && num2 < 20);
			flag = num2 != 20;
			if (!flag)
			{
				for (int i = 0; i < possibleClanBannerIconsIDs.Count; i++)
				{
					if (!CurrentBehavior._alreadyUsedIconIdsForNewClans.Contains(possibleClanBannerIconsIDs[i]))
					{
						num = possibleClanBannerIconsIDs[i];
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				num = possibleClanBannerIconsIDs.GetRandomElement();
			}
		}
		if (!CurrentBehavior._alreadyUsedIconIdsForNewClans.Contains(num))
		{
			CurrentBehavior._alreadyUsedIconIdsForNewClans.Add(num);
		}
		return num;
	}

	private static void SpawnNewHeroesForNewCompanionClan(Hero companionHero, Clan clan, Settlement settlement)
	{
		MBReadOnlyList<CharacterObject> lordTemplates = companionHero.Culture.LordTemplates;
		List<Hero> list = new List<Hero>();
		list.Add(CreateNewHeroForNewCompanionClan(lordTemplates.GetRandomElement(), settlement, new Dictionary<SkillObject, int>
		{
			{
				DefaultSkills.Steward,
				MBRandom.RandomInt(100, 175)
			},
			{
				DefaultSkills.Leadership,
				MBRandom.RandomInt(125, 175)
			},
			{
				DefaultSkills.OneHanded,
				MBRandom.RandomInt(125, 175)
			},
			{
				DefaultSkills.Medicine,
				MBRandom.RandomInt(125, 175)
			}
		}));
		list.Add(CreateNewHeroForNewCompanionClan(lordTemplates.GetRandomElement(), settlement, new Dictionary<SkillObject, int>
		{
			{
				DefaultSkills.OneHanded,
				MBRandom.RandomInt(100, 175)
			},
			{
				DefaultSkills.Leadership,
				MBRandom.RandomInt(125, 175)
			},
			{
				DefaultSkills.Tactics,
				MBRandom.RandomInt(125, 175)
			},
			{
				DefaultSkills.Engineering,
				MBRandom.RandomInt(125, 175)
			}
		}));
		list.Add(companionHero);
		foreach (Hero item in list)
		{
			item.Clan = clan;
			item.ChangeState(Hero.CharacterStates.Active);
			ChangeRelationAction.ApplyRelationChangeBetweenHeroes(item, Hero.MainHero, MBRandom.RandomInt(5, 10), showQuickNotification: false);
			if (item != companionHero)
			{
				EnterSettlementAction.ApplyForCharacterOnly(item, settlement);
			}
			foreach (Hero item2 in list)
			{
				if (item != item2)
				{
					ChangeRelationAction.ApplyRelationChangeBetweenHeroes(item, item2, MBRandom.RandomInt(5, 10), showQuickNotification: false);
				}
			}
		}
	}

	private static Hero CreateNewHeroForNewCompanionClan(CharacterObject templateCharacter, Settlement settlement, Dictionary<SkillObject, int> startingSkills)
	{
		Hero hero = HeroCreator.CreateSpecialHero(templateCharacter, settlement, null, null, MBRandom.RandomInt(Campaign.Current.Models.AgeModel.HeroComesOfAge, 50));
		foreach (KeyValuePair<SkillObject, int> startingSkill in startingSkills)
		{
			hero.HeroDeveloper.SetInitialSkillLevel(startingSkill.Key, startingSkill.Value);
		}
		return hero;
	}

	private static Equipment GetNewEquipmentForCompanion(Hero companionHero, bool isCivilian)
	{
		return Campaign.Current.Models.EquipmentSelectionModel.GetEquipmentRostersForCompanion(companionHero, isCivilian).GetRandomElementInefficiently().AllEquipments.GetRandomElement();
	}

	private static void list_player_fief_cancel_on_consequence()
	{
		CurrentBehavior._playerConfirmedTheAction = false;
	}

	private static bool fief_selected_on_condition()
	{
		MBTextManager.SetTextVariable("SETTLEMENT_NAME", CurrentBehavior._selectedFief.Name);
		return true;
	}

	private static bool companion_thanks_on_condition()
	{
		return CurrentBehavior._playerConfirmedTheAction;
	}

	private static bool fief_selected_confirm_clickable_on_condition(out TextObject explanation)
	{
		explanation = TextObject.Empty;
		MBTextManager.SetTextVariable("CULTURE_SPECIFIC_TITLE", HeroHelper.GetTitleInIndefiniteCase(Hero.OneToOneConversationHero));
		MBTextManager.SetTextVariable("SETTLEMENT_NAME", CurrentBehavior._selectedFief.Name);
		bool flag = Hero.MainHero.Gold >= 20000;
		bool flag2 = Hero.MainHero.Clan.Influence >= 500f;
		MBTextManager.SetTextVariable("NEEDED_GOLD_TO_GRANT_FIEF", 20000);
		MBTextManager.SetTextVariable("NEEDED_INFLUENCE_TO_GRANT_FIEF", 500);
		MBTextManager.SetTextVariable("INFLUENCE_ICON", "{=!}<img src=\"General\\Icons\\Influence@2x\" extend=\"7\">");
		MBTextManager.SetTextVariable("GOLD_ICON", "{=!}<img src=\"General\\Icons\\Coin@2x\" extend=\"8\">");
		if (flag && flag2)
		{
			explanation = new TextObject("{=PxQEwCha}You will pay {NEEDED_GOLD_TO_GRANT_FIEF}{GOLD_ICON}, {NEEDED_INFLUENCE_TO_GRANT_FIEF}{INFLUENCE_ICON}.");
			return true;
		}
		explanation = new TextObject("{=!}{GOLD_REQUIREMENT}{INFLUENCE_REQUIREMENT}");
		if (!flag)
		{
			TextObject variable = new TextObject("{=yo2NvkQQ}You need {NEEDED_GOLD_TO_GRANT_FIEF}{GOLD_ICON}. ");
			explanation.SetTextVariable("GOLD_REQUIREMENT", variable);
		}
		if (!flag2)
		{
			TextObject variable2 = new TextObject("{=pDeFXZJd}You need {NEEDED_INFLUENCE_TO_GRANT_FIEF}{INFLUENCE_ICON}.");
			explanation.SetTextVariable("INFLUENCE_REQUIREMENT", variable2);
		}
		return false;
	}

	private static void companion_talk_done_on_consequence()
	{
		if (PlayerEncounter.Current != null)
		{
			PlayerEncounter.LeaveEncounter = true;
		}
	}

	private static void companion_fire_on_consequence()
	{
		Agent oneToOneConversationAgent = ConversationMission.OneToOneConversationAgent;
		RemoveCompanionAction.ApplyByFire(Hero.OneToOneConversationHero.CompanionOf, Hero.OneToOneConversationHero);
		KillCharacterAction.ApplyByRemove(Hero.OneToOneConversationHero);
		if (Hero.MainHero.CurrentSettlement != null)
		{
			AgentNavigator agentNavigator = oneToOneConversationAgent.GetComponent<CampaignAgentComponent>().AgentNavigator;
			if (agentNavigator?.GetActiveBehavior() is FollowAgentBehavior)
			{
				agentNavigator.GetBehaviorGroup<DailyBehaviorGroup>().RemoveBehavior<FollowAgentBehavior>();
			}
			LocationCharacter locationCharacter = LocationComplex.Current.FindCharacter(oneToOneConversationAgent);
			PlayerEncounter.LocationEncounter.RemoveAccompanyingCharacter(locationCharacter);
		}
		if (PlayerEncounter.Current != null)
		{
			PlayerEncounter.LeaveEncounter = true;
		}
	}

	private bool companion_rejoin_after_emprisonment_role_on_condition()
	{
		if (Hero.OneToOneConversationHero != null && !Hero.OneToOneConversationHero.IsPartyLeader && Hero.OneToOneConversationHero.IsPlayerCompanion && Hero.OneToOneConversationHero.PartyBelongedTo != MobileParty.MainParty && (Hero.OneToOneConversationHero.PartyBelongedTo == null || !Hero.OneToOneConversationHero.PartyBelongedTo.IsCaravan))
		{
			if (Settlement.CurrentSettlement != null && Hero.OneToOneConversationHero.GovernorOf == Settlement.CurrentSettlement.Town)
			{
				MBTextManager.SetTextVariable("COMPANION_REJOIN_LINE", "{=Z5zAok5G}I need to recall you to my party, and to stop governing this town.");
			}
			else
			{
				MBTextManager.SetTextVariable("COMPANION_REJOIN_LINE", "{=1QthEZ9R}I am glad that I found you. Please rejoin my party.");
			}
			return true;
		}
		return false;
	}

	private void companion_rejoin_after_emprisonment_role_on_consequence()
	{
		AddHeroToPartyAction.Apply(Hero.OneToOneConversationHero, MobileParty.MainParty);
	}

	private void OnCompanionRemoved(Hero companion, RemoveCompanionAction.RemoveCompanionDetail detail)
	{
		if (LocationComplex.Current != null)
		{
			LocationComplex.Current.RemoveCharacterIfExists(companion);
		}
		if (PlayerEncounter.LocationEncounter != null)
		{
			PlayerEncounter.LocationEncounter.RemoveAccompanyingCharacter(companion);
		}
	}

	private bool companion_agrees_to_leave_on_condition()
	{
		MBTextManager.SetTextVariable("AGREE_TO_LEAVE", new TextObject("{=0geP718k}Well... I don't know what to say. Goodbye, then."));
		return true;
	}

	private static bool companion_has_role_on_condition()
	{
		Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
		SkillEffect.PerkRole heroPerkRole = MobileParty.MainParty.GetHeroPerkRole(oneToOneConversationHero);
		if (heroPerkRole == SkillEffect.PerkRole.None)
		{
			MBTextManager.SetTextVariable("COMPANION_ROLE", new TextObject("{=k7ebznzr}Yes?"));
		}
		else
		{
			MBTextManager.SetTextVariable("COMPANION_ROLE", new TextObject("{=n3bvfe8t}I am currently working as {COMPANION_JOB}."));
			MBTextManager.SetTextVariable("COMPANION_JOB", GameTexts.FindText("role", heroPerkRole.ToString()));
		}
		return true;
	}

	private static bool companion_role_discuss_on_condition()
	{
		if (Hero.OneToOneConversationHero != null)
		{
			return Hero.OneToOneConversationHero.Clan == Clan.PlayerClan;
		}
		return false;
	}

	private static bool companion_assign_role_on_condition()
	{
		if (Hero.OneToOneConversationHero != null && Hero.OneToOneConversationHero.Clan == Clan.PlayerClan)
		{
			return Hero.OneToOneConversationHero.PartyBelongedTo != null;
		}
		return false;
	}

	private static bool companion_becomes_engineer_on_condition()
	{
		Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
		Hero roleHolder = oneToOneConversationHero.PartyBelongedTo.GetRoleHolder(SkillEffect.PerkRole.Engineer);
		if (roleHolder != null)
		{
			TextObject textObject = new TextObject("{=QEp8t8u0}(Currently held by {COMPANION.LINK})");
			StringHelpers.SetCharacterProperties("COMPANION", roleHolder.CharacterObject, textObject);
			MBTextManager.SetTextVariable("CURRENTLY_HELD_ENGINEER", textObject);
		}
		else
		{
			MBTextManager.SetTextVariable("CURRENTLY_HELD_ENGINEER", "{=kNQMkh3j}(Currently unassigned)");
		}
		if (roleHolder != oneToOneConversationHero)
		{
			return MobilePartyHelper.IsHeroAssignableForEngineerInParty(oneToOneConversationHero, oneToOneConversationHero.PartyBelongedTo);
		}
		return false;
	}

	private static void companion_becomes_engineer_on_consequence()
	{
		Hero.OneToOneConversationHero.PartyBelongedTo.SetPartyEngineer(Hero.OneToOneConversationHero);
	}

	private static bool companion_becomes_surgeon_on_condition()
	{
		Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
		Hero roleHolder = oneToOneConversationHero.PartyBelongedTo.GetRoleHolder(SkillEffect.PerkRole.Surgeon);
		if (roleHolder != null)
		{
			TextObject textObject = new TextObject("{=QEp8t8u0}(Currently held by {COMPANION.LINK})");
			StringHelpers.SetCharacterProperties("COMPANION", roleHolder.CharacterObject, textObject);
			MBTextManager.SetTextVariable("CURRENTLY_HELD_SURGEON", textObject);
		}
		else
		{
			MBTextManager.SetTextVariable("CURRENTLY_HELD_SURGEON", "{=kNQMkh3j}(Currently unassigned)");
		}
		if (roleHolder != oneToOneConversationHero)
		{
			return MobilePartyHelper.IsHeroAssignableForSurgeonInParty(oneToOneConversationHero, oneToOneConversationHero.PartyBelongedTo);
		}
		return false;
	}

	private static void companion_becomes_surgeon_on_consequence()
	{
		Hero.OneToOneConversationHero.PartyBelongedTo.SetPartySurgeon(Hero.OneToOneConversationHero);
	}

	private static bool companion_becomes_quartermaster_on_condition()
	{
		Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
		Hero roleHolder = oneToOneConversationHero.PartyBelongedTo.GetRoleHolder(SkillEffect.PerkRole.Quartermaster);
		if (roleHolder != null)
		{
			TextObject textObject = new TextObject("{=QEp8t8u0}(Currently held by {COMPANION.LINK})");
			StringHelpers.SetCharacterProperties("COMPANION", roleHolder.CharacterObject, textObject);
			MBTextManager.SetTextVariable("CURRENTLY_HELD_QUARTERMASTER", textObject);
		}
		else
		{
			MBTextManager.SetTextVariable("CURRENTLY_HELD_QUARTERMASTER", "{=kNQMkh3j}(Currently unassigned)");
		}
		Hero oneToOneConversationHero2 = Hero.OneToOneConversationHero;
		if (roleHolder != oneToOneConversationHero)
		{
			return MobilePartyHelper.IsHeroAssignableForQuartermasterInParty(oneToOneConversationHero2, Hero.OneToOneConversationHero.PartyBelongedTo);
		}
		return false;
	}

	private static void companion_becomes_quartermaster_on_consequence()
	{
		Hero.OneToOneConversationHero.PartyBelongedTo.SetPartyQuartermaster(Hero.OneToOneConversationHero);
	}

	private static bool companion_becomes_scout_on_condition()
	{
		Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
		Hero roleHolder = oneToOneConversationHero.PartyBelongedTo.GetRoleHolder(SkillEffect.PerkRole.Scout);
		if (roleHolder != null)
		{
			TextObject textObject = new TextObject("{=QEp8t8u0}(Currently held by {COMPANION.LINK})");
			StringHelpers.SetCharacterProperties("COMPANION", roleHolder.CharacterObject, textObject);
			MBTextManager.SetTextVariable("CURRENTLY_HELD_SCOUT", textObject);
		}
		else
		{
			MBTextManager.SetTextVariable("CURRENTLY_HELD_SCOUT", "{=kNQMkh3j}(Currently unassigned)");
		}
		if (roleHolder != oneToOneConversationHero)
		{
			return MobilePartyHelper.IsHeroAssignableForScoutInParty(oneToOneConversationHero, oneToOneConversationHero.PartyBelongedTo);
		}
		return false;
	}

	private static void companion_becomes_scout_on_consequence()
	{
		Hero.OneToOneConversationHero.PartyBelongedTo.SetPartyScout(Hero.OneToOneConversationHero);
	}

	private static void companion_delete_party_role_consequence()
	{
		Hero.OneToOneConversationHero.PartyBelongedTo.RemoveHeroPerkRole(Hero.OneToOneConversationHero);
	}

	private static bool companion_fire_engineer_on_condition()
	{
		if (Hero.OneToOneConversationHero.PartyBelongedTo.GetRoleHolder(SkillEffect.PerkRole.Engineer) == Hero.OneToOneConversationHero)
		{
			return Hero.OneToOneConversationHero != Hero.OneToOneConversationHero.PartyBelongedTo.LeaderHero;
		}
		return false;
	}

	private static bool companion_fire_surgeon_on_condition()
	{
		if (Hero.OneToOneConversationHero.PartyBelongedTo.GetRoleHolder(SkillEffect.PerkRole.Surgeon) == Hero.OneToOneConversationHero)
		{
			return Hero.OneToOneConversationHero != Hero.OneToOneConversationHero.PartyBelongedTo.LeaderHero;
		}
		return false;
	}

	private static bool companion_fire_quartermaster_on_condition()
	{
		if (Hero.OneToOneConversationHero.PartyBelongedTo.GetRoleHolder(SkillEffect.PerkRole.Quartermaster) == Hero.OneToOneConversationHero)
		{
			return Hero.OneToOneConversationHero != Hero.OneToOneConversationHero.PartyBelongedTo.LeaderHero;
		}
		return false;
	}

	private static bool companion_fire_scout_on_condition()
	{
		if (Hero.OneToOneConversationHero.PartyBelongedTo.GetRoleHolder(SkillEffect.PerkRole.Scout) == Hero.OneToOneConversationHero)
		{
			return Hero.OneToOneConversationHero != Hero.OneToOneConversationHero.PartyBelongedTo.LeaderHero;
		}
		return false;
	}

	private bool companion_rescue_start_condition()
	{
		if (Campaign.Current.CurrentConversationContext == ConversationContext.FreedHero && Hero.OneToOneConversationHero?.CompanionOf == Clan.PlayerClan && CharacterObject.OneToOneConversationCharacter.Occupation == Occupation.Wanderer && !_partyScreenOpenedForPartyCreationAfterRescue)
		{
			MBTextManager.SetTextVariable("SALUTATION", Campaign.Current.ConversationManager.FindMatchingTextOrNull("str_salutation", CharacterObject.OneToOneConversationCharacter));
			return true;
		}
		return false;
	}

	private void companion_rescue_answer_options_join_party_consequence()
	{
		EndCaptivityAction.ApplyByReleasedAfterBattle(Hero.OneToOneConversationHero);
		Hero.OneToOneConversationHero.ChangeState(Hero.CharacterStates.Active);
		MobileParty.MainParty.AddElementToMemberRoster(CharacterObject.OneToOneConversationCharacter, 1);
	}

	private bool lead_a_party_clickable_condition(out TextObject reason)
	{
		bool num = Clan.PlayerClan.CommanderLimit > Clan.PlayerClan.WarPartyComponents.Count;
		reason = TextObject.Empty;
		if (!num)
		{
			reason = GameTexts.FindText("str_clan_doesnt_have_empty_party_slots");
		}
		return num;
	}

	private void companion_rescue_answer_options_lead_party_consequence()
	{
		Campaign.Current.ConversationManager.ConversationEndOneShot += OpenPartyScreenForRescue;
	}

	private void OpenPartyScreenForRescue()
	{
		TroopRoster.CreateDummyTroopRoster().AddToCounts(CharacterObject.OneToOneConversationCharacter, 1);
		TroopRoster.CreateDummyTroopRoster();
		GameTexts.FindText("str_lord_party_name").SetCharacterProperties("TROOP", CharacterObject.OneToOneConversationCharacter);
		PartyScreenManager.OpenScreenAsCreateClanPartyForHero(Hero.OneToOneConversationHero, PartyScreenClosed, TroopTransferableDelegate);
		_partyScreenOpenedForPartyCreationAfterRescue = true;
	}

	private void PartyScreenClosed(PartyBase leftOwnerParty, TroopRoster leftMemberRoster, TroopRoster leftPrisonRoster, PartyBase rightOwnerParty, TroopRoster rightMemberRoster, TroopRoster rightPrisonRoster, bool fromCancel)
	{
		if (fromCancel)
		{
			return;
		}
		CharacterObject characterAtIndex = leftMemberRoster.GetCharacterAtIndex(0);
		EndCaptivityAction.ApplyByReleasedAfterBattle(characterAtIndex.HeroObject);
		characterAtIndex.HeroObject.ChangeState(Hero.CharacterStates.Active);
		MobileParty.MainParty.AddElementToMemberRoster(characterAtIndex, 1);
		_partyCreatedAfterRescueForCompanion = true;
		MobileParty mobileParty = Clan.PlayerClan.CreateNewMobileParty(characterAtIndex.HeroObject);
		foreach (TroopRosterElement item in leftMemberRoster.GetTroopRoster())
		{
			if (item.Character != characterAtIndex)
			{
				mobileParty.MemberRoster.Add(item);
			}
		}
		foreach (TroopRosterElement item2 in leftPrisonRoster.GetTroopRoster())
		{
			mobileParty.MemberRoster.Add(item2);
		}
	}

	private bool TroopTransferableDelegate(CharacterObject character, PartyScreenLogic.TroopType type, PartyScreenLogic.PartyRosterSide side, PartyBase LeftOwnerParty)
	{
		return !character.IsHero;
	}

	private bool party_screen_continue_conversation_condition()
	{
		if (_partyScreenOpenedForPartyCreationAfterRescue && Campaign.Current.CurrentConversationContext == ConversationContext.FreedHero && Hero.OneToOneConversationHero?.CompanionOf == Clan.PlayerClan)
		{
			return CharacterObject.OneToOneConversationCharacter.Occupation == Occupation.Wanderer;
		}
		return false;
	}

	private bool party_screen_opened_but_party_is_not_created_after_rescue_condition()
	{
		if (!_partyCreatedAfterRescueForCompanion)
		{
			return _partyScreenOpenedForPartyCreationAfterRescue;
		}
		return false;
	}

	private void party_screen_opened_but_party_is_not_created_after_rescue_consequence()
	{
		_partyScreenOpenedForPartyCreationAfterRescue = false;
	}

	private bool party_screen_opened_and_party_is_created_after_rescue_condition()
	{
		if (_partyCreatedAfterRescueForCompanion)
		{
			return _partyScreenOpenedForPartyCreationAfterRescue;
		}
		return false;
	}

	private void end_rescue_companion()
	{
		_partyCreatedAfterRescueForCompanion = false;
		_partyScreenOpenedForPartyCreationAfterRescue = false;
		if (Hero.OneToOneConversationHero.IsPrisoner)
		{
			EndCaptivityAction.ApplyByReleasedAfterBattle(Hero.OneToOneConversationHero);
		}
	}
}
