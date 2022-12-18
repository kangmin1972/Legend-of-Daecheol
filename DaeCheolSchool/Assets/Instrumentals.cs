using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrumentals : MonoBehaviour
{
    public AudioSource[] samples;
    public int x;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "weapon")
        {
            if (usinghammer.ishammerused == true)
            {
                SamplePlay();
            }
        }

        if (other.tag == "tennisbullet")
        {
            SamplePlay();
        }
    }

    void SamplePlay()
    {
        x = Random.Range(0, samples.Length);
        samples[x].Play();
    }
}
