using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class startscreen : MonoBehaviour
{
    bool caninteract = false;
    public static int graphicset = 1;
    public static int effectsset = 1;
    public static int isfullscreen = 1;
    public static int iscrosshairon = 1;
    public static int isleavingpieces = 2;
    public GameObject normalcanvas;
    public GameObject gamemodecanvas;
    public Animation anim;
    public TMP_Dropdown resolutiondrop;
    public TextMeshProUGUI graphic;
    public TextMeshProUGUI effect;
    public TextMeshProUGUI fullscreen;
    public TextMeshProUGUI crosshair;
    public TextMeshProUGUI leavingpieces;
    public AudioSource buttonclick;

    public Toggle FullSCREAM;
    public Animation fadeanim;

    FullScreenMode screenMode;

    int resoltuionnum;

    List<Resolution> resolutions = new List<Resolution>();

    public Animation settings;

    // Start is called before the first frame update
    private void Start()
    {
        GameLoad();
        StartCoroutine(startset());
    }

    private void Update()
    {
        switch(graphicset)
        {
            case 1:
                graphic.text = "그래픽 : 좋음";
                QualitySettings.SetQualityLevel(0);
                break;
            case 2:
                graphic.text = "그래픽 : 나쁨";
                QualitySettings.SetQualityLevel(1);
                break;
            case 3:
                graphic.text = "그래픽 : 매우 나쁨";
                QualitySettings.SetQualityLevel(2);
                break;
        }

        switch(effectsset)
        {
            case 1:
                effect.text = "이펙트 : 켜짐";
                break;
            case 2:
                effect.text = "이펙트 : 꺼짐";
                break;
        }

        switch (isfullscreen)
        {
            case 1:
                fullscreen.text = "전체화면 : 켜짐";
                Screen.fullScreen = true;
                break;
            case 2:
                fullscreen.text = "전체화면 : 꺼짐";
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
    //찾아봐라ㅋㅋㅋ
    public void startbutton()
    {
        if (caninteract == true)
        {
            buttonclick.Play();
            normalcanvas.SetActive(false);
            gamemodecanvas.SetActive(true);
        }
    }

    public void storymode()
    {
        if (caninteract == true)
        {
            buttonclick.Play();
            anim.Play("cameramove2");
            fadeanim.Play();
            StartCoroutine(startanimation());
            caninteract = false;
        }
    }

    public void goback()
    {
        if(caninteract == true)
        {
            buttonclick.Play();
            normalcanvas.SetActive(true);
            gamemodecanvas.SetActive(false);
        }
    }

    public void exitgame()
    {
        if (caninteract == true)
        {
            buttonclick.Play();
            Application.Quit();
            
            caninteract = false;
        } 
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

    public void effectmove()
    {
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

    public void GameSettingMoveCamera()
    {
        if (caninteract == true)
        {
            anim.Play("cameramove3");
            caninteract = false;
        }
        
    }

    public void GameSettingBackCamera()
    {
        anim.Play("cameramove4");
        caninteract = true;
    }

    IEnumerator startset()
    {
        yield return new WaitForSeconds(2);
        caninteract = true;
    }

    IEnumerator startanimation()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("NewGame");
    }
}
