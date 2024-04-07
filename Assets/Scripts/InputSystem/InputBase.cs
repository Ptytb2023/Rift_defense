using NewInputSystem;
using RiftDefense.Generic.Interface;
using System;
using Zenject;

namespace RiftDefense.InputSustem
{
    public abstract class InputBase : IInputBase, IActive, IDisposable
    {
        protected InputMap InputMap;

        [Inject]
        public InputBase(InputMap inputMap)
        {
            InputMap = inputMap;
            Enable();
        }

        protected abstract void Enable();
        protected abstract void Disable();

        public void SetActive(bool active)
        {
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