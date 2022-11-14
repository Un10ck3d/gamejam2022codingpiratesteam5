using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class mainController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform[] cameraPositions;
    [SerializeField]
    private Transform[] extraCameraPositions;
    [SerializeField]
    private GameObject[] levels_forDisabling;
    [SerializeField]
    private int rotOffset;
    [SerializeField]
    private float time;
    public float rot;
    [HideInInspector]
    public bool IsHitingWall;
    private float rotNew;
    private float curRot = 0;
    private int curCameraPosition = 0;
    private int lastCameraPosition = 3;
    private Vector3 lastPosition;

    public ThudScript thudScipt;

    public IngameMenuScript menuScript;

    private float SAngle;

    private bool isMobile;

    void Awake()
    {
        Physics.gravity = new Vector3(0,-9.81f,0);
    }
    void Start()
    {
        rot = transform.eulerAngles.z;

        if(AttitudeSensor.current != null){
            InputSystem.EnableDevice(AttitudeSensor.current);

        }

        isMobile = false;
    }

    // Update is called once per frame
    void Update()
    {
        isMobile = AttitudeSensor.current.attitude.ReadValue().eulerAngles.z != 0;
        if(AttitudeSensor.current != null){

            Debug.Log(AttitudeSensor.current.attitude.ReadValue().eulerAngles);
            menuScript.level((int) AttitudeSensor.current.attitude.ReadValue().eulerAngles.z);
            SAngle = AttitudeSensor.current.attitude.ReadValue().eulerAngles.z;
        }
        else{
            Debug.Log("no censor");
            menuScript.level(-10);
        }
        //Debug.Log(curCameraPosition);
        for(int i = 0;i<=levels_forDisabling.Length-1;i++)
        {
            if(i!=curCameraPosition)
            {
                levels_forDisabling[i].SetActive(false);
            }
            else
            {
                levels_forDisabling[i].SetActive(true);
                // menuScript.level(i+1);
            }
        }
        if(cameraPositions.Length != 0)
        {            
            if(lastCameraPosition != curCameraPosition)
            {
                transform.position = cameraPositions[curCameraPosition].position;
                lastCameraPosition = curCameraPosition;
            }
        }
        if(IsHitingWall)
        {
            if(!isMobile){
            }
                if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
                    rot += 180;
                    iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0, 270, rot), "time", time, "easetype", iTween.EaseType.easeInOutCubic));
                }
                if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
                    rot -= 90;
                    iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0, 270, rot), "time", time, "easetype", iTween.EaseType.easeInOutCubic));
                }
                // if(Input.GetKeyDown(KeyCode.DownArrow)) {
                //     iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0, 270, transform.eulerAngles.z+rotOffset+0), "time", time, "easetype", iTween.EaseType.easeInOutCubic));
                // }
                if(Input.GetKeyDown(KeyCode.RightArrow)  || Input.GetKeyDown(KeyCode.D)) {
                    rot += 90;
                    iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0, 270, rot), "time", time, "easetype", iTween.EaseType.easeInOutCubic));
            }
            else {

                if(shouldMobileRot(90)){
                    rot = 180;
                    // iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0, 270, rot), "time", time, "easetype", iTween.EaseType.easeInOutCubic));
                }
                if(shouldMobileRot(180)){
                    rot = 90;
                    // iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0, 270, rot), "time", time, "easetype", iTween.EaseType.easeInOutCubic));
                }
                if(shouldMobileRot(-90)){
                    rot = 0;
                    // iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0, 270, rot), "time", time, "easetype", iTween.EaseType.easeInOutCubic));
                }
                if(shouldMobileRot(0)){
                    rot = -90;
                    // iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0, 270, rot), "time", time, "easetype", iTween.EaseType.easeInOutCubic));
                }
            }
            rot = rot % 360;
            rotNew = rot < 0 ? rot + 360 : rot;
            if(curRot != rotNew)
            {
                curRot = rotNew;
                thudScipt.rotate();
                StartCoroutine(shiftGrav());
            }

        }
    }

    bool shouldMobileRot(int degree){
        if(SAngle == 0) return false;
        return Mathf.Min(Mathf.Abs(degree - SAngle),  Mathf.Abs(degree - (SAngle - 360))) < 50;
    }

    IEnumerator shiftGrav()
    {
        Vector3 gravShiftCalc = new Vector3(0,0,0);
        if(rotNew == 0)
        {
            gravShiftCalc = new Vector3(0,-9.81f,0);
        }
        else if(rotNew == 90)
        {
            gravShiftCalc = new Vector3(0,0,9.81f);
        }
        else if(rotNew == 180)
        {
            gravShiftCalc = new Vector3(0,9.81f,0);
        }
        else if(rotNew == 270)
        {
            gravShiftCalc = new Vector3(0,0,-9.81f);
        }
        yield return new WaitForSeconds(0.34f);
        Physics.gravity = gravShiftCalc;

    }
    public void nextCameraPos(int amount)
    {
        curCameraPosition += amount;
    }
    public void extraCameraPos(bool on)
    {
        if(on)
        {
            transform.position = extraCameraPositions[curCameraPosition].position;
        }
        else
        {
            transform.position = cameraPositions[curCameraPosition].position;
        }
    }
}
