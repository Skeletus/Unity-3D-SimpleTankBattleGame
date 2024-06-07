using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private float enemyHealth = 5f;

    private void Update()
    {
        if (enemyHealth <= 0)
        {
            enemyManager.RemoveEnemy(this);
            Destroy(gameObject);
        }
    }

    private void TakeDamage(float damage)
    {
        enemyHealth -= damage;
    }
}
