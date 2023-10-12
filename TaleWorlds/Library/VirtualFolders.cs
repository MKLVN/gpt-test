using System;
using System.IO;
using System.Reflection;

namespace TaleWorlds.Library;

public class VirtualFolders
{
	[VirtualDirectory("..")]
	public class Win64_Shipping_Client
	{
		[VirtualDirectory("..")]
		public class bin
		{
			[VirtualDirectory("Parameters")]
			public class Parameters
			{
				[VirtualDirectory("ClientProfiles")]
				public class ClientProfiles
				{
					[VirtualDirectory("DigitalOcean.Test0")]
					public class DigitalOceanTest0
					{
						[VirtualFile("LobbyClient.xml", "<Configuration>\t<SessionProvider Type=\"ThreadedRest\" />\t<Clients>\t\t<Client Type=\"LobbyClient\" />\t</Clients>\t<Parameters>\t\t<Parameter Name=\"LobbyClient.Address\" Value=\"bannerlord-test0-lobby.bannerlord-services-2.net\" />\t\t<Parameter Name=\"LobbyClient.Port\" Value=\"443\" />\t\t<Parameter Name=\"LobbyClient.IsSecure\" Value=\"true\" />\t</Parameters></Configuration>")]
						public string LobbyClient;
					}
				}

				[VirtualFile("Environment", "QMZWqcATaxYQBWksMd0ifjQy9NdJ_dd4IGGIy2r8RQV8fWGKbzfkrlnVBcyAssK5lb3yWDyjXvMTIRNHknDxSjl6pflbWB5D4c4Cxo2VxYYCm3YBSIsh7nmfRLLg3s6sT5LGXLo3XATPG8TTRUSB0J_qEfK_FIkJLTVIXeqZT.w-")]
				public string Environment;

				[VirtualFile("Version.xml", "<Version>\t<Singleplayer Value=\"v1.2.3\"/></Version>")]
				public string Version;

				[VirtualFile("ClientProfile.xml", "<ClientProfile Value=\"DigitalOcean.Test0\"/>")]
				public string ClientProfile;
			}
		}
	}

	private static readonly bool _useVirtualFolders = true;

	public static string GetFileContent(string filePath)
	{
		if (!_useVirtualFolders)
		{
			if (!File.Exists(filePath))
			{
				return "";
			}
			return File.ReadAllText(filePath);
		}
		return GetVirtualFileContent(filePath);
	}

	private static string GetVirtualFileContent(string filePath)
	{
		string fileName = Path.GetFileName(filePath);
		string[] array = Path.GetDirectoryName(filePath).Split(new char[1] { Path.DirectorySeparatorChar });
		Type type = typeof(VirtualFolders);
		int num = 0;
		while (type != null && num != array.Length)
		{
			if (!string.IsNullOrEmpty(array[num]))
			{
				type = GetNestedDirectory(array[num], type);
			}
			num++;
		}
		if (type != null)
		{
			FieldInfo[] fields = type.GetFields();
			for (int i = 0; i < fields.Length; i++)
			{
				VirtualFileAttribute[] array2 = (VirtualFileAttribute[])fields[i].GetCustomAttributes(typeof(VirtualFileAttribute), inherit: false);
				if (array2[0].Name == fileName)
				{
					return array2[0].Content;
				}
			}
		}
		return "";
	}

	private static Type GetNestedDirectory(string name, Type type)
	{
		Type[] nestedTypes = type.GetNestedTypes();
		foreach (Type type2 in nestedTypes)
		{
			if (((VirtualDirectoryAttribute[])type2.GetCustomAttributes(typeof(VirtualDirectoryAttribute), inherit: false))[0].Name == name)
			{
				return type2;
			}
		}
		return null;
	}
}
