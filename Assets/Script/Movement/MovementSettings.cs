using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunGame.Movement
{


    [CreateAssetMenu(menuName = ("Run Game/Movement/Movement Settings"))]
    public class MovementSettings : ScriptableObject
    {

        [Header("Speed")]
        [SerializeField] private float _playerSpeed;
        public float PlayerSpeed
        {
            get{ return _playerSpeed;}
        }
        [SerializeField] private float _jumpPower;
        public float JumpPower
        {
            get{return _jumpPower;}
        }
    }
}