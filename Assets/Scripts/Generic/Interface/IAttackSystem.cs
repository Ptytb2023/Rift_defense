using System;

namespace RiftDefense.Generic.Interface
{
    public interface IAttackSystem<T> where T : IEnemy
    {
        public event Action<T> OnAttack;
        public void StartAttackTarget(T target);
        public void StopAttackTarget();
    }
}
