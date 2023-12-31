using System.Collections.Generic;
using System.Linq;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem;

public class CharacterRelationManager
{
	internal class HeroRelations
	{
		[SaveableField(1)]
		private Dictionary<long, Dictionary<long, int>> _relations = new Dictionary<long, Dictionary<long, int>>();

		internal static void AutoGeneratedStaticCollectObjectsHeroRelations(object o, List<object> collectedObjects)
		{
			((HeroRelations)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
		}

		protected virtual void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
		{
			collectedObjects.Add(_relations);
		}

		internal static object AutoGeneratedGetMemberValue_relations(object o)
		{
			return ((HeroRelations)o)._relations;
		}

		public int GetRelation(Hero hero1, Hero hero2)
		{
			(long, long) hashCodes = GetHashCodes(hero1, hero2);
			if (_relations.TryGetValue(hashCodes.Item1, out var value) && value.TryGetValue(hashCodes.Item2, out var value2))
			{
				return value2;
			}
			return 0;
		}

		public void SetRelation(Hero hero1, Hero hero2, int value)
		{
			(long, long) hashCodes = GetHashCodes(hero1, hero2);
			Dictionary<long, int> value3;
			if (value != 0)
			{
				if (!_relations.TryGetValue(hashCodes.Item1, out var value2))
				{
					value2 = new Dictionary<long, int>();
					_relations.Add(hashCodes.Item1, value2);
				}
				value2[hashCodes.Item2] = value;
			}
			else if (_relations.TryGetValue(hashCodes.Item1, out value3) && value3.ContainsKey(hashCodes.Item2))
			{
				value3.Remove(hashCodes.Item2);
				if (!value3.Any())
				{
					_relations.Remove(hashCodes.Item1);
				}
			}
		}

		public void Remove(Hero hero)
		{
			int hashCode = hero.Id.GetHashCode();
			_relations.Remove(hashCode);
			foreach (Dictionary<long, int> value in _relations.Values)
			{
				value.Remove(hashCode);
			}
		}

		public void ClearOldData()
		{
			ClearOldData(_relations);
			foreach (Dictionary<long, int> value in _relations.Values)
			{
				ClearOldData(value);
			}
		}

		private void ClearOldData<T>(Dictionary<long, T> obj)
		{
			HashSet<long> hashSet = new HashSet<long>(obj.Keys);
			foreach (Hero aliveHero in Campaign.Current.CampaignObjectManager.AliveHeroes)
			{
				if (hashSet.Contains(aliveHero.Id.GetHashCode()))
				{
					hashSet.Remove(aliveHero.Id.GetHashCode());
				}
			}
			foreach (long item in hashSet)
			{
				obj.Remove(item);
			}
		}

		private (long, long) GetHashCodes(Hero hero1, Hero hero2)
		{
			if (hero1.Id > hero2.Id)
			{
				return (hero1.Id.GetHashCode(), hero2.Id.GetHashCode());
			}
			return (hero2.Id.GetHashCode(), hero1.Id.GetHashCode());
		}
	}

	[SaveableField(1)]
	private readonly HeroRelations _heroRelations;

	public static CharacterRelationManager Instance => Campaign.Current.CharacterRelationManager;

	internal static void AutoGeneratedStaticCollectObjectsCharacterRelationManager(object o, List<object> collectedObjects)
	{
		((CharacterRelationManager)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected virtual void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		collectedObjects.Add(_heroRelations);
	}

	internal static object AutoGeneratedGetMemberValue_heroRelations(object o)
	{
		return ((CharacterRelationManager)o)._heroRelations;
	}

	public CharacterRelationManager()
	{
		_heroRelations = new HeroRelations();
	}

	public static int GetHeroRelation(Hero hero1, Hero hero2)
	{
		return Instance._heroRelations.GetRelation(hero1, hero2);
	}

	public static void SetHeroRelation(Hero hero1, Hero hero2, int value)
	{
		if (hero1 != hero2)
		{
			Instance._heroRelations.SetRelation(hero1, hero2, value);
		}
		else
		{
			Debug.FailedAssert("hero1 != hero2", "C:\\Develop\\MB3\\Source\\Bannerlord\\TaleWorlds.CampaignSystem\\CharacterRelationManager.cs", "SetHeroRelation", 262);
		}
	}

	public void AfterLoad()
	{
		if (MBSaveLoad.LastLoadedGameVersion < ApplicationVersion.FromString("v1.1.0"))
		{
			_heroRelations.ClearOldData();
		}
	}

	public void RemoveHero(Hero deadHero)
	{
		_heroRelations.Remove(deadHero);
	}
}
