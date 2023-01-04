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
    public GameObject moreinfo;

    private CharacterController _controller;

    private float _directionY;

    public TextMeshProUGUI classname;
    public TextMeshProUGUI classinfo;

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
                moreinfo.SetActive(false);
                break;
            case "ZONE/1FHall":
                roomtext.text = "1층 복도";
                moreinfo.SetActive(false);
                break;
            case "ZONE/ICT":
                roomtext.text = "ICT실";
                moreinfo.SetActive(true);
                classname.text = "ICT실";
                classinfo.text = "ICT실은 노트북을 사용할 수 있는 교실입니다. 주로 여기서 노트북을 이용한 수업을 하고, 수행평가도 가끔 이 곳에서 합니다.";
                break;
            case "ZONE/TechandHouse":
                roomtext.text = "기술가정실";
                moreinfo.SetActive(true);
                classname.text = "기술가정실";
                classinfo.text = "기술가정실은 기술가정이라는 과목을 공부하는 교실입니다. 기술가정 선생님께서 학생들을 가르치십니다.";
                break;
            case "ZONE/Stairs":
                roomtext.text = "계단";
                moreinfo.SetActive(false);
                break;
            case "ZONE/Studio":
                roomtext.text = "스튜디오";
                moreinfo.SetActive(true);
                classname.text = "스튜디오";
                classinfo.text = "스튜디오는 방송부가 이용하거나, 아니면 학생들이 기타 과목을 공부하는 곳입니다. 주로 방송과 관련된 장치들이 많이 있습니다.";
                break;
            case "ZONE/Helproom":
                roomtext.text = "학습도움실";
                moreinfo.SetActive(true);
                classname.text = "학습도움실";
                classinfo.text = "학습도움실은 학습에 도움이 필요한 학생들을 위한 교실입니다.";
                break;
            case "ZONE/2FHall":
                roomtext.text = "2층 복도";
                moreinfo.SetActive(false);
                break;
            case "ZONE/Class":
                roomtext.text = "교실";
                moreinfo.SetActive(true);
                classname.text = "교실";
                classinfo.text = "학생들이 수업하는 곳 중 하나입니다.";
                break;
            case "ZONE/Toilet":
                roomtext.text = "화장실";
                moreinfo.SetActive(true);
                classname.text = "화장실";
                classinfo.text = "네, 화장실입니다.";
                break;
            case "ZONE/MainOffice":
                roomtext.text = "교장실";
                moreinfo.SetActive(true);
                classname.text = "교장실";
                classinfo.text = "교장실은 교장수녀님께서 근무하시는 곳입니다. 이곳에서 수녀님을 뵐 수 있습니다.";
                break;
            case "ZONE/TeacherRestroom":
                roomtext.text = "방송실";
                moreinfo.SetActive(true);
                classname.text = "방송실";
                classinfo.text = "방송실은 방송부 학생들이 모여서 일하는 곳이자, 선생님들께서 휴식을 하시는 공간입니다.";
                break;
            case "ZONE/DreamClass":
                roomtext.text = "진로실";
                moreinfo.SetActive(true);
                classname.text = "진로실";
                classinfo.text = "진로실은 진로와 관련된 수업을 하는 곳입니다. 학생 진로에 관한 여러 얘기를 들을 수 있습니다.";
                break;
            case "ZONE/3FHall":
                roomtext.text = "3층 복도";
                moreinfo.SetActive(false);
                break;
            case "ZONE/EnglishClass":
                roomtext.text = "영어실";
                moreinfo.SetActive(true);
                classname.text = "영어실";
                classinfo.text = "영어실은 영어 과목을 공부하는 곳입니다. 각 영어 선생님들께서 영어를 가르쳐 주십니다.";
                break;
            case "ZONE/ScienceClass":
                roomtext.text = "과학실";
                moreinfo.SetActive(true);
                classname.text = "과학실";
                classinfo.text = "과학실은 과학 과목을 공부하거나, 과학 실험을 하는 곳입니다.";
                break;
            case "ZONE/Library":
                roomtext.text = "도서관";
                moreinfo.SetActive(true);
                classname.text = "도서관";
                classinfo.text = "도서관은 책을 읽거나 도덕 과목을 수업하는 곳입니다. 학생들은 편하게 책을 읽을 수 있고, 뒤에 편안한 공간과 쿠션도 있습니다.";
                break;
            case "ZONE/songandart":
                roomtext.text = "미술/음악실";
                moreinfo.SetActive(true);
                classname.text = "미술/음악실";
                classinfo.text = "미술/음악실은 미술이나 음악 과목을 수업하는 곳입니다. 미술이나 음악에 관련된 물품들이 싹 다 준비되어 있습니다.";
                break;
            case "ZONE/hospital":
                roomtext.text = "보건실";
                moreinfo.SetActive(true);
                classname.text = "보건실";
                classinfo.text = "보건실은 다치거나 아픈 학생들을 위한 곳입니다. 학생들은 주로 여기서 치료를 받습니다.";
                break;
            case "ZONE/Weclass":
                roomtext.text = "위클래스실";
                moreinfo.SetActive(true);
                classname.text = "위클래스실";
                classinfo.text = "위클래스실은 학생이 담당 선생님과 상담하는 곳입니다.";
                break;
            case "ZONE/DU":
                roomtext.text = "매점";
                moreinfo.SetActive(true);
                classname.text = "매점";
                classinfo.text = "이곳은 매점입니다! 혹은 DU로도 불려요. 배고픈 학생들을 위한 많은 간식들이 준비되어 있습니다.";
                break;
            case "ZONE/ecoroom":
                roomtext.text = "에코룸";
                moreinfo.SetActive(true);
                classname.text = "에코룸";
                classinfo.text = "에코룸은 선생님이나 학생들이 회의를 하거나, 각종 정보들을 나누는 곳입니다. 대위원회를 하는데 주로 사용됩니다.";
                break;
        }
    }
}
