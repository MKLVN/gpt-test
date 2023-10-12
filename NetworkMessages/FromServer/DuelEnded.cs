using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Network.Messages;

namespace NetworkMessages.FromServer;

[DefineGameNetworkMessageType(GameNetworkMessageSendType.FromServer)]
public sealed class DuelEnded : GameNetworkMessage
{
	public NetworkCommunicator WinnerPeer { get; private set; }

	public DuelEnded(NetworkCommunicator winnerPeer)
	{
		WinnerPeer = winnerPeer;
	}

	public DuelEnded()
	{
	}

	protected override bool OnRead()
	{
		bool bufferReadValid = true;
		WinnerPeer = GameNetworkMessage.ReadNetworkPeerReferenceFromPacket(ref bufferReadValid);
		return bufferReadValid;
	}

	protected override void OnWrite()
	{
		GameNetworkMessage.WriteNetworkPeerReferenceToPacket(WinnerPeer);
	}

	protected override MultiplayerMessageFilter OnGetLogFilter()
	{
		return MultiplayerMessageFilter.GameMode;
	}

	protected override string OnGetLogFormat()
	{
		return WinnerPeer.UserName + "has won the duel";
	}
}
