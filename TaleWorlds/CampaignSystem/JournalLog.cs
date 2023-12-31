using System.Collections.Generic;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem;

public class JournalLog
{
	[SaveableField(0)]
	public readonly CampaignTime LogTime;

	[SaveableField(1)]
	public readonly TextObject LogText;

	[SaveableField(2)]
	public readonly TextObject TaskName;

	[SaveableField(4)]
	public readonly int Range;

	[SaveableField(5)]
	public readonly LogType Type;

	[SaveableProperty(3)]
	public int CurrentProgress { get; private set; }

	internal static void AutoGeneratedStaticCollectObjectsJournalLog(object o, List<object> collectedObjects)
	{
		((JournalLog)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected virtual void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		CampaignTime.AutoGeneratedStaticCollectObjectsCampaignTime(LogTime, collectedObjects);
		collectedObjects.Add(LogText);
		collectedObjects.Add(TaskName);
	}

	internal static object AutoGeneratedGetMemberValueCurrentProgress(object o)
	{
		return ((JournalLog)o).CurrentProgress;
	}

	internal static object AutoGeneratedGetMemberValueLogTime(object o)
	{
		return ((JournalLog)o).LogTime;
	}

	internal static object AutoGeneratedGetMemberValueLogText(object o)
	{
		return ((JournalLog)o).LogText;
	}

	internal static object AutoGeneratedGetMemberValueTaskName(object o)
	{
		return ((JournalLog)o).TaskName;
	}

	internal static object AutoGeneratedGetMemberValueRange(object o)
	{
		return ((JournalLog)o).Range;
	}

	internal static object AutoGeneratedGetMemberValueType(object o)
	{
		return ((JournalLog)o).Type;
	}

	public JournalLog(CampaignTime logTime, TextObject logText, TextObject taskName = null, int currentProgress = 0, int range = 0, LogType type = LogType.Text)
	{
		LogTime = logTime;
		LogText = logText;
		TaskName = taskName;
		CurrentProgress = currentProgress;
		Range = range;
		Type = type;
	}

	public void UpdateCurrentProgress(int progress)
	{
		CurrentProgress = progress;
	}

	public bool HasBeenCompleted()
	{
		return CurrentProgress >= Range;
	}

	public TextObject GetTimeText()
	{
		int num = MathF.Ceiling(CampaignTime.Now.ToDays) - MathF.Ceiling(LogTime.ToDays);
		TextObject textObject;
		switch (num)
		{
		case 0:
			textObject = GameTexts.FindText("str_today");
			break;
		case 1:
			textObject = GameTexts.FindText("str_yesterday");
			break;
		default:
			textObject = GameTexts.FindText("str_DAY_days_ago");
			textObject.SetTextVariable("DAY", num);
			break;
		}
		return textObject;
	}
}
