using UnityEngine;

public class animControlScript_finalCOOP : MonoBehaviour
{
    float scoreRED;
    float scoreBLUE;
    void Start()
    {
        scoreRED = PlayerPrefs.GetFloat("redScore", 0f);
        scoreBLUE = PlayerPrefs.GetFloat("blueScore", 0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
