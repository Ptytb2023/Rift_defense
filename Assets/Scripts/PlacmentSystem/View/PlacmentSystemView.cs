using RiftDefense.PlacmentSystem.Model;
using UnityEngine;

namespace RiftDefense.PlacmentSystem.View
{
    public class PlacmentSystemView : MonoBehaviour
    {
        [Space]
        //[Header("Handler Cursor")]
        [SerializeField] private DataCursor _dataCursor;

        [Space]
        //[Header("Preview System")]
        [SerializeField] private DataPreviewSystem _previewSystemData;

        [Space]
        // [Header("Placement System")]
        [SerializeField] private PlacmentSystemData _placmentSystemData;



        public DataCursor DataCursor => _dataCursor;
        public DataPreviewSystem DataPreviewSystem => _previewSystemData;
        public PlacmentSystemData PlacmentSystemData => _placmentSystemData;
    }
}