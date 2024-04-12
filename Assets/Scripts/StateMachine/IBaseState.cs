namespace RiftDefense.FSM
{
    public interface IBaseState
    {
        bool Enabel { get; }

        void Enter();
        void Exit();
        void SetActive(bool active);
        void SetNextState(BaseState nextState);
    }
}