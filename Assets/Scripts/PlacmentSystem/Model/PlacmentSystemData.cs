using System;
using UnityEngine;

namespace RiftDefense.PlacmentSystem.Model
{
    [Serializable]
    public class PlacmentSystemData
    {
        [field: SerializeField] public Grid Grid { get; private set; }

    }
}