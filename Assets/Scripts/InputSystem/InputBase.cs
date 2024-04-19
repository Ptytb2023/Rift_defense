using NewInputSystem;
using RiftDefense.Generic.Interface;
using System;
using Zenject;

namespace RiftDefense.InputSustem
{
    public abstract class InputBase : IInputBase, IActive, IDisposable
    {
        protected InputManager InputManager;

        public bool Enabel { get; private set; }

        [Inject]
        public InputBase(InputManager inputManager)
        {
            InputManager = inputManager;
            Enable();
        }

        protected abstract void Enable();
        protected abstract void Disable();

        public void SetActive(bool active)
        {
            Enabel = active;

            if (active)
                Enable();
            else
                Disable();
        }

        public void Dispose()
        {
            Disable();
        }
    }
}