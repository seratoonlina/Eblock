using System.Collections;
using TMPro;
using UnityEngine;

public class goal1 : MonoBehaviour
{
    public float score = 0;
    Transform balls;
    public catchBall onGoals;
    public catchBall onGoalss;
    public Transform Spawn;

    void OnTriggerEnter(Collider other)
    {
        balls ballScript = other.GetComponent<balls>();

        if (ballScript != null)
        {
            score += 1;

            balls = other.transform;
            balls.position = Spawn.position;

            StartCoroutine(resetBallPosition(0.05f));
        }
    }

    IEnumerator resetBallPosition(float delay)
    {
        if (balls == null) yield break;

        onGoals.onGoal = true;
        onGoalss.onGoal = true;

        TrailRenderer trail = balls.GetComponent<TrailRenderer>();
        if (trail != null)
            trail.emitting = false;

        balls.SetParent(null);

        Rigidbody rb = balls.GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = false;

        yield return new WaitForSeconds(delay);

        onGoals.onGoal = false;
        onGoalss.onGoal = false;

        if (trail != null)
            trail.emitting = true;

        balls = null;
    }
}


