using RiftDefense.Edifice;
using RiftDefense.InputSustem;
using RiftDefense.PlacmentSystem.View;
using System.Collections;
using UnityEngine;
using Zenject;

namespace RiftDefense.PlacmentSystem.Presenter
{
    [RequireComponent(typeof(PlacmentSystemView))]
    public class PlacmentSystemPresenter : MonoBehaviour
    {
        [Inject]
        private IInputPlacement _input;

        private PlacmentSystemView _placmentSystemView;
        private ICursorPositionPresenter _cursorPositionPresenter;
        private PreviewSystem _preview;

        private GridData _gridData;
        private IPlacementState _currentState;


        private SystemEdificeView _currentEdifice;
        private Vector3Int _lastDetectedPosition = Vector3Int.zero;

        private Coroutine _placementSystemUpdate;

        private Grid _grid => _placmentSystemView.PlacmentSystemData.Grid;

   
       

        private void Start()
        {
            _placmentSystemView = GetComponent<PlacmentSystemView>();

            _gridData = _placmentSystemView.GridData;
            _cursorPositionPresenter = _placmentSystemView.GetCursorPositionPresenter();
            _preview = new PreviewSystem(_placmentSystemView.DataPreviewSystem);

            StopPlacement();
        }

        public void StartPlacement(SystemEdificeView edifice, TypePlacement type = TypePlacement.Creat)
        {
            StopPlacement();

            _currentEdifice = edifice;
            _placementSystemUpdate = StartCoroutine(UpdatePlacement());

            SetState(type);
            _preview.SetEdificePlacment(edifice);
            _preview.StartShowingPlacementPreview();

            _input.SetActive(true);
            _input.ClickAction += PlaceStructure;
            _input.ClickExit += StopPlacement;

            Vector3Int gridPosition = _cursorPositionPresenter.GetSelectedGridPosition(_grid);

            UpdateState(gridPosition);
        }

        private void SetState(TypePlacement type)
        {
            _currentState = _placmentSystemView.GetPlacementState(type);
        }

        private void PlaceStructure()
        {
            if (_placmentSystemView.IsSelectedButton)
                return;

            if (_cursorPositionPresenter.ChangedPosition(_grid))
                return;

            Vector3Int gridPosition = _cursorPositionPresenter.GetSelectedGridPosition(_grid);

            _currentState.OnAction(gridPosition, _currentEdifice);
            UpdateState(gridPosition);
        }

        private void StopPlacement()
        {
            if (_placementSystemUpdate is not null)
                StopCoroutine(_placementSystemUpdate);

            _currentEdifice = null;

            _preview.StopShowingPreview();

            _input.ClickAction -= PlaceStructure;
            _input.ClickExit -= StopPlacement;
            _input.SetActive(false);
        }

        private IEnumerator UpdatePlacement()
        {
            while (enabled)
            {
                Vector3Int gridPosition = _cursorPositionPresenter.GetSelectedGridPosition(_grid);

                if (_lastDetectedPosition != gridPosition)
                {
                    UpdateState(gridPosition);
                    _lastDetectedPosition = gridPosition;
                }

                yield return null;
            }
        }

        public void UpdateState(Vector3Int gridPosition)
        {
            bool validity = _gridData.CanPlaceObjectAt(gridPosition);
            Vector3 gridWorldPosition = _grid.CellToWorld(gridPosition);
            _preview.UpdatePosition(gridWorldPosition, validity);
        }
    }
}

public enum TypePlacement
{
    Creat = 1,
    Remove = 2,
}