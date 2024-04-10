using RiftDefense.Beatle;
using RiftDefense.Edifice.Tower.View;
using RiftDefense.Generic;



namespace RiftDefense.Edifice.Tower
{
    public class ClassiTower : BaseTower
    {
        public ClassiTower(
            BaseTowerView  prewierTower, 
            TargetSystem<IBeatle> targetSystem,
            AttackSystemClassic attackSystem) : 
            base(prewierTower,targetSystem, attackSystem)
        {
        }
    }
}
