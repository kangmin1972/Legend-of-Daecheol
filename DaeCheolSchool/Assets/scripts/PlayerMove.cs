using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform debugHitPointTransform;
    [SerializeField] private Transform hookshotTransform;
    private float _moveSpeed = 14f;
    public float stamina = 1f;
    public Image staminabar;
    private float _gravity = 6f;
    private float _jumpSpeed = 1.2f;
    public ScreenShake ss;
    public static bool canmove = true;
    private Vector3 characterVelocityMomentum;
    public AudioSource footstep;
    public AudioSource hammerhit;
    public LayerMask ignorethis;
    public AudioSource jump;
    public GameObject hammerspawn;
    public ParticleSystem dashparti;
    public GameObject dasheffectgo;
    public GameObject fakehammer;
    public AudioSource thing;
    bool isMoving;
    public static bool ishammerpowered;
    public Camera playercamera;
    private float characterVelocityY;
    public Vector3 movementVector = Vector3.zero;
    private Vector3 hookshotPosition;
    public Vector3 InputVector = Vector3.zero;
    private State state;
    private float hookshotsize;
    public AudioSource hookfinish;
    public AudioSource hookfire;
    public bool isdashing;
    public Mouse cam;
    public AudioSource dashsfx;
    private float dashstarttime;
    public bool bunnyhobbool;
    public Animation headbob;
    public Animation JumpAnim;
    bool jumped;

    [SerializeField] ParticleSystem forwarddash;
    [SerializeField] ParticleSystem backwarddash;
    [SerializeField] ParticleSystem leftdash;
    [SerializeField] ParticleSystem rightdash;


    private enum State
    {
        Normal, HookshotFlyingPlayer, HookshotThrown
    }
    
    private managejoystick _mangJoystick;

    private CharacterController _controller;

    private float _directionY;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Normal;
        hookshotTransform.gameObject.SetActive(false);
        _controller = GetComponent<CharacterController>();
        _mangJoystick = GameObject.Find("joystickbg").GetComponent<managejoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            default:
            case State.Normal:
                playermoving();
                Dash();
                HandleDash();
                HandleHookshotStart();
                break;
            case State.HookshotThrown:
                HandleHookshotThrow();
                playermoving();
                break;
            case State.HookshotFlyingPlayer:
                HandleHookshotMovement();
                break;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(4);
        }

    }

    public void playermoving()
    {
        float inputX = Input.GetAxis("Horizontal"); //Keyboard input to determine if player is moving
        float inputY = Input.GetAxis("Vertical");

        //float inputX = _mangJoystick.inputHorizontal();
        //float inputY = _mangJoystick.inputVertical();

        movementVector = Vector3.ClampMagnitude(transform.right * inputX + transform.forward * inputY, 1.0f);

        if (ishammerpowered == true)
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

            InputVector.x = Input.GetAxis("Horizontal");
            InputVector.z = Input.GetAxis("Vertical");

            //float x = _mangJoystick.inputHorizontal();
            //float z = _mangJoystick.inputVertical();

            Vector3 direction = transform.right * x + transform.forward * z;

            if (_controller.isGrounded)
            {
                if (jumped == true)
                {
                    jumped = false;
                    //JumpAnim.Play();
                }
                if (TestInputJump())
                {
                    bunnyhobbool = true;
                    jumped = true;
                    _directionY = _jumpSpeed;
                    jump.Play();
                }
            }
            else
            {
                jumped = true;
            }

            _directionY -= _gravity * Time.deltaTime;

            direction.y = _directionY;

            direction += characterVelocityMomentum;

            _controller.Move(direction * _moveSpeed * Time.deltaTime);

            if(stamina < 1)
            {
                stamina += 0.005f;
            }

            staminabar.fillAmount = stamina;


            if (isMoving == true && _controller.isGrounded)
            {
                if (!footstep.isPlaying)
                {
                    footstep.Play();
                }

                if (!headbob.isPlaying)
                {
                    headbob.Play("weaponsheadbob");
                }
            }
            else
            {
                headbob.Stop("weaponsheadbob");
                footstep.Stop();
            }

            if (characterVelocityMomentum.magnitude >= 0f)
            {
                float momentumDrag = 3f;
                characterVelocityMomentum -= characterVelocityMomentum * momentumDrag * Time.deltaTime;
                if (characterVelocityMomentum.magnitude < .0f)
                {
                    characterVelocityMomentum = Vector3.zero;
                }
            }

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "trigger_gethammer")
        {

            hammerspawn.SetActive(true);
            fakehammer.SetActive(false);
        }
    }

    void HandleDash()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift) && (stamina >= 0.3f))
        {
            dashsfx.Play();
            DashParticle();
            isdashing = true;
            dashstarttime = Time.time;
        }
    }

    void DashParticle()
    {
        if (InputVector.z > 0 && Mathf.Abs(InputVector.x) <= InputVector.z)
        {
            forwarddash.Play();
            return;
        }

        if (InputVector.z < 0 && Mathf.Abs(InputVector.x) <= InputVector.z)
        {
            backwarddash.Play();
            return;
        }

        if(InputVector.x > 0)
        {
            rightdash.Play();
            return;
        }

        if (InputVector.x < 0)
        {
            leftdash.Play();
            return;
        }

        forwarddash.Play();
    }

    void Dash()
    {
        if(isdashing == true)
        {
            if (Time.time - dashstarttime <= 0.1f)
            {
                if (movementVector.Equals(Vector3.zero))
                {
                    stamina -= 0.05f;
                    _controller.Move(transform.forward * 45f * Time.deltaTime);
                }
                else
                {
                    stamina -= 0.05f;
                    _controller.Move(movementVector.normalized * 45f * Time.deltaTime);
                }
            }
        }
    }

    private void HandleHookshotStart()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(Physics.Raycast(playercamera.transform.position, playercamera.transform.forward, out RaycastHit raycastHit, Mathf.Infinity,~ignorethis))
            {
                hookfire.Play();
                hookshotsize = 0f;
                hookshotTransform.gameObject.SetActive(true);
                debugHitPointTransform.position = raycastHit.point;
                hookshotPosition = raycastHit.point;
                hookshotTransform.localScale = Vector3.zero;
                state = State.HookshotThrown;
            }
        }
    }

    private void HandleHookshotThrow()
    {
        hookshotTransform.LookAt(hookshotPosition);

        float hookshotThrowSpeed = 200f;
        hookshotsize += hookshotThrowSpeed * Time.deltaTime;
        hookshotTransform.localScale = new Vector3(0.1f, 0.1f, hookshotsize);

        if(hookshotsize >= Vector3.Distance(transform.position, hookshotPosition))
        {
            state = State.HookshotFlyingPlayer;
            hookfinish.Play();
        }
    }

    private void HandleHookshotMovement()
    {
        hookshotTransform.LookAt(hookshotPosition);
        Vector3 hookshotDir = (hookshotPosition - transform.position).normalized;
        float hookshotSpeedMin = 40f;
        float hookshotSpeedMax = 60f;
        float hookshotSpeed = Mathf.Clamp(Vector3.Distance(transform.position, hookshotPosition), hookshotSpeedMin, hookshotSpeedMax);
        float hookshotSpeedMultiplier = 2f;

        if (hookshotsize > 0)
        {
            StartCoroutine(ss.Shake(.05f, .15f));
            hookshotsize -= hookshotSpeed * hookshotSpeedMultiplier * Time.deltaTime;
            hookshotTransform.localScale = new Vector3(0.1f, 0.1f, hookshotsize);
        }
        else
        {
            StopHookShot();
        }
        _controller.Move(hookshotDir * hookshotSpeed * hookshotSpeedMultiplier * Time.deltaTime);

        float reachedHookshotPositionDistance = 2f;
        if(Vector3.Distance(transform.position, hookshotPosition) < reachedHookshotPositionDistance)
        {
            StopHookShot();
        }

        if(TestInputDownHookshot())
        {
            state = State.Normal;
            StopHookShot();
        }
    }

    private void StopHookShot()
    {
        state = State.Normal;
        _directionY = 0f;
        hookshotTransform.gameObject.SetActive(false);
    }

    private bool TestInputDownHookshot ()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    private bool TestInputJump()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
