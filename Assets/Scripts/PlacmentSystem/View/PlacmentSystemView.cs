using RiftDefense.InputSustem;
using RiftDefense.PlacmentSystem.Model;
using RiftDefense.PlacmentSystem.Presenter;
using UnityEngine;
using Zenject;

namespace RiftDefense.PlacmentSystem.View
{
    public class PlacmentSystemView : MonoBehaviour
    {
        [Space]
        [SerializeField] private DataCursor _dataCursor;

        [Space]
        [SerializeField] private DataPreviewSystem _previewSystemData;

        [Space]
        [SerializeField] private PlacmentSystemData _placmentSystemData;

        [Inject]
        private IInputPlacement _input;

        private RemovePlacementState _removeState;
        private CreatePlacementState _creatState;
        private GridData _gridData;

        public DataCursor DataCursor => _dataCursor;
        public DataPreviewSystem DataPreviewSystem => _previewSystemData;
        public PlacmentSystemData PlacmentSystemData => _placmentSystemData;
        public GridData GridData => _gridData;


        private void Awake()
        {
            Initialization();
        }

        private void Initialization()
        {
            _gridData = new GridData();

            _removeState = new RemovePlacementState(GridData);
            _creatState = new CreatePlacementState(GridData, PlacmentSystemData.Grid);
        }

        public IPlacementState GetPlacementState(TypePlacement type)
        {
            return type == TypePlacement.Creat ? _creatState : _removeState;
        }

        public ICursorPositionPresenter GetCursorPositionPresenter()
        {
            if (_placmentSystemData.ISHexMap)
                return new CursorPositionHexPresenter(DataCursor, _input, _placmentSystemData.Tilemap);
            else
                return new CursorPositionPresenter(DataCursor, _input);
        }
    }
}