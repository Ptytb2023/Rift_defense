using RiftDefense.Edifice;
using UnityEngine;

namespace RiftDefense.PlacmentSystem.Presenter
{
    public class PlacementState : IPlacementState
    {
        private GridData _gridData;

        public PlacementState(GridData gridData)
        {
            _gridData = gridData;
        }

        public void OnAction(Vector3Int gridPosition, EdificePlacmentMainView edifice)
        {
            bool isCreate = _gridData.CanPlaceObjectAt(gridPosition) && edifice is not null;

            if (isCreate)
                return;

            _gridData.AddObjectAt(gridPosition, edifice);
        }

    }
}