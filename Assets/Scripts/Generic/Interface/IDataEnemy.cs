using System.Collections.Generic;
using UnityEngine;

namespace RiftDefense.Generic.Interface
{
    public interface IDataEnemy 
    {
        public IEnumerable<IEnemy> GetEnemies();
        public void AddEnemy(IEnemy enemy);
        public bool RemoveEnemy(IEnemy enemy);
        public bool FindNearbyEnemyFromPosition(Vector3 position, out IEnemy enemu);
    }
}