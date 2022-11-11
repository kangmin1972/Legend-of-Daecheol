using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bazookashoot : MonoBehaviour
{
    public float cooldownSpeed;
    int layer_mask;

    public float fireRate;

    public float Rockets;

    private float accuracy;

    public float maxSpreadAngle;
    public float range;

    public float timeTillMaxSpread;

    public GameObject Rocket;

    public GameObject shootPoint;

    public AudioSource rocketshot;
    public GameObject RocketEffect;

    public Camera camera1;
    public ScreenShake ss;
    public LayerMask IgnoreMe;

    public Animator rocketshake;

    public GameObject bulletparticle;
    public GameObject bazooka;

    public bool canshoot = true;

    // Start is called before the first frame update
    void Start()
    {
        layer_mask = LayerMask.GetMask("post", "post2", "Player", "BulletImpactReal", "bulletimpact");
        canshoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownSpeed += Time.deltaTime * 90f;
        if (weaponsystem.canusebazooka == true)
        {
            bazooka.SetActive(true);
            

            if (Input.GetMouseButtonDown(0))
            {
                accuracy += Time.deltaTime * 4f;
                if (Rockets > 0)
                {
                    if (canshoot == true)
                    {
                        if (cooldownSpeed >= fireRate)
                        {
                            rocketshake.Play(0);
                            Shoot();
                            cooldownSpeed = 0;
                        }
                    }
                }
                else
                {
                    canshoot = false;
                }
            }
        }
        else
        {
            bazooka.SetActive(false);
            rocketshake.enabled = false;
        }
    }

    void Shoot()
    {
        StartCoroutine(ss.Shake(.2f, .1f));
        weaponsystem.canchangeweapons = false;
        StartCoroutine(shakedelay());
        RocketEffect.SetActive(true);
        rocketshot.Play();
        rocketshake.enabled = true;
        RocketEffect.SetActive(true);
        RaycastHit hit;

        Quaternion fireRotation = Quaternion.LookRotation(transform.forward);

        float currentSpread = Mathf.Lerp(0.0f, maxSpreadAngle, accuracy / timeTillMaxSpread);

        fireRotation = Quaternion.RotateTowards(fireRotation, Random.rotation, Random.Range(0.0f, currentSpread));

        if (Physics.Raycast(transform.position, fireRotation * Vector3.forward, out hit, Mathf.Infinity, ~layer_mask))
        {
            GameObject tempBullet = Instantiate(Rocket, shootPoint.transform.position, fireRotation);
            tempBullet.GetComponent<Bullet>().hitPoint = hit.point;
        }

    }

    IEnumerator shakedelay()
    {
        yield return new WaitForSeconds(0.3f);
        weaponsystem.canchangeweapons = true;
    }
}
