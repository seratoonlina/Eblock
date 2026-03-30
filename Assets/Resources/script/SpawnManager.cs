using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    public GameObject playerPrefab;

    public Transform spawnPoint1;
    public Transform spawnPoint2;

    public bool p1Spawned = false;
    public bool p2Spawned = false;

    private GameObject player1;
    private GameObject player2;

    void Update()
    {
        foreach (var gamepad in Gamepad.all)
        {
            if (gamepad.buttonNorth.wasPressedThisFrame)
            {
                // Player 1
                if (!p1Spawned)
                {
                    player1 = SpawnPlayer(gamepad, spawnPoint1);
                    p1Spawned = true;
                    player1.GetComponent<Renderer>().material.color = Color.red;
                }
                // Player 2
                else if (!p2Spawned && gamepad != player1.GetComponent<PlayerInput>().devices[0])
                {
                    player2 = SpawnPlayer(gamepad, spawnPoint2);
                    p2Spawned = true;
                    player2.GetComponent<Renderer>().material.color = Color.blue;
                }
            }
        }

        // 🔄 TEST RESET (tekan R di keyboard)
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            ResetPlayers();
        }
    }

    GameObject SpawnPlayer(Gamepad gamepad, Transform spawnPoint)
    {
        GameObject player = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);

        // Assign device
        var input = player.GetComponent<PlayerInput>();
        input.SwitchCurrentControlScheme("Gamepad", gamepad);

        // Set spawn ke player
        var respawn = player.GetComponent<PlayerRespawn>();
        respawn.SetSpawn(spawnPoint);

        return player;
    }

    public void ResetPlayers()
    {
        if (player1 != null)
            player1.GetComponent<PlayerRespawn>().Respawn();

        if (player2 != null)
            player2.GetComponent<PlayerRespawn>().Respawn();
    }
}