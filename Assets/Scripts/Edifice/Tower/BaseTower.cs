using RiftDefense.Beatle;
using RiftDefense.Edifice.Tower.View;
using RiftDefense.FSM;
using RiftDefense.Generic;

namespace RiftDefense.Edifice.Tower
{
    public abstract class BaseTower : StateMachine
    {
        protected TargetSystem<IBeatle> TargetSystem;

        public BaseTower(BaseTowerView towerView) 
        {
            var transorm = towerView.transform;
            var radius = towerView.DataAttack.RadiusAtack;
            var mask = towerView.DataAttack.EnemyMask;

            TargetSystem = new TargetSystem<IBeatle>(transorm, radius, mask);
        }
    }
}
