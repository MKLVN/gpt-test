using System.Collections.Generic;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem;

public class PlayerCaptivity
{
	[SaveableField(0)]
	private CampaignTime _captivityStartTime;

	[SaveableField(1)]
	private PartyBase _captorParty;

	[SaveableField(2)]
	public int CountOfOffers;

	[SaveableField(3)]
	public int CurrentRansomAmount;

	private ICaptivityCampaignBehavior _captivityCampaignBehavior;

	[SaveableField(4)]
	private float _randomNumber;

	[SaveableField(5)]
	private CampaignTime _lastCheckTime;

	public static PartyBase CaptorParty
	{
		get
		{
			return Campaign.Current.PlayerCaptivity._captorParty;
		}
		set
		{
			if (value != null)
			{
				Campaign.Current.PlayerCaptivity._captorParty.PrisonRoster.RemoveTroop(Hero.MainHero.CharacterObject);
			}
			Campaign.Current.PlayerCaptivity._captorParty = value;
			if (value != null)
			{
				Campaign.Current.PlayerCaptivity._captorParty.AddPrisoner(Hero.MainHero.CharacterObject, 1);
				if ((Game.Current.GameStateManager.ActiveState as MapState).AtMenu)
				{
					GameMenu.SwitchToMenu(CaptorParty.IsSettlement ? "settlement_wait" : "prisoner_wait");
				}
				else
				{
					GameMenu.ActivateGameMenu(CaptorParty.IsSettlement ? "settlement_wait" : "prisoner_wait");
				}
			}
		}
	}

	private ICaptivityCampaignBehavior CaptivityCampaignBehavior
	{
		get
		{
			if (_captivityCampaignBehavior == null)
			{
				_captivityCampaignBehavior = Campaign.Current.GetCampaignBehavior<ICaptivityCampaignBehavior>();
			}
			return _captivityCampaignBehavior;
		}
	}

	public static float RandomNumber
	{
		get
		{
			return Campaign.Current.PlayerCaptivity._randomNumber;
		}
		set
		{
			Campaign.Current.PlayerCaptivity._randomNumber = value;
		}
	}

	public static bool IsCaptive => Campaign.Current.PlayerCaptivity._captorParty != null;

	public static int CaptiveTimeInDays => (int)(CampaignTime.Now - CaptivityStartTime).ToDays;

	public static CampaignTime CaptivityStartTime => Campaign.Current.PlayerCaptivity._captivityStartTime;

	public static CampaignTime LastCheckTime
	{
		get
		{
			return Campaign.Current.PlayerCaptivity._lastCheckTime;
		}
		set
		{
			Campaign.Current.PlayerCaptivity._lastCheckTime = value;
		}
	}

