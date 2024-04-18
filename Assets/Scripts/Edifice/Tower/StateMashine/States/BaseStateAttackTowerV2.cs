using Cysharp.Threading.Tasks;
using RiftDefense.Beatle;
using RiftDefense.Edifice.Tower;
using RiftDefense.Edifice.Tower.FSM;
using RiftDefense.Edifice.Tower.View;
using RiftDefense.FSM;
using RiftDefense.Generic.Interface;
using System;
using UnityEngine;

public abstract class BaseStateAttackTower : BaseState
{
    protected BaseTower BaseTower;

    protected ITargetSystem<IBeatle> TargetSystem => BaseTower.TargetSystem;
    protected BaseTowerView TowerView => BaseTower.towerView;

    protected float Delay;

    protected IBeatle CurrentTarget => BaseTower.CurrentTarget;


    protected event Action NewTarget;

    public BaseStateAttackTower(BaseTower baseTower)
        : base(baseTower)
    {
        BaseTower = baseTower;
    }

    protected abstract void PerfomAttack();

    public override void Enter()
    {
        if (CurrentTarget == null || CurrentTarget.Enabel == false)
            TrySetTargetOrOverGoNextState();
        Debug.Log($"Enter {typeof(BaseStateAttackTower)}");
    }

    public override void Exit()
    {
        Debug.Log($" Eixt {typeof(BaseStateAttackTower)}");
    }

    protected void NextState()
    {
        StateMachine.SetState(typeof(StateSearchTargetTower));
    }

    protected bool TrySetTargetOrOverGoNextState()
    {
        if (!TargetSystem.TryGetClosestTargetInRadius(out IBeatle beatle))
        {
            NextState();
            return false;
        }

        BaseTower.CurrentTarget = beatle;
        NewTarget?.Invoke();
        return true;
    }


    public override void Update()
    {
        if (!CurrentTarget.Enabel)
        {
            if (TrySetTargetOrOverGoNextState())
                return;
        }

        if (Delay > 0)
        {
            Delay -= Time.deltaTime;
            return;
        }

        PerfomAttack();

        Delay = TowerView.DataAttack.DelayBetweenShots;
    }
}
