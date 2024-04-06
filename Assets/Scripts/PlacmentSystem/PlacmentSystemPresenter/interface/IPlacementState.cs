using RiftDefense.Edifice;
using UnityEngine;

namespace RiftDefense.PlacmentSystem.Presenter
{
    public interface IPlacementState
    {
        public void OnAction(Vector3Int gridPosition, EdificePlacmentMainView edifice);
    }
}