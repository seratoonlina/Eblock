using UnityEngine;
using UnityEngine.InputSystem;

public class gamePadWarning : MonoBehaviour
{
    public GameObject GUIWarning;

    void OnEnable()
    {
        InputSystem.onDeviceChange += OnDeviceChange;
    }

    void OnDisable()
    {
        InputSystem.onDeviceChange -= OnDeviceChange;
    }
    
    void OnDeviceChange(InputDevice device,  InputDeviceChange change)
    {
        if (device is Gamepad)
        {
            if (change == InputDeviceChange.Added)
            {
                Debug.Log("gamepad Connected");
            }
            else if (change == InputDeviceChange.Removed)
            {
                Debug.Log("gamepad disconnected");
            }
        }
    }
    
}
