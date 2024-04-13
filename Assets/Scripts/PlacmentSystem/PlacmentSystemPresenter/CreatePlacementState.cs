using RiftDefense.Edifice;
using RiftDefense.Player.Container;
using UnityEngine;

namespace RiftDefense.PlacmentSystem.Presenter
{
    public class CreatePlacementState : IPlacementState
    {
        private Grid _grid;
        private GridData _gridData;
        private ContainerPolymers _containerPolymers;

        public CreatePlacementState(GridData gridData, Grid grid, ContainerPolymers containerPolymers)
        {
            _gridData = gridData;
            _grid = grid;
            _containerPolymers = containerPolymers;
        }

        public void OnAction(Vector3Int gridPosition, EdificePlacmentMainView edifice)
        {
            bool Freely = !_gridData.CanPlaceObjectAt(gridPosition) && edifice is not null;

            if (Freely)
                return;

            if (!_containerPolymers.TryTakePolymers(edifice.PriceEdifice))
                return;


            var spawnPosition = _grid.CellToWorld(gridPosition);

            var gameObject = edifice.SpawnObject(spawnPosition);
            gameObject.SetActive(true);
            _gridData.AddObjectAt(gridPosition, gameObject);
        }

    }
}