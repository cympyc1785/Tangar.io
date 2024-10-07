using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public InGameManager gm;

    public float MAX_SPEED = 5f;
    float MIN_MAP_X = -50.0f, MAX_MAP_X = 50.0f;
    float MIN_MAP_Y = -50.0f, MAX_MAP_Y = 50.0f;

    [HideInInspector] public bool isMoving;
    [HideInInspector] public float speed;
    [HideInInspector] public Vector2 pos;
    Vector2 direction;

    public void Move(Vector2 dir, float taget_speed)
    {
        if (dir == null) return;
        direction = dir;
        speed = taget_speed;
        isMoving = true;
    }

    public void Stop()
    {
        isMoving = false;
        speed = 0;
        direction = new Vector2(0, 0);
    }

    private void Update()
    {
        pos = transform.position;

        // stop for boundary
        if ((pos.x <= MIN_MAP_X && direction.x < 0.0f) || (pos.x >= MAX_MAP_X && direction.x > 0.0f))
        {
            direction.x = 0.0f;
        }
        if ((pos.y <= MIN_MAP_Y && direction.y < 0.0f) || (pos.y >= MAX_MAP_Y && direction.y > 0.0f))
        {
            direction.y = 0.0f;
        }

        // normalize
        if (direction.magnitude > 1.0f)
        {
            direction = direction.normalized;
        }

        // move
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
