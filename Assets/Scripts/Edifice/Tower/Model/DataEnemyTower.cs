using RiftDefense.Generic.Interface;
using RiftDefense.Beatle;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace RiftDefense.Edifice.Tower.Model
{
    public class DataEnemyTower : IDataEnemy<IBeatle>
    {
        private List<IBeatle> _beatles = new List<IBeatle>();

        public IEnumerable<IBeatle> GetEnemies()
        {
           return _beatles;
        }

        public void AddEnemy(IBeatle enemy)
        {
            if (enemy is null)
                throw new ArgumentNullException($"Argumet:{enemy} Null");

           _beatles.Add(enemy);
        }

        public bool RemoveEnemy(IBeatle enemy)
        {
            return _beatles.Remove(enemy);
        }

        public bool FindNearbyEnemyFromPosition(Vector3 position,out IBeatle enemu)
        {
            enemu = null;

            float squaredClosestDistance = Mathf.Infinity;

            foreach (var beatle in _beatles)
            {
                Vector3 directionToTarget = beatle.GetPosition() - position;
                var squaredMagnitudeToTarget = directionToTarget.sqrMagnitude;

                if (squaredMagnitudeToTarget < squaredClosestDistance)
                {
                    squaredClosestDistance = squaredMagnitudeToTarget;
                    enemu = beatle;
                }
            }

            return enemu != null;
        }

    }
}
