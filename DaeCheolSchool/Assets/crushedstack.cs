using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class crushedstack : MonoBehaviour
{
    public static int stack;
    public TextMeshProUGUI text;
    // Update is called once per frame
    void Update()
    {
        text.text = stack.ToString();
    }
}
