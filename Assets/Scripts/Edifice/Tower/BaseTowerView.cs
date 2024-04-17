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
        [field: SerializeField] public bool isAllTarget { get; private set; }
        [field: SerializeField] public int MaxCapacityTarget { get; private set; }
        public int CurrentCoutTarget { get; set; }

        [SerializeField] private Collider _collider;
        [SerializeField] private DataTowerAttack _baseDataTowerAttack;
        [SerializeField] private DataHealf _dataHealf;
        [SerializeField] private DataAnimator _dataAnimator;

        //private Coroutine _fixedTarget;
        //private WaitForSeconds _secondDelay;

        public DataTowerAttack DataAttack => _baseDataTowerAttack;
        public DataHealf DataHealf => _dataHealf;
        public DataAnimator DataAnimator => _dataAnimator;

        public bool Enabel { get; private set; }

        public Vector3Int GridPosition { get; set; }

        public event Action<IEnemy> Dead;

        private Coroutine _lookAt;

        public abstract void PreviewAtack(IBeatle enemy);

        public void PrewiwSearch(bool active)
        {
            //if (!active)
            //    _dataAnimator.Animator.StopPlayback();
            //else
            //    _dataAnimator.Animator.Play(_dataAnimator.ModeSearch);
        }

        public void ShowDead()
        {
            _dataAnimator.Animator.Play(_dataAnimator.Dead);
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

        protected virtual void OnDead()
        {
            //if (_fixedTarget != null)
            //    StopCoroutine(_fixedTarget);

            Enabel = false;
            Dead?.Invoke(this);
            _collider.enabled = false;
            ShowDead();
            LeanPool.Despawn(this, DataAnimator.DelayDespawn);
        }

        public virtual void OnSpawn()
        {
            //_secondDelay = new WaitForSeconds(10f);

            //_fixedTarget = StartCoroutine(cheakTargeta());
            //_dataAnimator.Animator.SetBool(_dataAnimator.Dead, false);
            CurrentCoutTarget = 0;
            _collider.enabled = true;
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

        //private IEnumerator cheakTargeta()
        //{
        //    while (Enabel)
        //    {
        //        yield return _secondDelay;

        //        if (CurrentCoutTarget >= MaxCapacityTarget)
        //        {
        //            CurrentCoutTarget--;
        //        }

        //    }
        //}


        public bool AddEnemyTarget(IEnemy enemy)
        {
            if (CurrentCoutTarget >= MaxCapacityTarget)
                return false;

            if (!isAllTarget)
                if (MaxCapacityTarget / 2 <= CurrentCoutTarget)
                {
                    int chanche = UnityEngine.Random.Range(0, 100);

                    if (chanche > 50)
                    {
                        CurrentCoutTarget++;
                        enemy.Dead += OnEnemyDeadTarget;
                        return true;
                    }
                    else
                        return false;
                }

            CurrentCoutTarget++;
            enemy.Dead += OnEnemyDeadTarget;
            return true;
        }

        private void OnEnemyDeadTarget(IEnemy enemy)
        {
            enemy.Dead -= OnEnemyDeadTarget;
            CurrentCoutTarget--;
        }

    }
}