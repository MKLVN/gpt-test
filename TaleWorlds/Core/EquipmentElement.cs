using System.Collections.Generic;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.Core;

public struct EquipmentElement : ISerializableObject, ISavedStruct
{
	public static readonly EquipmentElement Invalid = new EquipmentElement(null);

	public ItemObject CosmeticItem;

	[SaveableProperty(1)]
	public ItemObject Item { get; private set; }

	[SaveableProperty(2)]
	public ItemModifier ItemModifier { get; private set; }

	[SaveableProperty(3)]
	public bool IsQuestItem { get; private set; }

	public bool IsEmpty => Item == null;

	public bool IsVisualEmpty
	{
		get
		{
			if (IsEmpty)
			{
				return CosmeticItem == null;
			}
			return false;
		}
	}

	public int ItemValue
	{
		get
		{
			int num = 0;
			if (Item != null)
			{
				num = Item.Value;
				if (ItemModifier != null)
				{
					num = MathF.Round((float)num * ItemModifier.PriceMultiplier);
				}
			}
			return num;
		}
	}

	public float Weight
	{
		get
		{
			float weight = Item.Weight;
			if (!(weight > 0f))
			{
				return 0f;
			}
			return weight;
		}
	}

	public static void AutoGeneratedStaticCollectObjectsEquipmentElement(object o, List<object> collectedObjects)
	{
		((EquipmentElement)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	private void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		collectedObjects.Add(Item);
		collectedObjects.Add(ItemModifier);
	}

	internal static object AutoGeneratedGetMemberValueItem(object o)
	{
		return ((EquipmentElement)o).Item;
	}

	internal static object AutoGeneratedGetMemberValueItemModifier(object o)
	{
		return ((EquipmentElement)o).ItemModifier;
	}

	internal static object AutoGeneratedGetMemberValueIsQuestItem(object o)
	{
		return ((EquipmentElement)o).IsQuestItem;
	}

	public EquipmentElement(ItemObject item, ItemModifier itemModifier = null, ItemObject cosmeticItem = null, bool isQuestItem = false)
	{
		Item = item;
		ItemModifier = itemModifier;
		CosmeticItem = cosmeticItem;
		IsQuestItem = isQuestItem;
	}

	public EquipmentElement(EquipmentElement other)
		: this(other.Item, other.ItemModifier, other.CosmeticItem)
	{
	}

	public void SetModifier(ItemModifier itemModifier)
	{
		ItemModifier = itemModifier;
	}

	public void Clear()
	{
		Item = null;
		ItemModifier = null;
	}

	public override int GetHashCode()
	{
		int num = 0;
		if (Item != null)
		{
			num += Item.GetHashCode();
		}
		if (ItemModifier != null)
		{
			num += ItemModifier.GetHashCode() * 317;
		}
		return num;
	}

	public override string ToString()
	{
		return Item.ToString() ?? "";
	}

	public int GetModifiedHeadArmor()
	{
		int num = 0;
		if (Item.HasArmorComponent)
		{
			num = Item.ArmorComponent.HeadArmor;
		}
		if (num > 0 && ItemModifier != null)
		{
			num = ItemModifier.ModifyArmor(num);
		}
		if (num <= 0)
		{
			return 0;
		}
		return num;
	}

	public int GetModifiedBodyArmor()
	{
		int num = 0;
		if (Item.HasArmorComponent)
		{
			ArmorComponent armorComponent = Item.ArmorComponent;
			num = ((Item.ItemType != ItemObject.ItemTypeEnum.HorseHarness) ? armorComponent.BodyArmor : 0);
		}
		else if (Item.WeaponComponent != null)
		{
			num = Item.WeaponComponent.PrimaryWeapon.BodyArmor;
		}
		if (num > 0 && ItemModifier != null)
		{
			num = ItemModifier.ModifyArmor(num);
		}
		if (num <= 0)
		{
			return 0;
		}
		return num;
	}

	public int GetModifiedMountBodyArmor()
	{
		int num = 0;
		if (Item.HasArmorComponent)
		{
			ArmorComponent armorComponent = Item.ArmorComponent;
			num = ((Item.ItemType == ItemObject.ItemTypeEnum.HorseHarness) ? armorComponent.BodyArmor : 0);
		}
		else if (Item.WeaponComponent != null)
		{
			num = Item.WeaponComponent.PrimaryWeapon.BodyArmor;
		}
		if (num > 0 && ItemModifier != null)
		{
			num = ItemModifier.ModifyArmor(num);
		}
		if (num <= 0)
		{
			return 0;
		}
		return num;
	}

	public int GetModifiedLegArmor()
	{
		int num = 0;
		if (Item.HasArmorComponent)
		{
			num = Item.ArmorComponent.LegArmor;
		}
		if (num > 0 && ItemModifier != null)
		{
			num = ItemModifier.ModifyArmor(num);
		}
		if (num <= 0)
		{
			return 0;
		}
		return num;
	}

	public int GetModifiedArmArmor()
	{
		int num = 0;
		if (Item.HasArmorComponent)
		{
			num = Item.ArmorComponent.ArmArmor;
		}
		if (num > 0 && ItemModifier != null)
		{
			num = ItemModifier.ModifyArmor(num);
		}
		if (num <= 0)
		{
			return 0;
		}
		return num;
	}

	public short GetModifiedMaximumHitPointsForUsage(int usageIndex)
	{
		return Item.GetWeaponWithUsageIndex(usageIndex).GetModifiedMaximumHitPoints(ItemModifier);
	}

	public TextObject GetModifiedItemName()
	{
		if (ItemModifier == null || Item.IsCraftedByPlayer)
		{
			return Item.Name;
		}
		HorseComponent horseComponent = Item.HorseComponent;
		TextObject textObject;
		if (!TextObject.IsNullOrEmpty(horseComponent?.ModifiedName) && ItemModifier == null)
		{
			textObject = horseComponent.ModifiedName;
		}
		else
		{
			textObject = ItemModifier.Name;
			textObject.SetTextVariable("ITEMNAME", Item.Name);
		}
		return textObject;
	}

	public int GetModifiedThrustDamageForUsage(int usageIndex)
	{
		return Item.GetWeaponWithUsageIndex(usageIndex).GetModifiedThrustDamage(ItemModifier);
	}

	public int GetModifiedSwingDamageForUsage(int usageIndex)
	{
		return Item.GetWeaponWithUsageIndex(usageIndex).GetModifiedSwingDamage(ItemModifier);
	}

	public int GetModifiedMissileDamageForUsage(int usageIndex)
	{
		return Item.GetWeaponWithUsageIndex(usageIndex).GetModifiedMissileDamage(ItemModifier);
	}

	public int GetModifiedThrustSpeedForUsage(int usageIndex)
	{
		return Item.GetWeaponWithUsageIndex(usageIndex).GetModifiedThrustSpeed(ItemModifier);
	}

	public int GetModifiedSwingSpeedForUsage(int usageIndex)
	{
		return Item.GetWeaponWithUsageIndex(usageIndex).GetModifiedSwingSpeed(ItemModifier);
	}

	public int GetModifiedMissileSpeedForUsage(int usageIndex)
	{
		return Item.GetWeaponWithUsageIndex(usageIndex).GetModifiedMissileSpeed(ItemModifier);
	}

	public int GetModifiedHandlingForUsage(int usageIndex)
	{
		return Item.GetWeaponWithUsageIndex(usageIndex).GetModifiedHandling(ItemModifier);
	}

	public short GetModifiedStackCountForUsage(int usageIndex)
	{
		return Item.GetWeaponWithUsageIndex(usageIndex).GetModifiedStackCount(ItemModifier);
	}

	public int GetBaseValue()
	{
		int num = Item.Value;
		if (ItemModifier != null)
		{
			num = (int)((float)num * ItemModifier.PriceMultiplier);
		}
		return num;
	}

	public bool IsEqualTo(EquipmentElement other)
	{
		if (Item == other.Item)
		{
			return ItemModifier == other.ItemModifier;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is EquipmentElement other))
		{
			return false;
		}
		return IsEqualTo(other);
	}

