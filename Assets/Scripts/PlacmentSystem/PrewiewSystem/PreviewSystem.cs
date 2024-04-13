using RiftDefense.Edifice;
using RiftDefense.PlacmentSystem.Model;
using UnityEngine;

namespace RiftDefense.PlacmentSystem.Presenter
{
    public class PreviewSystem
    {
        private DataPreviewSystem _previewSystemData;
        private SystemEdificeView _previewObject;

        private const float _previewYOffset = 0.2f;

        public PreviewSystem(DataPreviewSystem previewSystemData)
        {
            _previewSystemData = previewSystemData;
        }

        public void SetEdificePlacment(SystemEdificeView edifice)
        {
            _previewObject = edifice;
            _previewObject?.gameObject.SetActive(true);
        }

        public void StartShowingPlacementPreview()
        {
            SetActiveVisualization(true);
        }

        public void StopShowingPreview()
        {
            SetActiveVisualization(false);
            _previewObject = null;
        }


        public void UpdatePosition(Vector3 positionWorld, bool validity)
        {
            var idicatorCursor = _previewSystemData.CursorIndicator;

            idicatorCursor.transform.position = positionWorld;
            ApplyFeedbackToPreview(validity, idicatorCursor.Material);

            if (_previewObject != null)
            {
                positionWorld.y += _previewYOffset;
                _previewObject.transform.position = positionWorld;

                ApplyFeedbackToPreview(validity, _previewObject.PreviewMaterial);
            }
        }

        private void ApplyFeedbackToPreview(bool validity, Material material)
        {
            Color ColorAvailable = _previewSystemData.ColorAvailableForPlacement;
            Color ColorNotAvailable = _previewSystemData.ColorNotAvailableForPlacement;

            Color newColor = validity ? ColorAvailable : ColorNotAvailable;

            material.color = newColor;
        }

        private void SetActiveVisualization(bool active)
        {
            var gridVisualiztion = _previewSystemData.GridVisualization;
            var idicatorCursor = _previewSystemData.CursorIndicator;

            gridVisualiztion.gameObject.SetActive(active);
            idicatorCursor.gameObject.SetActive(active);


            _previewObject?.gameObject.SetActive(active);

        }
    }
}