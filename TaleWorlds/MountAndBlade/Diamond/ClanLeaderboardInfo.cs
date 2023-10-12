using System;

namespace TaleWorlds.MountAndBlade.Diamond;

[Serializable]
public class ClanLeaderboardInfo
{
	public static ClanLeaderboardInfo Empty { get; private set; }

	public ClanLeaderboardEntry[] ClanEntries { get; private set; }

	static ClanLeaderboardInfo()
	{
		Empty = new ClanLeaderboardInfo(new ClanLeaderboardEntry[0]);
	}

	public ClanLeaderboardInfo(ClanLeaderboardEntry[] entries)
	{
		ClanEntries = entries;
	}
}
