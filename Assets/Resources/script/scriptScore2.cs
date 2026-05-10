using UnityEngine;
using TMPro;
using System;

public class scriptScore2 : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    public goal2 goal2Script;

    void Start()
    {
        if (goal2Script == null)
        {
            goal2Script = GetComponent<goal2>();
        }

        if (scoreText == null)
        {
            scoreText = GetComponent<TextMeshProUGUI>();
        }
    }

    void Update()
    {
        scoreText.text = goal2Script.score.ToString();
    }
}
