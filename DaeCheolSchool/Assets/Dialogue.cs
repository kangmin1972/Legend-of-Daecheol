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
                StartCoroutine(Scene1());
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

    IEnumerator Scene1()
    {
        state = State.None;
        yield return new WaitForSeconds(1f);
        Talking(Scene1NA[0]);
        yield return new WaitForSeconds(4.2f);
        Talking(Scene1NA[1]);
        yield return new WaitForSeconds(3.5f);
        Talking(Scene1NA[2]);
        yield return new WaitForSeconds(2.8f);
        Talking(Scene1NA[3]);
        yield return new WaitForSeconds(4.9f);
        Talking(Scene1NA[4]);
        yield return new WaitForSeconds(5.3f);
        subtitles.text = "";
    }
}
