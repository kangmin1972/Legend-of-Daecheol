using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponsystem : MonoBehaviour
{
    public static bool canusehammer;
    public static bool canusetenniuzis;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            canusehammer = true;
            canusetenniuzis = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            canusehammer = false;
            canusetenniuzis = true;
        }
    }
}
