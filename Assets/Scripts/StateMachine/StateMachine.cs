using System;
using System.Collections.Generic;

namespace RiftDefense.FSM
{
    public class StateMachine
    {
        private Dictionary<Type, BaseState> _states;

        public BaseState CurrentState { get; private set; }

        public StateMachine(Dictionary<Type, BaseState> states, BaseState startState)
        {
            if (states == null || states.Count < 0)
                throw new NullReferenceException($"[{states}] Incorrect data");

            _states = states;
            CurrentState = startState;
        }

        public void SetState<T>() where T : BaseState
        {
            var type = typeof(T);

            if ( CurrentState.GetType() == type)
                throw new Exception($"{type}, Already enabel");

            if (_states.TryGetValue(type, out BaseState baseState))
            {
                CurrentState?.Exit();
                CurrentState = baseState;
                CurrentState.Enter();
            }
            else
                throw new Exception($"{type}, Not included in the dictionary: {CurrentState}");
        }
    }
}
