using RiftDefense.InputSustem;
using System;


public class InputShopTower : InputBase
{

    public event Action<int> OnButtonClick;
   

    public InputShopTower(InputManager inputManager)
        : base(inputManager)
    {
    }

    protected override void Disable()
    {
        InputManager.InputMap.Shop.First.started -= stx => OnButtonClick?.Invoke(0);
        InputManager.InputMap.Shop.Second.started -= stx => OnButtonClick?.Invoke(1);
        InputManager.InputMap.Shop.Third.started -= stx => OnButtonClick?.Invoke(2);
        InputManager.InputMap.Shop.Fourth.started -= stx => OnButtonClick?.Invoke(3);
    }

    protected override void Enable()
    {
        InputManager.InputMap.Shop.First.started += stx => OnButtonClick?.Invoke(0);
        InputManager.InputMap.Shop.Second.started += stx => OnButtonClick?.Invoke(1);
        InputManager.InputMap.Shop.Third.started += stx => OnButtonClick?.Invoke(2);
        InputManager.InputMap.Shop.Fourth.started += stx => OnButtonClick?.Invoke(3);
    }
}
