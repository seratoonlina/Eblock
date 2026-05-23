using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsCOOP : MonoBehaviour
{
    [Header("EFFECT")]
    public AudioSource GOAL;
    public AudioSource effect3;
    public AudioSource effect2;
    public AudioSource effect1;
    public AudioSource GOEffect;
    public AudioSource TIMESUP;

    [Header("MUSIC")]
    public AudioSource music; 
    public float s2TEST;

    [Header("VIEWER SOUND")]
    public AudioSource sound;

    [Header("SLIDER")]
    public Slider sfxslider;
    public Slider musicslider;
    public Slider masterslider;

    void Start()
    {
        sfxslider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        musicslider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        masterslider.value = PlayerPrefs.GetFloat("MasterVolume", 0.5f);
        // Panggil sekali saat masuk scene untuk setting volume awal
    }

    void Update()
    {
        float sfxVol = sfxslider.value;
        float musicVol = musicslider.value;
        float masterVol = masterslider.value;

        // EFFFECT : 
        GOEffect.volume = sfxVol * masterVol;
        effect1.volume = sfxVol * masterVol;
        effect2.volume = sfxVol * masterVol;
        effect3.volume = sfxVol * masterVol;
        GOAL.volume = sfxVol * masterVol;
        TIMESUP.volume = sfxVol * masterVol;

        // MUSIC :
        s2TEST = musicVol * masterVol;
        music.volume = musicVol * masterVol;

        // SOUND :
        sound.volume = masterVol;
        
        Debug.Log("Volume Updated!");
    }
}