using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPause : MonoBehaviour
{

    public void resume()
    {
        FindAnyObjectByType<PauseScript>().getResume();
    }

    public void setting()
    {
        //ComingSoon
    }

    public void restart()
    {
        FindAnyObjectByType<PauseScript>().getResume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
