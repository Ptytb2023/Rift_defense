using UnityEngine;

namespace RiftDefense.PlacmentSystem.Presenter
{
    public interface ICursorPositionPresenter
    {
        Vector3Int GetSelectedGridPosition(Grid grid);
        Vector3 GetSelectedMapPosition();
    }
}