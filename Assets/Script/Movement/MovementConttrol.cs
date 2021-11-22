using System.Collections;
using System.Collections.Generic;
using RunGame.Stack;
using UnityEngine;

namespace RunGame.Movement
{
    [RequireComponent(typeof(Animator), typeof(Rigidbody))]
    public class MovementConttrol : MonoBehaviour
    {
        [SerializeField] MovementSettings _movementSettings;
        [SerializeField] StackControl _stackControl = new StackControl();

        [SerializeField] Rigidbody _rigidBody;
        [SerializeField] Animator _playerAnim;
        [SerializeField] private bool _groundControl;
        public bool GroundControl
        {
            get { return _groundControl; }
            set { _groundControl = value; }
        }

       
        /// <summary>
        /// Animasyon Control
        /// </summary>
        bool _transportAnim;

        [Header("Ladders Control")]
        public bool _creatLadders;

        private void Start()
        {
            InvokeRepeating("CreatLadders", 0.0f, 0.14f);
        }

        void FixedUpdate()
        {
            MovementRun();
            
            if (_stackControl.TimberNumb == 0)
            {
                _transportAnim = false;

                _playerAnim.SetBool("Transport", false);

                _creatLadders = false;
            }

            if (_stackControl.TimberNumb > 0)
            {
                _rigidBody.useGravity = false; 
            }
            else
            {
                _rigidBody.useGravity = true;
            }
        }


        private void OnCollisionEnter(Collision collision)
        {
            
            GroundControl = true;
            Debug.Log(collision.gameObject.name);
        }

        private void OnCollisionExit(Collision collision)
        {
            MovementJump();
            GroundControl = false;

        }
        /// <summary>
        /// Add timbers
        /// </summary>
        private void OnTriggerEnter(Collider other)
        {

            _playerAnim.SetBool("Transport", true);

            _stackControl.TimperUp(other.gameObject,true);

            _stackControl.TimberNumb++;


        }
        /// <summary>
        /// Player run
        /// </summary>
        void MovementRun()
        {
            if (Input.GetMouseButton(0))
            {//_rigidBody.velocity = (Vector3.forward * _movementSettings.PlayerSpeed * Time.deltaTime);
                transform.Translate(Vector3.forward * _movementSettings.PlayerSpeed * Time.deltaTime);
                _playerAnim.SetBool("Run", true);
            }
            else
            {
                _playerAnim.SetBool("Run", false);
            }


            
        }
        /// <summary>
        /// Player jump
        /// </summary>
        void MovementJump()
        {

            if (_stackControl.TimberNumb == 0 && _creatLadders == false || GroundControl == false)
            {
                _rigidBody.AddForce(Vector3.up * _movementSettings.JumpPower);
                if (!_transportAnim)
                {
                    _playerAnim.SetTrigger("Jump");
                }

            }
 
        }

        /// <summary>
        /// Ladders creat
        /// </summary>
        public void CreatLadders()
        {
            if(GroundControl == false)
            {
                _stackControl.CreatLadders();
                _creatLadders = true;
                
            }

        }


    }
}