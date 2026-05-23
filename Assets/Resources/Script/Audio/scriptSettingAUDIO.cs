using UnityEngine;
using UnityEngine.UI;

public class scriptSettingAUDIO : MonoBehaviour
{
    public AudioSource SFXVol;
    public AudioSource MusicVol;
    public AudioSource MasterVol;

    public Slider s1;

    void Start()
    {
        // Panggil sekali saat masuk scene untuk setting volume awal
    }

    // Buat fungsi publik supaya bisa dipanggil dari script lain 
    // (misal dipanggil dari OnValueChanged milik Slider)
    void Update()
    {
        float volSFX = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        float volMusic = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        float volMaster = PlayerPrefs.GetFloat("MasterVolume", 0.5f);

        if (SFXVol != null) SFXVol.volume = volSFX;
        if (MusicVol != null) MusicVol.volume = volMusic;
        if (MasterVol != null) MasterVol.volume = volMaster;
        
        Debug.Log("Volume Updated!");
    }
}