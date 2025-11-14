using UnityEngine;

namespace AlvaroPerez.MinionClash.Utils
{
    public class WorldSpaceToOverlayUi : MonoBehaviour
    {
        [SerializeField] private Camera worldCamera;
        [SerializeField] private Camera uiCamera;
        [SerializeField] private Transform trackTransform;

        public Transform TrackTransform
        {
            get => trackTransform;
            set => trackTransform = value;
        }

        public Camera WorldCamera
        {
            get => worldCamera;
            set => worldCamera = value;
        }

        public Camera UiCamera
        {
            get => uiCamera;
            set => uiCamera = value;
        }

        private void Update()
        {
            UpdatePosition();
        }

        public void UpdatePosition()
        {
            if (WorldCamera != null && UiCamera != null && TrackTransform != null)
            {
                var viewportPosition = WorldCamera.WorldToViewportPoint(trackTransform.position);
                transform.position = UiCamera.ViewportToWorldPoint(viewportPosition);
            }
        }
    }
}