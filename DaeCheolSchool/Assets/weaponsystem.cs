using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponsystem : MonoBehaviour
{
    public Animation weaponintro;
    public int weaponstate;
    public static bool canusehammer;
    public static bool canusetenniuzis;
    public static bool canusebazooka;
    public static bool canuseshotgun;
    public static bool canchangeweapons;

    [Header("Weapon Icons")]
    public Sprite hammericon;
    public Sprite tennisuziicon;
    public Sprite shotgunicon;
    public Sprite bazookaicon;
    public Image iconmain;

    private void Start()
    {
        canchangeweapons = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (canchangeweapons == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && weaponstate != 1)
            {
                iconmain.sprite = hammericon;
                weaponstate = 1;
                weaponintro.Play("WeaponsIntro");
                canusehammer = true;
                canusetenniuzis = false;
                canusebazooka = false;
                canuseshotgun = false;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && weaponstate != 2)
            {
                iconmain.sprite = tennisuziicon;
                weaponstate = 2;
                weaponintro.Play("WeaponsIntro");
                canusehammer = false;
                canusetenniuzis = true;
                canusebazooka = false;
                canuseshotgun = false;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) && weaponstate != 3)
            {
                iconmain.sprite = shotgunicon;
                weaponstate = 3;
                weaponintro.Play("WeaponsIntro");
                canusebazooka = false;
                canusehammer = false;
                canusetenniuzis = false;
                canuseshotgun = true;
            }

            if (Input.GetKeyDown(KeyCode.Alpha4) && weaponstate != 4)
            {
                iconmain.sprite = bazookaicon;
                weaponstate = 4;
                weaponintro.Play("WeaponsIntro");
                canusebazooka = true;
                canusehammer = false;
                canusetenniuzis = false;
                canuseshotgun = false;
            }
        }
    }
}
