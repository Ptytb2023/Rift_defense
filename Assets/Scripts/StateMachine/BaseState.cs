using RiftDefense.Generic.Interface;
using Unity.VisualScripting;

namespace RiftDefense.FSM
{
    public abstract class BaseState : IActive
    {
        protected StateMachine StateMachine { get; private set; }

        public bool Enabel { get; protected set; }

        protected BaseState NextState;

        public BaseState(StateMachine stateMachine, BaseState nextState)
        {
            StateMachine = stateMachine;
            NextState = nextState;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }

        public abstract void SetActive(bool active);
    }
}
