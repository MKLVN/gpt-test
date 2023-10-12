using System;
using System.Collections.Generic;
using System.IO;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.MountAndBlade;

public static class BannedPlayerManagerCustomGameServer
{
	private struct BannedPlayer
	{
		public PlayerId PlayerId { get; set; }

		public string PlayerName { get; set; }

		public int BanDueTime { get; set; }
	}

	private static object _bannedPlayersWriteLock = new object();

	private static Dictionary<PlayerId, BannedPlayer> _bannedPlayers = new Dictionary<PlayerId, BannedPlayer>();

	public static void AddBannedPlayer(PlayerId playerId, string playerName, int banDueTime)
	{
		if (_bannedPlayers.ContainsKey(playerId))
		{
			lock (_bannedPlayersWriteLock)
			{
				StreamWriter streamWriter = new StreamWriter("bannedUsers.txt", append: true);
				streamWriter.WriteLine(string.Concat(playerId, "\t", playerName));
				streamWriter.Close();
			}
		}
		_bannedPlayers[playerId] = new BannedPlayer
		{
			PlayerId = playerId,
			BanDueTime = banDueTime,
			PlayerName = playerName
		};
	}

	public static bool IsUserBanned(PlayerId playerId)
	{
		if (_bannedPlayers.ContainsKey(playerId))
		{
			if (_bannedPlayers[playerId].BanDueTime != 0)
			{
				return _bannedPlayers[playerId].BanDueTime > Environment.TickCount;
			}
			return true;
		}
		return false;
	}

	public static void LoadPlayers()
	{
		lock (_bannedPlayersWriteLock)
		{
			StreamReader streamReader = new StreamReader("bannedUsers.txt");
			while (streamReader.Peek() > 0)
			{
				string[] array = streamReader.ReadLine().Split(new char[1] { '\t' });
				PlayerId playerId = PlayerId.FromString(array[0]);
				string playerName = array[1];
				_bannedPlayers[playerId] = new BannedPlayer
				{
					PlayerId = playerId,
					PlayerName = playerName,
					BanDueTime = 0
				};
			}
			streamReader.Close();
		}
	}
}
