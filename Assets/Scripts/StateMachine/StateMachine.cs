using System;
using System.Collections.Generic;

namespace RiftDefense.FSM
{
    public abstract class StateMachine
    {
        protected Dictionary<Type, BaseState> State;

        public BaseState CurrentState { get; private set; }

        public void SetState<T>() where T : BaseState
        {
            var type = typeof(T);

            if (CurrentState.GetType() == type)
                throw new Exception($"{type}, Already enabel");

            if (State.TryGetValue(type, out BaseState baseState))
            {
                CurrentState?.Exit();
                CurrentState = baseState;
                CurrentState.Enter();
            }
            else
                throw new ArgumentException($"{type}, Not included in the dictionary: {CurrentState}");
        }
    }
}
