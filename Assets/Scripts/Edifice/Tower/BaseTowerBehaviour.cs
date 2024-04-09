using RiftDefense.Edifice.Tower.Model;
using RiftDefense.Generic;
using System;
using UnityEngine;

namespace RiftDefense.Edifice.Tower.View
{
    public abstract class BaseTowerBehaviour : MonoBehaviour, ITower
    {
        [SerializeField] private DataTowerAtack _dataTowerAtack;
        [SerializeField] private DataHealf _dataHealf;

        public DataHealf DataHealf => _dataHealf;
        public DataTowerAtack DataAtack => _dataTowerAtack;

        public event Action Died;

        public void ApplyDamage(float damage)
        {
            _dataHealf.ApplyDamage(damage);
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }
    }
}