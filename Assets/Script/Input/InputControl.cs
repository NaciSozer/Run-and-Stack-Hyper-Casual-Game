using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RunGame.Movement;

namespace RunGame.InputControl
{


    public class InputControl : MonoBehaviour
    {
        [SerializeField] private InputData _inputData;
        [SerializeField] MovementConttrol _movementControl = new MovementConttrol();

        private void Update()
        {
            MouseControl();
        }

        public void MouseControl()
        {
            if (Input.GetMouseButton(0))
            {
                _inputData.MouseX = Input.GetAxis("Mouse X") * _inputData.MouseSensitivity * Time.deltaTime;

                _movementControl.gameObject.transform.Rotate(Vector3.up * _inputData.MouseX);

            }
        }


    }
}