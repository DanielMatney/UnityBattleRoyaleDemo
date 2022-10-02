using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class StartPlayer : NetworkBehaviour
{
    public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>(default,
    NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    public void Move()
    {
        if (NetworkManager.Singleton.IsServer)
        {
            var randomPosition = GetRandomPositionOnPlane();

            transform.position = randomPosition;

            Position.Value = randomPosition;
        }
        else
        {
            SubmitPositionRequestServerRpc();
        }

    }

    static Vector3 GetRandomPositionOnPlane()
    {
        float MinPos = -5f;
        float MaxPos = 5f;
        float xPos = Random.Range(MinPos, MaxPos);
        float yPos = 1f;
        float zPos = Random.Range(MinPos, MaxPos);

        return new Vector3(xPos, yPos, zPos);
    }

    [ServerRpc]
    void SubmitPositionRequestServerRpc(ServerRpcParams rpcParams = default)
    {
        Position.Value = GetRandomPositionOnPlane();
    }

    private void Update() {
        {
            
        }
    }
}