	public bool Equals(ItemRosterElement other)
	{
		if (Item == other.EquipmentElement.Item)
		{
			return ItemModifier == other.EquipmentElement.ItemModifier;
		}
		return false;
	}

	public float GetEquipmentElementWeight()
	{
		if (Item != null)
		{
			if (Item.PrimaryWeapon == null || !Item.PrimaryWeapon.IsConsumable)
			{
				return Weight;
			}
			return Weight * (float)GetModifiedStackCountForUsage(0);
		}
		return 0f;
	}

	public bool IsInvalid()
	{
		if (Item == Invalid.Item)
		{
			return ItemModifier == Invalid.ItemModifier;
		}
		return false;
	}

	public int GetModifiedMountManeuver(in EquipmentElement harness)
	{
		if (Item == null)
		{
			return 0;
		}
		HorseComponent horseComponent = Item.HorseComponent;
		ArmorComponent obj = harness.Item?.ArmorComponent;
		int num = horseComponent.Maneuver + (obj?.ManeuverBonus ?? 0);
		if (ItemModifier != null)
		{
			num = ItemModifier.ModifyMountManeuver(num);
		}
		if (!harness.IsEmpty && harness.ItemModifier != null)
		{
			num = harness.ItemModifier.ModifyMountManeuver(num);
		}
		return num;
	}

