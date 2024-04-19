using System;
using UnityEngine;

namespace RiftDefense.InputSustem
{
    public class InputPlacement : InputBase, IInputPlacement
    {
        public InputPlacement(InputManager inputMap) : base(inputMap)
        {
        }

        public event Action ClickAction;
        public event Action ClickExit;

        public Vector2 GetMousePosition()
        {
            return InputManager.InputMap.Mouse.MousePosition.ReadValue<Vector2>();
        }

        protected override void Enable()
        {
            InputManager.InputMap.Mouse.LeftButton.started += stx => ClickAction?.Invoke();
            InputManager.InputMap.Keyboard.Exit.started += stx => ClickExit?.Invoke();
        }

        protected override void Disable()
        {
            InputManager.InputMap.Mouse.LeftButton.started -= stx => ClickAction?.Invoke();
            InputManager.InputMap.Keyboard.Exit.started -= stx => ClickExit?.Invoke();
        }
       
    }
}
