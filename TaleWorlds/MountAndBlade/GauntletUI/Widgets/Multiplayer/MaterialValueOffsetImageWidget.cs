using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.BaseTypes;

namespace TaleWorlds.MountAndBlade.GauntletUI.Widgets.Multiplayer;

public class MaterialValueOffsetImageWidget : ImageWidget
{
	private bool _visualDirty;

	private float _valueOffset;

	private float _saturationOffset;

	private float _hueOffset;

	public float ValueOffset
	{
		get
		{
			return _valueOffset;
		}
		set
		{
			_valueOffset = value;
			_visualDirty = true;
		}
	}

	public float SaturationOffset
	{
		get
		{
			return _saturationOffset;
		}
		set
		{
			_saturationOffset = value;
			_visualDirty = true;
		}
	}

	public float HueOffset
	{
		get
		{
			return _hueOffset;
		}
		set
		{
			_hueOffset = value;
			_visualDirty = true;
		}
	}

	public MaterialValueOffsetImageWidget(UIContext context)
		: base(context)
	{
	}

	protected override void OnLateUpdate(float dt)
	{
		base.OnLateUpdate(dt);
		if (!_visualDirty)
		{
			return;
		}
		foreach (Style style in base.Brush.Styles)
		{
			foreach (StyleLayer layer in style.Layers)
			{
				layer.ValueFactor += ValueOffset;
				layer.SaturationFactor += SaturationOffset;
				layer.HueFactor += HueOffset;
			}
		}
		_visualDirty = false;
	}
}
