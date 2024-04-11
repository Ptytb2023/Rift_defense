using RiftDefense.Beatle;
using RiftDefense.Edifice.Tower.View;
using RiftDefense.Generic;



namespace RiftDefense.Edifice.Tower
{
    public class ClassiTower : StateSearchTargetTower
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
