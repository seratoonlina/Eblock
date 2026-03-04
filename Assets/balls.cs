using Unity.VisualScripting;
using UnityEngine;

public class balls : MonoBehaviour
{
    public Transform Spawn1;
    public Transform Spawn2;
    public Transform LocationBall;

    public Transform PLayer1;
    public Transform Player2;
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<goal1>() || other.transform.GetComponent<goal2>())
        {
            PLayer1.position = Spawn1.position;
            Player2.position = Spawn2.position;
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 1f, ForceMode.Impulse);
            transform.position = LocationBall.position;
        }
    }
}
