using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform bossFirePoint;
    public GameObject bossBulletPrefab;
    private float bossShootTimer = 0f;
    public float bossShootTimerTotal = 0.5f;
    private float timeBetweenShoot = 0f;
    private float timeBetweenShootTime = 2f;
    public bool isShooting = true;
    public int bossHealth = 25;

    public bool hasGun = false;
    // Update is called once per frame
    void Update()
    {
        bossShootTimer -= Time.deltaTime;
        if (bossShootTimer <= 0 && isShooting)
        {
            Shoot();
        }

        if (bossHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        Instantiate(bossBulletPrefab, bossFirePoint.position, bossFirePoint.rotation);
        bossShootTimer = bossShootTimerTotal;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 10)
        {
            bossHealth--;
        }
        
        
    }
}