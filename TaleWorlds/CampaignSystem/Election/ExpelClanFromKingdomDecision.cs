using System.Collections.Generic;
using System.Linq;
using Helpers;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.Party.PartyComponents;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.Election;

public class ExpelClanFromKingdomDecision : KingdomDecision
{
	public class ExpelClanDecisionOutcome : DecisionOutcome
	{
		[SaveableField(100)]
		public readonly bool ShouldBeExpelled;

		internal static void AutoGeneratedStaticCollectObjectsExpelClanDecisionOutcome(object o, List<object> collectedObjects)
		{
			((ExpelClanDecisionOutcome)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
		}

		protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
		{
			base.AutoGeneratedInstanceCollectObjects(collectedObjects);
		}

		internal static object AutoGeneratedGetMemberValueShouldBeExpelled(object o)
		{
			return ((ExpelClanDecisionOutcome)o).ShouldBeExpelled;
		}

		public ExpelClanDecisionOutcome(bool shouldBeExpelled)
		{
			ShouldBeExpelled = shouldBeExpelled;
		}

		public override TextObject GetDecisionTitle()
		{
			TextObject textObject = new TextObject("{=kakxnaN5}{?SUPPORT}Yes{?}No{\\?}");
			textObject.SetTextVariable("SUPPORT", ShouldBeExpelled ? 1 : 0);
			return textObject;
		}

		public override TextObject GetDecisionDescription()
		{
			if (ShouldBeExpelled)
			{
				return new TextObject("{=s8z5Ugvm}The clan should be expelled");
			}
			return new TextObject("{=b2InhEeP}We oppose expelling the clan");
		}

		public override string GetDecisionLink()
		{
			return null;
		}

		public override ImageIdentifier GetDecisionImageIdentifier()
		{
			return null;
		}
	}

	private const float ClanFiefModifier = 0.005f;

	[SaveableField(100)]
	public readonly Clan ClanToExpel;

	[SaveableField(102)]
	public readonly Kingdom OldKingdom;

