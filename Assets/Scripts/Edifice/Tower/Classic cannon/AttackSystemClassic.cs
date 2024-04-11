using RiftDefense.Edifice.Tower.Model;
using RiftDefense.Generic.Interface;
using RiftDefense.Beatle;
using System;

namespace RiftDefense.Edifice.Tower
{
    public class AttackSystemClassic : IAttackSystem<IBeatle>
    {
        private BaseDataTowerAttack _data;

        public event Action<IBeatle> OnAttack;

        private float _damage => _data.Damage;

        public AttackSystemClassic(BaseDataTowerAttack data)
        {
            _data = data;
        }

        private void PerformAttack(IBeatle target)
        {
            target.ApplyDamage(_damage);
        }

        public void StartAttackTarget(IBeatle target)
        {
            throw new NotImplementedException();
        }

        public void StopAttackTarget()
        {
            throw new NotImplementedException();
        }
    }
}
