using System;
using System.Collections.Generic;

namespace TaleWorlds.MountAndBlade;

public class MatchInfo
{
	public string MatchId { get; set; }

	public string MatchType { get; set; }

	public string GameType { get; set; }

	public string Map { get; set; }

	public DateTime MatchDate { get; set; }

	public int WinnerTeam { get; set; }

	public string Faction1 { get; set; }

	public string Faction2 { get; set; }

	public int DefenderScore { get; set; }

	public int AttackerScore { get; set; }

	public List<PlayerInfo> Players { get; set; }

	public MatchInfo()
	{
		Players = new List<PlayerInfo>();
	}

	private PlayerInfo TryGetPlayer(string id)
	{
		foreach (PlayerInfo player in Players)
		{
			if (player.PlayerId == id)
			{
				return player;
			}
		}
		return null;
	}

	public void AddOrUpdatePlayer(string id, string username, int forcedIndex, int teamNo)
	{
		PlayerInfo playerInfo = TryGetPlayer(id);
		if (playerInfo == null)
		{
			Players.Add(new PlayerInfo
			{
				PlayerId = id,
				Username = username,
				ForcedIndex = forcedIndex,
				TeamNo = teamNo
			});
		}
		else
		{
			playerInfo.TeamNo = teamNo;
		}
	}

	public bool TryUpdatePlayerStats(string id, int kill, int death, int assist)
	{
		PlayerInfo playerInfo = TryGetPlayer(id);
		if (playerInfo != null)
		{
			playerInfo.Kill = kill;
			playerInfo.Death = death;
			playerInfo.Assist = assist;
			return true;
		}
		return false;
	}
}
