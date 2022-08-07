using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponsystem : MonoBehaviour
{
    [Header("Normal Vars")]
    public Animation weaponintro;
    public AudioSource sfx;
    public bool weaponchanged;
    public int weaponstate;
    private Melee Meleeboxstate;
    private shootfar shootfarstate;
    private shootclose shootclosestate;
    private shootspecial shootspecialstate;
    private explosion explosionstate;
    public static bool canusehammer;
    public static bool canusetenniuzis;
    public static bool canusebazooka;
    public static bool canuseshotgun;
    public static bool canchangeweapons;

    [Header("Weapon Icon Sprites")]
    public Sprite hammericon;
    public Sprite tennisuziicon;
    public Sprite shotgunicon;
    public Sprite bazookaicon;

    [Header("Weapon Icons")]
    public GameObject weaponselectui;
    public GameObject meleebox;
    public GameObject shootfarbox;
    public GameObject shootclosebox;
    public GameObject shootspecialbox;
    public GameObject explosionbox;

    [Header("WAIT, ARE YOU HAVE IT?")]
    public bool havehammer;

    private enum Melee
    {
        Hammer
    }

    private enum shootfar
    {
        Tennisuzi
    }

    private enum shootclose
    {
        Shotgun
    }

    private enum shootspecial
    {
        Minigun
    }

    private enum explosion
    {
        Bazooka
    }

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
            weaponselectfornumbers();
            weaponselectforscroll();
        }
    }

    IEnumerator weaponuiremove()
    {
        yield return new WaitForSeconds(3.5f);
        weaponselectui.SetActive(false);
    }

    void weaponselectfornumbers()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            sfx.Play();
            allweaponremove();
            StopAllCoroutines();
            StartCoroutine(weaponuiremove());
            weaponselectui.SetActive(true);
            weaponstate = 1;
            weaponselectboxsettings();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            sfx.Play();
            allweaponremove();
            StopAllCoroutines();
            StartCoroutine(weaponuiremove());
            weaponselectui.SetActive(true);
            weaponstate = 2;
            weaponselectboxsettings();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            sfx.Play();
            allweaponremove();
            StopAllCoroutines();
            StartCoroutine(weaponuiremove());
            weaponselectui.SetActive(true);
            weaponstate = 3;
            weaponselectboxsettings();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            sfx.Play();
            allweaponremove();
            StopAllCoroutines();
            StartCoroutine(weaponuiremove());
            weaponselectui.SetActive(true);
            weaponstate = 4;
            weaponselectboxsettings();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            sfx.Play();
            allweaponremove();
            StopAllCoroutines();
            StartCoroutine(weaponuiremove());
            weaponselectui.SetActive(true);
            weaponstate = 5;
            weaponselectboxsettings();
        }

        clicktochange();
    }

    void weaponselectforscroll()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            sfx.Play();
            allweaponremove();
            StopAllCoroutines();
            StartCoroutine(weaponuiremove());
            weaponselectui.SetActive(true);
            weaponstate += 1;
            if (weaponstate > 5)
            {
                weaponstate = 1;
            }
            weaponselectboxsettings();
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            sfx.Play();
            allweaponremove();
            StopAllCoroutines();
            StartCoroutine(weaponuiremove());
            weaponselectui.SetActive(true);
            weaponstate -= 1;
            if (weaponstate < 1)
            {
                weaponstate = 5;
            }
            weaponselectboxsettings();
        }
    }

    void allweaponremove()
    {
        canusehammer = false;
        canusetenniuzis = false;
        canusebazooka = false;
        canuseshotgun = false;
    }

    void clicktochange()
    {
        if (Input.GetMouseButtonDown(0) && weaponstate != 0)
        {
            canchangeweapons = false;
            StartCoroutine(weaponusecooltime());
            weaponselectui.SetActive(false);
        }
    }

    void weaponselectboxsettings()
    {
        switch(weaponstate)
        {
            case 1:
                meleeboxset();
                break;
            case 2:
                shootfarboxset();
                break;
            case 3:
                shootcloseboxset();
                break;
            case 4:
                shootspecialboxset();
                break;
            case 5:
                explosionboxset();
                break;
        }
    }

    void meleeboxset()
    {
        meleebox.SetActive(true);
        shootclosebox.SetActive(false);
        shootfarbox.SetActive(false);
        shootspecialbox.SetActive(false);
        explosionbox.SetActive(false);
    }

    void shootcloseboxset()
    {
        meleebox.SetActive(false);
        shootclosebox.SetActive(true);
        shootfarbox.SetActive(false);
        shootspecialbox.SetActive(false);
        explosionbox.SetActive(false);
    }

    void shootfarboxset()
    {
        meleebox.SetActive(false);
        shootclosebox.SetActive(false);
        shootfarbox.SetActive(true);
        shootspecialbox.SetActive(false);
        explosionbox.SetActive(false);
    }

    void shootspecialboxset()
    {
        meleebox.SetActive(false);
        shootclosebox.SetActive(false);
        shootfarbox.SetActive(false);
        shootspecialbox.SetActive(true);
        explosionbox.SetActive(false);
    }

    void explosionboxset ()
    {
        meleebox.SetActive(false);
        shootclosebox.SetActive(false);
        shootfarbox.SetActive(false);
        shootspecialbox.SetActive(false);
        explosionbox.SetActive(true);
    }

    IEnumerator weaponusecooltime()
    {
        yield return new WaitForSeconds(0.1f);
        switch (weaponstate)
        {
            case 1:
                canusehammer = true;
                canusetenniuzis = false;
                canusebazooka = false;
                canuseshotgun = false;
                break;
            case 2:
                canusehammer = false;
                canusetenniuzis = true;
                canusebazooka = false;
                canuseshotgun = false;
                break;
            case 3:
                canusebazooka = false;
                canusehammer = false;
                canusetenniuzis = false;
                canuseshotgun = true;
                break;
            case 4:
                canusehammer = true;
                canusetenniuzis = false;
                canusebazooka = false;
                canuseshotgun = false;
                break;
            case 5:
                canusebazooka = true;
                canusehammer = false;
                canusetenniuzis = false;
                canuseshotgun = false;
                break;
        }
        weaponintro.Play("WeaponsIntro");
        canchangeweapons = true;
        weaponstate = 0;
        
    }

    void rememberme()
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
