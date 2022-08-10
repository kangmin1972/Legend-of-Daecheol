using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftDash : MonoBehaviour
{
    public bool isdash;
    private int trieddash;
    private float starttime;

    PlayerMove playerc;
    CharacterController cc;

    
    // Start is called before the first frame update
    void Start()
    {
        playerc = GetComponent<PlayerMove>();
        cc = GetComponent<CharacterController>();
    }
}
