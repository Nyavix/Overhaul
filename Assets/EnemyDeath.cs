using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public GameObject deadEnemy;

    public void Die()
    {
        Instantiate(deadEnemy, transform.position, transform.rotation);
        Destroy(this.gameObject, 0.01f);
    }
}
