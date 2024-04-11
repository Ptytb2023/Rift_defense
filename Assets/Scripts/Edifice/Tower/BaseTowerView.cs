using RiftDefense.Edifice.Tower.Model;
using RiftDefense.Generic;
using RiftDefense.Generic.Interface;
using System;
using UnityEngine;

namespace RiftDefense.Edifice.Tower.View
{
    [RequireComponent(typeof(Animator))]
    public abstract class BaseTowerView : MonoBehaviour, ITower, IPreviewTower
    {
        [SerializeField] private BaseDataTowerAttack _dataTowerAtack;
        [SerializeField] private DataHealf _dataHealf;
        [SerializeField] private DataAnimator _dataAnimator;

        public DataHealf DataHealf => _dataHealf;
        public BaseDataTowerAttack DataAtack => _dataTowerAtack;
        public DataAnimator DataAnimator => _dataAnimator;

        public Animator Animator { get; private set; }

        public event Action Dead;

        public abstract void PreviewAtack(IEnemy enemy);

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