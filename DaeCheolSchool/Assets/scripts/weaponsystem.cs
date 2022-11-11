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
    public static bool canuseminigun;

    [Header("Weapon Icon Sprites")]
    public Image Meleeicon;
    public Image shootfaricon;
    public Image shootcloseicon;
    public Image shootspecialicon;
    public Image explosionicon;

    public Sprite hammericon;
    public Sprite tennisuziicon;
    public Sprite shotgunicon;
    public Sprite bazookaicon;
    public Sprite minigunicon;
    public Sprite none;

    public Image UIWeaponIcon;

    [Header("Weapons Has Cartegories")]
    public bool hasmelee;
    public bool hasshootfar;
    public bool hasshootclose;
    public bool hasshootspecial;
    public bool hasexplosion;

    [Header("Weapon Icons")]
    public GameObject weaponselectui;
    public GameObject meleebox;
    public GameObject shootfarbox;
    public GameObject shootclosebox;
    public GameObject shootspecialbox;
    public GameObject explosionbox;

    [Header("Weapon Crosshairs")]
    public GameObject shotguncrosshair;
    public GameObject riflecrosshair;

    [Header("WAIT, ARE YOU HAVE IT?")]
    public static bool havehammer = true;
    public static bool havetennisuzi;
    public static bool haveshotgun;
    public static bool haveminigun;
    public static bool havebazooka;

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

        itemcheck();

        switch (weaponstate)
        {
            case 2:
                if (hasshootfar == false)
                {
                    shootfaricon.sprite = none;
                }
                break;
            case 3:
                if (hasshootclose == false)
                {
                    shootcloseicon.sprite = none;
                }
                break;
            case 4:
                if (hasshootspecial == false)
                {
                    shootspecialicon.sprite = none;
                }
                break;
            case 5:
                if (hasexplosion == false)
                {
                    explosionicon.sprite = none;
                }
                break;
        }
    }

    IEnumerator weaponuiremove()
    {
        yield return new WaitForSeconds(3.5f);
        weaponstate = 0;
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
        canuseminigun = false;
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

    void itemcheck()
    {
        if (havetennisuzi == true)
        {
            hasshootfar = true;
        }
        if (haveshotgun == true)
        {
            hasshootclose = true;
        }
        if (haveminigun == true)
        {
            hasshootspecial = true;
        }
        if (havebazooka == true)
        {
            hasexplosion = true;
        }
    }

    IEnumerator weaponusecooltime()
    {
        yield return new WaitForSeconds(0.1f);
        switch (weaponstate)
        {
            case 1:
                UIWeaponIcon.sprite = hammericon;
                shotguncrosshair.SetActive(false);
                riflecrosshair.SetActive(false);
                canusehammer = true;
                canusetenniuzis = false;
                canusebazooka = false;
                canuseshotgun = false;
                canuseminigun = false;
                break;
            case 2:
                userifle();
                
                break;
            case 3:
                useshotgun();
                break;
            case 4:
                useminigun();
                break;
            case 5:
                usebazooka();
                break;
        }
        weaponintro.Play("WeaponsIntro");
        canchangeweapons = true;
        weaponstate = 0;

    }

    //weaponssettings

    void userifle()
    {
        if (hasshootfar == true)
        {
            UIWeaponIcon.sprite = tennisuziicon;
            shotguncrosshair.SetActive(false);
            riflecrosshair.SetActive(true);
            canusehammer = false;
            canusetenniuzis = true;
            canusebazooka = false;
            canuseshotgun = false;
            canuseminigun = false;
        }
    }

    void useshotgun()
    {
        if (hasshootclose == true)
        {
            UIWeaponIcon.sprite = shotgunicon;
            shotguncrosshair.SetActive(true);
            riflecrosshair.SetActive(false);
            canusebazooka = false;
            canusehammer = false;
            canusetenniuzis = false;
            canuseshotgun = true;
            canuseminigun = false;
        }
    }

    void useminigun()
    {
        if (hasshootspecial == true)
        {
            UIWeaponIcon.sprite = minigunicon;
            shotguncrosshair.SetActive(false);
            riflecrosshair.SetActive(false);
            canusehammer = false;
            canusetenniuzis = false;
            canusebazooka = false;
            canuseshotgun = false;
            canuseminigun = true;
        }
    }

    void usebazooka()
    {
        if (hasexplosion == true)
        {
            UIWeaponIcon.sprite = bazookaicon;
            shotguncrosshair.SetActive(false);
            riflecrosshair.SetActive(false);
            canusebazooka = true;
            canusehammer = false;
            canusetenniuzis = false;
            canuseshotgun = false;
            canuseminigun = false;
        }
    }
}
