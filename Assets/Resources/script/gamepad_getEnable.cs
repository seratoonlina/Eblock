using UnityEngine;
using UnityEngine.SceneManagement;

public class gamepad_getEnable : MonoBehaviour
{
    public GameObject loadingScreen;
    
    public void OnBack()
    {
        loadingScreen.SetActive(true);
        loadingScreen.GetComponent<Animator>().SetTrigger("coopON");
    }
}
