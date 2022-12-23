using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveIfPlayerConnect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
