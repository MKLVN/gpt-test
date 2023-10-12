using System;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.MountAndBlade.Diamond;

[Serializable]
public class ClanAnnouncement
{
	public int Id { get; private set; }

	public string Announcement { get; private set; }

	public PlayerId AuthorId { get; private set; }

	public DateTime CreationTime { get; private set; }

	public ClanAnnouncement(int id, string announcement, PlayerId authorId, DateTime creationTime)
	{
		Id = id;
		Announcement = announcement;
		AuthorId = authorId;
		CreationTime = creationTime;
	}
}
