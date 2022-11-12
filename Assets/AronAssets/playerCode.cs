using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCode : MonoBehaviour
{
    [SerializeField]
    private mainController controller;
    private int StoredObjectAmount;
    Material mymat;

    public Light l;
    public ThudScript thudManager;
    void Start()
    {
        mymat = GetComponent<Renderer>().materials[3];
        mymat.EnableKeyword("_EMISSION");
        mymat.SetColor("_EmissionColor", Color.red);
    }
    void OnTriggerEnter(Collider other)
    {
        StoredObjectAmount += 1;
        controller.IsHitingWall = true;
        yellow();
        thudManager.thud();
        
    }
    void OnTriggerExit(Collider other)
    {
        StoredObjectAmount -= 1;
        if(StoredObjectAmount <= 0)
        {
            controller.IsHitingWall = false;
            red();
        }
    }

    void red(){
        mymat.SetColor("_EmissionColor", new Color(0, 1000, 0));
        l.color = Color.red;

    }

    void yellow(){
        mymat.SetColor("_EmissionColor", new Color(1000, 1000, 0));
        l.color = Color.yellow;
    }

    
}
