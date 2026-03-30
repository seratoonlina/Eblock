using UnityEngine;

public class openingAnimmationScript : MonoBehaviour
{
    public Animator OPENING_ani;
    void Start()
    {
        OPENING_ani.SetTrigger("play");   
    }

    public void close()
    {
        
    }
}
