using UnityEngine;

namespace LavaGame
{
    public class PlayerAimSystem : MonoBehaviour
    {
        private const float MAX_HIT_DISTANCE = 100.0f;

        [SerializeField] private Transform _gunControlTransform;
        [SerializeField] private string _targetLayerName = "Enemies";

        private Camera _mainCamera;
        private int _targetLayerMask;


        private void Awake()
        {
            _mainCamera = Camera.main;
            _targetLayerMask = 1 << LayerMask.NameToLayer(_targetLayerName);
        }


        private void OnEnable() =>
            EventBus.LeftMouseButtonClick.Subscribe(MouseClickHandler);


        private void OnDisable() =>
            EventBus.LeftMouseButtonClick.Desubscribe(MouseClickHandler);


        public void MouseClickHandler(Vector3 screenPosition)
        {
            Debug.Log("LMB clicked");

            var screenPointRay = _mainCamera.ScreenPointToRay(screenPosition);

            Debug.DrawRay(screenPointRay.origin, screenPointRay.direction * 5.0f, Color.red);
            
            if (Physics.Raycast(screenPointRay, out var hitInfo, MAX_HIT_DISTANCE, _targetLayerMask))
            {
                _gunControlTransform.LookAt(hitInfo.point);
                
                EventBus.Shoot.Publish();
            }
        }
    }
}