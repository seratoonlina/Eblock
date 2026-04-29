using UnityEngine;

public class readySetScript : MonoBehaviour
{
    public GameObject panelStart;
    public GameObject READY;
    public GameObject BLOCK;
    public GameObject Timer;
    public void endReady()
    {
        BLOCK.SetActive(false);
        panelStart.SetActive(false);
        READY.SetActive(false);
        Timer.GetComponent<scriptTimer>().onORoffTIME = true;
        Time.timeScale = 1;
    }
}
