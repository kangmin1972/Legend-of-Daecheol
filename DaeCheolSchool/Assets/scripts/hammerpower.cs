using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerpower : MonoBehaviour
{
    public GameObject crushed;
    public AudioSource hammerhit;
    public ScreenShake ss;

    public bool iscandestroy = true;

    public float hp = 100f;
    public float test = 0f;

    private void Start()
    {
        iscandestroy = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ShutterShield")
        {
            iscandestroy = false;
        }

        if (other.tag == "weapon" && test == 0f && iscandestroy == true)
        {
            if (usinghammer.ishammerused == true && test == 0f && iscandestroy == true)
            {
                hammercrushed();
            }
        }

        if (other.tag == "tennisbullet" && test == 0f && iscandestroy == true)
        {
            others();
        }
    }

    void hammercrushed()
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

    void others()
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
