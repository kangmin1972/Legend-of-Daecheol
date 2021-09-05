using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public bool mobilesupport = false;
    public static float mouseSpeed = 5f;
    public Transform playerBody;
    public Camera cam;
    private Touch initTouch = new Touch();
    float xRotation = 0f;

    int leftFingerid, rightFingerid;

    public Transform cameraTransform;

    public float camerasensitivity;

    Vector2 lookInput;
    float cameraPitch;

    float halfScreenWidth;

    void Start()
    {
        switch(mobilesupport)
        {
            case false:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;

            case true:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                leftFingerid = -1;
                rightFingerid = -1;

                halfScreenWidth = Screen.width / 2;
                break;
        }
        
    }
    void Update()
    {
        if (mobilesupport == false)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
        else
        {
            GetTouchInput();

            if (rightFingerid != -1)
            {
                LookAround();
            }
        }
    }

    void GetTouchInput()
    {
        for (int i = 0; i < Input.touchCount; i++) { 
            Touch t = Input.GetTouch(i);

            switch (t.phase)
            {
                case TouchPhase.Began:

                    if (t.position.x < halfScreenWidth && leftFingerid == -1)
                    {
                        leftFingerid = t.fingerId;
                    }
                    else if (t.position.x > halfScreenWidth && rightFingerid == -1) {
                        rightFingerid = t.fingerId;
                    }

                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    if (t.fingerId == leftFingerid)
                    {
                        leftFingerid = -1;
                    }
                    else if (t.fingerId == rightFingerid)
                    {
                        rightFingerid = -1;
                    }
                    break;
                case TouchPhase.Moved:
                    if (t.fingerId == rightFingerid)
                    {
                        lookInput = t.deltaPosition *camerasensitivity * Time.deltaTime;
                    }

                    break;
                case TouchPhase.Stationary:
                    if(t.fingerId == rightFingerid)
                    {
                        lookInput = Vector2.zero;
                    }
                    break;
            }
        }
        
        

    }

    void LookAround()
    {
        cameraPitch = Mathf.Clamp(cameraPitch - lookInput.y, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);

        transform.Rotate(transform.up, lookInput.x);
    }
}
