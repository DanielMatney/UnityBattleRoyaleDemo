using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class StartManager : MonoBehaviour
{

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 300));

        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            ShowStartButtons();
        }
        else
        {
            ShowConnectedLabels();
        }

        GUILayout.EndArea();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    static void ShowStartButtons()
    {
        if (GUILayout.Button("Client")) NetworkManager.Singleton.StartClient();
        if (GUILayout.Button("Host")) NetworkManager.Singleton.StartHost();
        if (GUILayout.Button("Server")) NetworkManager.Singleton.StartServer();
    }

    static void ShowConnectedLabels()
    {
        if (GUILayout.Button(NetworkManager.Singleton.IsServer ? "Move" : "Request Position Change"))
        {
            if (NetworkManager.Singleton.ConnectedClients.TryGetValue(NetworkManager.Singleton.LocalClientId, out var networkedClient))
            {
                var player = networkedClient.PlayerObject.GetComponent<StartPlayer>();
                if (player)
                    {
                        player.Move();
                    }
            }
        }
    }
}
