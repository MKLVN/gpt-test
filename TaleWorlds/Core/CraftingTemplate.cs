using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace TaleWorlds.Core;

public class CraftingTemplate : MBObjectBase
{
	public enum CraftingStatTypes
	{
		Weight,
		WeaponReach,
		ThrustSpeed,
		SwingSpeed,
		ThrustDamage,
		SwingDamage,
		Handling,
		MissileDamage,
		MissileSpeed,
		Accuracy,
		StackAmount,
		NumStatTypes
	}

	public TextObject TemplateName;

	private bool[] _hiddenPieceTypesOnHolsteredMesh;

	private float[][] _statDataValues;

	public PieceData[] BuildOrders { get; private set; }

	public WeaponDescription[] WeaponDescriptions { get; private set; }

	public List<CraftingPiece> Pieces { get; private set; }

	public ItemObject.ItemTypeEnum ItemType { get; private set; }

	public ItemModifierGroup ItemModifierGroup { get; private set; }

	public string[] ItemHolsters { get; private set; }

	public Vec3 ItemHolsterPositionShift { get; private set; }

	public bool UseWeaponAsHolsterMesh { get; private set; }

	public bool AlwaysShowHolsterWithWeapon { get; private set; }

	public bool RotateWeaponInHolster { get; private set; }

	public CraftingPiece.PieceTypes PieceTypeToScaleHolsterWith { get; private set; }

	public static MBReadOnlyList<CraftingTemplate> All => MBObjectManager.Instance.GetObjectTypeList<CraftingTemplate>();

