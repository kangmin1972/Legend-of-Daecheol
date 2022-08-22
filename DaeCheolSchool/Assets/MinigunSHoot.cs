using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunSHoot : MonoBehaviour
{
    public Animation minigunshake;
    public AudioSource minigunsfx;
    public GameObject minigunmodel;
    public Transform cam;
    public bool canattack;
    public bool animationrewind;
    public LayerMask layer_mask;
    public Animation minigunhair;
    public GameObject camera1;
    public ParticleSystem gunshot;
    public LayerMask IgnoreMe;
    public ScreenShake ss;
    public bool isshooting;
    public bool readyanim;
    public AudioSource end;
    public GameObject shootlight;

    public AudioSource windup;

    public float cooldownSpeed;

    public float fireRate;

    public GameObject bulletparticle;

    [SerializeField] float inaccuracyDistance = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        canattack = true;
        animationrewind = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponsystem.canuseminigun == true)
        {
            minigunmodel.SetActive(true);
            shootlight.SetActive(false);
            cooldownSpeed += Time.deltaTime * 90f;

            if(Input.GetMouseButtonDown(0))
            {
                windup.Play();
                readyanim = true;
                minigunshake.Play("minigunready");
                StartCoroutine(Event_canattack());
            }

            if(readyanim == true)
            {
                if (minigunshake.isPlaying == false)
                {
                    minigunshake.Play("minigunready");
                }
            }

            if (Input.GetMouseButton(0) && isshooting == true)
            {
                minigunshake.Play("minigunshoot");
                shootlight.SetActive(true);
                if (cooldownSpeed >= fireRate)
                {
                    gunshot.Play();
                    Shoot();
                    if (minigunsfx.isPlaying == false)
                    {
                        minigunsfx.Play();
                    }
                    cooldownSpeed = 0;
                }
            }
            else
            {
                isshooting = false;
                minigunsfx.Stop();

            }

            if (Input.GetMouseButtonUp(0))
            {
                if (end.isPlaying == false)
                {
                    end.Play();
                }
                readyanim = false;
                shootlight.SetActive(false);
                if (minigunshake.isPlaying == true)
                {

                    minigunshake.Play("minigunend");
                    windup.Stop();
                }
                windup.Stop();
                minigunshake.Play("minigunend");
                StopAllCoroutines();

            }
        }
        else
        {
            minigunmodel.SetActive(false);
            minigunshake.Stop();
        }
    }

    void Shoot()
    {
        StartCoroutine(ss.Shake(.15f, .15f));
        RaycastHit hit;
        if (Physics.Raycast(camera1.transform.position, ShootingDir(), out hit, Mathf.Infinity, ~IgnoreMe))
        {
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * 1000f);
            }

            GameObject impactGO = Instantiate(bulletparticle, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
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
        yield return new WaitForSeconds(1f);
        isshooting = true;
        readyanim = false;
    }

    IEnumerator canchangeweaponm()
    {
        yield return new WaitForSeconds(0.5f);
        weaponsystem.canchangeweapons = true;
    }
}
