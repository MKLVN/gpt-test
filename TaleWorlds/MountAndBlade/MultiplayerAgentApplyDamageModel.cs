using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.ComponentInterfaces;

namespace TaleWorlds.MountAndBlade;

public class MultiplayerAgentApplyDamageModel : AgentApplyDamageModel
{
	public override float CalculateDamage(in AttackInformation attackInformation, in AttackCollisionData collisionData, in MissionWeapon weapon, float baseDamage)
	{
		return baseDamage;
	}

	public override void DecideMissileWeaponFlags(Agent attackerAgent, MissionWeapon missileWeapon, ref WeaponFlags missileWeaponFlags)
	{
	}

	public override bool DecideCrushedThrough(Agent attackerAgent, Agent defenderAgent, float totalAttackEnergy, Agent.UsageDirection attackDirection, StrikeType strikeType, WeaponComponentData defendItem, bool isPassiveUsage)
	{
		EquipmentIndex wieldedItemIndex = attackerAgent.GetWieldedItemIndex(Agent.HandIndex.OffHand);
		if (wieldedItemIndex == EquipmentIndex.None)
		{
			wieldedItemIndex = attackerAgent.GetWieldedItemIndex(Agent.HandIndex.MainHand);
		}
		WeaponComponentData weaponComponentData = ((wieldedItemIndex != EquipmentIndex.None) ? attackerAgent.Equipment[wieldedItemIndex].CurrentUsageItem : null);
		if (weaponComponentData == null || isPassiveUsage || !weaponComponentData.WeaponFlags.HasAnyFlag(WeaponFlags.CanCrushThrough) || strikeType != 0 || attackDirection != 0)
		{
			return false;
		}
		float num = 58f;
		if (defendItem != null && defendItem.IsShield)
		{
			num *= 1.2f;
		}
		return totalAttackEnergy > num;
	}

	public override bool CanWeaponDismount(Agent attackerAgent, WeaponComponentData attackerWeapon, in Blow blow, in AttackCollisionData collisionData)
	{
		if (!MBMath.IsBetween((int)blow.VictimBodyPart, 0, 6))
		{
			return false;
		}
		if (!attackerAgent.HasMount && blow.StrikeType == StrikeType.Swing && blow.WeaponRecord.WeaponFlags.HasAnyFlag(WeaponFlags.CanHook))
		{
			return true;
		}
		if (blow.StrikeType == StrikeType.Thrust)
		{
			return blow.WeaponRecord.WeaponFlags.HasAnyFlag(WeaponFlags.CanDismount);
		}
		return false;
	}

	public override void CalculateCollisionStunMultipliers(Agent attackerAgent, Agent defenderAgent, bool isAlternativeAttack, CombatCollisionResult collisionResult, WeaponComponentData attackerWeapon, WeaponComponentData defenderWeapon, out float attackerStunMultiplier, out float defenderStunMultiplier)
	{
		attackerStunMultiplier = 1f;
		defenderStunMultiplier = 1f;
	}

