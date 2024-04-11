using Cysharp.Threading.Tasks;
using RiftDefense.Beatle;
using RiftDefense.FSM;
using RiftDefense.Generic.Interface;
using System;
using System.Threading.Tasks;

namespace RiftDefense.Edifice.Tower.FSM
{
    public abstract class BaseStateAttackTower : BaseState
    {
        private StateSearchTargetTower _stateSearch;
        private ITargetSystem<IBeatle> _targetSystem;

        protected IBeatle CurrentTarget;


        public BaseStateAttackTower(StateMachineTower stateMashine,
                                    StateSearchTargetTower stateSearch,
                                    ITargetSystem<IBeatle> targetSystem)
            : base(stateMashine, stateSearch)
        {
            _stateSearch = stateSearch;
            _targetSystem = targetSystem;
        }


        protected abstract Task PerfomAttack();

        public override void Enter()
        {
            SetActive(true);

            TrySetTargetOrNextState();
        }

        public override void Exit()
        {
            SetActive(false);
        }

        protected virtual async bool Reload()
        {
            // if (_currentTarget == null)

        }

        protected async Task PerformDelay(float second)
        {
            var delay = TimeSpan.FromSeconds(second);
            await UniTask.Delay(delay, DelayType.DeltaTime, PlayerLoopTiming.Update);
        }


        private void TrySetTargetOrNextState()
        {
            if (_targetSystem.TryGetClosestTargetInRadius(out IBeatle beatle))
            {
                CurrentTarget = beatle;
                return;
            }

            StateMachine.SetState<StateSearchTargetTower>();
        }
    }
}
