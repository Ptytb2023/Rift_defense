using NewInputSystem;
using System;
using UnityEngine;

namespace RiftDefense.InputSustem
{
    public class InputPlacement : InputBase, IInputPlacement, IInputMenu
    {
        public InputPlacement(InputMap inputMap) : base(inputMap)
        {
        }

        public event Action ClickAction;
        public event Action ClickExit;
        public event Action clickEscape;

        public Vector2 GetMousePosition()
        {
            return InputMap.Mouse.MousePosition.ReadValue<Vector2>();
        }

        protected override void Enable()
        {
            InputMap.Enable();
            InputMap.Mouse.LeftButton.started += stx => ClickAction?.Invoke();
            InputMap.Keyboard.Exit.started += stx => ClickExit?.Invoke();
            InputMap.Ui.Escape.started += stx => OnClickEscape();

        }

        protected override void Disable()
        {
            InputMap.Disable();
            InputMap.Keyboard.Exit.started -= stx => ClickExit?.Invoke();
            InputMap.Mouse.LeftButton.started -= stx => ClickAction?.Invoke();
            InputMap.Ui.Escape.started -= stx => OnClickEscape();

        }


        private void OnClickEscape()
        {
            clickEscape?.Invoke();
        }
    }
}
