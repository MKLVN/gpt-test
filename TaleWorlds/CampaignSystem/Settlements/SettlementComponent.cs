using System.Collections.Generic;
using System.Xml;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.Settlements;

public abstract class SettlementComponent : MBObjectBase
{
	public enum ProsperityLevel
	{
		Low,
		Mid,
		High,
		NumberOfLevels
	}

	private PartyBase _owner;

	[SaveableProperty(50)]
	public int Gold { get; private set; }

	public float BackgroundCropPosition { get; protected set; }

	public string BackgroundMeshName { get; protected set; }

	public string WaitMeshName { get; protected set; }

	public string CastleBackgroundMeshName { get; protected set; }

	public PartyBase Owner
	{
		get
		{
			return _owner;
		}
		internal set
		{
			if (_owner != value)
			{
				if (_owner != null)
				{
					_owner.ItemRoster.RosterUpdatedEvent -= OnInventoryUpdated;
				}
				_owner = value;
				if (_owner != null)
				{
					_owner.ItemRoster.RosterUpdatedEvent += OnInventoryUpdated;
				}
			}
		}
	}

	public Settlement Settlement => _owner.Settlement;

	public TextObject Name => Owner.Name;

	[SaveableProperty(80)]
	public bool IsOwnerUnassigned { get; set; }

	public virtual bool IsTown => false;

	public virtual bool IsCastle => false;

	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		base.AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	internal static object AutoGeneratedGetMemberValueGold(object o)
	{
		return ((SettlementComponent)o).Gold;
	}

	internal static object AutoGeneratedGetMemberValueIsOwnerUnassigned(object o)
	{
		return ((SettlementComponent)o).IsOwnerUnassigned;
	}

	public virtual ProsperityLevel GetProsperityLevel()
	{
		return ProsperityLevel.Mid;
	}

	protected abstract void OnInventoryUpdated(ItemRosterElement item, int count);

	public virtual void OnPartyEntered(MobileParty mobileParty)
	{
	}

	public virtual void OnPartyLeft(MobileParty mobileParty)
	{
	}

	public virtual void OnInit()
	{
	}

	public void ChangeGold(int changeAmount)
	{
		Gold += changeAmount;
		if (Gold < 0)
		{
			Gold = 0;
		}
	}

	public int GetNumberOfTroops()
	{
		int num = 0;
		foreach (MobileParty party in Owner.Settlement.Parties)
		{
			if (party.IsMilitia || party.IsGarrison)
			{
				num += party.Party.NumberOfAllMembers;
			}
		}
		return num;
	}

	public override void Deserialize(MBObjectManager objectManager, XmlNode node)
	{
		base.Deserialize(objectManager, node);
	}

	public virtual int GetItemPrice(ItemObject item, MobileParty tradingParty = null, bool isSelling = false)
	{
		return 0;
	}

	public virtual int GetItemPrice(EquipmentElement itemRosterElement, MobileParty tradingParty = null, bool isSelling = false)
	{
		return 0;
	}

	public virtual void OnRelatedPartyRemoved(MobileParty mobileParty)
	{
	}

	public List<CharacterObject> GetPrisonerHeroes()
	{
		List<PartyBase> list = new List<PartyBase> { Owner };
		foreach (MobileParty party in Owner.Settlement.Parties)
		{
			if (party.IsGarrison)
			{
				list.Add(party.Party);
			}
		}
		List<CharacterObject> list2 = new List<CharacterObject>();
		foreach (PartyBase item in list)
		{
			for (int i = 0; i < item.PrisonRoster.Count; i++)
			{
				for (int j = 0; j < item.PrisonRoster.GetElementNumber(i); j++)
				{
					CharacterObject character = item.PrisonRoster.GetElementCopyAtIndex(i).Character;
					if (character.IsHero)
					{
						list2.Add(character);
					}
				}
			}
		}
		return list2;
	}
}
