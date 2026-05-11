using UnityEngine;
using UnityEngine.UI;

public class scriptEnableButton : MonoBehaviour
{
    public GameObject buttons;
    public GameObject gamepadEnable;
    
    public void getEvent()
    {
        buttons.SetActive(true);
        buttons.GetComponent<Animator>().SetTrigger("on");
        gamepadEnable.SetActive(true);
    }
}
