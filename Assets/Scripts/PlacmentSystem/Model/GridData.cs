using RiftDefense.Edifice;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GridData
{
    private Dictionary<Vector3Int, EdificePlacmentMainView> _placedObject = new();

    public void AddObjectAt(Vector3Int gridPosition, EdificePlacmentMainView edificePlacment)
    {
        if (_placedObject.ContainsKey(gridPosition))
            throw new Exception($"Dictionary already contains this cell position{gridPosition}");

        _placedObject.Add(gridPosition, edificePlacment);
    }


    public bool CanPlaceObjectAt(Vector3Int gridPosition)
    {
        return !_placedObject.ContainsKey(gridPosition);
    }


    public void RemoveObjectAt(Vector3Int gridPosition)
    {
        foreach (var position in _placedObject.Keys)
        {
            if (position == gridPosition)
            {
              var edifice = _placedObject[position];
                edifice.gameObject.SetActive(false);

                _placedObject.Remove(position);
            }
        }
    }
}

