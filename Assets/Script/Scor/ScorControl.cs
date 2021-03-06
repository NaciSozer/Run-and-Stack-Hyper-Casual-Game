using System.Collections;
using System.Collections.Generic;
using RunGame.Stack;
using RunGame.LevelController;
using UnityEngine.UI;
using UnityEngine;

namespace RunGame.Scor
{
    public class ScorControl : MonoBehaviour
    {
        [SerializeField] StackControl _stcakControl = new StackControl();
        [SerializeField] LevelControl _levelControl = new LevelControl();
         
        [SerializeField] Text _scorText;
        [SerializeField] Text _panelScor;
        [SerializeField] Text _finishLevelText;

        private void Update()
        {
            _scorText.text = "Scor: " + _stcakControl.TimberNumb.ToString();
            _panelScor.text = _scorText.text;
            _finishLevelText.text = "LEVEL " + (_levelControl.CurrentLevel + 1) + " COMPLETED";

            //Debug.Log(_levelControl.CurrentLevel);
        }
    }
}