using RiftDefense.Generic.Interface;
using System;
using System.Collections.Generic;

namespace RiftDefense.FSM
{
    public abstract class StateMachine : IActive
    {
        protected Dictionary<Type, BaseState> States = new Dictionary<Type, BaseState>();
        protected BaseState StartState;
        public BaseState CurrentState { get; private set; }

        public bool Enabel { get; private set; }

        public void AddState(BaseState state)
        {
            var type = state.GetType();

            if (States.ContainsKey(type))
                throw new InvalidCastException();

            States.Add(type, state);
        }

        public void SetActive(bool active)
        {
            Enabel = active;

            if (active)
                SetState(StartState.GetType());
            else
            {
                CurrentState?.Exit();
                CurrentState = null;
            }
        }

        public void SetState(Type typeState)
        {
            if (CurrentState != null)
                if (CurrentState.GetType() == typeState)
                    throw new Exception($"{typeState}, Already enabel");

            if (States.TryGetValue(typeState, out var newState))
            {
                CurrentState?.Exit();
                CurrentState?.SetActive(false);

                CurrentState = newState;
                CurrentState.SetActive(true);
                CurrentState.Enter();
            }
            else
                throw new ArgumentException($"{typeState}, Not included in the dictionary: {CurrentState}");
        }


    }
}
