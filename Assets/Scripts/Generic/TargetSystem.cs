using RiftDefense.Generic.Interface;
using System;
using UnityEngine;


namespace RiftDefense.Generic
{
    public class TargetSystem<T> : ITargetSystem<T>, IDisposable where T : IEnemy
    {
        private IDataEnemy _dataEnemu;
        private IHandlerSearchObject<T> _handlerSearchObject;

        private Transform _transform;

        public T CurrentTarget { get; private set; }
        private bool _isSetTarget;


        public event Action<T> TargetDiscovered;
        public event Action TargetLost;


        public TargetSystem(IDataEnemy dataEnemu,
                            IHandlerSearchObject<T> handlerSearchObject,
                            Transform transform)
        {
            _dataEnemu = dataEnemu;
            _handlerSearchObject = handlerSearchObject;
            _transform = transform;

            _isSetTarget = false;

            _handlerSearchObject.EnemyInSight += OnTargetInSight;
            _handlerSearchObject.EnemyNotInSight += OnTargetExitInSight;
        }

        private void OnTargetInSight(T target)
        {
            _dataEnemu.AddEnemy(target);

            if (_isSetTarget)
                TrySetTarget();
        }

        private void OnTargetExitInSight(T target)
        {
            if (CurrentTarget.GetPosition() == target.GetPosition())
            {
                _dataEnemu.RemoveEnemy(target);
                OnDiedAndExitZoneTarget();
            }
        }

        private void TrySetTarget()
        {
            if (_dataEnemu.FindNearbyEnemyFromPosition(_transform.position, out IEnemy enemu))
            {
                _isSetTarget = true;

                CurrentTarget = (T)enemu;
                TargetDiscovered?.Invoke((T)enemu);

                enemu.Dead += OnDiedAndExitZoneTarget;
            }
        }

        private void OnDiedAndExitZoneTarget()
        {
            CurrentTarget.Dead -= OnDiedAndExitZoneTarget;

            CurrentTarget = default(T);
            _isSetTarget = false;

            TrySetTarget();

            if(!_isSetTarget)
                TargetLost?.Invoke();
        }

        public void Dispose()
        {
            _handlerSearchObject.EnemyInSight -= OnTargetInSight;
            _handlerSearchObject.EnemyNotInSight -= OnTargetExitInSight;
        }
    }
}