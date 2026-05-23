using UnityEngine;
using UnityEngine.UI;

public class AudioSettingscript : MonoBehaviour
{
    public GameObject settingsPanel; 
    public Slider SFXSlider;
    public Slider MusicSlider;
    public Slider MasterVol;

    void Awake()
    {
        // Tetap mengambil data saat scene mulai
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        MasterVol.value = PlayerPrefs.GetFloat("MasterVolume", 0.5f);
        settingsPanel.SetActive(false);
    }

    void Start(){
    }

    public void ShowSetting()
    {
        settingsPanel.SetActive(true);
        SFXSlider.Select();
    }

    void Update()
    {
        // Tetap simpan data secara real-time
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
        PlayerPrefs.SetFloat("MasterVolume", MasterVol.value);
    }


}