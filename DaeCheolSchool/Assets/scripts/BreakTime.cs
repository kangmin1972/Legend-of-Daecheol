using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakTime : MonoBehaviour
{
    public AudioSource m_break;
    public AudioSource m_school1f;

    public AudioSource m_earthquake;
    public AudioSource m_hell;

    public bool ok = false;

    public int randomed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(asdf());
    }

    void Update()
    {
        if (ok == true)
        {
            switch (randomed) {
                case 1:
                    if (!m_earthquake.isPlaying)
                    {
                        ok = false;
                        m_school1f.Play();
                        StartCoroutine(asdf());
                    }
                    break;
                case 2:
                    if (!m_hell.isPlaying)
                    {
                        ok = false;
                        m_school1f.Play();
                        StartCoroutine(asdf());
                    }
                    break;
            }
        }
    }

    IEnumerator asdf()
    {
        yield return new WaitForSeconds(300);
        m_break.Play();
        m_school1f.Stop();
        yield return new WaitForSeconds(8);
        randomed = Random.Range(1, 3);
        switch (randomed)
        {
            case 1:
                m_earthquake.Play();
                break;
            case 2:
                m_hell.Play();
                break;
        }
        yield return new WaitForSeconds(20);
        ok = true;
    }
}
