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

        
        void Update()
        {
            CameraPositionFollow();
        }

        private void CameraPositionFollow()
        {
            _cameraTransform.position = Vector3.Lerp(
                _cameraTransform.position,
                _targetTransform.position + _cameraSettings.PositionOffset,
                Time.deltaTime * _cameraSettings.PositionLerpSpeed
                );

        }

    }
}