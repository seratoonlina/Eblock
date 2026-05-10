using UnityEngine;

public class readySetScript : MonoBehaviour
{
    public GameObject panelStart;
    public GameObject READY;
    public GameObject BLOCK;
    public GameObject Timer;

    public AudioSource tree;
    public AudioSource two;
    public AudioSource one;
    public AudioSource go;
    public AudioSource peluit;
    public void endReady()
    {
        BLOCK.SetActive(false);
        panelStart.SetActive(false);
        READY.SetActive(false);
        Timer.GetComponent<scriptTimer>().onORoffTIME = true;
        Time.timeScale = 1;
    }

    public void setTree()
    {
        tree.Play();
    }
    public void setTwo()
    {
        two.Play();
    }
    public void setOne()
    {
        one.Play();
    }
    public void setGo()
    {
        go.Play();
        peluit.Play();
    }
}
