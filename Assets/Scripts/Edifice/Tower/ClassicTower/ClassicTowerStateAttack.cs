using RiftDefense.Beatle;
using RiftDefense.Edifice.Tower.FSM;
using RiftDefense.Generic.Interface;
using System.Threading.Tasks;

public class ClassicTowerStateAttack : BaseStateAttackTower
{

    private ClassicTowerView _classicTowerView;

    private float _damage => TowerView.DataAtack.Damage;
    private int _maxAmout => TowerView.DataAtack.AmountAmmunition;

    private int _currentAmount;

    public ClassicTowerStateAttack(ClassicTower stateMashine,
                                   ClassicTowerView baseTowerView,
                                   ITargetSystem<IBeatle> targetSystem) :
        base(stateMashine, baseTowerView, targetSystem)
    {
        _classicTowerView = baseTowerView;
        _currentAmount = _maxAmout;
    }

   

    protected override async Task PerfomAttack()
    {
        _classicTowerView.LookAttarget(CurrentTarget, true);

        TowerView.PreviewAtack(CurrentTarget);

        CurrentTarget.ApplyDamage(_damage);
        _currentAmount--;

        if (_currentAmount <= 0)
            await Reload();
    }

    public override void Exit()
    {
        base.Exit();

        _classicTowerView.LookAttarget(CurrentTarget, false);
    }

    private async Task Reload()
    {
        float timeReload = TowerView.DataAtack.TimeReload;
        await PerformDelay(timeReload);
    }

}
