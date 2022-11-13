using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameMenuScript : MonoBehaviour
{
    public GameObject menuObject;

    public AudioClip clickSound;
    public AudioSource audioSource;

    public AudioSource audioSourceMusic;

    public AudioClip theme;
    public AudioClip theme_loopable;

    void Start()
    {
        audioSourceMusic.clip = theme;
        audioSourceMusic.loop = false;
        audioSourceMusic.Play();
        menuObject.SetActive(false);
        click();
    }

    void Update() {
        if (!audioSourceMusic.isPlaying) {
            audioSourceMusic.clip = theme_loopable;
            audioSourceMusic.loop = true;
            audioSourceMusic.Play();
        }
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
