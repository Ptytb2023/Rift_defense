using RiftDefense.Edifice;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace RiftDefense.UI.Shopping
{
    public class TowerShopScreen : MonoBehaviour
    {
        [SerializeField] private Transform _panelShoop;
        [SerializeField] private TowerBuyView _prefabBuyView;
        [SerializeField] private Button _removeButtonEdifice;

        [Inject]
        private InputShopTower _input;

        public bool ISSelecetButton { get; private set; }

        public event Action<SystemEdificeView> ButtonClickCreat;
        public event Action ButtonClickRemove;

        private List<TowerBuyView> _towerBuyViews;

        public void Init(List<SystemEdificeView> systemdifices)
        {
            _towerBuyViews = new List<TowerBuyView>();

            foreach (var edifice in systemdifices)
            {
                var buyView = Instantiate(_prefabBuyView, _panelShoop);

                buyView.Init(edifice);
                buyView.ButtonClick += ButtonClickBuy;
                buyView.ButtonSelected += OnSelectedButton;

                _towerBuyViews.Add(buyView);
            }
        }

        private void OnEnable()
        {
            _removeButtonEdifice.onClick.AddListener(OnRemoveClick);
            _input.OnButtonClick += OnButtonClickKeyboard;
        }

        private void OnDisable()
        {
            _removeButtonEdifice.onClick.RemoveListener(OnRemoveClick);

            _input.OnButtonClick -= OnButtonClickKeyboard;

            foreach (var BuyView in _towerBuyViews)
                BuyView.ButtonClick -= ButtonClickBuy;

            foreach (var BuyView in _towerBuyViews)
                BuyView.ButtonSelected -= OnSelectedButton;
        }

        private void ButtonClickBuy(SystemEdificeView systemEdificeView)
            => ButtonClickCreat?.Invoke(systemEdificeView);

        private void OnRemoveClick()=>ButtonClickRemove?.Invoke();

        private void OnSelectedButton(bool selected) => ISSelecetButton = selected;

        private void OnButtonClickKeyboard(int index)
        {
            if (index == 3)
            {
                OnRemoveClick();
                return;
            }

           var eddifice = _towerBuyViews[index].Edifice;

            ButtonClickCreat?.Invoke(eddifice);
        }

    }
}