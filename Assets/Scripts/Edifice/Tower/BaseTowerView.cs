using RiftDefense.Edifice.Tower.Model;
using RiftDefense.Generic;
using RiftDefense.Generic.Interface;
using System;
using UnityEngine;

namespace RiftDefense.Edifice.Tower.View
{
    public abstract class BaseTowerView : MonoBehaviour, ITower, IPreviewTower
    {
        [SerializeField] private DataTowerAtack _dataTowerAtack;
        [SerializeField] private DataHealf _dataHealf;

        public DataHealf DataHealf => _dataHealf;
        public DataTowerAtack DataAtack => _dataTowerAtack;

        public event Action Died;

        protected abstract void UpdateView();
        public abstract void PreviewAtack(IEnemy enemy);


        public void ApplyDamage(float damage)
        {
            _dataHealf.ApplyDamage(damage);
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        private void Update()
        {
            UpdateView();
        }
               
    }
}