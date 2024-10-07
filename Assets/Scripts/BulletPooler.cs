using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooler : MonoBehaviour
{
    public GameObject bulletPrefab; // Bullet prefab to instantiate
    public int poolSize = 100;      // Pool size (max bullets)
    private List<GameObject> bulletPool; // The pool of bullets

    // Initialize the bullet pool
    void Start()
    {
        bulletPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false); // Deactivate bullet initially
            bulletPool.Add(bullet);  // Add to pool
            bullet.transform.SetParent(transform);
        }
    }

    // Fetch an inactive bullet from the pool
    public GameObject GetBullet()
    {
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }

        return null; // No available bullets in pool (unlikely with proper pool size)
    }

    // Return a bullet to the pool
    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}

