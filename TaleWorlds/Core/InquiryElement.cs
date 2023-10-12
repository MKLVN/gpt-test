namespace TaleWorlds.Core;

public class InquiryElement
{
	public readonly string Title;

	public readonly ImageIdentifier ImageIdentifier;

	public readonly object Identifier;

	public readonly bool IsEnabled;

	public readonly string Hint;

	public InquiryElement(object identifier, string title, ImageIdentifier imageIdentifier)
	{
		Identifier = identifier;
		Title = title;
		ImageIdentifier = imageIdentifier;
		IsEnabled = true;
		Hint = null;
	}

	public InquiryElement(object identifier, string title, ImageIdentifier imageIdentifier, bool isEnabled, string hint)
	{
		Identifier = identifier;
		Title = title;
		ImageIdentifier = imageIdentifier;
		IsEnabled = isEnabled;
		Hint = hint;
	}

	public bool HasSameContentWith(object other)
	{
		if (other is InquiryElement inquiryElement)
		{
			if (Title == inquiryElement.Title && ImageIdentifier.Equals(inquiryElement.ImageIdentifier) && Identifier == inquiryElement.Identifier && IsEnabled == inquiryElement.IsEnabled)
			{
				return Hint == inquiryElement.Hint;
			}
			return false;
		}
		return false;
	}
}
