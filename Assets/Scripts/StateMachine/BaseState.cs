using RiftDefense.Generic.Interface;
using System;

namespace RiftDefense.FSM
{
    public abstract class BaseState : IActive, IDisposable, IBaseState
    {
        protected StateMachine StateMachine { get; private set; }
        protected BaseState NextState;
        public bool Enabel { get; protected set; }


        public BaseState(StateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }

        public void SetNextState(BaseState nextState)
        {
            NextState = nextState;
        }

        protected void GoOverNextOrExitState()
        {
            if (NextState != null)
                StateMachine.SetState(NextState);
            else
                Exit();
        }

        public virtual void Enter() { }
        public virtual void Exit() { }

        public virtual void SetActive(bool active)
        {
            Enabel = active;
        }

        public void Dispose()
        {
            SetActive(false);
        }
    }
}
