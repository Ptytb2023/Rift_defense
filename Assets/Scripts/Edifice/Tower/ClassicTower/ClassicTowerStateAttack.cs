using RiftDefense.Beatle;
using RiftDefense.Edifice.Tower.FSM;
using RiftDefense.Generic.Interface;
using System.Threading.Tasks;

public class ClassicTowerStateAttack : BaseStateAttackTowerV2
{
    private ClassicTowerView _classicTowerView;

    private float _damage => _classicTowerView.DataAttack.Damage;
    private int _maxAmout => _classicTowerView.DataAttackClassic.AmountAmmunition;

    private int _currentAmount;

    public ClassicTowerStateAttack(ClassicTower stateMashine,
                                   ClassicTowerView baseTowerView,
                                   ITargetSystem<IBeatle> targetSystem) :
        base(stateMashine, targetSystem)
    {
        _classicTowerView = baseTowerView;
        _currentAmount = _maxAmout;
    }


    public override void Enter()
    {
        TrySetStartAttackOrOverGoNextState();
    }

    public override void Exit()
    {
        _classicTowerView.LookAttarget(CurrentTarget, false);
    }

    protected async override void  PerfomAttack()
    {
        _classicTowerView.LookAttarget(CurrentTarget, true);

        while (Enabel && IsLiveTarget)
        {
            _classicTowerView.PreviewAtack(CurrentTarget);

            CurrentTarget.ApplyDamage(_damage);
            _currentAmount--;

            if (_currentAmount <= 0)
                await Reload();
        }
    }

    private async Task Reload()
    {
        float timeReload = _classicTowerView.DataAttack.TimeReload;
        _currentAmount = _maxAmout;
        await PerformDelay(timeReload);
    }
 
}
