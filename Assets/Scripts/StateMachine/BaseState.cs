using RiftDefense.Generic.Interface;
using System;

namespace RiftDefense.FSM
{
    public abstract class BaseState 
    {
        protected StateMachine StateMachine { get; private set; }

        public BaseState (StateMachine stateMachine) => StateMachine = stateMachine;

        public virtual void Enter() { }
        public virtual void Exit() { }

        public virtual void Update () { }

      
    }
}
