using RiftDefense.Edifice.Tower;
using RiftDefense.Generic.Interface;
using System;

using UnityEngine;

public class MainTower : MonoBehaviour, IMainTower
{
    [SerializeField] private Transform _point;

    public bool Enabel => enabled;

    public event Action<IEnemy> Dead;

    public void ApplyDamage(float damage)
    {
        Debug.Log("Attack Main Tower");
    }

    public Vector3 GetPosition()
    {
        return _point.position;
    }
}
