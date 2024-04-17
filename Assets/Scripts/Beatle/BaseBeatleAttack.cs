using RiftDefense.Edifice.Tower;
using RiftDefense.FSM;
using RiftDefense.Generic.Interface;
using UnityEngine;

public abstract class BaseBeatleAttack : BaseState
{
    protected BaseBeatle BaseBeatle;
    protected ITargetSystem<ITower> TargetSystem => BaseBeatle.TargetSystem;
    protected BaseBeatleView BeatleView => BaseBeatle.BaseBeatleView;

    protected MovableBeatle Moveble => BaseBeatle.MovableBeatle;

    protected ITower CurrentTarget => BaseBeatle.CurrentTarget;
    protected float Delay;


    protected BaseBeatleAttack(BaseBeatle stateMachine)
        : base(stateMachine)
    {
        BaseBeatle = stateMachine;
    }

    protected abstract void PerfomAttack();

    public override void Enter()
    {
        Moveble.SetActiveObstacel(true);
    }

    public override void Exit()
    {
        BaseBeatle.CurrentTarget = null;
        Moveble.SetActiveObstacel(false);
    }

    public override void Update()
    {
        if (Delay > 0)
        {
            Delay -= Time.deltaTime;
            return;
        }
        if (!CurrentTarget.Enabel)
        {
            StateMachine.SetState(typeof(StateMoveToMainTower));
        }

        PerfomAttack();

        Delay = BeatleView.DataAttackBeatle.DelayBetweenAttack;
    }




}
