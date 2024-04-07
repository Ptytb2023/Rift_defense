using Zenject;

public class PlacementInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GridData>().FromNew().AsSingle().NonLazy();
        //Container.Bind<CreatePlacementState>().FromNew().AsSingle().NonLazy();
        //Container.Bind<RemovePlacementState>().FromNew().AsSingle().NonLazy();
    }
}
