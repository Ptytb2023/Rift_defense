using RiftDefense.Edifice.Tower;
using RiftDefense.Generic;
using RiftDefense.Generic.Interface;
using System;

using UnityEngine;

public class MainTower : MonoBehaviour, IMainTower
{
    [field: SerializeField] public bool isAllTarget { get; private set; }
    [field: SerializeField] public int MaxCapacityTarget { get; private set; }
    public int CurrentCoutTarget { get; set; }

    [SerializeField] private DataHealf _dataHealf;
    [SerializeField] private Transform[] pointsForAttack;

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



    public bool AddEnemyTarget(IEnemy enemy)
    {
        if (CurrentCoutTarget >= MaxCapacityTarget)
            return false;

        if (!isAllTarget)
            if (MaxCapacityTarget / 2 <= CurrentCoutTarget)
            {
                int chanche = UnityEngine.Random.Range(0, 100);

                if (chanche > 50)
                {
                    CurrentCoutTarget++;
                    enemy.Dead += OnEnemyDeadTarget;
                    return true;
                }
                else
                    return false;
            }

        CurrentCoutTarget++;
        enemy.Dead += OnEnemyDeadTarget;
        return true;
    }

    private void OnEnemyDeadTarget(IEnemy enemy)
    {
        enemy.Dead -= OnEnemyDeadTarget;
        CurrentCoutTarget--;
    }

}
