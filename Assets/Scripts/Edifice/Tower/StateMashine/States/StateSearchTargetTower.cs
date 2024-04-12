using RiftDefense.Edifice.Tower.Model;
using RiftDefense.Edifice.Tower.View;
using RiftDefense.Generic.Interface;
using RiftDefense.Beatle;
using RiftDefense.FSM;
using Cysharp.Threading.Tasks;
using System;


namespace RiftDefense.Edifice.Tower.FSM
{
    public class StateSearchTargetTower : BaseState, IStateSearchTargetTower
    {
        private BaseTowerView _viewBaseTower;
        private ITargetSystem<IBeatle> _targetSystem;

        private BaseDataTowerAttack _dataAttack => _viewBaseTower.DataAtack;

        public StateSearchTargetTower(StateMachine stateMachine,
                                         BaseTowerView viewBaseTower,
                                         ITargetSystem<IBeatle> targetSystem)
            : base(stateMachine)
        {
            _viewBaseTower = viewBaseTower;
            _targetSystem = targetSystem;
        }


        public override void Enter()
        {
            SetActive(true);

            var animator = _viewBaseTower.Animator;
            var modeSearch = _viewBaseTower.DataAnimator.ModeSearch;
            //  animator.Play(modeSearch);

            Update();
        }

        public override void Exit()
        {
            var animator = _viewBaseTower.Animator;
            var Idel = _viewBaseTower.DataAnimator.Idel;
            // animator.Play(Idel);

            SetActive(false);
        }

        private async void Update()
        {
            while (Enabel)
            {
                if (_targetSystem.CheakTargetsInRadius())
                    GoOverNextOrExitState();
                else
                {
                    var deleay = TimeSpan.FromSeconds(_dataAttack.DelayBetweenSeatchTarget);
                    await UniTask.Delay(deleay, DelayType.DeltaTime, PlayerLoopTiming.Update);
                }
            }
        }
    }
}