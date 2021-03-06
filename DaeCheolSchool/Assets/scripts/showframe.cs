using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class showframe : MonoBehaviour
{
    public float timer, refresh, avgFramerate;
    public string display = "{0} FPS";
    public TextMeshProUGUI m_Text;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(framerate());
    }

    // Update is called once per frame
    IEnumerator framerate()
    {
        yield return new WaitForSeconds(1);
        float timelapse = Time.smoothDeltaTime;
        timer = timer <= 0 ? refresh : timer -= timelapse;

        if (timer <= 0) avgFramerate = (int)(1f / timelapse);
        m_Text.text = string.Format(display, avgFramerate.ToString());
        StartCoroutine(framerate());
    }
}
