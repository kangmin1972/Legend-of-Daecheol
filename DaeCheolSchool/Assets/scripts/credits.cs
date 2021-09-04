using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(movetostart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator movetostart()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("start");
    }
}
