using Lean.Pool;
using RiftDefense.Edifice.Tower;
using RiftDefense.Generic;
using RiftDefense.Generic.Interface;
using System;
using UnityEngine;

namespace RiftDefense.Edifice.Mining
{
    [RequireComponent(typeof(MiningSystem))]
    public class MiningStation : MonoBehaviour, IPoolable, ITower
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private DataHealf _dataHeafl;

        private MiningSystem _miningSystem;

        public bool Enabel { get; private set; }

        public Vector3Int GridPosition { get; set; }

        public event Action<IEnemy> Dead;

        private void Awake() => _miningSystem = GetComponent<MiningSystem>();
        public void ApplyDamage(float damage) => _dataHeafl.ApplyDamage(damage);
        public Vector3 GetPosition() => transform.position;

        private void OnDead()
        {
            Enabel = false;
            _collider.enabled = false;
            Dead?.Invoke(this);
            LeanPool.Despawn(this, 0.1f);
        }

        public void DespawnTower() => OnDead();

        public void OnSpawn()
        {
            Enabel = true;
            _collider.enabled = true;
            _dataHeafl.ResetDataHealf();
            _dataHeafl.Dead += OnDead;
        }

        public void OnDespawn()
        {
            
            _dataHeafl.Dead -= OnDead;
        }
    }
}
