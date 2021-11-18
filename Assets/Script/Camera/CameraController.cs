using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunGame.Camera
{

    public class CameraController : MonoBehaviour
    {
        [SerializeField] CameraSettings _cameraSettings;
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private Transform _cameraTransform;

        private void Start()
        {
            

            _cameraSettings.PositionOffset = _cameraTransform.position - _targetTransform.position;
        }

        void Update()
        {
            CameraPositionFollow();
        }

        private void CameraPositionLerpFollow()
        {
            _cameraTransform.position = Vector3.Lerp(
                _cameraTransform.position,
                _targetTransform.position + _cameraSettings.PositionOffset,
                Time.deltaTime * _cameraSettings.PositionLerpSpeed
                );

        }

        private void CameraPositionFollow()
        {
            _cameraTransform.position = _targetTransform.position + _cameraSettings.PositionOffset;
        }

    }
}