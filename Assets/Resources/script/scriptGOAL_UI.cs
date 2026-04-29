using System.Collections;
using System.Threading;
using UnityEngine;

public class scriptGOAL_UI : MonoBehaviour
{
    public GameObject GOAL_UI;
    public GameObject SOCCER_BALL;
    public GameObject BLOCKREDBLUE;
    public GameObject READYAGAIN;
    public GameObject TimerGOAL;
    public void getGOAL_UI()
    {
        SOCCER_BALL.SetActive(false);
        SOCCER_BALL.GetComponent<Rigidbody>().isKinematic = true;
        
        TimerGOAL.GetComponent<scriptTimer>().onORoffTIME = false;
        
        GOAL_UI.SetActive(true);
        GOAL_UI.GetComponent<Animator>().SetTrigger("GOAL");
    }

    public void TimerStop()
    {
        TimerGOAL.GetComponent<scriptTimer>().onORoffTIME = false;
    }

    public void RespawnStage()
    {
        TimerGOAL.GetComponent<scriptTimer>().onORoffTIME = false;
        READYAGAIN.SetActive(true);
        BLOCKREDBLUE.SetActive(true);
        SOCCER_BALL.SetActive(true);
        SOCCER_BALL.GetComponent<Rigidbody>().isKinematic = false;
        FindAnyObjectByType<SpawnManager>().ResetPlayers();
        READYAGAIN.GetComponent<Animator>().SetTrigger("on");
        gameObject.SetActive(false);
        
    }
}
