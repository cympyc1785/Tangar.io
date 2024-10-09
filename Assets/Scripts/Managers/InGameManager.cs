using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UIElements;
using Photon.Realtime;

public class InGameManager : MonoBehaviour
{
    [HideInInspector] public GameObject Player;
    [HideInInspector] public Player player;
    [SerializeField] private List<Vector2> spawnPoints;

    public ServerManager serverManager;
    public CameraManager cameraManager;

    private void Awake()
    {
        serverManager.ConnectToServer();
        serverManager.AddOnJoinHandler(OnPlayerJoinedRoom);
    }

    public void OnPlayerJoinedRoom()
    {
        // 방에 입장했을 때 플레이어 생성
        int idx = UnityEngine.Random.Range(0, spawnPoints.Count);
        Player = PhotonNetwork.Instantiate("Player", (Vector3)spawnPoints[idx], Quaternion.identity);
        player = Player.GetComponent<Player>();
        UnityEngine.Debug.Log(Player.name + " Instantiated");

        // 플레이어 카메라로 변경
        cameraManager.SetPlayerCamera(player.GetPlayerCamera());
        cameraManager.ShowPlayerCamera();
    }

    public void GameOver()
    {
        UnityEngine.Debug.Log("Game Over");

        // PhotonNetwork.Destroy(Player);
    }
}
