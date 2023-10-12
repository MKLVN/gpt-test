using System.Collections.Generic;
using SandBox.Objects.AnimationPoints;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SandBox.Objects.Cinematics;

public class SkeletonAnimatedCamera : ScriptComponentBehavior
{
	public string SkeletonName = "human_skeleton";

	public int BoneIndex;

	public Vec3 AttachmentOffset = new Vec3(0f, 0f, 0f, -1f);

	public string AnimationName = "";

	public SimpleButton Restart;

	private void CreateVisualizer()
	{
		if (SkeletonName != "" && AnimationName != "")
		{
			base.GameEntity.CreateSimpleSkeleton(SkeletonName);
			base.GameEntity.Skeleton.SetAnimationAtChannel(AnimationName, 0);
		}
	}

	protected override void OnInit()
	{
		base.OnInit();
		CreateVisualizer();
	}

	protected override void OnEditorInit()
	{
		base.OnEditorInit();
		OnInit();
	}

	protected override void OnTick(float dt)
	{
		GameEntity gameEntity = base.GameEntity.Scene.FindEntityWithTag("camera_instance");
		if (gameEntity != null && base.GameEntity.Skeleton != null)
		{
			MatrixFrame boneEntitialFrame = base.GameEntity.Skeleton.GetBoneEntitialFrame((sbyte)BoneIndex);
			boneEntitialFrame = base.GameEntity.GetGlobalFrame().TransformToParent(boneEntitialFrame);
			MatrixFrame frame = default(MatrixFrame);
			frame.rotation = boneEntitialFrame.rotation;
			frame.rotation.u = -boneEntitialFrame.rotation.s;
			frame.rotation.f = -boneEntitialFrame.rotation.u;
			frame.rotation.s = boneEntitialFrame.rotation.f;
			frame.origin = boneEntitialFrame.origin + AttachmentOffset;
			gameEntity.SetGlobalFrame(in frame);
			SoundManager.SetListenerFrame(frame);
		}
	}

	protected override void OnEditorTick(float dt)
	{
		OnTick(dt);
	}

	protected override void OnEditorVariableChanged(string variableName)
	{
		base.OnEditorVariableChanged(variableName);
		if (variableName == "SkeletonName" || variableName == "AnimationName")
		{
			CreateVisualizer();
		}
		if (!(variableName == "Restart"))
		{
			return;
		}
		List<GameEntity> entities = new List<GameEntity>();
		base.GameEntity.Scene.GetAllEntitiesWithScriptComponent<AnimationPoint>(ref entities);
		foreach (GameEntity item in entities)
		{
			item.GetFirstScriptOfType<AnimationPoint>().RequestResync();
		}
		CreateVisualizer();
	}
}