	internal static void AutoGeneratedStaticCollectObjectsCraftingTemplate(object o, List<object> collectedObjects)
	{
		((CraftingTemplate)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected override void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		base.AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	public int GetIndexOfUsageDataWithId(string weaponDescriptionId)
	{
		int result = -1;
		for (int i = 0; i < WeaponDescriptions.Length; i++)
		{
			if (weaponDescriptionId == WeaponDescriptions[i].StringId)
			{
				result = i;
				break;
			}
		}
		return result;
	}

	public bool IsPieceTypeHiddenOnHolster(CraftingPiece.PieceTypes pieceType)
	{
		return _hiddenPieceTypesOnHolsteredMesh[(int)pieceType];
	}

	public IEnumerable<KeyValuePair<CraftingStatTypes, float>> GetStatDatas(int usageIndex, DamageTypes thrustDamageType, DamageTypes swingDamageType)
	{
		for (int i = 0; i < _statDataValues[usageIndex].Length; i++)
		{
			CraftingStatTypes craftingStatTypes = (CraftingStatTypes)i;
			bool flag = false;
			switch (craftingStatTypes)
			{
			case CraftingStatTypes.ThrustSpeed:
			case CraftingStatTypes.ThrustDamage:
				flag = thrustDamageType == DamageTypes.Invalid;
				break;
			case CraftingStatTypes.SwingSpeed:
			case CraftingStatTypes.SwingDamage:
				flag = swingDamageType == DamageTypes.Invalid;
				break;
			}
			if (!flag && _statDataValues[usageIndex][i] >= 0f)
			{
				yield return new KeyValuePair<CraftingStatTypes, float>(craftingStatTypes, _statDataValues[usageIndex][i]);
			}
		}
	}

	public override string ToString()
	{
		return TemplateName.ToString();
	}

	public bool IsPieceTypeUsable(CraftingPiece.PieceTypes pieceType)
	{
		return BuildOrders.Any((PieceData bO) => bO.PieceType == pieceType);
	}

	public override void Deserialize(MBObjectManager objectManager, XmlNode node)
	{
		base.Deserialize(objectManager, node);
		_hiddenPieceTypesOnHolsteredMesh = new bool[4];
		string text = node.Attributes["modifier_group"]?.Value;
		if (text != null)
		{
			ItemModifierGroup = Game.Current.ObjectManager.GetObject<ItemModifierGroup>(text);
		}
		ItemType = (ItemObject.ItemTypeEnum)Enum.Parse(typeof(ItemObject.ItemTypeEnum), node.Attributes["item_type"].Value);
		ItemHolsters = node.Attributes["item_holsters"].Value.Split(new char[1] { ':' });
		ItemHolsterPositionShift = Vec3.Parse(node.Attributes["default_item_holster_position_offset"].Value);
		UseWeaponAsHolsterMesh = XmlHelper.ReadBool(node, "use_weapon_as_holster_mesh");
		AlwaysShowHolsterWithWeapon = XmlHelper.ReadBool(node, "always_show_holster_with_weapon");
		RotateWeaponInHolster = XmlHelper.ReadBool(node, "rotate_weapon_in_holster");
		XmlAttribute xmlAttribute = node.Attributes["piece_type_to_scale_holster_with"];
		PieceTypeToScaleHolsterWith = ((xmlAttribute != null) ? ((CraftingPiece.PieceTypes)Enum.Parse(typeof(CraftingPiece.PieceTypes), xmlAttribute.Value)) : CraftingPiece.PieceTypes.Invalid);
		XmlAttribute xmlAttribute2 = node.Attributes["hidden_piece_types_on_holster"];
		if (xmlAttribute2 != null)
		{
			string[] array = xmlAttribute2.Value.Split(new char[1] { ':' });
			foreach (string value in array)
			{
				CraftingPiece.PieceTypes pieceTypes = (CraftingPiece.PieceTypes)Enum.Parse(typeof(CraftingPiece.PieceTypes), value);
				_hiddenPieceTypesOnHolsteredMesh[(int)pieceTypes] = true;
			}
		}
		foreach (XmlNode childNode in node.ChildNodes)
		{
			if (childNode.Attributes == null)
			{
				continue;
			}
			switch (childNode.Name)
			{
			case "PieceDatas":
			{
				List<PieceData> list2 = new List<PieceData>();
				foreach (XmlNode childNode2 in childNode.ChildNodes)
				{
					XmlAttribute xmlAttribute6 = childNode2.Attributes["piece_type"];
					XmlAttribute xmlAttribute7 = childNode2.Attributes["build_order"];
					CraftingPiece.PieceTypes pieceType = (CraftingPiece.PieceTypes)Enum.Parse(typeof(CraftingPiece.PieceTypes), xmlAttribute6.Value);
					int order = int.Parse(xmlAttribute7.Value);
					list2.Add(new PieceData(pieceType, order));
				}
				BuildOrders = list2.ToArray();
				break;
			}
			case "WeaponDescriptions":
			{
				List<WeaponDescription> list = new List<WeaponDescription>();
				foreach (XmlNode childNode3 in childNode.ChildNodes)
				{
					string value3 = childNode3.Attributes["id"].Value;
					WeaponDescription object2 = MBObjectManager.Instance.GetObject<WeaponDescription>(value3);
					if (object2 != null)
					{
						list.Add(object2);
					}
				}
				WeaponDescriptions = list.ToArray();
				_statDataValues = new float[WeaponDescriptions.Length][];
				break;
			}
			case "UsablePieces":
				Pieces = new List<CraftingPiece>();
				foreach (XmlNode childNode4 in childNode.ChildNodes)
				{
					string value2 = childNode4.Attributes["piece_id"].Value;
					CraftingPiece @object = MBObjectManager.Instance.GetObject<CraftingPiece>(value2);
					if (@object != null)
					{
						Pieces.Add(@object);
					}
				}
				break;
			case "StatsData":
			{
				XmlAttribute xmlAttribute3 = childNode.Attributes["weapon_description"];
				float[] array2 = new float[11];
				for (int j = 0; j < array2.Length; j++)
				{
					array2[j] = float.MinValue;
				}
				foreach (XmlNode childNode5 in childNode.ChildNodes)
				{
					if (childNode5.NodeType == XmlNodeType.Element)
					{
						XmlAttribute xmlAttribute4 = childNode5.Attributes["stat_type"];
						XmlAttribute xmlAttribute5 = childNode5.Attributes["max_value"];
						CraftingStatTypes craftingStatTypes = (CraftingStatTypes)Enum.Parse(typeof(CraftingStatTypes), xmlAttribute4.Value);
						float num = float.Parse(xmlAttribute5.Value);
						array2[(int)craftingStatTypes] = num;
					}
				}
				if (xmlAttribute3 != null)
				{
					int indexOfUsageDataWithId = GetIndexOfUsageDataWithId(xmlAttribute3.Value);
					_statDataValues[indexOfUsageDataWithId] = array2;
					break;
				}
				for (int k = 0; k < _statDataValues.Length; k++)
				{
					_statDataValues[k] = array2;
				}
				break;
			}
			}
		}
		TemplateName = GameTexts.FindText("str_crafting_template", base.StringId);
	}

	public static CraftingTemplate GetTemplateFromId(string templateId)
	{
		return MBObjectManager.Instance.GetObject<CraftingTemplate>(templateId);
	}
}