using System.Collections.Generic;
using StoryMode.GameComponents.CampaignBehaviors;
using TaleWorlds.ActivitySystem;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;
using TaleWorlds.SaveSystem;

namespace StoryMode.StoryModePhases;

public class ThirdPhase
{
	[SaveableField(1)]
	private readonly MBList<Kingdom> _oppositionKingdoms;

	[SaveableField(2)]
	private readonly MBList<Kingdom> _allyKingdoms;

	[SaveableProperty(3)]
	public bool IsCompleted { get; private set; }

	public MBReadOnlyList<Kingdom> OppositionKingdoms => _oppositionKingdoms;

	public MBReadOnlyList<Kingdom> AllyKingdoms => _allyKingdoms;

	internal static void AutoGeneratedStaticCollectObjectsThirdPhase(object o, List<object> collectedObjects)
	{
		((ThirdPhase)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected virtual void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		collectedObjects.Add(_oppositionKingdoms);
		collectedObjects.Add(_allyKingdoms);
	}

	internal static object AutoGeneratedGetMemberValueIsCompleted(object o)
	{
		return ((ThirdPhase)o).IsCompleted;
	}

	internal static object AutoGeneratedGetMemberValue_oppositionKingdoms(object o)
	{
		return ((ThirdPhase)o)._oppositionKingdoms;
	}

	internal static object AutoGeneratedGetMemberValue_allyKingdoms(object o)
	{
		return ((ThirdPhase)o)._allyKingdoms;
	}

	public ThirdPhase()
	{
		_oppositionKingdoms = new MBList<Kingdom>();
		_allyKingdoms = new MBList<Kingdom>();
		IsCompleted = false;
	}

	public void AddAllyKingdom(Kingdom kingdom)
	{
		_allyKingdoms.Add(kingdom);
	}

	public void AddOppositionKingdom(Kingdom kingdom)
	{
		_oppositionKingdoms.Add(kingdom);
	}

	public void RemoveOppositionKingdom(Kingdom kingdom)
	{
		_oppositionKingdoms.Remove(kingdom);
	}

	public void CompleteThirdPhase(QuestBase.QuestCompleteDetails defeatTheConspiracyQuestCompleteDetail)
	{
		IsCompleted = true;
		switch (defeatTheConspiracyQuestCompleteDetail)
		{
		case QuestBase.QuestCompleteDetails.Success:
			ActivityManager.EndActivity("CompleteMainQuest", ActivityOutcome.Completed);
			break;
		case QuestBase.QuestCompleteDetails.Invalid:
		case QuestBase.QuestCompleteDetails.Cancel:
		case QuestBase.QuestCompleteDetails.Timeout:
			ActivityManager.EndActivity("CompleteMainQuest", ActivityOutcome.Abandoned);
			break;
		case QuestBase.QuestCompleteDetails.Fail:
		case QuestBase.QuestCompleteDetails.FailWithBetrayal:
			ActivityManager.EndActivity("CompleteMainQuest", ActivityOutcome.Failed);
			break;
		}
		Campaign.Current.CampaignBehaviorManager.RemoveBehavior<ThirdPhaseCampaignBehavior>();
	}
}
