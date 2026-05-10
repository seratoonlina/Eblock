using UnityEngine;
using UnityEngine.UI;

public class scriptSettingAudioCOOP : MonoBehaviour
{
    [Header("EFFECT")]
    public AudioSource effectGOAL;
    public AudioSource effect3;
    public AudioSource effect2;
    public AudioSource effect1;
    public AudioSource effectgo;
    public AudioSource effectTIMESUP;

    [Header("MUSIC")]
    public AudioSource music; 
    public float s2TEST;

    [Header("SOUND")]
    public AudioSource sound;

    [Header("SLIDER")]
    public Slider s1;
    public Slider s2;
    public Slider s3;

    void Start()
    {
        // Panggil sekali saat masuk scene untuk setting volume awal
    }

    // Buat fungsi publik supaya bisa dipanggil dari script lain 
    // (misal dipanggil dari OnValueChanged milik Slider)
    void Update()
    {
        // EFFFECT : 
        effectgo.volume = s1.value;
        effect1.volume = s1.value;
        effect2.volume = s1.value;
        effect3.volume = s1.value;
        effectGOAL.volume = s1.value;
        effectTIMESUP.volume = s1.value;

        // MUSIC :
        s2TEST = s2.value;
        music.volume = s2.value;

        // SOUND :
        
        Debug.Log("Volume Updated!");
    }
}