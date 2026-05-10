using UnityEngine;
using UnityEngine.UI;

public class scriptSettingAUDIO : MonoBehaviour
{
    public AudioSource effect;
    public AudioSource music;
    public AudioSource sound;

    public Slider s1;

    void Start()
    {
        // Panggil sekali saat masuk scene untuk setting volume awal
    }

    // Buat fungsi publik supaya bisa dipanggil dari script lain 
    // (misal dipanggil dari OnValueChanged milik Slider)
    void Update()
    {
        float volEffect = PlayerPrefs.GetFloat("soundeffect", 0.5f);
        float volMusic = PlayerPrefs.GetFloat("soundmusic", 0.5f);
        float volMaster = PlayerPrefs.GetFloat("sound", 0.5f);

        if (effect != null) effect.volume = volEffect;
        if (music != null) music.volume = volMusic;
        if (sound != null) sound.volume = volMaster;
        
        Debug.Log("Volume Updated!");
    }
}