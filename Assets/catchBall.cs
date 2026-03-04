using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class catchBall : MonoBehaviour
{
    Rigidbody ball;
    public bool Catched;
    public bool onGoal = false;
    public Transform catchPoint;
    public bool IsHoldingKick = false;
    bool ShootingCoolDown = false;
    public Transform SpawnPoint;

    void Start()
    {
        if (catchPoint == null)
        {
            catchPoint = transform.Find("catchPoint");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null && collision.rigidbody.GetComponent<balls>())
        {
            Rigidbody newBall = collision.rigidbody;
            catchPoint.GetComponent<BoxCollider>().isTrigger = true;

            if (newBall.transform.parent != null)
            {
                newBall.transform.SetParent(null);
                newBall.isKinematic = false;
            }

            ball = newBall;
            ball.transform.SetParent(catchPoint);
            ball.isKinematic = true;
            ball.transform.localPosition = Vector3.zero;
        }
    }


    void Update()
    {
        if (onGoal == true)
        {

            StartCoroutine(ResetTriggers(0.2f));
        
        }
        if (ball.transform.parent == catchPoint)
        {
            Catched = true;
        }
        else
        {
            Catched = false;
        }

        if (Catched == false)
        {
            ball = null;
            StartCoroutine(ResetTriggers(0.4f));
        }
        else if (Catched == true)
        {
            return;
        }

        
    }

    public void OnShoot(InputAction.CallbackContext value)
    {
        if (value.performed && ball != null)
        {
            IsHoldingKick = true;
            shootBall();
        }
    }

    void shootBall()
    {
        if (ball != null && ShootingCoolDown == false)
        {
            catchPoint.GetComponent<BoxCollider>().isTrigger = true;
            ball.transform.SetParent(null);
            ball.isKinematic = false;
            ball.AddForce(catchPoint.forward * 20f, ForceMode.Impulse);
            ball.AddForce(Physics.gravity * -1f, ForceMode.Acceleration);
            Catched = false;
            ball = null;
            ShootingCoolDown = true;

            StartCoroutine(ResetTrigger(2f));
        }
    }

    IEnumerator ResetTrigger(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        ShootingCoolDown = false;

        if (ball == null)
        {
            catchPoint.GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    IEnumerator ResetTriggers(float cooldown)
    {
        ball.isKinematic = false;
        ball.transform.SetParent(null);
        catchPoint.GetComponent<BoxCollider>().isTrigger = false;
        ball.transform.position = SpawnPoint.position;
        yield return new WaitForSeconds(cooldown);
        onGoal = false;


        if (ball == null)
        {
            onGoal = false;
            catchPoint.GetComponent<BoxCollider>().isTrigger = false;
        }
    }

}