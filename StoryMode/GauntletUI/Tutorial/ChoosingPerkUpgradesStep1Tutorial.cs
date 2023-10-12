using StoryMode.ViewModelCollection.Tutorial;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace StoryMode.GauntletUI.Tutorial;

public class ChoosingPerkUpgradesStep1Tutorial : TutorialItemBase
{
	private bool _contextChangedToCharacterScreen;

	public ChoosingPerkUpgradesStep1Tutorial()
	{
		base.Type = "ChoosingPerkUpgradesStep1";
		base.Placement = TutorialItemVM.ItemPlacements.Right;
		base.HighlightedVisualElementID = "CharacterButton";
		base.MouseRequired = true;
	}

	public override bool IsConditionsMetForCompletion()
	{
		return _contextChangedToCharacterScreen;
	}

	public override TutorialContexts GetTutorialsRelevantContext()
	{
		return TutorialContexts.MapWindow;
	}

	public override bool IsConditionsMetForActivation()
	{
		if ((TutorialHelper.PlayerIsInAnySettlement || TutorialHelper.PlayerIsSafeOnMap) && Hero.MainHero.HeroDeveloper.GetOneAvailablePerkForEachPerkPair().Count > 1)
		{
			return TutorialHelper.CurrentContext == TutorialContexts.MapWindow;
		}
		return false;
	}

	public override void OnTutorialContextChanged(TutorialContextChangedEvent obj)
	{
		_contextChangedToCharacterScreen = obj.NewContext == TutorialContexts.CharacterScreen;
	}
}
