using UnityEngine;
using UnityEngine.UI;

public class SettingsCOOP : MonoBehaviour
{
    public GameObject setting;
    public Slider soundEffect;
    public Slider soundMusic;
    public Slider sound;

    public float soundeffectfloat;

    // Tambahkan Start agar pas game dibuka, posisi slider sesuai dengan yang disimpan
    void Start()
    {
    }

    void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }

    public void ShowSetting()
    {
        setting.SetActive(true);
        if (setting.activeSelf)
        {
            soundEffect.Select();
        }
    }

    void Update()
    {
        // Menyimpan nilai slider ke PlayerPrefs secara terus menerus
        PlayerPrefs.SetFloat("soundeffect", soundEffect.value);
        PlayerPrefs.SetFloat("soundmusic", soundMusic.value);
        PlayerPrefs.SetFloat("sound", sound.value);
        // Memasukkan nilai slider ke variabel soundeffectfloat agar tidak error
        soundeffectfloat = soundEffect.value;
    }
}