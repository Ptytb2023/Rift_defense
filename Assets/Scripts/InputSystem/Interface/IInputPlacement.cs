using System;
using UnityEngine;

namespace RiftDefense.InputSustem
{
    public interface IInputPlacement : IInputBase
    {
        public event Action ClickAction;
        public event Action ClickExit;

        public Vector3 GetMousePosition();

    }
}