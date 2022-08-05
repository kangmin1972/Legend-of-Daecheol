using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgunshoot : MonoBehaviour
{
    public Animator shotgunshake;
    public AudioSource shotgunsfx;
    public Animation shotgunrecoil;
    public GameObject shotgunmodel;
    public bool canattack;
    public bool animationrewind;

    // Start is called before the first frame update
    void Start()
    {
        canattack = true;
        animationrewind = true;
        shotgunshake.playbackTime = 0;
        shotgunshake.Rebind();
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponsystem.canuseshotgun == true)
        {
            shotgunmodel.SetActive(true);
            if (animationrewind == true)
            {
                shotgunshake.playbackTime = 0;
                shotgunshake.Rebind();
                shotgunshake.speed = 0;
                animationrewind = false;
            }
            if (Input.GetMouseButtonDown(0) && canattack == true)
            {
                shotgunshake.speed = 1;
                canattack = false;
                weaponsystem.canchangeweapons = false;
                shotgunrecoil.Play("shotgunrecoil");
                StartCoroutine(Event_canattack());
                shotgunsfx.Play();
                shotgunshake.Play(0);
            }
        }
        else
        {
            animationrewind = true;
            shotgunmodel.SetActive(false);
            shotgunshake.playbackTime = 0;
            shotgunshake.Rebind();
        }
    }

    IEnumerator Event_canattack()
    {
        yield return new WaitForSeconds(1.1f);
        weaponsystem.canchangeweapons = true;
        canattack = true;
    }
}
