using RiftDefense.Generic.Interface;
using UnityEngine;

namespace RiftDefense.Beatle
{
    public interface IBeatle : IEnemy
    {
        public Vector3 GetPointForHit();
    }
}
