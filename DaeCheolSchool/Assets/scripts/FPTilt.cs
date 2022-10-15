using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPTilt : MonoBehaviour
{
    public float _tiltAmount = 5;
    public KeyCode _leftBtn = KeyCode.A;
    public KeyCode _rightBtn = KeyCode.D;
    public float _rotationSpeed = 1;
    private Quaternion _initialRotation;
    private Quaternion _targetRotation;

    void Start()
    {
        _initialRotation = _targetRotation = transform.rotation;
    }

    void Update()
    {

        if (Input.GetKeyDown(_leftBtn))
        {
            _targetRotation = Quaternion.Euler(0, 0, _tiltAmount) * _initialRotation;
        }
        else if (Input.GetKeyUp(_leftBtn))
        {
            _targetRotation = _initialRotation;
        }

        if (Input.GetKeyDown(_rightBtn))
        {
            _targetRotation = Quaternion.Euler(0, 0, -_tiltAmount) * _initialRotation;
        }
        else if (Input.GetKeyUp(_rightBtn))
        {
            _targetRotation = _initialRotation;
        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
    }
}
