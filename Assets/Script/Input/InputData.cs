using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunGame.InputControl
{

    [CreateAssetMenu(menuName =("Run Game/Input/Input Data"))]
    public class InputData : ScriptableObject
    {
        [SerializeField] float _horizontalInput;
        public float HorizontlInput
        {
            get { return _horizontalInput; }
            set { _horizontalInput = value; }
        }


        [SerializeField] private float _mouseX;
        public float MouseX {
            get { return _mouseX; }
            set { _mouseX = value; } 
        }

        [SerializeField] private float _mouseSensitivity;
        public float MouseSensitivity {
            get { return _mouseSensitivity; } 
        }

    }
}