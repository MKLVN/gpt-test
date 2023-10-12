using System;
using System.Runtime.Serialization;

namespace TaleWorlds.Diamond.Rest;

[Serializable]
[DataContract]
public class AliveMessage : RestRequestMessage
{
	[DataMember]
	public SessionCredentials SessionCredentials { get; private set; }

	public AliveMessage()
	{
	}

	public AliveMessage(SessionCredentials sessionCredentials)
	{
		SessionCredentials = sessionCredentials;
	}
}
