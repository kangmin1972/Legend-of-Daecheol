using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dangerintro : MonoBehaviour
{
    public GameObject DMS;
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
        yield return new WaitForSeconds(11);
        DMS.SetActive(true);
        gameObject.SetActive(false);
    }
}
