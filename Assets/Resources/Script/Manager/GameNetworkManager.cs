using Unity.Netcode;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameNetworkManager : MonoBehaviour
{
    public static GameNetworkManager Singleton { get; private set; }

    [SerializeField]
    private TextMeshProUGUI PlayersCount;

    private void Awake()
    {
        if (Singleton != null && Singleton != this)
        {
            Destroy(gameObject);
            return;
        }
        Singleton = this;
        Cursor.visible = true;
    }    

    private void Update() 
    {
        if (PlayersCount != null && PlayerManager.Singleton != null)
        {
            PlayersCount.text = "Players: " + PlayerManager.Singleton.GetPlayerCount();
        }
    }

    public void StartHostLAN()
    {
        Unity.Netcode.NetworkManager.Singleton.StartHost();
    }

    public void StartClientLAN()
    {
        Unity.Netcode.NetworkManager.Singleton.StartClient();
    }

    public void StartServerLAN()
    {
        Unity.Netcode.NetworkManager.Singleton.StartServer();
    }

    public void StartHostRelay(Unity.Services.Relay.Models.Allocation allocation)
    {
        var transport = Unity.Netcode.NetworkManager.Singleton.GetComponent<Unity.Netcode.Transports.UTP.UnityTransport>();
        transport.SetRelayServerData(new Unity.Networking.Transport.Relay.RelayServerData(allocation, "dtls"));
        Unity.Netcode.NetworkManager.Singleton.StartHost();
    }

    public void StartClientRelay(Unity.Services.Relay.Models.JoinAllocation joinAllocation)
    {
        var transport = Unity.Netcode.NetworkManager.Singleton.GetComponent<Unity.Netcode.Transports.UTP.UnityTransport>();
        transport.SetRelayServerData(new Unity.Networking.Transport.Relay.RelayServerData(joinAllocation, "dtls"));
        Unity.Netcode.NetworkManager.Singleton.StartClient();
    }

    // Callbacks for future use
    private void OnServerStarted(){}
    private void OnClientStarted(){}
    private void OnHostStarted(){}

    public void OnPlayerJoined(ulong clientId)
    {
        if (PlayerManager.Singleton != null)
            PlayerManager.Singleton.AddClientId(clientId);
    }

    public void OnPlayerLeft(ulong clientId)
    {
        if (PlayerManager.Singleton != null)
            PlayerManager.Singleton.RemoveClientId(clientId);
    }
}