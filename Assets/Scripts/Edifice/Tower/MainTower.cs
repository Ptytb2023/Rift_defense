using RiftDefense.Edifice.Tower;
using RiftDefense.Generic;
using RiftDefense.Generic.Interface;
using System;

using UnityEngine;

public class MainTower : MonoBehaviour, IMainTower
{
    
    [SerializeField] private Transform _point;
    [SerializeField] private DataHealf _dataHealf;

    public bool Enabel => gameObject.activeSelf;

    public Vector3Int GridPosition { get; set; }
    public event Action<IEnemy> Dead;


    private void OnEnable()
    {
        _dataHealf.Dead += OnDead;
    }

    private void OnDisable()
    {
        _dataHealf.Dead -= OnDead;
    }

    private void OnDead() => Dead?.Invoke(this);

    public void ApplyDamage(float damage)
    {
        _dataHealf.ApplyDamage(damage);
    }

    public Vector3 GetPosition()
    {
        return _point.position;
    }

    public void DespawnTower()
    {
        OnDead();
    }
}
