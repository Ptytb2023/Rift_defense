public class ClassicBeatle : BaseBeatle
{

    protected override void Awake()
    {
        base.Awake();

        var stateClassicAttack = new StateClassicAttack(this);
        var stateMoveToTarget = new StateMoveToTarget(this, typeof(StateClassicAttack));

        AddState(stateClassicAttack);
        AddState(stateMoveToTarget);
    }

}
