using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guneffect : MonoBehaviour
{
    public float sec;
    // Start is called before the first frame update
    void Update()
    {
        StartCoroutine(remove());
    }

    IEnumerator remove()
    {
        yield return new WaitForSeconds(sec);
        gameObject.SetActive(false);
    }
}
