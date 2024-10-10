using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 direction;
    const float speed = 10.0f;

    // Stage boundary limits
    float stageMinX = -50f;
    float stageMaxX = 50f;
    float stageMinY = -50f;
    float stageMaxY = 50f;

    // Add buffer zone for spawning outside the play area
    float buffer = 10f;

    public BulletSpawner spawner; // Reference to the spawner

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    public void SetPosition(Vector2 pos)
    {
        gameObject.transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(direction * speed * Time.deltaTime);

        // Start checking immediately if the bullet is out of bounds, but include a buffer
        CheckOutOfBounds();
    }

    // Check if the bullet is out of bounds and return it to the pool
    void CheckOutOfBounds()
    {
        Vector2 position = gameObject.transform.position;

        // Add a buffer zone outside the stage to prevent immediate deactivation
        if (position.x < stageMinX - buffer || position.x > stageMaxX + buffer ||
            position.y < stageMinY - buffer || position.y > stageMaxY + buffer)
        {
            ReturnToPool();
        }
    }

    // Return the bullet to the pool instead of destroying it
    void ReturnToPool()
    {
        spawner.NotifyBulletDestroyed(gameObject); // Notify spawner to return the bullet to the pool
    }
}
