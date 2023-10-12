using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.Diamond;
using TaleWorlds.PlayerServices;

namespace Messages.FromBattleServer.ToBattleServerManager;

[Serializable]
[MessageDescription("BattleServer", "BattleServerManager")]
public class BattleStartedMessage : Message
{
	public Dictionary<string, int> PlayerTeams { get; set; }

	public BattleStartedMessage()
	{
	}

	public BattleStartedMessage(Dictionary<PlayerId, int> playerTeams)
	{
		PlayerTeams = playerTeams.ToDictionary((KeyValuePair<PlayerId, int> kvp) => kvp.Key.ToString(), (KeyValuePair<PlayerId, int> kvp) => kvp.Value);
	}
}
