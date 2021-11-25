using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunGame.Stack
{
    public class StackControl : MonoBehaviour
    {
        [Header("Stack Data")]
        [SerializeField] private List<GameObject> _timberPrefabList = null;
        [SerializeField] private GameObject _timberPrefab;
        
        public List<GameObject> TimberPrefab
        {
            get {return _timberPrefabList;}
            set {_timberPrefabList.Add(_timberPrefab);}

        }

        [SerializeField] private Transform _timberObject;
        public Transform TimberObject
        {
            get { return _timberObject; }
            set { _timberObject = value; }
        }


        [SerializeField] private Transform _timberParent;
        public Transform TimberParent
        {
            get { return _timberParent; }
            set { _timberParent = value; }
        }

        [SerializeField] private float _distanceBetweenObjects = 0.8f;
        public float DistanceBetweenObects
        {
            get { return _distanceBetweenObjects;}
        }

       


        /// <summary>
        /// Ladders Data
        /// </summary>
        /// 
        [Header("Ladders Data")]
        [SerializeField] private GameObject _ladderPrefab;
        public GameObject LaddersPrefab
        {
            get { return _ladderPrefab;}

            set { _ladderPrefab = value;}
        }

        [SerializeField] private Transform _ladderCreatPos;
        public Transform LaddersCreatPos
        {
            get { return _ladderCreatPos;}
        }
        [SerializeField] private int _timberNumb;
        public int TimberNumb
        {
            get {  return _timberNumb; }
            set { _timberNumb = value; }
        }

       
       private void Update()
        {
            TimberNumb = TimberPrefab.Count;
        }
        

        public void TimperUp(GameObject _timberPrefab, bool down = true)
        {
            //int lastObecjt = TimberPrefab.LastIndexOf(_timberPrefab.GetComponent<Transform>().gameObject);

            TimberPrefab.Add(_timberPrefab);

            if (_timberPrefab.GetComponent<BoxCollider>())
            {
                _timberPrefab.GetComponent<BoxCollider>().enabled = false;
            }
            
            TimberNumb++;
            
            _timberPrefab.transform.parent = TimberParent.transform;


            Vector3 despos = TimberObject.localPosition;

            despos.y += down ? DistanceBetweenObects : -DistanceBetweenObects;

            _timberPrefab.transform.localPosition = despos;

            TimberObject = _timberPrefab.transform;
            
            
        }

        public void CreatLadders(bool creat = true)
        {
                if (0 < TimberNumb)
                {
                    
                    for (int i = 0; i <= TimberNumb; i++)
                    {
                    if (creat)
                    {
                        Quaternion desRot = LaddersCreatPos.transform.localRotation;

                        desRot = Quaternion.Euler(0, 90, 90);

                        Instantiate(LaddersPrefab, _ladderCreatPos.position, desRot);

                        
                    }

                    DeleteTimber();



                    break;
                    }
                    

                }

                else
                {
                    CancelInvoke();
                }
            
        }
        public void DeleteTimber()
        {
            TimberNumb--;
           
            TimberPrefab.RemoveAt(TimberPrefab.Count - 1);

            Destroy(TimberParent.GetComponent<Transform>().GetChild(TimberPrefab.Count).gameObject);
        }
    }
}