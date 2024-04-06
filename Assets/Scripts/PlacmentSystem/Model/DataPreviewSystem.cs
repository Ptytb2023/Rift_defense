using RiftDefense.PlacmentSystem.View;
using System;
using UnityEngine;

namespace RiftDefense.PlacmentSystem.Model
{
    [Serializable]
    public class DataPreviewSystem
    {
        [field: SerializeField] public GridView GridVisualization { get; private set; }
        [field: SerializeField] public CursorIndicatorComponent CursorIndicator { get; private set; }
        [field: SerializeField] public Color ColorAvailableForPlacement { get; private set; }
        [field: SerializeField] public Color ColorNotAvailableForPlacement { get; private set; }
    }
}