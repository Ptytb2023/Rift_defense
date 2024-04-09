namespace RiftDefense.Generic.Interface
{
    public interface IAttackSystem<T> where T : IEnemy
    {
        public void PerformAttack(T target);
    }
}
