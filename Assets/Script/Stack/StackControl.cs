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

        [SerializeField] private GameObject _timberParent;
        public GameObject TimberParent
        {
            get { return _timberParent; }
            set { _timberParent = value; }
        }

        [SerializeField] private float _distanceBetweenObjects = 0.08f;
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


        public void TimperUp(GameObject _timberPrefab, bool down = true)
        {
            
            TimberPrefab.Add(_timberPrefab);

            _timberPrefab.transform.parent = TimberParent.transform;


            Vector3 despos = TimberParent.transform.localPosition;

            despos.y += down ? DistanceBetweenObects : -DistanceBetweenObects;

            _timberPrefab.transform.localPosition = despos;

            TimberParent.transform.localPosition = _timberPrefab.transform.localPosition;

        }

        public void CreatLadders()
        {
                if (0 < TimberNumb)
                {
                    
                    for (int i = 0; i <= TimberNumb; i++)
                    {
                    Quaternion desRot = LaddersCreatPos.transform.localRotation;

                    desRot = Quaternion.Euler(0, 90, 90);

                    Instantiate(LaddersPrefab, _ladderCreatPos.position, desRot);

                    TimberNumb--;
                        TimberPrefab.RemoveAt(TimberPrefab.Count - 1);

                        Destroy(TimberParent.GetComponent<Transform>().GetChild(TimberPrefab.Count).gameObject);

                    //TimberParent.transform.localPosition = new Vector3(
                    //    TimberParent.transform.localPosition.x,
                    //    TimberParent.transform.localPosition.y - DistanceBetweenObects,
                    //    TimberParent.transform.localPosition.z);

                    break;
                    }
                    

                }

                else
                {
                    CancelInvoke();
                }
            
        }
    }
}