using System;
using System.Collections.Generic;
using UnityEngine;

namespace RiftDefense.FSM
{
    public abstract class StateMachine : MonoBehaviour
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


        protected virtual void OnEnable()
        {
            CurrentState = StartState;
            CurrentState.Enter();
        }


        private void OnDisable()
        {
            CurrentState?.Exit();
            CurrentState = null;
        }

        private void Update()
        {
            CurrentState.Update();
        }

        public void SetState(Type typeState)
        {
            if (CurrentState != null)
                if (CurrentState.GetType() == typeState)
                    throw new Exception($"{typeState}, Already enabel");

            if (States.TryGetValue(typeState, out var newState))
            {
                CurrentState?.Exit();
                CurrentState = newState;
                CurrentState.Enter();
            }
            else
                throw new ArgumentException($"{typeState}, Not included in the dictionary: {CurrentState}");
        }
    }
}
