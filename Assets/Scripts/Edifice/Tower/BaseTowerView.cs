using Lean.Pool;
using RiftDefense.Beatle;
using RiftDefense.Edifice.Tower.Model;
using RiftDefense.Generic;
using RiftDefense.Generic.Interface;
using System;
using System.Collections;
using System.Threading;
using UnityEngine;

namespace RiftDefense.Edifice.Tower.View
{
    public abstract class BaseTowerView : MonoBehaviour, ITower, IPoolable
    {
        [SerializeField] private DataTowerAttack _baseDataTowerAttack;
        [SerializeField] private DataHealf _dataHealf;
        [SerializeField] private DataAnimator _dataAnimator;

        public DataTowerAttack DataAttack => _baseDataTowerAttack;
        public DataHealf DataHealf => _dataHealf;
        public DataAnimator DataAnimator => _dataAnimator;

        public bool Enabel { get; private set; }

        public Vector3Int GridPosition { get; set; }

        public event Action<IEnemy> Dead;

        private Coroutine _lookAt;

        public abstract void PreviewAtack(IBeatle enemy);

        public void SetIdel()
        {

        }

        public void ShowDead()
        {

        }

        public void LookingAtEnemy(IBeatle enemy, bool active = true)
        {
            if (_lookAt != null)
                StopCoroutine(_lookAt);

            if (active)
                _lookAt = StartCoroutine(LookAt(enemy));
        }

        private IEnumerator LookAt(IBeatle enemy)
        {
            var head = DataAnimator.Head;
            var speed = DataAnimator.SpeedRotation;

            while (gameObject.activeSelf)
            {
                var direction = enemy.GetPosition() - head.position;
                Quaternion newRotation = Quaternion.LookRotation(direction);
                head.rotation = Quaternion.Slerp(head.rotation, newRotation, speed * Time.deltaTime);

                yield return null;
            }
        }

        public void ApplyDamage(float damage) => _dataHealf.ApplyDamage(damage);

        public Vector3 GetPosition() => transform.position;

        private void OnDead()
        {
            Enabel = false;
            Dead?.Invoke(this);
            ShowDead();
            LeanPool.Despawn(this, DataAnimator.DelayDespawn);
        }

        public virtual void OnSpawn()
        {
            Enabel = true;
            _dataHealf.ResetDataHealf();
            _dataHealf.Dead += OnDead;
        }

        public virtual void OnDespawn()
        {
            Enabel = false;
            _dataHealf.Dead -= OnDead;
        }


        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, DataAttack.RadiusAtack);
        }

        public void DespawnTower() => OnDead();

    }
}