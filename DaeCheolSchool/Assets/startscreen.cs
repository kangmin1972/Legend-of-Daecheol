using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class startscreen : MonoBehaviour
{
    bool caninteract = false;
    public static float graphicset = 1;
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
        if (graphicset == 1)
        {
            graphic.text = "그래픽 : 좋음";
        } 
        else
        {
            graphic.text = "그래픽 : 나쁨";
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
            PlayerPrefs.Save();
            caninteract = false;
        } 
    }

    public void graphicmove()
    {
        if (caninteract == true)
        {
            if (graphicset == 1)
            {
                PlayerPrefs.SetFloat("GraphicSETed", graphicset);
                PlayerPrefs.Save();
                graphicset = 2;
            }
            else
            {
                PlayerPrefs.SetFloat("GraphicSETed", graphicset);
                PlayerPrefs.Save();
                graphicset = 1;
            }
        }
    }

    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("GraphicSETed"))
            return;

        float graphiced = PlayerPrefs.GetFloat("GraphicSETed");

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
