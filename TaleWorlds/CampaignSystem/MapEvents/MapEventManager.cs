using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.MapEvents;

public class MapEventManager
{
	[SaveableField(1)]
	private List<MapEvent> _mapEvents;

	public List<MapEvent> MapEvents => _mapEvents;

	internal static void AutoGeneratedStaticCollectObjectsMapEventManager(object o, List<object> collectedObjects)
	{
		((MapEventManager)o).AutoGeneratedInstanceCollectObjects(collectedObjects);
	}

	protected virtual void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		collectedObjects.Add(_mapEvents);
	}

	internal static object AutoGeneratedGetMemberValue_mapEvents(object o)
	{
		return ((MapEventManager)o)._mapEvents;
	}

	internal MapEventManager()
	{
		_mapEvents = new List<MapEvent>();
	}

	internal void OnAfterLoad()
	{
		foreach (MapEvent mapEvent in _mapEvents)
		{
			mapEvent.OnAfterLoad();
		}
	}

	public void OnMapEventCreated(MapEvent mapEvent)
	{
		_mapEvents.Add(mapEvent);
	}

	internal void Tick()
	{
		for (int num = _mapEvents.Count - 1; num >= 0; num--)
		{
			if (_mapEvents[num].IsFinished)
			{
				_mapEvents.RemoveAt(num);
			}
			else if (_mapEvents[num].IsRaid || _mapEvents[num] != MobileParty.MainParty.MapEvent)
			{
				_mapEvents[num].Update();
			}
		}
	}

	public MapEvent GetMapEvent(int attackerPartyIndex)
	{
		return _mapEvents.FirstOrDefault((MapEvent mapEvent) => mapEvent.AttackerSide.LeaderParty.Index == attackerPartyIndex);
	}

	public List<MapEvent> GetMapEventsBetweenFactions(IFaction faction1, IFaction faction2)
	{
		List<MapEvent> list = new List<MapEvent>();
		foreach (MapEvent mapEvent in _mapEvents)
		{
			MBReadOnlyList<MapEventParty> source = mapEvent.PartiesOnSide(BattleSideEnum.Defender);
			MBReadOnlyList<MapEventParty> source2 = mapEvent.PartiesOnSide(BattleSideEnum.Attacker);
			if ((source.Any((MapEventParty mapEventParty) => mapEventParty.Party.MapFaction == faction1) && source2.Any((MapEventParty mapEventParty) => mapEventParty.Party.MapFaction == faction2)) || (source.Any((MapEventParty mapEventParty) => mapEventParty.Party.MapFaction == faction2) && source2.Any((MapEventParty mapEventParty) => mapEventParty.Party.MapFaction == faction1)))
			{
				list.Add(mapEvent);
			}
		}
		return list;
	}

	public void FinalizePlayerMapEvent(MapEvent mapEvent = null)
	{
		if (MobileParty.MainParty.MapEvent == null)
		{
			throw new MBNotFoundException("Trying to finalize a non-existing map event.");
		}
		PartyBase.MainParty.MapEvent.FinalizeEvent();
		PlayerEncounter.Finish();
	}

	public MapEvent StartSiegeMapEvent(PartyBase attackerParty, PartyBase defenderParty)
	{
		MapEvent mapEvent = new MapEvent();
		mapEvent.Initialize(attackerParty, defenderParty, null, MapEvent.BattleTypes.Siege);
		OnMapEventCreated(mapEvent);
		return mapEvent;
	}

	public MapEvent StartSallyOutMapEvent(PartyBase attackerParty, PartyBase defenderParty)
	{
		MapEvent mapEvent = new MapEvent();
		mapEvent.Initialize(attackerParty, defenderParty, null, MapEvent.BattleTypes.SallyOut);
		OnMapEventCreated(mapEvent);
		return mapEvent;
	}

	public MapEvent StartSiegeOutsideMapEvent(PartyBase attackerParty, PartyBase defenderParty)
	{
		MapEvent mapEvent = new MapEvent();
		mapEvent.Initialize(attackerParty, defenderParty, null, MapEvent.BattleTypes.SiegeOutside);
		OnMapEventCreated(mapEvent);
		return mapEvent;
	}
}