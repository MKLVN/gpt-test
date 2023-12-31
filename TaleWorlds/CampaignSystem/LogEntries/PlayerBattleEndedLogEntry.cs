using System.Collections.Generic;
using Helpers;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.LogEntries;

public class PlayerBattleEndedLogEntry : LogEntry, IChatNotification
{
	[SaveableField(280)]
	private readonly Hero _winnerSideHero;

	[SaveableField(281)]
	private readonly Hero _defeatedSideHero;

	[SaveableField(282)]
	private readonly Clan _defeatedSideClan;

	[SaveableField(283)]
	private readonly Clan _winnerSideClan;

	[SaveableField(284)]
	private readonly TextObject _defeatedSidePartyName;

	[SaveableField(285)]
	private readonly bool _defeatedSidePartyIsSettlement;

	[SaveableField(286)]
	private readonly bool _defeatedSidePartyIsBanditFaction;

	[SaveableField(287)]
	private readonly MBReadOnlyDictionary<Hero, short> _witnesses;

	[SaveableField(288)]
	private readonly bool _isAgainstGreatOdds;

	[SaveableField(289)]
	private readonly bool _isEasyPlayerVictory;

	[SaveableField(290)]
	private readonly bool _isPlayerLastStand;

	[SaveableField(291)]
	private readonly bool _isAgainstCaravan;

	[SaveableField(292)]
	private readonly bool _playerVictory;

	[SaveableField(293)]
	private readonly bool _playerWasAttacker;

	[SaveableField(294)]
	private readonly Settlement _capturedSettlement;

	public bool IsVisibleNotification
	{
		get
		{
			if (_defeatedSideHero != null)
			{
				return _winnerSideHero != null;
			}
			return false;
		}
	}

