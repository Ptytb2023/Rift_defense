using Cysharp.Threading.Tasks;
using RiftDefense.Beatle;
using RiftDefense.Edifice.Tower.FSM;
using RiftDefense.FSM;
using RiftDefense.Generic.Interface;
using System;
using System.Threading.Tasks;

public abstract class BaseStateAttackTower : BaseState
{
    private ITargetSystem<IBeatle> _targetSystem;

    protected IBeatle CurrentTarget;
    protected bool IsLiveTarget => CurrentTarget.Enabel;

    public BaseStateAttackTower(StateMachine stateMachine,
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

    

    protected void NextState()
    {
        if (!Enabel)
            return;
        StateMachine.SetState(typeof(StateSearchTargetTower));
    }

    protected bool TrySetTargetOrOverGoNextState()
    {
        if (!_targetSystem.TryGetClosestTargetInRadius(out IBeatle beatle))
        {
            NextState();
            return false;
        }

        CurrentTarget = beatle;
        return true;
    }
}
