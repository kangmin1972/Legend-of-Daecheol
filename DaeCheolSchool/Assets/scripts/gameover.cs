using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    public TextMeshProUGUI timered;
    // Start is called before the first frame update
    void Start()
    {
        TimeSpan time = TimeSpan.FromSeconds(timer.currentTime);
        timered.text = time.ToString(@"mm\:ss\:fff");

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    public void restart()
    {
        SceneManager.LoadScene(2);
    }

    public void main()
    {
        SceneManager.LoadScene(1);   
    }
}
