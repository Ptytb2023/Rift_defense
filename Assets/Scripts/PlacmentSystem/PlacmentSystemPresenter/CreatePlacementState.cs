using RiftDefense.Edifice;
using UnityEngine;

namespace RiftDefense.PlacmentSystem.Presenter
{
    public class CreatePlacementState : IPlacementState
    {
        private Grid _grid;
        private GridData _gridData;

        public CreatePlacementState(GridData gridData, Grid grid)
        {
            _gridData = gridData;
            _grid = grid;
        }

        public void OnAction(Vector3Int gridPosition, EdificePlacmentMainView edifice)
        {
            bool Freely = _gridData.CanPlaceObjectAt(gridPosition) && edifice is not null;

            if (!Freely)
                return;

            var spawnPosition = _grid.CellToWorld(gridPosition);

            var gameObject = edifice.SpawnObject(spawnPosition);
            gameObject.SetActive(true);
            _gridData.AddObjectAt(gridPosition, gameObject);
        }

    }
}