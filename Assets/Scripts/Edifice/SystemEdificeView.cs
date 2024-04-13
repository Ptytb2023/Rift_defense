using UnityEngine;

namespace RiftDefense.Edifice
{
    public class SystemEdificeView : MonoBehaviour
    {
       [SerializeField] public DataEdiface DataEdiface { get; private set; }

        public Material PreviewMaterialInstaler { get; private set; }

        private EdificeView _objectViewToPlaced => DataEdiface.ObjectViewToPlaced;

        private void Start()
        {
            PreviewMaterialInstaler = new Material(DataEdiface.PreviewMaterialForEdifice);
            _objectViewToPlaced.Init(PreviewMaterialInstaler);
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

            var gameObject = Instantiate(prefab);
            gameObject.transform.position = position;
            return gameObject;
        }
    }
}
