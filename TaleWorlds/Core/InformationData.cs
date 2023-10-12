using System.Collections.Generic;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.Core;

public abstract class InformationData
{
	[SaveableField(2)]
	public readonly TextObject DescriptionText;

	public abstract TextObject TitleText { get; }

	public abstract string SoundEventPath { get; }

	protected virtual void AutoGeneratedInstanceCollectObjects(List<object> collectedObjects)
	{
		collectedObjects.Add(DescriptionText);
	}

	internal static object AutoGeneratedGetMemberValueDescriptionText(object o)
	{
		return ((InformationData)o).DescriptionText;
	}

	protected InformationData(TextObject description)
	{
		DescriptionText = description;
	}

	public virtual bool IsValid()
	{
		return true;
	}
}