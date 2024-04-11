using System;
using UnityEngine;

namespace RiftDefense.Edifice.Tower.Model
{
    [Serializable]
    public class BaseDataTowerAttack
    {
        [field: SerializeField] public float DelayBetweenShots { get; private set; }
        [field: SerializeField] public float TimeReload { get; private set; }
        [field: SerializeField] public int AmountAmmunition { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float RadiusAtack { get; private set; }
        [field: SerializeField] public TimeSpan DelayBetweenSeatchTarget { get; private set; }
        [field: SerializeField] public LayerMask Obstacle { get; private set; }
        [field: SerializeField] public bool ShootThroughObstacle { get; private set; }
    }
}