using System;

namespace RiftDefense.Generic.Interface
{
    public interface IHandlerSearchObject<T>
    {
        event Action<T> EnemyInSight;
        event Action<T> EnemyNotInSight;
    }
}