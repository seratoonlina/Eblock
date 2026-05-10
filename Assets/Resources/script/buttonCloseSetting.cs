using UnityEngine;
using UnityEngine.UI;

public class buttonCloseSetting : MonoBehaviour
{
    public GameObject settingGUI;
    public Button settingButton;
    public void getClickClose()
    {
        settingGUI.SetActive(false);
        settingButton.Select();
    }
}
