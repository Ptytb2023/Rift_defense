using Cysharp.Threading.Tasks;
using RiftDefense.Edifice.Tower;
using RiftDefense.Generic.Interface;
using System;
using UnityEngine;

public class PointAttackTower : MonoBehaviour, ITower
{
    [SerializeField] private MainTower _mainTower;

    public bool Enabel => _mainTower.Enabel;

    public Vector3Int GridPosition { get; set; }

    public event Action<IEnemy> Dead;

    public void ApplyDamage(float damage)
    {
       _mainTower?.ApplyDamage(damage);
    }

    public void DespawnTower()
    {
        Dead?.Invoke(this);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
