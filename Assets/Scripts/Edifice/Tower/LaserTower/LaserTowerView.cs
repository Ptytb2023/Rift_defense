using Lean.Pool;
using RiftDefense.Beatle;
using RiftDefense.Edifice.Tower.Model;
using RiftDefense.Edifice.Tower.View;
using RiftDefense.Generic.Interface;
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

        private LaserTower _laserTower;

        private void Awake()
        {
            _laserTower = new LaserTower(this);
        }

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
            _laserTower.SetActive(true);
        }

        public override void OnDespawn()
        {
            base.OnDespawn();
            _laserTower.SetActive(false);

        }
        
    }
}