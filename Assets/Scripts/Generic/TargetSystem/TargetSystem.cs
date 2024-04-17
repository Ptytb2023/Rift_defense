using System;
using RiftDefense.Generic.Interface;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Rendering;

namespace RiftDefense.Generic
{
    public class TargetSystem<T> : ITargetSystem<T> where T : IEnemy
    {
        private IEnemy _source;

        private IEnemy _currentTarget;

        private Transform _transform;
        private float _radius;
        private LayerMask _layerMask;

        private Collider[] _colliders;

        private const int _precentFreeTarget = 50;

        public TargetSystem(Transform transform, IEnemy source, float radius, LayerMask layerMask)
        {
            _transform = transform;
            _radius = radius;
            _layerMask = layerMask;
            _source = source;
        }

        public bool TryGetClosestTargetInRadius(out T target)
        {
            target = default;

            if (!TryGetAllTargetsInRadius(out List<T> targets))
                return false;

            target = SearchClossetEnemy(_transform.position, targets);

            if (target == null)
                return false;
            else
                return true;
        }

        public bool CheakTargetsInRadius()
        {
            return TrySearchTargetInRadius();
        }

        public T FindClossetTarget(List<T> targets)
        {
            if (targets == null || targets.Count is 0)
                throw new NullReferenceException($"{targets} is null or Cout 0");

            return SearchClossetEnemy(_transform.position, targets);
        }

        public bool TryGetAllTargetsInRadius(out List<T> targets)
        {
            targets = new List<T>();

            TrySearchTargetInRadius();

            foreach (Collider collider in _colliders)
            {
                if (collider.TryGetComponent(out T enemy))
                    targets.Add(enemy);
            }

            return targets.Count > 0;
        }

        private bool TrySearchTargetInRadius()
        {
            Vector3 position = _transform.position;
            _colliders = Physics.OverlapSphere(position, _radius, _layerMask.value);

            return _colliders.Length > 0;
        }

        private T SearchClossetEnemy(Vector3 pointPosition, List<T> enemys)
        {
            T closestEnemy = default;

            float squaredClosestDistance = Mathf.Infinity;

            foreach (var enemy in enemys)
            {
                if (!enemy.AddEnemyTarget(_source))
                    break;

                Vector3 directionToTarget = pointPosition - enemy.GetPosition();
                float squaredDirection = directionToTarget.sqrMagnitude;

                if (squaredDirection < squaredClosestDistance)
                {
                    closestEnemy = enemy;
                    squaredClosestDistance = squaredDirection;
                }
            }

            return closestEnemy;
        }

        //private bool TargetFree(IEnemy enemy)
        //{
        //    if (enemy.MaxCapacityTarget <= enemy.CurrentCoutTarget)
        //        return false;

        //    if (!enemy.isAllTarget)
        //        if (enemy.MaxCapacityTarget / 2 <= enemy.CurrentCoutTarget)
        //        {
        //            int chanche = UnityEngine.Random.Range(0, 100);

        //            if (chanche > _precentFreeTarget)
        //            {
        //                RememberTarget(enemy);
        //                return true;
        //            }
        //            else
        //                return false;
        //        }

        //    RememberTarget(enemy);
        //    return true;
        //}

        //private void RememberTarget(IEnemy enemy)
        //{
        //    if (_currentTarget != null)
        //        Debug.Log("ERor");

        //    _source.Dead += OnDeadSource;
        //    _currentTarget = enemy;
        //    _currentTarget.CurrentCoutTarget++;
        //}

        //private void OnDeadSource(IEnemy source)
        //{
        //    _source.Dead -= OnDeadSource;

        //    if (_currentTarget != null)
        //    {
        //        _currentTarget.CurrentCoutTarget--;
        //        _currentTarget = null;
        //    }
        //}

    }
}
