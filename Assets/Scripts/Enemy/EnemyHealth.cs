using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f;

    public void TakeDamage(float _damage)
    {
        enemyHealth -= _damage;

        if(enemyHealth <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        Destroy(this.gameObject);
    }
}
