using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadingAnimationScript : MonoBehaviour
{
    
    public GameObject LoadingScreens;
    public void OnAnimation(int SceneIndex)
    {
        StartCoroutine(SceneLoadingStatus(SceneIndex));
    }


    IEnumerator SceneLoadingStatus(int SceneIndex)
    {
        AsyncOperation operations = SceneManager.LoadSceneAsync(SceneIndex);

        while(operations.isDone == false)
        {
            Debug.Log("Loading Scene: " + operations.progress);
            LoadingScreens.SetActive(true);
            yield return null;
        }
    }
}
