using NewInputSystem;
using System;
using UnityEngine;

namespace RiftDefense.InputSustem
{
    public class InputPlacement : InputBase, IInputPlacement
    {
        public event Action ClickAction;
        public event Action ClickExit;

        public Vector3 GetMousePosition()
        {
            return InputMap.Mouse.MousePosition.ReadValue<Vector3>();
        }

        protected override void Enable()
        {
            InputMap.Mouse.LeftButton.performed += stx => ClickAction?.Invoke();
            InputMap.Keyboard.Exit.performed += stx => ClickExit?.Invoke();
        }

        protected override void Disable()
        {
            InputMap.Keyboard.Exit.performed -= stx => ClickExit?.Invoke();
            InputMap.Mouse.LeftButton.performed -= stx => ClickAction?.Invoke();
        }
    }
}