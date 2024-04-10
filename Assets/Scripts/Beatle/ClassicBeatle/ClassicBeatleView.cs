using RiftDefense.Generic;
using System;
using UnityEngine;

namespace RiftDefense.Beatle
{
    public class ClassicBeatleView : MonoBehaviour, IBeatle
    {
        [SerializeField] private DataHealf _dataHealf;
        [SerializeField] private float _speed;

        public event Action Dead;

        private void Update()
        {
            
        }

        public void ApplyDamage(float damage)
        {
            _dataHealf.ApplyDamage(damage);
            Debug.Log(damage);
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }
    }
}
