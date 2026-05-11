using UnityEngine;
using UnityEngine.UI;

public class SettingScript : MonoBehaviour
{
    public GameObject settingPanel; 
    public Slider soundEffect;
    public Slider soundMusic;
    public Slider sound;

    void Awake()
    {
        // Tetap mengambil data saat scene mulai
        soundEffect.value = PlayerPrefs.GetFloat("soundeffect", 0.5f);
        soundMusic.value = PlayerPrefs.GetFloat("soundmusic", 0.5f);
        sound.value = PlayerPrefs.GetFloat("sound", 0.5f);
        settingPanel.SetActive(false);
        
        
    }

    void Start(){
    }

    public void ShowSetting()
    {
        settingPanel.SetActive(true);
        soundEffect.Select();
    }

    void Update()
    {
        // Tetap simpan data secara real-time
        PlayerPrefs.SetFloat("soundeffect", soundEffect.value);
        PlayerPrefs.SetFloat("soundmusic", soundMusic.value);
        PlayerPrefs.SetFloat("sound", sound.value);
    }
}