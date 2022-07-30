using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerpower : MonoBehaviour
{
    public GameObject crushed;
    public AudioSource hammerhit;
    public ScreenShake ss;
    public float test = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "weapon" && test == 0f)
        {
            if (usinghammer.ishammerused == true && test == 0f)
            {
                musictrans.iscombat = true;
                PlayerMove.ishammerpowered = true;
                musictrans.test = true;
                Destroy(gameObject);
                hammerhit.pitch = Random.Range(0.5f, 1.5f);
                hammerhit.Play();
                crushedstack.stack += 1;
                test = 1f;
                Vector3 oldPos = transform.position;
                Instantiate(crushed, oldPos, Quaternion.identity);
                Destroy(gameObject);
            }
        }

        if (other.tag == "tennisbullet" && test == 0f)
        {
                musictrans.iscombat = true;
                musictrans.test = true;
                Destroy(gameObject);
                hammerhit.pitch = Random.Range(0.5f, 1.5f);
                hammerhit.Play();
                crushedstack.stack += 1;
                test = 1f;
                Vector3 oldPos = transform.position;
                Instantiate(crushed, oldPos, Quaternion.identity);
                Destroy(gameObject);
        }
    }
}
