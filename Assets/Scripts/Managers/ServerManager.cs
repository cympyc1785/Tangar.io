using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ServerManager : MonoBehaviourPunCallbacks
{
    public Action onJoinHandler;

    public void AddOnJoinHandler(Action handler)
    {
        if (onJoinHandler == null)
        {
            onJoinHandler = handler;
        }
        else
        {
            onJoinHandler += handler;
        }
    }

    public void ConnectToServer()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings(); // Photon ������ ����
            Debug.Log("Connecting to Photon Server...");
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon Master Server");
        PhotonNetwork.JoinLobby(); // ������ ����Ǹ� �κ� ����
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");

        // �κ� �����ϸ� �濡 ���� �Ǵ� ����
        JoinOrCreateRoom();
    }

    private void JoinOrCreateRoom()
    {
        string roomName = "TestRoom"; // ������ �� �̸��� ����
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4; // �ִ� 4���� �÷��̾� ���

        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room: " + PhotonNetwork.CurrentRoom.Name);
        onJoinHandler?.Invoke();
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError($"Failed to join room: {message}");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError($"Failed to create room: {message}");
    }
}
