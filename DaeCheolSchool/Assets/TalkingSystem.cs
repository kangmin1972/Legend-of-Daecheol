using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingSystem : MonoBehaviour
{
    public NarratorAudio[] narrators;
    public int number;
    // Start is called before the first frame update
    void Update()
    {
        
        Dialogue.instance.Talking(narrators[number]);
    }
}
