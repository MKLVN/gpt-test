using TaleWorlds.Library;

namespace TaleWorlds.Engine;

[ApplicationInterfaceBase]
internal interface IMusic
{
	[EngineMethod("get_free_music_channel_index", false)]
	int GetFreeMusicChannelIndex();

	[EngineMethod("load_clip", false)]
	void LoadClip(int index, string pathToClip);

	[EngineMethod("unload_clip", false)]
	void UnloadClip(int index);

	[EngineMethod("is_clip_loaded", false)]
	bool IsClipLoaded(int index);

	[EngineMethod("play_music", false)]
	void PlayMusic(int index);

	[EngineMethod("play_delayed", false)]
	void PlayDelayed(int index, int delayMilliseconds);

	[EngineMethod("is_music_playing", false)]
	bool IsMusicPlaying(int index);

	[EngineMethod("pause_music", false)]
	void PauseMusic(int index);

	[EngineMethod("stop_music", false)]
	void StopMusic(int index);

	[EngineMethod("set_volume", false)]
	void SetVolume(int index, float volume);
}
