using RiftDefense.Generic;
using RiftDefense.Beatle;
using System;
using UnityEngine;
using RiftDefense.Edifice.Tower.View;

namespace RiftDefense.Edifice.Tower
{
    [RequireComponent(typeof(BaseTowerView))]
    public abstract class BaseTower : MonoBehaviour, ITower
    {
        private BaseTowerView _viewBaseTower;

        private ITargetSystem<IBeatle> _targetSystem;

        protected IBeatle CurentTarget { get; private set; }

        public event Action Dead;

        protected virtual void OnEnable()
        {
            _targetSystem.TargetDiscovered += OnTargetDiscovered;
            _targetSystem.TargetLost += OnTargetLost;
        }

        protected virtual void OnDisable()
        {
            _targetSystem.TargetDiscovered -= OnTargetDiscovered;
            _targetSystem.TargetLost -= OnTargetLost;

        }

        private void OnTargetDiscovered(IBeatle target) => CurentTarget = target;
        private void OnTargetLost() => CurentTarget = null;


        public Vector3 GetPosition() => transform.position;


        public void ApplyDamage(float damage)
        {
            _viewBaseTower.DataHealf.ApplyDamage(damage);
        }
    }
}