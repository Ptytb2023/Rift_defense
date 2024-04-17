using Cysharp.Threading.Tasks;
using RiftDefense.Edifice.Tower;
using RiftDefense.FSM;
using RiftDefense.Generic.Interface;
using System;
using System.Threading.Tasks;

public class StateMoveToMainTower : BaseState
{
    protected BaseBeatle _beatle;
    protected BaseBeatleView _beatleView => _beatle.BaseBeatleView;
    protected ITargetSystem<ITower> TargetSystem => _beatle.TargetSystem;
    private MovableBeatle _movable => _beatle.MovableBeatle;

    public StateMoveToMainTower(BaseBeatle beatleBase
        ) : base(beatleBase)
    {
        _beatle = beatleBase;
    }

    public override void Enter()
    {
        _beatle.CurrentTarget = null;
        _movable.SetTargetToMove(_beatleView.Destination);
        SearchNewTarget();
    }

    public override void Exit()
    {
        _movable.StopMove();
    }

    private async void SearchNewTarget()
    {
        await UniTask.Yield(PlayerLoopTiming.Update);
        var second = _beatleView.DataAttackBeatle.DelayBetweenSearch;

        while (Enabel && _beatle.CurrentTarget == null)
        {
            if (TargetSystem.TryGetClosestTargetInRadius(out ITower tower))
            {
                _beatle.CurrentTarget = tower;
                NextState();
                return;
            }

            await PerformDelay(second);
        }
    }

    private void NextState()
    {
        StateMachine.SetState(typeof(StateMoveToTarget));
    }

    protected async Task PerformDelay(float second)
    {
        var delay = TimeSpan.FromSeconds(second);
        await UniTask.Delay(delay, DelayType.DeltaTime, PlayerLoopTiming.Update);
    }
}
