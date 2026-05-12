using UnityEngine;

public class buttonPlayCoop : MonoBehaviour
{
    public void OnClick()
    {
        FindAnyObjectByType<ControllerCheck>().PlayNow();
    }
}
