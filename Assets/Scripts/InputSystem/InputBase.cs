using NewInputSystem;
using RiftDefense.Generic.Interface;
using System;
using Zenject;

namespace RiftDefense.InputSustem
{
    public abstract class InputBase : IInputBase, IActive, IDisposable 
    {
        [Inject]
        protected InputMap InputMap;

        public InputBase()
        {
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