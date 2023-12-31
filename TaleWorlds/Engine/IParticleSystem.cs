using System;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

[ApplicationInterfaceBase]
internal interface IParticleSystem
{
	[EngineMethod("set_enable", false)]
	void SetEnable(UIntPtr psysPointer, bool enable);

	[EngineMethod("set_runtime_emission_rate_multiplier", false)]
	void SetRuntimeEmissionRateMultiplier(UIntPtr pointer, float multiplier);

	[EngineMethod("restart", false)]
	void Restart(UIntPtr psysPointer);

	[EngineMethod("set_local_frame", false)]
	void SetLocalFrame(UIntPtr pointer, ref MatrixFrame newFrame);

	[EngineMethod("get_local_frame", false)]
	void GetLocalFrame(UIntPtr pointer, ref MatrixFrame frame);

	[EngineMethod("get_runtime_id_by_name", false)]
	int GetRuntimeIdByName(string particleSystemName);

	[EngineMethod("create_particle_system_attached_to_bone", false)]
	ParticleSystem CreateParticleSystemAttachedToBone(int runtimeId, UIntPtr skeletonPtr, sbyte boneIndex, ref MatrixFrame boneLocalFrame);

	[EngineMethod("create_particle_system_attached_to_entity", false)]
	ParticleSystem CreateParticleSystemAttachedToEntity(int runtimeId, UIntPtr entityPtr, ref MatrixFrame boneLocalFrame);

	[EngineMethod("set_particle_effect_by_name", false)]
	void SetParticleEffectByName(UIntPtr pointer, string effectName);
}
