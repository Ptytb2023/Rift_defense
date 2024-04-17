using UnityEngine;
using RiftDefense.Edifice.Tower.FSM;


namespace RiftDefense.Edifice.Tower
{
    [RequireComponent(typeof(LaserTowerView))]
    public class LaserTower : BaseTower
    {
      [field:SerializeField]  public LaserTowerView LaserTowerView { get; private set; }


        protected override void Awake()
        {
            base.Awake();

            var stateAttack = new LaserTowerAttackState(this);
            var stateSearch = new StateSearchTargetTower(this, stateAttack.GetType());


            AddState(stateAttack);
            AddState(stateSearch);

            StartState = stateSearch;
        }
       
    }
}