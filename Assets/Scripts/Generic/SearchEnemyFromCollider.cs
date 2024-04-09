using RiftDefense.Generic.Interface;
using System;
using UnityEngine;

namespace RiftDefense.Generic
{
    public class SearchEnemyFromCollider<T> : IHandlerSearchObject<T>, IActive, IDisposable where T : IEnemy
    {
        private HandlerZoneTriger _zoneTriger;

        public event Action<T> EnemyInSight;
        public event Action<T> EnemyNotInSight;

        public SearchEnemyFromCollider(HandlerZoneTriger zoneTriger)
        {
            _zoneTriger = zoneTriger;
            OnSearch();
        }

        private void OnEneterTriget(Collider collider)
        {
            if (collider.gameObject.TryGetComponent(out T enemu))
                EnemyInSight?.Invoke(enemu);
        }


        private void OnExitTriger(Collider collider)
        {
            if (collider.gameObject.TryGetComponent(out T enemu))
                EnemyNotInSight?.Invoke(enemu);
        }

        private void OnSearch()
        {
            _zoneTriger.EneterTriget += OnEneterTriget;
            _zoneTriger.ExitTriger += OnExitTriger;
        }

        private void OffSearch()
        {
            _zoneTriger.EneterTriget -= OnEneterTriget;
            _zoneTriger.ExitTriger -= OnExitTriger;
        }

        public void SetActive(bool active)
        {
            if (active)
                OnSearch();
            else
                OffSearch();
        }

        public void Dispose()
        {
           SetActive(false);
        }
    }
}