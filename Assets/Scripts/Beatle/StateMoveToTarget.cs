using Cysharp.Threading.Tasks;
using RiftDefense.Edifice.Tower;
using RiftDefense.FSM;
using RiftDefense.Generic.Interface;
using System;

public class StateMoveToTarget : BaseState
{
    protected BaseBeatle BaseBeatle;
    protected ITargetSystem<ITower> TargetSystem => BaseBeatle.TargetSystem;
    protected BaseBeatleView BeatleView => BaseBeatle.BaseBeatleView;
    protected MovableBeatle _movableBeatle => BaseBeatle.MovableBeatle;

    private Type _nextState;

    ITower _target => BaseBeatle.CurrentTarget;

    public StateMoveToTarget(BaseBeatle baseBeatle, Type nextState)
                                 : base(baseBeatle)
    {
        BaseBeatle = baseBeatle;

        _nextState = nextState;
    }

    public override void Enter()
    {
        if (!_target.Enabel)
            NextStateMoveToMainTower();
        else
            Move();
    }

    public override void Exit()
    {
        _movableBeatle.StopMove();
    }

    private async void Move()
    {
        float distanceAttack = BeatleView.DataAttackBeatle.AttackDistance;
        _movableBeatle.SetTargetToMove(BaseBeatle.CurrentTarget.GetPosition(), distanceAttack);

        while (Enabel && _target.Enabel)
        {
            if (_movableBeatle.TryReachDestination(distanceAttack))
            {
                StateMachine.SetState(_nextState);
                return;
            }

            await UniTask.Yield(PlayerLoopTiming.FixedUpdate);
        }

        if (Enabel)
            NextStateMoveToMainTower();
    }


    protected void NextStateMoveToMainTower()
    {
        StateMachine.SetState(typeof(StateMoveToMainTower));
    }
}
