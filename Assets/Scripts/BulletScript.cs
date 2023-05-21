using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public LayerMask enemyLayers;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    
    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (!hitInfo.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log(hitInfo.gameObject);
            
            if(hitInfo.gameObject.layer == 9)
                hitInfo.gameObject.GetComponent<EnemyDeath>().Die();
        }
            
    }
}
