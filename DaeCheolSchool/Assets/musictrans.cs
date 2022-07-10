using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musictrans : MonoBehaviour
{
    public AudioSource normal;
    public AudioSource combat;
    public static bool iscombat;
    public static bool test = true;
    // Start is called before the first frame update
    void Start()
    {
        normal.volume = 0.89f;
        combat.volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(iscombat == true && test == true)
        {
            StopAllCoroutines();
            StartCoroutine(getpsyched());
            test = false;
        }
        if (iscombat == true)
        {
            normal.volume -= 0.01f;
            combat.volume += 0.01f;
        }
        else
        {
            normal.volume += 0.01f;
            combat.volume -= 0.01f;
            test = true;
        }
    }

    IEnumerator getpsyched()
    {
        yield return new WaitForSeconds(3);
        iscombat = false;
    }
}
