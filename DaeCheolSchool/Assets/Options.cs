using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using TMPro;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    public Camera MainCamera;
    public Toggle ScreenShake1;
    public Toggle Headbob;
    public Toggle ScreenTilt;
    public Toggle SeasonalEvent;
    public Toggle ShowFPS;

    public Toggle isbloom;
    public Toggle isdepthoffield;
    public Toggle iscolorgrading;
    public Toggle isambientocculusion;
    public Toggle ismotionblur;
    public Toggle isvsync;

    FullScreenMode fullscreenmode;

    public PostProcessVolume volume;
    Bloom bloom;
    DepthOfField dof;
    ColorGrading cg;
    AmbientOcclusion ao;
    MotionBlur mb;

    public bool ScreenShakebool;
    public bool Headbobbool;
    public bool ScreenTiltbool;
    public bool Seasonaleventbool;
    public bool ShowFPSbool;

    public static float camerasenvalue;
    public Slider CameraSen;
    public Slider FOV;
    public Slider MusicSlider;
    public Slider SFXSlider;

    public AudioMixer musicmixer;

    public GameObject opcanvas;
    public GameObject pausecanvas;

    public GameObject normal;
    public GameObject general;
    public GameObject graphic;
    public GameObject audio1;

    public TMP_Dropdown resolutionDropdown;
    List<Resolution> resolutions = new List<Resolution>();
    int resolutionNum;


    // Start is called before the first frame update
    void Start()
    {
        LoadData();
        InitUI();
    }

    void InitUI()
    {
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].refreshRate == 60)
                resolutions.Add(Screen.resolutions[i]);
        }
        resolutionDropdown.options.Clear();

        int optionNum = 0;
        foreach (Resolution item in resolutions)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.text = item.width + "x" + item.height + " " + item.refreshRate + "hz";
            resolutionDropdown.options.Add(option);

            if (item.width == Screen.width && item.height == Screen.height)
                resolutionDropdown.value = optionNum;
            optionNum++;
        }
        resolutionDropdown.RefreshShownValue();
    }

    public void DropboxOptionChange(int x)
    {
        resolutionNum = x;
        Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height, fullscreenmode);
        
    }

    public void SetVolume (float volume)
    {
        var dbVolume = Mathf.Log10(volume) * 20;
        if (volume == 0.0f)
        {
            dbVolume = -80.0f;
        }
        musicmixer.SetFloat("VolumeMusic", dbVolume);
    }

    void LoadData()
    {
        if (PlayerPrefs.HasKey("CameraSensiti"))
        {
            CameraSen.value = PlayerPrefs.GetFloat("CameraSensiti");
        }
        if (PlayerPrefs.HasKey("FOV"))
        {
            FOV.value = PlayerPrefs.GetFloat("FOV");
        }
        GeneralSavings();
        GraphicSavings();
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

    public void SetBloom(bool value)
    {
        volume.profile.TryGetSettings(out bloom);
        bloom.active = value;

        switch (value)
        {
            case true:
                PlayerPrefs.SetInt("BloomValue", 1);
                break;
            case false:
                PlayerPrefs.SetInt("BloomValue", 0);
                break;
        }
    }

    public void SetCG(bool value)
    {
        volume.profile.TryGetSettings(out cg);
        cg.active = value;

        switch (value)
        {
            case true:
                PlayerPrefs.SetInt("CGValue", 1);
                break;
            case false:
                PlayerPrefs.SetInt("CGValue", 0);
                break;
        }
    }

    public void SetDOF(bool value)
    {
        volume.profile.TryGetSettings(out dof);
        dof.active = value;

        switch (value)
        {
            case true:
                PlayerPrefs.SetInt("DOFValue", 1);
                break;
            case false:
                PlayerPrefs.SetInt("DOFValue", 0);
                break;
        }
    }

    public void SetAO(bool value)
    {
        volume.profile.TryGetSettings(out ao);
        ao.active = value;

        switch (value)
        {
            case true:
                PlayerPrefs.SetInt("AOValue", 1);
                break;
            case false:
                PlayerPrefs.SetInt("AOValue", 0);
                break;
        }
    }

    public void SetVsync(bool value)
    {

        switch (value)
        {
            case true:
                QualitySettings.vSyncCount = 1;
                PlayerPrefs.SetInt("VSYNCValue", 1);
                break;
            case false:
                QualitySettings.vSyncCount = 0;
                PlayerPrefs.SetInt("VSYNCValue", 0);
                break;
        }
    }

    void GeneralSavings()
    {
        if (PlayerPrefs.HasKey("ScreenShakeValue"))
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
        }
        if (PlayerPrefs.HasKey("HeadBobValue"))
        {
            switch (PlayerPrefs.GetInt("HeadBobValue"))
            {
                case 1:
                    Headbob.isOn = true;
                    break;
                case 0:
                    Headbob.isOn = false;
                    break;
            }
        }
        if (PlayerPrefs.HasKey("CamTiltValue"))
        {
            switch (PlayerPrefs.GetInt("CamTiltValue"))
            {
                case 1:
                    ScreenTilt.isOn = true;
                    break;
                case 0:
                    ScreenTilt.isOn = false;
                    break;
            }
        }
        if (PlayerPrefs.HasKey("FrameShowValue"))
        {
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
    }

    void GraphicSavings()
    {
        if (PlayerPrefs.HasKey("BloomValue"))
        {
            switch (PlayerPrefs.GetInt("BloomValue"))
            {
                case 1:
                    isbloom.isOn = true;
                    break;
                case 0:
                    isbloom.isOn = false;
                    break;
            }
        }
        if (PlayerPrefs.HasKey("DOFValue"))
        {
            switch (PlayerPrefs.GetInt("DOFValue"))
            {
                case 1:
                    isdepthoffield.isOn = true;
                    break;
                case 0:
                    isdepthoffield.isOn = false;
                    break;
            }
        }
        if (PlayerPrefs.HasKey("CGValue"))
        {
            switch (PlayerPrefs.GetInt("CGValue"))
            {
                case 1:
                    iscolorgrading.isOn = true;
                    break;
                case 0:
                    iscolorgrading.isOn = false;
                    break;
            }
        }
        if (PlayerPrefs.HasKey("AOValue"))
        {
            switch (PlayerPrefs.GetInt("AOValue"))
            {
                case 1:
                    isambientocculusion.isOn = true;
                    break;
                case 0:
                    isambientocculusion.isOn = false;
                    break;
            }
        }
        if (PlayerPrefs.HasKey("VSYNCValue"))
        {
            switch (PlayerPrefs.GetInt("VSYNCValue"))
            {
                case 1:
                    isvsync.isOn = true;
                    break;
                case 0:
                    isvsync.isOn = false;
                    break;
            }
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

    public void graphics()
    {
        normal.SetActive(false);
        graphic.SetActive(true);
    }

    public void sound()
    {
        normal.SetActive(false);
        audio1.SetActive(true);
    }

    public void SettijngTitle()
    {
        normal.SetActive(true);
        general.SetActive(false);
        graphic.SetActive(false);
        audio1.SetActive(false);
    }
}
