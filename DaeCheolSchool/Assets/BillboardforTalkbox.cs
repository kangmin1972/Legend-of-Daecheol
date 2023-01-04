using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardforTalkbox : MonoBehaviour
{
    public GameObject Main_Camera;

    void LateUpdate()
    {
        transform.LookAt(new Vector3(Main_Camera.transform.position.x, transform.position.y, Main_Camera.transform.position.z));
    }
}
