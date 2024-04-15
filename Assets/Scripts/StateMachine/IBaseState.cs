namespace RiftDefense.FSM
{
    public interface IBaseState
    {
        bool Enabel { get; }
        void Enter();
        void Exit();
        void SetActive(bool active);
        public void SetNextState(BaseState nextState);
    }
}