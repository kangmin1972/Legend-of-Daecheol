using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketbulelt : MonoBehaviour
{
    public GameObject explode;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.contacts[0].point.ToString());
        Instantiate(explode, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
