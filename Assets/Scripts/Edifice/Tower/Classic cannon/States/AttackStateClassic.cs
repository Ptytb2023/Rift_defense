using RiftDefense.Beatle;
using RiftDefense.Edifice.Tower;
using RiftDefense.Edifice.Tower.Model;
using RiftDefense.FSM;
using RiftDefense.Generic;
using RiftDefense.Generic.Interface;

public class AttackStateClassic : BaseState
{
    private ClassicTowerView towerView;
    public AttackStateClassic(StateMachine stateMashine,ClassicTowerView towerView) : base(stateMashine)
    {
    }
    private BaseState _nextState;
    private BaseDataTowerAttack _data;

    private ITargetSystem<IBeatle> _targetSystem;
    private IAttackSystem<IBeatle> _attackSystem;

    private IBeatle _curentTarget;

    public override void Enter()
    {
        _curentTarget = _targetSystem.CurrentTarget;
    }


}
