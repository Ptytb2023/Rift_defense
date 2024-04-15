
namespace RiftDefense.Edifice.Tower.FSM
{
    public class ClassicTower : BaseTower
    {
        public ClassicTower(ClassicTowerView towerView) : base(towerView)
        {
            var stateAttack = new ClassicTowerStateAttack(this, towerView, TargetSystem);
            var stateSearch = new StateSearchTargetTower(this, towerView, TargetSystem, stateAttack.GetType());

            AddState(stateAttack);
            AddState(stateSearch);

            StartState = stateSearch;
        }
    }
}
