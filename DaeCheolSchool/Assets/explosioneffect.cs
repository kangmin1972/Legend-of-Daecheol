using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosioneffect : MonoBehaviour
{
    public AudioSource explode;
    public ScreenShake ss;
    // Start is called before the first frame update
    void Start()
    {
        explode.Play();
        knockback();
        StartCoroutine(ss.Shake(.1f, .2f));
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
