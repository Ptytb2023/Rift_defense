using Cysharp.Threading.Tasks;
using RiftDefense.Edifice.Tower;
using RiftDefense.FSM;
using RiftDefense.Generic.Interface;
using System;
using System.Threading.Tasks;

public abstract class BaseBeatleAttack : BaseState
{
    protected BaseBeatle BaseBeatle;
    protected ITargetSystem<ITower> TargetSystem => BaseBeatle.TargetSystem;
    protected BaseBeatleView BeatleView => BaseBeatle.BaseBeatleView;

    protected MovableBeatle Moveble => BaseBeatle.MovableBeatle;

    protected ITower CurrentTarget => BaseBeatle.CurrentTarget;

    protected BaseBeatleAttack(BaseBeatle stateMachine)
        : base(stateMachine)
    {
        BaseBeatle = stateMachine;
    }

    protected abstract void PerfomAttack();

    public override void Enter()
    {
        Moveble.StopMove();
        Moveble.SetActiveObstacel(true);

        PerfomAttack();
    }

    public override void Exit()
    {
        BaseBeatle.CurrentTarget = null;
        Moveble.SetActiveObstacel(false);
    }

    protected async Task PerformDelay(float second)
    {
        var delay = TimeSpan.FromSeconds(second);
        await UniTask.Delay(delay, DelayType.DeltaTime, PlayerLoopTiming.Update);
    }
}
