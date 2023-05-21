using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Timeline;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask enemyLayers;
    public GameObject Boss;
    private float attackTimer = 0f;
    public float attackTimerTotal = 0.2f;
    public bool hasBlade = false;

    public GameObject flashParticles;
    private float flashTimer = 0f;
    public float flashTimerTotal = 0.3f;

    public GameObject armp1;
    public GameObject armp2;
    public GameObject armp3;
    public GameObject armp4;

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
        flashTimer -= Time.deltaTime;

        armp1.SetActive(hasBlade);
        armp2.SetActive(hasBlade);
        armp3.SetActive(hasBlade);
        armp4.SetActive(hasBlade);

        if (Input.GetKeyDown("q") && hasBlade)
        {
            if(attackTimer <= 0)
             Attack();
        }

        if(flashTimer < 0)
        {
            flashParticles.SetActive(false);
        }
    }

    void Attack()
    {
            animator.SetTrigger("Attack");

            flashParticles.SetActive(true);
            flashTimer = flashTimerTotal;
            
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.name == "Boss")
                {
                    Boss.GetComponent<Boss>().bossHealth -= 1;
                }
                Debug.Log("We hit " + enemy.name);
            //Destroy(enemy.gameObject);
            enemy.GetComponent<EnemyDeath>().Die();
            SimpleCameraShakeInCinemachine.CameraShaker.ShakeScreen(0.05f, 8, 6);
            }

            attackTimer = attackTimerTotal;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Get Arm")
        {
            hasBlade = true;
            Destroy(other.gameObject);
        }
    }
}
