using RiftDefense.PlacmentSystem.Presenter;
using System;
using UnityEngine;
using Zenject;

namespace RiftDefense.PlacmentSystem.Model
{
    [Serializable]
    public class PlacmentSystemData
    {
        [field: SerializeField] public Grid Grid { get; private set; }

        [Inject]
        private GridData _gridData;

        [Inject]
        private RemovePlacementState _removeState;

        [Inject]
        private PlacementState _creatState;

        public IPlacementState CreatState => _creatState;
        public IPlacementState RemoveState => _removeState;

        public GridData GridData => _gridData;

    }
}