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
        if (canmove == true)
        {
            if (_controller.isGrounded && _directionY < 0)
            {
                _directionY = 0f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 direction = transform.right * x + transform.forward * z;

            if (_controller.isGrounded)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    _directionY = _jumpSpeed;
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
}
