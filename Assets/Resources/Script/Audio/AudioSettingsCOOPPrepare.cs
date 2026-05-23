using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsCOOPPrepare : MonoBehaviour
{
    

    [Header("MUSIC")]
    public AudioSource music; 
    public float s2TEST;

    [Header("SOUND")]
    public AudioSource sound;

    void Start()
    {
        music.Play();
    }

    void Update()
    {
        float volMusic = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        float volMaster = PlayerPrefs.GetFloat("MasterVolume", 0.5f);
        // MUSIC :
        music.volume = volMusic * volMaster;
        s2TEST = volMusic * volMaster;

        // SOUND :
        Debug.Log("Volume Updated!");
    }

    // Buat fungsi publik supaya bisa dipanggil dari script lain 
    // (misal dipanggil dari OnValueChanged milik Slider)

}
