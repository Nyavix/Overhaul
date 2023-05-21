using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public LayerMask playerLayers;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.right * -speed;
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log(hitInfo.gameObject);
        }

        Destroy(gameObject);

    }
}