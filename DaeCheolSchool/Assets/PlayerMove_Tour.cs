using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMove_Tour : MonoBehaviour
{
    public static bool istouring;
    private float _moveSpeed = 9f;
    private float _gravity = 6f;
    private float _jumpSpeed = 1.5f;
    public static bool canmove = true;
    public GameObject flashlight;
    public GameObject NormalCanvas;
    public GameObject InterfaceCanvas;
    bool flashlighton;
    public Animation mapanim;
    public bool mapopen;
    public TextMeshProUGUI roomtext;
    public Animation mapwalk;

    private CharacterController _controller;

    private float _directionY;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (istouring == true)
        {
            NormalCanvas.SetActive(false);
            InterfaceCanvas.SetActive(false);
            Map();
            Touring();
        }
        else
        {
            NormalCanvas.SetActive(true);
            InterfaceCanvas.SetActive(true);
        }
    }

    void Touring()
    {
        if (canmove == true)
        {
            if (_controller.isGrounded && _directionY < 0)
            {
                _directionY = 0f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            if (x != 0 || z != 0)
            {
                if (!mapwalk.isPlaying)
                    mapwalk.Play();
            }
            else if (x == 0 && z == 0)
            {
                mapwalk.Stop();
            }

            Vector3 direction = transform.right * x + transform.forward * z;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _moveSpeed = 8f;
            }
            else
            {
                _moveSpeed = 4f;
            }

            _directionY -= _gravity * Time.deltaTime;

            direction.y = _directionY;

            _controller.Move(direction * _moveSpeed * Time.deltaTime);

        }

    }

    void Map()
    {
        if (Input.GetKeyDown(KeyCode.M) && !mapanim.isPlaying)
        {
            switch (mapopen)
            {
                case true:
                    if (!mapanim.isPlaying)
                        mapanim.Play("MapClose");
                    mapopen = false;
                    break;
                case false:
                    if (!mapanim.isPlaying)
                        mapanim.Play("MapOpen");
                    mapopen = true;
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "ZONE/Entrance":
                roomtext.text = "현관";
                break;
            case "ZONE/1FHall":
                roomtext.text = "1층 복도";
                break;
            case "ZONE/ICT":
                roomtext.text = "ICT실";
                break;
            case "ZONE/TechandHouse":
                roomtext.text = "기술가정실";
                break;
            case "ZONE/Stairs":
                roomtext.text = "계단";
                break;
            case "ZONE/Studio":
                roomtext.text = "스튜디오";
                break;
            case "ZONE/Helproom":
                roomtext.text = "학습도움실";
                break;
            case "ZONE/2FHall":
                roomtext.text = "2층 복도";
                break;
            case "ZONE/Class":
                roomtext.text = "교실";
                break;
            case "ZONE/Toilet":
                roomtext.text = "화장실";
                break;
            case "ZONE/MainOffice":
                roomtext.text = "교장수녀님 교실";
                break;
            case "ZONE/TeacherRestroom":
                roomtext.text = "방송실";
                break;
            case "ZONE/DreamClass":
                roomtext.text = "진로실";
                break;
            case "ZONE/3FHall":
                roomtext.text = "3층 복도";
                break;
            case "ZONE/EnglishClass":
                roomtext.text = "영어실";
                break;
            case "ZONE/ScienceClass":
                roomtext.text = "과학실";
                break;
            case "ZONE/Library":
                roomtext.text = "도서관";
                break;
            case "ZONE/songandart":
                roomtext.text = "미술/음악실";
                break;
            case "ZONE/hospital":
                roomtext.text = "보건실";
                break;
            case "ZONE/Weclass":
                roomtext.text = "위클래스실";
                break;
        }
    }
}
