using System;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.MountAndBlade.Diamond;

[Serializable]
public class ClanPlayerInfo
{
	public PlayerId PlayerId { get; private set; }

	public string PlayerName { get; private set; }

	public AnotherPlayerState State { get; private set; }

	public string ActiveBadgeId { get; private set; }

	public ClanPlayerInfo(PlayerId playerId, string playerName, AnotherPlayerState anotherPlayerState, string activeBadgeId)
	{
		PlayerId = playerId;
		PlayerName = playerName;
		ActiveBadgeId = activeBadgeId;
		State = anotherPlayerState;
	}
}
