using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float range = 20f;
    [SerializeField] private float verticalRange = 20f;

    private BoxCollider boxColliderTrigger;

    private void Awake()
    {
        boxColliderTrigger = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        boxColliderTrigger.size = new Vector3(1, verticalRange, range);
        boxColliderTrigger.center = new Vector3(0, 0, range * 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        // add potential enemy to shoot
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            // add 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // remove potential enemy to shoot
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            // remove 
        }
    }
}
