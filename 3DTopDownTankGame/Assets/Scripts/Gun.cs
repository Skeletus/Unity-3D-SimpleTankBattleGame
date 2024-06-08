using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float range = 20f;
    [SerializeField] private float verticalRange = 20f;
    [SerializeField] private float fireRate = 10f;
    [SerializeField] private float bigDamage = 5f;
    [SerializeField] private float smallDamage = 2f;
    private float nextTimeToFire;

    private BoxCollider boxColliderTrigger;

    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private LayerMask obstaclesLayerMask;

    private void Awake()
    {
        boxColliderTrigger = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        boxColliderTrigger.size = new Vector3(1, verticalRange, range);
        boxColliderTrigger.center = new Vector3(0, 0, range * 0.5f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire)
        {
            Fire();
        }
    }

    private void Fire()
    {
        // damage enemies 
        foreach(Enemy enemy in enemyManager.enemiesInTrigger)
        {
            // get direction to the enemy
            Vector3 direction = enemy.transform.position - transform.position;
            RaycastHit hit;

            if (Physics.Raycast(transform.position, direction, out hit, range * 1.5f, obstaclesLayerMask))
            {
                if (hit.transform == enemy.transform)
                {
                    // range check
                    float distance = Vector3.Distance(enemy.transform.position, transform.position);

                    if (distance > range * 0.5f)
                    {
                        // damage enemy small
                        Debug.Log("Dealing small damage");
                        enemy.TakeDamage(smallDamage);
                    }
                    else
                    {
                        // damage enemy big
                        Debug.Log("Dealing big damage");
                        enemy.TakeDamage(bigDamage);
                    }

                    //Debug.DrawRay(transform.position, direction, Color.green);
                }
            }

            
        }

        // reset time
        nextTimeToFire = Time.time + fireRate;
    }

    private void OnTriggerEnter(Collider other)
    {
        // add potential enemy to shoot
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy != null)
        {
            // add 
            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // remove potential enemy to shoot
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy != null)
        {
            // remove 
            enemyManager.RemoveEnemy(enemy);
        }
    }
}
