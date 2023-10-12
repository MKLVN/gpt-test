using System.Collections.Generic;
using TaleWorlds.Core;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.Roster;

public struct FlattenedTroopRosterElement : ISavedStruct
{
	public static readonly FlattenedTroopRosterElement DefaultFlattenedTroopRosterElement;

	[SaveableField(0)]
	private readonly CharacterObject _troop;

	[SaveableField(1)]
	private readonly int _xp;

	[SaveableField(3)]
	private readonly int _xpGain;

	[SaveableField(4)]
	private readonly UniqueTroopDescriptor _uniqueNo;

	[SaveableProperty(5)]
	public RosterTroopState State { get; private set; }

	public CharacterObject Troop => _troop;

	public bool IsWounded
	{
		get
		{
			if (Troop.IsHero)
			{
				return Troop.HeroObject.IsWounded;
			}
			if (State != RosterTroopState.Wounded)
			{
				return State == RosterTroopState.WoundedInThisBattle;
			}
			return true;
		}
		set
		{
			State = (value ? RosterTroopState.Wounded : RosterTroopState.Active);
		}
	}

	public bool IsRouted
	{
		get
		{
			return State == RosterTroopState.Routed;
		}
		set
		{
			State = (value ? RosterTroopState.Routed : RosterTroopState.Active);
		}
	}

	public bool IsKilled
	{
		get
		{
			return State == RosterTroopState.Killed;
		}
		set
		{
			State = (value ? RosterTroopState.Killed : RosterTroopState.Active);
		}
	}

	public int Xp => _xp;

	public int XpGained => _xpGain;

	public UniqueTroopDescriptor Descriptor => _uniqueNo;

	public static void AutoGeneratedStaticCollectObjectsFlattenedTroopRosterElement(object o, List<object> collectedObjects)
	{
		((FlattenedTroopRosterElement)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	private void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		collectedObjects.Add(_troop);
		UniqueTroopDescriptor.AutoGeneratedStaticCollectObjectsUniqueTroopDescriptor(_uniqueNo, collectedObjects);
	}

	internal static object AutoGeneratedGetMemberValueState(object o)
	{
		return ((FlattenedTroopRosterElement)o).State;
	}

	internal static object AutoGeneratedGetMemberValue_troop(object o)
	{
		return ((FlattenedTroopRosterElement)o)._troop;
	}

	internal static object AutoGeneratedGetMemberValue_xp(object o)
	{
		return ((FlattenedTroopRosterElement)o)._xp;
	}

	internal static object AutoGeneratedGetMemberValue_xpGain(object o)
	{
		return ((FlattenedTroopRosterElement)o)._xpGain;
	}

	internal static object AutoGeneratedGetMemberValue_uniqueNo(object o)
	{
		return ((FlattenedTroopRosterElement)o)._uniqueNo;
	}

	public FlattenedTroopRosterElement(CharacterObject troop, RosterTroopState state = RosterTroopState.Active, int xp = 0, UniqueTroopDescriptor uniqueNo = default(UniqueTroopDescriptor), int xpGain = 0)
	{
		this = default(FlattenedTroopRosterElement);
		_troop = troop;
		_xp = xp;
		_xpGain = xpGain;
		State = state;
		_uniqueNo = ((!uniqueNo.IsValid) ? new UniqueTroopDescriptor(Game.Current.NextUniqueTroopSeed) : uniqueNo);
	}

	public FlattenedTroopRosterElement(FlattenedTroopRosterElement rosterElement, RosterTroopState state)
		: this(rosterElement)
	{
		State = state;
	}

	private FlattenedTroopRosterElement(FlattenedTroopRosterElement rosterElement)
	{
		this = default(FlattenedTroopRosterElement);
		_troop = rosterElement._troop;
		_xp = rosterElement._xp;
		_xpGain = rosterElement._xpGain;
		_uniqueNo = rosterElement._uniqueNo;
		State = rosterElement.State;
	}

	public override string ToString()
	{
		return Troop.ToString();
	}

	bool ISavedStruct.IsDefault()
	{
		if (_troop == null && _xp == 0 && _xpGain == 0 && State == RosterTroopState.Active)
		{
			return _uniqueNo == UniqueTroopDescriptor.Invalid;
		}
		return false;
	}
}
