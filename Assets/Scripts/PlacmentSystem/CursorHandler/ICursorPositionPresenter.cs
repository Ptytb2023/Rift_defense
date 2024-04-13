using UnityEngine;

namespace RiftDefense.PlacmentSystem.Presenter
{
    public interface ICursorPositionPresenter
    {
        bool ChangedPosition(Grid grid);
        Vector3Int GetSelectedGridPosition(Grid grid);
        Vector3 GetSelectedMapPosition();
    }
}