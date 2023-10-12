using System.Collections.Generic;
using Helpers;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.BarterSystem.Barterables;

public class SetPrisonerFreeBarterable : Barterable
{
	[SaveableField(900)]
	private readonly Hero _prisonerCharacter;

	[SaveableField(901)]
	private readonly Hero _ransompayer;

	public override string StringID => "set_prisoner_free_barterable";

	public override TextObject Name
	{
		get
		{
			StringHelpers.SetCharacterProperties("PRISONER", _prisonerCharacter.CharacterObject);
			return new TextObject("{=RwOzeGc3}Release {PRISONER.NAME}");
		}
	}

	public SetPrisonerFreeBarterable(Hero prisonerCharacter, Hero captor, PartyBase ownerParty, Hero ransompayer)
		: base(captor, ownerParty)
	{
		_prisonerCharacter = prisonerCharacter;
		_ransompayer = ransompayer;
	}

	public override int GetUnitValueForFaction(IFaction faction)
	{
		float num = (float)Campaign.Current.Models.RansomValueCalculationModel.PrisonerRansomValue(_prisonerCharacter.CharacterObject) * (1f + MBMath.ClampFloat(_prisonerCharacter.CaptivityStartTime.ElapsedWeeksUntilNow, 0f, 8f) * 0.3f) * 0.9f;
		if (faction == _prisonerCharacter.MapFaction || faction == _prisonerCharacter.Clan)
		{
			return (int)num;
		}
		if (faction.MapFaction == _prisonerCharacter.PartyBelongedToAsPrisoner.MapFaction)
		{
			return (int)(0f - num);
		}
		return 0;
	}

	public override ImageIdentifier GetVisualIdentifier()
	{
		return new ImageIdentifier(CharacterCode.CreateFrom(_prisonerCharacter.CharacterObject));
	}

	public override string GetEncyclopediaLink()
	{
		return _prisonerCharacter.EncyclopediaLink;
	}

	public override void Apply()
	{
		if (_prisonerCharacter.IsPrisoner)
		{
			EndCaptivityAction.ApplyByRansom(_prisonerCharacter, _ransompayer);
		}
	}

	internal static void AutoGeneratedStaticCollectObjectsSetPrisonerFreeBarterable(object o, List<object> collectedObjects)
	{
		((SetPrisonerFreeBarterable)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		base.AutoGeneratedInstanceCollectObjects(collectedObjects);
		collectedObjects.Add(_prisonerCharacter);
		collectedObjects.Add(_ransompayer);
	}

	internal static object AutoGeneratedGetMemberValue_prisonerCharacter(object o)
	{
		return ((SetPrisonerFreeBarterable)o)._prisonerCharacter;
	}

	internal static object AutoGeneratedGetMemberValue_ransompayer(object o)
	{
		return ((SetPrisonerFreeBarterable)o)._ransompayer;
	}
}