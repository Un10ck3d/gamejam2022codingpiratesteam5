using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneTrigger : MonoBehaviour
{
    [SerializeField]
    private mainController mainController;
    private bool used = false;
    void OnTriggerEnter(Collider other)
    {
        if(used == false)
        {
            if(!other.isTrigger)
            {
                Debug.Log("next scene");
                mainController.nextCameraPos(1);
            }
        }
        else
        {
            if(!other.isTrigger)
            {
                mainController.nextCameraPos(-1);
            }
        }
    }
}
