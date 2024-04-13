using RiftDefense.Edifice;
using RiftDefense.PlacmentSystem.Presenter;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace RiftDefense.UI.Shopping
{
    public class TowerShopScreen : MonoBehaviour
    {
        [SerializeField] private PlacmentSystemPresenter _placmentSystemPresenter;
        [SerializeField] private Button _removeEdifice;
        [SerializeField] private Transform _panelShoop;
        [SerializeField] private TowerBuyView _prefabBuyView;

        private void Init(List<SystemEdificeView> systemdifices)
        {
            foreach (var edifice in systemdifices)
            {
                var buyView = Instantiate(_prefabBuyView, _panelShoop);

                buyView.Init(edifice);
                buyView.ButtonClick += ButtonClickBuy;
            }
        }

        private void ButtonClickBuy(SystemEdificeView systemEdificeView)
        {
           
        }


    }
}