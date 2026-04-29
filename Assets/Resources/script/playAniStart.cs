using System.Threading;
using UnityEngine;

public class playAniStart : MonoBehaviour
{
    public GameObject blockRed;
    public GameObject blockBlue;
    public GameObject TimerStart;

    public Animator go123;
    public void onAnimateStart()
    {
        go123.SetTrigger("on");
        TimerStart.GetComponent<scriptTimer>().onORoffTIME = false;
        TimerStart.GetComponent<scriptTimer>().totalDetik = 180f;


        
    }
}
