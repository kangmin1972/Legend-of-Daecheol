using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionsfix : MonoBehaviour
{
    public Transform DoorPrefab;

    void Start()
    {
        Transform bullet = Instantiate(DoorPrefab) as Transform;
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
    }
}
