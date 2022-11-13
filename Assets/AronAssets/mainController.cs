using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int rotOffset;
    [SerializeField]
    private float time;
    public float rot;
    [HideInInspector]
    public bool IsHitingWall;
    private float rotNew;
    private float curRot = 0;

    public ThudScript thudScipt;

    void Awake()
    {
        Physics.gravity = new Vector3(0,-9.81f,0);
    }
    void Start()
    {
        rot = transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsHitingWall)
        {
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
}
