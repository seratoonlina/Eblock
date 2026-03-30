using UnityEngine;
using UnityEngine.AI;

public class bot : MonoBehaviour
{
    public NavMeshAgent agents;
    public GameObject balls;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agents.SetDestination(balls.transform.position);
    }
}
