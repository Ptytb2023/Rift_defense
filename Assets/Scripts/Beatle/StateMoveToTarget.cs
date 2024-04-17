using RiftDefense.Edifice.Tower;
using RiftDefense.FSM;
using RiftDefense.Generic.Interface;
using System;
using UnityEngine;

public class StateMoveToTarget : BaseState
{
    protected BaseBeatle BaseBeatle;
    protected ITargetSystem<ITower> TargetSystem => BaseBeatle.TargetSystem;
    protected BaseBeatleView BeatleView => BaseBeatle.BaseBeatleView;
    protected MovableBeatle _movableBeatle => BaseBeatle.MovableBeatle;

    private Type _nextState;

    private Transform _pointAttack => BeatleView.DataAttackBeatle.pointAttack;
    private float _radiusAttack => BeatleView.DataAttackBeatle.radiusPointAttack;
    private float _diastanceAttack => BeatleView.DataAttackBeatle.AttackDistance;
    private LayerMask _maskEnemy => BeatleView.DataAttackBeatle.EnemyMask;
    private Collider[] _colliders;


    protected ITower CurrentTarget => BaseBeatle.CurrentTarget;

    public StateMoveToTarget(BaseBeatle baseBeatle, Type nextState)
                                 : base(baseBeatle)
    {
        BaseBeatle = baseBeatle;

        _nextState = nextState;
    }

    public override void Enter()
    {
        _movableBeatle.SetActiveQuality(false);
        _movableBeatle.SetTargetToMove(BaseBeatle.CurrentTarget.GetPosition(), _diastanceAttack);
    }

    public override void Exit()
    {
        _movableBeatle.SetActiveQuality(true);
        _movableBeatle.StopMove();
    }

    public override void Update()
    {
        if (CurrentTarget.Enabel)
        {
            if (TryRechDestination())
            {
                StateMachine.SetState(_nextState);
                return;
            }
        }
        else
            StateMachine.SetState(_nextState);
    }


    private bool TryRechDestination()
    {
        _colliders = Physics.OverlapSphere(_pointAttack.position,
            _radiusAttack,
            _maskEnemy.value);

        foreach (var collider in _colliders)
        {
            if(collider.TryGetComponent(out ITower tower))
                if(tower==CurrentTarget)
                    return true;
        }

        return false;
    }


}
