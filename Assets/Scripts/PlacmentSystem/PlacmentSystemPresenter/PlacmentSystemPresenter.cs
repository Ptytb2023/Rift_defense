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
        private CursorPositionPresenter _cursorPositionPresenter;
        private PreviewPresenter _preview;

        [Inject]
        private GridData _gridData;
        private IPlacementState _currentState;

        private RemovePlacementState _removeState;
        private CreatePlacementState _creatState;

        private EdificePlacmentMainView _currentEdifice;
        private Vector3Int _lastDetectedPosition = Vector3Int.zero;

        private Coroutine _placementSystemUpdate;

        private Grid _grid => _placmentSystemView.PlacmentSystemData.Grid;


        private void Start()
        {
            _placmentSystemView = GetComponent<PlacmentSystemView>();

            _cursorPositionPresenter = new CursorPositionPresenter(_placmentSystemView.DataCursor, _input);
            _preview = new PreviewPresenter(_placmentSystemView.DataPreviewSystem);
            _removeState = new RemovePlacementState(_gridData);
            _creatState = new CreatePlacementState(_gridData, _placmentSystemView.PlacmentSystemData.Grid);

            StopPlacement();
        }

        public void StartPlacement(EdificePlacmentMainView edifice, TypePlacement type = TypePlacement.Creat)
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
        }

        private void SetState(TypePlacement type)
        {
            _currentState = type == TypePlacement.Creat ? _creatState : _removeState;
        }

        private void PlaceStructure()
        {
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