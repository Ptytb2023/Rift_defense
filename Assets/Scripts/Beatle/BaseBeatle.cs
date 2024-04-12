using RiftDefense.Edifice.Tower;
using RiftDefense.Generic;
using RiftDefense.Generic.Interface;
using System;
using System.Collections;
using UnityEngine;

namespace RiftDefense.Beatle
{
    [RequireComponent(typeof(BeatleView))]
    public abstract class BaseBeatle : MonoBehaviour, IBeatle
    {
        protected BeatleView BeatleView;
        protected ITower CurrentTarget { get; private set; }
        public bool Enabel => gameObject.activeSelf;

        private IMainTower _mainTower;
        private ITargetSystem<ITower> _targetSystem;

        private Coroutine _searchCorutine;
        private Coroutine _distanceCorutine;
        private Coroutine _attackCorutine;


        public event Action<IEnemy> Dead;

        private void Awake()
        {
            BeatleView = GetComponent<BeatleView>();

            float rdiusSearch = BeatleView.DataAttackBeatle.RadiusSearch;
            var maskEnemu = BeatleView.DataAttackBeatle.EnemyMask;

            _mainTower = FindObjectOfType<MainTower>();
            _targetSystem = new TargetSystem<ITower>(transform, rdiusSearch, maskEnemu);

            var meshAgent = BeatleView.DataMoveBeatle.NavMeshAgent;
            meshAgent.speed = BeatleView.DataMoveBeatle.Speed;
            meshAgent.stoppingDistance = BeatleView.DataAttackBeatle.AttackDistance;
        }

        protected abstract IEnumerator PerfomAttack();

        private IEnumerator SearchNewTarget()
        {
            var delay = BeatleView.DataAttackBeatle.DelayBetweenSearch;

            while (CurrentTarget == _mainTower && enabled)
            {
                if (TrySetNewTarget())
                    UpdateMove();

                yield return new WaitForSeconds(delay);
            }
        }

        private IEnumerator TryPerfomAttack()
        {
            bool isActive = true;
            var navMeshAgent = BeatleView.DataMoveBeatle.NavMeshAgent;
            float distacneAttackSqr = Mathf.Pow(BeatleView.DataAttackBeatle.AttackDistance, 2);

            while (isActive && enabled)
            {
                if (GetSqrDistanceToTarget() <= distacneAttackSqr)
                {
                    isActive = false;
                    BeatleView.SetActiovMove(false);
                    yield return PerfomAttack();

                    StartBeatle();
                }

                yield return null;
            }
        }

        private float GetSqrDistanceToTarget()
        {
            var direction = transform.position - CurrentTarget.GetPosition();

            return direction.sqrMagnitude;
        }

        private bool TrySetNewTarget()
        {
            if (!_targetSystem.TryGetClosestTargetInRadius(out ITower tower))
                return false;

            CurrentTarget = tower;
            return true;
        }

        private void UpdateMove()
        {
            var navMeshAgent = BeatleView.DataMoveBeatle.NavMeshAgent;
            navMeshAgent.destination = CurrentTarget.GetPosition();
            BeatleView.SetActiovMove(true);
        }


        private void StartBeatle()
        {
            StopAllCoroutines();

            if (!TrySetNewTarget())
            {
                CurrentTarget = _mainTower;
                StartCoroutine(nameof(SearchNewTarget));
            }

            UpdateMove();
            StartCoroutine(nameof(TryPerfomAttack));
        }

        private void OnEnable()
        {
            BeatleView.DataHealf.ResetDataHealf();
            BeatleView.DataHealf.Dead += OnDead;

            StartBeatle();
        }

        private void OnDisable()
        {
            BeatleView.DataHealf.Dead -= OnDead;

            StopAllCoroutines();
        }

        public Vector3 GetPosition() => transform.position;

        public void ApplyDamage(float damage) => BeatleView.DataHealf.ApplyDamage(damage);

        private void OnDead()
        {
            Dead?.Invoke(this);
            gameObject.SetActive(false);
        }
    }
}