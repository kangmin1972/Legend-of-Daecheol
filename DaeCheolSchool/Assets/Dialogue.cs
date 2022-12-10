using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    private AudioSource audiosr;
    public static Dialogue instance;
    public TextMeshProUGUI subtitles;
    private State state;

    public NarratorAudio[] Scene1NA;
    public int number;

    private enum State
    {
        None, Welcome
    }

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audiosr = gameObject.AddComponent<AudioSource>();
        state = State.Welcome;
    }

    public void Update()
    {
        switch(state)
        {
            case State.None:
                break;
            case State.Welcome:
                Scene1();
                break;
        }
    }

    public void Talking(NarratorAudio clip)
    {
        if (audiosr.isPlaying)
            audiosr.Stop();

        audiosr.PlayOneShot(clip.clip);
        subtitles.text = clip.subtitle;
    }

    void Scene1()
    {
        int i = 0;
        //state = State.None;
        while (i == 2)
        {
            Talking(Scene1NA[i]);
            if(!audiosr.isPlaying)
            i += 1;
            break;
        }
    }
}
