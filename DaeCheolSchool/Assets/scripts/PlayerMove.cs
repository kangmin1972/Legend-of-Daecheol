using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private float _moveSpeed = 5f;
    private float _gravity = 6f;
    private float _jumpSpeed = 1.5f;
    public static bool canmove = true;
    public AudioSource footstep;
    public AudioSource jump;
    bool isMoving;

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
        //float inputX = Input.GetAxis("Horizontal"); //Keyboard input to determine if player is moving
        //float inputY = Input.GetAxis("Vertical");

        float inputX = _mangJoystick.inputHorizontal();
        float inputY = _mangJoystick.inputVertical();

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

            //float x = Input.GetAxis("Horizontal");
            //float z = Input.GetAxis("Vertical");

            float x = _mangJoystick.inputHorizontal();
            float z = _mangJoystick.inputVertical();

            Vector3 direction = transform.right * x + transform.forward * z;

            if (_controller.isGrounded)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    _directionY = _jumpSpeed;
                    jump.Play();
                }
            }

            if (isMoving == true && _controller.isGrounded)
            {
                if (!footstep.isPlaying)
                {
                    footstep.Play();
                }
            }
            else
            {
                footstep.Stop();
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
}
