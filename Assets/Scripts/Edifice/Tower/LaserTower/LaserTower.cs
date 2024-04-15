
using RiftDefense.Edifice.Tower.FSM;

namespace RiftDefense.Edifice.Tower
{
    public class LaserTower : BaseTower
    {
        public LaserTower(LaserTowerView towerView)
            : base(towerView)
        {
            var stateAttack = new LaserTowerAttackState(this, TargetSystem, towerView);
            var stateSearch = new StateSearchTargetTower(this, towerView, TargetSystem, stateAttack.GetType());


            AddState(stateAttack);
            AddState(stateSearch);

            StartState = stateSearch;
        }
    }
}