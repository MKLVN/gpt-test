using System;
using System.Collections.Generic;

namespace TaleWorlds.Network;

public abstract class MessageContract
{
	private Type _myType;

	private static Dictionary<Type, byte> MessageContracts { get; set; }

	private static Dictionary<Type, MessageContractCreator> MessageContractCreators { get; set; }

	public byte MessageId => MessageContracts[_myType];

	static MessageContract()
	{
		MessageContracts = new Dictionary<Type, byte>();
		MessageContractCreators = new Dictionary<Type, MessageContractCreator>();
	}

	internal static byte GetContractId(Type type)
	{
		InitializeMessageContract(type);
		return MessageContracts[type];
	}

	internal static MessageContractCreator GetContractCreator(Type type)
	{
		InitializeMessageContract(type);
		return MessageContractCreators[type];
	}

	private static void InitializeMessageContract(Type type)
	{
		if (MessageContracts.ContainsKey(type))
		{
			return;
		}
		object[] customAttributes = type.GetCustomAttributes(typeof(MessageId), inherit: true);
		if (customAttributes.Length != 1)
		{
			return;
		}
		MessageId messageId = customAttributes[0] as MessageId;
		lock (MessageContracts)
		{
			if (!MessageContracts.ContainsKey(type))
			{
				MessageContracts.Add(type, messageId.Id);
				Type typeFromHandle = typeof(MessageContractCreator<>);
				Type[] typeArguments = new Type[1] { type };
				MessageContractCreator value = Activator.CreateInstance(typeFromHandle.MakeGenericType(typeArguments)) as MessageContractCreator;
				MessageContractCreators.Add(type, value);
			}
		}
	}

	protected MessageContract()
	{
		_myType = GetType();
		InitializeMessageContract(_myType);
	}

	public static MessageContract CreateMessageContract(Type messageContractType)
	{
		InitializeMessageContract(messageContractType);
		return MessageContractCreators[messageContractType].Invoke();
	}

	public abstract void SerializeToNetworkMessage(INetworkMessageWriter networkMessage);

	public abstract void DeserializeFromNetworkMessage(INetworkMessageReader networkMessage);
}
