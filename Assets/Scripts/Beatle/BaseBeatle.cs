using RiftDefense.Edifice.Tower;
using RiftDefense.FSM;
using RiftDefense.Generic;

public class BaseBeatle : StateMachine
{
    public BaseBeatleView BaseBeatleView { get; private set; }
    public ITower CurrentTarget { get; set; }
    public TargetSystem<ITower> TargetSystem { get; private set; }
    public MovableBeatle MovableBeatle { get; private set; }

    protected StateMoveToMainTower StateMoveToMainTower;

    public BaseBeatle(BaseBeatleView baseView)
    {
        BaseBeatleView = baseView;

        var transform = baseView.transform;
        var radius = baseView.DataAttackBeatle.RadiusSearch;
        var layerMask = baseView.DataAttackBeatle.EnemyMask;

        TargetSystem = new TargetSystem<ITower>(transform, radius, layerMask);

        var navMehsAgent = baseView.DataMoveBeatle.NavMeshAgent;
        var navMehsObstacel = baseView.DataMoveBeatle.NavMeshObstacel;

        MovableBeatle = new MovableBeatle(navMehsAgent, navMehsObstacel);

        StateMoveToMainTower = new StateMoveToMainTower(this);

        AddState(StateMoveToMainTower);

        StartState = StateMoveToMainTower;
    }

}
