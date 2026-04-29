using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TIMES_UPscript : MonoBehaviour
{
    public void endTIMESUP()
    {
        Debug.Log("berhasil");
        SceneManager.LoadScene("finalCOOP");
    }
}
