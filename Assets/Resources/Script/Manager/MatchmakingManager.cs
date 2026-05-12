using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;

public class MatchmakingManager : MonoBehaviour
{
    public static MatchmakingManager Singleton { get; private set; }

    private Lobby connectedLobby;
    private float heartbeatTimer;

    private void Awake()
    {
        if (Singleton != null && Singleton != this)
        {
            Destroy(gameObject);
            return;
        }
        Singleton = this;
    }

    private void Update()
    {
        HandleLobbyHeartbeat();
    }

    public async Task InitializeAndAuthenticate()
    {
        try
        {
            InitializationOptions options = new InitializationOptions();
            options.SetProfile(Random.Range(0, 10000).ToString());

            await UnityServices.InitializeAsync(options);

            AuthenticationService.Instance.SignedIn += () =>
            {
                Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId);
            };

            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
        }
    }

    public async Task CreateLobby(string lobbyName, bool isPrivate, int maxPlayers)
    {
        try
        {
            Allocation allocation = await RelayService.Instance.CreateAllocationAsync(maxPlayers - 1);
            string relayJoinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

            CreateLobbyOptions options = new CreateLobbyOptions
            {
                IsPrivate = isPrivate,
                Data = new Dictionary<string, DataObject>
                {
                    { "RelayCode", new DataObject(DataObject.VisibilityOptions.Member, relayJoinCode) },
                    { "CameraMode", new DataObject(DataObject.VisibilityOptions.Public, "Topdown") },
                    { "GameMode", new DataObject(DataObject.VisibilityOptions.Public, "Classic") }
                }
            };

            Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, options);
            connectedLobby = lobby;
            
            Debug.Log($"Created Lobby: {lobby.Name} with max players: {maxPlayers}. IsPrivate: {isPrivate}. Join Code: {lobby.LobbyCode}");
            
            GameNetworkManager.Singleton.StartHostRelay(allocation);
        }
        catch (LobbyServiceException e)
        {
            Debug.LogError(e);
        }
    }

    public async Task JoinLobbyById(string lobbyId)
    {
        try
        {
            Lobby lobby = await LobbyService.Instance.JoinLobbyByIdAsync(lobbyId);
            await JoinRelayFromLobby(lobby);
        }
        catch (LobbyServiceException e)
        {
            Debug.LogError(e);
        }
    }

    public async Task JoinLobbyByCode(string lobbyCode)
    {
        try
        {
            Lobby lobby = await LobbyService.Instance.JoinLobbyByCodeAsync(lobbyCode);
            await JoinRelayFromLobby(lobby);
        }
        catch (LobbyServiceException e)
        {
            Debug.LogError(e);
        }
    }

    private async Task JoinRelayFromLobby(Lobby lobby)
    {
        connectedLobby = lobby;
        string relayJoinCode = lobby.Data["RelayCode"].Value;
        Debug.Log("Joined Lobby, Relay Code is: " + relayJoinCode);

        JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(relayJoinCode);
        GameNetworkManager.Singleton.StartClientRelay(joinAllocation);
    }

    private async void HandleLobbyHeartbeat()
    {
        if (connectedLobby != null && connectedLobby.HostId == AuthenticationService.Instance.PlayerId)
        {
            heartbeatTimer -= Time.deltaTime;
            if (heartbeatTimer < 0f)
            {
                float heartbeatTimerMax = 15f;
                heartbeatTimer = heartbeatTimerMax;
                await LobbyService.Instance.SendHeartbeatPingAsync(connectedLobby.Id);
            }
        }
    }

    public async Task LeaveLobby()
    {
        if (connectedLobby != null)
        {
            try
            {
                await LobbyService.Instance.RemovePlayerAsync(connectedLobby.Id, AuthenticationService.Instance.PlayerId);
                connectedLobby = null;
            }
            catch (LobbyServiceException e)
            {
                Debug.LogError(e);
            }
        }
    }
}
