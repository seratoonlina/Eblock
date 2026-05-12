using Unity.Netcode;
using UnityEngine;
using System.Collections.Generic;
using Unity.Netcode;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Singleton { get; private set; }

    private List<ulong> clientIds = new List<ulong>();

    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddClientId(ulong clientId)
    {
        if (!clientIds.Contains(clientId))
        {
            clientIds.Add(clientId);
        }
    }

    public void RemoveClientId(ulong clientId)
    {
        clientIds.Remove(clientId);
    }

    public List<ulong> GetClientIds()
    {
        return clientIds;
    }

    public int GetPlayerCount()
    {
        return clientIds.Count;
    }
}