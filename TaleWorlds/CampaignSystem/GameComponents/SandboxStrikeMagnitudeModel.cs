using Helpers;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class SandboxStrikeMagnitudeModel : StrikeMagnitudeCalculationModel
{
	public override float CalculateHorseArcheryFactor(BasicCharacterObject characterObject)
	{
		return 100f;
	}

	public override float CalculateStrikeMagnitudeForMissile(BasicCharacterObject attackerCharacter, BasicCharacterObject attackerCaptainCharacter, float missileDamage, float missileSpeed, float missileStartingSpeed, WeaponComponentData currentUsageWeaponComponent)
	{
		float num = missileSpeed;
		float num2 = missileSpeed - missileStartingSpeed;
		if (num2 > 0f)
		{
			ExplainedNumber bonuses = new ExplainedNumber(0f, includeDescriptions: false, null);
			WeaponClass ammoClass = currentUsageWeaponComponent.AmmoClass;
			if (attackerCharacter is CharacterObject characterObject && characterObject.IsHero && (ammoClass == WeaponClass.Stone || ammoClass == WeaponClass.ThrowingAxe || ammoClass == WeaponClass.ThrowingKnife || ammoClass == WeaponClass.Javelin))
			{
				PerkHelper.AddPerkBonusForCharacter(DefaultPerks.Throwing.RunningThrow, characterObject, isPrimaryBonus: true, ref bonuses);
			}
			num += num2 * bonuses.ResultNumber;
		}
		num /= missileStartingSpeed;
		return num * num * missileDamage;
	}

	public override float CalculateStrikeMagnitudeForSwing(BasicCharacterObject attackerCharacter, BasicCharacterObject attackerCaptainCharacter, float swingSpeed, float impactPointAsPercent, float weaponWeight, WeaponComponentData weaponUsageComponent, float weaponLength, float weaponInertia, float weaponCoM, float extraLinearSpeed, bool doesAttackerHaveMount)
	{
		CharacterObject characterObject = attackerCharacter as CharacterObject;
		ExplainedNumber bonuses = new ExplainedNumber(extraLinearSpeed);
		if (characterObject != null && extraLinearSpeed > 0f)
		{
			SkillObject relevantSkill = weaponUsageComponent.RelevantSkill;
			CharacterObject captainCharacter = attackerCaptainCharacter as CharacterObject;
			if (doesAttackerHaveMount)
			{
				PerkHelper.AddPerkBonusFromCaptain(DefaultPerks.Riding.NomadicTraditions, captainCharacter, ref bonuses);
			}
			else
			{
				if (relevantSkill == DefaultSkills.TwoHanded)
				{
					PerkHelper.AddPerkBonusForCharacter(DefaultPerks.TwoHanded.RecklessCharge, characterObject, isPrimaryBonus: true, ref bonuses);
				}
				PerkHelper.AddPerkBonusForCharacter(DefaultPerks.Roguery.DashAndSlash, characterObject, isPrimaryBonus: true, ref bonuses);
				PerkHelper.AddPerkBonusForCharacter(DefaultPerks.Athletics.SurgingBlow, characterObject, isPrimaryBonus: true, ref bonuses);
				PerkHelper.AddPerkBonusFromCaptain(DefaultPerks.Athletics.SurgingBlow, captainCharacter, ref bonuses);
			}
			if (relevantSkill == DefaultSkills.Polearm)
			{
				PerkHelper.AddPerkBonusFromCaptain(DefaultPerks.Polearm.Lancer, captainCharacter, ref bonuses);
				if (doesAttackerHaveMount)
				{
					PerkHelper.AddPerkBonusForCharacter(DefaultPerks.Polearm.Lancer, characterObject, isPrimaryBonus: true, ref bonuses);
					PerkHelper.AddPerkBonusFromCaptain(DefaultPerks.Polearm.UnstoppableForce, captainCharacter, ref bonuses);
				}
			}
		}
		return CombatStatCalculator.CalculateStrikeMagnitudeForSwing(swingSpeed, impactPointAsPercent, weaponWeight, weaponLength, weaponInertia, weaponCoM, bonuses.ResultNumber);
	}

	public override float CalculateStrikeMagnitudeForThrust(BasicCharacterObject attackerCharacter, BasicCharacterObject attackerCaptainCharacter, float thrustWeaponSpeed, float weaponWeight, WeaponComponentData weaponUsageComponent, float extraLinearSpeed, bool doesAttackerHaveMount, bool isThrown = false)
	{
		CharacterObject characterObject = attackerCharacter as CharacterObject;
		ExplainedNumber bonuses = new ExplainedNumber(extraLinearSpeed);
		if (characterObject != null && extraLinearSpeed > 0f)
		{
			SkillObject relevantSkill = weaponUsageComponent.RelevantSkill;
			CharacterObject captainCharacter = attackerCaptainCharacter as CharacterObject;
			if (doesAttackerHaveMount)
			{
				PerkHelper.AddPerkBonusFromCaptain(DefaultPerks.Riding.NomadicTraditions, captainCharacter, ref bonuses);
			}
			else
			{
				if (relevantSkill == DefaultSkills.TwoHanded)
				{
					PerkHelper.AddPerkBonusForCharacter(DefaultPerks.TwoHanded.RecklessCharge, characterObject, isPrimaryBonus: true, ref bonuses);
				}
				PerkHelper.AddPerkBonusForCharacter(DefaultPerks.Roguery.DashAndSlash, characterObject, isPrimaryBonus: true, ref bonuses);
				PerkHelper.AddPerkBonusForCharacter(DefaultPerks.Athletics.SurgingBlow, characterObject, isPrimaryBonus: true, ref bonuses);
				PerkHelper.AddPerkBonusFromCaptain(DefaultPerks.Athletics.SurgingBlow, captainCharacter, ref bonuses);
			}
			if (relevantSkill == DefaultSkills.Polearm)
			{
				PerkHelper.AddPerkBonusFromCaptain(DefaultPerks.Polearm.Lancer, captainCharacter, ref bonuses);
				if (doesAttackerHaveMount)
				{
					PerkHelper.AddPerkBonusForCharacter(DefaultPerks.Polearm.Lancer, characterObject, isPrimaryBonus: true, ref bonuses);
					PerkHelper.AddPerkBonusFromCaptain(DefaultPerks.Polearm.UnstoppableForce, captainCharacter, ref bonuses);
				}
			}
		}
		return CombatStatCalculator.CalculateStrikeMagnitudeForThrust(thrustWeaponSpeed, weaponWeight, bonuses.ResultNumber, isThrown);
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
			Debug.FailedAssert("Given damage type is invalid.", "C:\\Develop\\MB3\\Source\\Bannerlord\\TaleWorlds.CampaignSystem\\GameComponents\\SandboxStrikeMagnitudeModel.cs", "ComputeRawDamage", 174);
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

	public override float CalculateAdjustedArmorForBlow(float baseArmor, BasicCharacterObject attackerCharacter, BasicCharacterObject attackerCaptainCharacter, BasicCharacterObject victimCharacter, BasicCharacterObject victimCaptainCharacter, WeaponComponentData weaponComponent)
	{
		bool flag = false;
		float num = baseArmor;
		CharacterObject characterObject = attackerCharacter as CharacterObject;
		CharacterObject characterObject2 = attackerCaptainCharacter as CharacterObject;
		if (attackerCharacter == characterObject2)
		{
			characterObject2 = null;
		}
		if (num > 0f && characterObject != null)
		{
			if (weaponComponent != null && weaponComponent.RelevantSkill == DefaultSkills.Crossbow && characterObject.GetPerkValue(DefaultPerks.Crossbow.Piercer) && baseArmor < DefaultPerks.Crossbow.Piercer.PrimaryBonus)
			{
				flag = true;
			}
			if (flag)
			{
				num = 0f;
			}
			else
			{
				ExplainedNumber bonuses = new ExplainedNumber(baseArmor);
				PerkHelper.AddPerkBonusForCharacter(DefaultPerks.TwoHanded.Vandal, characterObject, isPrimaryBonus: true, ref bonuses);
				if (weaponComponent != null)
				{
					if (weaponComponent.RelevantSkill == DefaultSkills.OneHanded)
					{
						PerkHelper.AddPerkBonusForCharacter(DefaultPerks.OneHanded.ChinkInTheArmor, characterObject, isPrimaryBonus: true, ref bonuses);
					}
					else if (weaponComponent.RelevantSkill == DefaultSkills.Bow)
					{
						PerkHelper.AddPerkBonusForCharacter(DefaultPerks.Bow.Bodkin, characterObject, isPrimaryBonus: true, ref bonuses);
						if (characterObject2 != null)
						{
							PerkHelper.AddPerkBonusFromCaptain(DefaultPerks.Bow.Bodkin, characterObject2, ref bonuses);
						}
					}
					else if (weaponComponent.RelevantSkill == DefaultSkills.Crossbow)
					{
						PerkHelper.AddPerkBonusForCharacter(DefaultPerks.Crossbow.Puncture, characterObject, isPrimaryBonus: true, ref bonuses);
						if (characterObject2 != null)
						{
							PerkHelper.AddPerkBonusFromCaptain(DefaultPerks.Crossbow.Puncture, characterObject2, ref bonuses);
						}
					}
					else if (weaponComponent.RelevantSkill == DefaultSkills.Throwing)
					{
						PerkHelper.AddPerkBonusForCharacter(DefaultPerks.Throwing.WeakSpot, characterObject, isPrimaryBonus: true, ref bonuses);
						if (characterObject2 != null)
						{
							PerkHelper.AddPerkBonusFromCaptain(DefaultPerks.Throwing.WeakSpot, characterObject2, ref bonuses);
						}
					}
				}
				float num2 = bonuses.ResultNumber - baseArmor;
				num = MathF.Max(0f, baseArmor - num2);
			}
		}
		return num;
	}
}
