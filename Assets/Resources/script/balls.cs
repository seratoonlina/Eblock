  using Unity.VisualScripting;
using UnityEngine;

public class balls : MonoBehaviour
{
    public Transform Spawn1;
    public Transform Spawn2;
    public Transform LocationBall;

    public Transform Player1;
    public Transform Player2;

    void OnTriggerEnter(Collider other)
    {
        // 1. Cek Goal (Ditambah null check agar tidak error saat salah satu null)
        if (other.GetComponent<goal1>() != null || other.GetComponent<goal2>() != null)
        {
            if (Player1 != null && Spawn1 != null) Player1.position = Spawn1.position;
            if (Player2 != null && Spawn2 != null) Player2.position = Spawn2.position;

            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            if (rb != null) rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);

            if (LocationBall != null) transform.position = LocationBall.position;
            transform.SetParent(null);
        }
        // 2. Cek Player (Bagian ini yang paling sering bikin Null Reference)
        
    }
}