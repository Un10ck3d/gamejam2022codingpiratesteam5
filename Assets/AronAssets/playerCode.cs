using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCode : MonoBehaviour
{
    [SerializeField]
    private mainController controller;
    private int StoredObjectAmount;
    Material mymat;

    public Rigidbody rb;

    public Light l;
    public ThudScript thudManager;

    private float oldvelspeed = 0;

    public float velToPlaySound;
    
    void Start()
    {
        mymat = GetComponent<Renderer>().materials[3];
        mymat.EnableKeyword("_EMISSION");
        mymat.SetColor("_EmissionColor", Color.red);
    }

   
    void Update()
    {
        if(Vector3.Distance(rb.velocity, Vector3.zero) - oldvelspeed < velToPlaySound){
            thudManager.thud();
        }
        oldvelspeed = Vector3.Distance(rb.velocity, Vector3.zero);


    }
    void OnTriggerEnter(Collider other)
    {
        StoredObjectAmount += 1;
        controller.IsHitingWall = true;
        yellow();
        // thudManager.thud();
        
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
        mymat.SetColor("_EmissionColor", new Color(1000, 0, 0));
        l.color = Color.red;

    }

    void yellow(){
        mymat.SetColor("_EmissionColor", new Color(1000, 1000, 0));
        l.color = Color.yellow;
    }

    
}
