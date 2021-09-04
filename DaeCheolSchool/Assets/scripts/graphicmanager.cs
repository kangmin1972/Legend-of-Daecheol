using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graphicmanager : MonoBehaviour
{
    public GameObject cubeppp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startscreen.graphicset == 1)
        {
            cubeppp.SetActive(true);
        } 
        else
        {
            cubeppp.SetActive(false);
        }
    }
}
