using RiftDefense.Generic.Interface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Detecteble
{
    private DataDetecteble _dataDetecteble;

    private List<IEnemy> _enemys;
    private const int percentageInvisibility = 50;


    public Detecteble(DataDetecteble dataDetecteble)
    {
        _dataDetecteble = dataDetecteble;
        _enemys = new List<IEnemy>(_dataDetecteble.MaxSizeDataEnemy);
    }

    public bool AddEnemyTarget(IEnemy enemy)
    {
        if (_enemys.Count >= _dataDetecteble.MaxSizeDataEnemy)
            return false;

        if (!_dataDetecteble.IsllTargetsEnemy)
            if (_dataDetecteble.MaxSizeDataEnemy / 2 <= _enemys.Count)
            {
                int chanche = UnityEngine.Random.Range(0, 100);

                if (chanche > percentageInvisibility)
                    return AddEnemy(enemy);
                else
                    return false;
            }

        return AddEnemy(enemy);
    }

    private bool AddEnemy(IEnemy enemy)
    {
        _enemys.Add(enemy);
        enemy.Dead += OnEnemyDeadTarget;
        return true;
    }

    private void OnEnemyDeadTarget(IEnemy enemy)
    {
        enemy.Dead -= OnEnemyDeadTarget;
        _enemys.Remove(enemy);
    }

    public void Reseting()
    {
        foreach (var enemy in _enemys)
        {
            enemy.Dead -= OnEnemyDeadTarget;
        }
        _enemys?.Clear();
    }

}

[Serializable]
public class DataDetecteble
{
    [field: SerializeField] public int MaxSizeDataEnemy { get; private set; }
    [field: SerializeField] public bool IsllTargetsEnemy { get; private set; }
}