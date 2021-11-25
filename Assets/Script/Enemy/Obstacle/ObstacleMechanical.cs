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
        [SerializeField] StackControl _stackControl = new StackControl();

        [SerializeField] private GameObject _panelColor;
        public GameObject PanelColor { get { return _panelColor; } set { _panelColor = value; } }

        [SerializeField] private int _randomProcess;
        public int RandomProcess { get { return _randomProcess; } set { _randomProcess = value; } }

        [SerializeField] private TextMeshProUGUI _processText;
        public TextMeshProUGUI ProcessText { get { return _processText; } set { _processText = value; } }

        [SerializeField] private GameObject _timberPrefab;
        public GameObject TimberPrefab { get { return _timberPrefab; } }
        

        


        private void Start()
        {
            _stackControl = GameObject.Find("StackControl").GetComponent<StackControl>();

            RandomProcess = Random.Range(-3, 3);

            CreatProcess();

        }

       

        public void CreatProcess()
        {
            

            if (RandomProcess >= 0)
            {
                ProcessText.text = "+ " + RandomProcess;
                PanelColor.GetComponent<Image>().color = new Color32(0, 255, 196, 47);

            }
            else if (RandomProcess < 0)
            {
                ProcessText.text = " " + RandomProcess;
                PanelColor.GetComponent<Image>().color = new Color32(239, 28, 28, 47);
                
            }


        }

        

        private void OnTriggerExit(Collider other)
        {
            
                _stackControl.TimberNumb += RandomProcess;
                CreatAndDeleteTimber();
            
            

        }

        public void CreatAndDeleteTimber()
        {
            if (RandomProcess > 0)
            {
                for (int i = 1; i <= RandomProcess; i++)
                {
                    GameObject timberPrefab = Instantiate(TimberPrefab);
                    _stackControl.TimperUp(timberPrefab, true);


                }

            }
            else if (RandomProcess < 0)
            {

                for (int i = 1; i <= RandomProcess * -1; i++)
                {
                    _stackControl.DeleteTimber();

                }

            }
        }
    }
        
    

}