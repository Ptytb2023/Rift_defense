using Lean.Pool;
using RiftDefense.Edifice.Tower;
using UnityEngine;

namespace RiftDefense.Edifice
{
    public class SystemEdificeView : MonoBehaviour
    {
        [field: SerializeField] public DataEdiface DataEdiface { get; private set; }

        public Material PreviewMaterial => DataEdiface.PreviewMaterialForEdifice;

        private EdificeView _objectViewToPlaced => DataEdiface.Edifice;

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

        public ITower SpawnTower(Vector3 position)
        {
            var prefab = DataEdiface.Tower;
            var gameObject = LeanPool.Spawn(prefab, position, Quaternion.identity);
            gameObject.transform.position = position;

            return gameObject.GetComponent<ITower>();
        }
    }
}
