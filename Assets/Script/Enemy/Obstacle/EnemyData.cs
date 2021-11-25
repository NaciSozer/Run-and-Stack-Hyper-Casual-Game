using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunGame.Obstacle
{

    [CreateAssetMenu(menuName =("Run Game/Obstacle/Obstacle Data"))]
    public class EnemyData : ScriptableObject
    {

        [SerializeField] private float _damage;
        public float Damage { get { return _damage; } }



    }
}