using RiftDefense.InputSustem;
using RiftDefense.PlacmentSystem.Model;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace RiftDefense.PlacmentSystem.Presenter

{
    public class CursorPositionHexPresenter : ICursorPositionPresenter
    {
        private DataCursor _dataCursor;
        private Tilemap _tilemap;

        private Vector3 _lastPostion = Vector3.zero;
        private Vector3Int _lastPositionTileMap = Vector3Int.zero;
        private const float _maxDistanceRaycast = 100f;

        private IInputPlacement _inputPlacement;

        public CursorPositionHexPresenter(DataCursor dataCursor, IInputPlacement inputPlacement, Tilemap tileMap)
        {
            _dataCursor = dataCursor;
            _tilemap = tileMap;
            _inputPlacement = inputPlacement;
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

            if (_tilemap.GetTile(gridPosition))
            {
                _lastPositionTileMap = gridPosition;
                return gridPosition;
            }
            else
                return _lastPositionTileMap;
        }
    }
}
