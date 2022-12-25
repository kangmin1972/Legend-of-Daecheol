using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Animation dooropen;
    public AudioSource doorsfx;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<Collider>().enabled = false;
            Debug.Log("okay");
            if(!doorsfx.isPlaying)
                doorsfx.Play();
            dooropen.Play();
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
