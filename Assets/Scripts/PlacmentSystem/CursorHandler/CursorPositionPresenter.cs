using RiftDefense.InputSustem;
using RiftDefense.PlacmentSystem.Model;
using UnityEngine;
using Zenject;

namespace RiftDefense.PlacmentSystem.Presenter
{
    public class CursorPositionPresenter
    {
        private DataCursor _dataCursor;

        private Vector3 _lastPostion = Vector3.zero;
        private const float _maxDistanceRaycast = 100f;

        private IInputPlacement _inputPlacement;

        public CursorPositionPresenter(DataCursor dataCursor,IInputPlacement inputPlacement)
        {
            _inputPlacement = inputPlacement;
            _dataCursor = dataCursor;
        }

        public Vector3 GetSelectedMapPosition()
        {
            var mousePosition = Input.mousePosition;
            mousePosition.z = _dataCursor.Camera.nearClipPlane;

            Ray ray = _dataCursor.Camera.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _maxDistanceRaycast, _dataCursor.PlacementLayerMask))
                _lastPostion = hit.point;

            return _lastPostion;
        }

        public Vector3Int GetSelectedGridPosition(Grid grid)
        {
            Vector3 mousePosition = GetSelectedMapPosition();
            Vector3Int gridPosition = grid.WorldToCell(mousePosition);

            return gridPosition;
        }
    }
}
