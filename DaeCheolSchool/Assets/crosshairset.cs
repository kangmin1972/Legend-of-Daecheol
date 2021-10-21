using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class crosshairset : MonoBehaviour
{
    public GameObject crosshair;

    // Update is called once per frame
    void Update()
    {
        if (startscreen.iscrosshairon == 2)
        {
            crosshair.SetActive(false);
        }
    }
}
