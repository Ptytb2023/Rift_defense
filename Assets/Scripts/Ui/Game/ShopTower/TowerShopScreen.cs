using RiftDefense.Edifice;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RiftDefense.UI.Shopping
{
    public class TowerShopScreen : MonoBehaviour
    {
        [SerializeField] private Transform _panelShoop;
        [SerializeField] private TowerBuyView _prefabBuyView;
        [SerializeField] private Button _removeButtonEdifice;

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

                _towerBuyViews.Add(buyView);
            }
        }

        private void OnEnable()
        {
            _removeButtonEdifice.onClick.AddListener(OnRemoveClick);
        }

        private void OnDisable()
        {
            _removeButtonEdifice.onClick.RemoveListener(OnRemoveClick);

            foreach (var BuyView in _towerBuyViews)
                BuyView.ButtonClick -= ButtonClickBuy;
        }

        private void ButtonClickBuy(SystemEdificeView systemEdificeView)
            => ButtonClickCreat?.Invoke(systemEdificeView);

        private void OnRemoveClick()=>ButtonClickRemove?.Invoke();
    }
}