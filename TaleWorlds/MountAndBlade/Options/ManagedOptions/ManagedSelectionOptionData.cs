using System.Collections.Generic;
using TaleWorlds.Engine;
using TaleWorlds.Engine.Options;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.Options.ManagedOptions;

public class ManagedSelectionOptionData : ManagedOptionData, ISelectionOptionData, IOptionData
{
	private readonly int _selectableOptionsLimit;

	private readonly IEnumerable<SelectionData> _selectableOptionNames;

	public ManagedSelectionOptionData(TaleWorlds.MountAndBlade.ManagedOptions.ManagedOptionsType type)
		: base(type)
	{
		_selectableOptionsLimit = GetOptionsLimit(type);
		_selectableOptionNames = GetOptionNames(type);
	}

	public int GetSelectableOptionsLimit()
	{
		return _selectableOptionsLimit;
	}

	public IEnumerable<SelectionData> GetSelectableOptionNames()
	{
		return _selectableOptionNames;
	}

	public static int GetOptionsLimit(TaleWorlds.MountAndBlade.ManagedOptions.ManagedOptionsType optionType)
	{
		return optionType switch
		{
			TaleWorlds.MountAndBlade.ManagedOptions.ManagedOptionsType.TurnCameraWithHorseInFirstPerson => 4, 
			TaleWorlds.MountAndBlade.ManagedOptions.ManagedOptionsType.ReportCasualtiesType => 3, 
			TaleWorlds.MountAndBlade.ManagedOptions.ManagedOptionsType.AutoTrackAttackedSettlements => 3, 
			TaleWorlds.MountAndBlade.ManagedOptions.ManagedOptionsType.ControlBlockDirection => 3, 
			TaleWorlds.MountAndBlade.ManagedOptions.ManagedOptionsType.ControlAttackDirection => 3, 
			TaleWorlds.MountAndBlade.ManagedOptions.ManagedOptionsType.NumberOfCorpses => 6, 
			TaleWorlds.MountAndBlade.ManagedOptions.ManagedOptionsType.Language => LocalizedTextManager.GetLanguageIds(NativeConfig.IsDevelopmentMode).Count, 
			TaleWorlds.MountAndBlade.ManagedOptions.ManagedOptionsType.VoiceLanguage => LocalizedVoiceManager.GetVoiceLanguageIds().Count, 
			TaleWorlds.MountAndBlade.ManagedOptions.ManagedOptionsType.CrosshairType => 2, 
			TaleWorlds.MountAndBlade.ManagedOptions.ManagedOptionsType.OrderType => 2, 
			TaleWorlds.MountAndBlade.ManagedOptions.ManagedOptionsType.OrderLayoutType => 2, 
			TaleWorlds.MountAndBlade.ManagedOptions.ManagedOptionsType.BattleSize => 7, 
			TaleWorlds.MountAndBlade.ManagedOptions.ManagedOptionsType.ReinforcementWaveCount => 4, 
			TaleWorlds.MountAndBlade.ManagedOptions.ManagedOptionsType.UnitSpawnPrioritization => 4, 
			_ => 0, 
		};
	}

	private static IEnumerable<SelectionData> GetOptionNames(TaleWorlds.MountAndBlade.ManagedOptions.ManagedOptionsType type)
	{
		int l;
		switch (type)
		{
		case TaleWorlds.MountAndBlade.ManagedOptions.ManagedOptionsType.Language:
		{
			List<string> languageIds2 = LocalizedTextManager.GetLanguageIds(NativeConfig.IsDevelopmentMode);
			for (l = 0; l < languageIds2.Count; l++)
			{
				yield return new SelectionData(isLocalizationId: false, LocalizedTextManager.GetLanguageTitle(languageIds2[l]));
			}
			yield break;
		}
		case TaleWorlds.MountAndBlade.ManagedOptions.ManagedOptionsType.VoiceLanguage:
		{
			List<string> languageIds2 = LocalizedVoiceManager.GetVoiceLanguageIds();
			for (l = 0; l < languageIds2.Count; l++)
			{
				yield return new SelectionData(isLocalizationId: false, LocalizedTextManager.GetLanguageTitle(languageIds2[l]));
			}
			yield break;
		}
		}
		l = GetOptionsLimit(type);
		string typeName = type.ToString();
		for (int i = 0; i < l; i++)
		{
			yield return new SelectionData(isLocalizationId: true, "str_options_type_" + typeName + "_" + i);
		}
	}
}
