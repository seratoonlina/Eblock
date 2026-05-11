using UnityEngine;

public class closeLOADING : MonoBehaviour
{
    public GameObject openingGameCoop;
    void Start()
    {
        openingGameCoop.GetComponent<Animation>().Play();
    }

    public void ready()
    {
        openingGameCoop.SetActive(false);
    }
}
