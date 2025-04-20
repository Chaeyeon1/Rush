using Unity.Netcode;
using UnityEngine;

public class NetworkManagerHud : MonoBehaviour
{
    void OnGUI()
    {
        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            if (GUI.Button(new Rect(10, 10, 150, 30), "Start Host"))
            {
                NetworkManager.Singleton.StartHost();
            }

            if (GUI.Button(new Rect(10, 50, 150, 30), "Start Client"))
            {
                NetworkManager.Singleton.StartClient();
            }

            if (GUI.Button(new Rect(10, 90, 150, 30), "Start Server"))
            {
                NetworkManager.Singleton.StartServer();
            }
        }
        else
        {
            string mode = NetworkManager.Singleton.IsHost ? "Host" :
                          NetworkManager.Singleton.IsServer ? "Server" : "Client";
            GUI.Label(new Rect(10, 10, 300, 30), "Transport: " + mode);
        }
    }
}
