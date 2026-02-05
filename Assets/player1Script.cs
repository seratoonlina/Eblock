
using UnityEngine;
using UnityEngine.InputSystem;

public class player1Script : MonoBehaviour
{
    private Player1 player1;
    Vector2 controllers;
    public Rigidbody controlllerPlayer1;
    bool running = false;
    public float speed = 3.5f;
    float hitForce = 2f;
    Rigidbody rbBall;
    Vector3 arah;
    Collision collisionBall;
    void Start()
    {
    }

    private void Awake()
    {
        player1 = new Player1();
        player1.PlayerMovement.movement.performed += ctx => controllers = ctx.ReadValue<Vector2>();
        player1.PlayerMovement.movement.canceled += ctx => controllers = Vector2.zero;
        player1.PlayerMovement.RUN.performed += ctx => running = true;
        player1.PlayerMovement.RUN.canceled += ctx => running = false;
    }

    private void OnEnable()
    {
        player1.Enable();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.right * controllers.x + transform.forward * controllers.y;
        Vector3 moveRigid = controlllerPlayer1.position + move * speed * Time.deltaTime;
        controlllerPlayer1.MovePosition(moveRigid);

        if (rbBall != null && Input.GetKeyDown(KeyCode.E))
        {
            arah = collisionBall.contacts[0].normal * -1;
            rbBall.AddForce(arah * hitForce, ForceMode.Impulse);
        }

        if (running == true)
        {
            speed = 6f;
        }
        else
        {
            speed = 3.5f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ball")
        {
                rbBall = collision.gameObject.GetComponent<Rigidbody>();
                collisionBall = collision;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "ball")
        {
            rbBall = null;
            collisionBall = null;
        }
    }


}
