using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startscreen : MonoBehaviour
{
    bool caninteract = false;
    public Animation anim;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(startset());
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
