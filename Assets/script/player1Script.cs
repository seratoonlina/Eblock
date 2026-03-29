
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class player1Script : MonoBehaviour
{
    public ParticleSystem effect1;
    public ParticleSystem effect2;
    Vector2 controllers;
    Vector2 rotateInput;
    public Rigidbody controlllerPlayer1;
    bool running;
    public float speed = 3.5f;
    float hitForce = 2f;
    Rigidbody rbBall;
    Vector3 arah;
    public catchBall GetBall;
    

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



    public void OnRun(InputAction.CallbackContext context)
    {
        running = context.performed;
    }

    public void shootBall()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(controllers.x, 0f, controllers.y);
        controlllerPlayer1.MovePosition(controlllerPlayer1.position + direction * speed * Time.deltaTime);

        if (direction.magnitude > 0.1f)
        {
            Quaternion rotationss = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationss, 20f * Time.deltaTime);
        }

        if (running && GetBall.Catched == true)
        {
            effectPlay();
            speed = 5f;
        }
        else if (running && GetBall.Catched == false)
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
