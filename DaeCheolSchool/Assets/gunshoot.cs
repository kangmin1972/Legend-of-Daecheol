using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class gunshoot : MonoBehaviour
{

    public float cooldownSpeed;
    int layer_mask;

    public float bullets;

    public float fireRate;

    public float recoilCooldown;

    private float accuracy;

    public float maxSpreadAngle;
    public float range;

    public float timeTillMaxSpread;

    public GameObject bullet;

    public GameObject shootPoint;

    public AudioSource gunshot;
    public GameObject GunEffect;

    public Camera camera1;
    public ScreenShake ss;
    public LayerMask IgnoreMe;

    public Animator gunshake;

    public GameObject bulletparticle;
    public GameObject tenniuzi;

    public bool canshoot = true;

    // Start is called before the first frame update
    void Start()
    {
        layer_mask = LayerMask.GetMask("Default");
        canshoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponsystem.canusetenniuzis == true)
        {
            tenniuzi.SetActive(true);
            cooldownSpeed += Time.deltaTime * 90f;

            if (Input.GetMouseButton(0))
            {
                accuracy += Time.deltaTime * 4f;
                if (bullets > 0)
                {
                    if (canshoot == true)
                    {
                        if (cooldownSpeed >= fireRate)
                        {
                            Shoot();
                            cooldownSpeed = 0;
                            recoilCooldown = 1;
                        }
                    }
                }
                else
                {
                    canshoot = false;
                }
            }
            else
            {
                gunshake.enabled = false;
                recoilCooldown -= Time.deltaTime;
                if (recoilCooldown <= 1)
                {
                    accuracy = 0.0f;
                }
            }
        }
        else
        {
            tenniuzi.SetActive(false);
        }
    }

    void Shoot()
    {
        gunshot.Play();
        gunshake.enabled = true;
        StartCoroutine(ss.Shake(.05f, .1f));
        GunEffect.SetActive(true);
        RaycastHit hit;

        Quaternion fireRotation = Quaternion.LookRotation(transform.forward);

        float currentSpread = Mathf.Lerp(0.0f, maxSpreadAngle, accuracy / timeTillMaxSpread);

        fireRotation = Quaternion.RotateTowards(fireRotation, Random.rotation, Random.Range(0.0f, currentSpread));

        if (Physics.Raycast(transform.position, fireRotation * Vector3.forward, out hit, Mathf.Infinity,layer_mask))
        {
            GameObject tempBullet = Instantiate(bullet, shootPoint.transform.position, fireRotation);
            tempBullet.GetComponent<Bullet>().hitPoint = hit.point;
        }

        if (Physics.Raycast(camera1.transform.position, camera1.transform.forward, out hit, range, ~IgnoreMe))
        {
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * 1000f);
            }

            GameObject impactGO = Instantiate(bulletparticle, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
