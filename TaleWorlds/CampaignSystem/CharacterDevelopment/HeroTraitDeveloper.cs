using System.Collections.Generic;
using TaleWorlds.Core;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.CharacterDevelopment;

public class HeroTraitDeveloper : PropertyOwner<PropertyObject>
{
	[SaveableProperty(0)]
	internal Hero Hero { get; private set; }

	internal static void AutoGeneratedStaticCollectObjectsHeroTraitDeveloper(object o, List<object> collectedObjects)
	{
		((HeroTraitDeveloper)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		base.AutoGeneratedInstanceCollectObjects(collectedObjects);
		collectedObjects.Add(Hero);
	}

	internal static object AutoGeneratedGetMemberValueHero(object o)
	{
		return ((HeroTraitDeveloper)o).Hero;
	}

	internal HeroTraitDeveloper(Hero hero)
	{
		Hero = hero;
		UpdateTraitXPAccordingToTraitLevels();
	}

	public void AddTraitXp(TraitObject trait, int xpAmount)
	{
		xpAmount += GetPropertyValue(trait);
		Campaign.Current.Models.CharacterDevelopmentModel.GetTraitLevelForTraitXp(Hero, trait, xpAmount, out var traitLevel, out var traitXp);
		SetPropertyValue(trait, traitXp);
		if (traitLevel != Hero.GetTraitLevel(trait))
		{
			Hero.SetTraitLevel(trait, traitLevel);
		}
	}

	public void UpdateTraitXPAccordingToTraitLevels()
	{
		foreach (TraitObject item in TraitObject.All)
		{
			int traitLevel = Hero.GetTraitLevel(item);
			if (traitLevel != 0)
			{
				int traitXpRequiredForTraitLevel = Campaign.Current.Models.CharacterDevelopmentModel.GetTraitXpRequiredForTraitLevel(item, traitLevel);
				SetPropertyValue(item, traitXpRequiredForTraitLevel);
			}
		}
	}
}
