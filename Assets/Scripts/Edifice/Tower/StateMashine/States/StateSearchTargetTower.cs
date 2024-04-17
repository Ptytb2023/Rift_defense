using RiftDefense.Edifice.Tower.Model;
using RiftDefense.Edifice.Tower.View;
using RiftDefense.Generic.Interface;
using RiftDefense.Beatle;
using RiftDefense.FSM;
using System;
using UnityEngine;


namespace RiftDefense.Edifice.Tower.FSM
{
    public class StateSearchTargetTower : BaseState
    {
        private BaseTower _tower;
        private ITargetSystem<IBeatle> _targetSystem => _tower.TargetSystem;
        private BaseTowerView _viewBaseTower => _tower.towerView;

        private Type _nextState;
        private DataTowerAttack _dataAttack => _viewBaseTower.DataAttack;

        private float _delay;

        public StateSearchTargetTower(BaseTower tower,
                                         Type nextState)
            : base(tower)
        {
            _tower = tower;
            _nextState = nextState;
        }


        public override void Enter()
        {
            _viewBaseTower.PrewiwSearch(true);
            //Debug.Log($"Enter {typeof(StateSearchTargetTower)}");
        }

        public override void Exit()
        {
            _viewBaseTower.PrewiwSearch(false);

            //Debug.Log($"Exit {typeof(StateSearchTargetTower)}");
        }

        public override void Update()
        {
            if (_delay > 0)
            {
                _delay -= Time.deltaTime;
                return;
            }

            if (_targetSystem.TryGetClosestTargetInRadius(out IBeatle beatle))
            {
                _tower.CurrentTarget = beatle;
                StateMachine.SetState(_nextState);
            }
            else
            {
                _delay = _dataAttack.DelayBetweenSeatchTarget;
            }
            //Debug.Log($"Update {typeof(StateSearchTargetTower)}");
        }
    }
}