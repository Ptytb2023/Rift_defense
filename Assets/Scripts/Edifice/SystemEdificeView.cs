using Lean.Pool;
using UnityEngine;

namespace RiftDefense.Edifice
{
    public class SystemEdificeView : MonoBehaviour
    {
       [field:SerializeField] public DataEdiface DataEdiface { get; private set; }

        public Material PreviewMaterial => DataEdiface.PreviewMaterialForEdifice;

        private EdificeView _objectViewToPlaced => DataEdiface.ObjectViewToPlaced;

        private void Start()
        {
            _objectViewToPlaced.Init(PreviewMaterial);
        }

        private void OnEnable()
        {
            _objectViewToPlaced.gameObject.SetActive(true);
        }

        public void OnDisable()
        {
            _objectViewToPlaced?.gameObject.SetActive(false);
        }

        public GameObject SpawnObject(Vector3 position)
        {
            var prefab = DataEdiface.ObjectToPlacedPrefab;

            var gameObject = LeanPool.Spawn(prefab, position, Quaternion.identity);
            gameObject.transform.position = position;
            return gameObject;
        }
    }
}
