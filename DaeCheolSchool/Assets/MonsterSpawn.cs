using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public Animator shutter;
    public GameObject trigger1;
    public ScreenShake ss;
    public float timer;
    public AudioSource shuttersfx;

    public static bool combating;
    // Start is called before the first frame update
    void Start()
    {
        shutter.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 0.01f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CLASS/kingclass")
        {
            closeshutter();
        }
    }

    void closeshutter()
    {
        combating = true;
        musictrans.iscombat = true;
        shuttersfx.Play();
        shutter.speed = 1;
        StartCoroutine(ss.Shake(.5f, .2f));
        shutter.Play("shutter");
        trigger1.SetActive(false);
        shutter.speed = 1;
    }
}
