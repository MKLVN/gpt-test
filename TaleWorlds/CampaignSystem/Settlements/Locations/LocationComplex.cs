using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.Settlements.Locations;

public class LocationComplex
{
	[SaveableField(1)]
	private readonly Dictionary<string, Location> _locations;

	public static LocationComplex Current
	{
		get
		{
			if (PlayerEncounter.LocationEncounter != null)
			{
				return PlayerEncounter.LocationEncounter.Settlement.LocationComplex;
			}
			return null;
		}
	}

	internal static void AutoGeneratedStaticCollectObjectsLocationComplex(object o, List<object> collectedObjects)
	{
		((LocationComplex)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected virtual void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		collectedObjects.Add(_locations);
	}

	internal static object AutoGeneratedGetMemberValue_locations(object o)
	{
		return ((LocationComplex)o)._locations;
	}

	public static bool CanAlways(LocationCharacter locationCharacter, Location location)
	{
		return true;
	}

	public static bool CanNever(LocationCharacter locationCharacter, Location location)
	{
		return false;
	}

	public static bool CanIfHero(LocationCharacter locationCharacter, Location location)
	{
		return locationCharacter.Character.IsHero;
	}

	public static bool CanIfDay(LocationCharacter locationCharacter, Location location)
	{
		return !Campaign.Current.IsNight;
	}

	public static bool CanIfPriceIsPaid(LocationCharacter locationCharacter, Location location)
	{
		string stringId = location.StringId;
		if (!(stringId == "lordshall"))
		{
			if (stringId == "prison")
			{
				return Campaign.Current.Models.BribeCalculationModel.GetBribeToEnterDungeon(Settlement.CurrentSettlement) == 0;
			}
			return false;
		}
		return Campaign.Current.Models.BribeCalculationModel.GetBribeToEnterLordsHall(Settlement.CurrentSettlement) == 0;
	}

	public static bool CanIfGrownUpMaleOrHero(LocationCharacter locationCharacter, Location location)
	{
		if (CanIfMaleOrHero(locationCharacter, location))
		{
			return locationCharacter.Character.Age >= (float)Campaign.Current.Models.AgeModel.HeroComesOfAge;
		}
		return false;
	}

	public static bool CanIfMaleOrHero(LocationCharacter locationCharacter, Location location)
	{
		if (locationCharacter.Character.IsFemale)
		{
			return locationCharacter.Character.IsHero;
		}
		return true;
	}

	public static bool CanIfSettlementAccessModelLetsPlayer(LocationCharacter locationCharacter, Location location)
	{
		bool disableOption;
		TextObject disabledText;
		return Campaign.Current.Models.SettlementAccessModel.CanMainHeroAccessLocation(Settlement.CurrentSettlement, location.StringId, out disableOption, out disabledText);
	}

	public LocationComplex()
	{
		_locations = new Dictionary<string, Location>();
	}

	public LocationComplex(LocationComplexTemplate complexTemplate)
		: this()
	{
		foreach (Location location in complexTemplate.Locations)
		{
			_locations.Add(location.StringId, new Location(location, this));
		}
		foreach (KeyValuePair<string, string> passage in complexTemplate.Passages)
		{
			AddPassage(GetLocationWithId(passage.Key), GetLocationWithId(passage.Value));
		}
	}

	public LocationComplex(LocationComplex complex)
		: this()
	{
		List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
		foreach (Location listOfLocation in complex.GetListOfLocations())
		{
			_locations.Add(listOfLocation.StringId, new Location(listOfLocation, this));
			foreach (Location locationsOfPassage in listOfLocation.LocationsOfPassages)
			{
				if (!list.Contains(new KeyValuePair<string, string>(locationsOfPassage.StringId, listOfLocation.StringId)) && !list.Contains(new KeyValuePair<string, string>(listOfLocation.StringId, locationsOfPassage.StringId)))
				{
					list.Add(new KeyValuePair<string, string>(listOfLocation.StringId, locationsOfPassage.StringId));
				}
			}
		}
		foreach (KeyValuePair<string, string> item in list)
		{
			AddPassage(GetLocationWithId(item.Key), GetLocationWithId(item.Value));
		}
	}

	public void Initialize(LocationComplexTemplate complexTemplate)
	{
		foreach (Location location2 in complexTemplate.Locations)
		{
			Location location = GetLocationWithId(location2.StringId);
			if (location == null)
			{
				location = new Location(location2, this);
				_locations.Add(location2.StringId, location);
			}
			location?.Initialize(location2, this);
		}
		foreach (string item in _locations.Keys.ToList())
		{
			Location locationWithId = GetLocationWithId(item);
			if (locationWithId == null || !locationWithId.IsInitialized)
			{
				_locations.Remove(item);
			}
		}
		foreach (KeyValuePair<string, string> passage in complexTemplate.Passages)
		{
			AddPassage(GetLocationWithId(passage.Key), GetLocationWithId(passage.Value));
		}
	}

	public void AddPassage(Location firstLocation, Location secondLocation)
	{
		firstLocation.AddPassageToLocation(secondLocation);
		secondLocation.AddPassageToLocation(firstLocation);
	}

	public void ChangeLocation(LocationCharacter locationCharacter, Location fromLocation, Location toLocation)
	{
		fromLocation?.RemoveLocationCharacter(locationCharacter);
		toLocation?.AddCharacter(locationCharacter);
		toLocation?.OnAIChangeLocation(fromLocation);
		if (CampaignMission.Current != null && (toLocation == null || toLocation == CampaignMission.Current.Location))
		{
			PlayerEncounter.LocationEncounter.OnCharacterLocationChanged(locationCharacter, fromLocation, toLocation);
		}
	}

	public IEnumerable<LocationCharacter> GetListOfCharactersInLocation(string locationName)
	{
		foreach (LocationCharacter character in _locations[locationName].GetCharacterList())
		{
			yield return character;
		}
	}

	public IList<LocationCharacter> GetListOfCharacters()
	{
		List<LocationCharacter> list = new List<LocationCharacter>();
		foreach (KeyValuePair<string, Location> location in _locations)
		{
			list = list.Concat(location.Value.GetCharacterList()).ToList();
		}
		return list.AsReadOnly();
	}

	public IEnumerable<Location> GetListOfLocations()
	{
		foreach (KeyValuePair<string, Location> location in _locations)
		{
			yield return location.Value;
		}
	}

	public void AgentPassageUsageTick()
	{
		if (CampaignMission.Current.Mode == MissionMode.Stealth)
		{
			return;
		}
		List<LocationCharacter> list = new List<LocationCharacter>();
		foreach (KeyValuePair<string, Location> location in _locations)
		{
			if (location.Value == CampaignMission.Current.Location || !location.Value.CanAIExit(null))
			{
				continue;
			}
			foreach (LocationCharacter character in location.Value.GetCharacterList())
			{
				if (!character.FixedLocation)
				{
					list.Add(character);
				}
			}
		}
		if (list.Count <= 0)
		{
			return;
		}
		LocationCharacter locationCharacter = list[MBRandom.RandomInt(list.Count)];
		Location locationOfCharacter = GetLocationOfCharacter(locationCharacter);
		int num = 0;
		foreach (Location locationsOfPassage in locationOfCharacter.LocationsOfPassages)
		{
			if (locationsOfPassage.CanAIEnter(locationCharacter) && locationsOfPassage.CharacterCount < locationsOfPassage.ProsperityMax)
			{
				num += locationsOfPassage.ProsperityMax;
			}
		}
		if (num <= 0)
		{
			return;
		}
		int num2 = MBRandom.RandomInt(num);
		Location toLocation = null;
		foreach (Location locationsOfPassage2 in locationOfCharacter.LocationsOfPassages)
		{
			if (locationsOfPassage2.CanAIEnter(locationCharacter) && locationsOfPassage2.CharacterCount < locationsOfPassage2.ProsperityMax)
			{
				num2 -= locationsOfPassage2.ProsperityMax;
				if (num2 < 0)
				{
					toLocation = locationsOfPassage2;
				}
			}
		}
		ChangeLocation(locationCharacter, locationOfCharacter, toLocation);
	}

	public Location GetLocationOfCharacter(LocationCharacter character)
	{
		Location result = null;
		foreach (KeyValuePair<string, Location> location in _locations)
		{
			if (location.Value.ContainsCharacter(character))
			{
				result = location.Value;
			}
		}
		return result;
	}

	public Location GetLocationOfCharacter(Hero hero)
	{
		Location result = null;
		foreach (KeyValuePair<string, Location> location in _locations)
		{
			if (location.Value.ContainsCharacter(hero))
			{
				return location.Value;
			}
		}
		return result;
	}

	public LocationCharacter GetLocationCharacterOfHero(Hero hero)
	{
		foreach (KeyValuePair<string, Location> location in _locations)
		{
			LocationCharacter locationCharacter = location.Value.GetLocationCharacter(hero);
			if (locationCharacter != null)
			{
				return locationCharacter;
			}
		}
		return null;
	}

	public LocationCharacter GetFirstLocationCharacterOfCharacter(CharacterObject character)
	{
		foreach (KeyValuePair<string, Location> location in _locations)
		{
			foreach (LocationCharacter character2 in location.Value.GetCharacterList())
			{
				if (character2.Character == character)
				{
					return character2;
				}
			}
		}
		return null;
	}

	public void RemoveCharacterIfExists(Hero hero)
	{
		GetLocationOfCharacter(hero)?.RemoveCharacter(hero);
	}

	public void RemoveCharacterIfExists(LocationCharacter locationCharacter)
	{
		GetLocationOfCharacter(locationCharacter)?.RemoveLocationCharacter(locationCharacter);
	}

	public void ClearTempCharacters()
	{
		foreach (KeyValuePair<string, Location> location in _locations)
		{
			location.Value.RemoveAllCharacters();
		}
	}

	public Location GetLocationWithId(string id)
	{
		foreach (KeyValuePair<string, Location> location in _locations)
		{
			if (location.Key == id)
			{
				return location.Value;
			}
		}
		return null;
	}

	public string GetScene(string stringId, int upgradeLevel)
	{
		return GetLocationWithId(stringId).GetSceneName(upgradeLevel);
	}

	public LocationCharacter FindCharacter(IAgent agent)
	{
		LocationCharacter locationCharacter = null;
		foreach (KeyValuePair<string, Location> location in _locations)
		{
			locationCharacter = location.Value.GetLocationCharacter(agent.Origin);
			if (locationCharacter != null)
			{
				return locationCharacter;
			}
		}
		return locationCharacter;
	}

	public IEnumerable<Location> FindAll(Func<string, bool> predicate)
	{
		return from kv in _locations
			where predicate(kv.Key)
			select kv.Value;
	}
}