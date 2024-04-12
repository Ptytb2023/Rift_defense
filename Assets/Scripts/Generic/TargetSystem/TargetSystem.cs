using System;
using RiftDefense.Generic.Interface;
using System.Collections.Generic;
using UnityEngine;

namespace RiftDefense.Generic
{
    public class TargetSystem<T> : ITargetSystem<T> where T : IEnemy
    {
        private Transform _transform;
        private float _radius;
        private LayerMask _layerMask;

        private Collider[] _colliders;

        public TargetSystem(Transform transform, float radius, LayerMask layerMask)
        {
            _transform = transform;
            _radius = radius;
            _layerMask = layerMask;
        }

        public bool TryGetClosestTargetInRadius(out T target)
        {
            target = default;

            if (!TryGetAllTargetsInRadius(out List<T> targets))
                return false;

            target = SearchClossetEnemy(_transform.position, targets);
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


    }
}
