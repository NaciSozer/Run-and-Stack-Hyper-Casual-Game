using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace RunGame.Obstacle
{
    
    public abstract class Obstacle
    {
        public Color _color;
        public int _damage;
        public int _randomProcess;
        public bool _plus;
        public TextMeshProUGUI _processText;
    }
}