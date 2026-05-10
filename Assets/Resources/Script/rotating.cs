using Unity.Mathematics;
using UnityEngine;

public class rotating : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 10f, 0) * 2f * Time.deltaTime);
    }
}
