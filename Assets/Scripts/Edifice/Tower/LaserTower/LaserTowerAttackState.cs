using RiftDefense.Beatle;
using RiftDefense.FSM;
using RiftDefense.Generic.Interface;
using System.Threading.Tasks;
using UnityEngine;

namespace RiftDefense.Edifice.Tower
{
    public class LaserTowerAttackState : BaseStateAttackTowerV2
    {
        private LaserTowerView _laserTowerView;

        private float _curentDurationSeries;
        private RaycastHit[] _hitInfo;

        private Transform _pointShoot => _laserTowerView.DataAttackLaser.SpherePoint;
        private float _delayBetweenShots => _laserTowerView.DataAttack.DelayBetweenShots;
        private LayerMask enemyMask => _laserTowerView.DataAttack.EnemyMask;


        public LaserTowerAttackState(StateMachine stateMashine,
                                      ITargetSystem<IBeatle> targetSystem,
                                      LaserTowerView laserTowerView) :
            base(stateMashine, targetSystem)
        {
            _laserTowerView = laserTowerView;

            _curentDurationSeries = _laserTowerView.DataAttackLaser.DurationSeries;
        }

        public override void Enter()
        {
            TrySetStartAttackOrOverGoNextState();
        }

        public override void Exit()
        {
            _laserTowerView.TurnOffBeam();
        }

        protected override async void PerfomAttack()
        {
            _laserTowerView.TurnOnBeam(CurrentTarget);

            while (Enabel && IsLiveTarget)
            {
                ReduceTime();
                HoldBeam();
                HitEnemy();

                await PerformDelay(_delayBetweenShots);

                if (_curentDurationSeries <= 0)
                    await Reload();
            }

            TrySetStartAttackOrOverGoNextState();
        }

        private void HoldBeam()
        {
            var directionAttack = _pointShoot.position - CurrentTarget.GetPosition();
            var distanceAttack = directionAttack.magnitude;

            _hitInfo = Physics.RaycastAll(_pointShoot.position, directionAttack, distanceAttack, enemyMask);
        }

        private void ReduceTime()
        {
            _curentDurationSeries -= Time.deltaTime;
            _curentDurationSeries -= _delayBetweenShots;
        }

        private async Task Reload(bool instant = false)
        {
            var secondReload = _laserTowerView.DataAttack.TimeReload;
            _laserTowerView.PreviewReload(secondReload);

            await PerformDelay(secondReload);

            _curentDurationSeries = _laserTowerView.DataAttackLaser.DurationSeries;
        }

        private void HitEnemy()
        {
            var damge = _laserTowerView.DataAttack.Damage;

            foreach (var hit in _hitInfo)
            {
                var enemy = hit.collider.GetComponent<IBeatle>();
                enemy.ApplyDamage(damge);
                _laserTowerView.PreviewAtack(enemy);

            }
        }



    }
}