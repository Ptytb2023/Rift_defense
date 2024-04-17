using RiftDefense.Beatle;
using RiftDefense.Edifice.Tower.View;
using RiftDefense.FSM;
using RiftDefense.Generic;
using UnityEngine;

namespace RiftDefense.Edifice.Tower
{
    [RequireComponent(typeof(BaseTowerView))]
    public abstract class BaseTower : StateMachine
    {
        [SerializeField] public BaseTowerView towerView;
        
        public TargetSystem<IBeatle> TargetSystem { get; private set; }

        public IBeatle CurrentTarget;

        protected virtual void Awake()
        {
            var transorm = towerView.transform;
            var radius = towerView.DataAttack.RadiusAtack;
            var mask = towerView.DataAttack.EnemyMask;

            TargetSystem = new TargetSystem<IBeatle>(transorm, towerView, radius, mask);
        }
      
    }
}
