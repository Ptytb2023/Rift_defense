using RiftDefense.InputSustem;
using System;
using Zenject;

public class InputMenu : InputBase, IInputMenu
{
    [Inject]
    public InputMenu(InputManager inputManager) : base(inputManager)
    {
    }

    public event Action clickEscape;

    protected override void Disable()
    {
        InputManager.InputMap.UI.PouseClick.started -= stx => clickEscape?.Invoke();
    }

    protected override void Enable()
    {
        InputManager.InputMap.UI.PouseClick.started += stx => clickEscape?.Invoke();
    }
}
