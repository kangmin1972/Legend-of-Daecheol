using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class graphicmanager : MonoBehaviour
{
    public PostProcessLayer cubeppp;
    public PostProcessVolume volume;
    Bloom bloom;
    DepthOfField dof;
    ColorGrading cg;
    AmbientOcclusion ao;
    MotionBlur mb;
    public static bool isbloom;
    public static bool isdepthoffield;
    public static bool iscolorgrading;
    public static bool isambientocculusion;
    public static bool ismotionblur;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
