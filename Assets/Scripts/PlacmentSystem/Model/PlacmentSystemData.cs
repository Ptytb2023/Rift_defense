using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace RiftDefense.PlacmentSystem.Model
{
    [Serializable]
    public class PlacmentSystemData
    {
        [field: SerializeField] public Grid Grid { get; private set; }
        [field: SerializeField] public Tilemap Tilemap { get; private set; }
        [field: SerializeField] public bool ISHexMap { get; private set; }

    }
}