using System;
using UnityEngine;
using RiftDefense.Generic.Interface;

namespace RiftDefense.Generic
{
    [Serializable]
    public class DataHealf : IDamageable, IDataHealf
    {
        [field: SerializeField] public float MaxHealf { get; private set; }

        public Action<float> ChenageHealf;

        private float _currentHealf;

        public float CurrentHealf => _currentHealf;

        public void ApplyDamage(float damage)
        {
            if (damage > _currentHealf)
                _currentHealf = 0f;
            else
                _currentHealf -= damage;

            ChenageHealf?.Invoke(_currentHealf);
        }

        public void ResetDataHealf()
        {
            _currentHealf = MaxHealf;
            ChenageHealf?.Invoke(_currentHealf);
        }
    }
}