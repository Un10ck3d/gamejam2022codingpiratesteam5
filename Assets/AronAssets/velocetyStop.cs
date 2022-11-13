using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velocetyStop : MonoBehaviour
{
    [SerializeField]
    private Rigidbody mainRb;
    void OnTriggerEnter(Collider other)
    {
        {
            if(!other.isTrigger)
            {
                Debug.Log("stopped velocety");
                mainRb.velocity = new Vector3(0,0,0);
            }
        }
    }
}
