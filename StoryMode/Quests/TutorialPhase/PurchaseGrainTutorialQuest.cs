using System.Collections.Generic;
using StoryMode.Quests.QuestTasks;
using StoryMode.StoryModePhases;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace StoryMode.Quests.TutorialPhase;

public class PurchaseGrainTutorialQuest : StoryModeQuestBase
{
	public const int BuyGrainAmount = 2;

	[SaveableField(1)]
	private readonly PurchaseItemTutorialQuestTask _purchaseItemTutorialQuestTask;

	private TextObject _buyItemTaskStartLog
	{
		get
		{
			TextObject textObject = new TextObject("{=D9RoNGJg}Buy 2 {GRAIN}{.s}. Click \"Buy Products\" option on village menu to buy products.");
			textObject.SetTextVariable("GRAIN", DefaultItems.Grain.Name);
			return textObject;
		}
	}

	public override TextObject Title
	{
		get
		{
			TextObject textObject = new TextObject("{=JhEzD45J}Purchase {GRAIN}");
			textObject.SetTextVariable("GRAIN", DefaultItems.Grain.Name);
			return textObject;
		}
	}

	public PurchaseGrainTutorialQuest(Hero questGiver)
		: base("purchase_grain_tutorial_quest", questGiver, CampaignTime.Never)
	{
		StoryMode.StoryModePhases.TutorialPhase.Instance.InitializeTutorialVillageItemRoster();
		SetDialogs();
		TextObject textObject = new TextObject("{=TLRyyRaW}Purchased {GRAIN} Amount");
		textObject.SetTextVariable("GRAIN", DefaultItems.Grain.Name);
		_purchaseItemTutorialQuestTask = new PurchaseItemTutorialQuestTask(PurchaseItemTaskOnSuccess, 2, DefaultItems.Grain, AddDiscreteLog(_buyItemTaskStartLog, textObject, 0, 2));
		AddTask(_purchaseItemTutorialQuestTask);
	}

	protected override void SetDialogs()
	{
	}

	protected override void InitializeQuestOnGameLoad()
	{
		SetDialogs();
		_purchaseItemTutorialQuestTask.AddTaskBehaviorsOnGameLoad(PurchaseItemTaskOnSuccess);
		_purchaseItemTutorialQuestTask.InitializeTaskOnLoad(2, DefaultItems.Grain);
	}

	protected override void HourlyTick()
	{
	}

	private void PurchaseItemTaskOnSuccess()
	{
		CompleteQuestWithSuccess();
	}

	internal static void AutoGeneratedStaticCollectObjectsPurchaseGrainTutorialQuest(object o, List<object> collectedObjects)
	{
		((PurchaseGrainTutorialQuest)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		base.AutoGeneratedInstanceCollectObjects(collectedObjects);
		collectedObjects.Add(_purchaseItemTutorialQuestTask);
	}

	internal static object AutoGeneratedGetMemberValue_purchaseItemTutorialQuestTask(object o)
	{
		return ((PurchaseGrainTutorialQuest)o)._purchaseItemTutorialQuestTask;
	}
}
