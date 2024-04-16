public class ClassicBeatleV2 : BaseBeatle
{
    public ClassicBeatleV2(BaseBeatleView baseView)
        : base(baseView)
    {
        var stateClassicAttack = new StateClassicAttack(this);
        var stateMoveToTarget = new StateMoveToTarget(this,typeof(StateClassicAttack));

        AddState(stateClassicAttack);
        AddState(stateMoveToTarget);
    }

}
