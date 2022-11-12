using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravContrller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Physics.gravity.y
        if(Input.GetKey(KeyCode.W))
        {
            Physics.gravity = new Vector3(0,transform.eulerAngles.z == 0 ? 9.81f : 0,0);
            Physics.gravity = new Vector3(0,transform.eulerAngles.z == -180 ? -9.81f : 0,0);
        }
        if(Input.GetKey(KeyCode.S))
        {
            Physics.gravity = new Vector3(0,-9.81f,0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            Physics.gravity = new Vector3(0,0,9.81f);
        }
        if(Input.GetKey(KeyCode.A))
        {
            Physics.gravity = new Vector3(0,0,-9.81f);
        }
    }
}
