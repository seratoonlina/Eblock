using Unity.Netcode;
using UnityEngine;
using Unity.Collections;

public class RoomSettingsNetwork : NetworkBehaviour
{
    public static RoomSettingsNetwork Singleton { get; private set; }

    public NetworkVariable<int> MaxPlayers = new NetworkVariable<int>(2, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);
    public NetworkVariable<FixedString32Bytes> CameraMode = new NetworkVariable<FixedString32Bytes>("Topdown", NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);

    private void Awake()
    {
        if (Singleton != null && Singleton != this)
        {
            Destroy(gameObject);
            return;
        }
        Singleton = this;
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        
        if (IsServer)
        {
            // Set default settings on spawn if server
            MaxPlayers.Value = 2; // Default 1v1
            CameraMode.Value = "Topdown";
        }

        // Listen for changes
        MaxPlayers.OnValueChanged += OnMaxPlayersChanged;
        CameraMode.OnValueChanged += OnCameraModeChanged;
    }

    public override void OnNetworkDespawn()
    {
        MaxPlayers.OnValueChanged -= OnMaxPlayersChanged;
        CameraMode.OnValueChanged -= OnCameraModeChanged;
        base.OnNetworkDespawn();
    }

    private void OnMaxPlayersChanged(int previousValue, int newValue)
    {
        Debug.Log($"Max Players changed to: {newValue}");
        // Add UI updates or logic here
    }

    private void OnCameraModeChanged(FixedString32Bytes previousValue, FixedString32Bytes newValue)
    {
        Debug.Log($"Camera Mode changed to: {newValue}");
        // Change camera logic based on mode here
    }

    // Method for Host to update settings
    public void SetSettings(int maxPlayers, string cameraMode)
    {
        if (IsServer)
        {
            MaxPlayers.Value = maxPlayers;
            CameraMode.Value = cameraMode;
        }
    }
}
