using RiftDefense.Generic;
using RiftDefense.Generic.Interface;
using RiftDefense.Beatle;
using System;

namespace RiftDefense.Edifice.Tower
{
    public abstract class BaseTower : IActive, IDisposable
    {
        private IPreviewTower _prewierTower;
        private ITargetSystem<IBeatle> _targetSystem;
        private IAttackSystem<IBeatle> _attackSystem;

        protected BaseTower(IPreviewTower prewierTower,
            ITargetSystem<IBeatle> targetSystem,
            IAttackSystem<IBeatle> attackSystem)
        {
            _prewierTower = prewierTower;
            _targetSystem = targetSystem;
            _attackSystem = attackSystem;
        }

        protected virtual void OnEnable()
        {
            _targetSystem.TargetDiscovered += OnTargetDiscovered;
            _targetSystem.TargetLost += OnTargetLost;

            _attackSystem.OnAttack += ShowAttack;
        }

        protected virtual void OnDisable()
        {
            _targetSystem.TargetDiscovered -= OnTargetDiscovered;
            _targetSystem.TargetLost -= OnTargetLost;

            _attackSystem.OnAttack -= ShowAttack;
        }

        private void OnTargetDiscovered(IBeatle target) => _attackSystem.StartAttackTarget(target);
        private void OnTargetLost() => _attackSystem.StopAttackTarget();

        private void ShowAttack(IBeatle beatle) => _prewierTower.PreviewAtack(beatle);


        public void SetActive(bool active)
        {
            if (active)
                OnEnable();
            else
                OnDisable();
        }

        public void Dispose()
        {
            SetActive(false);
        }
    }
}