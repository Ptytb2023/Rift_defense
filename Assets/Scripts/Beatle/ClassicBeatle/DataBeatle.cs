using RiftDefense.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace RiftDefense.Beatle.Model
{

    [Serializable]
    public class DataAttackBeatle
    {
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float DelayBetweenAttack { get; private set; }
        [field: SerializeField] public float AttackDistance { get; private set; }
        [field: SerializeField] public float DelayBetweenSearch { get; private set; }
        [field: SerializeField] public float RadiusSearch { get; private set; }
        [field: SerializeField] public LayerMask EnemyMask { get; private set; }
    }

    [Serializable]
    public class DataMoveBeatle
    {
        [field: SerializeField] public NavMeshAgent NavMeshAgent { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }

    }

    [Serializable]
    public class DataAnimationBeatle
    {
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public string Idel { get; private set; }
        [field: SerializeField] public string Attack { get; private set; }
        [field: SerializeField] public string Move { get; private set; }
        [field: SerializeField] public string Dead { get; private set; }
    }
}