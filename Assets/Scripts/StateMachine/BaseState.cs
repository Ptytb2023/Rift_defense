using RiftDefense.Generic.Interface;
using System;

namespace RiftDefense.FSM
{
    public abstract class BaseState : IActive, IDisposable
    {
        protected StateMachine StateMachine { get; private set; }

        public bool Enabel { get; protected set; }

        public BaseState (StateMachine stateMachine) => StateMachine = stateMachine;

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
