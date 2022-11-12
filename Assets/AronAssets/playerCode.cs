using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCode : MonoBehaviour
{
    [SerializeField]
    private mainController controller;
    private int StoredObjectAmount;
    void OnTriggerEnter(Collider other)
    {
        StoredObjectAmount += 1;
        controller.IsHitingWall = true;
    }
    void OnTriggerExit(Collider other)
    {
        StoredObjectAmount -= 1;
        if(StoredObjectAmount <= 0)
        {
            controller.IsHitingWall = false;
        }
    }
}
