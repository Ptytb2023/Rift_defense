using System;

namespace RiftDefense.Generic.Interface
{
    public interface IDataHealf : IDamageable
    {
        public event Action<float> CheangeHealf;
        public event Action Dead;

        public float CurrentHealf { get; }
        public float MaxHealf { get; }

        public void ResetDataHealf();
    }
}