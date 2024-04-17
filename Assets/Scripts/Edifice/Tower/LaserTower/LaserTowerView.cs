using Lean.Pool;
using RiftDefense.Beatle;
using RiftDefense.Edifice.Tower.Model;
using RiftDefense.Edifice.Tower.View;
using System.Collections;
using UnityEngine;


namespace RiftDefense.Edifice.Tower
{
    public class LaserTowerView : BaseTowerView
    {
        [SerializeField] private DataAttackLaser _dataLaserTower;
        [SerializeField] private Material _materialSphereShoot;
        [SerializeField] private Color _colorReload;

        public DataAttackLaser DataAttackLaser => _dataLaserTower;

        private Coroutine _trackingBeam;
        private const int _indexEndBeam = 1;


        public void TurnOnBeam(IBeatle enemy)
        {
            TurnOffBeam();

            _dataLaserTower.Beam.enabled = true;

            _trackingBeam = StartCoroutine(TrackingTarget(enemy));
        }

        public void TurnOffBeam()
        {
            _dataLaserTower.Beam.enabled = false;

            if (_trackingBeam != null)
                StopCoroutine(_trackingBeam);
        }

        private IEnumerator TrackingTarget(IBeatle enemy)
        {
            var beam = _dataLaserTower.Beam;
            var spherePoint = _dataLaserTower.SpherePoint;

            beam.SetPosition(0, spherePoint.position);

            while (gameObject.activeSelf)
            {
                beam.SetPosition(_indexEndBeam, enemy.GetPosition());
                yield return new WaitForFixedUpdate();
            }
        }


        public override void PreviewAtack(IBeatle enemy)
        {
            var efect = LeanPool.Spawn(DataAttackLaser.EffectLaserHit);
            efect.Init(enemy);
        }

        public void PreviewReload(float secondReload)
        {
            //StartCoroutine(Reload(secondReload));
        }
      

        private IEnumerator Reload(float secondReload)
        {
            var oldColor = _materialSphereShoot.color;
            _materialSphereShoot.color = _colorReload;

            yield return new WaitForSeconds(secondReload);

            _materialSphereShoot.color = oldColor;
        }

        public override void OnSpawn()
        {
            base.OnSpawn();
        }

        protected override void OnDead()
        {
            base.OnDead();
            TurnOffBeam();
        }
    }
}