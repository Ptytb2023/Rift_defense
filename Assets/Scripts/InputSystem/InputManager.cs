using NewInputSystem;
using RiftDefense.InputSustem;
using System;
using Zenject;

public class InputManager : IInputBase, IDisposable
{
    public InputMap InputMap { get; set; }

    [Inject]
    public InputManager(InputMap inputMap)
    {
        InputMap = inputMap;
        Enable();
    }

    public void SetActive(bool active)
    {
        if (active)
            Enable();
        else
            Disable();
    }


    protected void Enable()
    {
        InputMap.Enable();
    }

    protected void Disable()
    {
        InputMap.Disable();
    }

    public void Dispose()
    {
        Disable();
    }
}
