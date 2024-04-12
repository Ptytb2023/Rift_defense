using RiftDefense.FSM;
using RiftDefense.Edifice.Tower.Model;
using RiftDefense.Generic;
using RiftDefense.Beatle;
using System.Collections.Generic;

namespace RiftDefense.Edifice.Tower.FSM
{
    public class ClassicTower : StateMachine
    {
        private ClassicTowerView _classicTowerView;
        private BaseDataTowerAttack _dataAtac => _classicTowerView.DataAtack;

        public ClassicTower(ClassicTowerView classicTowerView)
        {
            _classicTowerView = classicTowerView;   

            var targetSystem = new TargetSystem<IBeatle>(_classicTowerView.transform, _dataAtac.RadiusAtack, _dataAtac.EnemyMask);
            var stateSearch = new StateSearchTargetTower(this, _classicTowerView, targetSystem);
            var stateAttack = new ClassicTowerStateAttack(this, _classicTowerView, targetSystem);

            stateSearch.SetNextState(stateAttack);
            stateAttack.SetNextState(stateSearch);

            States = new HashSet<BaseState>();
            States.Add(stateAttack);
            States.Add(stateSearch);

            StartState = stateSearch;
        }

    }
}
