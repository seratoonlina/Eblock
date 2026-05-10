using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonScript : MonoBehaviour
{
    public GameObject play;
    public GameObject exit;
    public GameObject credit;
    public GameObject loadingScreenEnable;
    public Animator loadingScreens;
    public void PlayButton(int SceneIndex)
    {
        play.GetComponent<Button>().enabled = false;
        exit.GetComponent<Button>().enabled = false;
        credit.GetComponent<Button>().enabled = false;

        loadingScreenEnable.SetActive(true);
        loadingScreens.SetTrigger("play");
    }

    public void CreditButton()
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
