using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour
{
    public int second;
    public string nextscene;
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
        yield return new WaitForSeconds(second);
        SceneManager.LoadScene(nextscene);
    }
}
