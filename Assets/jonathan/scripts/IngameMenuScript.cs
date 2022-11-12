using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart() {
        Debug.Log("Restarting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EnterMenu() {
        Debug.Log("Entering Menu");
    }
}
