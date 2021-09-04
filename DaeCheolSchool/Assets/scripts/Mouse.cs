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

    float screenWidth = Screen.width;

    private float rotx = 0f;
    private float roty = 0f;
    private Vector3 origRot;

    public float rotSpeed = 0.5f;
    public float dir = -1;

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

                origRot = cam.transform.eulerAngles;
                rotx = origRot.x;
                roty = origRot.y;
                break;
        }
        
    }
    void FixedUpdate()
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
            foreach (Touch touch in Input.touches)
            {
                if (touch.position.x > (screenWidth / 2))
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        initTouch = touch;
                    }
                    else if (touch.phase == TouchPhase.Moved)
                    {
                        float deltaX = initTouch.position.x - touch.position.x;
                        float deltaY = initTouch.position.y - touch.position.y;
                        rotx -= deltaY * Time.deltaTime * rotSpeed * dir;
                        roty += deltaX * Time.deltaTime * rotSpeed * dir;
                        rotx = Mathf.Clamp(rotx, -45f, 45f);
                        playerBody.transform.eulerAngles = new Vector3(rotx, roty, 0f);
                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        initTouch = new Touch();
                    }
                }
            }
        }
    }
}
