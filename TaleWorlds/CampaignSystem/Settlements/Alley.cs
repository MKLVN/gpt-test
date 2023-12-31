using System.Collections.Generic;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.Settlements;

public class Alley : SettlementArea
{
	public enum AreaState
	{
		Empty,
		OccupiedByGangLeader,
		OccupiedByPlayer
	}

	private Settlement _settlement;

	[CachedData]
	private TextObject _name;

	[SaveableField(10)]
	private Hero _owner;

	private string _tag;

	public override Settlement Settlement => _settlement;

	public override TextObject Name => _name;

	public override Hero Owner => _owner;

	public override string Tag => _tag;

	public AreaState State { get; private set; }

	internal static void AutoGeneratedStaticCollectObjectsAlley(object o, List<object> collectedObjects)
	{
		((Alley)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		base.AutoGeneratedInstanceCollectObjects(collectedObjects);
		collectedObjects.Add(_owner);
	}

	internal static object AutoGeneratedGetMemberValue_owner(object o)
	{
		return ((Alley)o)._owner;
	}

	public void SetOwner(Hero newOwner)
	{
		if (_owner != null)
		{
			_owner.OwnedAlleys.Remove(this);
		}
		Hero owner = _owner;
		_owner = newOwner;
		if (_owner != null)
		{
			_owner.OwnedAlleys.Add(this);
			State = ((_owner != Hero.MainHero) ? AreaState.OccupiedByGangLeader : AreaState.OccupiedByPlayer);
		}
		else
		{
			State = AreaState.Empty;
		}
		CampaignEventDispatcher.Instance.OnAlleyOwnerChanged(this, newOwner, owner);
	}

	public Alley(Settlement settlement, string tag, TextObject name)
	{
		Initialize(settlement, tag, name);
	}

	public void Initialize(Settlement settlement, string tag, TextObject name)
	{
		_name = name;
		_settlement = settlement;
		_tag = tag;
	}

	internal void AfterLoad()
	{
		if (_owner != null)
		{
			State = ((_owner != Hero.MainHero) ? AreaState.OccupiedByGangLeader : AreaState.OccupiedByPlayer);
			_owner.OwnedAlleys.Add(this);
			if (MBSaveLoad.LastLoadedGameVersion < ApplicationVersion.FromString("v1.2.0") && !_owner.IsAlive)
			{
				SetOwner(null);
				State = AreaState.Empty;
			}
		}
		else
		{
			State = AreaState.Empty;
		}
	}
}
