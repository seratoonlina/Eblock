using UnityEngine;

public class playAniStart : MonoBehaviour
{
    public GameObject blockRed;
    public GameObject blockBlue;

    public Animator go123;
    public void onAnimateStart()
    {
        go123.SetTrigger("on");
        
    }
}
