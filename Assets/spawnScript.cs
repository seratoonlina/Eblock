using UnityEngine;

public class spawnScript : MonoBehaviour
{
    public Transform spawnPoint1, spawnPoint2;
    public GameObject prefrabPlayer1, prefrabPlayer2;
    void Awake()
    {
        Instantiate(prefrabPlayer1, spawnPoint1.position, spawnPoint1.rotation);
        Instantiate(prefrabPlayer2, spawnPoint2.position, spawnPoint2.rotation);
    }

}
