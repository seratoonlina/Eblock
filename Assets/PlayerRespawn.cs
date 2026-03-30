using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 spawnPosition;
    private Quaternion spawnRotation;

    public void SetSpawn(Transform spawnPoint)
    {
        spawnPosition = spawnPoint.position;
        spawnRotation = spawnPoint.rotation;
    }

    public void Respawn()
    {
        transform.position = spawnPosition;
        transform.rotation = spawnRotation;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}