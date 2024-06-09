using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwarness : MonoBehaviour
{
    [SerializeField] private Material aggresiveMaterial;
    private bool isAggro;

    private void Update()
    {
        if (isAggro)
        {
            GetComponent<Renderer>().material = aggresiveMaterial;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            isAggro = true;
        }
    }
}
