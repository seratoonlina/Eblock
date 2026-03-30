using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public PlayerRespawn player1;
    public PlayerRespawn player2;

    public List<InputDevice> devices = new List<InputDevice>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void RegisterDevice(InputDevice device)
    {
        if (!devices.Contains(device))
        {
            devices.Add(device);
        }
    }

    public void RegisterPlayer(PlayerRespawn player)
    {
        if (player1 == null)
        {
            player1 = player;
            Debug.Log("Player 1 registered");
        }
        else if (player2 == null)
        {
            player2 = player;
            Debug.Log("Player 2 registered");
        }
    }   

    void Start()
    {
        var playerInput = GetComponent<PlayerInput>();
    
        if (playerInput.devices.Count > 0)
        {
            GameManager.instance.RegisterDevice(playerInput.devices[0]);
        }
    }

    public void ResetPlayers()
    {
        player1.Respawn();
        player2.Respawn();
    }
}
