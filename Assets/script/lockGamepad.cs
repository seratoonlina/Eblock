
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class LockDevice : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputDevice savedDevice;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        savedDevice = playerInput.devices.Count > 0 ? playerInput.devices[0] : null;
    }

    void OnEnable()
    {
        if (savedDevice != null)
        {
            playerInput.user.UnpairDevices();
            InputUser.PerformPairingWithDevice(savedDevice, playerInput.user);
        }
    }
}