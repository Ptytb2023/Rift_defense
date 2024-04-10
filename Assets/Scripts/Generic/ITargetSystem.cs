using RiftDefense.Generic.Interface;
using System;

namespace RiftDefense.Generic
{
    public interface ITargetSystem<T> where T : IEnemy
    {
      public  T CurrentTarget { get; }

       public event Action<T> TargetDiscovered;
       public event Action TargetLost;
    }
}