	internal static void AutoGeneratedStaticCollectObjectsPlayerCaptivity(object o, List<object> collectedObjects)
	{
		((PlayerCaptivity)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected virtual void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		CampaignTime.AutoGeneratedStaticCollectObjectsCampaignTime(_captivityStartTime, collectedObjects);
		collectedObjects.Add(_captorParty);
		CampaignTime.AutoGeneratedStaticCollectObjectsCampaignTime(_lastCheckTime, collectedObjects);
	}

	internal static object AutoGeneratedGetMemberValueCountOfOffers(object o)
	{
		return ((PlayerCaptivity)o).CountOfOffers;
	}

	internal static object AutoGeneratedGetMemberValueCurrentRansomAmount(object o)
	{
		return ((PlayerCaptivity)o).CurrentRansomAmount;
	}

	internal static object AutoGeneratedGetMemberValue_captivityStartTime(object o)
	{
		return ((PlayerCaptivity)o)._captivityStartTime;
	}

	internal static object AutoGeneratedGetMemberValue_captorParty(object o)
	{
		return ((PlayerCaptivity)o)._captorParty;
	}

	internal static object AutoGeneratedGetMemberValue_randomNumber(object o)
	{
		return ((PlayerCaptivity)o)._randomNumber;
	}

	internal static object AutoGeneratedGetMemberValue_lastCheckTime(object o)
	{
		return ((PlayerCaptivity)o)._lastCheckTime;
	}

	public static void StartCaptivity(PartyBase captorParty)
	{
		Campaign.Current.PlayerCaptivity.StartCaptivityInternal(captorParty);
		RandomNumber = MBRandom.RandomFloat;
	}

	public static void OnPlayerCharacterChanged()
	{
		if (Hero.MainHero.IsPrisoner)
		{
			Campaign.Current.PlayerCaptivity.StartCaptivityInternal(Hero.MainHero.PartyBelongedToAsPrisoner);
			RandomNumber = MBRandom.RandomFloat;
			CaptorParty = Hero.MainHero.PartyBelongedToAsPrisoner;
		}
	}

	public void SetRansomAmount()
	{
		CurrentRansomAmount = GetPlayerRansomValue();
	}

	private int GetPlayerRansomValue()
	{
		return (int)((MBRandom.RandomFloat * 0.5f + 0.5f) * ((float)Hero.MainHero.Gold * 0.05f + 300f) * (float)((!Hero.MainHero.PartyBelongedToAsPrisoner.IsSettlement) ? 1 : (Hero.MainHero.PartyBelongedToAsPrisoner.Settlement.MapFaction.IsKingdomFaction ? 4 : 2)) * (float)((!Hero.MainHero.PartyBelongedToAsPrisoner.IsMobile || !Hero.MainHero.PartyBelongedToAsPrisoner.MobileParty.IsLordParty) ? 1 : 2) * (Hero.MainHero.GetPerkValue(DefaultPerks.Trade.ManOfMeans) ? (1f + DefaultPerks.Trade.ManOfMeans.SecondaryBonus) : 1f));
	}

	private void StartCaptivityInternal(PartyBase captorParty)
	{
		_captivityStartTime = CampaignTime.Now;
		_lastCheckTime = CampaignTime.Now;
		if (PlayerEncounter.Current != null)
		{
			PlayerEncounter.LeaveEncounter = true;
		}
		if (MobileParty.MainParty.CurrentSettlement != null)
		{
			LeaveSettlementAction.ApplyForParty(MobileParty.MainParty);
		}
		MobileParty.MainParty.IsActive = false;
		PartyBase.MainParty.UpdateVisibilityAndInspected();
		_captorParty = captorParty;
		_captorParty.SetAsCameraFollowParty();
		_captorParty.UpdateVisibilityAndInspected();
		if (MobileParty.MainParty.Army != null)
		{
			if (MobileParty.MainParty.Army.LeaderParty == MobileParty.MainParty)
			{
				DisbandArmyAction.ApplyByPlayerTakenPrisoner(MobileParty.MainParty.Army);
			}
			MobileParty.MainParty.Army = null;
		}
	}

	private void EndCaptivityInternal()
	{
		if (Hero.MainHero.IsAlive)
		{
			PartyBase.MainParty.AddElementToMemberRoster(CharacterObject.PlayerCharacter, 1, insertAtFront: true);
			MobileParty.MainParty.ChangePartyLeader(Hero.MainHero);
		}
		if (Hero.MainHero.CurrentSettlement != null)
		{
			if (PlayerEncounter.Current != null)
			{
				PlayerEncounter.LeaveSettlement();
			}
			else if (Hero.MainHero.IsAlive)
			{
				LeaveSettlementAction.ApplyForParty(MobileParty.MainParty);
			}
			else
			{
				LeaveSettlementAction.ApplyForCharacterOnly(Hero.MainHero);
			}
		}
		if (PlayerEncounter.Current != null)
		{
			PlayerEncounter.Finish();
		}
		else if (Campaign.Current.CurrentMenuContext != null)
		{
			GameMenu.ExitToLast();
		}
		if (_captorParty.IsActive)
		{
			_captorParty.PrisonRoster.RemoveTroop(Hero.MainHero.CharacterObject);
		}
		if (Hero.MainHero.IsAlive)
		{
			Hero.MainHero.ChangeState(Hero.CharacterStates.Active);
		}
		if (Hero.MainHero.IsAlive)
		{
			MobileParty.MainParty.IsActive = true;
			PartyBase.MainParty.SetAsCameraFollowParty();
			MobileParty.MainParty.Ai.SetMoveModeHold();
			SkillLevelingManager.OnMainHeroReleasedFromCaptivity(CaptivityStartTime.ElapsedHoursUntilNow);
			PartyBase.MainParty.UpdateVisibilityAndInspected();
		}
		CampaignEventDispatcher.Instance.OnHeroPrisonerReleased(Hero.MainHero, _captorParty, _captorParty.MapFaction, EndCaptivityDetail.ReleasedAfterEscape);
		_captorParty = null;
		CountOfOffers = 0;
		CurrentRansomAmount = 0;
	}

	public static void EndCaptivity()
	{
		if (Hero.MainHero.IsAlive)
		{
			if (Hero.MainHero.IsWounded)
			{
				Hero.MainHero.HitPoints = 20;
			}
			if (Hero.MainHero.PartyBelongedToAsPrisoner != null && Hero.MainHero.PartyBelongedToAsPrisoner.IsMobile)
			{
				Hero.MainHero.PartyBelongedToAsPrisoner.MobileParty.Ai.SetDoNotAttackMainParty(12);
			}
			PlayerEncounter.ProtectPlayerSide(4f);
		}
		Campaign.Current.PlayerCaptivity.EndCaptivityInternal();
	}

	internal void Update(float dt)
	{
		MapState mapState = Game.Current.GameStateManager.ActiveState as MapState;
		if (IsCaptive && (dt > 0f || (mapState != null && !mapState.AtMenu)))
		{
			if (_captorParty.IsMobile && _captorParty.MobileParty.IsActive)
			{
				PartyBase.MainParty.MobileParty.Position2D = _captorParty.MobileParty.Position2D;
			}
			else if (_captorParty.IsSettlement)
			{
				PartyBase.MainParty.MobileParty.Position2D = _captorParty.Settlement.GatePosition;
			}
			if (mapState != null && !mapState.AtMenu)
			{
				GameMenu.ActivateGameMenu(CaptorParty.IsSettlement ? "settlement_wait" : "prisoner_wait");
			}
			if (IsCaptive)
			{
				CaptivityCampaignBehavior?.CheckCaptivityChange(dt);
			}
		}
	}
}