	public override bool CanWeaponKnockback(Agent attackerAgent, WeaponComponentData attackerWeapon, in Blow blow, in AttackCollisionData collisionData)
	{
		if (MBMath.IsBetween((int)collisionData.VictimHitBodyPart, 0, 6) && !attackerWeapon.WeaponFlags.HasAnyFlag(WeaponFlags.CanKnockDown))
		{
			if (!attackerWeapon.IsConsumable && (blow.BlowFlag & BlowFlags.CrushThrough) == 0)
			{
				if (blow.StrikeType == StrikeType.Thrust)
				{
					return blow.WeaponRecord.WeaponFlags.HasAnyFlag(WeaponFlags.WideGrip);
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public override bool CanWeaponKnockDown(Agent attackerAgent, Agent victimAgent, WeaponComponentData attackerWeapon, in Blow blow, in AttackCollisionData collisionData)
	{
		if (attackerWeapon.WeaponClass == WeaponClass.Boulder)
		{
			return true;
		}
		BoneBodyPartType victimHitBodyPart = collisionData.VictimHitBodyPart;
		bool flag = MBMath.IsBetween((int)victimHitBodyPart, 0, 6);
		if (!victimAgent.HasMount && victimHitBodyPart == BoneBodyPartType.Legs)
		{
			flag = true;
		}
		if (flag && blow.WeaponRecord.WeaponFlags.HasAnyFlag(WeaponFlags.CanKnockDown))
		{
			if (!attackerWeapon.IsPolearm || blow.StrikeType != StrikeType.Thrust)
			{
				if (attackerWeapon.IsMeleeWeapon && blow.StrikeType == StrikeType.Swing)
				{
					return MissionCombatMechanicsHelper.DecideSweetSpotCollision(in collisionData);
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public override float GetDismountPenetration(Agent attackerAgent, WeaponComponentData attackerWeapon, in Blow blow, in AttackCollisionData attackCollisionData)
	{
		float num = 0f;
		if (blow.StrikeType == StrikeType.Swing && blow.WeaponRecord.WeaponFlags.HasAnyFlag(WeaponFlags.CanHook))
		{
			num += 0.25f;
		}
		return num;
	}

	public override float GetKnockBackPenetration(Agent attackerAgent, WeaponComponentData attackerWeapon, in Blow blow, in AttackCollisionData attackCollisionData)
	{
		return 0f;
	}

	public override float GetKnockDownPenetration(Agent attackerAgent, WeaponComponentData attackerWeapon, in Blow blow, in AttackCollisionData attackCollisionData)
	{
		float num = 0f;
		if (attackerWeapon.WeaponClass == WeaponClass.Boulder)
		{
			num += 0.25f;
		}
		else if (attackerWeapon.IsMeleeWeapon)
		{
			if (attackCollisionData.VictimHitBodyPart == BoneBodyPartType.Legs && blow.StrikeType == StrikeType.Swing)
			{
				num += 0.1f;
			}
			else if (attackCollisionData.VictimHitBodyPart == BoneBodyPartType.Head)
			{
				num += 0.15f;
			}
		}
		return num;
	}

	public override float GetHorseChargePenetration()
	{
		return 0.37f;
	}

	public override float CalculateStaggerThresholdMultiplier(Agent defenderAgent)
	{
		return 1f;
	}

	public override float CalculatePassiveAttackDamage(BasicCharacterObject attackerCharacter, in AttackCollisionData collisionData, float baseDamage)
	{
		return baseDamage;
	}

	public override MeleeCollisionReaction DecidePassiveAttackCollisionReaction(Agent attacker, Agent defender, bool isFatalHit)
	{
		return MeleeCollisionReaction.Bounced;
	}

	public override float CalculateShieldDamage(in AttackInformation attackInformation, float baseDamage)
	{
		baseDamage *= 1.25f;
		MissionMultiplayerFlagDomination missionBehavior = Mission.Current.GetMissionBehavior<MissionMultiplayerFlagDomination>();
		if (missionBehavior != null && missionBehavior.GetMissionType() == MultiplayerGameType.Captain)
		{
			return baseDamage * 0.5f;
		}
		return baseDamage;
	}

	public override float GetDamageMultiplierForBodyPart(BoneBodyPartType bodyPart, DamageTypes type, bool isHuman)
	{
		float result = 1f;
		switch (bodyPart)
		{
		case BoneBodyPartType.None:
			result = 1f;
			break;
		case BoneBodyPartType.Head:
			switch (type)
			{
			case DamageTypes.Invalid:
				result = 2f;
				break;
			case DamageTypes.Cut:
				result = 1.2f;
				break;
			case DamageTypes.Pierce:
				result = ((!isHuman) ? 1.2f : 2f);
				break;
			case DamageTypes.Blunt:
				result = 1.2f;
				break;
			}
			break;
		case BoneBodyPartType.Neck:
			switch (type)
			{
			case DamageTypes.Invalid:
				result = 2f;
				break;
			case DamageTypes.Cut:
				result = 1.2f;
				break;
			case DamageTypes.Pierce:
				result = ((!isHuman) ? 1.2f : 2f);
				break;
			case DamageTypes.Blunt:
				result = 1.2f;
				break;
			}
			break;
		case BoneBodyPartType.Chest:
		case BoneBodyPartType.Abdomen:
		case BoneBodyPartType.ShoulderLeft:
		case BoneBodyPartType.ShoulderRight:
		case BoneBodyPartType.ArmLeft:
		case BoneBodyPartType.ArmRight:
			result = ((!isHuman) ? 0.8f : 1f);
			break;
		case BoneBodyPartType.Legs:
			result = 0.8f;
			break;
		}
		return result;
	}

	public override bool CanWeaponIgnoreFriendlyFireChecks(WeaponComponentData weapon)
	{
		if (weapon != null && weapon.IsConsumable && weapon.WeaponFlags.HasAnyFlag(WeaponFlags.CanPenetrateShield) && weapon.WeaponFlags.HasAnyFlag(WeaponFlags.MultiplePenetration))
		{
			return true;
		}
		return false;
	}

	public override bool DecideAgentShrugOffBlow(Agent victimAgent, AttackCollisionData collisionData, in Blow blow)
	{
		return MissionCombatMechanicsHelper.DecideAgentShrugOffBlow(victimAgent, collisionData, in blow);
	}

	public override bool DecideAgentDismountedByBlow(Agent attackerAgent, Agent victimAgent, in AttackCollisionData collisionData, WeaponComponentData attackerWeapon, in Blow blow)
	{
		return MissionCombatMechanicsHelper.DecideAgentDismountedByBlow(attackerAgent, victimAgent, in collisionData, attackerWeapon, in blow);
	}

	public override bool DecideAgentKnockedBackByBlow(Agent attackerAgent, Agent victimAgent, in AttackCollisionData collisionData, WeaponComponentData attackerWeapon, in Blow blow)
	{
		return MissionCombatMechanicsHelper.DecideAgentKnockedBackByBlow(attackerAgent, victimAgent, in collisionData, attackerWeapon, in blow);
	}

	public override bool DecideAgentKnockedDownByBlow(Agent attackerAgent, Agent victimAgent, in AttackCollisionData collisionData, WeaponComponentData attackerWeapon, in Blow blow)
	{
		return MissionCombatMechanicsHelper.DecideAgentKnockedDownByBlow(attackerAgent, victimAgent, in collisionData, attackerWeapon, in blow);
	}

	public override bool DecideMountRearedByBlow(Agent attackerAgent, Agent victimAgent, in AttackCollisionData collisionData, WeaponComponentData attackerWeapon, in Blow blow)
	{
		return MissionCombatMechanicsHelper.DecideMountRearedByBlow(attackerAgent, victimAgent, in collisionData, attackerWeapon, in blow);
	}
}
