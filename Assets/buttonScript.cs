using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonScript : MonoBehaviour
{
    public GameObject btn1s;
    public GameObject btn2s;
    public GameObject btn3s;
    public GameObject loadingScreenEnable;
    public Animator loadingScreens;
    public void PlayButton(int SceneIndex)
    {
        btn1s.GetComponent<Button>().enabled = false;
        btn2s.GetComponent<Button>().enabled = false;
        btn3s.GetComponent<Button>().enabled = false;

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
