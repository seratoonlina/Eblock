using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseScene;
    public bool isPause;
    InputMenu menuSetting;

    void OnEnable()
    {
        menuSetting.Enable();
    }

    void Awake()
    {
        menuSetting = new InputMenu();
        menuSetting.Movement.Pause.performed += ctx => isPause = true;
        menuSetting.Movement.Back.canceled += ctx => isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPause == true)
        {
            PauseScene.SetActive(true);
            Time.timeScale = 0;
        }
        else if (isPause == false)
        {
            PauseScene.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void getResume()
    {
        isPause = false;
    }
}
