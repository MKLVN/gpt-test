using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Network.Messages;

namespace NetworkMessages.FromServer;

[DefineGameNetworkMessageType(GameNetworkMessageSendType.FromServer)]
public sealed class ServerMessage : GameNetworkMessage
{
	public string Message { get; private set; }

	public bool IsMessageTextId { get; private set; }

	public ServerMessage(string message, bool isMessageTextId = false)
	{
		Message = message;
		IsMessageTextId = isMessageTextId;
	}

	public ServerMessage()
	{
	}

	protected override void OnWrite()
	{
		GameNetworkMessage.WriteStringToPacket(Message);
		GameNetworkMessage.WriteBoolToPacket(IsMessageTextId);
	}

	protected override bool OnRead()
	{
		bool bufferReadValid = true;
		Message = GameNetworkMessage.ReadStringFromPacket(ref bufferReadValid);
		IsMessageTextId = GameNetworkMessage.ReadBoolFromPacket(ref bufferReadValid);
		return bufferReadValid;
	}

	protected override MultiplayerMessageFilter OnGetLogFilter()
	{
		return MultiplayerMessageFilter.Messaging;
	}

	protected override string OnGetLogFormat()
	{
		return "Message from server: " + Message;
	}
}
