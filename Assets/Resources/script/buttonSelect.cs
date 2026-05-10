using UnityEngine;
using UnityEngine.UI;

public class buttonSelect : MonoBehaviour
{
    public Button button1;
    public GameObject nextButton;
    public GameObject nextButton2;
    public GameObject tutorialFirst;
    public GameObject tutorialFirst2;
    public GameObject loadingAnimation;
    void Start()
    {
        button1.Select();
        nextButton.SetActive(false);
    }


    
    void Update()
    {
        if (tutorialFirst.activeSelf)
        {
            button1.enabled = false;
            nextButton.SetActive(true);
            nextButton.GetComponent<Button>().Select();
        }
        if (tutorialFirst2.activeSelf)
        {
            tutorialFirst.SetActive(false);
            nextButton.SetActive(false);
            nextButton2.SetActive(true);
            nextButton2.GetComponent<Button>().Select();
        }
        if (loadingAnimation.activeSelf)
        {
            tutorialFirst.SetActive(false);
            nextButton.SetActive(false);
            nextButton2.SetActive(false);
        }
    }
}
