using RiftDefense.Edifice.Tower.Model;
using RiftDefense.Edifice.Tower.View;
using RiftDefense.Generic;
using RiftDefense.Generic.Interface;
using RiftDefense.Beatle;
using System;
using System.Collections;
using UnityEngine;

namespace RiftDefense.Edifice.Tower
{
    public abstract class BaseTower : IActive, IDisposable
    {
        private BaseTowerBehaviour _towerBehaviur;

        private TargetSystem<IBeatle> _targetSystem;
        private IAttackSystem<IBeatle> _attackSystem;
        private IBeatle _currentTarget;

        private Coroutine _attack;

        protected BaseTower(BaseTowerBehaviour towerBehaviur,
                            TargetSystem<IBeatle> targetSystem,
                            IAttackSystem<IBeatle> attackSystem)
        {
            _towerBehaviur = towerBehaviur;
            _targetSystem = targetSystem;
            _attackSystem = attackSystem;

            SetActive(true);
        }

        private DataTowerAtack _dataAtack => _towerBehaviur.DataAtack;


        private void SetNewTarget(IBeatle target)
        {
            StopAttack();

            _currentTarget = target;
            _attack = _towerBehaviur.StartCoroutine(StateAttack());
        }

        private void StopAttack()
        {
            if (_attack != null)
                _towerBehaviur.StopCoroutine(_attack);

            _currentTarget = null;
            
        }

        protected virtual IEnumerator StateAttack()
        {
            int amountAmmunition = _dataAtack.AmountAmmunition;

            while (_towerBehaviur.enabled && _currentTarget != null)
            {

                _attackSystem.PerformAttack(_currentTarget);

                amountAmmunition--;

                if (amountAmmunition <= 0)
                {
                    yield return PerformDelay(_dataAtack.TimeReload);
                    continue;
                }

                yield return PerformDelay(_dataAtack.DelayBetweenShots);
            }
        }

        private IEnumerator PerformDelay(float second)
        {
            yield return new WaitForSeconds(second);
        }

        public void SetActive(bool active)
        {
            if (active)
                TowerOn();
            else
                TowerOff();
        }

        private void TowerOff()
        {
            StopAttack();
            _targetSystem.NewTarget -= SetNewTarget;
            _targetSystem.TargetDiedOrExitZone -= StopAttack;
        }

        private void TowerOn()
        {
            _targetSystem.NewTarget += SetNewTarget;
            _targetSystem.TargetDiedOrExitZone += StopAttack;
        }

        public void Dispose()
        {
            SetActive(false);
        }
    }
}