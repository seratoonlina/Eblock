using UnityEngine;

public class readySetScript : MonoBehaviour
{
    public GameObject panelStart;
    public GameObject READY;
    public GameObject BLOCK;
    public void endReady()
    {
        BLOCK.SetActive(false);
        panelStart.SetActive(false);
        READY.SetActive(false);
        Time.timeScale = 1;
    }
}
