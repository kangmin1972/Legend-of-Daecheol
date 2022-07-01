using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private float _moveSpeed = 10f;
    private float _gravity = 6f;
    private float _jumpSpeed = 1.3f;
    public ScreenShake ss;
    public static bool canmove = true;
    public AudioSource footstep;
    public AudioSource hammerhit;
    public AudioSource jump;
    public GameObject hammerspawn;
    public GameObject fakehammer;
    public AudioSource thing;
    bool isMoving;
    public static bool ishammerpowered;

    private managejoystick _mangJoystick;

    private CharacterController _controller;

    private float _directionY;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _mangJoystick = GameObject.Find("joystickbg").GetComponent<managejoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal"); //Keyboard input to determine if player is moving
        float inputY = Input.GetAxis("Vertical");

        //float inputX = _mangJoystick.inputHorizontal();
        //float inputY = _mangJoystick.inputVertical();
        
        if(ishammerpowered == true)
        {
            StartCoroutine(ss.Shake(.15f, .2f));
            hammerhit.Play();
            ishammerpowered = false;
        }

        if (inputX != 0 || inputY != 0)
        {
            isMoving = true;
        }
        else if (inputX == 0 && inputY == 0)
        {
            isMoving = false;
        }

        if (canmove == true)
        {
            if (_controller.isGrounded && _directionY < 0)
            {
                _directionY = 0f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            //float x = _mangJoystick.inputHorizontal();
            //float z = _mangJoystick.inputVertical();

            Vector3 direction = transform.right * x + transform.forward * z;

            if (_controller.isGrounded)
            {
                if (Input.GetButton("Jump"))
                {
                    _directionY = _jumpSpeed;
                    jump.Play();
                }
            }

            _directionY -= _gravity * Time.deltaTime;

            direction.y = _directionY;

            _controller.Move(direction * _moveSpeed * Time.deltaTime);

        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(4);
        }

    }

    public void PlayerJumping()
    {
        if (_controller.isGrounded)
        {
            _directionY = _jumpSpeed;
            jump.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "trigger_gethammer")
        {

            hammerspawn.SetActive(true);
            fakehammer.SetActive(false);
        }
    }
}
