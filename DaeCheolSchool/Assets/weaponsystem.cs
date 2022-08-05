using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponsystem : MonoBehaviour
{
    public static bool canusehammer;
    public static bool canusetenniuzis;
    public static bool canusebazooka;
    public static bool canuseshotgun;
    public static bool canchangeweapons;

    private void Start()
    {
        canchangeweapons = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (canchangeweapons == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                canusehammer = true;
                canusetenniuzis = false;
                canusebazooka = false;
                canuseshotgun = false;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                canusehammer = false;
                canusetenniuzis = true;
                canusebazooka = false;
                canuseshotgun = false;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                canusebazooka = false;
                canusehammer = false;
                canusetenniuzis = false;
                canuseshotgun = true;
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                canusebazooka = true;
                canusehammer = false;
                canusetenniuzis = false;
                canuseshotgun = false;
            }
        }
    }
}
