using System;
using UnityEngine;

namespace RiftDefense.Edifice
{
    [Serializable]
    public class DataEdiface
    {
        [field: SerializeField] public Sprite IconForShop { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public int PricesBuy { get; private set; }
        [field: SerializeField] public EdificeView ObjectViewToPlaced { get; private set; }
        [field: SerializeField] public GameObject ObjectToPlacedPrefab { get; private set; }
        [field: SerializeField] public Material PreviewMaterialForEdifice { get; private set; }
    }
}
