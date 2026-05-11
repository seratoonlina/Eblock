using UnityEngine;
using UnityEngine.UI;

public class scriptSettingAudioCOOPpersiapan : MonoBehaviour
{
    

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
        music.Play();
    }

    void Update()
    {
        // MUSIC :
        music.volume = s2.value;
        s2TEST = s2.value;
        

        // SOUND :
        
        Debug.Log("Volume Updated!");
    }
    

    // Buat fungsi publik supaya bisa dipanggil dari script lain 
    // (misal dipanggil dari OnValueChanged milik Slider)

}