	public int GetModifiedMountSpeed(in EquipmentElement harness)
	{
		if (Item == null)
		{
			return 0;
		}
		HorseComponent horseComponent = Item.HorseComponent;
		ArmorComponent obj = harness.Item?.ArmorComponent;
		int num = horseComponent.Speed + (obj?.SpeedBonus ?? 0);
		if (ItemModifier != null)
		{
			num = ItemModifier.ModifyMountSpeed(num);
		}
		if (!harness.IsEmpty && harness.ItemModifier != null)
		{
			num = harness.ItemModifier.ModifyMountSpeed(num);
		}
		return num;
	}

	public int GetModifiedMountCharge(in EquipmentElement harness)
	{
		if (Item == null)
		{
			return 0;
		}
		HorseComponent horseComponent = Item.HorseComponent;
		ArmorComponent obj = harness.Item?.ArmorComponent;
		int num = horseComponent.ChargeDamage + (obj?.ChargeBonus ?? 0);
		if (ItemModifier != null)
		{
			num = ItemModifier.ModifyMountCharge(num);
		}
		if (!harness.IsEmpty && harness.ItemModifier != null)
		{
			num = harness.ItemModifier.ModifyMountCharge(num);
		}
		return num;
	}

	public int GetModifiedMountHitPoints()
	{
		if (Item == null)
		{
			return 0;
		}
		HorseComponent horseComponent = Item.HorseComponent;
		int num = horseComponent.HitPoints + horseComponent.HitPointBonus;
		if (ItemModifier != null)
		{
			num = ItemModifier.ModifyMountHitPoints(num);
		}
		if (num <= 0)
		{
			return 0;
		}
		return num;
	}

	void ISerializableObject.DeserializeFrom(IReader reader)
	{
		string text = reader.ReadString();
		ItemModifier = null;
		if (text != "")
		{
			ItemModifier = Game.Current.ObjectManager.GetObject<ItemModifier>(text);
		}
		MBGUID objectId = new MBGUID(reader.ReadUInt());
		Item = MBObjectManager.Instance.GetObject(objectId) as ItemObject;
	}

	void ISerializableObject.SerializeTo(IWriter writer)
	{
		writer.WriteString((ItemModifier != null) ? ItemModifier.StringId : "");
		writer.WriteUInt(Item?.Id.InternalValue ?? 0);
	}

	bool ISavedStruct.IsDefault()
	{
		if (Item == null)
		{
			return ItemModifier == null;
		}
		return false;
	}
}
