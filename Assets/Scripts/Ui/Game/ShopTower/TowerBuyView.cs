using RiftDefense.Edifice;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RiftDefense.UI.Shopping
{
    public class TowerBuyView : MonoBehaviour
    {
        [SerializeField] private Image _iconTower;
        [SerializeField] private Button _buttonBuy;
        [SerializeField] private TMP_Text _labelPrice;
        [SerializeField] private TMP_Text _labelDescription;

        private SystemEdificeView _edifice;

        public event Action<SystemEdificeView> ButtonClick;


        public void Init(SystemEdificeView edifice)
        {
            _edifice = edifice;

            var icon = edifice.DataEdiface.IconForShop;
            var prive = edifice.DataEdiface.PricesBuy;
            var description = edifice.DataEdiface.Description;

            _labelPrice.text = description;
            _labelDescription.text = description;
            _iconTower.sprite = icon;
        }

        private void OnEnable() => _buttonBuy.onClick.AddListener(OnClick);

        private void OnDisable() => _buttonBuy.onClick.RemoveListener(OnClick);
       
        private void OnClick() => ButtonClick?.Invoke(_edifice);
    }
}
