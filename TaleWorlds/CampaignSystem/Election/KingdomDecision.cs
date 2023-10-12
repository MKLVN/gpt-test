using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.Election;

public abstract class KingdomDecision
{
	public enum SupportStatus
	{
		Equal,
		Majority,
		Minority
	}

	[SaveableField(0)]
	private static bool _notificationsEnabled = true;

	[SaveableField(1)]
	private bool _isEnforced;

	[SaveableField(2)]
	private bool _playerExamined;

	private bool _notifyPlayer = _notificationsEnabled;

	[SaveableField(10)]
	private Kingdom _kingdom;

	public SupportStatus SupportStatusOfFinalDecision;

	public Kingdom Kingdom => _kingdom ?? ProposerClan.Kingdom;

	[SaveableProperty(4)]
	public Clan ProposerClan { get; private set; }

	public bool IsEnforced
	{
		get
		{
			return _isEnforced;
		}
		set
		{
			_isEnforced = value;
		}
	}

	public bool PlayerExamined
	{
		get
		{
			return _playerExamined;
		}
		set
		{
			_playerExamined = value;
		}
	}

	public bool NotifyPlayer
	{
		get
		{
			if (!_notifyPlayer)
			{
				return IsEnforced;
			}
			return true;
		}
		set
		{
			_notifyPlayer = value;
		}
	}

	public bool IsPlayerParticipant
	{
		get
		{
			if (Kingdom == Clan.PlayerClan.Kingdom)
			{
				return !Clan.PlayerClan.IsUnderMercenaryService;
			}
			return false;
		}
	}

	[SaveableProperty(3)]
	public CampaignTime TriggerTime { get; protected set; }

	public virtual bool IsKingsVoteAllowed => true;

	protected virtual int HoursToWait => 48;

	public bool NeedsPlayerResolution
	{
		get
		{
			if (Kingdom == Clan.PlayerClan.Kingdom)
			{
				if (!IsEnforced)
				{
					if (TriggerTime.IsPast)
					{
						return Kingdom.RulingClan == Clan.PlayerClan;
					}
					return false;
				}
				return true;
			}
			return false;
		}
	}

