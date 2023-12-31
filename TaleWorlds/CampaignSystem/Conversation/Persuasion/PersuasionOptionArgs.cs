using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.Conversation.Persuasion;

public class PersuasionOptionArgs
{
	[SaveableField(102)]
	public readonly PersuasionArgumentStrength ArgumentStrength;

	[SaveableField(103)]
	public readonly SkillObject SkillUsed;

	[SaveableField(104)]
	public readonly TraitObject TraitUsed;

	[SaveableField(111)]
	public readonly Tuple<TraitObject, int>[] TraitCorrelation;

	[SaveableField(105)]
	public readonly TraitEffect TraitEffect;

	[SaveableField(106)]
	public readonly bool CanBlockOtherOption;

	[SaveableField(107)]
	public readonly bool CanMoveToTheNextReservation;

	[SaveableField(108)]
	public readonly bool GivesCriticalSuccess;

	[SaveableField(110)]
	public readonly TextObject Line;

	[SaveableField(109)]
	private bool _isBlocked;

	public bool IsBlocked => _isBlocked;

	internal static void AutoGeneratedStaticCollectObjectsPersuasionOptionArgs(object o, List<object> collectedObjects)
	{
		((PersuasionOptionArgs)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected virtual void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		collectedObjects.Add(SkillUsed);
		collectedObjects.Add(TraitUsed);
		collectedObjects.Add(TraitCorrelation);
		collectedObjects.Add(Line);
	}

	internal static object AutoGeneratedGetMemberValueArgumentStrength(object o)
	{
		return ((PersuasionOptionArgs)o).ArgumentStrength;
	}

	internal static object AutoGeneratedGetMemberValueSkillUsed(object o)
	{
		return ((PersuasionOptionArgs)o).SkillUsed;
	}

	internal static object AutoGeneratedGetMemberValueTraitUsed(object o)
	{
		return ((PersuasionOptionArgs)o).TraitUsed;
	}

	internal static object AutoGeneratedGetMemberValueTraitCorrelation(object o)
	{
		return ((PersuasionOptionArgs)o).TraitCorrelation;
	}

	internal static object AutoGeneratedGetMemberValueTraitEffect(object o)
	{
		return ((PersuasionOptionArgs)o).TraitEffect;
	}

	internal static object AutoGeneratedGetMemberValueCanBlockOtherOption(object o)
	{
		return ((PersuasionOptionArgs)o).CanBlockOtherOption;
	}

	internal static object AutoGeneratedGetMemberValueCanMoveToTheNextReservation(object o)
	{
		return ((PersuasionOptionArgs)o).CanMoveToTheNextReservation;
	}

	internal static object AutoGeneratedGetMemberValueGivesCriticalSuccess(object o)
	{
		return ((PersuasionOptionArgs)o).GivesCriticalSuccess;
	}

	internal static object AutoGeneratedGetMemberValueLine(object o)
	{
		return ((PersuasionOptionArgs)o).Line;
	}

	internal static object AutoGeneratedGetMemberValue_isBlocked(object o)
	{
		return ((PersuasionOptionArgs)o)._isBlocked;
	}

	public PersuasionOptionArgs(SkillObject skill, TraitObject trait, TraitEffect traitEffect, PersuasionArgumentStrength argumentStrength, bool givesCriticalSuccess, TextObject line, Tuple<TraitObject, int>[] traitCorrelation = null, bool canBlockOtherOption = false, bool canMoveToTheNextReservation = false, bool isInitiallyBlocked = false)
	{
		SkillUsed = skill;
		TraitUsed = trait;
		TraitEffect = traitEffect;
		ArgumentStrength = argumentStrength;
		GivesCriticalSuccess = givesCriticalSuccess;
		CanBlockOtherOption = canBlockOtherOption;
		CanMoveToTheNextReservation = canMoveToTheNextReservation;
		_isBlocked = isInitiallyBlocked;
		Line = line;
		TraitCorrelation = traitCorrelation;
	}

	public void BlockTheOption(bool isBlocked)
	{
		_isBlocked = isBlocked;
	}
}
