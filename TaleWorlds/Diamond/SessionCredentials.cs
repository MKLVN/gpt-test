using System;
using System.Runtime.Serialization;

namespace TaleWorlds.Diamond;

[Serializable]
[DataContract]
public sealed class SessionCredentials
{
	[DataMember]
	public PeerId PeerId { get; private set; }

	[DataMember]
	public SessionKey SessionKey { get; private set; }

	public SessionCredentials(PeerId peerId, SessionKey sessionKey)
	{
		PeerId = peerId;
		SessionKey = sessionKey;
	}
}
