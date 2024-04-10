namespace RiftDefense.FSM
{
    public abstract class BaseState
    {
        protected StateMachine StateMashine;

        public BaseState(StateMachine stateMashine)
        {
            StateMashine = stateMashine;
        }
      
        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
    }
}
