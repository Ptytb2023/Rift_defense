using RiftDefense.Beatle;
using RiftDefense.FSM;
using System.Collections;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

namespace RiftDefense.Edifice.Tower
{
    public class LaserTowerAttackState : BaseStateAttackTower
    {
        private LaserTower _laserTower;
        private LaserTowerView _laserTowerView => _laserTower.LaserTowerView;

        private float _curentDurationSeries;
        private RaycastHit[] _hitInfo;

        private Transform _pointShoot => _laserTowerView.DataAttackLaser.SpherePoint;
        private LayerMask enemyMask => _laserTowerView.DataAttack.EnemyMask;

        private WaitForSeconds delayTurnOff; 

        private Coroutine _turenOn;

        public LaserTowerAttackState(LaserTower laserTower) :
            base(laserTower)
        {
            _laserTower = laserTower;
            delayTurnOff = new WaitForSeconds(_laserTowerView.DataAttack.DelayBetweenShots/2f);
            _curentDurationSeries = _laserTowerView.DataAttackLaser.DurationSeries;
        }

        public override void Enter()
        {
            base.Enter();

            if (CurrentTarget != null && CurrentTarget.Enabel)
            {
                _laserTowerView.TurnOnBeam(CurrentTarget);
            }
        }

        public override void Exit()
        {
            base.Exit();
            _laserTowerView.TurnOffBeam();
            if(_turenOn!=null)
                StateMachine.StopCoroutine(_turenOn);
            _laserTowerView.TurnOffBeam();
        }

        private IEnumerator DelayTurenOn()
        {
            _laserTowerView.TurnOnBeam(CurrentTarget);

            yield return delayTurnOff;

            _laserTowerView.TurnOffBeam();
        }

        protected override void PerfomAttack()
        {
            ReduceTime();
            HoldBeam();
            HitEnemy();

            //_turenOn = StateMachine.StartCoroutine(DelayTurenOn());
            if (_curentDurationSeries <= 0)
                Reload();
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
            _curentDurationSeries -= Delay;
        }

        private void Reload()
        {
            _laserTowerView.TurnOffBeam();
            Delay = _laserTowerView.DataAttack.TimeReload;
            _curentDurationSeries = _laserTowerView.DataAttackLaser.DurationSeries;
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