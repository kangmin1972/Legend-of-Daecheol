using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Camera MainCamera;
    public Toggle ScreenShake;
    public Toggle Headbob;
    public Toggle ScreenTilt;
    public Toggle SeasonalEvent;
    public Toggle ShowFPS;

    public bool ScreenShakebool;
    public bool Headbobbool;
    public bool ScreenTiltbool;
    public bool Seasonaleventbool;
    public bool ShowFPSbool;

    public static float camerasenvalue;
    public Slider CameraSen;
    public Slider FOV;

    public GameObject opcanvas;
    public GameObject pausecanvas;

    public GameObject normal;
    public GameObject general;
    public GameObject graphic;
    public GameObject audio1;


    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    void LoadData()
    {
        if (!PlayerPrefs.HasKey("CameraSensiti") || !PlayerPrefs.HasKey("FOV"))
            return;
        CameraSen.value = PlayerPrefs.GetFloat("CameraSensiti");
        FOV.value = PlayerPrefs.GetFloat("FOV");
    }

    // Update is called once per frame
    void SaveData()
    {
        PlayerPrefs.SetFloat("CameraSensiti", Mouse.mouseSpeed);
        PlayerPrefs.SetFloat("FOV", MainCamera.fieldOfView);
    }

    public void SetCameraSen(float volume)
    {
        Mouse.mouseSpeed = volume;
        PlayerPrefs.SetFloat("CameraSensiti", Mouse.mouseSpeed);
    }

    public void SetFOVCamera(float volume)
    {
        MainCamera.fieldOfView = volume;
        PlayerPrefs.SetFloat("FOV", MainCamera.fieldOfView);
    }

    public void QuitSettings()
    {
        opcanvas.SetActive(false);
        pausecanvas.SetActive(true);
    }

    public void General()
    {
        normal.SetActive(false);
        general.SetActive(true);
    }

    public void SettijngTitle()
    {
        normal.SetActive(true);
        general.SetActive(false);
        graphic.SetActive(false);
        audio1.SetActive(false);
    }
}
