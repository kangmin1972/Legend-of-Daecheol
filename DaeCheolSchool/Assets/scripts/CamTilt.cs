using UnityEngine;
using System.Collections;

public class CamTilt : MonoBehaviour
{

    //Editor variables, you can customize these
    public float _tiltAmount = 5;
    public KeyCode _leftBtn = KeyCode.A; //A is default
    public KeyCode _rightBtn = KeyCode.D; //D is default

    // Update is called once per frame
    void Update()
    {

        // If _leftBtn key is hit, rotate Z axis of camera by _tiltAmount
        if (Input.GetKeyDown(_leftBtn))
        {
            transform.Rotate(0, 0, _tiltAmount);
        }
        else if (Input.GetKeyUp(_leftBtn))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        // Same as above, but inverted values
        if (Input.GetKeyDown(_rightBtn))
        {
            transform.Rotate(0, 0, -_tiltAmount);
        }
        else if (Input.GetKeyUp(_rightBtn))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}