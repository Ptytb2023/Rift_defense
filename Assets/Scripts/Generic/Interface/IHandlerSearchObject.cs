using System;

namespace RiftDefense.Generic.Interface
{
    public interface IHandlerSearchObject<T>
    {
        public event Action<T> EnemyInSight;
        public event Action<T> EnemyNotInSight;
    }
}