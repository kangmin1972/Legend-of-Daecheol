using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class shotgunshoot : MonoBehaviour
{
    public Animation shotgunshake;
    public AudioSource shotgunsfx;
    public Animation shotgunrecoil;
    public GameObject shotgunmodel;
    public Transform cam;
    public bool canattack;
    public bool animationrewind;
    public LayerMask layer_mask;
    public Animation shotgunhair;
    public ScreenShake ss;
    public GameObject shootPoint;
    public GameObject bullet;
    public int bulletint;
    public GameObject SetDisable1;
    public GameObject SetDisable2;

    public GameObject bulletparticle;

    [SerializeField] float inaccuracyDistance = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        layer_mask = LayerMask.GetMask("post", "post2", "Player", "BulletImpactReal", "bulletimpact");
        canattack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponsystem.canuseshotgun == true)
        {
            shotgunmodel.SetActive(true);
            if (Input.GetMouseButtonDown(0) && canattack == true)
            {
                shotgunshake.Stop();
                Shoot();
                shotgunhair.Play("shotguncrosshair");
                switch(bulletint)
                {
                    case 0:
                        shotgunshake.Play("shotgunshoot1");
                        break;
                    case 1:
                        shotgunshake.Play("shotgunshake");
                        break;
                }
                canattack = false;
                weaponsystem.canchangeweapons = false;
                shotgunrecoil.Play("shotgunrecoil");
                StartCoroutine(canchangeweaponm());
                StartCoroutine(Event_canattack());
                shotgunsfx.Play();
            }
        }
        else
        {
            animationrewind = true;
            shotgunmodel.SetActive(false);
        }
    }

    void Shoot()
    {
        StartCoroutine(ss.Shake(.3f, .1f));
        StartCoroutine(canmove());
        PlayerMove.canmove = false;
        for (int i = 0; i < 30; i++)
        {
            RaycastHit hit;
            if(Physics.Raycast(cam.position, ShootingDir(), out hit, Mathf.Infinity, ~layer_mask))
            {
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * 1000f);
                }

                GameObject tempBullet = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity);
                tempBullet.GetComponent<Bullet>().hitPoint = hit.point;

                GameObject impactGO = Instantiate(bulletparticle, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }
        }
    }

    Vector3 ShootingDir()
    {
        Vector3 targetpos = cam.position + cam.forward * 1f;
        targetpos = new Vector3(
            targetpos.x + Random.Range(-inaccuracyDistance, inaccuracyDistance),
            targetpos.y + Random.Range(-inaccuracyDistance, inaccuracyDistance),
            targetpos.z + Random.Range(-inaccuracyDistance, inaccuracyDistance)
            );
        Vector3 direction = targetpos - cam.position;
        return direction.normalized;
    }

    IEnumerator Event_canattack()
    {
        switch (bulletint)
        {
            case 0:
                yield return new WaitForSeconds(0.5f);
                bulletint = 1;
                break;
            case 1:
                yield return new WaitForSeconds(1.1f);
                bulletint = 0;
                break;
        }
        canattack = true;
    }

    IEnumerator canchangeweaponm()
    {
        yield return new WaitForSeconds(0.5f);
        weaponsystem.canchangeweapons = true;
    }

    IEnumerator canmove()
    {
        yield return new WaitForSeconds(0.1f);
        PlayerMove.canmove = true;
    }
}
