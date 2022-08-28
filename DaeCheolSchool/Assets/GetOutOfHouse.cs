using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetOutOfHouse : MonoBehaviour
{
    public GameObject uiintract;
    public SpriteRenderer UIUSE;
    public Sprite spriteforui;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MissionComputer.ischeckedmessage == true)
        {
            UIUSE.sprite = spriteforui;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            uiintract.SetActive(true);
            if (Input.GetKey(KeyCode.F) && MissionComputer.ischeckedmessage == true)
            {
                MissionComputer.ischeckedmessage = false;
                uiintract.SetActive(false);
                SceneManager.LoadScene(2);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            uiintract.SetActive(false);
        }
    }
}