	protected virtual void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		collectedObjects.Add(_kingdom);
		collectedObjects.Add(ProposerClan);
		CampaignTime.AutoGeneratedStaticCollectObjectsCampaignTime(TriggerTime, collectedObjects);
	}

	internal static object AutoGeneratedGetMemberValueProposerClan(object o)
	{
		return ((KingdomDecision)o).ProposerClan;
	}

	internal static object AutoGeneratedGetMemberValueTriggerTime(object o)
	{
		return ((KingdomDecision)o).TriggerTime;
	}

	internal static object AutoGeneratedGetMemberValue_isEnforced(object o)
	{
		return ((KingdomDecision)o)._isEnforced;
	}

	internal static object AutoGeneratedGetMemberValue_playerExamined(object o)
	{
		return ((KingdomDecision)o)._playerExamined;
	}

	internal static object AutoGeneratedGetMemberValue_kingdom(object o)
	{
		return ((KingdomDecision)o)._kingdom;
	}

	protected KingdomDecision(Clan proposerClan)
	{
		ProposerClan = proposerClan;
		_kingdom = proposerClan.Kingdom;
		TriggerTime = CampaignTime.HoursFromNow(HoursToWait);
	}

	public abstract bool IsAllowed();

	public int GetInfluenceCost(Clan sponsorClan)
	{
		int proposalInfluenceCost = GetProposalInfluenceCost();
		if (sponsorClan != Clan.PlayerClan)
		{
			return proposalInfluenceCost;
		}
		return proposalInfluenceCost;
	}

	public abstract int GetProposalInfluenceCost();

	public abstract TextObject GetGeneralTitle();

	public abstract TextObject GetSupportTitle();

	public abstract TextObject GetChooseTitle();

	public abstract TextObject GetSupportDescription();

	public abstract TextObject GetChooseDescription();

	public virtual float CalculateMeritOfOutcome(DecisionOutcome candidateOutcome)
	{
		return 1f;
	}

	public abstract IEnumerable<DecisionOutcome> DetermineInitialCandidates();

	public MBList<DecisionOutcome> NarrowDownCandidates(MBList<DecisionOutcome> initialCandidates, int maxCandidateCount)
	{
		foreach (DecisionOutcome initialCandidate in initialCandidates)
		{
			initialCandidate.InitialMerit = CalculateMeritOfOutcome(initialCandidate);
		}
		return SortDecisionOutcomes(initialCandidates).Take(maxCandidateCount).ToMBList();
	}

	public abstract Clan DetermineChooser();

	public IEnumerable<Supporter> DetermineSupporters()
	{
		foreach (Clan clan in Kingdom.Clans)
		{
			if (!clan.IsUnderMercenaryService)
			{
				yield return new Supporter(clan);
			}
		}
	}

	protected virtual bool ShouldBeCancelledInternal()
	{
		return false;
	}

	protected virtual bool CanProposerClanChangeOpinion()
	{
		return false;
	}

	public bool ShouldBeCancelled()
	{
		if (ProposerClan.Kingdom != Kingdom)
		{
			return true;
		}
		if (!IsAllowed())
		{
			return true;
		}
		if (ShouldBeCancelledInternal())
		{
			return true;
		}
		if (ProposerClan == Clan.PlayerClan)
		{
			return false;
		}
		MBList<DecisionOutcome> mBList = NarrowDownCandidates(DetermineInitialCandidates().ToMBList(), 3);
		DecisionOutcome queriedDecisionOutcome = GetQueriedDecisionOutcome(mBList);
		DetermineSponsors(mBList);
		Supporter.SupportWeights supportWeightOfSelectedOutcome;
		DecisionOutcome decisionOutcome = DetermineSupportOption(new Supporter(ProposerClan), mBList, out supportWeightOfSelectedOutcome, calculateRelationshipEffect: true);
		bool flag = ProposerClan.Influence < (float)GetInfluenceCostOfSupport(ProposerClan, Supporter.SupportWeights.SlightlyFavor) * 1.5f;
		bool num = mBList.Any((DecisionOutcome t) => t.SponsorClan != null && t.SponsorClan.IsEliminated);
		bool flag2 = supportWeightOfSelectedOutcome == Supporter.SupportWeights.StayNeutral || decisionOutcome == null;
		bool flag3 = decisionOutcome != queriedDecisionOutcome || (decisionOutcome == queriedDecisionOutcome && flag2);
		if (!num)
		{
			if (mBList.Any((DecisionOutcome t) => t.SponsorClan == ProposerClan) && !flag)
			{
				if (!(!CanProposerClanChangeOpinion() && flag3))
				{
					return CanProposerClanChangeOpinion() && flag2;
				}
				return true;
			}
			return false;
		}
		return true;
	}

	public DecisionOutcome DetermineSupportOption(Supporter supporter, MBReadOnlyList<DecisionOutcome> possibleOutcomes, out Supporter.SupportWeights supportWeightOfSelectedOutcome, bool calculateRelationshipEffect)
	{
		Supporter.SupportWeights supportWeights = Supporter.SupportWeights.Choose;
		DecisionOutcome decisionOutcome = null;
		DecisionOutcome decisionOutcome2 = null;
		float num = float.MinValue;
		float num2 = 0f;
		int num3 = 0;
		Clan clan = supporter.Clan;
		foreach (DecisionOutcome possibleOutcome in possibleOutcomes)
		{
			float num4 = DetermineSupport(supporter.Clan, possibleOutcome);
			if (num4 > num)
			{
				decisionOutcome = possibleOutcome;
				num = num4;
			}
			if (num4 < num2)
			{
				decisionOutcome2 = possibleOutcome;
				num2 = num4;
			}
			num3++;
		}
		if (decisionOutcome != null)
		{
			float num5 = num;
			if (decisionOutcome2 != null)
			{
				num5 -= 0.5f * num2;
			}
			float num6 = num5;
			if (clan.Influence < num6 * 2f)
			{
				num6 *= 0.5f;
				if (num6 > clan.Influence * 0.7f)
				{
					num6 = clan.Influence * 0.7f;
				}
			}
			else if (clan.Influence > num6 * 10f)
			{
				num6 *= 1.5f;
			}
			if (decisionOutcome.Likelihood > 0.65f)
			{
				num6 *= 1.6f * (1.2f - decisionOutcome.Likelihood);
			}
			if (calculateRelationshipEffect && decisionOutcome.SponsorClan != null)
			{
				int num7 = (int)(100f - TaleWorlds.Library.MathF.Clamp(clan.Leader.GetRelation(decisionOutcome.SponsorClan.Leader), -100f, 100f));
				float num8 = TaleWorlds.Library.MathF.Lerp(0.2f, 1.8f, 1f - (float)num7 / 200f);
				num6 *= num8;
			}
			if (num6 > (float)GetInfluenceCostOfSupport(supporter.Clan, Supporter.SupportWeights.FullyPush))
			{
				supportWeights = Supporter.SupportWeights.FullyPush;
			}
			else if (num6 > (float)GetInfluenceCostOfSupport(supporter.Clan, Supporter.SupportWeights.StronglyFavor))
			{
				supportWeights = Supporter.SupportWeights.StronglyFavor;
			}
			else if (num6 > (float)GetInfluenceCostOfSupport(supporter.Clan, Supporter.SupportWeights.SlightlyFavor))
			{
				supportWeights = Supporter.SupportWeights.SlightlyFavor;
			}
		}
		while (supportWeights >= Supporter.SupportWeights.SlightlyFavor && supporter.Clan != null && supporter.Clan.Influence < (float)GetInfluenceCostOfSupport(supporter.Clan, supportWeights))
		{
			supportWeights--;
		}
		supportWeightOfSelectedOutcome = supportWeights;
		if (supportWeights == Supporter.SupportWeights.StayNeutral || supportWeights == Supporter.SupportWeights.Choose)
		{
			return null;
		}
		return decisionOutcome;
	}

	public abstract float DetermineSupport(Clan clan, DecisionOutcome possibleOutcome);

	public abstract void DetermineSponsors(MBReadOnlyList<DecisionOutcome> possibleOutcomes);

	protected void AssignDefaultSponsor(DecisionOutcome outcome)
	{
		if (outcome.SupporterList.Count > 0)
		{
			Supporter.SupportWeights maxWeight = outcome.SupporterList.Max((Supporter t) => t.SupportWeight);
			Supporter supporter = outcome.SupporterList.First((Supporter t) => t.SupportWeight == maxWeight);
			outcome.SetSponsor(supporter.Clan);
		}
	}

	public abstract void ApplyChosenOutcome(DecisionOutcome chosenOutcome);

	public int GetInfluenceCost(DecisionOutcome decisionOutcome, Clan clan, Supporter.SupportWeights supportWeight)
	{
		int result = 0;
		switch (supportWeight)
		{
		case Supporter.SupportWeights.Choose:
			result = 0;
			break;
		case Supporter.SupportWeights.StayNeutral:
			result = 0;
			break;
		case Supporter.SupportWeights.SlightlyFavor:
			result = GetInfluenceCostOfSupport(clan, Supporter.SupportWeights.SlightlyFavor);
			break;
		case Supporter.SupportWeights.StronglyFavor:
			result = GetInfluenceCostOfSupport(clan, Supporter.SupportWeights.StronglyFavor);
			break;
		case Supporter.SupportWeights.FullyPush:
			result = GetInfluenceCostOfSupport(clan, Supporter.SupportWeights.FullyPush);
			break;
		default:
			Debug.FailedAssert("false", "C:\\Develop\\MB3\\Source\\Bannerlord\\TaleWorlds.CampaignSystem\\Election\\KingdomDecision.cs", "GetInfluenceCost", 334);
			break;
		}
		return result;
	}

	public abstract TextObject GetSecondaryEffects();

	public abstract void ApplySecondaryEffects(MBReadOnlyList<DecisionOutcome> possibleOutcomes, DecisionOutcome chosenOutcome);

	public abstract TextObject GetChosenOutcomeText(DecisionOutcome chosenOutcome, SupportStatus supportStatus, bool isShortVersion = false);

	public MBList<DecisionOutcome> SortDecisionOutcomes(MBReadOnlyList<DecisionOutcome> possibleOutcomes)
	{
		return possibleOutcomes.OrderByDescending((DecisionOutcome k) => k.InitialMerit).ToMBList();
	}

	public abstract DecisionOutcome GetQueriedDecisionOutcome(MBReadOnlyList<DecisionOutcome> possibleOutcomes);

	public bool IsSingleClanDecision()
	{
		return Kingdom.Clans.Count == 1;
	}

	public virtual float CalculateRelationshipEffectWithSponsor(Clan clan)
	{
		float num = 0.8f;
		return (float)clan.Leader.GetRelation(ProposerClan.Leader) * num;
	}

	public int GetInfluenceCostOfSupport(Clan clan, Supporter.SupportWeights supportWeight)
	{
		int influenceCostOfSupportInternal = GetInfluenceCostOfSupportInternal(supportWeight);
		float num = 1f;
		if (clan.Leader.GetPerkValue(DefaultPerks.Charm.FlexibleEthics))
		{
			num += DefaultPerks.Charm.FlexibleEthics.PrimaryBonus;
		}
		return (int)((float)influenceCostOfSupportInternal * num);
	}

	protected virtual int GetInfluenceCostOfSupportInternal(Supporter.SupportWeights supportWeight)
	{
		switch (supportWeight)
		{
		case Supporter.SupportWeights.SlightlyFavor:
			return 20;
		case Supporter.SupportWeights.StronglyFavor:
			return 60;
		case Supporter.SupportWeights.FullyPush:
			return 150;
		default:
			throw new ArgumentOutOfRangeException("supportWeight", supportWeight, null);
		case Supporter.SupportWeights.Choose:
		case Supporter.SupportWeights.StayNeutral:
			return 0;
		}
	}

	public virtual bool OnShowDecision()
	{
		return true;
	}

	public virtual KingdomDecision GetFollowUpDecision()
	{
		return null;
	}
}
