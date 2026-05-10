using UnityEngine;
using TMPro;
using System;

public class scriptScore1 : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    public goal1 goal1Script;

    void Start()
    {
        if (goal1Script == null)
        {
            goal1Script = GetComponent<goal1>();
        }

        if (scoreText == null)
        {
            scoreText = GetComponent<TextMeshProUGUI>();
        }
    }

    void Update()
    {
        scoreText.text = goal1Script.score.ToString();
    }
}
