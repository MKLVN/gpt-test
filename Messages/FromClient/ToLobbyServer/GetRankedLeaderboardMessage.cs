using System;
using Newtonsoft.Json;
using TaleWorlds.Diamond;

namespace Messages.FromClient.ToLobbyServer;

[Serializable]
[MessageDescription("Client", "LobbyServer")]
public class GetRankedLeaderboardMessage : Message
{
	[JsonProperty]
	public string GameType { get; private set; }

	public GetRankedLeaderboardMessage()
	{
	}

	public GetRankedLeaderboardMessage(string gameType)
	{
		GameType = gameType;
	}
}
