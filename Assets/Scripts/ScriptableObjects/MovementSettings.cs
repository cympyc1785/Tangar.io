using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovementSettings", menuName = "Settings/MovementSettings")]
public class MovementSettings : ScriptableObject
{
    public float MAX_SPEED = 5f;
    public float MIN_MAP_X = -50.0f;
    public float MAX_MAP_X = 50.0f;
    public float MIN_MAP_Y = -50.0f;
    public float MAX_MAP_Y = 50.0f;
}
