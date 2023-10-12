using System;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;

namespace SandBox.Objects.AnimationPoints;

public class PlayMusicPoint : AnimationPoint
{
	private InstrumentData _instrumentData;

	private SoundEvent _trackEvent;

	private bool _hasInstrumentAttached;

	protected override void OnInit()
	{
		base.OnInit();
		KeepOldVisibility = true;
		base.IsDisabledForPlayers = true;
		SetScriptComponentToTick(GetTickRequirement());
	}

	public void StartLoop(SoundEvent trackEvent)
	{
		_trackEvent = trackEvent;
		if (base.HasUser && MBActionSet.CheckActionAnimationClipExists(base.UserAgent.ActionSet, LoopStartActionCode))
		{
			base.UserAgent.SetActionChannel(0, LoopStartActionCode, ignorePriority: true, 0uL);
		}
	}

	public void EndLoop()
	{
		if (_trackEvent != null)
		{
			_trackEvent = null;
			ChangeInstrument(null);
		}
	}

	public override TickRequirement GetTickRequirement()
	{
		if (base.HasUser)
		{
			return TickRequirement.Tick | base.GetTickRequirement();
		}
		return base.GetTickRequirement();
	}

	protected override void OnTick(float dt)
	{
		base.OnTick(dt);
		if (_trackEvent != null && base.HasUser && MBActionSet.CheckActionAnimationClipExists(base.UserAgent.ActionSet, LoopStartActionCode))
		{
			base.UserAgent.SetActionChannel(0, LoopStartActionCode, _hasInstrumentAttached, 0uL);
		}
	}

	public override void OnUseStopped(Agent userAgent, bool isSuccessful, int preferenceIndex)
	{
		base.OnUseStopped(userAgent, isSuccessful, preferenceIndex);
		DefaultActionCode = ActionIndexCache.act_none;
		EndLoop();
	}

	public void ChangeInstrument(Tuple<InstrumentData, float> instrument)
	{
		InstrumentData instrumentData = instrument?.Item1;
		if (_instrumentData == instrumentData)
		{
			return;
		}
		_instrumentData = instrumentData;
		if (!base.HasUser || !base.UserAgent.IsActive())
		{
			return;
		}
		if (base.UserAgent.IsSitting())
		{
			LoopStartAction = ((instrumentData == null) ? "act_sit_1" : instrumentData.SittingAction);
		}
		else
		{
			LoopStartAction = ((instrumentData == null) ? "act_stand_1" : instrumentData.StandingAction);
		}
		ActionSpeed = instrument?.Item2 ?? 1f;
		SetActionCodes();
		ClearAssignedItems();
		base.UserAgent.SetActionChannel(0, LoopStartActionCode, ignorePriority: false, (ulong)base.UserAgent.GetCurrentActionPriority(0));
		if (_instrumentData == null)
		{
			return;
		}
		foreach (var instrumentEntity in _instrumentData.InstrumentEntities)
		{
			ItemForBone newItem = new ItemForBone(instrumentEntity.Item1, instrumentEntity.Item2, isVisible: true);
			AssignItemToBone(newItem);
		}
		AddItemsToAgent();
		_hasInstrumentAttached = !_instrumentData.IsDataWithoutInstrument;
	}
}
