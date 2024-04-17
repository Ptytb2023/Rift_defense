public class ClassicBeatle : BaseBeatle
{
    public ClassicBeatle(BaseBeatleView baseView)
        : base(baseView)
    {
        var stateClassicAttack = new StateClassicAttack(this);
        var stateMoveToTarget = new StateMoveToTarget(this,typeof(StateClassicAttack));

        AddState(stateClassicAttack);
        AddState(stateMoveToTarget);
    }

}
