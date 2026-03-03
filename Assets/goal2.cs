using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class goal2 : MonoBehaviour
{
    public float score = 0;
    public Transform Spawn;
    Transform balls;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.GetComponent<balls>())
        {
            score += 1;
            balls = other.gameObject.transform; 
            balls.position = Spawn.position;
            StartCoroutine(resetBallPosition(0.2f));
        }
    }

    IEnumerator resetBallPosition(float delay)
    {
        balls.GetComponent<TrailRenderer>().emitting = false;
        yield return new WaitForSeconds(delay);
        balls.GetComponent<TrailRenderer>().emitting = true;
        
    }
}
