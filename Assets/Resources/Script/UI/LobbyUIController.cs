using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using Unity.Services.Lobbies.Models;

public class LobbyUIController : MonoBehaviour
{
    [Header("Main Menu")]
    public GameObject mainMenuPanel;
    public Button onlineModeBtn;
    public Button lanModeBtn;

    [Header("Online Menu")]
    public GameObject onlineMenuPanel;
    public Button createPublicRoomBtn;
    public Button createPrivateRoomBtn;
    public Button joinLobbyListBtn; // Refresh list
    public TMP_InputField joinCodeInput;
    public Button joinPrivateRoomBtn;
    public Button backOnlineBtn;
    
    [Header("LAN Menu")]
    public GameObject lanMenuPanel;
    public Button startLanHostBtn;
    public Button searchLanHostBtn;
    public Transform lanHostListContainer; // Parent for instantiated buttons
    public GameObject lanHostButtonPrefab; // Prefab UI button
    public Button backLanBtn;

    [Header("Room Settings (Online Create)")]
    public TMP_Dropdown maxPlayersDropdown; // 1v1 (2), 2v2 (4)
    public TMP_Dropdown cameraModeDropdown; // Topdown, TPV

    private void Start()
    {
        ShowPanel(mainMenuPanel);

        // Main Menu
        onlineModeBtn.onClick.AddListener(async () => {
            ShowPanel(onlineMenuPanel);
            await MatchmakingManager.Singleton.InitializeAndAuthenticate();
        });

        lanModeBtn.onClick.AddListener(() => {
            ShowPanel(lanMenuPanel);
        });

        // Online Actions
        createPublicRoomBtn.onClick.AddListener(() => {
            int maxP = maxPlayersDropdown.value == 0 ? 2 : 4;
            _ = MatchmakingManager.Singleton.CreateLobby("Public Room", false, maxP);
            // Hide panels or show "In Room" UI
            gameObject.SetActive(false);
        });

        createPrivateRoomBtn.onClick.AddListener(() => {
            int maxP = maxPlayersDropdown.value == 0 ? 2 : 4;
            _ = MatchmakingManager.Singleton.CreateLobby("Private Room", true, maxP);
            gameObject.SetActive(false);
        });

        joinPrivateRoomBtn.onClick.AddListener(() => {
            if (!string.IsNullOrEmpty(joinCodeInput.text))
            {
                _ = MatchmakingManager.Singleton.JoinLobbyByCode(joinCodeInput.text);
                gameObject.SetActive(false);
            }
        });

        backOnlineBtn.onClick.AddListener(() => ShowPanel(mainMenuPanel));

        // LAN Actions
        startLanHostBtn.onClick.AddListener(() => {
            LANDiscoveryManager.Singleton.StartBroadcasting();
            GameNetworkManager.Singleton.StartHostLAN();
            gameObject.SetActive(false);
        });

        searchLanHostBtn.onClick.AddListener(() => {
            // Clear old list
            foreach (Transform child in lanHostListContainer)
                Destroy(child.gameObject);

            LANDiscoveryManager.Singleton.StartListening();
        });

        LANDiscoveryManager.Singleton.OnHostFound += (ip, hostName) => {
            if (lanHostButtonPrefab == null || lanHostListContainer == null) return;
            
            GameObject btnObj = Instantiate(lanHostButtonPrefab, lanHostListContainer);
            btnObj.GetComponentInChildren<TextMeshProUGUI>().text = $"{hostName} ({ip})";
            btnObj.GetComponent<Button>().onClick.AddListener(() => {
                LANDiscoveryManager.Singleton.StopDiscovery();
                LANDiscoveryManager.Singleton.JoinLANHost(ip);
                gameObject.SetActive(false);
            });
        };

        backLanBtn.onClick.AddListener(() => {
            LANDiscoveryManager.Singleton.StopDiscovery();
            ShowPanel(mainMenuPanel);
        });
    }

    private void ShowPanel(GameObject panelToShow)
    {
        if (mainMenuPanel) mainMenuPanel.SetActive(false);
        if (onlineMenuPanel) onlineMenuPanel.SetActive(false);
        if (lanMenuPanel) lanMenuPanel.SetActive(false);

        if (panelToShow) panelToShow.SetActive(true);
    }
}
