using TaleWorlds.MountAndBlade.Diamond;

namespace TaleWorlds.MountAndBlade;

public static class NetworkMain
{
	public static LobbyClient GameClient { get; private set; }

	public static CommunityClient CommunityClient { get; private set; }

	public static void SetPeers(LobbyClient gameClient, CommunityClient communityClient)
	{
		GameClient = gameClient;
		CommunityClient = communityClient;
	}
}
