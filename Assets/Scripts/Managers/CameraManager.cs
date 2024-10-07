using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MovableObject
{
    Player player;
    
    void Start()
    {
        player = gm.Player.GetComponent<Player>();
    }
}
