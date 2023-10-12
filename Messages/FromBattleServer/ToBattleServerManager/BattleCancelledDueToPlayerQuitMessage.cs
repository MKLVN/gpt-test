using System;
using Newtonsoft.Json;
using TaleWorlds.Diamond;
using TaleWorlds.PlayerServices;

namespace Messages.FromBattleServer.ToBattleServerManager;

[Serializable]
[MessageDescription("BattleServer", "BattleServerManager")]
public class BattleCancelledDueToPlayerQuitMessage : Message
{
	[JsonProperty]
	public PlayerId PlayerId { get; private set; }

	public BattleCancelledDueToPlayerQuitMessage()
	{
	}

	public BattleCancelledDueToPlayerQuitMessage(PlayerId playerId)
	{
		PlayerId = playerId;
	}
}
