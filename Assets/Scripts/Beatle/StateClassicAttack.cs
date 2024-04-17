
public class StateClassicAttack : BaseBeatleAttack
{
    private float demage => BeatleView.DataAttackBeatle.Damage;

    public StateClassicAttack(BaseBeatle stateMachine) :
        base(stateMachine)
    {
    }

    protected override  void PerfomAttack()
    {
        BeatleView.PrewiewAtack();
        CurrentTarget.ApplyDamage(demage);
    }
}
