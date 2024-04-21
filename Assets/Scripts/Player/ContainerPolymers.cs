using UnityEngine;
using System;

namespace RiftDefense.Player.Container
{
    [CreateAssetMenu(fileName = "ContainerPolymers", menuName = "Container/Polymer", order = 51)]
    public class ContainerPolymers : ScriptableObject
    {
       [field:SerializeField] public int AmountPolymer { get; private set; }

        public event Action<int> ChangeAmoutPolymer;
        public event Action NotAmoutPolymer;

        public void AddPolymers(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            AmountPolymer += count;

            ChangeAmoutPolymer?.Invoke(AmountPolymer);
        }

        public bool InventoryWarehouse(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            return AmountPolymer < count;
        }

        public bool TryTakePolymers(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));


            if (count > AmountPolymer)
            {
                NotAmoutPolymer?.Invoke();
                return false;
            }

            AmountPolymer -= count;
            ChangeAmoutPolymer?.Invoke(AmountPolymer);
            return true;
        }

        public void Resetiong()
        {
            AmountPolymer = 0;
        }

    }
}