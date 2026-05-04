using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TIMES_UPscript : MonoBehaviour
{
    public AudioSource audioTimesup;
    public AudioSource musicBackground;

    public void endTIMESUP()
    {
        Debug.Log("berhasil");
        SceneManager.LoadScene("finalCOOP");
    }
    public void playPeluit()
    {
        audioTimesup.Play();
        musicBackground.Stop();

    }


}
