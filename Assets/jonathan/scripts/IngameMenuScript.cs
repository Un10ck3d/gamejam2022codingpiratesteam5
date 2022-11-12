using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameMenuScript : MonoBehaviour
{
    public GameObject menuObject;
    void Start()
    {
        menuObject.SetActive(false);
    }

    public void Restart() {
        Debug.Log("Restarting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EnterMenu() {
        Debug.Log("Entering Menu");
        SceneManager.LoadScene(0);
    }

    public void ToggleMenu() {
        menuObject.SetActive(!menuObject.activeSelf);
    }
}
