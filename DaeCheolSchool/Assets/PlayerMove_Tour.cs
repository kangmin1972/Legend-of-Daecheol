using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
