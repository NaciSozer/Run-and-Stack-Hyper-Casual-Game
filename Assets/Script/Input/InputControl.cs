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
            _inputData.HorizontlInput = Input.GetAxisRaw("Horizontal");
            

            if (Input.anyKey)
            {
                if(Input.mousePosition.x < Screen.width / 2 || transform.position.x > 5.8f)
                {
                    transform.Translate(Vector3.left * _inputData.MouseSensitivity * Time.deltaTime);

                }

                if (Input.mousePosition.x > Screen.width / 2 || transform.position.x < -5.8f)
                {

                    transform.Translate(Vector3.right * _inputData.MouseSensitivity * Time.deltaTime);

                }

            }



            //if (Input.GetMouseButton(0))
            //{
            //    _inputData.MouseX = Input.GetAxis("Mouse X") * _inputData.MouseSensitivity * Time.deltaTime;

            //    _movementControl.gameObject.transform.Rotate(Vector3.up * _inputData.MouseX);

            //}
        }


    }
}