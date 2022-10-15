using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosioneffect : MonoBehaviour
{
    public AudioSource explode;
    public GameObject ss;
    public ScreenShake musd;
    // Start is called before the first frame update
    void Start()
    {
        ss = GameObject.Find("MainCameraScreen");
        musd = ss.GetComponent<ScreenShake>();
        explode.Play();
        knockback();
        StartCoroutine(musd.Shake(.3f, .15f));
    }

    void knockback()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 5);

        foreach (Collider nearyby in colliders)
        {
            Rigidbody rb = nearyby.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(1000, transform.position, 10);
            }
        }
    }
}
