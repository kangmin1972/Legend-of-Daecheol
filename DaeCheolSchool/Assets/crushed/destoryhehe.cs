using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryhehe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destoryhaha());
    }

    IEnumerator destoryhaha()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
