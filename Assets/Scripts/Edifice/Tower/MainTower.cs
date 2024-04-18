using RiftDefense.Edifice.Tower;
using RiftDefense.Generic;
using RiftDefense.Generic.Interface;
using System;

using UnityEngine;

public class MainTower : MonoBehaviour, IMainTower
{
    [field: SerializeField] private DataDetecteble _dataDetecteble;
  

    [SerializeField] private DataHealf _dataHealf;
    [SerializeField] private Transform[] pointsForAttack;

    public bool Enabel => gameObject.activeSelf;
    public Detecteble Detecteble { get; private set; }
    public Vector3Int GridPosition { get; set; }

    public event Action<IEnemy> Dead;

    private void Awake()
    {
        Detecteble = new Detecteble(_dataDetecteble);
    }

    private void OnEnable()
    {
        Detecteble.Reseting();
        _dataHealf.Dead += OnDead;
    }

    private void OnDisable()
    {
        _dataHealf.Dead -= OnDead;
    }

    private void OnDead()
    {
        Dead?.Invoke(this);
    }

    public void ApplyDamage(float damage)
    {
        _dataHealf.ApplyDamage(damage);
    }

    public Vector3 GetPosition()
    {
        int randomPoitn = UnityEngine.Random.Range(0, pointsForAttack.Length);

        return pointsForAttack[randomPoitn].position;
    }

    public void DespawnTower()
    {
        OnDead();
    }




}
