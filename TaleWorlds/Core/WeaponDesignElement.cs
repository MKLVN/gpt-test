using System.Collections.Generic;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.Core;

public class WeaponDesignElement
{
	[SaveableField(10)]
	private readonly CraftingPiece _craftingPiece;

	[SaveableField(20)]
	private int _scalePercentage;

	public int ScalePercentage => _scalePercentage;

	public float ScaleFactor => (float)_scalePercentage * 0.01f;

	public bool IsPieceScaled => _scalePercentage != 100;

	public CraftingPiece CraftingPiece => _craftingPiece;

	public bool IsValid => CraftingPiece.IsValid;

	public float ScaledLength
	{
		get
		{
			if (!IsPieceScaled)
			{
				return CraftingPiece.Length;
			}
			return CraftingPiece.Length * ScaleFactor;
		}
	}

	public float ScaledWeight
	{
		get
		{
			if (!IsPieceScaled)
			{
				return CraftingPiece.Weight;
			}
			float num = (_craftingPiece.FullScale ? (ScaleFactor * ScaleFactor * ScaleFactor) : ScaleFactor);
			return CraftingPiece.Weight * num;
		}
	}

	public float ScaledCenterOfMass
	{
		get
		{
			if (!IsPieceScaled)
			{
				return CraftingPiece.CenterOfMass;
			}
			return CraftingPiece.CenterOfMass * ScaleFactor;
		}
	}

	public float ScaledDistanceToNextPiece
	{
		get
		{
			if (!IsPieceScaled)
			{
				return CraftingPiece.DistanceToNextPiece;
			}
			return CraftingPiece.DistanceToNextPiece * ScaleFactor;
		}
	}

	public float ScaledDistanceToPreviousPiece
	{
		get
		{
			if (!IsPieceScaled)
			{
				return CraftingPiece.DistanceToPreviousPiece;
			}
			return CraftingPiece.DistanceToPreviousPiece * ScaleFactor;
		}
	}

	public float ScaledBladeLength
	{
		get
		{
			if (!IsPieceScaled)
			{
				return CraftingPiece.BladeData.BladeLength;
			}
			return CraftingPiece.BladeData.BladeLength * ScaleFactor;
		}
	}

	public float ScaledPieceOffset
	{
		get
		{
			if (!IsPieceScaled)
			{
				return CraftingPiece.PieceOffset;
			}
			return CraftingPiece.PieceOffset * ScaleFactor;
		}
	}

	public float ScaledPreviousPieceOffset
	{
		get
		{
			if (!IsPieceScaled)
			{
				return CraftingPiece.PreviousPieceOffset;
			}
			return CraftingPiece.PreviousPieceOffset * ScaleFactor;
		}
	}

	public float ScaledNextPieceOffset
	{
		get
		{
			if (!IsPieceScaled)
			{
				return CraftingPiece.NextPieceOffset;
			}
			return CraftingPiece.NextPieceOffset * ScaleFactor;
		}
	}

	internal static void AutoGeneratedStaticCollectObjectsWeaponDesignElement(object o, List<object> collectedObjects)
	{
		((WeaponDesignElement)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected virtual void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		collectedObjects.Add(_craftingPiece);
	}

	internal static object AutoGeneratedGetMemberValue_craftingPiece(object o)
	{
		return ((WeaponDesignElement)o)._craftingPiece;
	}

	internal static object AutoGeneratedGetMemberValue_scalePercentage(object o)
	{
		return ((WeaponDesignElement)o)._scalePercentage;
	}

	public void SetScale(int scalePercentage)
	{
		_scalePercentage = scalePercentage;
	}

	private WeaponDesignElement(CraftingPiece craftingPiece, int scalePercentage = 100)
	{
		_craftingPiece = craftingPiece;
		_scalePercentage = scalePercentage;
	}

	public WeaponDesignElement GetCopy()
	{
		return new WeaponDesignElement(CraftingPiece, ScalePercentage);
	}

	public static WeaponDesignElement GetInvalidPieceForType(CraftingPiece.PieceTypes pieceType)
	{
		return new WeaponDesignElement(CraftingPiece.GetInvalidCraftingPiece(pieceType));
	}

	public static WeaponDesignElement CreateUsablePiece(CraftingPiece craftingPiece, int scalePercentage = 100)
	{
		return new WeaponDesignElement(craftingPiece, scalePercentage);
	}
}
