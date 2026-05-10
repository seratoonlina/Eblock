using Unity.VisualScripting;
using UnityEngine;

public class balls : MonoBehaviour
{
    [Header("Ball References")]
    public Transform Spawn1;
    public Transform Spawn2;
    public Transform LocationBall;

    [Header("Player References")]
    public Transform Player1;
    public Transform Player2;

    [Header("Target References")]
    public GameObject goal1;
    public GameObject goal2;
    void OnTriggerEnter(Collider other)
    {
        bool isGoal = other.gameObject == goal1 || other.gameObject == goal2;
        if (isGoal)
        {
            Player1.position = Spawn1.position;
            Player2.position = Spawn2.position;
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 1f, ForceMode.Impulse);
            transform.position = LocationBall.position;
            transform.SetParent(null);
        }
        else if (other.transform.parent != null &&
                 other.transform.parent.GetComponent<PlayerController>() != null)
        {
            FindAnyObjectByType<catchBall>().shootBall();
        }
    }
}
