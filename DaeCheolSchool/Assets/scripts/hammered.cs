using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammered : MonoBehaviour
{
    public GameObject fractured;

    // Update is called once per frame
    void OnMouseDown()
    {
        Instantiate(fractured, transform.position, transform.rotation);
        Destroy(gameObject);
    }
        
}
