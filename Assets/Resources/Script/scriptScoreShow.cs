using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class scriptScoreShow : MonoBehaviour
{
    public float redS;
    public float blues;

    public TextMeshProUGUI red;
    public TextMeshProUGUI blue;

    public TextMeshProUGUI redL;
    public TextMeshProUGUI blueL;

    public void Start()
    {
        redS = PlayerPrefs.GetFloat("redScore",0f);
        blues = PlayerPrefs.GetFloat("blueScore",0f);

        red.text = redS.ToString();
        blue.text = blues.ToString();

        redL.text = redS.ToString();
        blueL.text = blues.ToString();
    }
}
