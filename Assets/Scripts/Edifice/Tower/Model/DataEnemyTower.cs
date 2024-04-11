using RiftDefense.Generic.Interface;
using RiftDefense.Beatle;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace RiftDefense.Edifice.Tower.Model
{
    public class DataEnemy : IDataEnemy
    {
        private List<IEnemy> _beatles = new List<IEnemy>();

        public IEnumerable<IEnemy> GetEnemies()
        {
           return _beatles;
        }

        public void AddEnemy(IEnemy enemy)
        {
            if (enemy is null)
                throw new ArgumentNullException($"Argumet:{enemy} Null");

           _beatles.Add(enemy);
        }

        public bool RemoveEnemy(IEnemy enemy)
        {
            return _beatles.Remove(enemy);
        }

        public bool FindNearbyEnemyFromPosition(Vector3 position,out IEnemy enemu)
        {
            enemu = null;

            if (_beatles.Count==0) 
                return false;

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
