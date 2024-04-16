using RiftDefense.Edifice.Tower.Model;
using RiftDefense.Edifice.Tower.View;
using RiftDefense.Generic.Interface;
using RiftDefense.Beatle;
using RiftDefense.FSM;
using Cysharp.Threading.Tasks;
using System;


namespace RiftDefense.Edifice.Tower.FSM
{
    public class StateSearchTargetTower : BaseState
    {

        private BaseTowerView _viewBaseTower;
        private ITargetSystem<IBeatle> _targetSystem;
        private Type _nextState;
        private DataTowerAttack _dataAttack => _viewBaseTower.DataAttack;

        public StateSearchTargetTower(StateMachine stateMachine,
                                         BaseTowerView viewBaseTower,
                                         ITargetSystem<IBeatle> targetSystem,
                                         Type nextState)
            : base(stateMachine)
        {
            _viewBaseTower = viewBaseTower;
            _targetSystem = targetSystem;
            _nextState = nextState;
        }


        public override void Enter()
        {
            SetActive(true);
            _viewBaseTower.PrewiwSearch(true);

            Update();
        }

        public override void Exit()
        {
            _viewBaseTower.PrewiwSearch(false);
            SetActive(false);
        }

        private async void Update()
        {
            while (Enabel)
            {
                if (_targetSystem.CheakTargetsInRadius())
                    StateMachine.SetState(_nextState);
                else
                {
                    var deleay = TimeSpan.FromSeconds(_dataAttack.DelayBetweenSeatchTarget);
                    await UniTask.Delay(deleay, DelayType.DeltaTime, PlayerLoopTiming.Update);
                }
            }
        }
    }
}