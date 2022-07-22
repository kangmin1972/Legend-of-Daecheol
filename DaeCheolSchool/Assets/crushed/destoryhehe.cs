using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryhehe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (startscreen.isleavingpieces == 2)
        {
            //StartCoroutine(destoryhaha());
        }
        
    }

    IEnumerator destoryhaha()
    {
        yield return new WaitForSeconds(15);
        Destroy(gameObject);
    }
}
