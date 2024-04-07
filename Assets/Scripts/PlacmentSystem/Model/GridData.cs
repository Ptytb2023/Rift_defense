using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class GridData
{
    private Dictionary<Vector3Int, GameObject> _placedObject = new();

    public void AddObjectAt(Vector3Int gridPosition, GameObject edificePlacment)
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
        var position = _placedObject.Keys.FirstOrDefault(pos => pos == gridPosition);

        if (position == null)
            return;

        var eidifce = _placedObject[position];
        eidifce.gameObject.SetActive(false);
        _placedObject.Remove(position);



        //foreach (var position in _placedObject.Keys)
        //{
        //    if (position == gridPosition)
        //    {
        //        var edifice = _placedObject[position];
        //        edifice.gameObject.SetActive(false);

        //        _placedObject.Remove(position);
        //    }
        //}
    }
}

