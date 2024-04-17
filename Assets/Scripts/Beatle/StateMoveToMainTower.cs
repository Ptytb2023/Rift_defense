using Cysharp.Threading.Tasks;
using RiftDefense.Edifice.Tower;
using RiftDefense.FSM;
using RiftDefense.Generic.Interface;
using System;
using System.Threading.Tasks;
using UnityEngine;
using static Lean.Pool.LeanGameObjectPool;

public class StateMoveToMainTower : BaseState
{
    protected BaseBeatle _beatle;
    protected BaseBeatleView _beatleView => _beatle.BaseBeatleView;
    protected ITargetSystem<ITower> TargetSystem => _beatle.TargetSystem;
    private MovableBeatle _movable => _beatle.MovableBeatle;


    private ITower CurrentTarget => _beatle.CurrentTarget;
    protected float Delay;

    public StateMoveToMainTower(BaseBeatle beatleBase
        ) : base(beatleBase)
    {
        _beatle = beatleBase;
    }

    public override void Enter()
    {
        _beatle.CurrentTarget = null;
        _movable.SetTargetToMove(_beatleView.Destination);
    }

    public override void Exit()
    {
        _movable.StopMove();
    }


    public override void Update()
    {
        if (Delay > 0)
        {
            Delay -= Time.deltaTime;
            return;
        }

        if (TargetSystem.TryGetClosestTargetInRadius(out ITower tower))
        {
            _beatle.CurrentTarget = tower;
            NextState();
            return;
        }
        else
        {
            Delay = _beatleView.DataAttackBeatle.DelayBetweenSearch;
        }
    }

    private void NextState()
    {
        StateMachine.SetState(typeof(StateMoveToTarget));
    }
}
