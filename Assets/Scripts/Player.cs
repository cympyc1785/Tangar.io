using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovableObject
{
    public ColorUtils.ColorIdx curColorIdx { get; private set; } = ColorUtils.ColorIdx.RED;

    SpriteRenderer spriteRenderer;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeColor()
    {
        curColorIdx = ColorUtils.NextColor(curColorIdx);

        spriteRenderer.color = ColorUtils.GetColorByIdx(curColorIdx);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision : " + collision.name);
    }


}
