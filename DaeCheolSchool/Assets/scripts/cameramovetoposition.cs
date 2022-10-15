using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovetoposition : MonoBehaviour
{
    public Transform endMarker = null; // create an empty gameobject and assign in inspector
    public Transform camera41;
    void Update()
    {
        camera41.position = Vector3.MoveTowards(transform.position, endMarker.position, 5f * Time.deltaTime);

    }
}
