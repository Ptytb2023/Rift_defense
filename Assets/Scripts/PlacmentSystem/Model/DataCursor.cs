using RiftDefense.PlacmentSystem.View;
using System;
using UnityEngine;

namespace RiftDefense.PlacmentSystem.Model
{
    [Serializable]
    public class DataCursor
    {
        [field: SerializeField] public Camera Camera { get; private set; }
        [field: SerializeField] public LayerMask PlacementLayerMask { get; private set; }
    }
}