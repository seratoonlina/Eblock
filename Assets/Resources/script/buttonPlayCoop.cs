using UnityEngine;

public class buttonPlayCoop : MonoBehaviour
{
    public void OnClick()
    {
        FindAnyObjectByType<pluginSystem>().PlayNow();
    }
}
