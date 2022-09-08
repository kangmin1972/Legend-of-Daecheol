using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamefirstintro : MonoBehaviour
{
    public GameObject introcanvas;
    public GameObject audio1;
    public GameObject normalcanvas;
    public Animator anim;

    private void Start()
    {
        audio1.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (DaySystem.todaydate == 1)
        {
            StartCoroutine(introends());
            normalcanvas.SetActive(false);
            introcanvas.SetActive(true);
            PlayerMove.canmove = false;
        }
        else
        {
            PlayerMove.canmove = true;
            audio1.SetActive(true);
            introcanvas.SetActive(false);
            normalcanvas.SetActive(true);
        }
    }

    IEnumerator introends()
    {
        yield return new WaitForSeconds(6.1f);
        audio1.SetActive(true);
        StartCoroutine(introends2());
    }

    IEnumerator introends2()
    {
        yield return new WaitForSeconds(2.2f);
        PlayerMove.canmove = true;
        introcanvas.SetActive(false);
        normalcanvas.SetActive(true);
    }
}
