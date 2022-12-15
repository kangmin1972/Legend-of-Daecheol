using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausescript : MonoBehaviour
{
    public static bool gamepaused = false;
    public GameObject pauseMenuUI;
    public Camera pcamera;
    public GameObject optioncanvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gamepaused)
            {
                //Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        pcamera.GetComponent<Mouse>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gamepaused = false;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.UnPause();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        pcamera.GetComponent<Mouse>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gamepaused = true;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Pause();
        }
    }

    public void Options()
    {
        pauseMenuUI.SetActive(false);
        optioncanvas.SetActive(true);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(1);
        gamepaused = false;
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {

    }
}