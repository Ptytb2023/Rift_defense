using System;
using UnityEngine;
using RiftDefense.Generic.Interface;

namespace RiftDefense.Generic
{
    [Serializable]
    public class DataHealf :  IDataHealf
    {
        [field: SerializeField] public float MaxHealf { get; private set; }

        public event Action<float> CheangeHealf;
        public event Action Dead;

        private float _currentHealf;

        public float CurrentHealf => _currentHealf;

        public void ApplyDamage(float damage)
        {
            if (damage > _currentHealf)
            {
                _currentHealf = 0f;
                Dead?.Invoke();
            }
            else
                _currentHealf -= damage;

            CheangeHealf?.Invoke(_currentHealf);
        }

        public void ResetDataHealf()
        {
            _currentHealf = MaxHealf;
            CheangeHealf?.Invoke(_currentHealf);
        }
    }
}