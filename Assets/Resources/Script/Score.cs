using UnityEngine;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    public PlayerController player;

    void Start()
    {
        if (scoreText == null)
            scoreText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (player != null)
            scoreText.text = player.score.ToString();
    }
}
