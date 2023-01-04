using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PeopleTalk : MonoBehaviour
{
    public GameObject textbox;
    public TextMeshPro text;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textbox.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textbox.SetActive(false);
        }
    }
}
