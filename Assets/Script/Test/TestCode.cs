using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    public List<GameObject> timberlist;
    public GameObject timber;

    public Transform timberFile;
    public Transform timberPos;
    public float distance = 0.08f;

    bool down = true;
    


    void Start()
    {
        

        //for(int i = 0; i<=5 - 1; i++)
        //{

        //    GameObject go = Instantiate(timber, timberPos.transform.position, Quaternion.identity);
        //    timber.transform.position = newPos;
        //    go.transform.parent = timberPos.transform;

        //    timberlist.Add(timber);

        //}


        for (int i = 0; i < 3; ++i)
        {
            timberlist.Add(timber);

            GameObject tim = Instantiate(timber,timberPos.parent);
            tim.transform.parent = timberPos.transform;

            Vector3 despos = timberPos.transform.localPosition;
            despos.y += down ? distance : -distance;

            timber.transform.localPosition = despos;

            timberFile = timber.transform;

        }


    }
    
    
}
