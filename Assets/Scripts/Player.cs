using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovableObject
{
    public int curColorIdx { get; private set; } = 0;

    public void ChangeColor()
    {
        curColorIdx = (curColorIdx + 1) % 3;
    }
}
