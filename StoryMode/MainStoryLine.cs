using System.Collections.Generic;
using StoryMode.GameComponents.CampaignBehaviors;
using StoryMode.StoryModeObjects;
using StoryMode.StoryModePhases;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.SaveSystem;
using TaleWorlds.SaveSystem.Load;

namespace StoryMode;

public class MainStoryLine
{
	public const int MainStoryLineDialogOptionPriority = 150;

	public const string DragonBannerItemStringId = "dragon_banner";

	public const string DragonBannerPart1ItemStringId = "dragon_banner_center";

	public const string DragonBannerPart2ItemStringId = "dragon_banner_dragonhead";

	public const string DragonBannerPart3ItemStringId = "dragon_banner_handle";

	[SaveableField(1)]
	public MainStoryLineSide MainStoryLineSide;

	[SaveableField(6)]
	public Settlement ImperialMentorSettlement;

	[SaveableField(7)]
	public Settlement AntiImperialMentorSettlement;

	[SaveableField(9)]
	private Dictionary<string, float> _tutorialScores;

	[SaveableField(10)]
	public bool FamilyRescued;

	public List<Hideout> BusyHideouts;

	public bool IsPlayerInteractionRestricted
	{
		get
		{
			if (!TutorialPhase.IsCompleted)
			{
				if (!IsOnImperialQuestLine)
				{
					return !IsOnAntiImperialQuestLine;
				}
				return false;
			}
			return false;
		}
	}

	public bool IsOnImperialQuestLine
	{
		get
		{
			if (MainStoryLineSide != MainStoryLineSide.CreateImperialKingdom)
			{
				return MainStoryLineSide == MainStoryLineSide.SupportImperialKingdom;
			}
			return true;
		}
	}

	public bool IsOnAntiImperialQuestLine
	{
		get
		{
			if (MainStoryLineSide != MainStoryLineSide.CreateAntiImperialKingdom)
			{
				return MainStoryLineSide == MainStoryLineSide.SupportAntiImperialKingdom;
			}
			return true;
		}
	}

	[SaveableProperty(2)]
	public TutorialPhase TutorialPhase { get; private set; }

	[SaveableProperty(3)]
	public FirstPhase FirstPhase { get; private set; }

	[SaveableProperty(4)]
	public SecondPhase SecondPhase { get; private set; }

	[SaveableProperty(5)]
	public ThirdPhase ThirdPhase { get; private set; }

	[SaveableProperty(8)]
	public Kingdom PlayerSupportedKingdom { get; private set; }

	public bool IsCompleted
	{
		get
		{
			if (StoryModeManager.Current.MainStoryLine.ThirdPhase != null)
			{
				return StoryModeManager.Current.MainStoryLine.ThirdPhase.IsCompleted;
			}
			return false;
		}
	}

	public ItemObject DragonBanner { get; private set; }

	public bool IsFirstPhaseCompleted => SecondPhase != null;

	public bool IsSecondPhaseCompleted => ThirdPhase != null;

	public MainStoryLine()
	{
		MainStoryLineSide = MainStoryLineSide.None;
		TutorialPhase = new TutorialPhase();
		_tutorialScores = new Dictionary<string, float>();
		FamilyRescued = false;
		BusyHideouts = new List<Hideout>();
	}

	[LoadInitializationCallback]
	private void OnLoad(MetaData metaData, ObjectLoadData objectLoadData)
	{
		BusyHideouts = new List<Hideout>();
	}

	public void OnSessionLaunched()
	{
		DragonBanner = Campaign.Current.ObjectManager.GetObject<ItemObject>("dragon_banner");
	}

	public void SetTutorialScores(Dictionary<string, float> scores)
	{
		_tutorialScores = new Dictionary<string, float>(scores);
	}

	public Dictionary<string, float> GetTutorialScores()
	{
		return new Dictionary<string, float>(_tutorialScores);
	}

