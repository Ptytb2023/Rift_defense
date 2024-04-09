using RiftDefense.Generic;
using RiftDefense.Beatle;
using UnityEngine;

namespace RiftDefense.Edifice.Tower
{
    public class ClassiCannonTower : BaseTower
    {

        private Transform _headTower;

        public ClassiCannonTower(ClassicCannonBehaviour towerBehaviur,
                                 TargetSystem<IBeatle> targetSystem,
                                 AttackSystemClassic attackSystem,
                                 Transform head) :
            base(towerBehaviur, targetSystem, attackSystem)
        {
            _headTower = head;
        }

    }
}
