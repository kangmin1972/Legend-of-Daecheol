using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private GameObject Main_Camera;

    void Start()
    {
        Main_Camera = GameObject.Find("Main Camera");
    }

    void LateUpdate()
    {
        transform.LookAt(new Vector3(Main_Camera.transform.position.x, transform.position.y, Main_Camera.transform.position.z));
    }
}
