using Cysharp.Threading.Tasks;
using RiftDefense.Beatle;
using RiftDefense.Edifice.Tower.View;
using RiftDefense.FSM;
using RiftDefense.Generic.Interface;
using System;
using System.Threading.Tasks;

namespace RiftDefense.Edifice.Tower.FSM
{
    public abstract class BaseStateAttackTower : BaseState
    {
        protected BaseTowerView TowerView;
        private ITargetSystem<IBeatle> _targetSystem;

        protected IBeatle CurrentTarget;

        public BaseStateAttackTower(StateMachine stateMashine,
                                    BaseTowerView baseTowerView,
                                    ITargetSystem<IBeatle> targetSystem)
            : base(stateMashine)
        {
            TowerView = baseTowerView;
            _targetSystem = targetSystem;
        }

        protected abstract Task PerfomAttack();

        public override void Enter()
        {
            SetActive(true);

            if (TrySetTargetOrNextState())
                DelayBetweenShoots();
        }

        public override void Exit()
        {
            SetActive(false);
        }


        private async void DelayBetweenShoots()
        {
            while (Enabel)
            {
                await PerfomAttack();

                float secodDelay = TowerView.DataAtack.DelayBetweenShots;
                await PerformDelay(secodDelay);
            }
        }

        protected async Task PerformDelay(float second)
        {
            var delay = TimeSpan.FromSeconds(second);
            await UniTask.Delay(delay, DelayType.DeltaTime, PlayerLoopTiming.Update);
        }


        protected bool TrySetTargetOrNextState()
        {
            if (_targetSystem.TryGetClosestTargetInRadius(out IBeatle beatle))
            {
                CurrentTarget = beatle;
                CurrentTarget.Dead += TargetDied;
                return true;
            }

            GoOverNextOrExitState();
            return false;
        }

        private void TargetDied(IEnemy enemy)
        {
            CurrentTarget.Dead -= TargetDied;
            TrySetTargetOrNextState();
        }
    }
}
