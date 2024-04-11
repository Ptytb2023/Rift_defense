using RiftDefense.Beatle;
using RiftDefense.Edifice.Tower.View;
using RiftDefense.Generic.Interface;
using RiftDefense.Edifice.Tower.Model;
using RiftDefense.FSM;
using RiftDefense.Edifice.Tower.FSM;
using System.Threading.Tasks;


namespace RiftDefense.Edifice.Tower
{
    public class StateSearchTargetTower : BaseState, IActive
    {
        private BaseTowerView _viewBaseTower;
        private ITargetSystem<IBeatle> _targetSystem;

        private BaseDataTowerAttack _dataAttack => _viewBaseTower.DataAtack;

        protected StateSearchTargetTower(StateMachineTower stateMachine,
                                         BaseStateAttackTower nextState,
                                         BaseTowerView viewBaseTower,
                                         ITargetSystem<IBeatle> targetSystem)
            : base(stateMachine, nextState)
        {
            NextState = nextState;
            _viewBaseTower = viewBaseTower;
            _targetSystem = targetSystem;
        }


        public override void Enter()
        {
            var animator = _viewBaseTower.Animator;
            var modeSearch = _viewBaseTower.DataAnimator.ModeSearch;
            animator.Play(modeSearch);

            Update();
        }

        public override void Exit()
        {
            var animator = _viewBaseTower.Animator;
            var Idel = _viewBaseTower.DataAnimator.Idel;
            animator.Play(Idel);

            SetActive(false);
        }

        public async void Update()
        {
            while (Enabel)
            {
                if (_targetSystem.CheakTargetsInRadius())
                    StateMachine.SetState<BaseStateAttackTower>();

                await Task.Delay(_dataAttack.DelayBetweenSeatchTarget);
            }
        }

        public override void SetActive(bool active)
        {
            Enabel = active;
        }
    }
}