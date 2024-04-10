using RiftDefense.Edifice;
using UnityEngine;

namespace RiftDefense.PlacmentSystem.Presenter
{
    public class RemovePlacementState : IPlacementState
    {
        private GridData _gridData;

        public RemovePlacementState(GridData gridData)
        {
            _gridData = gridData;
        }

        public void OnAction(Vector3Int gridPosition, EdificePlacmentMainView edifice)
        {
            bool isRemove = _gridData.CanPlaceObjectAt(gridPosition);

            if (isRemove)
                return;

            _gridData.RemoveObjectAt(gridPosition);
        }
    }
}