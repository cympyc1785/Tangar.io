using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public BulletPooler bulletPooler; // Reference to the bullet pooler
    private float spawnInterval = 0.1f;
    private float timeSinceLastSpawn = 0f;


    // Size of the play area (assuming a square stage)
    float stageMinX = -50f;
    float stageMaxX = 50f;
    float stageMinY = -50f;
    float stageMaxY = 50f;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        // Spawn bullets based on time interval
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnBullet();
            timeSinceLastSpawn = 0f;
        }
    }
    Vector2 GetRandomSpawnPosition()
    {
        // Randomly choose one of the four sides (top, bottom, left, right)
        int side = Random.Range(0, 4);

        Vector2 spawnPosition = Vector2.zero;

        switch (side)
        {
            case 0: // Top
                spawnPosition = new Vector2(Random.Range(stageMinX, stageMaxX), stageMaxY + 5); // Just above the top edge
                break;
            case 1: // Bottom
                spawnPosition = new Vector2(Random.Range(stageMinX, stageMaxX), stageMinY - 5); // Just below the bottom edge
                break;
            case 2: // Left
                spawnPosition = new Vector2(stageMinX - 5, Random.Range(stageMinY, stageMaxY)); // Just left of the left edge
                break;
            case 3: // Right
                spawnPosition = new Vector2(stageMaxX + 5, Random.Range(stageMinY, stageMaxY)); // Just right of the right edge
                break;
        }

        return spawnPosition;
    }
    void SpawnBullet()
    {
        GameObject bulletObject = bulletPooler.GetBullet();

        if (bulletObject != null) // Make sure there's an available bullet
        {
            bulletObject.SetActive(true); // Activate the bullet
            Bullet bullet = bulletObject.GetComponent<Bullet>();

            Vector2 spawnPosition = GetRandomSpawnPosition();
            bullet.SetPosition(spawnPosition);

            Vector2 centerOfStage = new Vector2((stageMaxX + stageMinX) / 2, (stageMaxY + stageMinY) / 2);
            Vector2 direction = (centerOfStage - spawnPosition).normalized;
            float angleOffset = Random.Range(-30f, 30f);
            direction = RotateVector(direction, angleOffset);
            bullet.SetDirection(direction);

            bullet.spawner = this; // Set reference to the spawner
        }
    }
    Vector2 RotateVector(Vector2 direction, float angleDegrees)
    {
        float angleRadians = angleDegrees * Mathf.Deg2Rad;
        float cos = Mathf.Cos(angleRadians);
        float sin = Mathf.Sin(angleRadians);

        return new Vector2(
            direction.x * cos - direction.y * sin,
            direction.x * sin + direction.y * cos
        );
    }
    // Notify when a bullet should be returned to the pool
    public void NotifyBulletDestroyed(GameObject bulletObject)
    {
        bulletPooler.ReturnBullet(bulletObject); // Return to pool instead of destroying
    }
}
