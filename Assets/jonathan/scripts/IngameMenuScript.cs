using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameMenuScript : MonoBehaviour
{
    public GameObject menuObject;

    public AudioClip clickSound;
    public AudioSource audioSource;

    void Start()
    {
        menuObject.SetActive(false);
        click();
    }

    public void click() {
        audioSource.clip = clickSound;
        audioSource.Play();
    }

    public void Restart() {
        Debug.Log("Restarting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EnterMenu() {
        click();
        Debug.Log("Entering Menu");
        SceneManager.LoadScene(0);
    }

    public void ToggleMenu() {
        menuObject.SetActive(!menuObject.activeSelf);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
