using System;

namespace TaleWorlds.MountAndBlade.Diamond;

[Serializable]
public class ClanInfo
{
	public Guid ClanId { get; private set; }

	public string Name { get; private set; }

	public string Tag { get; private set; }

	public string Faction { get; private set; }

	public string Sigil { get; private set; }

	public string InformationText { get; private set; }

	public ClanPlayer[] Players { get; private set; }

	public ClanAnnouncement[] Announcements { get; private set; }

	public ClanInfo(Guid clanId, string name, string tag, string faction, string sigil, string information, ClanPlayer[] players, ClanAnnouncement[] announcements)
	{
		ClanId = clanId;
		Name = name;
		Tag = tag;
		Faction = faction;
		Sigil = sigil;
		Players = players;
		InformationText = information;
		Announcements = announcements;
	}

	public static ClanInfo CreateUnavailableClanInfo()
	{
		return new ClanInfo(Guid.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, new ClanPlayer[0], new ClanAnnouncement[0]);
	}
}
