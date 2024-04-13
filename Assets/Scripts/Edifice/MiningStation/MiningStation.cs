using RiftDefense.Edifice.Tower;
using RiftDefense.Generic;
using RiftDefense.Generic.Interface;
using System;
using UnityEngine;

namespace RiftDefense.Edifice.Mining
{
    [RequireComponent(typeof(MiningSystem))]
    public class MiningStation : MonoBehaviour, ITower
    {
        [SerializeField] private DataHealf _dataHeafl;

        private MiningSystem _miningSystem;

        public bool Enabel => gameObject.activeSelf;
        public event Action<IEnemy> Dead;

        private void Awake() => _miningSystem = GetComponent<MiningSystem>();
        public void ApplyDamage(float damage) => _dataHeafl.ApplyDamage(damage);
        public Vector3 GetPosition()=> transform.position;
       

        private void OnEnable()
        {
            _dataHeafl.ResetDataHealf();
            _dataHeafl.Dead += OnHpOver;
        }

        private void OnDisable() 
        {
            _dataHeafl.Dead -= OnHpOver;
            Dead?.Invoke(this);
        }

        private void OnHpOver() => Dead?.Invoke(this);

    }
}
