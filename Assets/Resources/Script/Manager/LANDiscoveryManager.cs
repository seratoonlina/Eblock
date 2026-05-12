using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Collections.Generic;

public class LANDiscoveryManager : MonoBehaviour
{
    public static LANDiscoveryManager Singleton { get; private set; }

    private const int BroadcastPort = 47777;
    private UdpClient udpClient;
    private bool isBroadcasting;
    private bool isListening;

    public Action<string, string> OnHostFound; // ipAddress, hostName
    private string myHostName = "Player_Guest_" + UnityEngine.Random.Range(1000, 9999);

    private Dictionary<string, float> foundHosts = new Dictionary<string, float>();

    private void Awake()
    {
        if (Singleton != null && Singleton != this)
        {
            Destroy(gameObject);
            return;
        }
        Singleton = this;
    }

    private void OnDestroy()
    {
        StopDiscovery();
    }

    public void StartBroadcasting(string hostName = "")
    {
        if (!string.IsNullOrEmpty(hostName))
            myHostName = hostName;
            
        StopDiscovery();
        
        udpClient = new UdpClient();
        udpClient.EnableBroadcast = true;
        isBroadcasting = true;
        InvokeRepeating(nameof(BroadcastMessage), 0f, 2f);
    }

    public void StartListening()
    {
        StopDiscovery();
        
        udpClient = new UdpClient();
        udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, BroadcastPort));
        isListening = true;
        
        ReceiveData();
    }

    public void StopDiscovery()
    {
        isBroadcasting = false;
        isListening = false;
        CancelInvoke(nameof(BroadcastMessage));
        
        if (udpClient != null)
        {
            udpClient.Close();
            udpClient = null;
        }
    }

    private void BroadcastMessage()
    {
        if (!isBroadcasting || udpClient == null) return;

        string message = "EBLOCK_HOST:" + myHostName;
        byte[] data = Encoding.UTF8.GetBytes(message);
        
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, BroadcastPort);
        try
        {
            udpClient.Send(data, data.Length, endPoint);
        }
        catch (Exception e)
        {
            Debug.LogError("Broadcast error: " + e.Message);
        }
    }

    private async void ReceiveData()
    {
        while (isListening && udpClient != null)
        {
            try
            {
                UdpReceiveResult result = await udpClient.ReceiveAsync();
                string message = Encoding.UTF8.GetString(result.Buffer);
                
                if (message.StartsWith("EBLOCK_HOST:"))
                {
                    string hostName = message.Substring("EBLOCK_HOST:".Length);
                    string ip = result.RemoteEndPoint.Address.ToString();
                    
                    // Prevent spam
                    if (!foundHosts.ContainsKey(ip) || Time.time - foundHosts[ip] > 3f)
                    {
                        foundHosts[ip] = Time.time;
                        OnHostFound?.Invoke(ip, hostName);
                    }
                }
            }
            catch (ObjectDisposedException)
            {
                // Expected when client is closed
                break;
            }
            catch (Exception e)
            {
                Debug.LogError("Receive error: " + e.Message);
            }
        }
    }
    
    public void JoinLANHost(string ipAddress)
    {
        var transport = Unity.Netcode.NetworkManager.Singleton.GetComponent<Unity.Netcode.Transports.UTP.UnityTransport>();
        transport.ConnectionData.Address = ipAddress;
        GameNetworkManager.Singleton.StartClientLAN();
    }
}
