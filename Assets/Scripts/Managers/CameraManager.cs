using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public InGameManager gm;

    public Camera mainCamera;
    [HideInInspector] public Camera playerCamera;

    public void SetPlayerCamera(Camera playerCam)
    {
        if (playerCam == null)
        {
            Debug.Log("Camer not found!");
        }
        playerCamera = playerCam;
    }

    public void ShowMainCamera()
    {
        mainCamera.enabled = true;
        if (playerCamera != null) playerCamera.enabled = false;
    }

    public void ShowPlayerCamera()
    {
        if (playerCamera == null) return;

        mainCamera.enabled = false;
        playerCamera.enabled = true;
    }
}
