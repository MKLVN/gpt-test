using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.Extensions;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class CharacterDevelopmentCampaignBehavior : CampaignBehaviorBase
{
	public override void RegisterEvents()
	{
		CampaignEvents.DailyTickHeroEvent.AddNonSerializedListener(this, DailyTickHero);
		CampaignEvents.OnNewGameCreatedPartialFollowUpEndEvent.AddNonSerializedListener(this, OnNewGameCreatedPartialFollowUpEnd);
	}

	private void OnNewGameCreatedPartialFollowUpEnd(CampaignGameStarter starter)
	{
		foreach (Hero allAliveHero in Hero.AllAliveHeroes)
		{
			InitializeHeroCharacterDeveloper(allAliveHero);
		}
		foreach (Hero deadOrDisabledHero in Hero.DeadOrDisabledHeroes)
		{
			InitializeHeroCharacterDeveloper(deadOrDisabledHero);
		}
	}

	private void InitializeHeroCharacterDeveloper(Hero hero)
	{
		hero.HeroDeveloper.CheckInitialLevel();
		if (!hero.IsChild && (hero.Clan != Clan.PlayerClan || (hero != Hero.MainHero && CampaignOptions.AutoAllocateClanMemberPerks)))
		{
			DevelopCharacterStats(hero);
		}
	}

	public override void SyncData(IDataStore dataStore)
	{
	}

	private void DailyTickHero(Hero hero)
	{
		if (!hero.IsChild && hero.IsAlive && (hero.Clan != Clan.PlayerClan || (hero != Hero.MainHero && CampaignOptions.AutoAllocateClanMemberPerks)))
		{
			if (hero.HeroDeveloper.UnspentFocusPoints > 0)
			{
				DistributeUnspentFocusPoints(hero);
			}
			if (hero.HeroDeveloper.GetOneAvailablePerkForEachPerkPair().Count > 0)
			{
				SelectPerks(hero);
			}
			if (hero.HeroDeveloper.UnspentAttributePoints > 0)
			{
				DistributeUnspentAttributePoints(hero);
			}
		}
	}

	public void DevelopCharacterStats(Hero hero)
	{
		DistributeUnspentAttributePoints(hero);
		DistributeUnspentFocusPoints(hero);
		SelectPerks(hero);
	}

	private void DistributeUnspentAttributePoints(Hero hero)
	{
		while (hero.HeroDeveloper.UnspentAttributePoints > 0)
		{
			CharacterAttribute characterAttribute = null;
			float num = float.MinValue;
			foreach (CharacterAttribute item in Attributes.All)
			{
				int attributeValue = hero.GetAttributeValue(item);
				if (attributeValue >= Campaign.Current.Models.CharacterDevelopmentModel.MaxAttribute)
				{
					continue;
				}
				float num2 = 0f;
				if (attributeValue == 0)
				{
					num2 = float.MaxValue;
				}
				else
				{
					foreach (SkillObject skill in item.Skills)
					{
						float num3 = MathF.Max(0f, (float)(75 + hero.GetSkillValue(skill)) - Campaign.Current.Models.CharacterDevelopmentModel.CalculateLearningLimit(attributeValue, hero.HeroDeveloper.GetFocus(skill), null).ResultNumber);
						num2 += num3;
					}
					int num4 = 1;
					foreach (CharacterAttribute item2 in Attributes.All)
					{
						if (item2 != item)
						{
							int attributeValue2 = hero.GetAttributeValue(item2);
							if (num4 < attributeValue2)
							{
								num4 = attributeValue2;
							}
						}
					}
					float num5 = MathF.Sqrt((float)num4 / (float)attributeValue);
					num2 *= num5;
				}
				if (num2 > num)
				{
					num = num2;
					characterAttribute = item;
				}
			}
			if (characterAttribute != null)
			{
				hero.HeroDeveloper.AddAttribute(characterAttribute, 1);
				continue;
			}
			break;
		}
	}

	private void DistributeUnspentFocusPoints(Hero hero)
	{
		while (hero.HeroDeveloper.UnspentFocusPoints > 0)
		{
			SkillObject skillObject = null;
			float num = float.MinValue;
			foreach (SkillObject item in Skills.All)
			{
				if (hero.HeroDeveloper.CanAddFocusToSkill(item))
				{
					int attributeValue = hero.GetAttributeValue(item.CharacterAttribute);
					int focus = hero.HeroDeveloper.GetFocus(item);
					float num2 = (float)hero.GetSkillValue(item) - Campaign.Current.Models.CharacterDevelopmentModel.CalculateLearningLimit(attributeValue, focus, null).ResultNumber;
					if (num2 > num)
					{
						num = num2;
						skillObject = item;
					}
				}
			}
			if (skillObject != null)
			{
				hero.HeroDeveloper.AddFocus(skillObject, 1);
				continue;
			}
			break;
		}
	}

	private void SelectPerks(Hero hero)
	{
		foreach (PerkObject item in hero.HeroDeveloper.GetOneAvailablePerkForEachPerkPair())
		{
			if (item.AlternativePerk != null)
			{
				if (MBRandom.RandomFloat < 0.5f)
				{
					hero.HeroDeveloper.AddPerk(item);
				}
				else
				{
					hero.HeroDeveloper.AddPerk(item.AlternativePerk);
				}
			}
			else
			{
				hero.HeroDeveloper.AddPerk(item);
			}
		}
	}
}
