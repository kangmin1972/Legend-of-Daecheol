using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketbulelt : MonoBehaviour
{
    public GameObject explode;
    public bool isCreated = true;

    private void Start()
    {
        isCreated = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isCreated == true)
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(explode.transform, pos, rot);
            isCreated = false;
        }
        Destroy(gameObject);
    }
}
