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
    public Animation anim;
    public TMP_Dropdown resolutiondrop;
    public TextMeshProUGUI graphic;
    public TextMeshProUGUI effect;
    public TextMeshProUGUI fullscreen;

    public Toggle FullSCREAM;

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
    }
    //찾아봐라ㅋㅋㅋ
    public void startbutton()
    {
        if (caninteract == true)
        {
            anim.Play("cameramove2");
            StartCoroutine(startanimation());
            caninteract = false;
        }
    }

    public void exitgame()
    {
        if (caninteract == true)
        {
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


    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("GraphicSETed") || !PlayerPrefs.HasKey("EffectSETed") || !PlayerPrefs.HasKey("ScreenSETed"))
            return;

        int graphiced = PlayerPrefs.GetInt("GraphicSETed");
        int effected = PlayerPrefs.GetInt("EffectSETed");
        int screened = PlayerPrefs.GetInt("ScreenSETed", isfullscreen);


        graphicset = graphiced;
        effectsset = effected;
        isfullscreen = screened;
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
        SceneManager.LoadScene("gametips");
    }
}
