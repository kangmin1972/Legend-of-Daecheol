using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryhehe : MonoBehaviour
{
    public GameObject effect;
    public Rigidbody[] rb;
    // Start is called before the first frame update
    void Start()
    {
        if (startscreen.isleavingpieces == 2)
        {
            StartCoroutine(destoryhaha());
        }
        
    }

    IEnumerator destoryhaha()
    {
        yield return new WaitForSeconds(6);
        Destroy(effect);
    }
}
