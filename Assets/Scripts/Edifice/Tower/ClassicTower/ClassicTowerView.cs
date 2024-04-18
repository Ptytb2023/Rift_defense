using Lean.Pool;
using RiftDefense.Beatle;
using RiftDefense.Edifice.Tower.FSM;
using RiftDefense.Edifice.Tower.Model;
using RiftDefense.Edifice.Tower.View;
using UnityEngine;


public class ClassicTowerView : BaseTowerView
{
    [SerializeField] private DataAttackClassic _dattaAttackClssic;

    [SerializeField] private float _speedLookAtTarget = 1f;
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _pointShoot;
    [SerializeField] private ParticleSystem _shootEfect;

    private ClassicTower _clasicTower;

    public DataAttackClassic DataAttackClassic => _dattaAttackClssic;

    private Coroutine _looking;


    public override void OnDespawn()
    {
        base.OnDespawn();

    }

    public override void OnSpawn()
    {
        base.OnSpawn();
    }


    public override void PreviewAtack(IBeatle enemy)
    {
        if (_shootEfect != null)
            LeanPool.Spawn(_shootEfect, _pointShoot.position, _pointShoot.rotation);
    }

}
