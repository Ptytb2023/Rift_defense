using UnityEngine;

namespace RiftDefense.Edifice
{
    public abstract class EdificePlacmentMainView : MonoBehaviour
    {
        [SerializeField] private PlacementEdifice _placementObject;
        [SerializeField] private GameObject _postedObject;

        [SerializeField] private Material _previewMaterialForEdifice;

        public Material PreviewMaterialInstaler { get; private set; }

        private  void Start()
        {
            PreviewMaterialInstaler = new Material(_previewMaterialForEdifice);
            _placementObject.Init(_previewMaterialForEdifice);
        }

        private void OnEnable()
        {
            _placementObject.gameObject.SetActive(true); 
        }

        public void OnDisable()
        {
            _placementObject?.gameObject.SetActive(false);
            _postedObject?.SetActive(false);
        }
    }
}
