using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.PostProcessing;

public class Settings : MonoBehaviour
{
    bool caninteract = false;
    public static int graphicset = 1;
    public static int effectsset = 1;
    public static int isfullscreen = 1;
    public static int iscrosshairon = 1;
    public static int isleavingpieces = 2;
    public TMP_Dropdown resolutiondrop;
    public TextMeshProUGUI graphic;
    public TextMeshProUGUI effect;
    public TextMeshProUGUI fullscreen;
    public TextMeshProUGUI crosshair;
    public TextMeshProUGUI leavingpieces;
    public AudioSource buttonclick;
    public Animation fadeanim;

    public TMP_Dropdown resolutionDropdown;
    List<Resolution> resolutions = new List<Resolution>();
    int resolutionNum;

    public PostProcessVolume volume;

    public GameObject General;
    public GameObject Graphic;

    public GameObject normalcanvas;

    public TextMeshProUGUI fullscreente;

    public GameObject creditscanvas;

    FullScreenMode screenMode;

    int resoltuionnum;

    public Animation settings;

    private void Start()
    {
        InitUI();
    }

    void InitUI()
    {
        resolutions.AddRange(Screen.resolutions);
        resolutionDropdown.options.Clear();

        foreach (Resolution item in resolutions)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.text = item.width + "x" + item.height + "" + item.refreshRate + "hz";
            resolutionDropdown.options.Add(option);
        }
        resolutionDropdown.RefreshShownValue();
    }

    public void DropboxOptionChange(int x)
    {
        resolutionNum = x;
    }

    void Update()
    {

        switch (effectsset)
        {
            case 1:
                effect.text = "켜짐";
                break;
            case 2:
                effect.text = "꺼짐";
                break;
        }

        switch (isfullscreen)
        {
            case 1:
                fullscreen.text = "켜짐";
                Screen.fullScreen = true;
                break;
            case 2:
                fullscreen.text = "꺼짐";
                Screen.fullScreen = false;
                break;
        }

        switch (iscrosshairon)
        {
            case 1:
                crosshair.text = "조준점 : 켜짐";
                break;
            case 2:
                crosshair.text = "조준점 : 꺼짐";
                break;
        }

        switch (isleavingpieces)
        {
            case 1:
                leavingpieces.text = "잔해 남기기 : 켜짐";
                break;
            case 2:
                leavingpieces.text = "잔해 남기기 : 꺼짐";
                break;
        }
    }

    public void Backtostart()
    {
        buttonclick.Play();
        normalcanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void graphicmove()
    {
        switch (graphicset)
        {
            case 1:
                graphicset = 2;
                PlayerPrefs.SetInt("GraphicSETed", graphicset);
                PlayerPrefs.Save();
                break;
            case 2:
                graphicset = 3;
                PlayerPrefs.SetInt("GraphicSETed", graphicset);
                PlayerPrefs.Save();
                break;
            case 3:
                graphicset = 1;
                PlayerPrefs.SetInt("GraphicSETed", graphicset);
                PlayerPrefs.Save();
                break;
        }
    }

    //이펙트
    public void effectmove()
    {
        buttonclick.Play();
        switch (effectsset)
        {
            case 1:
                effectsset = 2;
                PlayerPrefs.SetInt("EffectSETed", effectsset);
                PlayerPrefs.Save();
                break;
            case 2:
                effectsset = 1;
                PlayerPrefs.SetInt("EffectSETed", effectsset);
                PlayerPrefs.Save();
                break;
        }
    }

    public void fullscreenmove()
    {
        switch (isfullscreen)
        {
            case 1:
                isfullscreen = 2;
                PlayerPrefs.SetInt("ScreenSETed", isfullscreen);
                PlayerPrefs.Save();
                break;
            case 2:
                isfullscreen = 1;
                PlayerPrefs.SetInt("ScreenSETed", isfullscreen);
                PlayerPrefs.Save();
                break;
        }
    }

    public void crosshairmove()
    {
        switch (iscrosshairon)
        {
            case 1:
                iscrosshairon = 2;
                PlayerPrefs.SetInt("CrosshairSETed", iscrosshairon);
                PlayerPrefs.Save();
                break;
            case 2:
                iscrosshairon = 1;
                PlayerPrefs.SetInt("CrosshairSETed", iscrosshairon);
                PlayerPrefs.Save();
                break;
        }
    }

    public void leavingpiecemove()
    {
        switch (isleavingpieces)
        {
            case 1:
                isleavingpieces = 2;
                PlayerPrefs.SetInt("LeavingSETed", isleavingpieces);
                PlayerPrefs.Save();
                break;
            case 2:
                isleavingpieces = 1;
                PlayerPrefs.SetInt("LeavingSETed", isleavingpieces);
                PlayerPrefs.Save();
                break;
        }
    }


    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("GraphicSETed") || !PlayerPrefs.HasKey("EffectSETed") || !PlayerPrefs.HasKey("ScreenSETed") || !PlayerPrefs.HasKey("CrosshairSETed") || !PlayerPrefs.HasKey("LeavingSETed"))
            return;

        int graphiced = PlayerPrefs.GetInt("GraphicSETed");
        int effected = PlayerPrefs.GetInt("EffectSETed");
        int screened = PlayerPrefs.GetInt("ScreenSETed", isfullscreen);
        int crosshaired = PlayerPrefs.GetInt("CrosshairSETed");
        int leavedpiece = PlayerPrefs.GetInt("LeavingSETed");


        graphicset = graphiced;
        effectsset = effected;
        isfullscreen = screened;
        iscrosshairon = crosshaired;
        isleavingpieces = leavedpiece;
    }

    public void Generalcanvas()
    {
        buttonclick.Play();
        General.SetActive(true);
        Graphic.SetActive(false);
    }

    public void Graphiccanvas()
    {
        buttonclick.Play();
        Graphic.SetActive(true);
        General.SetActive(false);
    }
}
