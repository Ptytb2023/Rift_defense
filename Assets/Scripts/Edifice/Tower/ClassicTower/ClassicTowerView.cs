using Lean.Pool;
using RiftDefense.Beatle;
using RiftDefense.Edifice.Tower.FSM;
using RiftDefense.Edifice.Tower.Model;
using RiftDefense.Edifice.Tower.View;
using UnityEngine;


public class ClassicTowerView : BaseTowerView
{
    [SerializeField] private DataAttackClassic _dattaAttackClssic;
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _pointShoot;
    [SerializeField] private ParticleSystem _shootEfect;

    private ClassicTower _clasicTower;

    public DataAttackClassic DataAttackClassic => _dattaAttackClssic;

    private Coroutine _looking;



    public override void PreviewAtack(IBeatle enemy)
    {
        var ise = LeanPool.Spawn(_shootEfect, _pointShoot.position, _pointShoot.rotation);
        LeanPool.Despawn(ise, DataAttack.DelayBetweenShots / 2f);
    }

}