	internal static void AutoGeneratedStaticCollectObjectsExpelClanFromKingdomDecision(object o, List<object> collectedObjects)
	{
		((ExpelClanFromKingdomDecision)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		base.AutoGeneratedInstanceCollectObjects(collectedObjects);
		collectedObjects.Add(ClanToExpel);
		collectedObjects.Add(OldKingdom);
	}

	internal static object AutoGeneratedGetMemberValueClanToExpel(object o)
	{
		return ((ExpelClanFromKingdomDecision)o).ClanToExpel;
	}

	internal static object AutoGeneratedGetMemberValueOldKingdom(object o)
	{
		return ((ExpelClanFromKingdomDecision)o).OldKingdom;
	}

	public ExpelClanFromKingdomDecision(Clan proposerClan, Clan clan)
		: base(proposerClan)
	{
		ClanToExpel = clan;
		OldKingdom = clan.Kingdom;
	}

	public override bool IsAllowed()
	{
		return Campaign.Current.Models.KingdomDecisionPermissionModel.IsExpulsionDecisionAllowed(ClanToExpel);
	}

	public override int GetProposalInfluenceCost()
	{
		return Campaign.Current.Models.DiplomacyModel.GetInfluenceCostOfExpellingClan(base.ProposerClan);
	}

	public override TextObject GetGeneralTitle()
	{
		TextObject textObject = new TextObject("{=pF92DagG}Expel {CLAN_NAME} from {KINGDOM_NAME}");
		textObject.SetTextVariable("CLAN_NAME", ClanToExpel.Name);
		textObject.SetTextVariable("KINGDOM_NAME", OldKingdom.Name);
		return textObject;
	}

	public override TextObject GetSupportTitle()
	{
		TextObject textObject = new TextObject("{=ZwpWX8Zx}Vote for expelling {CLAN_NAME} from the kingdom");
		textObject.SetTextVariable("CLAN_NAME", ClanToExpel.Name);
		return textObject;
	}

	public override TextObject GetChooseTitle()
	{
		TextObject textObject = new TextObject("{=pF92DagG}Expel {CLAN_NAME} from {KINGDOM_NAME}");
		textObject.SetTextVariable("CLAN_NAME", ClanToExpel.Name);
		textObject.SetTextVariable("KINGDOM_NAME", OldKingdom.Name);
		return textObject;
	}

	public override TextObject GetSupportDescription()
	{
		TextObject textObject = new TextObject("{=eTr0XHas}{FACTION_LEADER} will decide if {CLAN_NAME} will be expelled from {KINGDOM_NAME}. You can pick your stance regarding this decision.");
		textObject.SetTextVariable("FACTION_LEADER", DetermineChooser().Leader.Name);
		textObject.SetTextVariable("CLAN_NAME", ClanToExpel.Name);
		textObject.SetTextVariable("KINGDOM_NAME", OldKingdom.Name);
		return textObject;
	}

	public override TextObject GetChooseDescription()
	{
		TextObject textObject = new TextObject("{=J8brFxIW}As {?IS_FEMALE}queen{?}king{\\?} you must decide if {CLAN_NAME} will be expelled from kingdom.");
		textObject.SetTextVariable("IS_FEMALE", DetermineChooser().Leader.IsFemale ? 1 : 0);
		textObject.SetTextVariable("CLAN_NAME", ClanToExpel.Name);
		return textObject;
	}

	public override IEnumerable<DecisionOutcome> DetermineInitialCandidates()
	{
		yield return new ExpelClanDecisionOutcome(shouldBeExpelled: true);
		yield return new ExpelClanDecisionOutcome(shouldBeExpelled: false);
	}

	public override Clan DetermineChooser()
	{
		return OldKingdom.RulingClan;
	}

	protected override bool ShouldBeCancelledInternal()
	{
		return !base.Kingdom.Clans.Contains(ClanToExpel);
	}

	public override float DetermineSupport(Clan clan, DecisionOutcome possibleOutcome)
	{
		float num = 0f;
		bool shouldBeExpelled = ((ExpelClanDecisionOutcome)possibleOutcome).ShouldBeExpelled;
		float num2 = 3.5f;
		float num3 = (float)FactionManager.GetRelationBetweenClans(ClanToExpel, clan) * num2;
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 10000f;
		foreach (Settlement settlement in ClanToExpel.Settlements)
		{
			num4 += settlement.GetSettlementValueForFaction(OldKingdom) * 0.005f;
		}
		if (clan.Leader.GetTraitLevel(DefaultTraits.Calculating) > 0)
		{
			num6 = ClanToExpel.Influence * 0.05f + ClanToExpel.Renown * 0.02f;
		}
		if (clan.Leader.GetTraitLevel(DefaultTraits.Commander) > 0)
		{
			foreach (WarPartyComponent warPartyComponent in ClanToExpel.WarPartyComponents)
			{
				num5 += (float)warPartyComponent.MobileParty.MemberRoster.TotalManCount * 0.01f;
			}
		}
		num = num7 + num3 + num4 + num5 + num6;
		float num8 = 0f;
		if (shouldBeExpelled)
		{
			return 0f - num;
		}
		return num;
	}

	public override void DetermineSponsors(MBReadOnlyList<DecisionOutcome> possibleOutcomes)
	{
		foreach (DecisionOutcome possibleOutcome in possibleOutcomes)
		{
			if (((ExpelClanDecisionOutcome)possibleOutcome).ShouldBeExpelled)
			{
				possibleOutcome.SetSponsor(base.ProposerClan);
			}
			else
			{
				AssignDefaultSponsor(possibleOutcome);
			}
		}
	}

	public override void ApplyChosenOutcome(DecisionOutcome chosenOutcome)
	{
		if (!((ExpelClanDecisionOutcome)chosenOutcome).ShouldBeExpelled)
		{
			return;
		}
		int relationCostOfExpellingClanFromKingdom = Campaign.Current.Models.DiplomacyModel.GetRelationCostOfExpellingClanFromKingdom();
		foreach (Supporter supporter in chosenOutcome.SupporterList)
		{
			if (((ExpelClanDecisionOutcome)chosenOutcome).ShouldBeExpelled && ClanToExpel.Leader != supporter.Clan.Leader)
			{
				ChangeRelationAction.ApplyRelationChangeBetweenHeroes(ClanToExpel.Leader, supporter.Clan.Leader, relationCostOfExpellingClanFromKingdom);
			}
		}
		ChangeKingdomAction.ApplyByLeaveKingdom(ClanToExpel);
	}

	public override TextObject GetSecondaryEffects()
	{
		return new TextObject("{=fJY9uosa}All supporters gain some relations with each other and lose a large amount of relations with the expelled clan.");
	}

	public override void ApplySecondaryEffects(MBReadOnlyList<DecisionOutcome> possibleOutcomes, DecisionOutcome chosenOutcome)
	{
	}

	public override TextObject GetChosenOutcomeText(DecisionOutcome chosenOutcome, SupportStatus supportStatus, bool isShortVersion = false)
	{
		TextObject textObject = (((ExpelClanDecisionOutcome)chosenOutcome).ShouldBeExpelled ? (IsSingleClanDecision() ? new TextObject("{=h5eTEYON}{RULER.NAME} has expelled the {CLAN} clan from the {KINGDOM}.") : (supportStatus switch
		{
			SupportStatus.Majority => new TextObject("{=rd229FYG}{RULER.NAME} has expelled the {CLAN} clan from the {KINGDOM} with the support of {?RULER.GENDER}her{?}his{\\?} council."), 
			SupportStatus.Minority => new TextObject("{=G3qGLAeQ}{RULER.NAME} has expelled the {CLAN} clan from the {KINGDOM} against the wishes of {?RULER.GENDER}her{?}his{\\?} council."), 
			_ => new TextObject("{=m6OVl6Dg}{RULER.NAME} has expelled the {CLAN} clan from the {KINGDOM}, with {?RULER.GENDER}her{?}his{\\?} council evenly split on the matter."), 
		})) : (IsSingleClanDecision() ? new TextObject("{=mvkKP6OE}{RULER.NAME} chose not to expel the {CLAN} clan from the {KINGDOM}.") : (supportStatus switch
		{
			SupportStatus.Majority => new TextObject("{=yBL3TzXw}{RULER.NAME} chose not to expel the {CLAN} clan from the {KINGDOM} with the support of {?RULER.GENDER}her{?}his{\\?} council."), 
			SupportStatus.Minority => new TextObject("{=940TwBPs}{RULER.NAME} chose not to expel the {CLAN} clan from the {KINGDOM} over the objections of {?RULER.GENDER}her{?}his{\\?} council."), 
			_ => new TextObject("{=Oe1NdVLe}{RULER.NAME} chose not to expel the {CLAN} clan from the {KINGDOM} with {?RULER.GENDER}her{?}his{\\?} council evenly split on the matter."), 
		})));
		textObject.SetTextVariable("CLAN", ClanToExpel.Name);
		textObject.SetTextVariable("KINGDOM", OldKingdom.Name);
		StringHelpers.SetCharacterProperties("RULER", OldKingdom.Leader.CharacterObject, textObject);
		return textObject;
	}

	public override DecisionOutcome GetQueriedDecisionOutcome(MBReadOnlyList<DecisionOutcome> possibleOutcomes)
	{
		return possibleOutcomes.FirstOrDefault((DecisionOutcome t) => ((ExpelClanDecisionOutcome)t).ShouldBeExpelled);
	}
}
