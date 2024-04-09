using RiftDefense.Edifice.Tower.Model;
using RiftDefense.Generic.Interface;
using RiftDefense.Beatle;

namespace RiftDefense.Edifice.Tower
{
    public class AttackSystemClassic : IAttackSystem<IBeatle>
    {
        private DataTowerAtack _data;

        private float _damage => _data.DamageOneHit;

        public AttackSystemClassic(DataTowerAtack data)
        {
            _data = data;
        }

        public void PerformAttack(IBeatle target)
        {
            target.ApplyDamage(_damage);
        }
    }
}
