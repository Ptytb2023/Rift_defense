using RiftDefense.Beatle;
using RiftDefense.Edifice.Tower.FSM;
using UnityEngine;

public class ClassicTowerStateAttack : BaseStateAttackTower
{
    private ClassicTower _classicTower;
    private ClassicTowerView _classicTowerView => _classicTower.classicTowerView;

    private float _damage => _classicTowerView.DataAttack.Damage;
    private int _maxAmout => _classicTowerView.DataAttackClassic.AmountAmmunition;

    private int _currentAmount;

    public ClassicTowerStateAttack(ClassicTower classicTower) : base(classicTower)
    {
        _classicTower = classicTower;
        _currentAmount = _maxAmout;
    }

    public override void Enter()
    {
        base.Enter();

        if (CurrentTarget != null && CurrentTarget.Enabel)
                  NewTarget += OnNewTarget;


        _classicTowerView.LookingAtEnemy(CurrentTarget,true);
    }

    public override void Exit()
    {
        base.Exit();

        NewTarget -= OnNewTarget;

        _classicTowerView.LookingAtEnemy(CurrentTarget, false);
    }

    protected  override void PerfomAttack()
    {
        Debug.Log("Attack Mini");
        _classicTowerView.PreviewAtack(CurrentTarget);

        CurrentTarget.ApplyDamage(_damage);
        _currentAmount--;

        if (_currentAmount <= 0)
             Reload();
    }

    private void  Reload()
    {
        Delay = _classicTowerView.DataAttack.TimeReload;
        _currentAmount = _maxAmout;
    }


    private void OnNewTarget()
    {
        _classicTowerView.LookingAtEnemy(CurrentTarget, true);
    }
}
