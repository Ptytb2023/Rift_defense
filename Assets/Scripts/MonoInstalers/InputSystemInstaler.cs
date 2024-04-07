using NewInputSystem;
using RiftDefense.InputSustem;
using Zenject;

public class InputSystemInstaler : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<InputMap>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<InputPlacement>().FromNew().AsSingle().NonLazy();
    }
}