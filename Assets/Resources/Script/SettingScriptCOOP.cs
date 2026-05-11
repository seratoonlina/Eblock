using UnityEngine;
using UnityEngine.UI;

public class SettingScriptCOOP : MonoBehaviour
{
    public GameObject setting;
    public Slider soundEffect;
    public Slider soundMusic;
    public Slider sound;
    public float soundeffectfloat;
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
        PlayerPrefs.SetFloat("soundeffect", soundEffect.value);
        PlayerPrefs.SetFloat("soundmusic", soundMusic.value);
        PlayerPrefs.SetFloat("sound", sound.value);
        soundeffectfloat = soundEffect.value;
    }
}