using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    [HideInInspector] public bool isJoystickMoving;
    [HideInInspector] public Vector3 dir;

    void Start()
    {
        isJoystickMoving = false;
    }
}