	internal static void AutoGeneratedStaticCollectObjectsPlayerBattleEndedLogEntry(object o, List<object> collectedObjects)
	{
		((PlayerBattleEndedLogEntry)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		base.AutoGeneratedInstanceCollectObjects(collectedObjects);
		collectedObjects.Add(_winnerSideHero);
		collectedObjects.Add(_defeatedSideHero);
		collectedObjects.Add(_defeatedSideClan);
		collectedObjects.Add(_winnerSideClan);
		collectedObjects.Add(_defeatedSidePartyName);
		collectedObjects.Add(_witnesses);
		collectedObjects.Add(_capturedSettlement);
	}

	internal static object AutoGeneratedGetMemberValue_winnerSideHero(object o)
	{
		return ((PlayerBattleEndedLogEntry)o)._winnerSideHero;
	}

	internal static object AutoGeneratedGetMemberValue_defeatedSideHero(object o)
	{
		return ((PlayerBattleEndedLogEntry)o)._defeatedSideHero;
	}

	internal static object AutoGeneratedGetMemberValue_defeatedSideClan(object o)
	{
		return ((PlayerBattleEndedLogEntry)o)._defeatedSideClan;
	}

	internal static object AutoGeneratedGetMemberValue_winnerSideClan(object o)
	{
		return ((PlayerBattleEndedLogEntry)o)._winnerSideClan;
	}

	internal static object AutoGeneratedGetMemberValue_defeatedSidePartyName(object o)
	{
		return ((PlayerBattleEndedLogEntry)o)._defeatedSidePartyName;
	}

	internal static object AutoGeneratedGetMemberValue_defeatedSidePartyIsSettlement(object o)
	{
		return ((PlayerBattleEndedLogEntry)o)._defeatedSidePartyIsSettlement;
	}

	internal static object AutoGeneratedGetMemberValue_defeatedSidePartyIsBanditFaction(object o)
	{
		return ((PlayerBattleEndedLogEntry)o)._defeatedSidePartyIsBanditFaction;
	}

	internal static object AutoGeneratedGetMemberValue_witnesses(object o)
	{
		return ((PlayerBattleEndedLogEntry)o)._witnesses;
	}

	internal static object AutoGeneratedGetMemberValue_isAgainstGreatOdds(object o)
	{
		return ((PlayerBattleEndedLogEntry)o)._isAgainstGreatOdds;
	}

	internal static object AutoGeneratedGetMemberValue_isEasyPlayerVictory(object o)
	{
		return ((PlayerBattleEndedLogEntry)o)._isEasyPlayerVictory;
	}

	internal static object AutoGeneratedGetMemberValue_isPlayerLastStand(object o)
	{
		return ((PlayerBattleEndedLogEntry)o)._isPlayerLastStand;
	}

	internal static object AutoGeneratedGetMemberValue_isAgainstCaravan(object o)
	{
		return ((PlayerBattleEndedLogEntry)o)._isAgainstCaravan;
	}

	internal static object AutoGeneratedGetMemberValue_playerVictory(object o)
	{
		return ((PlayerBattleEndedLogEntry)o)._playerVictory;
	}

	internal static object AutoGeneratedGetMemberValue_playerWasAttacker(object o)
	{
		return ((PlayerBattleEndedLogEntry)o)._playerWasAttacker;
	}

	internal static object AutoGeneratedGetMemberValue_capturedSettlement(object o)
	{
		return ((PlayerBattleEndedLogEntry)o)._capturedSettlement;
	}

	public PlayerBattleEndedLogEntry(MapEvent mapEvent)
	{
		PartyBase leaderParty = ((mapEvent.BattleState == BattleState.AttackerVictory) ? mapEvent.AttackerSide : mapEvent.DefenderSide).LeaderParty;
		PartyBase leaderParty2 = mapEvent.GetMapEventSide(mapEvent.DefeatedSide).LeaderParty;
		_winnerSideHero = leaderParty.LeaderHero;
		_defeatedSideHero = leaderParty2.LeaderHero;
		_defeatedSidePartyIsSettlement = leaderParty2.IsSettlement && (leaderParty2.Settlement.IsTown || leaderParty2.Settlement.IsCastle);
		if (_defeatedSidePartyIsSettlement)
		{
			_capturedSettlement = leaderParty2.Settlement;
		}
		_defeatedSidePartyIsBanditFaction = leaderParty2.MapFaction.IsBanditFaction;
		_defeatedSidePartyName = leaderParty2.Name;
		_winnerSideClan = GetClanOf(leaderParty);
		_defeatedSideClan = GetClanOf(leaderParty2);
		BattleSideEnum playerSide = PlayerEncounter.Current.PlayerSide;
		MapEventSide mapEventSide = mapEvent.GetMapEventSide(playerSide);
		MapEventSide mapEventSide2 = mapEvent.GetMapEventSide(playerSide.GetOppositeSide());
		float strengthRatio = mapEventSide.StrengthRatio;
		int casualties = mapEventSide.Casualties;
		int casualties2 = mapEventSide2.Casualties;
		_playerVictory = playerSide == mapEvent.WinningSide;
		_playerWasAttacker = playerSide == mapEvent.AttackerSide.MissionSide;
		_isAgainstGreatOdds = strengthRatio > 1.5f;
		_isEasyPlayerVictory = strengthRatio < 0.5f && casualties * 3 < casualties2 && playerSide == mapEvent.WinningSide;
		if (_defeatedSidePartyIsSettlement)
		{
			_isEasyPlayerVictory = strengthRatio < 0.25f && casualties * 3 < casualties2 && playerSide == mapEvent.WinningSide;
		}
		_isPlayerLastStand = playerSide == mapEvent.DefeatedSide && casualties2 > casualties;
		MobileParty mobileParty = mapEventSide2.Parties[0].Party.MobileParty;
		_isAgainstCaravan = playerSide == mapEvent.WinningSide && mobileParty != null && mobileParty.IsCaravan;
		Dictionary<Hero, short> dictionary = new Dictionary<Hero, short>();
		if (mapEvent != null)
		{
			foreach (PartyBase involvedParty in mapEvent.InvolvedParties)
			{
				foreach (TroopRosterElement item in involvedParty.MemberRoster.GetTroopRoster())
				{
					if (item.Character.HeroObject != null && !dictionary.ContainsKey(item.Character.HeroObject))
					{
						dictionary.Add(item.Character.HeroObject, (short)((involvedParty.Side == MobileParty.MainParty.Party.Side) ? 1 : (-1)));
					}
				}
			}
		}
		_witnesses = dictionary.GetReadOnlyDictionary();
	}

	private Clan GetClanOf(PartyBase party)
	{
		if (party.MobileParty?.ActualClan != null)
		{
			return party.MobileParty.ActualClan;
		}
		if (party.Owner != null)
		{
			if (!party.Owner.IsNotable)
			{
				return party.Owner.Clan;
			}
			return party.Owner.HomeSettlement.OwnerClan;
		}
		if (party.IsSettlement)
		{
			return party.Settlement.OwnerClan;
		}
		if (party.LeaderHero != null)
		{
			return party.LeaderHero.Clan;
		}
		return null;
	}

	public override ImportanceEnum GetImportanceForClan(Clan clan)
	{
		return ImportanceEnum.Zero;
	}

	public override void GetConversationScoreAndComment(Hero talkTroop, bool findString, out string comment, out ImportanceEnum score)
	{
		if (!_witnesses.TryGetValue(talkTroop, out var value))
		{
			value = -2;
		}
		score = ImportanceEnum.Zero;
		comment = "";
		bool flag = _winnerSideHero == Hero.MainHero;
		int num;
		if (_playerVictory)
		{
			if (_capturedSettlement != null)
			{
				if (Hero.MainHero.CurrentSettlement == _capturedSettlement && Hero.OneToOneConversationHero.IsNotable)
				{
					score = ImportanceEnum.QuiteImportant;
					comment = "str_comment_endplayerbattle_you_stormed_this_city";
				}
				else if (value == 1)
				{
					score = ImportanceEnum.SomewhatImportant;
					if (findString)
					{
						MBTextManager.SetTextVariable("ENEMY_SETTLEMENT", _defeatedSidePartyName);
						if (_isEasyPlayerVictory)
						{
							comment = "str_comment_endplayerbattle_we_stormed_castle_easy";
						}
						else
						{
							comment = "str_comment_endplayerbattle_we_stormed_castle";
						}
					}
				}
				else if (flag && _defeatedSideClan == talkTroop.Clan)
				{
					score = ImportanceEnum.SomewhatImportant;
					if (findString)
					{
						MBTextManager.SetTextVariable("SETTLEMENT_NAME", _defeatedSidePartyName);
						comment = "str_comment_endplayerbattle_you_captured_our_castle";
					}
				}
				else if (flag)
				{
					score = ImportanceEnum.SomewhatImportant;
					if (findString)
					{
						MBTextManager.SetTextVariable("SETTLEMENT_NAME", _defeatedSidePartyName);
						comment = "str_comment_endplayerbattle_you_stormed_castle";
					}
				}
				return;
			}
			if (_defeatedSideHero != null && _defeatedSideHero == talkTroop && flag)
			{
				score = ImportanceEnum.SomewhatImportant;
				if (findString)
				{
					comment = "str_comment_endplayerbattle_you_defeated_me";
				}
				return;
			}
			if (_defeatedSideHero != null && value == 1 && talkTroop.MapFaction == Hero.MainHero.MapFaction && _defeatedSideHero.MapFaction != Hero.MainHero.MapFaction)
			{
				score = ImportanceEnum.SomewhatImportant;
				if (findString)
				{
					MBTextManager.SetTextVariable("ENEMY_TERM", FactionHelper.GetTermUsedByOtherFaction(_defeatedSideHero.MapFaction, talkTroop.Clan, pejorative: false));
					MBTextManager.SetTextVariable("DEFEATED_PARTY_LEADER", _defeatedSideHero.Name);
					comment = "str_comment_endplayerbattle_we_defeated_enemy";
				}
				return;
			}
			if (_defeatedSidePartyIsBanditFaction)
			{
				if (value == 1 && _isEasyPlayerVictory)
				{
					score = ImportanceEnum.SomewhatImportant;
					if (findString)
					{
						comment = "str_comment_endplayerbattle_we_hunted_bandit_easy";
					}
				}
				else if (value == 1)
				{
					score = ImportanceEnum.SomewhatImportant;
					if (findString)
					{
						comment = "str_comment_endplayerbattle_we_hunted_bandit";
					}
				}
				else if (talkTroop.IsMerchant)
				{
					score = ImportanceEnum.SomewhatImportant;
					if (findString)
					{
						comment = "str_comment_endplayerbattle_you_hunted_bandit_merchant";
					}
				}
				return;
			}
			if (_isAgainstCaravan)
			{
				if (_defeatedSideClan != null && _defeatedSideClan.Leader == talkTroop)
				{
					score = ImportanceEnum.SomewhatImportant;
					if (findString)
					{
						comment = "str_comment_endplayerbattle_you_accosted_my_caravan";
					}
				}
				return;
			}
			if (_defeatedSideHero != null)
			{
				IFaction faction;
				if (_defeatedSideClan.Kingdom != null)
				{
					IFaction kingdom = _defeatedSideClan.Kingdom;
					faction = kingdom;
				}
				else
				{
					IFaction kingdom = _defeatedSideClan;
					faction = kingdom;
				}
				if (faction == talkTroop.MapFaction)
				{
					num = ((Hero.MainHero.MapFaction != talkTroop.MapFaction) ? 1 : 0);
					goto IL_0284;
				}
			}
			num = 0;
			goto IL_0284;
		}
		if (_playerVictory)
		{
			return;
		}
		if (_winnerSideHero == talkTroop && flag)
		{
			score = ImportanceEnum.SomewhatImportant;
			if (findString)
			{
				comment = "str_comment_endplayerbattle_i_defeated_you";
			}
		}
		else if (_winnerSideHero == talkTroop && value == -1)
		{
			score = ImportanceEnum.SomewhatImportant;
			if (findString)
			{
				comment = "str_comment_endplayerbattle_we_defeated_you";
			}
		}
		else
		{
			if (!(_winnerSideHero != null && flag))
			{
				return;
			}
			IFaction faction2;
			if (_winnerSideClan.Kingdom != null)
			{
				IFaction kingdom = _winnerSideClan.Kingdom;
				faction2 = kingdom;
			}
			else
			{
				IFaction kingdom = _winnerSideClan;
				faction2 = kingdom;
			}
			if (faction2 == talkTroop.MapFaction && talkTroop.MapFaction != Hero.MainHero.MapFaction && flag)
			{
				score = ImportanceEnum.SomewhatImportant;
				if (findString)
				{
					MBTextManager.SetTextVariable("VICTORIOUS_PARTY_LEADER", _winnerSideHero.Name);
					comment = "str_comment_endplayerbattle_my_ally_defeated_you";
				}
				return;
			}
			if (value == 1 && _winnerSideHero.MapFaction != Hero.MainHero.MapFaction && talkTroop.MapFaction == Hero.MainHero.MapFaction)
			{
				score = ImportanceEnum.SomewhatImportant;
				if (findString)
				{
					MBTextManager.SetTextVariable("VICTORIOUS_PARTY_LEADER", _winnerSideHero.Name);
					MBTextManager.SetTextVariable("ENEMY_TERM", FactionHelper.GetTermUsedByOtherFaction(_winnerSideHero.MapFaction, talkTroop.MapFaction, pejorative: false));
					comment = "str_comment_endplayerbattle_we_were_defeated";
				}
				return;
			}
			int num2;
			if (talkTroop.MapFaction == Hero.MainHero.MapFaction)
			{
				IFaction mapFaction = talkTroop.MapFaction;
				IFaction faction3;
				if (_winnerSideClan.Kingdom != null)
				{
					IFaction kingdom = _winnerSideClan.Kingdom;
					faction3 = kingdom;
				}
				else
				{
					IFaction kingdom = _winnerSideClan;
					faction3 = kingdom;
				}
				num2 = (FactionManager.IsAtWarAgainstFaction(mapFaction, faction3) ? 1 : 0);
			}
			else
			{
				num2 = 0;
			}
			if (((uint)num2 & (flag ? 1u : 0u)) == 0)
			{
				return;
			}
			if (_isPlayerLastStand)
			{
				score = ImportanceEnum.SomewhatImportant;
				if (findString)
				{
					MBTextManager.SetTextVariable("VICTORIOUS_PARTY_LEADER", _winnerSideHero.Name);
					MBTextManager.SetTextVariable("ENEMY_TERM", FactionHelper.GetTermUsedByOtherFaction(_winnerSideHero.MapFaction, talkTroop.MapFaction, pejorative: false));
					comment = "str_comment_endplayerbattle_our_enemy_defeated_you_pyrrhic";
				}
			}
			else
			{
				score = ImportanceEnum.SomewhatImportant;
				if (findString)
				{
					MBTextManager.SetTextVariable("VICTORIOUS_PARTY_LEADER", _winnerSideHero.Name);
					MBTextManager.SetTextVariable("ENEMY_TERM", FactionHelper.GetTermUsedByOtherFaction(_winnerSideHero.MapFaction, talkTroop.MapFaction, pejorative: false));
					comment = "str_comment_endplayerbattle_our_enemy_defeated_you";
				}
			}
		}
		return;
		IL_0284:
		if (((uint)num & (flag ? 1u : 0u)) != 0)
		{
			int num3 = -5;
			num3 -= talkTroop.CharacterObject.GetTraitLevel(DefaultTraits.Mercy) * 5;
			num3 -= talkTroop.CharacterObject.GetTraitLevel(DefaultTraits.Generosity) * 5;
			if (talkTroop.GetRelation(_defeatedSideHero) < num3)
			{
				score = ImportanceEnum.SomewhatImportant;
				if (findString)
				{
					string text = ConversationHelper.HeroRefersToHero(talkTroop, _defeatedSideHero, uppercaseFirst: true);
					MBTextManager.SetTextVariable("DEFEATED_LEADER_RELATIONSHIP", text);
					_defeatedSideHero.SetTextVariables();
					MBTextManager.SetTextVariable("DEFEATED_LEADER", _defeatedSideHero.Name);
					comment = "str_comment_endplayerbattle_you_defeated_my_ally_disrespectful";
				}
			}
			else
			{
				score = ImportanceEnum.SomewhatImportant;
				if (findString)
				{
					string text2 = ConversationHelper.HeroRefersToHero(talkTroop, _defeatedSideHero, uppercaseFirst: true);
					MBTextManager.SetTextVariable("DEFEATED_LEADER_RELATIONSHIP", text2);
					_defeatedSideHero.SetTextVariables();
					MBTextManager.SetTextVariable("DEFEATED_LEADER", _defeatedSideHero.Name);
					comment = "str_comment_endplayerbattle_you_defeated_my_ally";
				}
			}
			return;
		}
		int num4;
		if (_defeatedSideHero != null && talkTroop.MapFaction == Hero.MainHero.MapFaction)
		{
			IFaction faction4;
			if (_defeatedSideClan.Kingdom != null)
			{
				IFaction kingdom = _defeatedSideClan.Kingdom;
				faction4 = kingdom;
			}
			else
			{
				IFaction kingdom = _defeatedSideClan;
				faction4 = kingdom;
			}
			num4 = (FactionManager.IsAtWarAgainstFaction(faction4, talkTroop.MapFaction) ? 1 : 0);
		}
		else
		{
			num4 = 0;
		}
		if (((uint)num4 & (flag ? 1u : 0u)) == 0)
		{
			return;
		}
		if (_isAgainstGreatOdds)
		{
			score = ImportanceEnum.SomewhatImportant;
			if (findString)
			{
				MBTextManager.SetTextVariable("DEFEATED_PARTY_LEADER", _defeatedSideHero.Name);
				_defeatedSideHero.SetTextVariables();
				comment = "str_comment_endplayerbattle_you_defeated_our_enemy_great_battle";
			}
		}
		else
		{
			score = ImportanceEnum.SomewhatImportant;
			if (findString)
			{
				MBTextManager.SetTextVariable("DEFEATED_PARTY_LEADER", _defeatedSideHero.Name);
				_defeatedSideHero.SetTextVariables();
				comment = "str_comment_endplayerbattle_you_defeated_our_enemy";
			}
		}
	}

	public override string ToString()
	{
		return GetNotificationText().ToString();
	}

	public TextObject GetNotificationText()
	{
		TextObject textObject = TextObject.Empty;
		if (_winnerSideHero != null && _defeatedSideHero != null)
		{
			textObject = GameTexts.FindText("str_destroy_player_party");
			StringHelpers.SetCharacterProperties("HERO_1", _winnerSideHero.CharacterObject, textObject);
			StringHelpers.SetCharacterProperties("HERO_2", _defeatedSideHero.CharacterObject, textObject);
		}
		return textObject;
	}
}
