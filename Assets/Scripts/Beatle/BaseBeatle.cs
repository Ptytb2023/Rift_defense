using RiftDefense.Edifice.Tower;
using RiftDefense.FSM;
using RiftDefense.Generic;
using UnityEngine;

[RequireComponent(typeof(BaseBeatleView))]
public class BaseBeatle : StateMachine
{
    public BaseBeatleView BaseBeatleView { get; private set; }
    public ITower CurrentTarget { get; set; }
    public TargetSystem<ITower> TargetSystem { get; private set; }
    public MovableBeatle MovableBeatle { get; private set; }


    protected StateMoveToMainTower StateMoveToMainTower;

    protected virtual void Awake()
    {
        BaseBeatleView = GetComponent<BaseBeatleView>();

        var radius = BaseBeatleView.DataAttackBeatle.RadiusSearch;
        var layerMask = BaseBeatleView.DataAttackBeatle.EnemyMask;

        TargetSystem = new TargetSystem<ITower>(transform, BaseBeatleView , radius, layerMask);

        var navMehsAgent = BaseBeatleView.DataMoveBeatle.NavMeshAgent;
        var navMehsObstacel = BaseBeatleView.DataMoveBeatle.NavMeshObstacel;

        MovableBeatle = new MovableBeatle(navMehsAgent, navMehsObstacel, BaseBeatleView);

        StateMoveToMainTower = new StateMoveToMainTower(this);

        AddState(StateMoveToMainTower);

        StartState = StateMoveToMainTower;
    }
}
