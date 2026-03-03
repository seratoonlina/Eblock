using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class catchBall : MonoBehaviour
{
    Rigidbody ball;
    public bool Catched;
    public Transform catchPoint;
    public bool IsHoldingKick = false;
    public bool isGoal;

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

            if (newBall.transform.parent != null)
            {
                newBall.transform.SetParent(null);
                newBall.isKinematic = false;
            }

            catchPoint.GetComponent<BoxCollider>().isTrigger = true;

            ball = newBall;
            ball.transform.SetParent(catchPoint);
            ball.isKinematic = true;
            ball.transform.localPosition = Vector3.zero;
        }
    }


    void Update()
    {
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

        if (isGoal == true)
        {
            ball = null;
            StartCoroutine(ResetTriggers(0.4f));
        }
    }

    public void OnShoot(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            IsHoldingKick = true;
            shootBall();
        }

        if (value.canceled)
        {
            IsHoldingKick = false;
        }
    }

    void shootBall()
    {
        if (ball != null)
        {
            catchPoint.GetComponent<BoxCollider>().isTrigger = true;

            ball.transform.SetParent(null);
            ball.isKinematic = false;
            ball.AddForce(catchPoint.forward * 2.7f, ForceMode.Impulse);
            ball.AddForce(Physics.gravity * -1f, ForceMode.Acceleration);

            ball = null;

            StartCoroutine(ResetTrigger(0.4f));
        }
        if (ball == null)
        {
            StartCoroutine(ResetTriggers(0.4f));
        }
    }

    IEnumerator ResetTrigger(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);

        if (ball == null)
        {
            catchPoint.GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    IEnumerator ResetTriggers(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);

        if (ball == null)
        {
            catchPoint.GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    IEnumerator ResetTriggerss(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);

        if (ball == null)
        {
            catchPoint.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}