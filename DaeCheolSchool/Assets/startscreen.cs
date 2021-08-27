using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startscreen : MonoBehaviour
{
    // Start is called before the first frame update
    public void startbutton()
    {
        SceneManager.LoadScene("gametips");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
