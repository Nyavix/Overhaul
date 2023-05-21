using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private float shootTimer = 0f;
    public float shootTimerTotal = 1f;

    public bool hasGun = false;

    public GameObject gun;
    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;
        if (Input.GetKeyDown("w") && shootTimer <= 0 && hasGun)
        {
            Shoot();
        }

        gun.SetActive(hasGun);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        shootTimer = shootTimerTotal;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Get Gun")
        {
            hasGun = true;
            Destroy(other.gameObject);
        }
    }
}
