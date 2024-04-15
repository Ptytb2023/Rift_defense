using RiftDefense.Generic.Interface;
using UnityEngine;

namespace RiftDefense.Edifice.Tower
{
    public interface ITower : IEnemy, IPlacementObject
    {

    }

    public interface IPlacementObject
    {
        public void DespawnTower();
        public Vector3Int GridPosition { get; set; }
    }
}
