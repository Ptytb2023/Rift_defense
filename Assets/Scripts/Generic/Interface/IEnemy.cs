using System;
using UnityEngine;

namespace RiftDefense.Generic.Interface
{
    public interface IEnemy : IDamageable
    {
        public event Action Dead;
        public Vector3 GetPosition();
    }
}
