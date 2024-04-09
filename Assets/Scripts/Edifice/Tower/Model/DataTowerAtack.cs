using System;
using UnityEngine;

namespace RiftDefense.Edifice.Tower.Model
{
    [Serializable]
    public class DataTowerAtack
    {
        [field:SerializeField] public float DelayBetweenShots { get; private set; }
        [field:SerializeField] public float TimeReload { get; private set; }
        [field:SerializeField] public int AmountAmmunition { get; private set; }
        [field:SerializeField] public float DamageOneHit { get; private set; }
        [field:SerializeField] public float RadiusAtack { get; private set; }
        [field:SerializeField] public LayerMask Obstacle { get; private set; }
        [field:SerializeField] public bool IgnoreObstacle { get; private set; }
    }
}