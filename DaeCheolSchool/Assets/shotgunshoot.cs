using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgunshoot : MonoBehaviour
{
    public Animator shotgunshake;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            shotgunshake.Play(0);
        }
    }
}
