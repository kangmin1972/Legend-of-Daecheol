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
        transform.LookAt(Main_Camera.transform);
    }
}
