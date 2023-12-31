using System;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

[ApplicationInterfaceBase]
internal interface ITwoDimensionView
{
	[EngineMethod("create_twodimension_view", false)]
	TwoDimensionView CreateTwoDimensionView();

	[EngineMethod("begin_frame", false)]
	void BeginFrame(UIntPtr pointer);

	[EngineMethod("end_frame", false)]
	void EndFrame(UIntPtr pointer);

	[EngineMethod("clear", false)]
	void Clear(UIntPtr pointer);

	[EngineMethod("add_new_mesh", false)]
	void AddNewMesh(UIntPtr pointer, float[] vertices, float[] uvs, uint[] indices, int vertexCount, int indexCount, UIntPtr material, ref TwoDimensionMeshDrawData meshDrawData);

	[EngineMethod("add_new_quad_mesh", false)]
	void AddNewQuadMesh(UIntPtr pointer, UIntPtr material, ref TwoDimensionMeshDrawData meshDrawData);

	[EngineMethod("add_cached_text_mesh", false)]
	bool AddCachedTextMesh(UIntPtr pointer, UIntPtr material, ref TwoDimensionTextMeshDrawData meshDrawData);

	[EngineMethod("add_new_text_mesh", false)]
	void AddNewTextMesh(UIntPtr pointer, float[] vertices, float[] uvs, uint[] indices, int vertexCount, int indexCount, UIntPtr material, ref TwoDimensionTextMeshDrawData meshDrawData);
}
