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
        [SerializeField] private BaseTower _baseTower;
        [SerializeField] public DataDetecteble _dataDetecteble;
        [SerializeField] private GameObject _sekelt;


        [SerializeField] private Collider _collider;
        [SerializeField] private DataTowerAttack _baseDataTowerAttack;
        [SerializeField] private DataHealf _dataHealf;
        [SerializeField] private DataAnimator _dataAnimator;
        [SerializeField] private EffectTowerDead _effectTowerDead;


        //private Coroutine _fixedTarget;
        //private WaitForSeconds _secondDelay;

        public DataTowerAttack DataAttack => _baseDataTowerAttack;
        public DataHealf DataHealf => _dataHealf;
        public DataAnimator DataAnimator => _dataAnimator;

        public bool Enabel { get; private set; }
        public Detecteble Detecteble { get; private set; }
        public Vector3Int GridPosition { get; set; }

        public event Action<IEnemy> Dead;

        private Coroutine _lookAt;

        public abstract void PreviewAtack(IBeatle enemy);

        private void Awake()
        {
            Detecteble = new Detecteble(_dataDetecteble);
        }

        public void PrewiwSearch(bool active)
        {
            //if (!active)
            //    _dataAnimator.Animator.StopPlayback();
            //else
            //    _dataAnimator.Animator.Play(_dataAnimator.ModeSearch);
        }

        public void ShowDead()
        {
            if (_sekelt != null)
            {
                _sekelt?.gameObject.SetActive(true);
                DataAnimator.AnimationModel?.gameObject.SetActive(false);
            }

            if (_lookAt != null)
                StopCoroutine(_lookAt);
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
            _baseTower.enabled = false;
            Enabel = false;
            Dead?.Invoke(this);
            _collider.enabled = false;
            ShowDead();
            LeanPool.Despawn(this, DataAnimator.DelayDespawn);
            LeanPool.Spawn(_effectTowerDead, transform.position, Quaternion.identity);
        }

        public virtual void OnSpawn()
        {
            _baseTower.enabled = true;
            if (_sekelt != null)
            {
                _sekelt?.gameObject.SetActive(false);
                DataAnimator.AnimationModel?.gameObject.SetActive(true);
            }

            Detecteble.Reseting();

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




    }
}