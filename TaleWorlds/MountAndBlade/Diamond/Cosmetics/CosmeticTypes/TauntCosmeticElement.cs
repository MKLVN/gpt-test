using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.Diamond.Cosmetics.CosmeticTypes;

public class TauntCosmeticElement : CosmeticElement
{
	private static Dictionary<string, List<(string, int)>> _localSlotData;

	private static bool _isReadingData;

	private const string _dataFolder = "Data";

	private const string _dataFile = "Taunts.json";

	public static int MaxNumberOfTaunts => 6;

	public TextObject Name { get; }

	static TauntCosmeticElement()
	{
		_localSlotData = new Dictionary<string, List<(string, int)>>();
	}

	public TauntCosmeticElement(int index, string id, CosmeticsManager.CosmeticRarity rarity, int cost, string name)
		: base(id, rarity, cost, CosmeticsManager.CosmeticType.Taunt)
	{
		UsageIndex = index;
		Name = new TextObject(name);
	}

	private static PlatformFilePath GetDataFilePath()
	{
		return new PlatformFilePath(new PlatformDirectoryPath(PlatformFileType.User, "Data"), "Taunts.json");
	}

	private static async Task ReadExistingSlotDataAsync()
	{
		if (_isReadingData)
		{
			return;
		}
		_isReadingData = true;
		PlatformFilePath dataFilePath = GetDataFilePath();
		_localSlotData = null;
		if (FileHelper.FileExists(dataFilePath))
		{
			string value = await FileHelper.GetFileContentStringAsync(dataFilePath);
			if (!string.IsNullOrEmpty(value))
			{
				_localSlotData = JsonConvert.DeserializeObject<Dictionary<string, List<(string, int)>>>(value);
			}
		}
		_isReadingData = false;
	}

	public static async Task<List<(string, int)>> GetTauntIndicesForPlayerAsync(string playerId)
	{
		await ReadExistingSlotDataAsync();
		List<(string, int)> value = null;
		if (_localSlotData?.TryGetValue(playerId, out value) ?? false)
		{
			return value;
		}
		return null;
	}

	public static async Task SetTauntIndicesForPlayerAsync(string playerBannerlordId, List<(string, int)> tauntIndices)
	{
		await ReadExistingSlotDataAsync();
		Dictionary<string, List<(string, int)>> dictionary = _localSlotData ?? new Dictionary<string, List<(string, int)>>();
		PlatformFilePath dataFilePath = GetDataFilePath();
		string key = playerBannerlordId.ToString();
		if (dictionary.ContainsKey(key))
		{
			dictionary.Remove(key);
		}
		dictionary.Add(key, tauntIndices);
		if (await FileHelper.SaveFileAsync(dataFilePath, Common.SerializeObjectAsJson(dictionary)) != 0)
		{
			Debug.FailedAssert("Failed to save taunt indices", "C:\\Develop\\MB3\\Source\\Bannerlord\\TaleWorlds.MountAndBlade.Diamond\\Cosmetics\\CosmeticTypes\\TauntCosmeticElement.cs", "SetTauntIndicesForPlayerAsync", 105);
		}
	}
}
