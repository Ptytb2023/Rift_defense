using System;
using UnityEngine;

namespace RiftDefense.Generic.Interface
{
    public interface IEnemy : IDamageable
    {
        public bool isAllTarget { get; }
        public int MaxCapacityTarget { get; }
        public int CurrentCoutTarget { get; set; }
        public bool AddEnemyTarget(IEnemy enemy);
        public bool Enabel { get; }
        public event Action<IEnemy> Dead;
        public Vector3 GetPosition();
    }
}
