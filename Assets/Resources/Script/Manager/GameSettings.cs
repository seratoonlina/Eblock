using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public GameObject loadingScreenSettings;
    void Start()
    {
        loadingScreenSettings.SetActive(false);
    }

}
