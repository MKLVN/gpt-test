using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class DeploymentHandler : MissionLogic
{
	protected MissionMode previousMissionMode;

	protected readonly bool isPlayerAttacker;

	private const string BoundaryTagExpression = "deployment_castle_boundary(_\\d+)*";

	private bool areDeploymentPointsInitialized;

	public Team team => base.Mission.PlayerTeam;

	public bool IsPlayerAttacker => isPlayerAttacker;

	public DeploymentHandler(bool isPlayerAttacker)
	{
		this.isPlayerAttacker = isPlayerAttacker;
	}

	public override void EarlyStart()
	{
		BattleSideEnum deploymentBoundary = (isPlayerAttacker ? BattleSideEnum.Attacker : BattleSideEnum.Defender);
		SetDeploymentBoundary(deploymentBoundary);
	}

	public override void AfterStart()
	{
		base.AfterStart();
		previousMissionMode = base.Mission.Mode;
		base.Mission.SetMissionMode(MissionMode.Deployment, atStart: true);
		team.OnOrderIssued += OrderController_OnOrderIssued;
	}

	private void OrderController_OnOrderIssued(OrderType orderType, MBReadOnlyList<Formation> appliedFormations, params object[] delegateParams)
	{
		OrderController_OnOrderIssued_Aux(orderType, appliedFormations, delegateParams);
	}

	internal static void OrderController_OnOrderIssued_Aux(OrderType orderType, MBReadOnlyList<Formation> appliedFormations, params object[] delegateParams)
	{
		bool flag = false;
		foreach (Formation appliedFormation in appliedFormations)
		{
			if (appliedFormation.CountOfUnits > 0)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			switch (orderType)
			{
			case OrderType.None:
				Debug.FailedAssert("false", "C:\\Develop\\MB3\\Source\\Bannerlord\\TaleWorlds.MountAndBlade\\Missions\\MissionLogics\\DeploymentHandler.cs", "OrderController_OnOrderIssued_Aux", 109);
				break;
			case OrderType.Move:
			case OrderType.MoveToLineSegment:
			case OrderType.MoveToLineSegmentWithHorizontalLayout:
			case OrderType.FollowMe:
			case OrderType.FollowEntity:
			case OrderType.Advance:
			case OrderType.FallBack:
				ForcePositioning();
				ForceUpdateFormationParams();
				break;
			case OrderType.StandYourGround:
				ForcePositioning();
				ForceUpdateFormationParams();
				break;
			case OrderType.Charge:
			case OrderType.ChargeWithTarget:
			case OrderType.GuardMe:
				ForcePositioning();
				ForceUpdateFormationParams();
				break;
			case OrderType.Retreat:
				ForcePositioning();
				ForceUpdateFormationParams();
				break;
			case OrderType.LookAtEnemy:
			case OrderType.LookAtDirection:
				ForcePositioning();
				ForceUpdateFormationParams();
				break;
			case OrderType.ArrangementLine:
			case OrderType.ArrangementCloseOrder:
			case OrderType.ArrangementLoose:
			case OrderType.ArrangementCircular:
			case OrderType.ArrangementSchiltron:
			case OrderType.ArrangementVee:
			case OrderType.ArrangementColumn:
			case OrderType.ArrangementScatter:
				ForceUpdateFormationParams();
				break;
			case OrderType.FormCustom:
			case OrderType.FormDeep:
			case OrderType.FormWide:
			case OrderType.FormWider:
				ForceUpdateFormationParams();
				break;
			case OrderType.Mount:
			case OrderType.Dismount:
				ForceUpdateFormationParams();
				break;
			case OrderType.AIControlOn:
			case OrderType.AIControlOff:
				ForcePositioning();
				ForceUpdateFormationParams();
				break;
			case OrderType.Transfer:
			case OrderType.Use:
			case OrderType.AttackEntity:
				ForceUpdateFormationParams();
				break;
			case OrderType.PointDefence:
				Debug.FailedAssert("will be removed", "C:\\Develop\\MB3\\Source\\Bannerlord\\TaleWorlds.MountAndBlade\\Missions\\MissionLogics\\DeploymentHandler.cs", "OrderController_OnOrderIssued_Aux", 182);
				break;
			default:
				Debug.FailedAssert("false", "C:\\Develop\\MB3\\Source\\Bannerlord\\TaleWorlds.MountAndBlade\\Missions\\MissionLogics\\DeploymentHandler.cs", "OrderController_OnOrderIssued_Aux", 185);
				break;
			case OrderType.CohesionHigh:
			case OrderType.CohesionMedium:
			case OrderType.CohesionLow:
			case OrderType.HoldFire:
			case OrderType.FireAtWill:
				break;
			}
		}
		void ForcePositioning()
		{
			foreach (Formation appliedFormation2 in appliedFormations)
			{
				if (appliedFormation2.CountOfUnits > 0)
				{
					Vec2 direction = appliedFormation2.FacingOrder.GetDirection(appliedFormation2);
					appliedFormation2.SetPositioning(appliedFormation2.GetReadonlyMovementOrderReference().CreateNewOrderWorldPosition(appliedFormation2, WorldPosition.WorldPositionEnforcedCache.None), direction);
				}
			}
		}
		void ForceUpdateFormationParams()
		{
			foreach (Formation appliedFormation3 in appliedFormations)
			{
				if (appliedFormation3.CountOfUnits > 0)
				{
					bool flag2 = false;
					if (appliedFormation3.IsPlayerTroopInFormation)
					{
						flag2 = appliedFormation3.GetReadonlyMovementOrderReference().OrderEnum == MovementOrder.MovementOrderEnum.Follow;
					}
					appliedFormation3.ApplyActionOnEachUnit(delegate(Agent agent)
					{
						agent.UpdateCachedAndFormationValues(updateOnlyMovement: true, arrangementChangeAllowed: false);
					}, flag2 ? Mission.Current.MainAgent : null);
				}
			}
		}
	}

	public void ForceUpdateAllUnits()
	{
		OrderController_OnOrderIssued(OrderType.Move, team.FormationsIncludingSpecialAndEmpty);
	}

	public virtual void FinishDeployment()
	{
	}

	public override void OnRemoveBehavior()
	{
		if (team != null)
		{
			team.OnOrderIssued -= OrderController_OnOrderIssued;
		}
		base.Mission.SetMissionMode(previousMissionMode, atStart: false);
		base.OnRemoveBehavior();
	}

	public void SetDeploymentBoundary(BattleSideEnum side)
	{
		IEnumerable<GameEntity> source = base.Mission.Scene.FindEntitiesWithTagExpression("deployment_castle_boundary(_\\d+)*");
		Regex regex = new Regex("deployment_castle_boundary(_\\d+)*");
		Func<GameEntity, string> getExpressedTag = delegate(GameEntity e)
		{
			string[] tags = e.Tags;
			foreach (string input in tags)
			{
				Match match = regex.Match(input);
				if (match.Success)
				{
					return match.Value;
				}
			}
			Debug.FailedAssert("false", "C:\\Develop\\MB3\\Source\\Bannerlord\\TaleWorlds.MountAndBlade\\Missions\\MissionLogics\\DeploymentHandler.cs", "SetDeploymentBoundary", 237);
			return null;
		};
		foreach (IGrouping<string, GameEntity> item in from e in source
			group e by getExpressedTag(e))
		{
			if (item.Any((GameEntity e) => e.HasTag(side.ToString())))
			{
				string name = getExpressedTag(item.First());
				bool isAllowanceInside = !item.Any((GameEntity e) => e.HasTag("out"));
				IEnumerable<Vec2> source2 = item.Select((GameEntity bp) => bp.GlobalPosition.AsVec2);
				base.Mission.Boundaries.Add(name, source2.ToList(), isAllowanceInside);
			}
		}
	}

	public void RemoveAllBoundaries()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, ICollection<Vec2>> boundary in base.Mission.Boundaries)
		{
			list.Add(boundary.Key);
		}
		foreach (string item in list)
		{
			base.Mission.Boundaries.Remove(item);
		}
	}

	public void InitializeDeploymentPoints()
	{
		if (areDeploymentPointsInitialized)
		{
			return;
		}
		foreach (DeploymentPoint item in base.Mission.ActiveMissionObjects.FindAllWithType<DeploymentPoint>())
		{
			item.Hide();
		}
		areDeploymentPointsInitialized = true;
	}
}
