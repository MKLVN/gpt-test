using System;
using System.Collections.Generic;
using System.Linq;
using Helpers;
using SandBox.GauntletUI;
using SandBox.Missions.MissionLogics;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.CraftingSystem;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.CampaignSystem.Inventory;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;
using TaleWorlds.ScreenSystem;

namespace StoryMode.GauntletUI.Tutorial;

public static class TutorialHelper
{
	public static bool PlayerIsInAnySettlement
	{
		get
		{
			Settlement currentSettlement = Settlement.CurrentSettlement;
			if (currentSettlement != null)
			{
				if (!currentSettlement.IsFortification)
				{
					return currentSettlement.IsVillage;
				}
				return true;
			}
			return false;
		}
	}

	public static bool PlayerIsInAnyVillage => Settlement.CurrentSettlement?.IsVillage ?? false;

	public static bool IsOrderingAvailable
	{
		get
		{
			if (Mission.Current?.PlayerTeam != null)
			{
				for (int i = 0; i < Mission.Current.PlayerTeam.FormationsIncludingEmpty.Count; i++)
				{
					Formation formation = Mission.Current.PlayerTeam.FormationsIncludingEmpty[i];
					if (formation.PlayerOwner == Agent.Main && formation.CountOfUnits > 0)
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	public static bool IsCharacterPopUpWindowOpen => GauntletTutorialSystem.Current.IsCharacterPortraitPopupOpen;

	public static EncyclopediaPages CurrentEncyclopediaPage => GauntletTutorialSystem.Current.CurrentEncyclopediaPageContext;

	public static TutorialContexts CurrentContext => GauntletTutorialSystem.Current.CurrentContext;

	public static bool PlayerIsInNonEnemyTown
	{
		get
		{
			Settlement currentSettlement = Settlement.CurrentSettlement;
			if (currentSettlement != null && currentSettlement.IsTown)
			{
				return !FactionManager.IsAtWarAgainstFaction(currentSettlement.MapFaction, MobileParty.MainParty.MapFaction);
			}
			return false;
		}
	}

	public static string ActiveVillageRaidGameMenuID => "raiding_village";

	public static bool IsActiveVillageRaidGameMenuOpen => Campaign.Current?.CurrentMenuContext?.GameMenu?.StringId == ActiveVillageRaidGameMenuID;

	public static bool TownMenuIsOpen
	{
		get
		{
			Settlement currentSettlement = Settlement.CurrentSettlement;
			if (currentSettlement != null && currentSettlement.IsTown)
			{
				return Campaign.Current.CurrentMenuContext?.GameMenu?.StringId == "town";
			}
			return false;
		}
	}

	public static bool VillageMenuIsOpen => Settlement.CurrentSettlement?.IsVillage ?? false;

	public static bool BackStreetMenuIsOpen
	{
		get
		{
			Settlement currentSettlement = Settlement.CurrentSettlement;
			if (currentSettlement != null && currentSettlement.IsTown && LocationComplex.Current != null)
			{
				Location locationWithId = LocationComplex.Current.GetLocationWithId("tavern");
				return GetMenuLocations.Contains(locationWithId);
			}
			return false;
		}
	}

	public static bool IsPlayerInABattleMission
	{
		get
		{
			Mission current = Mission.Current;
			if (current != null)
			{
				return current.Mode == MissionMode.Battle;
			}
			return false;
		}
	}

	public static bool IsOrderOfBattleOpenAndReady
	{
		get
		{
			Mission current = Mission.Current;
			if (current != null && current.Mode == MissionMode.Deployment)
			{
				return !LoadingWindow.IsLoadingWindowActive;
			}
			return false;
		}
	}

	public static bool CanPlayerAssignHimselfToFormation
	{
		get
		{
			if (!IsOrderOfBattleOpenAndReady)
			{
				return false;
			}
			return Mission.Current?.PlayerTeam.FormationsIncludingEmpty.Any((Formation x) => x.CountOfUnits > 0 && x.Captain == null) ?? false;
		}
	}

	public static bool IsPlayerInAFight
	{
		get
		{
			MissionMode? missionMode = Mission.Current?.Mode;
			if (missionMode.HasValue)
			{
				if (missionMode != MissionMode.Battle && missionMode != MissionMode.Duel)
				{
					return missionMode == MissionMode.Tournament;
				}
				return true;
			}
			return false;
		}
	}

	public static bool IsPlayerEncounterLeader
	{
		get
		{
			Mission current = Mission.Current;
			if (current == null)
			{
				return false;
			}
			return current.PlayerTeam?.IsPlayerGeneral == true;
		}
	}

	public static bool IsPlayerInAHideoutBattleMission => Mission.Current?.HasMissionBehavior<HideoutMissionController>() ?? false;

	public static IList<Location> GetMenuLocations => Campaign.Current.GameMenuManager.MenuLocations;

	public static bool PlayerIsSafeOnMap => !IsActiveVillageRaidGameMenuOpen;

	public static bool IsCurrentTownHaveDoableCraftingOrder
	{
		get
		{
			ICraftingCampaignBehavior campaignBehavior = Campaign.Current.GetCampaignBehavior<ICraftingCampaignBehavior>();
			CraftingCampaignBehavior.CraftingOrderSlots craftingOrderSlots = campaignBehavior?.CraftingOrders[Settlement.CurrentSettlement?.Town];
			List<CraftingOrder> list = craftingOrderSlots?.Slots.Where((CraftingOrder x) => x != null).ToList();
			MBList<TroopRosterElement> mBList = PartyBase.MainParty?.MemberRoster.GetTroopRoster();
			if (campaignBehavior == null || craftingOrderSlots == null || list == null || mBList == null)
			{
				return false;
			}
			for (int i = 0; i < mBList.Count; i++)
			{
				TroopRosterElement troopRosterElement = mBList[i];
				if (!troopRosterElement.Character.IsHero)
				{
					continue;
				}
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].IsOrderAvailableForHero(troopRosterElement.Character.HeroObject))
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	public static bool CurrentInventoryScreenIncludesBannerItem
	{
		get
		{
			if (Game.Current.GameStateManager.ActiveState is InventoryState inventoryState)
			{
				IEnumerable<ItemRosterElement> enumerable = inventoryState.InventoryLogic?.GetElementsInRoster(InventoryLogic.InventorySide.OtherInventory);
				if (enumerable != null)
				{
					foreach (ItemRosterElement item in enumerable)
					{
						if (item.EquipmentElement.Item.IsBannerItem)
						{
							return true;
						}
					}
				}
			}
			return false;
		}
	}

	public static bool PlayerHasUnassignedRolesAndMember
	{
		get
		{
			bool flag = false;
			MBList<TroopRosterElement> mBList = PartyBase.MainParty?.MemberRoster.GetTroopRoster();
			for (int i = 0; i < mBList.Count; i++)
			{
				TroopRosterElement troopRosterElement = mBList[i];
				if (troopRosterElement.Character.IsHero && !troopRosterElement.Character.IsPlayerCharacter && MobileParty.MainParty.GetHeroPerkRole(troopRosterElement.Character.HeroObject) == SkillEffect.PerkRole.None)
				{
					flag = true;
					break;
				}
			}
			bool flag2 = MobileParty.MainParty.GetRoleHolder(SkillEffect.PerkRole.Surgeon) == null || MobileParty.MainParty.GetRoleHolder(SkillEffect.PerkRole.Engineer) == null || MobileParty.MainParty.GetRoleHolder(SkillEffect.PerkRole.Quartermaster) == null || MobileParty.MainParty.GetRoleHolder(SkillEffect.PerkRole.Scout) == null;
			return flag && flag2;
		}
	}

	public static bool PlayerCanRecruit
	{
		get
		{
			if (PlayerIsInAnySettlement && (TownMenuIsOpen || VillageMenuIsOpen) && !Hero.MainHero.IsPrisoner && MobileParty.MainParty.MemberRoster.TotalManCount < PartyBase.MainParty.PartySizeLimit)
			{
				foreach (Hero notable in Settlement.CurrentSettlement.Notables)
				{
					int num = 0;
					foreach (CharacterObject item in HeroHelper.GetVolunteerTroopsOfHeroForRecruitment(notable))
					{
						if (item != null && HeroHelper.HeroCanRecruitFromHero(notable, Hero.MainHero, num))
						{
							int troopRecruitmentCost = Campaign.Current.Models.PartyWageModel.GetTroopRecruitmentCost(item, Hero.MainHero);
							return Hero.MainHero.Gold >= 5 * troopRecruitmentCost;
						}
						num++;
					}
				}
			}
			return false;
		}
	}

	public static bool IsKingdomDecisionPanelActiveAndHasOptions
	{
		get
		{
			ScreenBase topScreen = ScreenManager.TopScreen;
			GauntletKingdomScreen val = (GauntletKingdomScreen)(object)((topScreen is GauntletKingdomScreen) ? topScreen : null);
			if (val != null && val.DataSource?.Decision?.IsCurrentDecisionActive == true)
			{
				return val.DataSource.Decision.CurrentDecision.DecisionOptionsList.Count > 0;
			}
			return false;
		}
	}

	public static Location CurrentMissionLocation => CampaignMission.Current?.Location;

	public static bool BuyingFoodBaseConditions
	{
		get
		{
			if ((TownMenuIsOpen || VillageMenuIsOpen || CurrentContext == TutorialContexts.InventoryScreen) && Settlement.CurrentSettlement != null)
			{
				ItemObject @object = MBObjectManager.Instance.GetObject<ItemObject>("grain");
				if (@object != null)
				{
					ItemRoster itemRoster = Settlement.CurrentSettlement.ItemRoster;
					int num = itemRoster.FindIndexOfItem(@object);
					if (num >= 0)
					{
						int elementUnitCost = itemRoster.GetElementUnitCost(num);
						return Hero.MainHero.Gold >= 5 * elementUnitCost;
					}
				}
			}
			return false;
		}
	}

	public static int BuyGrainAmount => 2;

	public static int RecruitTroopAmount => 4;

	public static bool PlayerHasAnyUpgradeableTroop
	{
		get
		{
			foreach (TroopRosterElement item in MobileParty.MainParty.MemberRoster.GetTroopRoster())
			{
				CharacterObject character = item.Character;
				if (character.IsHero || item.Number <= 0)
				{
					continue;
				}
				for (int i = 0; i < character.UpgradeTargets.Length; i++)
				{
					if (character.GetUpgradeXpCost(PartyBase.MainParty, i) > item.Xp)
					{
						continue;
					}
					CharacterObject characterObject = character.UpgradeTargets[i];
					if (characterObject.UpgradeRequiresItemFromCategory == null)
					{
						return true;
					}
					foreach (ItemRosterElement item2 in MobileParty.MainParty.ItemRoster)
					{
						if (item2.EquipmentElement.Item.ItemCategory == characterObject.UpgradeRequiresItemFromCategory && item2.Amount > 0)
						{
							return true;
						}
					}
				}
			}
			return false;
		}
	}

	public static bool PlayerIsInAConversation => !CharacterObject.ConversationCharacters.IsEmpty();

	public static DateTime CurrentTime => DateTime.Now;

	public static int MinimumGoldForCompanion => 999;

	public static float MaximumSpeedForPartyForSpeedTutorial => 4f;

	public static float MaxCohesionForCohesionTutorial => 30f;

	public static bool? IsThereAvailableCompanionInLocation(Location location)
	{
		return location?.GetCharacterList().Any((LocationCharacter x) => x.Character.IsHero && x.Character.HeroObject.IsWanderer && !x.Character.HeroObject.IsPlayerCompanion);
	}
}
