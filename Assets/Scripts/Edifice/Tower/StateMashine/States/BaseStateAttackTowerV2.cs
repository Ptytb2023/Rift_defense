using Cysharp.Threading.Tasks;
using RiftDefense.Beatle;
using RiftDefense.Edifice.Tower.FSM;
using RiftDefense.FSM;
using RiftDefense.Generic.Interface;
using System;
using System.Threading.Tasks;

public abstract class BaseStateAttackTowerV2 : BaseState
{
    private ITargetSystem<IBeatle> _targetSystem;

    protected IBeatle CurrentTarget;
    protected bool IsLiveTarget => CurrentTarget.Enabel;

    public BaseStateAttackTowerV2(StateMachine stateMachine,
        ITargetSystem<IBeatle> targetSystem)
        : base(stateMachine)
    {
        _targetSystem = targetSystem;
    }

    protected abstract void PerfomAttack();



    protected async Task PerformDelay(float second)
    {
        var delay = TimeSpan.FromSeconds(second);
        await UniTask.Delay(delay, DelayType.DeltaTime, PlayerLoopTiming.Update);
    }

    protected bool TrySetTarget()
    {
        if (!_targetSystem.TryGetClosestTargetInRadius(out IBeatle beatle))
            return false;

        CurrentTarget = beatle;
        return true;
    }

    protected void NextState()
    {
        StateMachine.SetState(typeof(StateSearchTargetTower));
    }

    protected bool TrySetStartAttackOrOverGoNextState()
    {
        if (!TrySetTarget())
        {
            NextState();
            return false;
        }
        
        PerfomAttack();
        return true;
    }
}
