using System;
using UnityEngine;

namespace RiftDefense.Generic.Interface
{
    public interface IEnemy : IDamageable
    {
        public bool Enabel { get; }
        public event Action<IEnemy> Dead;
        public Vector3 GetPosition();
    }
}
