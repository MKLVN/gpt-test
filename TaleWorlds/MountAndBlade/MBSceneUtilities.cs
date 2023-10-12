using System.Collections.Generic;
using System.Linq;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public static class MBSceneUtilities
{
	public const int MaxNumberOfSpawnPaths = 32;

	public const string SpawnPathPrefix = "spawn_path_";

	public const string SoftBorderVertexTag = "walk_area_vertex";

	public const string SoftBoundaryName = "walk_area";

	public const string SceneBoundaryName = "scene_boundary";

	public static MBList<Path> GetAllSpawnPaths(Scene scene)
	{
		MBList<Path> mBList = new MBList<Path>();
		for (int i = 0; i < 32; i++)
		{
			string name = "spawn_path_" + i.ToString("D2");
			Path pathWithName = scene.GetPathWithName(name);
			if (pathWithName != null && pathWithName.NumberOfPoints > 1)
			{
				mBList.Add(pathWithName);
			}
		}
		return mBList;
	}

	public static List<Vec2> GetSceneBoundaryPoints(Scene scene, out string boundaryName)
	{
		List<Vec2> list = new List<Vec2>();
		int softBoundaryVertexCount = scene.GetSoftBoundaryVertexCount();
		if (softBoundaryVertexCount >= 3)
		{
			boundaryName = "walk_area";
			for (int i = 0; i < softBoundaryVertexCount; i++)
			{
				Vec2 softBoundaryVertex = scene.GetSoftBoundaryVertex(i);
				list.Add(softBoundaryVertex);
			}
		}
		else
		{
			boundaryName = "scene_boundary";
			scene.GetBoundingBox(out var min, out var max);
			float num = MathF.Min(2f, max.x - min.x);
			float num2 = MathF.Min(2f, max.y - min.y);
			List<Vec2> collection = new List<Vec2>
			{
				new Vec2(min.x + num, min.y + num2),
				new Vec2(max.x - num, min.y + num2),
				new Vec2(max.x - num, max.y - num2),
				new Vec2(min.x + num, max.y - num2)
			};
			list.AddRange(collection);
		}
		return list;
	}

	public static void ProjectPositionToDeploymentBoundaries(BattleSideEnum side, ref WorldPosition position)
	{
		Mission current = Mission.Current;
		IMissionDeploymentPlan deploymentPlan = current.DeploymentPlan;
		if (deploymentPlan.HasDeploymentBoundaries(side, DeploymentPlanType.Initial))
		{
			Vec2 position2 = position.AsVec2;
			if (!deploymentPlan.IsPositionInsideDeploymentBoundaries(side, in position2, DeploymentPlanType.Initial))
			{
				position2 = position.AsVec2;
				Vec2 closestDeploymentBoundaryPosition = deploymentPlan.GetClosestDeploymentBoundaryPosition(side, in position2, DeploymentPlanType.Initial);
				position = new WorldPosition(current.Scene, new Vec3(closestDeploymentBoundaryPosition, position.GetGroundZ()));
			}
		}
	}

	public static void RadialSortBoundaries(ref List<Vec2> boundaries)
	{
		if (boundaries.Count == 0)
		{
			return;
		}
		Vec2 boundaryCenter = Vec2.Zero;
		foreach (Vec2 boundary in boundaries)
		{
			boundaryCenter += boundary;
		}
		boundaryCenter.x /= boundaries.Count;
		boundaryCenter.y /= boundaries.Count;
		boundaries = boundaries.OrderBy((Vec2 b) => (b - boundaryCenter).RotationInRadians).ToList();
	}

	public static bool IsPointInsideBoundaries(in Vec2 point, List<Vec2> boundaries, float acceptanceThreshold = 0.01f)
	{
		acceptanceThreshold = MathF.Max(0f, acceptanceThreshold);
		if (boundaries.Count <= 2)
		{
			return false;
		}
		bool result = true;
		for (int i = 0; i < boundaries.Count; i++)
		{
			Vec2 vec = boundaries[i];
			Vec2 vec2 = boundaries[(i + 1) % boundaries.Count] - vec;
			Vec2 vec3 = point - vec;
			if (vec2.x * vec3.y - vec2.y * vec3.x < 0f - acceptanceThreshold)
			{
				result = false;
				break;
			}
		}
		return result;
	}

	public static float FindClosestPointToBoundaries(in Vec2 position, List<Vec2> boundaries, out Vec2 closestPoint)
	{
		closestPoint = position;
		float num = float.MaxValue;
		for (int i = 0; i < boundaries.Count; i++)
		{
			Vec2 segmentA = boundaries[i];
			Vec2 segmentB = boundaries[(i + 1) % boundaries.Count];
			Vec2 closest;
			float closestPointOnLineSegment = MBMath.GetClosestPointOnLineSegment(position, segmentA, segmentB, out closest);
			if (closestPointOnLineSegment <= num)
			{
				num = closestPointOnLineSegment;
				closestPoint = closest;
			}
		}
		return num;
	}
}
