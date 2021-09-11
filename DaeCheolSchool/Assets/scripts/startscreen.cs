using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class startscreen : MonoBehaviour
{
    bool caninteract = false;
    public static int graphicset = 1;
    public Animation anim;
    public TextMeshProUGUI graphic;
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
                break;
            case 2:
                graphic.text = "그래픽 : 나쁨";
                break;
            case 3:
                graphic.text = "그래픽 : 매우 나쁨";
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
        if (caninteract == true)
        {
            if (graphicset == 1)
            {
                graphicset = 2;
                PlayerPrefs.SetInt("GraphicSETed", graphicset);
                
                PlayerPrefs.Save();
                
            }
            else
            {
                graphicset = 1;
                PlayerPrefs.SetInt("GraphicSETed", graphicset);
                PlayerPrefs.Save();
            }
        }
    }

    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("GraphicSETed"))
            return;

        int graphiced = PlayerPrefs.GetInt("GraphicSETed");

        graphicset = graphiced;
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
