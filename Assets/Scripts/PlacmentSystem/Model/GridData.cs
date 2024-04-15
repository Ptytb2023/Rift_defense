using Lean.Pool;
using RiftDefense.Edifice.Tower;
using RiftDefense.Generic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridData
{
    private Dictionary<Vector3Int, ITower> _placedObject = new();

    public void AddObjectAt(Vector3Int gridPosition, ITower tower)
    {
        if (_placedObject.ContainsKey(gridPosition))
            throw new Exception($"Dictionary already contains this cell position{gridPosition}");

        _placedObject.Add(gridPosition, tower);
        tower.GridPosition = gridPosition;
        tower.Dead += OnDeadTower;
    }


    public bool CanPlaceObjectAt(Vector3Int gridPosition)
    {
        return !_placedObject.ContainsKey(gridPosition);
    }


    public void RemoveObjectAt(Vector3Int gridPosition)
    {
        var position = _placedObject.Keys.FirstOrDefault(pos => pos == gridPosition);

        if (position == null)
            return;

        var tower = _placedObject[position];
        tower.DespawnTower();
        RemoveTower(position, tower);
    }

    private void RemoveTower(Vector3Int position, ITower tower)
    {
        _placedObject.Remove(position);
        tower.Dead -= OnDeadTower;
    }

    private void OnDeadTower(IEnemy towerDead)
    {
        var tower = towerDead as ITower;
        RemoveTower(tower.GridPosition, tower);
    }
}




