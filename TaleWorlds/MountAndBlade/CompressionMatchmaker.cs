namespace TaleWorlds.MountAndBlade;

public static class CompressionMatchmaker
{
	public static readonly CompressionInfo.Integer KillDeathAssistCountCompressionInfo;

	public static readonly CompressionInfo.Float MissionTimeCompressionInfo;

	public static readonly CompressionInfo.Float MissionTimeLowPrecisionCompressionInfo;

	public static readonly CompressionInfo.Integer MissionCurrentStateCompressionInfo;

	public static readonly CompressionInfo.Integer ScoreCompressionInfo;

	static CompressionMatchmaker()
	{
		KillDeathAssistCountCompressionInfo = new CompressionInfo.Integer(-1000, 100000, maximumValueGiven: true);
		MissionTimeCompressionInfo = new CompressionInfo.Float(-5f, 86400f, 20);
		MissionTimeLowPrecisionCompressionInfo = new CompressionInfo.Float(-5f, 12, 4f);
		MissionCurrentStateCompressionInfo = new CompressionInfo.Integer(0, 6);
		ScoreCompressionInfo = new CompressionInfo.Integer(-1000000, 21);
	}
}
