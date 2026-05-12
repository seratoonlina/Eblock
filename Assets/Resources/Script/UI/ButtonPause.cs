using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonPause : MonoBehaviour
{
    public GameObject backloadingQUIT;
    public GameObject settings;
    public Slider selectbuttonSettingFirst;
    public void resume()
    {
        FindAnyObjectByType<PauseScript>().getResume();
    }

    public void setting()
    {
        settings.SetActive(true);
        if (settings.activeSelf)
        {
            selectbuttonSettingFirst.Select();
        }
    }

    public void quit()
    {
        FindAnyObjectByType<PauseScript>().getResume();
        backloadingQUIT.SetActive(true);
        backloadingQUIT.GetComponent<Animator>().SetTrigger("coopON");
    }
}