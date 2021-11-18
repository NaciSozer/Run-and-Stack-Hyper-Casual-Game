using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RunGame.Camera
{


    [CreateAssetMenu(menuName ="Run Game/Camera/Camera Settings")]
    public class CameraSettings : ScriptableObject
    {

        [Header("Position")]
        [SerializeField] private Vector3 _positionOffset;
        public Vector3 PositionOffset
        {
            get { return _positionOffset; }
            set { _positionOffset = value; }
        }

        [SerializeField] private float _positionLerpSpeed;
        public float PositionLerpSpeed
        {
            get { return _positionLerpSpeed; }
        }

    }
}