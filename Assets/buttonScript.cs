using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("PlayScene");
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
