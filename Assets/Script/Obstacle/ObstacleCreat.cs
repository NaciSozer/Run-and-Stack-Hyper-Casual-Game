using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace RunGame.Obstacle
{
    [System.Serializable]
    public class ObstacleCreat : MonoBehaviour
    {
        ObstacleMechanical _obstacleMechanical = new ObstacleMechanical();

        public Color _color;
        public int _damage;
        public int _randomProcess;
        public bool _plus;
        public TextMeshProUGUI _processText;




        void Start()
        {
            this._randomProcess = _obstacleMechanical._randomProcess;
            //_obstacleMechanical.CreatProcess();
        }

        
    }
}