
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerController : MonoBehaviour
{

    [Header("References")]
    public CharacterController controller;
    public Transform cam;  // 3D TPV mode
    public LayerMask groundMask;
    public Transform groundCheck;
    public ParticleSystem effect1;
    public ParticleSystem effect2;
    public catchBall GetBall;
    public float controllerIndex;
    public Animator Anim;

    Vector2 controllers;
    Vector2 rotateInput;
    bool isRunning;

    [Header("Controller")]
    public float speed = 5f;
    public float turnsmoothTime = 0.1f;
    float turnSmoothVelocity;
    // scoring
    public float score = 0;
    float hitForce = 2f;
    public Vector3 moveDir;
    // jump
    public float gravity = -9.81f;
    public float jumpHeight = 20f;

    Vector3 velocity;
    bool isGrounded;
    public float groundDistance = 0.2f;

    
    Rigidbody rbBall;
    Vector3 arah;

    void Start()
    {
        if (GetBall == null)
        {
            GetBall = GetComponent<catchBall>();
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        controllers = context.ReadValue<Vector2>();
        Debug.Log("control" + controllers);
    }

    public void SetControllerIndex(float controllerindex)
    {
        controllerIndex = controllerindex;
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        isRunning = context.performed;
    }

    // Update is called once per frame
    void Update()
    {
        // Check Ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        float horizontal = controllers.x;
        float vertical = controllers.y;
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnsmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        // Jump
        if (Input.GetKey(KeyCode.Space) && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        // Apply Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (isRunning && GetBall.Catched == true)
        {
            effectPlay();
            speed = 5f;
        }
        else if (isRunning && GetBall.Catched == false)
        {
            effectPlay();
            speed = 7f;
        }
        else
        {
            effectStop();
            speed = 3f;
        }
    }

    void effectPlay()
    {
        effect1.Play();
        effect2.Play();   
    }
    void effectStop()
    {
        effect1.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        effect2.Stop(true, ParticleSystemStopBehavior.StopEmitting);   
    }
}
