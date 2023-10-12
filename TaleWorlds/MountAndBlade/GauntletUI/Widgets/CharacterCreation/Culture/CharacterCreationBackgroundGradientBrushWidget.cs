using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.GauntletUI.Widgets.CharacterCreation.Culture;

public class CharacterCreationBackgroundGradientBrushWidget : BrushWidget
{
	private Color _cultureColor1;

	[Editor(false)]
	public Color CultureColor1
	{
		get
		{
			return _cultureColor1;
		}
		set
		{
			if (_cultureColor1 != value)
			{
				_cultureColor1 = value;
				OnPropertyChanged(value, "CultureColor1");
				SetCultureBackground(value);
			}
		}
	}

	public CharacterCreationBackgroundGradientBrushWidget(UIContext context)
		: base(context)
	{
	}

	private void SetCultureBackground(Color cultureColor1)
	{
		foreach (Style style in base.Brush.Styles)
		{
			foreach (StyleLayer layer in style.Layers)
			{
				layer.Color = cultureColor1;
			}
		}
	}
}
