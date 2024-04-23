using RiftDefense.Edifice;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RiftDefense.UI.Shopping
{
    public class TowerBuyView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image _iconTower;
        [SerializeField] private Button _buttonBuy;
        [SerializeField] private TMP_Text _labelPrice;
        [SerializeField] private TMP_Text _labelDescription;

        public SystemEdificeView Edifice { get; private set; }

        public event Action<SystemEdificeView> ButtonClick;
        public event Action<bool> ButtonSelected;

        public void Init(SystemEdificeView edifice)
        {
            Edifice = edifice;

            var icon = edifice.DataEdiface.IconForShop;
            var price = edifice.DataEdiface.PricesBuy;
            var description = edifice.DataEdiface.Description;

            _labelPrice.text = price.ToString();
            _labelDescription.text = description;
            _iconTower.sprite = icon;
        }

        private void OnEnable() => _buttonBuy.onClick.AddListener(OnClick);

        private void OnDisable() => _buttonBuy.onClick.RemoveListener(OnClick);
       
        private void OnClick() => ButtonClick?.Invoke(Edifice);

       

        public void OnPointerExit(PointerEventData eventData)
        {
            ButtonSelected?.Invoke(false);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            ButtonSelected?.Invoke(true);
        }
    }
}
