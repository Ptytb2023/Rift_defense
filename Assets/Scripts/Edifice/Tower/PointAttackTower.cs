using Cysharp.Threading.Tasks;
using RiftDefense.Edifice.Tower;
using RiftDefense.Generic.Interface;
using System;
using UnityEngine;

public class PointAttackTower : MonoBehaviour, ITower
{
    [field: SerializeField] public bool isAllTarget { get; private set; }
    [field: SerializeField] public int MaxCapacityTarget { get; private set; }
    public int CurrentCoutTarget { get; set; }
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
