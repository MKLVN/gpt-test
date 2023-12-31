using System;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

[ApplicationInterfaceBase]
internal interface IDecal
{
	[EngineMethod("get_material", false)]
	Material GetMaterial(UIntPtr decalPointer);

	[EngineMethod("set_material", false)]
	void SetMaterial(UIntPtr decalPointer, UIntPtr materialPointer);

	[EngineMethod("create_decal", false)]
	Decal CreateDecal(string name);

	[EngineMethod("get_factor_1", false)]
	uint GetFactor1(UIntPtr decalPointer);

	[EngineMethod("set_factor_1_linear", false)]
	void SetFactor1Linear(UIntPtr decalPointer, uint linearFactorColor1);

	[EngineMethod("set_factor_1", false)]
	void SetFactor1(UIntPtr decalPointer, uint factorColor1);

	[EngineMethod("set_vector_argument", false)]
	void SetVectorArgument(UIntPtr decalPointer, float vectorArgument0, float vectorArgument1, float vectorArgument2, float vectorArgument3);

	[EngineMethod("set_vector_argument_2", false)]
	void SetVectorArgument2(UIntPtr decalPointer, float vectorArgument0, float vectorArgument1, float vectorArgument2, float vectorArgument3);

	[EngineMethod("get_global_frame", false)]
	void GetFrame(UIntPtr decalPointer, ref MatrixFrame outFrame);

	[EngineMethod("set_global_frame", false)]
	void SetFrame(UIntPtr decalPointer, ref MatrixFrame decalFrame);

	[EngineMethod("create_copy", false)]
	Decal CreateCopy(UIntPtr pointer);
}
