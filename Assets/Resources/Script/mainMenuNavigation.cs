using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenuNavigation : MonoBehaviour
{
    [Header("Buttons")]
    public GameObject play;
    public GameObject exit;
    public GameObject credit;
    
    [Header("Menu")]
    public GameObject mainMenu;
    public GameObject playMenu;
    public GameObject optionMenu;
    public GameObject creditMenu;
    
    [Header("Loading Scene")]
    public GameObject loadingScreenEnable;
    public Animator loadingScreens;

    public void PlayButton()
    {
        play.GetComponent<Button>().enabled = false;
        exit.GetComponent<Button>().enabled = false;
        credit.GetComponent<Button>().enabled = false;

        mainMenu.SetActive(false);
        playMenu.SetActive(true);
    }

    public void MenuToCredit()
    {
        mainMenu.SetActive(false);
        creditMenu.SetActive(true);
    }

    public void MenuToOptions(){
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }

    public void ToMainMenu(int Window)
    {
        switch (Window){
            case 1:
                creditMenu.SetActive(false);
                break;
            case 2:
                optionMenu.SetActive(false);
                break;
            case 3:
                playMenu.SetActive(false);
                break;
            default:
                Debug.Log("options not available.");
                break;
        }
        mainMenu.SetActive(true);
    }
    
    public void ExitButton()
    {
        Application.Quit();
    }
}
