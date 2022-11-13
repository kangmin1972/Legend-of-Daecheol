using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Graphic__Manual : MonoBehaviour
{
    public PostProcessVolume cubeppp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Settings.effectsset == 1)
        {
            cubeppp.enabled = true;
        }
        else
        {
            cubeppp.enabled = false;
        }
    }
}
