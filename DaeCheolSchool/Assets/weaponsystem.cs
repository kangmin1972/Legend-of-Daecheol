using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponsystem : MonoBehaviour
{
    public static bool canusehammer;
    public static bool canusetenniuzis;
    public static bool canusebazooka;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            canusehammer = true;
            canusetenniuzis = false;
            canusebazooka = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            canusehammer = false;
            canusetenniuzis = true;
            canusebazooka = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            canusebazooka = true;
            canusehammer = false;
            canusetenniuzis = false;
        }
    }
}