	public void SetStoryLineSide(MainStoryLineSide side)
	{
		MainStoryLineSide = side;
		PlayerSupportedKingdom = Clan.PlayerClan.Kingdom;
		StoryModeEvents.Instance.OnMainStoryLineSideChosen(MainStoryLineSide);
		DisableHeroAction.Apply(StoryModeHeroes.ImperialMentor);
		DisableHeroAction.Apply(StoryModeHeroes.AntiImperialMentor);
	}

	public void SetMentorSettlements(Settlement imperialMentorSettlement, Settlement antiImperialMentorSettlement)
	{
		ImperialMentorSettlement = imperialMentorSettlement;
		AntiImperialMentorSettlement = antiImperialMentorSettlement;
	}

	public void CompleteTutorialPhase(bool isSkipped)
	{
		TutorialPhase.CompleteTutorial(isSkipped);
		FirstPhase = new FirstPhase();
		StoryModeEvents.Instance.OnStoryModeTutorialEnded();
		StoryModeManager.Current.MainStoryLine.FirstPhase.CollectBannerPiece();
		Campaign.Current.CampaignBehaviorManager.RemoveBehavior<TutorialPhaseCampaignBehavior>();
	}

	public void CompleteFirstPhase()
	{
		SecondPhase = new SecondPhase();
		Campaign.Current.CampaignBehaviorManager.RemoveBehavior<FirstPhaseCampaignBehavior>();
	}

	public void CompleteSecondPhase()
	{
		ThirdPhase = new ThirdPhase();
		StoryModeEvents.Instance.OnConspiracyActivated();
		Campaign.Current.CampaignBehaviorManager.RemoveBehavior<SecondPhaseCampaignBehavior>();
	}

	public void CancelSecondAndThirdPhase()
	{
		if (SecondPhase != null)
		{
			Campaign.Current.CampaignBehaviorManager.RemoveBehavior<SecondPhaseCampaignBehavior>();
		}
		Campaign.Current.CampaignBehaviorManager.RemoveBehavior<ThirdPhaseCampaignBehavior>();
	}

	internal static void AutoGeneratedStaticCollectObjectsMainStoryLine(object o, List<object> collectedObjects)
	{
		((MainStoryLine)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected virtual void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		collectedObjects.Add(ImperialMentorSettlement);
		collectedObjects.Add(AntiImperialMentorSettlement);
		collectedObjects.Add(_tutorialScores);
		collectedObjects.Add(TutorialPhase);
		collectedObjects.Add(FirstPhase);
		collectedObjects.Add(SecondPhase);
		collectedObjects.Add(ThirdPhase);
		collectedObjects.Add(PlayerSupportedKingdom);
	}

	internal static object AutoGeneratedGetMemberValueTutorialPhase(object o)
	{
		return ((MainStoryLine)o).TutorialPhase;
	}

	internal static object AutoGeneratedGetMemberValueFirstPhase(object o)
	{
		return ((MainStoryLine)o).FirstPhase;
	}

	internal static object AutoGeneratedGetMemberValueSecondPhase(object o)
	{
		return ((MainStoryLine)o).SecondPhase;
	}

	internal static object AutoGeneratedGetMemberValueThirdPhase(object o)
	{
		return ((MainStoryLine)o).ThirdPhase;
	}

	internal static object AutoGeneratedGetMemberValuePlayerSupportedKingdom(object o)
	{
		return ((MainStoryLine)o).PlayerSupportedKingdom;
	}

	internal static object AutoGeneratedGetMemberValueMainStoryLineSide(object o)
	{
		return ((MainStoryLine)o).MainStoryLineSide;
	}

	internal static object AutoGeneratedGetMemberValueImperialMentorSettlement(object o)
	{
		return ((MainStoryLine)o).ImperialMentorSettlement;
	}

	internal static object AutoGeneratedGetMemberValueAntiImperialMentorSettlement(object o)
	{
		return ((MainStoryLine)o).AntiImperialMentorSettlement;
	}

	internal static object AutoGeneratedGetMemberValueFamilyRescued(object o)
	{
		return ((MainStoryLine)o).FamilyRescued;
	}

	internal static object AutoGeneratedGetMemberValue_tutorialScores(object o)
	{
		return ((MainStoryLine)o)._tutorialScores;
	}
}
