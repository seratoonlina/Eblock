using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class insideButtonPlay : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject loadingScreenProgress;

    public void COOP()
    {
        loadingScreen.SetActive(true);
        loadingScreen.GetComponent<Animator>().SetTrigger("coopON");
    }
    public void MultiPlayer()
    {
        
    }
    public void Bot()
    {
        
    }


    IEnumerator loadScene(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);

        while(operation.isDone == false)
        {
            Debug.Log(" Loading Scene: " + operation.progress);
            loadingScreen.SetActive(true);
            loadingScreenProgress.SetActive(true);
            yield return null;
        }

        loadingScreen.SetActive(true);
        
    }
}
