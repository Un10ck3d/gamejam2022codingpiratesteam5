using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smmothCamRot : MonoBehaviour
{
    // Start is called before the first frame update

    public int rotOffset;
    public float time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0, 270, rotOffset+90), "time", time, "easetype", iTween.EaseType.easeInOutCubic));
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0, 270, rotOffset+0), "time", time, "easetype", iTween.EaseType.easeInOutCubic));
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)) {
            iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0, 270, rotOffset+-90), "time", time, "easetype", iTween.EaseType.easeInOutCubic));
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)) {
            iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0, 270, rotOffset+180), "time", time, "easetype", iTween.EaseType.easeInOutCubic));
        }
    }
}
