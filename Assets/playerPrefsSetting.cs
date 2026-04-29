using UnityEngine;

public class playerPrefsSetting : MonoBehaviour
{
    
    void Start()
    {
        PlayerPrefs.SetFloat("redScore", 0);
        PlayerPrefs.SetFloat("blueScore", 0);
    }

    
}
