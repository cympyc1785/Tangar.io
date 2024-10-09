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
            PhotonNetwork.ConnectUsingSettings(); // Photon 서버에 연결
            Debug.Log("Connecting to Photon Server...");
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon Master Server");
        PhotonNetwork.JoinLobby(); // 서버에 연결되면 로비에 입장
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");

        // 로비에 입장하면 방에 참가 또는 생성
        JoinOrCreateRoom();
    }

    private void JoinOrCreateRoom()
    {
        string roomName = "TestRoom"; // 임의의 방 이름을 설정
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4; // 최대 4명의 플레이어 허용

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
