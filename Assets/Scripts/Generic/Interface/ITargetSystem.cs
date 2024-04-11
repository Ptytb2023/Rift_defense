using System.Collections.Generic;
using System.Numerics;

namespace RiftDefense.Generic.Interface
{
    public interface ITargetSystem<T> where T : IEnemy
    {
        public bool TryGetClosestTargetInRadius(out T target);
        public bool TryGetAllTargetsInRadius(out List<T> targets);
        public bool CheakTargetsInRadius();
        public T FindClossetTarget(List<T> enemys);
    }
}