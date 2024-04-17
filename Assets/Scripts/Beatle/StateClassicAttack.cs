using RiftDefense.FSM;

public class StateClassicAttack : BaseBeatleAttack
{
    public StateClassicAttack(BaseBeatle stateMachine) :
        base(stateMachine)
    {
    }

    protected override async void PerfomAttack()
    {
        var demage = BeatleView.DataAttackBeatle.Damage;
        var delayBetweenAttack = BeatleView.DataAttackBeatle.DelayBetweenAttack;

        while (Enabel && CurrentTarget != null && CurrentTarget.Enabel)
        {
            BeatleView.PrewiewAtack();
            CurrentTarget.ApplyDamage(demage);
            
            await PerformDelay(delayBetweenAttack);
        }

        if (Enabel)
            StateMachine.SetState(typeof(StateMoveToMainTower));
    }
}
