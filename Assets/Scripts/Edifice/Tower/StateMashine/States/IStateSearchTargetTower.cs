using RiftDefense.FSM;

namespace RiftDefense.Edifice.Tower.FSM
{
    public interface IStateSearchTargetTower: IBaseState
    {
        void Enter();
        void Exit();
    }
}