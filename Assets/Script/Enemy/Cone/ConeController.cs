using System.Collections;
using System.Collections.Generic;
using RunGame.Stack;
using UnityEngine;

namespace RunGame.Obstacle
{

    public class ConeController : MonoBehaviour
    {
        [SerializeField] StackControl _stackControl = new StackControl();
        [SerializeField] GameObject _coneParticalEffect;
        private bool playEffect = true;
        Quaternion desRot;


       private void OnTriggerStay(Collider other)
        {
            
            _stackControl.DeleteTimber();
            if (playEffect)
            {
                desRot = _coneParticalEffect.transform.rotation;
                desRot = Quaternion.Euler(-90, 0, 0);
                Instantiate(_coneParticalEffect, transform.position, Quaternion.identity);
                playEffect = false;
            }
            
        }



    }
}