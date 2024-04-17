using RiftDefense.Beatle;
using RiftDefense.Generic;
using UnityEngine;

namespace RiftDefense.Edifice.Tower.FSM
{
    [RequireComponent(typeof(ClassicTowerView))]
    public class ClassicTower : BaseTower
    {
       [field:SerializeField] public ClassicTowerView classicTowerView { get; private set; }


        protected override void Awake() 
        {
            base.Awake();

            var stateAttack = new ClassicTowerStateAttack(this);
            var stateSearch = new StateSearchTargetTower(this, stateAttack.GetType());

            AddState(stateAttack);
            AddState(stateSearch);

            StartState = stateSearch;
        }
    }
}
