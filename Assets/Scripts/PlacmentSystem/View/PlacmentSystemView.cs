using RiftDefense.Edifice;
using RiftDefense.InputSustem;
using RiftDefense.PlacmentSystem.Model;
using RiftDefense.PlacmentSystem.Presenter;
using RiftDefense.Player.Container;
using RiftDefense.UI.Shopping;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace RiftDefense.PlacmentSystem.View
{
    [RequireComponent(typeof(PlacmentSystemPresenter))]
    public class PlacmentSystemView : MonoBehaviour
    {
        [SerializeField] private TowerShopScreen _towerShopScreen;
        [SerializeField] private List<SystemEdificeView> _systemEdificeViews;
        [SerializeField] private ContainerPolymers _containerPolymers;

        [Space]
        [SerializeField] private DataCursor _dataCursor;

        [Space]
        [SerializeField] private DataPreviewSystem _previewSystemData;

        [Space]
        [SerializeField] private PlacmentSystemData _placmentSystemData;

        [Inject]
        private IInputPlacement _input;

        private PlacmentSystemPresenter _placmentSystemPresenter;

        private RemovePlacementState _removeState;
        private CreatePlacementState _creatState;
        private GridData _gridData;

        public DataCursor DataCursor => _dataCursor;
        public DataPreviewSystem DataPreviewSystem => _previewSystemData;
        public PlacmentSystemData PlacmentSystemData => _placmentSystemData;
        public GridData GridData => _gridData;


        private void Awake()
        {
            _placmentSystemPresenter = GetComponent<PlacmentSystemPresenter>();
            Initialization();
        }


        private void OnEnable()
        {
            _towerShopScreen.ButtonClickCreat += OnClickCreat;
            _towerShopScreen.ButtonClickRemove += OnClickRemove;
        }

        private void OnDisable()
        {
            _towerShopScreen.ButtonClickCreat -= OnClickCreat;
            _towerShopScreen.ButtonClickRemove -= OnClickRemove;
        }

        private void Initialization()
        {
            _gridData = new GridData();

            _removeState = new RemovePlacementState(GridData);
            _creatState = new CreatePlacementState(GridData, PlacmentSystemData.Grid, _containerPolymers);

            List<SystemEdificeView> edificeViews = new List<SystemEdificeView>();

            foreach (var systemEdificeView in _systemEdificeViews)
            {
                var edifice = Instantiate(systemEdificeView);
                edifice.gameObject.SetActive(false);
                edificeViews.Add(edifice);

            }

            _towerShopScreen.Init(edificeViews);
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

        private void OnClickCreat(SystemEdificeView systemEdificeView)
        {
            _placmentSystemPresenter.StartPlacement(systemEdificeView);
        }

        private void OnClickRemove()
        {
            _placmentSystemPresenter.StartPlacement(null, TypePlacement.Remove);
        }

    }
}