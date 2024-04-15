using RiftDefense.Beatle;
using RiftDefense.Edifice.Tower.FSM;
using RiftDefense.Edifice.Tower.Model;
using RiftDefense.Edifice.Tower.View;
using RiftDefense.Generic.Interface;
using System.Collections;
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

    private void Awake()
    {
        _clasicTower = new ClassicTower(this);
    }

    public override void OnDespawn()
    {
        base.OnDespawn();
        _clasicTower.SetActive(false);

    }

    public override void OnSpawn()
    {
        base.OnSpawn();
        _clasicTower.SetActive(true);
    }
  

    public override void PreviewAtack(IEnemy enemy)
    {
        if (_shootEfect != null)
            Instantiate(_shootEfect, _pointShoot.position, _pointShoot.rotation);
    }

    public void LookAttarget(IBeatle beatle, bool active)
    {
        if (active)
        {
            StopLooking();
            _looking = StartCoroutine(LookAtTarget(beatle));
        }
        else
            StopLooking();
    }

    private void StopLooking()
    {
        if (_looking != null)
            StopCoroutine(_looking);
    }

    private IEnumerator LookAtTarget(IBeatle beatle)
    {
        while (enabled)
        {
            var direction = beatle.GetPosition() - _head.position;
            Quaternion newRotation = Quaternion.LookRotation(direction);

            _head.rotation = Quaternion.Slerp(_head.rotation, newRotation, _speedLookAtTarget);

            yield return null;
        }
    }

   
}
