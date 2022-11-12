using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravContrller : MonoBehaviour
{
    private float timer;
    [SerializeField]
    private smmothCamRotAron rotGet;
    private float rot;
    private float curRot = 0;
    void Awake()
    {
        Physics.gravity = new Vector3(0,-9.81f,0);
    }
    void Update()
    {
        rot = rotGet.rot < 0 ? rotGet.rot + 360 : rotGet.rot;
        timer = timer + Time.deltaTime;
        Debug.Log(rot);
        if(curRot != rot)
        {
            curRot = rot;
            StartCoroutine(shiftGrav());
        }
    }
    IEnumerator shiftGrav()
    {
        Vector3 gravShiftCalc = new Vector3(0,0,0);
        if(rot == 0)
        {
            gravShiftCalc = new Vector3(0,-9.81f,0);
        }
        else if(rot == 90)
        {
            gravShiftCalc = new Vector3(0,0,9.81f);
        }
        else if(rot == 180)
        {
            gravShiftCalc = new Vector3(0,9.81f,0);
        }
        else if(rot == 270)
        {
            gravShiftCalc = new Vector3(0,0,-9.81f);
        }
        Debug.Log("hey");
        yield return new WaitForSeconds(0.34f);
        Debug.Log("hejafter");
        Physics.gravity = gravShiftCalc;

    }
}
