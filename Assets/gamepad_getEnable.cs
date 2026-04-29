using UnityEngine;
using UnityEngine.SceneManagement;

public class gamepad_getEnable : MonoBehaviour
{
    public void OnBack()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
