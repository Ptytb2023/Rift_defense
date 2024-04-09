using System.Collections.Generic;
using UnityEngine;

namespace RiftDefense.Generic.Interface
{
    public interface IDataEnemy<T>
    {
        public IEnumerable<T> GetEnemies();
        public void AddEnemy(T enemy);
        public bool RemoveEnemy(T enemy);
        public bool FindNearbyEnemyFromPosition(Vector3 position, out T enemu);
    }
}