using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryhehe : MonoBehaviour
{
    public GameObject effect;
    public Rigidbody[] rb;
    public static bool leavingpieces = true;
    bool set1 = false;
    // Start is called before the first frame update
    void Start()
    {
        if (leavingpieces == false)
        {
            StartCoroutine(destoryhaha());
        }
        else
        {
            set1 = true;
        }
        
    }

    private void Update()
    {
        if (leavingpieces == false && set1 == true)
        {
            Destroy(gameObject);
        }
        else if (leavingpieces == true)
        {
            StopAllCoroutines();
            set1 = true;
        }
    }

    IEnumerator destoryhaha()
    {
        yield return new WaitForSeconds(6);
        Destroy(gameObject);
    }
}
