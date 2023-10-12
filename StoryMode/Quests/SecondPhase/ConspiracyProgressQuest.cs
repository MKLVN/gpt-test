using System.Collections.Generic;
using System.Linq;
using Helpers;
using StoryMode.StoryModeObjects;
using StoryMode.StoryModePhases;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace StoryMode.Quests.SecondPhase;

public class ConspiracyProgressQuest : StoryModeQuestBase
{
	[SaveableField(2)]
	private JournalLog _startQuestLog;

	private bool _isImperialSide => StoryModeManager.Current.MainStoryLine.IsOnImperialQuestLine;

	private TextObject _startQuestLogText
	{
		get
		{
			TextObject textObject = new TextObject("{=oX2aoilb}{MENTOR.NAME} knows of the rise of your {KINGDOM_NAME}. Rumors say {MENTOR.NAME} is planning to undo your progress. Be ready!");
			StringHelpers.SetCharacterProperties("MENTOR", _isImperialSide ? StoryModeHeroes.AntiImperialMentor.CharacterObject : StoryModeHeroes.ImperialMentor.CharacterObject, textObject);
			textObject.SetTextVariable("KINGDOM_NAME", (Clan.PlayerClan.Kingdom != null) ? Clan.PlayerClan.Kingdom.Name : Clan.PlayerClan.Name);
			return textObject;
		}
	}

	private TextObject _questCanceledLogText => new TextObject("{=tVlZTOst}You have chosen a different path.");

	public override TextObject Title
	{
		get
		{
			TextObject textObject;
			if (_isImperialSide)
			{
				textObject = new TextObject("{=PJ5C3Dim}{ANTIIMPERIAL_MENTOR.NAME}'s Conspiracy");
				StringHelpers.SetCharacterProperties("ANTIIMPERIAL_MENTOR", StoryModeHeroes.AntiImperialMentor.CharacterObject, textObject);
			}
			else
			{
				textObject = new TextObject("{=i3SSc0I4}{IMPERIAL_MENTOR.NAME}'s Plan");
				StringHelpers.SetCharacterProperties("IMPERIAL_MENTOR", StoryModeHeroes.ImperialMentor.CharacterObject, textObject);
			}
			return textObject;
		}
	}

	public ConspiracyProgressQuest()
		: base("conspiracy_quest_campaign_behavior", null, CampaignTime.Never)
	{
		StoryMode.StoryModePhases.SecondPhase.Instance.TriggerConspiracy();
	}

	protected override void InitializeQuestOnGameLoad()
	{
		SetDialogs();
	}

	protected override void HourlyTick()
	{
	}

	protected override void RegisterEvents()
	{
		CampaignEvents.DailyTickEvent.AddNonSerializedListener(this, DailyTick);
		CampaignEvents.OnQuestCompletedEvent.AddNonSerializedListener(this, OnQuestCompleted);
		StoryModeEvents.OnConspiracyActivatedEvent.AddNonSerializedListener(this, OnConspiracyActivated);
		CampaignEvents.ClanChangedKingdom.AddNonSerializedListener(this, OnClanChangedKingdom);
	}

	private void OnClanChangedKingdom(Clan clan, Kingdom oldKingdom, Kingdom newKingdom, ChangeKingdomAction.ChangeKingdomActionDetail detail, bool showNotification = true)
	{
		if (clan == Clan.PlayerClan && oldKingdom == StoryModeManager.Current.MainStoryLine.PlayerSupportedKingdom)
		{
			CompleteQuestWithCancel(_questCanceledLogText);
			StoryModeManager.Current.MainStoryLine.CancelSecondAndThirdPhase();
		}
	}

	protected override void OnStartQuest()
	{
		_startQuestLog = AddDiscreteLog(_startQuestLogText, new TextObject("{=1LrHV647}Conspiracy Strength"), (int)StoryMode.StoryModePhases.SecondPhase.Instance.ConspiracyStrength, 2000);
	}

	protected override void SetDialogs()
	{
	}

	protected override void OnFinalize()
	{
		base.OnFinalize();
		foreach (QuestBase item in Campaign.Current.QuestManager.Quests.ToList())
		{
			if (typeof(ConspiracyQuestBase) == item.GetType().BaseType && item.IsOngoing)
			{
				item.CompleteQuestWithCancel(new TextObject("{=YJxCbbpd}Conspiracy is activated!"));
			}
		}
	}

	private void DailyTick()
	{
		StoryModeManager.Current.MainStoryLine.SecondPhase.IncreaseConspiracyStrength();
		_startQuestLog.UpdateCurrentProgress((int)StoryModeManager.Current.MainStoryLine.SecondPhase.ConspiracyStrength);
	}

	private void OnQuestCompleted(QuestBase quest, QuestCompleteDetails detail)
	{
		if (detail == QuestCompleteDetails.Success && typeof(ConspiracyQuestBase) == quest.GetType().BaseType)
		{
			_startQuestLog.UpdateCurrentProgress((int)StoryModeManager.Current.MainStoryLine.SecondPhase.ConspiracyStrength);
		}
	}

	private void OnConspiracyActivated()
	{
		CompleteQuestWithTimeOut();
	}

	internal static void AutoGeneratedStaticCollectObjectsConspiracyProgressQuest(object o, List<object> collectedObjects)
	{
		((ConspiracyProgressQuest)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		base.AutoGeneratedInstanceCollectObjects(collectedObjects);
		collectedObjects.Add(_startQuestLog);
	}

	internal static object AutoGeneratedGetMemberValue_startQuestLog(object o)
	{
		return ((ConspiracyProgressQuest)o)._startQuestLog;
	}
}
