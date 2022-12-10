using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Narrator Audio", menuName = "Assets/New Narrator Audio")]
public class NarratorAudio : ScriptableObject
{
    public AudioClip clip;
    public string subtitle;
}
