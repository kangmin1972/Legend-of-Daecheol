using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionComputer : MonoBehaviour
{

    [Header("System Vars")]
    public GameObject useui;
    public BoxCollider monitortrigger;
    public TextMeshProUGUI Daytext;
    public static int Day = 1;
    public static bool ismonitoron;
    public GameObject MonitorUI;
    public AudioSource ButtonSwitch;
    public AudioSource MonitorTurnon;

    [Header("Messenger")]
    public GameObject NewMessage;
    public static bool ischeckedmessage;
    public GameObject MessagePopup;

    // Start is called before the first frame update
    void Start()
    {
        MessagePopup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ismonitoron = MonitorUI.activeInHierarchy;

        switch(ismonitoron)
        {
            case true:
                Mouse.canlook = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case false:
                Mouse.canlook = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
        }


        //messenger
        switch(ischeckedmessage)
        {
            case true:
                NewMessage.SetActive(false);
                break;
            case false:
                NewMessage.SetActive(true);
                break;
        }

        if (MessagePopup.activeInHierarchy == true)
        {
            ischeckedmessage = true;
        }

        //normalsystem
        switch(Day)
        {
            case 1:
                Daytext.text = "월요일";
                break;
            case 2:
                Daytext.text = "화요일";
                break;
            case 3:
                Daytext.text = "수요일";
                break;
            case 4:
                Daytext.text = "목요일";
                break;
            case 5:
                Daytext.text = "금요일";
                break;
            case 6:
                Daytext.text = "토요일";
                break;
            case 7:
                Daytext.text = "일요일";
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            useui.SetActive(true);
            if (Input.GetKey(KeyCode.F) && MonitorUI.activeInHierarchy == false)
            {
                MonitorTurnon.Play();
                MonitorUI.SetActive(true);
                monitortrigger.enabled = false;
                useui.SetActive(false);
                MonitorUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            useui.SetActive(false);

        }
    }

    public void exitmonitor()
    {
        ButtonSwitch.Play();
        MonitorUI.SetActive(false);
        monitortrigger.enabled = true;
    }

    public void messagebutton()
    {
        ButtonSwitch.Play();
        ischeckedmessage = true;
        if (MessagePopup.activeInHierarchy == false)
        {
            MessagePopup.SetActive(true);
        }
        else
        {
            MessagePopup.SetActive(false);
        }
    }
}
