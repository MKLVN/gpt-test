using TaleWorlds.Library;

namespace TaleWorlds.Core;

public class DefaultStrikeMagnitudeModel : StrikeMagnitudeCalculationModel
{
	public override float CalculateStrikeMagnitudeForMissile(BasicCharacterObject attackerCharacter, BasicCharacterObject attackerCaptainCharacter, float missileDamage, float missileSpeed, float missileStartingSpeed, WeaponComponentData currentUsageWeaponComponent)
	{
		float num = missileSpeed / missileStartingSpeed;
		return num * num * missileDamage;
	}

	public override float CalculateStrikeMagnitudeForSwing(BasicCharacterObject attackerCharacter, BasicCharacterObject attackerCaptainCharacter, float swingSpeed, float impactPointAsPercent, float weaponWeight, WeaponComponentData weaponUsageComponent, float weaponLength, float weaponInertia, float weaponCoM, float extraLinearSpeed, bool doesAttackerHaveMount)
	{
		return CombatStatCalculator.CalculateStrikeMagnitudeForSwing(swingSpeed, impactPointAsPercent, weaponWeight, weaponLength, weaponInertia, weaponCoM, extraLinearSpeed);
	}

	public override float CalculateStrikeMagnitudeForThrust(BasicCharacterObject attackerCharacter, BasicCharacterObject attackerCaptainCharacter, float thrustWeaponSpeed, float weaponWeight, WeaponComponentData weaponUsageComponent, float extraLinearSpeed, bool doesAttackerHaveMount, bool isThrown = false)
	{
		return CombatStatCalculator.CalculateStrikeMagnitudeForThrust(thrustWeaponSpeed, weaponWeight, extraLinearSpeed, isThrown);
	}

	public override float ComputeRawDamage(DamageTypes damageType, float magnitude, float armorEffectiveness, float absorbedDamageRatio)
	{
		float bluntDamageFactorByDamageType = GetBluntDamageFactorByDamageType(damageType);
		float num = 50f / (50f + armorEffectiveness);
		float num2 = magnitude * num;
		float num3 = bluntDamageFactorByDamageType * num2;
		float num4;
		switch (damageType)
		{
		case DamageTypes.Cut:
			num4 = MathF.Max(0f, num2 - armorEffectiveness * 0.5f);
			break;
		case DamageTypes.Pierce:
			num4 = MathF.Max(0f, num2 - armorEffectiveness * 0.33f);
			break;
		case DamageTypes.Blunt:
			num4 = MathF.Max(0f, num2 - armorEffectiveness * 0.2f);
			break;
		default:
			Debug.FailedAssert("Given damage type is invalid.", "C:\\Develop\\MB3\\Source\\Bannerlord\\TaleWorlds.Core\\DefaultStrikeMagnitudeModel.cs", "ComputeRawDamage", 59);
			return 0f;
		}
		num3 += (1f - bluntDamageFactorByDamageType) * num4;
		return num3 * absorbedDamageRatio;
	}

	public override float GetBluntDamageFactorByDamageType(DamageTypes damageType)
	{
		float result = 0f;
		switch (damageType)
		{
		case DamageTypes.Blunt:
			result = 0.6f;
			break;
		case DamageTypes.Cut:
			result = 0.1f;
			break;
		case DamageTypes.Pierce:
			result = 0.25f;
			break;
		}
		return result;
	}

	public override float CalculateHorseArcheryFactor(BasicCharacterObject characterObject)
	{
		return 100f;
	}
}
