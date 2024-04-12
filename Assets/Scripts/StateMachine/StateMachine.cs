using RiftDefense.Generic.Interface;
using System;
using System.Collections.Generic;

namespace RiftDefense.FSM
{
    public class StateMachine : IActive
    {
        protected HashSet<BaseState> States;
        protected BaseState StartState;

        public BaseState CurrentState { get; private set; }

        public bool Enabel { get; private set; }

        public void SetActive(bool active)
        {
            Enabel = active;

            if (active)
                SetState(StartState);
            else
                CurrentState?.Exit();

        }

        public void SetState(BaseState state)
        {
            if (CurrentState == state)
                throw new Exception($"{state}, Already enabel");

            if (States.TryGetValue(state, out var newState))
            {
                CurrentState?.Exit();
                CurrentState = newState;
                CurrentState.Enter();
            }
            else
                throw new ArgumentException($"{state}, Not included in the dictionary: {CurrentState}");
        }
    }
}
