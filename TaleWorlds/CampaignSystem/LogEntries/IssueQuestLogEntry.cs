using System.Collections.Generic;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.LogEntries;

public class IssueQuestLogEntry : LogEntry
{
	[SaveableField(10)]
	public readonly Hero IssueGiver;

	[SaveableField(20)]
	public readonly Hero Antagonist;

	[SaveableField(30)]
	public QuestBase.QuestCompleteDetails Details;

	public override CampaignTime KeepInHistoryTime => CampaignTime.Weeks(1f);

	internal static void AutoGeneratedStaticCollectObjectsIssueQuestLogEntry(object o, List<object> collectedObjects)
	{
		((IssueQuestLogEntry)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		base.AutoGeneratedInstanceCollectObjects(collectedObjects);
		collectedObjects.Add(IssueGiver);
		collectedObjects.Add(Antagonist);
	}

	internal static object AutoGeneratedGetMemberValueIssueGiver(object o)
	{
		return ((IssueQuestLogEntry)o).IssueGiver;
	}

	internal static object AutoGeneratedGetMemberValueAntagonist(object o)
	{
		return ((IssueQuestLogEntry)o).Antagonist;
	}

	internal static object AutoGeneratedGetMemberValueDetails(object o)
	{
		return ((IssueQuestLogEntry)o).Details;
	}

	public IssueQuestLogEntry(Hero questGiver, Hero antagonist, QuestBase.QuestCompleteDetails status)
	{
		IssueGiver = questGiver;
		Antagonist = antagonist;
		Details = status;
	}

	public override void GetConversationScoreAndComment(Hero talkTroop, bool findString, out string comment, out ImportanceEnum score)
	{
		score = ImportanceEnum.Zero;
		comment = "";
		if (IssueGiver == talkTroop)
		{
			if (Details == QuestBase.QuestCompleteDetails.FailWithBetrayal)
			{
				score = ImportanceEnum.MatterOfLifeAndDeath;
				if (findString)
				{
					comment = "str_comment_quest_betrayed";
				}
			}
			else if (Details == QuestBase.QuestCompleteDetails.Success)
			{
				score = ImportanceEnum.VeryImportant;
				if (findString)
				{
					comment = "str_comment_quest_succeeded";
				}
			}
			else if (Details == QuestBase.QuestCompleteDetails.Fail || Details == QuestBase.QuestCompleteDetails.Timeout || Details == QuestBase.QuestCompleteDetails.Cancel)
			{
				score = ImportanceEnum.Important;
				if (findString)
				{
					comment = "str_comment_quest_failed";
				}
			}
			else if (Details == QuestBase.QuestCompleteDetails.Invalid)
			{
				score = ImportanceEnum.ReasonablyImportant;
				if (findString)
				{
					comment = "str_comment_quest_invalid";
				}
			}
		}
		else if (Antagonist == talkTroop && Details == QuestBase.QuestCompleteDetails.FailWithBetrayal)
		{
			score = ImportanceEnum.MatterOfLifeAndDeath;
			if (findString)
			{
				comment = "str_comment_quest_counteroffer_accepted";
			}
		}
	}
}