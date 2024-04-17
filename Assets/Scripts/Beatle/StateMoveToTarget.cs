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

    private float _diastanceAttack => BeatleView.DataAttackBeatle.AttackDistance;

    protected ITower CurrentTarget => BaseBeatle.CurrentTarget;

    public StateMoveToTarget(BaseBeatle baseBeatle, Type nextState)
                                 : base(baseBeatle)
    {
        BaseBeatle = baseBeatle;

        _nextState = nextState;
    }

    public override void Enter()
    {
        _movableBeatle.SetTargetToMove(BaseBeatle.CurrentTarget.GetPosition(), _diastanceAttack);
    }

    public override void Exit()
    {
        _movableBeatle.StopMove();
    }

    public override void Update()
    {
        if (CurrentTarget.Enabel)
            if (_movableBeatle.TryReachDestination(_diastanceAttack))
            {
                StateMachine.SetState(_nextState);
                return;
            }
            else
                StateMachine.SetState(typeof(StateMoveToMainTower));
    }
}
