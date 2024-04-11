using RiftDefense.Beatle;
using RiftDefense.Edifice.Tower;
using RiftDefense.Edifice.Tower.FSM;
using RiftDefense.FSM;
using RiftDefense.Generic.Interface;

public abstract class BaseStateAttackTower : BaseState
{
    private StateSearchTargetTower _stateSearch;
    private ITargetSystem<IBeatle> _targetSystem;

    private IBeatle _currentTarget;
    public BaseStateAttackTower(StateMachineTower stateMashine
        , StateSearchTargetTower stateSearch, ITargetSystem<IBeatle> targetSystem) : base(stateMashine, stateSearch)
    {
        _stateSearch = stateSearch;
        _targetSystem = targetSystem;
    }

    public void Init(IBeatle target)
    {
        _currentTarget = target;
    }

    protected abstract void PerfomAttack();

    private async void Update()
    {
       // if (_currentTarget == null)

    }

    private bool TrySetTarget()
    {
        if (!_targetSystem.TryGetClosestTargetInRadius(out IBeatle beatle))
            return false;

        _currentTarget = beatle;
        return true;
    }
} 
