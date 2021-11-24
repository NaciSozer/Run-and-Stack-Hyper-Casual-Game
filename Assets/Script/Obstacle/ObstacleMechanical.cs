using System.Collections;
using System.Collections.Generic;
using RunGame.Stack;
using TMPro;
using UnityEngine.UI;
using UnityEngine;


namespace RunGame.Obstacle
{

    public class ObstacleMechanical : MonoBehaviour
    {
        StackControl _stackControl = new StackControl();

        public GameObject _panelColor;
        public int _randomProcess;
        public bool _plus;
        public TextMeshProUGUI _processText;


        private void Start()
        {
            _randomProcess = Random.Range(-3, 3);

            CreatProcess();
            // Debug.Log("Baþlangýç deðerimiz  " + _randomProcess);

        }

        public void CreatProcess()
        {
            NewRandomProscess();

            if (_randomProcess >= 0)
            {
                _processText.text = "+ " + _randomProcess;
                _panelColor.GetComponent<Image>().color = new Color32(0, 255, 196, 47);

                Debug.Log("Pozitif deðer " + _randomProcess);
            }
            else if (_randomProcess < 0)
            {
                _processText.text = " " + _randomProcess;
                _panelColor.GetComponent<Image>().color = new Color32(239, 28, 28, 47);
                Debug.Log("Negtif deðer " + _randomProcess);
            }


        }

        public int NewRandomProscess()
        {
           

            // Debug.Log("process " + process + "_random " + _randomProcess);
            return _randomProcess;

        }

        public void CreatAndDeleteTimber()
        {
            if (NewRandomProscess() > -1)
            {
                Debug.Log("Timber++ " + NewRandomProscess());
                for (int i = 0; i <= _randomProcess; i++)
                {
                    _stackControl.TimperUp(_stackControl.TimberObject.gameObject, true);
                }

            }
            else if (NewRandomProscess() < 0)
            {
                Debug.Log("Timber--" + NewRandomProscess());
                for (int i = 0; i <= _randomProcess; i++)
                {
                    _stackControl.CreatLadders(false);
                }

            }
        }


    }
        


}