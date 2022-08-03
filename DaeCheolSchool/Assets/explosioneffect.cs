using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosioneffect : MonoBehaviour
{
    public AudioSource explode;
    public ScreenShake ss;
    // Start is called before the first frame update
    void Start()
    {
        explode.Play();
        StartCoroutine(ss.Shake(.1f, .2f));
    }
}
