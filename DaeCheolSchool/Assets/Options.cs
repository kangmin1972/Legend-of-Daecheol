using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Camera MainCamera;
    public Toggle ScreenShake1;
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
        if (!PlayerPrefs.HasKey("CameraSensiti") || !PlayerPrefs.HasKey("FOV") || !PlayerPrefs.HasKey("ScreenShakeValue") || !PlayerPrefs.HasKey("HeadBobValue") || !PlayerPrefs.HasKey("CamTiltValue") || !PlayerPrefs.HasKey("FrameShowValue"))
            return;
        CameraSen.value = PlayerPrefs.GetFloat("CameraSensiti");
        FOV.value = PlayerPrefs.GetFloat("FOV");
        GeneralSavings();
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

    public void SetScreenShake(bool value)
    {
        ScreenShake.isScreenShakeon = value;

        switch(value)
        {
            case true:
                PlayerPrefs.SetInt("ScreenShakeValue", 1);
                break;
            case false:
                PlayerPrefs.SetInt("ScreenShakeValue", 0);
                break;
        }
    }

    public void SetHeadbob(bool value)
    {
        headbob.isHeadbobOn = value;

        switch (value)
        {
            case true:
                PlayerPrefs.SetInt("HeadBobValue", 1);
                break;
            case false:
                PlayerPrefs.SetInt("HeadBobValue", 0);
                break;
        }
    }

    public void SetCamTilt(bool value)
    {
        CamTilt.isCamTilt = value;

        switch (value)
        {
            case true:
                PlayerPrefs.SetInt("CamTiltValue", 1);
                break;
            case false:
                PlayerPrefs.SetInt("CamTiltValue", 0);
                break;
        }
    }

    public void SetShowFrame(bool value)
    {
        showframe.isShowingFrame = value;

        switch (value)
        {
            case true:
                PlayerPrefs.SetInt("FrameShowValue", 1);
                break;
            case false:
                PlayerPrefs.SetInt("FrameShowValue", 0);
                break;
        }
    }

    void GeneralSavings()
    {
        switch (PlayerPrefs.GetInt("ScreenShakeValue"))
        {
            case 1:
                ScreenShake1.isOn = true;
                break;
            case 0:
                ScreenShake1.isOn = false;
                break;
        }
        switch (PlayerPrefs.GetInt("HeadBobValue"))
        {
            case 1:
                Headbob.isOn = true;
                break;
            case 0:
                Headbob.isOn = false;
                break;
        }
        switch (PlayerPrefs.GetInt("CamTiltValue"))
        {
            case 1:
                ScreenTilt.isOn = true;
                break;
            case 0:
                ScreenTilt.isOn = false;
                break;
        }
        switch (PlayerPrefs.GetInt("FrameShowValue"))
        {
            case 1:
                ShowFPS.isOn = true;
                break;
            case 0:
                ShowFPS.isOn = false;
                break;
        }
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
