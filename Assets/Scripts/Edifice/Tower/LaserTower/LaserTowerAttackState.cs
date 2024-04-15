using RiftDefense.Beatle;
using RiftDefense.FSM;
using RiftDefense.Generic.Interface;
using System.Threading.Tasks;
using UnityEngine;

namespace RiftDefense.Edifice.Tower
{
    public class LaserTowerAttackState : BaseStateAttackTower
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
            if (TrySetTargetOrOverGoNextState())
            {
                _laserTowerView.TurnOnBeam(CurrentTarget);
                PerfomAttack();
            }
        }

        public override void Exit()
        {
            _laserTowerView.TurnOffBeam();
        }

        protected override async void PerfomAttack()
        {
            while (Enabel && IsLiveTarget)
            {
                ReduceTime();
                HoldBeam();
                HitEnemy();

                await PerformDelay(_delayBetweenShots);

                if (_curentDurationSeries <= 0)
                    await Reload();
            }

            NextState();
        }


        private void HoldBeam()
        {
            var directionAttack = CurrentTarget.GetPointForHit() - _pointShoot.position;
            var distanceAttack = directionAttack.magnitude;
            Debug.DrawLine(_pointShoot.position, directionAttack * distanceAttack, Color.red, 0.3f);

            _hitInfo = Physics.RaycastAll(_pointShoot.position, directionAttack, distanceAttack, enemyMask.value);
        }

        private void ReduceTime()
        {
            _curentDurationSeries -= Time.deltaTime;
            _curentDurationSeries -= _delayBetweenShots;
        }

        private async Task Reload(bool instant = false)
        {
            if (Enabel)
            {
                var secondReload = _laserTowerView.DataAttack.TimeReload;
                _laserTowerView.PreviewReload(secondReload);

                await PerformDelay(secondReload);

                _curentDurationSeries = _laserTowerView.DataAttackLaser.DurationSeries;
            }
        }

        private void HitEnemy()
        {
            var coutDamage = _laserTowerView.DataAttackLaser.maxEnmeyDamge + 1;
            var damge = _laserTowerView.DataAttack.Damage;

            for (int i = 0; i < _hitInfo.Length; i++)
            {
                if (coutDamage < i)
                    break;

                var enemy = _hitInfo[i].collider.GetComponent<IBeatle>();
                enemy.ApplyDamage(damge);
                _laserTowerView.PreviewAtack(enemy);
            }

            //var damge = _laserTowerView.DataAttack.Damage;
            //CurrentTarget.ApplyDamage(damge);
            //_laserTowerView.PreviewAtack(CurrentTarget);
        }



    }
}