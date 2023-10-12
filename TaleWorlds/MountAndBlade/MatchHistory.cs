using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public static class MatchHistory
{
	private const int MaxMatchCountPerMatchType = 10;

	private const string HistoryDirectoryName = "Data";

	private const string HistoryFileName = "History.json";

	private static bool IsHistoryCacheDirty;

	private static MBList<MatchInfo> _matches;

	private static PlatformFilePath HistoryFilePath
	{
		get
		{
			PlatformDirectoryPath folderPath = new PlatformDirectoryPath(PlatformFileType.User, "Data");
			return new PlatformFilePath(folderPath, "History.json");
		}
	}

	public static MBReadOnlyList<MatchInfo> Matches => _matches;

	static MatchHistory()
	{
		IsHistoryCacheDirty = true;
		_matches = new MBList<MatchInfo>();
	}

	public static async Task LoadMatchHistory()
	{
		if (!IsHistoryCacheDirty)
		{
			return;
		}
		if (FileHelper.FileExists(HistoryFilePath))
		{
			try
			{
				_matches = JsonConvert.DeserializeObject<MBList<MatchInfo>>(await FileHelper.GetFileContentStringAsync(HistoryFilePath));
				if (_matches == null)
				{
					_matches = new MBList<MatchInfo>();
					throw new Exception("_matches were null.");
				}
			}
			catch (Exception ex)
			{
				Debug.FailedAssert("Could not load match history. " + ex.Message, "C:\\Develop\\MB3\\Source\\Bannerlord\\TaleWorlds.MountAndBlade\\Network\\MatchHistory.cs", "LoadMatchHistory", 65);
				try
				{
					FileHelper.DeleteFile(HistoryFilePath);
				}
				catch (Exception ex2)
				{
					Debug.FailedAssert("Could not delete match history file. " + ex2.Message, "C:\\Develop\\MB3\\Source\\Bannerlord\\TaleWorlds.MountAndBlade\\Network\\MatchHistory.cs", "LoadMatchHistory", 72);
				}
			}
		}
		IsHistoryCacheDirty = false;
	}

	public static async Task<MBReadOnlyList<MatchInfo>> GetMatches()
	{
		await LoadMatchHistory();
		return Matches;
	}

	public static void AddMatch(MatchInfo match)
	{
		if (TryGetMatchInfo(match.MatchId, out var _))
		{
			for (int i = 0; i < _matches.Count; i++)
			{
				if (_matches[i].MatchId == match.MatchId)
				{
					_matches[i] = match;
				}
			}
		}
		else
		{
			int matchTypeCount = GetMatchTypeCount(match.MatchType);
			if (matchTypeCount >= 10)
			{
				RemoveMatches(match.MatchType, matchTypeCount - 10 + 1);
			}
			_matches.Add(match);
		}
		IsHistoryCacheDirty = true;
	}

	public static bool TryGetMatchInfo(string matchId, out MatchInfo matchInfo)
	{
		matchInfo = null;
		foreach (MatchInfo match in _matches)
		{
			if (match.MatchId == matchId)
			{
				matchInfo = match;
				return true;
			}
		}
		return false;
	}

	private static void RemoveMatches(string matchType, int numMatchToRemove)
	{
		for (int i = 0; i < numMatchToRemove; i++)
		{
			MatchInfo oldestMatch = GetOldestMatch(matchType);
			_matches.Remove(oldestMatch);
		}
		IsHistoryCacheDirty = true;
	}

	private static MatchInfo GetOldestMatch(string matchType)
	{
		DateTime dateTime = DateTime.MaxValue;
		MatchInfo result = null;
		foreach (MatchInfo match in _matches)
		{
			if (match.MatchDate < dateTime)
			{
				dateTime = match.MatchDate;
				result = match;
			}
		}
		return result;
	}

	public static async void Serialize()
	{
		try
		{
			byte[] data = Common.SerializeObjectAsJson(_matches);
			await FileHelper.SaveFileAsync(HistoryFilePath, data);
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
		IsHistoryCacheDirty = true;
	}

	private static int GetMatchTypeCount(string category)
	{
		int num = 0;
		foreach (MatchInfo match in _matches)
		{
			if (match.MatchType == category)
			{
				num++;
			}
		}
		return num;
	}
}
